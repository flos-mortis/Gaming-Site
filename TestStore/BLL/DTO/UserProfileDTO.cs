using System;

namespace BLL.DTO
{
    class UserProfileDTO
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string About { get; set; }
        public byte[] Picture { get; set; }
        public string FavGame { get; set; }
    }
}
