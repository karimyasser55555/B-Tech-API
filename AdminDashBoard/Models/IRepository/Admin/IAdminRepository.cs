using Domain;

namespace AdminDashBoard.Models.IRepository.Admin
{
    public interface IAdminRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<List<string>> GetAllRoleAsync(int id);
    }
}
