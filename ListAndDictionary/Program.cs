using System.ComponentModel;
using System.IO.Pipes;

namespace ListAndDictionary
{
    internal class Program
    {
        // List variable containing names of persons
        private static List<string> personList = new List<string>();

        // Dictionary containing person name and age where the string TKey is for name and the int TValue is for age
        private static Dictionary<string, int> personAgeDictionary = new Dictionary<string, int>();

        public static void Main()
        {
            Console.WriteLine("Welcome to the Person Manager!");
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Add New Person");
                Console.WriteLine("2. Remove Person");
                Console.WriteLine("3. Find Person");
                Console.WriteLine("4. List All Persons");
                Console.WriteLine("5. Exit");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        AddPerson();
                        break;
                    case "2":
                        RemovePerson();
                        break;
                    case "3":
                        FindPerson();
                        break;
                    case "4":
                        DisplayAllPersons();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        public static void AddPerson()
        {
            // TODO 1: Request user input for the person's name.
            Console.WriteLine("Please input the person's name");
            string input = Console.ReadLine();
            // TODO 2: Validate if the person already exists in the personList.
            if (personList.Contains(input))
            {
                Console.WriteLine("This person is already in the list");
            }
            // TODO 3: Add the person to the personList if they don't already exist.
            else
            {
                personList.Add(input);
                Console.WriteLine("{0} succecfully added to the list", input);
            }
            // TODO 4: Provide user feedback for successful addition or if the person already exists in personList.
            // TODO 5: Validate if the person already exists in the personAgeDictionary.
            if (personAgeDictionary.ContainsKey(input))
            {
                Console.WriteLine("This person's age is already known");
            }
            // TODO 6: If they don't exist, request age input and add the person to the personAgeDictionary.
            //         NOTE!: Remember to add both TKey and TValue
            else
            {
                Console.WriteLine("Please enter the age of the person");
                int inputAge = Convert.ToInt32(Console.ReadLine());
                personAgeDictionary.Add(input, inputAge);
                Console.WriteLine("{0} succecfully added", input);
            }
            // TODO 7: Provide user feedback for successful addition or if the person already exists in personAgeDictionary.
        }

        public static void RemovePerson()
        {
            // TODO 8: Request user input for the name of the person to remove.
            Console.WriteLine("Who do you want to remove?");
            string deletePerson = Console.ReadLine();
            // TODO 9: Remove the person from personList if they exist.
            if (personList.Contains(deletePerson))
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    if (personList[i] == deletePerson)
                    {
                        personList.RemoveAt(i);
                        Console.WriteLine("Person was successfully removed from the list");
                    }
                }
            }
            // TODO 10: Provide user feedback for successful removal or if the person doesn't exist in personList.
            // TODO 11: Remove the person from personAgeDictionary if they exist.
            if (personAgeDictionary.ContainsKey(deletePerson))
            {
                personAgeDictionary.Remove(deletePerson);
                Console.WriteLine("Person was successfully remoted from the dictionary");
            }
            // TODO 12: Provide user feedback for successful removal or if the person doesn't exist in personAgeDictionary.
        }

        public static void FindPerson()
        {
            // TODO 13: Request user input for the name of the person to find.
            Console.WriteLine("Who are you looking for?");
            string findPerson = Console.ReadLine();
            // TODO 14: Check if the person is in personList and provide appropriate feedback.
            if(personList.Contains(findPerson))
            {
                Console.WriteLine("{0} is in the list", findPerson);
            }
            else
            { 
                Console.WriteLine("Sorry, there is nobody with the name {0}", findPerson) ;
            }
            // TODO 15: Check if the person is in personAgeDictionary and provide appropriate feedback.
            if(personAgeDictionary.ContainsKey(findPerson))
            {
                foreach (var item in personAgeDictionary)
                {
                    if(item.Key == findPerson)
                    {
                        Console.WriteLine("Person: {0}, Age: {1}", item.Key, item.Value.ToString());
                    }
                }
            }
        }

        public static void DisplayAllPersons()
        {
            // TODO 16: Iterate over personList and display each person's name.
            if (personList.Count > 0)
            {
                foreach (var person in personList)
                {
                    Console.WriteLine(person);
                }
                // TODO 17: Iterate over personAgeDictionary and display each person's name and age.
                foreach (var item in personAgeDictionary)
                {
                    Console.WriteLine("Person: {0}, Age: {1}", item.Key, item.Value.ToString());
                }
            }
            // TODO 18: Consider handling the case where the lists are empty by providing feedback to the user.
            else
            {
                Console.WriteLine("There is nobody in the list");
            }
        }
    }
}
