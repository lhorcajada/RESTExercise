using CrossCutting.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace DomainEntities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(80, ErrorMessageResourceName = "ErrorUserNameValidated", ErrorMessageResourceType = typeof(Resource), MinimumLength = 8)]
        public string Name { get; set; }
        [DataType(DataType.DateTime, ErrorMessageResourceName = "ErrorDataTimeValidated", ErrorMessageResourceType = typeof(Resource))]
        public DateTime BirthDate { get; set; }
    }
}
