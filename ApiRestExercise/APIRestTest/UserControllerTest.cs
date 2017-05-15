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
using Rhino.Mocks;
using APIRest.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Collections.Generic;
using DomainEntities;

namespace APIRestTest
{
    [TestClass]
    public class UnitTest1
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
            _dataFactory = MockRepository.GenerateStub<IDataFactory>();
            _uow = MockRepository.GenerateStub<IUnitOfWork>();
            _userRepository = MockRepository.GenerateStub<IUserRepository>();
            _addUserRule = MockRepository.GenerateStub<IAddUserRule>();
            _addUserLogic = MockRepository.GenerateStub<IAddUserLogic>();
            _addUserService = MockRepository.GenerateStub<IAddUserService>();
            _getUserLogic = MockRepository.GenerateStub<IGetUserLogic>();
            _getUserService = MockRepository.GenerateStub<IGetUserService>();
            _updateUserRule = MockRepository.GenerateStub<IUpdateUserRule>();
            _updateUserLogic = MockRepository.GenerateStub<IUpdateUserLogic>();
            _updateUserService = MockRepository.GenerateStub<IUpdateUserService>();
            _deleteUserLogic = MockRepository.GenerateStub<IDeleteUserLogic>();
            _deleteUserService = MockRepository.GenerateStub<IDeleteUserService>();
        }
        private List<User> GetUserAll()
        {
            List<User> users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Name = "Nombre 1",
                    BirthDate = new DateTime(1973, 5,3)
                },
                new User
                {
                    Id = 2,
                    Name = "Nombre 2",
                    BirthDate = new DateTime(1973, 12,23)
                },

            };
            return users;
        }
        private List<UserDto> GetUserDtoAll()
        {
            List<UserDto> users = new List<UserDto>
            {
                new UserDto
                {
                    Id = 1,
                    Name = "Nombre 1",
                    BirthDate = new DateTime(1973, 5,3)
                },
                new UserDto
                {
                    Id = 2,
                    Name = "Nombre 2",
                    BirthDate = new DateTime(1973, 12,23)
                },

            };
            return users;
        }


        [TestMethod]
        [ExpectedException(typeof(BusinessException), "Usuario no encontrado con ese código.")]
        [TestCategory("UnitTestUserController")]
        public async Task GetReturnsNotFound()
        {
            // Arrange
            _getUserService.Stub(s => s.GetUserById(45))
                .Throw(new BusinessException(Resource.ExceptionUserNotFound));

            var controller = new UserController(
                _addUserService,
                _updateUserService,
                _deleteUserService,
                _getUserService);

            // Act
            IHttpActionResult actionResult = await controller.Get(45);

        }
        [TestMethod]
        [TestCategory("UnitTestUserController")]
        public async Task GetReturnsUserWithSameId()
        {
            // Arrange


            _getUserService.Stub(s => s.GetUserById(45))
                .Return(Task.FromResult<UserDto>(new UserDto { Id = 45 }));


            var controller = new UserController(
                _addUserService,
                _updateUserService,
                _deleteUserService,
                _getUserService);

            // Act
            IHttpActionResult actionResult = await controller.Get(45);
            var contentResult = actionResult as OkNegotiatedContentResult<UserDto>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(45, contentResult.Content.Id);


        }
        [TestMethod]
        [TestCategory("UnitTestUserController")]
        public async Task PostMethodSetsLocationHeader()
        {
            // Arrange
            UserDto userDto = new UserDto
            {
                Name = "Prueba",
                BirthDate = new DateTime(1945, 2, 5)
            };
            _addUserService.Stub(s => s.AddUser(userDto)).Return(Task.CompletedTask);
            _getUserService.Stub(g => g.GetUserAll()).Return(Task.FromResult<IEnumerable<UserDto>>(GetUserDtoAll().AsEnumerable()));
            var controller = new UserController(
                _addUserService,
                _updateUserService,
                _deleteUserService,
                _getUserService);

            // Act
            IHttpActionResult actionResult = await controller.Post(userDto);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<UserDto>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("GetById", createdResult.RouteName);
            Assert.AreEqual(2, createdResult.RouteValues["id"]);

        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException), "El nombre de usuario ya existe.")]
        [TestCategory("UnitTestUserController")]
        public async Task PostReturnsThrowExceptionRepeatName()
        {
            // Arrange
            UserDto userDto = new UserDto
            {
                Id = 1,
                Name = "Prueba",
                BirthDate = new DateTime(1945, 2, 5)
            };
            _addUserService.Stub(s => s.AddUser(userDto))
                .Throw(new BusinessException(Resource.ExceptionUserNameNoRepeat));
            var controller = new UserController(
                _addUserService,
                _updateUserService,
                _deleteUserService,
                _getUserService);

            // Act
            IHttpActionResult actionResult = await controller.Post(userDto);
        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException), "El usuario debe ser mayor de 18 años.")]
        [TestCategory("UnitTestUserController")]
        public async Task PostReturnsThrowExceptionUserHasNotLegalAge()
        {
            // Arrange
            UserDto userDto = new UserDto
            {
                Id = 1,
                Name = "Prueba",
                BirthDate = new DateTime(1945, 2, 5)
            };
            _addUserService.Stub(s => s.AddUser(userDto))
                .Throw(new BusinessException(Resource.ExceptionUserMustBeLegalAge));
            var controller = new UserController(
                _addUserService,
                _updateUserService,
                _deleteUserService,
                _getUserService);

            // Act
            IHttpActionResult actionResult = await controller.Post(userDto);
        }

        [TestMethod]
        [TestCategory("UnitTestUserController")]
        public async Task PutReturnsContentResult()
        {
            // Arrange
            UserDto userDto = new UserDto
            {
                Id = 1,
                Name = "Prueba",
                BirthDate = new DateTime(1945, 2, 5)
            };
            _updateUserService.Stub(s => s.UpdateUser(userDto)).Return(Task.CompletedTask);
            _getUserService.Stub(g => g.GetUserAll()).Return(Task.FromResult<IEnumerable<UserDto>>(GetUserDtoAll().AsEnumerable()));
            var controller = new UserController(
                _addUserService,
                _updateUserService,
                _deleteUserService,
                _getUserService);

            // Act
            IHttpActionResult actionResult = await controller.Put(1,userDto);
            var contentResult = actionResult as OkNegotiatedContentResult<UserDto>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException), "El nombre de usuario ya existe.")]
        [TestCategory("UnitTestUserController")]
        public async Task PutReturnsThrowExceptionRepeatName()
        {
            // Arrange
            UserDto userDto = new UserDto
            {
                Id = 1,
                Name = "Prueba",
                BirthDate = new DateTime(1945, 2, 5)
            };
            _updateUserService.Stub(s => s.UpdateUser(userDto))
                .Throw(new BusinessException(Resource.ExceptionUserNameNoRepeat));
            var controller = new UserController(
                _addUserService,
                _updateUserService,
                _deleteUserService,
                _getUserService);

            // Act
            IHttpActionResult actionResult = await controller.Put(1, userDto);
        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException), "El usuario debe ser mayor de 18 años.")]
        [TestCategory("UnitTestUserController")]
        public async Task PutReturnsThrowExceptionUserHasNotLegalAge()
        {
            // Arrange
            UserDto userDto = new UserDto
            {
                Id = 1,
                Name = "Prueba",
                BirthDate = new DateTime(1945, 2, 5)
            };
            _updateUserService.Stub(s => s.UpdateUser(userDto))
                .Throw(new BusinessException(Resource.ExceptionUserMustBeLegalAge));
            var controller = new UserController(
                _addUserService,
                _updateUserService,
                _deleteUserService,
                _getUserService);

            // Act
            IHttpActionResult actionResult = await controller.Put(1, userDto);
        }

        [TestMethod]
        [TestCategory("UnitTestUserController")]
        public async Task DeleteReturnsContentResult()
        {
            // Arrange
            UserDto userDto = new UserDto
            {
                Id = 1,
                Name = "Prueba",
                BirthDate = new DateTime(1945, 2, 5)
            };
            _deleteUserService.Stub(s => s.DeleteUser(1)).Return(Task.CompletedTask);
            var controller = new UserController(
                _addUserService,
                _updateUserService,
                _deleteUserService,
                _getUserService);

            // Act
            IHttpActionResult actionResult = await controller.Delete(1);
            var contentResult = actionResult as OkNegotiatedContentResult<int>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.AreEqual(1, contentResult.Content);
        }

    }
}
