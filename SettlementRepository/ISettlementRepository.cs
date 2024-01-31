
using WebApplicationTask.Models;

namespace WebApplicationTask.SettlementRepository
{
    public interface ISettlementRepository
    {
        Task<List<Settelment>> GetSettelments();
        Task<Settelment> GetSettelmentById(int id);
        Task<Settelment> AddSettelment(Settelment newSettelment);
        Task<Settelment> UpdateSettelment(Settelment updatedSettelment);
        Task<bool> DeleteSettelment(int id);
    }
}
