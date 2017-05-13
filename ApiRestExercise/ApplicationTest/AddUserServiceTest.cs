using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationCore.Contracts.UserContracts;
using ApplicationServices.ManagementUser;
using DomainCore.Repository;
using DomainCore.Logic.UserLogic;
using Rhino.Mocks;
using ApplicationCore.DTOs;
using System.Threading.Tasks;

namespace ApplicationTest
{
    [TestClass]
    public class AddUserServiceTest
    {
        IUnitOfWork _uow;
        IUserRepository _userRepository;
        IUserLogic _addUserLogic;
        [TestInitialize]
        public void Initialize()
        {
            _uow = MockRepository.GenerateStub<IUnitOfWork>();
            _userRepository = MockRepository.GenerateStub<IUserRepository>();
            _addUserLogic = MockRepository.GenerateStub<IUserLogic>();
        }
        [TestMethod]
        public async Task AddUserNoTrowException()
        {
            UserDto userToAdd = new UserDto
            {
                Name = "Nombre de prueba",
                BirthDate = new DateTime(1945, 5, 6)

            };
            _uow.Stub(x => x.CommitAsync()).Return();
            _addUserLogic.Stub(x => x.ValidationsToAdd(null, userToAdd)).IgnoreArguments();
            _userRepository.Stub(x => x.Add(null)).IgnoreArguments();

            IAddUserService addUserService = new AddUserService(_uow, _userRepository, _addUserLogic);
            await addUserService.AddUser(userToAdd);

  

        }
    }
}
