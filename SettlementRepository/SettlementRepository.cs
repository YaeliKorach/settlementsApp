using Microsoft.EntityFrameworkCore;
using WebApplicationTask.Models;

namespace WebApplicationTask.SettlementRepository
{
    public class SettlementRepository:ISettlementRepository
    {
        SettlementDBContext _settlementDBContext;
        public SettlementRepository(SettlementDBContext settlementDBContext)
        {
            _settlementDBContext = settlementDBContext;
        }

      
        public async Task<List<Settelment>> GetSettelments()
        {
            return await _settlementDBContext.settelments.ToListAsync();
        }
        public async Task<Settelment> AddSettelment(Settelment newSettelment)
        {
            await _settlementDBContext.settelments.AddAsync(newSettelment);
            await _settlementDBContext.SaveChangesAsync();
            return newSettelment;
        }
        public async Task<Settelment> GetSettelmentById(int id)
        {
            var settlement= await _settlementDBContext.settelments.FindAsync(id);
            return settlement;
        }
        public async Task<Settelment> UpdateSettelment(Settelment updatedSettelment)
        {
            _settlementDBContext.Entry(updatedSettelment).State = EntityState.Modified;
            await _settlementDBContext.SaveChangesAsync();
            return updatedSettelment;
        }

        public async Task<bool> DeleteSettelment(int id)
        {
            var settelmentToDelete = await _settlementDBContext.settelments.FindAsync(id);

            if (settelmentToDelete == null)
                return false; 

            _settlementDBContext.settelments.Remove(settelmentToDelete);
            await _settlementDBContext.SaveChangesAsync();
            return true; 
        }
    }
}
