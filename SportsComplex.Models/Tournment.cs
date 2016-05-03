using System;

namespace SportsComplex.Models
{
    public class Tournment
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Fees { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime TournmentDate { get; set; }

        public DateTime LastDate { get; set; }

        public bool IsEnrolled { get; set; }

        public bool IsDeleted { get; set; }
    }
}
