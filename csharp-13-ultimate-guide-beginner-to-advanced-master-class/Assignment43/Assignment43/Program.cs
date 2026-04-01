using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment43
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car[] cars = new Car[3]
            {
                new Car() {Model = "Toyota Corolla", RentalPrice = 50, Rented = false},
                new Car() {Model = "Honda Civic", RentalPrice = 60, Rented = false},
                new Car() {Model = "Ford Mustang", RentalPrice = 80, Rented = false}
            };
            Console.WriteLine("Welcome to the car rental system!");
            Console.WriteLine();
            bool exit = false;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Rent a car");
                Console.WriteLine("2. Return a car");
                Console.WriteLine("3. View available cars");
                Console.WriteLine("4. Exit");
                Console.Write("Please enter your choice: ");
                int menuChoice = Convert.ToInt32(Console.ReadLine());
                if (menuChoice == 1)
                {
                    int choicedCarId;
                    do
                    {
                        Console.WriteLine("Rent a Car:");
                        for (int i = 0; i < cars.Length; ++i)
                        {
                            cars[i].PrintInfo(i, cars[i]);
                        }
                        Console.Write("Please enter the ID of the car you want to rent: ");
                        choicedCarId = Convert.ToInt32(Console.ReadLine());
                    } while (choicedCarId >= cars.Length);
                    bool result = cars[choicedCarId].Rent(cars[choicedCarId]);
                }
                else if (menuChoice == 2)
                {
                    int choicedCarId;
                    do
                    {
                        Console.WriteLine("Return a Car:");
                        for (int i = 0; i < cars.Length; ++i)
                        {
                            cars[i].PrintInfo(i, cars[i]);
                        }
                        Console.Write("Please enter the ID of the car you want to return: ");
                        choicedCarId = Convert.ToInt32(Console.ReadLine());
                    } while (choicedCarId >= cars.Length);
                    bool result = cars[choicedCarId].Return(cars[choicedCarId]);
                }
                else if (menuChoice == 3)
                {
                    Console.WriteLine("Available cars:");
                    for (int i = 0; i < cars.Length; ++i)
                    {
                        cars[i].PrintInfo(i, cars[i]);
                    }
                }
                else if (menuChoice == 4)
                {
                    Console.WriteLine("Thank you for using the car rental system!");
                    Console.ReadKey();
                    exit = true;
                }
            } while(exit == false);
        }
    }
}
