using api_filmes_senai.Domains;
namespace api_filmes_senai.interfaces
{
    public interface IFilmeRepository
    {
        void Cadastrar(Filmes novoFilme);

        List<Filmes> Listar();

        void Atualizar(Guid id, Filmes filme);

        void Deletar(Guid id);

        Filmes BuscarPorId(Guid id);

        List<Filmes> ListarPorGenero(Guid idGenenro);
    }
}
