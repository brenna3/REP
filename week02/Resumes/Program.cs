using System;

class Program
{
    static void Main(string[] args)
    {
        // Create first job
        Job job1 = new Job();
        job1._jobTitle = "Salesforce Admin";
        job1._company = "Christensen Inc";
        job1._startYear = 2020;
        job1._endYear = 2023;

        // Create second job
        Job job2 = new Job();
        job2._jobTitle = "It Product Manger";
        job2._company = "Christensen Inc";
        job2._startYear = 2023;
        job2._endYear = 2025;

        // Create resume and assign name
        Resume myResume = new Resume();
        myResume._name = "Brenna Nery";

        // Add jobs to resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display resume
        myResume.Display();
    }
}