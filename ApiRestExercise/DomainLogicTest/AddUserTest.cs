

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
    public class AddUserTest
    {
        IAddUserRule addUserRule;
        IAddUserLogic addUserLogic;
        List<User> userAll;
        [TestInitialize]
        public void Initialize()
        {
            addUserRule = new AddUserRule();
            addUserLogic = new AddUserLogic(addUserRule);
            userAll = GetAllUsersFictitius();

        }
        [TestMethod]
        [TestCategory("Logic")]

        public void AddUserThatNotExists_Test()
        {
            UserDto userToAdd = new UserDto
            {
                Name = "Nombre 3",
                BirthDate = new DateTime(1995, 11, 12)

            };
            addUserLogic.ValidationsToAdd(userAll.AsQueryable(), userToAdd);
            bool hasError = false;
            Assert.IsTrue(hasError == false);
        }



        [TestMethod]
        [ExpectedException(typeof(BusinessException), "El usuario debe ser mayor de 18 años.")]
        [TestCategory("Logic")]
        public void AddUser_HasNotLegalAge_Test()
        {
            UserDto userToAdd = new UserDto
            {
                Name = "Nombre 3",
                BirthDate = new DateTime(2016, 11, 12)

            };
            addUserLogic.ValidationsToAdd(userAll.AsQueryable(), userToAdd);
        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException), "El nombre de usuario ya existe.")]
        [TestCategory("Logic")]
        public void AddUser_ReturnExceptionNameRepeat_Test()
        {
            UserDto userToAdd = new UserDto
            {
                Name = "Nombre 2",
                BirthDate = new DateTime(1945, 5, 6)

            };
            addUserLogic.ValidationsToAdd(userAll.AsQueryable(), userToAdd);
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
