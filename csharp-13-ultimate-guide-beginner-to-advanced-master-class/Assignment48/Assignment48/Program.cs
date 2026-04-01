using System;
using System.Collections.Generic;

namespace Assignment48
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestPaper testPaper1 = new TestPaper();
            testPaper1.SubjectName = "General Knowledge";
            testPaper1.TestPaperName = "Test Paper 1";
            testPaper1.Questions = new List<IQuestion>();
            Question question1 = new Question();
            question1.QuestionText = "What is the capital of Bangladesh?";
            question1.Options = new List<IOption>()
            {
                new Option()
                {
                    OptionText = "Barishal",
                    OptionLetter = 'A'
                },
                 new Option()
                {
                    OptionText = "Sylhet",
                    OptionLetter = 'B'
                },
                 new Option()
                {
                    OptionText = "Dhaka",
                    OptionLetter = 'C'
                },
                 new Option()
                {
                    OptionText = "Rangpur",
                    OptionLetter = 'D'
                },
            };
            question1.CorrectAnswerLetter = 'C';
            testPaper1.Questions.Add(question1);
            Question question2 = new Question();
            question2.QuestionText = "What is the largest ocean on Earth?";
            question2.Options = new List<IOption>()
            {
                new Option()
                {
                    OptionText = "Atlantic Ocean",
                    OptionLetter = 'A'
                },
                 new Option()
                {
                    OptionText = "Indian Ocean",
                    OptionLetter = 'B'
                },
                 new Option()
                {
                    OptionText = "Pacific Ocean",
                    OptionLetter = 'C'
                },
                 new Option()
                {
                    OptionText = "Arctic Ocean",
                    OptionLetter = 'D'
                },
            };
            question2.CorrectAnswerLetter = 'C';
            testPaper1.Questions.Add(question2);
            TestPaper testPaper2 = new TestPaper()
            {
                SubjectName = "Mathematics",
                TestPaperName = "Test Paper 2",
                Questions = new List<IQuestion> ()
                {
                    new Question()
                    {
                        QuestionText = "What is the value of 12×8?",
                        Options = new List<IOption>() {
                            new Option()
                            {
                                OptionText = "84",
                                OptionLetter = 'A'
                            },
                            new Option()
                            {
                                OptionText = "96",
                                OptionLetter = 'B'
                            },
                            new Option()
                            {
                                OptionText = "100",
                                OptionLetter = 'C'
                            },
                            new Option()
                            {
                                OptionText = "105",
                                OptionLetter = 'D'
                            }
                        },
                        CorrectAnswerLetter = 'B'
                    }
                }
            };
            while (true)
            {
                Console.WriteLine("Do you want to test a student?");
                Console.WriteLine("1.Yes");
                Console.WriteLine("2.No");
                string choice = Console.ReadLine();
                if (choice[0] == 'n' || choice[0] == 'N')
                {
                    break;
                }
                Student student = new Student();
                Console.Write("Enter Roll No: ");
                bool isInteger = false;
                do
                {
                    isInteger = int.TryParse(Console.ReadLine(), out int rollNo);
                    if (isInteger)
                    {
                        student.RollNo = rollNo;
                    }
                } while (!isInteger);
                Console.Write("Enter name: ");
                student.StudentName = Console.ReadLine();
                student.TestPapers = new List<ITestPaper>()
                {
                    testPaper1, testPaper2
                };
                for (int i = 0; i < 2; ++i)
                {
                    ITestPaper testPaper = student.TestPapers[i];
                    Console.WriteLine(testPaper.TestPaperName);
                    Console.WriteLine(testPaper.SubjectName);
                    int totalMark = 0;
                    for (int j = 0; j < testPaper.Questions.Count; ++j)
                    {
                        IQuestion question = testPaper.Questions[j];
                        Console.Write("Question " + (j + 1) + ": ");
                        Console.WriteLine(question.QuestionText);
                        List<IOption> options = question.Options;
                        for (int k = 0; k < 4; ++k) 
                        {
                            Console.WriteLine(options[k].OptionLetter + ". " + options[k].OptionText);
                        }
                        Console.Write("Choose Answer(A/B/C/D): ");
                        char selectedOption = Convert.ToChar(Console.ReadLine());
                        int mark = question.CorrectAnswerLetter == selectedOption ? 1 : 0;
                        Console.WriteLine("Correct Answer: " + question.CorrectAnswerLetter + ", Students Choice: " + selectedOption + ", Marks Obtained: " + mark);
                        totalMark += mark;
                        Console.WriteLine();
                    }
                    Console.WriteLine("Total marks for this paper are: " + totalMark);
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
