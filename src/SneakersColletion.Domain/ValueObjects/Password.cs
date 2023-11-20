using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakersColletion.Domain.ValueObjects
{
    public class Password
    {
        public string Value { get; }

        public Password(string value)
        {
            // Validation logic for password strength
            Value = value;
        }
    }
}
