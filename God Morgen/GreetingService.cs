using System;
using System.Collections.Generic;

public class GreetingService
{
    private static readonly Dictionary<string, (int start, int end, string message)> Greetings = new()
    {
        { "Morgen", (5, 11, "God morgen") },
        { "Ettermiddag", (12, 17, "God ettermiddag") },
        { "Kveld", (18, 22, "God kveld") },
        { "Natt", (23, 4, "God natt") }
    };

    public static string GetGreeting(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            return "Feil: Ugyldig klokkeslett. Time må være mellom 0 og 23.";
        }

        foreach (var entry in Greetings)
        {
            if ((entry.Value.start <= hour && hour <= entry.Value.end) ||
                (entry.Value.start > entry.Value.end && (hour >= entry.Value.start || hour <= entry.Value.end)))
            {
                return entry.Value.message;
            }
        }

        return "Hei";
    }
}