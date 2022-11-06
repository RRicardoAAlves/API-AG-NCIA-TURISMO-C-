using myProject.Model;

namespace myProject.Repository
{
    public interface IDestinoRepository
    {
        Task<IEnumerable<Destino>> GetDestinos();
        Task<Destino> GetDestinosById(int id);
        void AddDestinos(Destino destino);
        void AtualizarDestinos(Destino destino);
        void DeletarDestinos(Destino destino);
        Task<bool> SaveChangesAsync();
    }
}