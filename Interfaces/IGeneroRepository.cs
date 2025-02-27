using api_filmes_senai.Domains;
namespace api_filmes_senai.Interfaces
{
    /// <summary>
    /// Interface para genero: Contrato
    /// toda classe que herdar(implementar) essa interface, devera implementar todos os metodos definidos aqui dentro
    /// </summary>
    public interface IGeneroRepository
    {
        //CRUD : metodos
        //C : Create: CAdastrar um novo Objeto
        //R : read: listar todos os objetos
        //U : Update: alterar um objeto
        //D : Delete: deleto ou excluo um obj

        //Metodo = TipoDeRetorno NomeDoMetodo(Argumentos)

        void Cadastrar(Genero novoGenero);

        List<Genero> Listar();

        void Atualizar(Guid id, Genero genero);

        void Deletar(Guid id);

        Genero BuscarPorId(Guid id);
    }
}
