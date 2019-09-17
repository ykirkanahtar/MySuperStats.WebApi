using System.Threading.Tasks;
using MySuperStats.Contracts.Enums;

namespace MySuperStats.WebUI.Utils
{
    public interface IPermissionChecker
    {
        Task<bool> HasPermissionAsync(int matchGroupId, int userId, PermissionEnum permissionEnum);
    }
}