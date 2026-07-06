namespace BankPOS.DTOs
{
    public record CreateBranchRequest(
        string BranchCode,
        string Name,
        string Location
    );

    public record CreateBranchResponse(
        Guid BranchId,
        string BranchCode,
        string Name,
        string Location
);
}