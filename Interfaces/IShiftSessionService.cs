using BankPOS.Entities;

namespace BankPOS.Interfaces
{
    public interface IShiftSessionService
    {
        Task<ShiftSession> OpenShift(ShiftSession shiftSession);

        Task<ShiftSession> CloseShift(int shiftId);
    }
}