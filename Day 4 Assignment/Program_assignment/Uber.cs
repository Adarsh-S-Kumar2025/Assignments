using System;

namespace RideManagement
{
    class Ride
    {
        //  Static Members
        private static int totalRides;
        private static double totalEarnings;
        private static double baseFare;
        private static double surgeMultiplier;

        // Static Constructor
        static Ride()
        {
            totalRides = 0;
            totalEarnings = 0;
            baseFare = 50; // Default base fare ₹50
            surgeMultiplier = 1.0; // Default surge multiplier
            Console.WriteLine("Uber System Initialized. Ready to book rides...");
            Console.WriteLine("-----------------------------------------------");
        }

        //  Instance Members
        public string RideId { get; private set; }
        public string DriverName { get; set; }
        public string PassengerName { get; set; }
        public double DistanceKm { get; set; }
        public double Fare { get; private set; }

        //  Constructor
        public Ride(string driverName, string passengerName, double distanceKm)
        {
            totalRides++;  // increment ride count
            RideId = "Ride_" + (1000 + totalRides);
            DriverName = driverName;
            PassengerName = passengerName;
            DistanceKm = distanceKm;

            // Calculate fare using static method
            Fare = CalculateFare(distanceKm);

            // Update total earnings
            totalEarnings += Fare;
        }

        //  Static Method: Calculate fare
        private static double CalculateFare(double distanceKm)
        {
            return baseFare + (distanceKm * 15 * surgeMultiplier);
        }

        //  Static Method: Set Surge Multiplier
        public static void SetSurgeMultiplier(double multiplier)
        {
            if (multiplier <= 0)
            {
                Console.WriteLine("Invalid multiplier. Must be greater than 0.");
                return;
            }
            surgeMultiplier = multiplier;
            Console.WriteLine($"Surge Multiplier updated to {surgeMultiplier}x");
        }

        //  Static Method: Show total rides and earnings
        public static void ShowRideSummary()
        {
            Console.WriteLine("\n===== Ride Summary =====");
            Console.WriteLine($"Total Rides Booked : {totalRides}");
            Console.WriteLine($"Total Earnings     : ₹{totalEarnings:F2}");
            Console.WriteLine("=========================");
        }

        //  Instance Method: Show ride details
        public void ShowRideDetails()
        {
            Console.WriteLine($"\nRide ID       : {RideId}");
            Console.WriteLine($"Driver Name   : {DriverName}");
            Console.WriteLine($"Passenger Name: {PassengerName}");
            Console.WriteLine($"Distance (km) : {DistanceKm}");
            Console.WriteLine($"Fare (₹)      : {Fare:F2}");
            Console.WriteLine("----------------------------");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initialize surge multiplier
            Ride.SetSurgeMultiplier(2); // 1.5x surge

            // Create Ride objects
            Ride ride1 = new Ride("Rahul", "Adarsh", 10);
            Ride ride2 = new Ride("Anu", "Sharon", 5.5);
            Ride ride3 = new Ride("Kiran", "Riya", 8);

            // Display individual rides
            ride1.ShowRideDetails();
            ride2.ShowRideDetails();
            ride3.ShowRideDetails();

            // Display summary
            Ride.ShowRideSummary();

            Console.ReadLine();
        }
    }
}
