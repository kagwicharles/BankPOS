using System.ComponentModel.DataAnnotations;

namespace BankPOS.DTOs
{
    public record CreateCustomerRequest(
        string CustomerName,
        string CustomerNationalId,
        string CustomerPhone
    );

    public record CreateCustomerResponse(
        int CustomerId,
        string CustomerName,
        string CustomerNationalId,
        string CustomerPhone
    );

    public record GetCustomerProfileRequest(
        [property: Required] int CustomerId
    );

    public record GetCustomerProfileResponse(
        int CustomerId,
        string CustomerName,
        string CustomerNationalId,
        string CustomerPhone
    );
}