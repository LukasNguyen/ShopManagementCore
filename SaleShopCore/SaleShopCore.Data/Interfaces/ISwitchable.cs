using SaleShopCore.Data.Enums;

namespace SaleShopCore.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { get; set; }
    }
}