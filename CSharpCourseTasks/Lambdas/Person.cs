using System;

namespace Lambdas
{
    class Person
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public Person(string name, int age)
        {
            Name = name;

            if (age < 0)
            {
                throw new ArgumentException("The age can't be < 0, now it is " + age, nameof(age));
            }

            Age = age;
        }
    }
}
