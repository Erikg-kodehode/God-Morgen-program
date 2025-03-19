using System;

class Program
{
    static void Main()
    {
        Console.Write("Hva heter du? ");
        string name = Console.ReadLine() ?? "Bruker";

        DateTime now = DateTime.Now;
        int hour = now.Hour;
        int minute = now.Minute;

        Console.Write("Vil du bruke nåværende tid eller skrive inn en egen tid? (nå/egen): ");
        string choice = (Console.ReadLine() ?? "nå").Trim().ToLower();

        if (choice == "egen")
        {
            Console.Write("Skriv inn en time (0-23): ");
            if (!int.TryParse(Console.ReadLine(), out int customHour) || customHour < 0 || customHour > 23)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Feil: Ugyldig klokkeslett. Time må være mellom 0 og 23.");
                Console.ResetColor();
                return;
            }

            Console.Write("Skriv inn minutter (0-59): ");
            if (!int.TryParse(Console.ReadLine(), out int customMinute) || customMinute < 0 || customMinute > 59)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Feil: Ugyldige minutter. Minutter må være mellom 0 og 59.");
                Console.ResetColor();
                return;
            }

            now = new DateTime(now.Year, now.Month, now.Day, customHour, customMinute, 0);
            hour = customHour;
            minute = customMinute;
        }

        string greeting = GreetingService.GetGreeting(hour);
        Console.WriteLine($"{greeting}, {name}! Klokken er nå {hour:D2}:{minute:D2}.");
    }
}
