using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula03Colecoes.Models.Enuns;

//assitam Hora de Aventura!!! "nunca vi rastro de cobra nem couro de lobisomem, se correr o bicho pega, se ficar o bicho come, porque eu sou é homem, porque eu sou é homem, menina eu sou é homem, menina eu sou é homem."

namespace Aula03Colecoes.Models
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }
        public TipoFuncionarioEnuns /*<-- isso aqui é a minha classe e lá na pasta Enuns, está os meu atributos.*/ TipoFuncionario { get; set; }
        public int MyProperty { get; set; }

        /*Abaixo estão os metodos*/

        public void ReajustarSalario()
        {
            Salario = Salario + (Salario * 10/100);
        }

        public string ExibirPeriodoExperiencia()
        {
            String PeriodoExperiencia = string.Format("Periodo de experiência: {0} até {1}", DataAdmissao, DataAdmissao.AddMonths(3));
            return PeriodoExperiencia;
        }

        public decimal CalcularDescVT(decimal percentual)
        {
            decimal desconto = this.Salario * percentual/100;
            return desconto;
        }


        private int ConteCaracter(String dado)
        {
            return dado.Length;
        }

        public bool ValidarCPF()
        {
            if(ConteCaracter(CPF) == 11)
                return true;
            else
                return false;
        }
    }
}