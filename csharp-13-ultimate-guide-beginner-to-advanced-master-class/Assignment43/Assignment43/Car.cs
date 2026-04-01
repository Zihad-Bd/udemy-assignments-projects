using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment43
{
    internal class Car
    {
        public string Make {  get; set; }
        public string Model { get; set; }
        public decimal RentalPrice { get; set; }
        public bool Rented { get; set; }
        public bool Rent(Car car)
        {
            if (car.Rented == false)
            {
                Console.WriteLine($"Rented the {car.Model} for ${car.RentalPrice}/day.");
                car.Rented = true;
                return true;
            }
            else
            {
                Console.WriteLine("Sorry, the selected car is not available for rent.");
                return false;
            }
        }
        public bool Return(Car car)
        {
            if (car.Rented)
            {
                Console.WriteLine($"Returned the {car.Model}.");
                car.Rented = false;
                return true;
            }
            else
            {
                Console.WriteLine("Sorry, the selected car is not rented.");
                return false;
            }
        }
        public void PrintInfo(int carId, Car car)
        {
            Console.Write($"{carId}. {car.Model} (Rental price: {car.RentalPrice}/day) - ");
            Console.WriteLine(car.Rented ? "Rented" : "Available");
        }
    }
}
