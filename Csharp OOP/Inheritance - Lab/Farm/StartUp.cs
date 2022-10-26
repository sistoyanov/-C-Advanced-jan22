using System;

namespace Farm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Puppy dog = new Puppy();
            dog.Eat();
            dog.Bark();
            dog.Weep();

            Cat cat = new Cat();
            cat.Eat();
            cat.Meow();
        }
    }
}
