//Feito por Felipe e Gustavo
using System;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
            ExibirLista();
            //ObterPorId(); <=== não tire este do comentário!!!
            AdicionarFuncionario();
            ObterPorIdDigitado();
            ObterPorSalarioDigitado();
            ObterPorNome();
            ObterFuncionariosRecentes();
            ObterEstatisticas();
            ValidarSalarioAdmissao(1000m, DateTime.Today);
            //ValidarNome(); <=== já esta sendo chamado em AdicionarFuncionario.
            ObterPorTipo();


            DetalharData();
            CalcularDescontoINSS();
        }

        public static void ObterPorId()
        {
            lista = lista.FindAll(x => x.Id == 1);
            ExibirLista();
        }

        public static void AdicionarFuncionario()
        {
            Funcionario f = new Funcionario();

            Console.WriteLine("Digite o nome do seu novo funcionário:");
            f.Nome = Console.ReadLine();

            if (!ValidarNome(f.Nome)) // o "!" serve para ver se um argumento esta negativado. EX: Caso o funcionário NÃO tenha o nome maior do que dois digitos.
            {
                Console.WriteLine("\nFuncionário não adicionado por nome inválido.");
                return;
            }

            Console.WriteLine("\nDigite o salario do seu novo funionario:");
            f.Salario = decimal.Parse(Console.ReadLine());

            Console.WriteLine("\nDigite a data de admissão deste funcionário:");
            f.DataAdmissao = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nDigite o seu Id:");
            f.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDigite o CPF deste novo funcionário:");
            f.CPF = Console.ReadLine();

            if (ValidarSalarioAdmissao(f.Salario, f.DataAdmissao))
            {
                lista.Add(f);
                Console.WriteLine("\nNovo funcionário adicionado a lista.");
                ExibirLista();
            }

            else
            {
                Console.WriteLine($"\nSeu funcionário não pôde ser adicionado a lista, pois a data de contratação ou o salários estão inválidos.");
                return;
            }
        }

        public static void ObterPorIdDigitado()
        {
            Console.WriteLine("\nDigite o ID para buscar um funcionario:");
            int id = int.Parse(Console.ReadLine());
            Funcionario fBusca = lista.Find(x => x.Id == id);

            if (fBusca == null)
                Console.WriteLine("\nFuncionário não encontrado");
            else
            {
                Console.WriteLine($"\nFuncionário encontrado: {fBusca.Nome}");
            }
        }

        public static void ObterPorSalarioDigitado()
        {
            Console.WriteLine("\nDigite o salario minimo para buscar funcionários acima dessa margem de lucro:");
            decimal salario = decimal.Parse(Console.ReadLine());
            List<Funcionario> fBusca = lista.FindAll(x => x.Salario >= salario);
            

            if (fBusca.Count == 0)
                Console.WriteLine("\nNão foi encontrado nenhum funcionário que ganhe isso de salário.");
            else
            {
                Console.WriteLine($"\nFuncionários encontrados: {fBusca.Count}");

                foreach (var f in fBusca)
                {
                    Console.WriteLine("==================================");
                    Console.WriteLine($"Id: {f.Id}");
                    Console.WriteLine($"Nome: {f.Nome}");
                    Console.WriteLine($"CPF: {f.CPF}");
                    Console.WriteLine($"Admissão: {f.DataAdmissao:dd/MM/yyyy}");
                    Console.WriteLine($"Salário: {f.Salario:C2}");
                    Console.WriteLine($"Tipo: {f.TipoFuncionario}");
                    Console.WriteLine("==================================");
                }
            }
        }

        //Atividades 03
        public static void ObterPorNome()
        {
            Console.WriteLine("\nDigite o nome do funcionário para busca-lo");
            String nome = Console.ReadLine();
            Funcionario fBusca = lista.Find(x => x.Nome.ToLower() == nome.ToLower());

            if (fBusca == null)
                Console.WriteLine($"\n{nome} não existe na lista de funcionarios.");
            else
                Console.WriteLine($"\nSeu funcionario ({nome}) está na lista.");
        }

        public static void ObterFuncionariosRecentes()
        {
            lista.RemoveAll(x => x.Id < 4);

            var funcionarios = lista.OrderByDescending(x => x.Salario).ToList();

            if (funcionarios.Count > 0)
            {
                Console.WriteLine($"\nExibindo funcionários com o Id maior do que três:");

                foreach (Funcionario f in funcionarios)
                {
                    Console.WriteLine($"Seu funcionário: {f.Nome}, Id: {f.Id} recebe R${f.Salario} de salario.\n\n");
                }
            }

            else
                Console.WriteLine($"\nNão existe funcionários com o Id menor do que 4.");
        }

        public static void ObterEstatisticas()
        {
            int qtdFuncionarios = lista.Count;
            decimal somaSalarial = 0;

            foreach (Funcionario f in lista)
            {
                somaSalarial += f.Salario;
            }

            Console.WriteLine($"\nO total de dinheiro que você irá gastar com o salário destes {qtdFuncionarios} funcionários é de : R${somaSalarial}");
        }

        public static bool ValidarSalarioAdmissao(decimal salario, DateTime admissao)
        {


            if (salario == 0 || admissao < DateTime.Today)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidarNome(String nome)
        {
            

            if (string.IsNullOrWhiteSpace(nome) || nome.Trim().Length <= 2)
                return false;
                
            else
                return true;
        }

        public static void ObterPorTipo()
        {
            Console.WriteLine("\nDigite o seu tipo de trabalho (1 - CLT, 2 - Aprendiz)");

            int tipoTrabalhador = int.Parse(Console.ReadLine());

            List<Funcionario> funcionariosTipos = lista.FindAll(x => (int)x.TipoFuncionario == tipoTrabalhador);

            if (funcionariosTipos.Count == 0)
            {
                Console.WriteLine("\nNão existe essa classificação para nenhum de seus funcionários.");
            }

            else
            {
                foreach (Funcionario f in funcionariosTipos)
                {
                        Console.WriteLine("==================================");
                        Console.WriteLine($"Id: {f.Id}");
                        Console.WriteLine($"Nome: {f.Nome}");
                        Console.WriteLine($"CPF: {f.CPF}");
                        Console.WriteLine($"Admissão: {f.DataAdmissao:dd/MM/yyyy}");
                        Console.WriteLine($"Salário: {f.Salario:C2}");
                        Console.WriteLine($"Tipo: {f.TipoFuncionario}");
                        Console.WriteLine("==================================");
                }
            }
        }

        //atividade do INSS
        public static DateTime DetalharData()
        {
            Console.WriteLine("Digite uma data no formato dd/mm/aaaa:");
            String recebidor = Console.ReadLine();

            DateTime data = DateTime.Parse(recebidor);

            Console.WriteLine($"Então a data que você digitou é {data.ToString("dd 'de' MMMM 'de' yyyy")}");
            return data;

            if (data.DayOfWeek == DayOfWeek.Friday)
                Console.WriteLine($"Sendo exatamente um {data.ToString("dddd 'as' HH:mm")}");
        }

        public static void CalcularDescontoINSS()
        {
            decimal desconto;

            Console.WriteLine("Digite o seu salário :");
            decimal salario = decimal.Parse(Console.ReadLine());

            if (salario <= 1212)
            {
                desconto = salario * 0.075m;
                Console.WriteLine($"Será descontado 7,5% para o INSS , sendo cobrado {desconto:c2}");
                salario = salario - desconto;
                Console.WriteLine($"Com isso , agora você possui {salario:c2}");
            }
            else if (salario <= 2427.35m)
            {
                desconto = salario * 0.09m;
                Console.WriteLine($"Será descontado 9% para o INSS , sendo cobrado {desconto:c2}");
                salario = salario - desconto;
                Console.WriteLine($"Com isso , agora você possui {salario:c2}");
            }
            else if (salario <= 3641.03m)
            {
                desconto = salario * 0.12m;
                Console.WriteLine($"Será descontado 12% para o INSS , sendo cobrado {desconto:c2}");
                salario = salario - desconto;
                Console.WriteLine($"Com isso , agora você possui {salario:c2}");
            }
            else
            {
                desconto = salario * 0.14m;
                Console.WriteLine($"Será descontado 14% para o INSS , sendo cobrado {desconto:c2}");
                salario = salario - desconto;
                Console.WriteLine($"Com isso , agora você possui {salario:c2}");
            }
        }
        //fim das atividades

        public static void ExibirLista()
        {
            string dados = "";
            for (int i = 0; i < lista.Count; i++)
            {
                dados += "==================================\n";
                dados += string.Format("Id: {0} \n", lista[i].Id);
                dados += string.Format("Nome: {0} \n", lista[i].Nome);
                dados += string.Format("CPF: {0} \n", lista[i].CPF);
                dados += string.Format("Admissão: {0:dd/MM/yyyy} \n", lista[i].DataAdmissao);
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