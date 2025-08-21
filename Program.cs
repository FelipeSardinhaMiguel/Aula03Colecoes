using System;
using Aula03Colecoes.Models;
using Aula03Colecoes.Models.Enuns;

namespace Aula03Colecoes
{
    public class Program
    {
        static List<Funcionario> lista = new List<Funcionario>();
        
        static void Main(string[] args)
        {
            CriarLista();
            //ExibirLista();
            //ObterPorId();
            AdicionarFuncionario();
            ObterPorIdDigitado();
            ObterPorSalarioDigitado();
        }

        public static void ObterPorId()
        {
            lista = lista.FindAll(x => x.Id == 1);
            ExibirLista();
        }

        public static void AdicionarFuncionario()
        {
            /*int i = int.Parse();

            Console.WriteLine("Digite a qtd de funcionários que queira inserir");
            int i = int.Parse(Console.ReadLine());

            for(i=0;i<=i;i++)
            {}*/
            Funcionario f = new Funcionario();
            
            Console.WriteLine("Digite o seu nome: ");
            f.Nome = Console.ReadLine();

            Console.WriteLine("Digite o seu salario: ");
            f.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data de admissão: ");
            f.DataAdmissao = DateTime.Parse(Console.ReadLine());

            if(string.IsNullOrEmpty(f.Nome))
            {
                Console.WriteLine("O nome deve ser preenchido");
                return;
            }

            else if(f.Salario == 0 /*>= 0 && f.Salario <= 0.99*/)
            {
                Console.WriteLine("Voce não é escravo!! Escreva seu salário");
                return;
            }

            else
            {
                lista.Add(f);
                ExibirLista();
            }
        }

        public static void ObterPorIdDigitado()
        {
            Console.WriteLine("Digite o ID: ");
            int id = int.Parse(Console.ReadLine());
            Funcionario fBusca = lista.Find(x => x.Id == id);

            if(fBusca == null)
                Console.WriteLine("Não encontrado");
            else
                Console.WriteLine($"Funcionário encontrado: {fBusca.Nome}");
        }

        public static void ObterPorSalarioDigitado()
        {
            Console.WriteLine("Digite o salario minimo: ");
            decimal salario = decimal.Parse(Console.ReadLine());
            lista = lista.FindAll(x => x.Salario >= salario);
            ExibirLista();

            /*if(fBusca == null)
                Console.WriteLine("Não encontrado");
            else
                Console.WriteLine($"Funcionário encontrado: {fBusca.Salario}");*/
        }

        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < lista.Count; i++ )
            {
                dados += "==================================\n";
                dados += string.Format("Id: {0} \n", lista[i].Id);
                dados += string.Format("Nome: {0} \n", lista[i].Nome);
                dados += string.Format("CPF: {0} \n", lista[i].CPF);
                dados += string.Format("Admissão: {0:dd/mm/yyyy} \n", lista[i].DataAdmissao);
                dados += string.Format("Salario: {0:c2} \n", lista[i].Salario);
                dados += string.Format("Tipo: {0} \n", lista[i].TipoFuncionario);
                dados += "==================================\n";
            }
            Console.WriteLine(dados);
        }
         public static void CriarLista()
        {
            Funcionario f1 = new Funcionario();
            f1.Id = 1;
            f1.Nome = "Neymar";
            f1.CPF = "12345678910";
            f1.DataAdmissao = DateTime.Parse("01/01/2000");
            f1.Salario = 100.000M;
            f1.TipoFuncionario = TipoFuncionarioEnuns.CLT;
            lista.Add(f1);

            Funcionario f2 = new Funcionario();
            f2.Id = 2;
            f2.Nome = "Cristiano Ronaldo";
            f2.CPF = "01987654321";
            f2.DataAdmissao = DateTime.Parse("30/06/2002");
            f2.Salario = 150.000M;
            f2.TipoFuncionario = TipoFuncionarioEnuns.CLT;
            lista.Add(f2);

            Funcionario f3 = new Funcionario();
            f3.Id = 3;
            f3.Nome = "Messi";
            f3.CPF = "135792468";
            f3.DataAdmissao = DateTime.Parse("01/11/2003");
            f3.Salario = 70.000M;
            f3.TipoFuncionario = TipoFuncionarioEnuns.Aprendiz;
            lista.Add(f3);

            Funcionario f4 = new Funcionario();
            f4.Id = 4;
            f4.Nome = "Mbappe";
            f4.CPF = "246813579";
            f4.DataAdmissao = DateTime.Parse("15/09/2005");
            f4.Salario = 80.000M;
            f4.TipoFuncionario = TipoFuncionarioEnuns.Aprendiz;
            lista.Add(f4);

            Funcionario f5 = new Funcionario();
            f5.Id = 5;
            f5.Nome = "Lewa";
            f5.CPF = "246813579";
            f5.DataAdmissao = DateTime.Parse("20/10/1998");
            f5.Salario = 90.000M;
            f5.TipoFuncionario = TipoFuncionarioEnuns.Aprendiz;
            lista.Add(f5);

            Funcionario f6 = new Funcionario();
            f6.Id = 6;
            f6.Nome = "Roger Guedes";
            f6.CPF = "246813579";
            f6.DataAdmissao = DateTime.Parse("13/12/1997");
            f6.Salario = 300.000M;
            f6.TipoFuncionario = TipoFuncionarioEnuns.CLT;
            lista.Add(f6);
        } 
    }
}