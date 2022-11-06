using myProject.Database;
using myProject.Model;
using Microsoft.EntityFrameworkCore;

namespace myProject.Repository
{
    public class DestinoRepository : IDestinoRepository
    {
        private readonly UsuarioDbContext _context;

       
        public DestinoRepository(UsuarioDbContext context)
        {
            _context = context;
        }

        public void AddDestinos(Destino destino)
        {
            _context.Add(destino);
        }

        public void AtualizarDestinos(Destino destino)
        {
            _context.Update(destino);
        }

        

        public void DeletarDestinos(Destino destino)
        {
            _context.Remove(destino);
        }

        
        public async Task<Destino> GetDestinosById(int id)
        {
            return await _context.Destinos
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Destino>> GetDestinos()
        {
            return await _context.Destinos.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}