using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;

namespace Eventi.Application.Contract.Ticket;

public class CreateTicket
{
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Title { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public int Number { get; set; }

    public double TotalPrice { get; set; }
    public float DiscountRate { get; set; } = 0;

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public double Price { get; set; }

    public string? Description { get; set; }
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }

    [Range(1, 100_000, ErrorMessage = ValidationMessage.IsRequired)]
    public long EventId { get; set; }

    public int UsedNumber { get; set; }
}