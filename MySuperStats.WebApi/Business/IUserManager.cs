using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySuperStats.Contracts.Requests;
using MySuperStats.Contracts.Responses;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public interface IUserManager
    {
        Task<IdentityResult> CreateAsync(User user, string password, IUrlHelper url, string requestScheme, string callBackUrl, List<string> roles);
        Task<IdentityResult> UpdateAsync(int id, User user);
        Task<IdentityResult> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
        Task<User> GetByIdWithBasketballStats(int id);
        Task<User> GetByUserNameAsync(string userName);
        Task<User> GetByEmailAddressAsync(string emailAddress);
        Task<User> GetUserAsync(ClaimsPrincipal ClaimsPrincipal);
        Task<IList<User>> GetAllAsync();
        Task<IList<User>> GetAllByMatchGroupIdAsync(int matchGroupId);
        Task<IdentityResult> ConfirmEmailAsync(int userId, string code);
        Task ForgotPasswordAsync(PasswordRecoveryRequest request, IUrlHelper url, string requestScheme, string callBackUrl);
        Task<IdentityResult> ResetPasswordAsync(PasswordResetRequest request);
        Task<IList<Role>> GetRolesAsync(int userId, int matchGroupId);
        Task<UsersAddToRoleResponse> AddUsersToRoleAsync(UsersAddToRoleRequest request);
    }
}

