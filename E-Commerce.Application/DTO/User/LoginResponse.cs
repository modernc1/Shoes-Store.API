
namespace E_Commerce.Application.DTO.User
{
    public record LoginResponse(
        bool Success = false,
        string Email = null!,
        string FullName = null!,
        string Role = null!,
        string Message = null!,
        string Token = null!,
        string RefreshToken = null!
        );
}
