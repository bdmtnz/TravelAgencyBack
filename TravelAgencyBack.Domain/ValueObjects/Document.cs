using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public class Document
    {
        public DocumentType Type { get; set; }
        public string Value { get; set; }
        public Document(DocumentType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
