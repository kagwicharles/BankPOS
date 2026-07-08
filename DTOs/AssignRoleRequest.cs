namespace BankPOS.DTOs
{
    public record AssignRoleRequest(
        string Email,
        string Role
    );
}