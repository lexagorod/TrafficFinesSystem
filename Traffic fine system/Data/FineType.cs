using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traffic_fine_system
{
    [Serializable]
    public readonly struct FineType
    {
        private readonly string _value;

        public FineType(string value) { _value = value; }

        public static implicit operator string(FineType s) => s._value;

        public override string ToString() => _value;
    }
}
