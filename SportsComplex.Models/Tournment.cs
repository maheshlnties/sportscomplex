namespace SportsComplex.Models
{
    public class Tournment
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Fees { get; set; }

        public int CreatedDate { get; set; }

        public int LastDate { get; set; }

        public int IsEnrolled { get; set; }
    }
}
