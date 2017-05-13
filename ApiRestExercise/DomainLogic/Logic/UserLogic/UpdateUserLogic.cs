using DomainCore.Logic.UserLogic;
using DomainLogic.Logic.UserLogic;

namespace DomainLogic.Logic.UserLogic
{
    /// <summary>
    /// Lógica para el mantenimiento de usuarios
    /// </summary>
    public class UpdateUserLogic : UserBaseLogic
    {
        public UpdateUserLogic(IUserRule userRules, IUserLogic getUserLogic) : base(userRules, getUserLogic)
        {
        }
    }
}
