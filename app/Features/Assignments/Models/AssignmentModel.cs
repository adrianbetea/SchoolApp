using app.Base;

namespace app.Features.Assignments.Models;

public class AssignmentModel : Model
{
    public string Subject { get; set; }
    
    public string Description { get; set; }
    
    public DateTime DeadlLine { get; set; }
}
