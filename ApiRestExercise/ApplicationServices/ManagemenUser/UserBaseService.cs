using CrossCutting.Resources;
using DomainCore.Logic.UserLogic;
using DomainCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.ManagemenUser
{
    public abstract class UserBaseService
    {
        public readonly IUnitOfWork _uow;
        public readonly IUserRepository _userRepository;
        public readonly IUserLogic _userLogic;
        public UserBaseService(
            IUnitOfWork uow,
            IUserRepository userRepository,
            IUserLogic userLogic
            )
        {
            if (uow == null || userRepository == null || userLogic == null)
                throw new ArgumentNullException(Resource.ExceptionNullObject);
            _uow = uow;
            _userRepository = userRepository;
            _userLogic = userLogic;
        }
    }
}
