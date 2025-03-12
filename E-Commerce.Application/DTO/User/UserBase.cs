namespace E_Commerce.Application.DTO.User
{
    public class UserBase
    {
        public required string Email { get; set; } = default!;
        public required string Password { get; set; } = default!;
    }

}
