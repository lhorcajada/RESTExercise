using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomainCore.Repository;
using Data;
using Data.Repository;
using DomainEntities;
using System.Linq;
using System.Data.Entity.Validation;

namespace Data.Test
{
    [TestClass]
    public class UserManagement_Test
    {
        IDataFactory _dataFactory;
        IUnitOfWork _uow;
        [TestInitialize]
        public void Initialize()
        {
            _dataFactory = new DataFactory();
            _uow = new UnitOfWork(_dataFactory);

        }

        [TestMethod]
        [TestCategory("Data")]

        public void AddAndDeleteUserThatNotExists_Test()
        {
            IUserRepository userRepository;
            User userToAdd;
            int commitResult;
            AddUser(out userRepository, out userToAdd, out commitResult);

            Assert.IsTrue(commitResult > 0);

            User userInserted = GetUserByNameWithTracking(userRepository, userToAdd);
            Assert.AreEqual(userInserted.Name, userToAdd.Name);
            DeleteUser(userRepository, userInserted);

        }
        [TestMethod]
        [TestCategory("Data")]

        public void AddAndDeleteUserWithDeliveryAddressThatNotExists_Test()
        {
            IUserRepository userRepository;
            User userToAdd;
            int commitResult;
            AddUserWithDeliveryAddress(out userRepository, out userToAdd, out commitResult);

            Assert.IsTrue(commitResult > 0);

            User userInserted = GetUserByNameWithTracking(userRepository, userToAdd);
            Assert.AreEqual(userInserted.Name, userToAdd.Name);
            DeleteUser(userRepository, userInserted);

        }



        [TestMethod]
        [TestCategory("Data")]
        public void UpdateUserThatNotExists_Test()
        {
            IUserRepository userRepository;
            User userToAdd;
            int commitResult;
            AddUser(out userRepository, out userToAdd, out commitResult);
            User userToUpdate = GetUserByNameWithTracking(userRepository, userToAdd);
            userToUpdate.Name = "Nombre modificado";
            userToUpdate.BirthDate = new DateTime(1999, 2, 27);

            UpdateUser(userRepository, userToUpdate);
            Assert.IsTrue(commitResult > 0);
            DeleteUser(userRepository, userToUpdate);

        }
        public User CreateUserFictitius()
        {
            return new User
            {
                Name = "Nombre del primer usuario",
                BirthDate = new DateTime(1994, 5, 12),
                Address = new UserAddress("Mi calle","","",""),
                DeliveryAddress = new UserAddress("", "", "", "")
            };
        }
        public User CreateUserFictitiusWithDeliveryAddress()
        {
            return new User
            {
                Name = "Nombre del primer usuario",
                BirthDate = new DateTime(1994, 5, 12),
                Address = new UserAddress("Mi calle", "", "", ""),
                DeliveryAddress = new UserAddress("Mi calle de entrega","","","") 
            };
        }
        private void DeleteUser(IUserRepository userRepository, User userToDelete)
        {
            userRepository.Delete(userToDelete);
            _uow.Commit();
        }
        private void UpdateUser(IUserRepository userRepository, User userToUpdate)
        {
            userRepository.Update(userToUpdate);
            _uow.Commit();
        }
        private static User GetUserByNameWithTracking(IUserRepository userRepository, User userToAdd)
        {
            return userRepository.GetAllWithTracking().FirstOrDefault(u => u.Name.Contains(userToAdd.Name));
        }

        private void AddUser(out IUserRepository userRepository, out User userToAdd, out int commitResult)
        {
            userRepository = new UserRepository(_dataFactory);
            userToAdd = CreateUserFictitius();
            userRepository.Add(userToAdd);
            commitResult = _uow.Commit();

        }
        private void AddUserWithDeliveryAddress(out IUserRepository userRepository, out User userToAdd, out int commitResult)
        {
            userRepository = new UserRepository(_dataFactory);
            userToAdd = CreateUserFictitiusWithDeliveryAddress();
            userRepository.Add(userToAdd);
            commitResult = _uow.Commit();

        }
    }
}
