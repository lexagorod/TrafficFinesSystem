using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficFineSystem
{
    public readonly struct ActorType
    {
        private readonly string _value;

        public ActorType(string value) { _value = value; }

        public static implicit operator string(ActorType s) => s._value;

        public override string ToString() => _value;
    }
}
