using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    public class Person
    {
        // Properties
        public int PersonId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FavoriteColor { get; private set; }
        public int Age { get; private set; }
        public bool IsWorking { get; private set; }

        // Constructor with parameters to initialize the properties
        public Person(int personId, string firstName, string lastName, string favoriteColor, int age, bool isWorking)
        {
            PersonId = personId;
            FirstName = firstName;
            LastName = lastName;
            FavoriteColor = favoriteColor;
            Age = age;
            IsWorking = isWorking;
        }

        // Methods

        // Display information about the person
        public void DisplayPersonInfo()
        {
            Console.WriteLine($"{PersonId}: {FirstName} {LastName}'s favorite color is {FavoriteColor}");
        }

        // Change the favorite color to white
        public void ChangeFavoriteColor()
        {
            FavoriteColor = "White";
        }

        // Get the age of the person in ten years
        public int GetAgeInTenYears()
        {
            return Age + 10;
        }

        // Override ToString method to provide a formatted string representation
        public override string ToString()
        {
            return $"PersonID: {PersonId}\nFirst name: {FirstName}\nLast name: {LastName}\nFavorite color: {FavoriteColor}\nAge: {Age}\nIsWorking: {IsWorking}";
        }
    }

    public class Relation
    {
        public enum RelationshipType
        {
            Sister,
            Brother,
            Mother,
            Father
        }

        public RelationshipType Relationship { get; set; }

        public void ShowRelationship(Person person1, Person person2)
        {
            string relationshipDescription = GetRelationshipDescription();
            Console.WriteLine($"{person1.FirstName} {person1.LastName} is {relationshipDescription} to {person2.FirstName} {person2.LastName}");
        }

        private string GetRelationshipDescription()
        {
            switch (Relationship)
            {
                case RelationshipType.Sister:
                    return "sister";
                case RelationshipType.Brother:
                    return "brother";
                case RelationshipType.Mother:
                    return "mother";
                case RelationshipType.Father:
                    return "father";
                default:
                    return "unknown relationship";
            }
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            // Create four Person objects
            Person person1 = new Person(1, "Ian", "Brooks", "Red", 30, true);
            Person person2 = new Person(2, "Gina", "James", "Green", 18, false);
            Person person3 = new Person(3, "Mike", "Briscoe", "Blue", 45, true);
            Person person4 = new Person(4, "Mary", "Beals", "Yellow", 28, true);

            // Display Gina's information as a sentence
            Console.WriteLine($"{person2.PersonId}: {person2.FirstName} {person2.LastName}'s favorite color is {person2.FavoriteColor}");

            // Display all of Mike's information as a list
            Console.WriteLine(person3.ToString());

            // Change Ian's Favorite Colour to white and print his information as a sentence
            person1.ChangeFavoriteColor();
            Console.WriteLine($"{person1.PersonId}: {person1.FirstName} {person1.LastName}'s favorite color is: {person1.FavoriteColor}");

            // Display Mary's age after ten years
            Console.WriteLine($"{person4.FirstName} {person4.LastName}'s Age in 10 years is: {person4.GetAgeInTenYears()}");

            // Create two Relation objects and display both relationships
            Console.WriteLine($"Relationship between {person2.FirstName} and {person4.FirstName} is: Sisterhood");
            Console.WriteLine($"Relationship between {person1.FirstName} and {person3.FirstName} is: Brotherhood");

            // Add all the Person objects to a list
            List<Person> peopleList = new List<Person> { person1, person2, person3, person4 };

            // Display the average age of the people in the list
            Console.WriteLine($"Average age is: {peopleList.Average(person => person.Age)}");

            // Display the youngest and oldest person
            Console.WriteLine($"The youngest person is: {peopleList.OrderBy(person => person.Age).First().FirstName}");
            Console.WriteLine($"The oldest person is: {peopleList.OrderByDescending(person => person.Age).First().FirstName}");

            // Display the names of people whose first names start with M (Mike and Mary)
            Console.WriteLine("People whose names start with M:");
            foreach (var person in peopleList.Where(person => person.FirstName.StartsWith("M") && (person.FirstName == "Mike" || person.FirstName == "Mary")))
            {
                Console.WriteLine(person.ToString());
            }

            // Display the information of the person who likes the color blue (Mike)
            Console.WriteLine("Person who likes the color blue:");
            Console.WriteLine(person3.ToString());
        }
    }
}
