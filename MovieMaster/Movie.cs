using System.ComponentModel.DataAnnotations;

namespace MovieMaster
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Runtime { get; set; }

        public override string ToString()
        {
            return $"{Title}, {Genre}, {Runtime}";
        }
    }
}
