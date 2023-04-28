using System;

namespace WonderlandAnimal.Services
{
    public class RandomGenerator
    {
        public static int GetRndNumber()
        {
            Guid guid = Guid.NewGuid();
            Random random = new Random();
            return random.Next();
        }
    }
}