namespace _2_Problem
{
    internal class Solution
    {
        public static int NumberOfPairs { get; set; } = 1000000; // 1 million

        public static Person[] PhoneBook { get; set; }

        public static string SearchName { get; set; }


        static void Main(string[] args)
        {

            GenerateFakeData();

            Random random = new Random();
            //int randomNumber = random.Next(0, NumberOfPairs - 1); // random case
            int randomNumber = NumberOfPairs - 1; // worst case

            SearchName = PhoneBook[randomNumber].Name;

            Console.WriteLine("Looking for: " + SearchName);
            DateTime startTime = DateTime.Now;

            string phone = FindPersonsPhoneNumberByPersonsName();

            TimeSpan elapsedTime = DateTime.Now - startTime;

            Console.WriteLine("Person's PhoneNumber: " + phone);
            Console.WriteLine($"\nElapsed Time: {elapsedTime.TotalMilliseconds} ms\n");

        }

        static string FindPersonsPhoneNumberByPersonsName()
        {
            //return DefaultForLoop(); // Big O (n)
            return BinarySearch(PhoneBook, 0, PhoneBook.Length - 1, SearchName); // Big O (log2(n))
        }


        static string DefaultForLoop()
        {
            for (int i = 0; i < PhoneBook.Length; i++)
            {
                if (string.Compare(PhoneBook[i].Name, SearchName, StringComparison.Ordinal) == 0)
                {
                    Console.WriteLine(PhoneBook[i].Name + " - Found at index: " + i);
                    Console.WriteLine("Iterations: " + i);
                    return PhoneBook[i].PhoneNumber;
                }
            }
            return null;
        }


        static string BinarySearch(Person[] array, int first, int last, string searchTerm)
        {

            int mid = (first + last) / 2;

            var iterationsCounter = 0;

            while (first <= last)
            {
                iterationsCounter++;
                int res = StringIsGreaterThan(array[mid].Name, searchTerm);

                if (res == -1)
                {
                    first = mid + 1;
                }
                else if (res == 0)
                {

                    Console.WriteLine(PhoneBook[mid].Name + " - Found at index: " + mid);
                    Console.WriteLine("Iterations: " + iterationsCounter);
                    Console.WriteLine("log2(n) = " + Math.Ceiling(Math.Log(NumberOfPairs) / Math.Log(2))); // log2 calc
                    return PhoneBook[mid].PhoneNumber;
                }
                else
                {
                    last = mid - 1;
                }
                mid = (first + last) / 2;
            }
            if (first > last)
            {
                Console.WriteLine("Element is not found!");
            }


            return null;
        }


        static int StringIsGreaterThan(string firstValue, string secondValue)
        {
            int minLength = firstValue.Length < secondValue.Length ? firstValue.Length : secondValue.Length;


            for (int i = 0; i < minLength; i++)
            {
                if (firstValue[i] < secondValue[i])
                {
                    return -1;
                }
                else if (firstValue[i] > secondValue[i])
                {
                    return 1;
                }
            }

            if (firstValue.Length < secondValue.Length)
            {
                return -1;
            }
            else if (firstValue.Length > secondValue.Length)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        static void GenerateFakeData()
        {
            PhoneBook = new Person[NumberOfPairs];

            int pairsLength = NumberOfPairs.ToString().Length;

            for (int i = 1; i <= NumberOfPairs; i++)
            {
                Person person = new Person();
                person.Name = "Person " + i.ToString().PadLeft(pairsLength, '0');
                person.PhoneNumber = (NumberOfPairs - i).ToString().PadLeft(pairsLength, '0');

                PhoneBook[i - 1] = person;

            }


        }

    }


}