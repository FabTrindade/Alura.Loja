using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Produto { Nome = "Viangre", Categoria = "Alimentos", PrecoUnitario = 1.98, Unidade = "L" };
            var p2 = new Produto { Nome = "Algodão", Categoria = "Farmácia", PrecoUnitario = 5.98, Unidade = "kg" };
            var p3 = new Produto { Nome = "Cerveja", Categoria = "Alimentos", PrecoUnitario = 3.35, Unidade = "L" };
            Promocao promocaoPascoa = new Promocao
            {
                Descricao = "Feliz Páscoa",
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddMonths(3)
            };

            promocaoPascoa.IncluiProduto(p1);
            promocaoPascoa.IncluiProduto(p2);
            promocaoPascoa.IncluiProduto(p3);

            using(var context = new LojaContext())
            {
                context.Promocoes.Add(promocaoPascoa);
                context.SaveChanges();
            }
        }

        private static void AtualizausandoEntity()
        {
            using (var context = new LojaContext())
            {
                Produto p = new Produto();
                p.Id = 4;
                p = context.Produtos.FirstOrDefault(prd => prd.Id == p.Id);
                p.Nome = "Por que dormimos?";
                p.Categoria = "Livros";
                p.PrecoUnitario = 16.50;

                context.Produtos.Update(p);
                context.SaveChanges();
            }
        }
        private static void RemoveUsandoEntity(int Id)
        {
            using (var context = new LojaContext())
            {
                context.Produtos.Remove(context.Produtos.Where(pd => pd.Id == Id).First());
                context.SaveChanges();
            }
        }
        private static void RecuperaUsandoEntity()
        {
            using (var context = new LojaContext())
            {
                List < Produto > produtos = context.Produtos.ToList();
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }
        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var context = new LojaContext())
            {
                context.Produtos.Add(p);
                context.SaveChanges();
            }
        }
        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.PrecoUnitario = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
