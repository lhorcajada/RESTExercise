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
    public class UserTest
    {
        IUpdateUserRule updateUserRule;
        IGetUserLogic getUserLogic;
        IUpdateUserLogic updateUserlogic;
        List<User> userAll;
        [TestInitialize]
        public void Initialized()
        {
            updateUserRule = new UpdateUserRule();
            getUserLogic = new GetUserLogic();
            updateUserlogic = new UpdateUserLogic(updateUserRule, getUserLogic);
            userAll = GetAllUsersFictitius();

        }
        [TestMethod]
        [TestCategory("Logic")]
        public void UpdateUser_Test()
        {
            UserDto userToUpdate = new UserDto
            {
                Id = 2,
                Name = "Nombre Modificado",
                BirthDate = new DateTime(1998, 11, 12)

            };
            updateUserlogic.LogicToUpdate(userAll.AsQueryable(), userToUpdate);
            bool hasError = false;
            Assert.IsTrue(hasError == false);
        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException), "El usuario debe ser mayor de 18 años.")]
        [TestCategory("Logic")]
        public void UpdateUser_HasNotLegalAge_Test()
        {
            UserDto userToAdd = new UserDto
            {
                Name = "Nombre 3",
                BirthDate = new DateTime(2016, 11, 12)

            };
            updateUserlogic.LogicToUpdate(userAll.AsQueryable(), userToAdd);
        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException), "El nombre de usuario ya existe.")]
        [TestCategory("Logic")]
        public void UpdateUser_ReturnExceptionNameRepeat_Test()
        {
            UserDto userToUpdate = new UserDto
            {
                Name = "Nombre 2",
                BirthDate = new DateTime(1945, 5, 6)

            };
            updateUserlogic.LogicToUpdate(userAll.AsQueryable(), userToUpdate);
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
