using System;

namespace NotificationApp
{
    // 1. Interface
    public interface INotificationService
    {
        void Notify(string message);
    }

    // 2. Implementations
    public class SMSNotifier : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    public class EmailNotifier : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class PushNotifier : INotificationService
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Push notification sent: {message}");
        }
    }

    // 3. Appointment Service
    public class AppointmentService
    {
        private readonly INotificationService _notificationService;

        public AppointmentService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public void BookAppointment(string patientName, DateTime appointmentDate)
        {
            Console.WriteLine($"Appointment booked for {patientName} on {appointmentDate}.");
            _notificationService.Notify($"Dear {patientName}, your appointment is confirmed for {appointmentDate}.");
        }
    }

    // 4. Program
    class Program
    {
        static void Main(string[] args)
        {
            INotificationService notifier;

            Console.WriteLine("Select notification type: 1-SMS, 2-Email, 3-Push");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    notifier = new SMSNotifier();
                    break;
                case "2":
                    notifier = new EmailNotifier();
                    break;
                case "3":
                    notifier = new PushNotifier();
                    break;
                default:
                    Console.WriteLine("Invalid choice, using SMS as default.");
                    notifier = new SMSNotifier();
                    break;
            }

            var service = new AppointmentService(notifier);
            service.BookAppointment("John Doe", DateTime.Now.AddDays(1));
        }
    }
}
