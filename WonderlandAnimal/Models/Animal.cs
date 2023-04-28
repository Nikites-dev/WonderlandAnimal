using System;

namespace WonderlandAnimal.Models
{
    public class Animal
    {
        public long Id { get; set; }
        public long[] AnimalTypes { get; set; }
        
        public float Weight { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public String Gender { get; set; } // MALE, FEMALE, OTHER
        
        public String LifeStatus { get; set; } // ALIVE, DEAD
        public DateTime ChippingDateTime { get; set; } // ISO-8601
        
        public int ChipperId { get; set; } // user id
        public long ChippingLocationId { get; set; }
        
        public long[] VisitedLocations { get; set; }
        public DateTime? DeathDateTime { get; set; }
        
    }
}
