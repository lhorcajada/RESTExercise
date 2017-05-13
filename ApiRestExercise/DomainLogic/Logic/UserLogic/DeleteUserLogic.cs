
using DomainCore.Logic.UserLogic;

namespace DomainLogic.Logic.UserLogic

{
    /// <summary>
    /// Lógica para el mantenimiento de usuarios
    /// </summary>
    public class DeleteUserLogic : UserBaseLogic
    {
        public DeleteUserLogic(IUserLogic getUserLogic) : base(getUserLogic)
        {
        }
    }
}
