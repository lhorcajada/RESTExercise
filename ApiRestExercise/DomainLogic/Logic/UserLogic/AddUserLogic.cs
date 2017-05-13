using DomainCore.Logic.UserLogic;

namespace DomainLogic.Logic.UserLogic
{
    /// <summary>
    /// Lógica para el mantenimiento de usuarios
    /// </summary>
    public class AddUserLogic : UserBaseLogic
    {
       
        public AddUserLogic(IUserRule userRules) : base(userRules)
        {
        }

      
    }
}
