using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using Eventi.Application.Contract.Ticket;
using Microsoft.AspNetCore.Http;

namespace Eventi.Application.Contract.Event;

public class CreateEvent
{
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Name { get; set; }

    public IFormFile? ImageCover { get; set; }
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string ImageCoverTitle { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string ImageCoverAlt { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
    public long SubcategoryId { get; set; }

    public string? Tags { get; set; }
    
    public List<long> PresenterIdList { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.IsRequired)]
    public long DepartmentId { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Slug { get; set; }

    public string EventType { get; set; }
    public string Address { get; set; }
    public string SupportNumber { get; set; }
    public string Description { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public bool IsConfirmed { get; set; }

    public List<CreateTicket> Tickets { get; set; } = new();
}