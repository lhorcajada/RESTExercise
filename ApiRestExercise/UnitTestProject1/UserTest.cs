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
using APIRest.Controllers;

namespace APITest
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
        [TestInitialize]
        public void Initialize()
        {
            _dataFactory = new DataFactory();
            _uow = new UnitOfWork(_dataFactory);
            _userRepository = new UserRepository(_dataFactory);

        }
        private void InitizalizeAddLogic()
        {
            _addUserRule = new AddUserRule();
            _addUserLogic = new AddUserLogic(_addUserRule);
            _addUserService = new AddUserService(_uow, _userRepository, _addUserLogic);
        }
        [TestMethod]
        public async Task IntegrationTest_AddUser_ResultOk()
        {
            InitizalizeAddLogic();
            var userDto = new UserDto
            {
                Name = "Mi nombre",
                BirthDate = new DateTime(1973, 3, 7)
            };
            var userController = new UserController(_addUserService, _updateUserService, _deleteUserService, _getUserService);

            await userController.Post(userDto);
        }
    }
}
