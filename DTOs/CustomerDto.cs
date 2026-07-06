using System.ComponentModel.DataAnnotations;

namespace BankPOS.DTOs
{
    public record CreateCustomerRequest(
        string CustomerName,
        string CustomerNationalId,
        string CustomerPhone
    );

    public record CreateCustomerResponse(
        Guid CustomerId,
        string CustomerName,
        string CustomerNationalId,
        string CustomerPhone
    );

    public record GetCustomerProfileRequest(
        Guid CustomerId
    );

    public record GetCustomerProfileResponse(
        Guid CustomerId,
        string CustomerName,
        string CustomerNationalId,
        string CustomerPhone
    );
}