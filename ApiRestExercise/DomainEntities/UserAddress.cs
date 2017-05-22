using CrossCutting.Resources;
using CrossCutting.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public class UserAddress:ValueObject
    {
        public UserAddress(string street, string postalCode, string province, string country)
        {
            Street = street;
            PostalCode = postalCode;
            Province = province;
            Country = country;

        }
        public UserAddress()
        {

        }
        public string Street { get; private set; }
        public string PostalCode { get; private set; }
        public string Province { get; private set; }
        public string Country { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return Province;
            yield return Country;
            yield return PostalCode;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}-{2} {3}", Street, PostalCode, Province, Country);
        }
    }
}
