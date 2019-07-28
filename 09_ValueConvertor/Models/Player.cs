using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace _00_Core.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Team Team { get; set; }

        public Position Position { get; set; }

        public string CardCode { get; set; } 
    }

    public enum Position
    {
        GK,
        FB,
        CB,
        CF
    }

    class EncryptedConverter : ValueConverter<string, string>
    {
        public EncryptedConverter(ConverterMappingHints mappingHints = default)
            : base(EncryptExpr, DecryptExpr, mappingHints)
        { }

        static Expression<Func<string, string>> DecryptExpr = x => new string(x.Reverse().ToArray());
        static Expression<Func<string, string>> EncryptExpr = x => new string(x.Reverse().ToArray());
    }
}