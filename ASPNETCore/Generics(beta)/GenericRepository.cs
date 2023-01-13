using ASPNETCore.Interfaces;
using ASPNETCore.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCore.Repositories
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        public CCMSContext _context;
        
        public GenericRepository(CCMSContext context)
        {
            _context = context;
        }
        
        

        public List<T> GetAllEntities(string param1, string param2)
        {
            List<T> entities =  _context.Set<T>().Include(param1).Include(param2).ToList();
            return entities;
        }

        
    }
}
