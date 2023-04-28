using System;

namespace WonderlandAnimal.Models
{
    public class AnimalVisitedLocation
    {
        public long Id { get; set; }
        public DateTime DateTimeOfVisitLocationPoint { get; set; }
        public long LocationPointId { get; set; }
    }
}
