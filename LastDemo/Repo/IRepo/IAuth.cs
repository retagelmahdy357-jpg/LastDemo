using LastDemo.DTO;
using LastDemo.Model;

namespace LastDemo.Repo.IRepo
{
    public interface IAuth
    {
        public Task<string> Login(AppUserDto userDto);
        public Task<bool> Rigester(AppUser user);
    }
}
