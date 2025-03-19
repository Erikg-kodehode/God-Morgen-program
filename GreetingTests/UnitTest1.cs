using Xunit;

public class GreetingServiceTests
{
    [Theory]
    [InlineData(5, "God morgen")]
    [InlineData(11, "God morgen")]
    [InlineData(12, "God ettermiddag")]
    [InlineData(17, "God ettermiddag")]
    [InlineData(18, "God kveld")]
    [InlineData(22, "God kveld")]
    [InlineData(23, "God natt")]
    [InlineData(4, "God natt")]
    public void GetGreeting_ReturnsCorrectGreeting(int hour, string expectedGreeting)
    {
        string result = GreetingService.GetGreeting(hour);
        Assert.Equal(expectedGreeting, result);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(24)]
    [InlineData(100)]
    public void GetGreeting_ReturnsErrorForInvalidHours(int hour)
    {
        string result = GreetingService.GetGreeting(hour);
        Assert.Equal("Feil: Ugyldig klokkeslett. Time må være mellom 0 og 23.", result);
    }
}
