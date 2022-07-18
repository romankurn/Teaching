using System.Threading.Tasks;

namespace ArtWorkshop.Service.DataBaseLayer.Interfaces
{
	public interface IRoleRepository
	{
		Task<string> GetRoleByUserIdAsync(int userId);
	}
}
