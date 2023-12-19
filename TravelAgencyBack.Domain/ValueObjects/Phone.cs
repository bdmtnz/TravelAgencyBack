using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyBack.Domain.ValueObjects
{
    public class Phone
    {
        public int Indicative { get; set; }
        public string Value { get; set; }
        public Phone()
        {
            Value = string.Empty;
        }
    }
}
