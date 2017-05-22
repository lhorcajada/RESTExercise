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
    public class UserAddressOV : ValueObject
    {
        private readonly string _street;

        public string Street
        {
            get { return _street; }
        }
        private readonly string _postalCode;

        public string PostalCode
        {
            get { return _postalCode; }
        }
        private readonly string _province;

        public string Province
        {
            get { return _province; }
        }
        private readonly string _country;

        public string Country
        {
            get { return _country; }
        }

        public UserAddressOV(string street, string postalCode, string province, string country)
        {
            _street = street;
            _postalCode = postalCode;
            _province = province;
            _country = country;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _street;
            yield return _province;
            yield return _country;
            yield return _postalCode;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}-{2} {3}",_street, _postalCode, _province, _country);
        }
    }
}
