using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Domain.ValueObjects
{
    public class Phone : IValueObject
    {
        public int Indicative { get; private set; }
        public string Value { get; private set; }

        public Phone(int indicative, string value)
        {
            Indicative = indicative;
            Value = value;
        }
    }
}
