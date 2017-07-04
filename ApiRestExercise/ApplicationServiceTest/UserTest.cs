using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using DomainCore.Repository;
using DomainCore.Logic.UserLogic;
using Data.Repository;
using DomainLogic.Rules.UserRules;
using DomainLogic.Logic.UserLogic;
using ApplicationCore.Contracts.UserContracts;
using ApplicationServices.ManagementUser;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using CrossCutting.Exceptions;
using CrossCutting.Resources;
using System.Linq;
using System.Data.Entity.Validation;

namespace ApplicationServiceTest
{
    [TestClass]
    public class UserTest
    {
        IDataFactory _dataFactory;
        IUnitOfWork _uow;
        IUserRepository _userRepository;
        IAddUserLogic _addUserLogic;
        IUpdateUserLogic _updateUserLogic;
        IDeleteUserLogic _deleteUserLogic;
        IGetUserLogic _getUserLogic;
        IAddUserRule _addUserRule;
        IUpdateUserRule _updateUserRule;
        IAddUserService _addUserService;
        IUpdateUserService _updateUserService;
        IDeleteUserService _deleteUserService;
        IGetUserService _getUserService;
        UserDto _userToAdd;

        [TestInitialize]
        public void Initialize()
        {
            _dataFactory = new DataFactory();
            _uow = new UnitOfWork(_dataFactory);
            _userRepository = new UserRepository(_dataFactory);
            _addUserRule = new AddUserRule();
            _addUserLogic = new AddUserLogic(_addUserRule);
            _addUserService = new AddUserService(_uow, _userRepository, _addUserLogic);
            _getUserLogic = new GetUserLogic();
            _getUserService = new GetUserService(_userRepository, _getUserLogic);
            _updateUserRule = new UpdateUserRule();
            _updateUserLogic = new UpdateUserLogic(_updateUserRule, _getUserLogic);
            _updateUserService = new UpdateUserService(_uow, _userRepository, _updateUserLogic);
            _deleteUserLogic = new DeleteUserLogic(_getUserLogic);
            _deleteUserService = new DeleteUserService(_uow, _userRepository, _deleteUserLogic);



        }

        


        [TestMethod]
        [TestCategory("Integration")]
        public async Task IntegrationTest_AddUser_ResultOk()
        {
            _userToAdd = new UserDto
            {
                Name = "Yo mismo",
                BirthDate = new DateTime(1973, 3, 7),                
            };
            await _addUserService.AddUser(_userToAdd);
            _getUserService = new GetUserService(_userRepository, _getUserLogic);
            var userAll = await _getUserService.GetUserAll();
            var userGot = userAll.FirstOrDefault(u => u.Name.Contains(_userToAdd.Name));
            Assert.AreEqual(_userToAdd.Name, userGot.Name);
            Assert.AreEqual(_userToAdd.BirthDate, userGot.BirthDate);
            await _deleteUserService.DeleteUser(userGot.Id);

        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException), "El usuario debe ser mayor de 18 años.")]
        [TestCategory("Integration")]
        public async Task IntegrationTest_AddUser_ResultUserHasNotLegalAge()
        {

            _userToAdd = new UserDto
            {
                Name = "Yo mismo",
                BirthDate = new DateTime(2012, 3, 7)
            };


            await _addUserService.AddUser(_userToAdd);


        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException), "El nombre de usuario ya existe.")]
        [TestCategory("Integration")]
        public async Task IntegrationTest_AddUser_ResultCannotRepeatName()
        {
            var userAll = await _getUserService.GetUserAll();
            var userGot = userAll.Last();
            await _addUserService.AddUser(userGot);
            await _deleteUserService.DeleteUser(userGot.Id);

        }
        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof(DbEntityValidationException))]
        public async Task IntegrationTest_AddUser_ResultNameHasNotMinimumLong()
        {
            _userToAdd = new UserDto
            {
                Name = "Yo",
                BirthDate = new DateTime(1976, 3, 7)
            };


            await _addUserService.AddUser(_userToAdd);
        }
        [TestMethod]
        [TestCategory("Integration")]
        [ExpectedException(typeof(BusinessException), "El usuario no ha sido informado.")]
        public async Task IntegrationTest_AddUser_ResultUserNull()
        {
            _userToAdd = null;


            await _addUserService.AddUser(_userToAdd);
        }

        [TestMethod]
        [TestCategory("Integration")]
        public async Task IntegrationTest_UdateUser_ResultOk()
        {
            var userAll = await _getUserService.GetUserAll();
            var userGot = userAll.Last();

            var previousBirthDate = userGot.BirthDate;
            userGot.BirthDate = new DateTime(1974, 4, 5);

            await _updateUserService.UpdateUser(userGot);
        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException), "El usuario debe ser mayor de 18 años.")]
        [TestCategory("Integration")]
        public async Task IntegrationTest_UdateUser_ResultUserHasNotLegalAge()
        {
            var userAll = await _getUserService.GetUserAll();
            var userGot = userAll.Last();

            var previousBirthDate = userGot.BirthDate;
            userGot.BirthDate = new DateTime(2012, 4, 5);

            await _updateUserService.UpdateUser(userGot);

        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException), "El nombre de usuario ya existe.")]
        [TestCategory("Integration")]
        public async Task IntegrationTest_UpdateUser_ResultCannotRepeatName()
        {
            var userAll = await _getUserService.GetUserAll();
            var userGot = userAll.Last();
            var firstUser = userAll.First();
            var previousBirthDate = userGot.BirthDate;
            userGot.BirthDate = new DateTime(2012, 4, 5);
            userGot.Name = firstUser.Name;
            await _updateUserService.UpdateUser(userGot);

        }

    }
}

