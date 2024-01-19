namespace VisitorPlacementModels
{
    public class Event
{

    public List<Visitor> RegisteredVisitors = new List<Visitor>();
    public DateTime EventDate { get; }
    public int MaxAttenders { get; }

    public Event(DateTime eventDate, int maxAttenders)
    {
        EventDate = eventDate;
        MaxAttenders = maxAttenders;
        
    }

    private void RegisterVisitor(Visitor visitor)
    {
        if (!RegisteredVisitors.Any(v => v.Name == visitor.Name && v.DateOfBirth == visitor.DateOfBirth))
        {
            visitor.Id = GenerateUniqueVisitorId();
            RegisteredVisitors.Add(visitor);
        }
    }

    private int GenerateUniqueVisitorId()
    {
        return RegisteredVisitors.Count + 1;
    }

    public void RegisterVisitors(List<Visitor> visitors)
    {
        foreach (var visitor in visitors)
        {
            RegisterVisitor(visitor);
        }
    }

    public void ProcessEventAccess()
    {
        var sortedVisitors = RegisteredVisitors.OrderBy(v => v.RegistrationDate).ToList();

        foreach (var visitor in sortedVisitors)
        {
            if (IsVisitorAllowedAccess(visitor))
            {
                visitor.IsAllowedAccess = true;
            }
            else
            {
                visitor.IsAllowedAccess = false;
            }
        }
        RegisteredVisitors = sortedVisitors;
    }

    private bool IsVisitorAllowedAccess(Visitor visitor)
    {
        if (visitor.RegistrationDate > EventDate)
        {
            Console.WriteLine($"Visitor {visitor.Name} has submitted registration late.");
            return false;
        }

        
        if (RegisteredVisitors.IndexOf(visitor) >= MaxAttenders)
        {
            Console.WriteLine("Event is at capacity. No more attendees allowed.");
            return false;
        }

    

        return true;
    }
}

}
