﻿using ApplicationCore.DTOs;
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
        IUserRule updateUserRule;
        IUserLogic getUserLogic;
        IUserLogic updateUserlogic;
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
        public void UpdateUser_Test()
        {
            UserDto userToUpdate = new UserDto
            {
                Id = 2,
                Name = "Nombre Modificado",
                BirthDate = new DateTime(1998, 11, 12)

            };
            updateUserlogic.ValidationsToUpdate(userAll.AsQueryable(), userToUpdate);
            bool hasError = false;
            Assert.IsTrue(hasError == false);
        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void UpdateUser_HasNotLegalAge_Test()
        {
            UserDto userToAdd = new UserDto
            {
                Name = "Nombre 3",
                BirthDate = new DateTime(2016, 11, 12)

            };
            updateUserlogic.ValidationsToUpdate(userAll.AsQueryable(), userToAdd);
        }
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void UpdateUser_ReturnExceptionNameRepeat_Test()
        {
            UserDto userToUpdate = new UserDto
            {
                Name = "Nombre 2",
                BirthDate = new DateTime(1945, 5, 6)

            };
            updateUserlogic.ValidationsToUpdate(userAll.AsQueryable(), userToUpdate);
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