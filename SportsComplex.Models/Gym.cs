using System;

namespace SportsComplex.Models
{
    public class Gym
    {
        public string PsNumber { get; set; }

        public bool Jonined { get; set; }

        public DateTime? JoninedOn { get; set; }

        public DateTime? LeftOn { get; set; }
    }
}
