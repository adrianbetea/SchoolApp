using app.Features.Assignments.Models;
using app.Features.Assignments.Views;
using Microsoft.AspNetCore.Mvc;

namespace app.Features.Assignments;
[ApiController]
[Route("assignments")]
public class AssignmentsController
{
    private static List<AssignmentModel> _mockDb = new List<AssignmentModel>();
    
    [HttpPost]
    public AssignmentResponse Add(AssignmentRequest request)
    {
        var assignment = new AssignmentModel()
        {
            id = Guid.NewGuid().ToString(),
            Created = DateTime.UtcNow,
            Updated = DateTime.UtcNow,
            Subject = request.Subject,
            Description = request.Description,
            DeadlLine =  request.DeadLine
        };
        _mockDb.Add(assignment);
        return new AssignmentResponse
        {
            id = assignment.id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            DeadlLine = assignment.DeadlLine

        };
    }

    [HttpGet]
    public IEnumerable<AssignmentResponse> get()
    {
        return _mockDb.Select(
            assignment => new AssignmentResponse()
            {
                id = assignment.id,
                Subject = assignment.Subject,
                Description = assignment.Description,
                DeadlLine = assignment.DeadlLine
            }
        ).ToList();
    }

    [HttpGet("{id}")]
    public AssignmentResponse Get([FromRoute] string id)
    {
        var assignment = _mockDb.FirstOrDefault(x=> x.id == id);
        if (assignment is null)
        {
            return null;
        }

        return new AssignmentResponse
        {
            id = assignment.id,
            Subject = assignment.Subject,
            Description = assignment.Description,
            DeadlLine = assignment.DeadlLine

        }; 
    }
    
    //TDOT HttpDelete, HttpPatch, delete dupa id si update cu redutn la obiect sub forma de AssignmentResponse
}