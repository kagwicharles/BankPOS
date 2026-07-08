namespace BankPOS.DTOs
{
    public record LoginRequest(
        string Email,
        string Password
    );
}