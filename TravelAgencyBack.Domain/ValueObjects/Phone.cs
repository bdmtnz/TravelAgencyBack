using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Domain.ValueObjects
{
    public class Phone<T> : ValueObject<T> where T : IEntity
    {
        public int Indicative { get; set; }
        public string Value { get; set; }

        public Phone(int indicative, string value)
        {
            Indicative = indicative;
            Value = value;
        }
    }
}
