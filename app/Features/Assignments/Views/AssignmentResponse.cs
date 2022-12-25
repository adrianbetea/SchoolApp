namespace app.Features.Assignments.Views;

public class AssignmentResponse
{
    public string id { get; set; }
    
    public string Subject { get; set; }
    
    public string Description { get; set; }
    
    public DateTime DeadlLine { get; set; }
}