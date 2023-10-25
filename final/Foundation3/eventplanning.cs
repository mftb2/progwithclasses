using System;

class Address
{
    public string StreetAddress { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }

    public Address(string streetAddress, string city, string state, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        State = state;
        Country = country;
    }

    public string GetFormattedAddress()
    {
        return $"{StreetAddress}, {City}, {State}, {Country}";
    }
}

class Event
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public TimeSpan Time { get; private set; }
    public Address EventAddress { get; private set; }

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        EventAddress = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"Event: {Title}\nDescription: {Description}\nDate: {Date:yyyy-MM-dd}\nTime: {Time:hh\\:mm tt}\nLocation: {EventAddress.GetFormattedAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public string GetShortDescription()
    {
        return $"Event: {GetType().Name}\nTitle: {Title}\nDate: {Date:yyyy-MM-dd}";
    }
}

class Lecture : Event
{
    public string Speaker { get; private set; }
    public int Capacity { get; private set; }

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}

class Reception : Event
{
    public string RSVPContactEmail { get; private set; }

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        RSVPContactEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Reception\nRSVP Email: {RSVPContactEmail}";
    }
}

class OutdoorGathering : Event
{
    public string WeatherForecast { get; private set; }

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        WeatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return base.GetFullDetails() + $"\nType: Outdoor Gathering\nWeather Forecast: {WeatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Address address = new Address("123 Main St", "City1", "State1", "Country1");

        Event lectureEvent = new Lecture("Lecture Title", "Lecture Description", DateTime.Now, TimeSpan.FromHours(2), address, "Speaker Name", 100);
        Event receptionEvent = new Reception("Reception Title", "Reception Description", DateTime.Now, TimeSpan.FromHours(3), address, "rsvp@example.com");
        Event outdoorEvent = new OutdoorGathering("Outdoor Event Title", "Outdoor Event Description", DateTime.Now, TimeSpan.FromHours(4), address, "Sunny");

        Console.WriteLine("Standard Details:");
        Console.WriteLine(lectureEvent.GetStandardDetails());
        Console.WriteLine();

        Console.WriteLine("Full Details:");
        Console.WriteLine(receptionEvent.GetFullDetails());
        Console.WriteLine();

        Console.WriteLine("Short Description:");
        Console.WriteLine(outdoorEvent.GetShortDescription());
    }
}
