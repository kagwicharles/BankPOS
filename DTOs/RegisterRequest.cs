namespace BankPOS.DTOs
{
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string OtherNames,
        string StaffEmail,
        string Email,
        string Password
    );
}