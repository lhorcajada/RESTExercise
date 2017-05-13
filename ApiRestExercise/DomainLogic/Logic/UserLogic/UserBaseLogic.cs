using ApplicationCore.DTOs;
using CrossCutting.Exceptions;
using CrossCutting.Resources;
using DomainCore.Logic.UserLogic;
using DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLogic.Logic.UserLogic
{
    public abstract class UserBaseLogic:IUserLogic
    {
        public readonly IUserRule _userRules;
        public readonly IUserLogic _getUserLogic;
        public UserBaseLogic(IUserRule userRules)
        {
            if (userRules == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _userRules = userRules;
        }

        public UserBaseLogic(IUserLogic getUserLogic)
        {
            if (getUserLogic == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _getUserLogic = getUserLogic;

        }
        public UserBaseLogic(IUserRule userRules, IUserLogic getUserLogic)
        {
            if (userRules == null || getUserLogic == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _userRules = userRules;
            _getUserLogic = getUserLogic;
        }
        public UserBaseLogic()
        {

        }
        public void ValidationsToAdd(IQueryable<User> userAll, UserDto user)
        {
            _userRules.ApplyRules(userAll, user);


        }
        public IQueryable<User> ValidationsToDelete(IQueryable<User> userAll, UserDto user)
        {
            return _getUserLogic.QueryToGetUserById(userAll, user.Id);
        }
        public IQueryable<User> QueryToGetUserById(IQueryable<User> userAll, int userId)
        {
            return userAll.Where(u => u.Id == userId);
        }
        public IQueryable<User> ValidationsToUpdate(IQueryable<User> userAll, UserDto user)
        {
            _userRules.ApplyRules(userAll, user);
            return _getUserLogic.QueryToGetUserById(userAll, user.Id);

        }

        public void ValidationsToGetById(User userFinded)
        {
            if (userFinded == null)
                throw new BusinessException(Resource.ExceptionUserNotFound);
        }
    }
}
