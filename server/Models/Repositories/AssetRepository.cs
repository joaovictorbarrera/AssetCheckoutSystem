using AssetManagementSystem.Data;

namespace AssetManagementSystem.Models.Repositories
{
    public class AssetRepository
    {
        private readonly AppDbContext _context;

        public AssetRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
