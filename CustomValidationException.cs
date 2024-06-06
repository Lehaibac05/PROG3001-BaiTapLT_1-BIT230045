using System.Linq.Expressions;

namespace CustomValidationException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the student's age:");
            try
            {
                int age = int.Parse(Console.ReadLine());

                CheckAgeEligibility(age);

                Console.WriteLine("The student is eligible for admission.");
            }
            catch (AgeOutOfRangeException ex)
            {
                Console.WriteLine("Eligibility Error");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid age.");
            }
        }

        static void CheckAgeEligibility(int age)
        {
            if (age < 18 || age > 25)
            {
                throw new AgeOutOfRangeException("The student's age must be between 18 and 25 to be eligible for admission.");
            }
        }
    }
}
