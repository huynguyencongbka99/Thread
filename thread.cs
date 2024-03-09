using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        // Define the number of tasks to run in parallel
        int numTasks = 5;

        // Create an array of tasks
        Task[] tasks = new Task[numTasks];

        // Start and run each task in parallel
        for (int i = 0; i < numTasks; i++)
        {
            int taskNumber = i; // Capturing the loop variable
            tasks[i] = Task.Run(() => ProcessData(taskNumber)); //magic lamda function here!
        }

        // Wait for all tasks to complete
        Task.WaitAll(tasks);

        Console.WriteLine("All tasks completed.");
    }

    static void ProcessData(int taskNumber)
    {
        Console.WriteLine("Task {0} started.", taskNumber);

        // Simulate some processing time
        Random random = new Random();
        int milliseconds = random.Next(1000, 5000);
        Task.Delay(milliseconds).Wait();

        Console.WriteLine("Task {0} completed after {1} milliseconds.", taskNumber, milliseconds);
    }
}
