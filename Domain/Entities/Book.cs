using Domain.Common;

namespace Domain.Entities
{
    public class Book : ModelBase
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        public double? Price { get; set; }
    }
}
