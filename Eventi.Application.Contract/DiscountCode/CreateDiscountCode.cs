using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace Eventi.Application.Contract.DiscountCode;

public class CreateDiscountCode
{
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public string Code { get; set; }

    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public float DiscountRate { get; set; }
    
    [Required(ErrorMessage = ValidationMessage.IsRequired)]
    public int Count { get; set; }

    [Range(1, 100_000, ErrorMessage = ValidationMessage.IsRequired)]
    public long TicketId { get; set; }

}