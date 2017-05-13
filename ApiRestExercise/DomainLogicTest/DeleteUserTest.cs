

using ApplicationCore.DTOs;
using CrossCutting.Exceptions;
using DomainCore.Logic.UserLogic;
using DomainEntities;
using DomainLogic.Logic.UserLogic;
using DomainLogic.Rules.UserRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DomainLogicTest
{
    [TestClass]
    public class DeleteUserTest
    {
        IUserRule updateUserRule;
        IUserLogic getUserLogic;
        IUserLogic deleteUserlogic;
        List<User> userAll;

        [TestInitialize]
        public void Initialize()
        {
            updateUserRule = new UpdateUserRule();
            getUserLogic = new GetUserLogic();
            deleteUserlogic = new UpdateUserLogic(updateUserRule, getUserLogic);
            userAll = GetAllUsersFictitius();

        }

        [TestMethod]
        public void DeleteUser_Test()
        {
            UserDto userToUpdate = new UserDto
            {
                Id = 2,
                Name = "Nombre Modificado",
                BirthDate = new DateTime(1998, 11, 12)

            };
            deleteUserlogic.ValidationsToDelete(userAll.AsQueryable(), userToUpdate);
            bool hasError = false;
            Assert.IsTrue(hasError == false);
        }
 
        private static List<User> GetAllUsersFictitius()
        {
            return new List<User>()
            {
                new User
                {
                    Id = 1,
                    Name = "Nombre 1",
                    BirthDate = new DateTime(2000,4,23)
                },
                new User
                {
                    Id = 2,
                    Name = "Nombre 2",
                    BirthDate = new DateTime(1945,5,6)
                }
            };
        }
    }
}
