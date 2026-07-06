namespace BankPOS.DTOs
{
    public record APIResponse<T>(
        string Message,
        T? Data
    );
}