

public class Program
{
    public static void Main(string[] args)
    {
        
        List<Student> studentsList = new List<Student>();

        string input = Console.ReadLine(); 

        while (input != "end")
        {
            
            string[] inputData = input.Split(" ");
            string firstName = inputData[0]; 
            string lastName = inputData[1]; 
            int age = int.Parse(inputData[2]); 
            string homeTown = inputData[3]; 

            Student student = new Student(firstName, lastName, age, homeTown);
            studentsList.Add(student);

            input = Console.ReadLine();
        }

        

        string searchedTown = Console.ReadLine(); 

        foreach (Student student in studentsList)
        {
            if (student.HomeTown == searchedTown)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }

    }
}


