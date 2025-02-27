using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.interfaces;
using api_filmes_senai.Migrations;
using Microsoft.EntityFrameworkCore;

namespace api_filmes_senai.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {

        private readonly Filmes_Context _context;
        public FilmeRepository(Filmes_Context context)
        {
            context = _context;
        }

        public void Atualizar(Guid id, Filmes filme)
        {
            Filmes filmeBuscado = _context.Filmes.Find(id!);

            if (filmeBuscado != null)
            {
                filmeBuscado.Titulo = filme.Titulo;

                filmeBuscado.IdGenero = filme.IdGenero;
            }
        }

        public Filmes BuscarPorId(Guid id)
        {
            try
            {
                Filmes filmeBuscado = _context.Filmes.Find()!;

                return filmeBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Filmes novoFilme)
        {
            try
            {
                _context.Filmes.Add(novoFilme);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Filmes filmeBuscado = _context.Filmes.Find(id)!;

                if (filmeBuscado != null)
                {
                    _context.Filmes.Remove(filmeBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filmes> Listar()
        {
            try
            {
                List<Filmes> listaDeFilmes = _context.Filmes.Include(g => g.Genero)

                    //Seleciona o que quer trazer na requisicao
                    .Select(f => new Filmes
                    {
                        //dados de filme
                        IdFilmes = f.IdFilmes,
                        Titulo = f.Titulo,

                        Genero = new Genero
                        {
                            Nome = f.Genero!.Nome
                        }
                    })

                    .ToList();

                return listaDeFilmes;

            }
        
    }

        public List<Filmes> ListarPorGenero(Guid idGenenro)
        {
            throw new NotImplementedException();
        }
    }
}

