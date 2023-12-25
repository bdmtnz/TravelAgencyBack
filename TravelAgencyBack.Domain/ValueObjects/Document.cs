using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyBack.Domain.Base;
using TravelAgencyBack.Domain.Contracts;

namespace TravelAgencyBack.Domain.ValueObjects
{
    public enum DocumentType
    {
        CC,
        TI,
        NUIP,
        PP,
        EXT
    }

    public class Document : IValueObject
    {
        public DocumentType Type { get; private set; }
        public string Value { get; private set; }
        public Document()
        {
            
        }
        public Document(DocumentType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
