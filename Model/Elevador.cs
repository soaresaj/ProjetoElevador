using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoElevador.Model
{
    class Elevador
    {
        
        public int totalAndares { get; set; }
        public int capacidadeElevador { get; set; }
        public int andarAtual { get; set; }
        public int pessoasNoElevador { get; set; }
                
        public static List<Elevador> Inicializar()
        {
            //Deve receber como parâmetros a capacidade do elevador e o total de
            //andares no prédio(os elevadores sempre começam no térreo e vazio)
            List<Elevador> parametros = new List<Elevador>();

            Elevador elevador = new Elevador();

            Console.WriteLine("Qual o total de andares do prédio?");
            elevador.totalAndares = int.Parse(Console.ReadLine());
            Console.WriteLine("Qual a capacidade do elevador?");
            elevador.capacidadeElevador = int.Parse(Console.ReadLine());
            elevador.andarAtual = 0;
            elevador.pessoasNoElevador = 0;

            parametros.Add(elevador);

            return parametros;

        }
        public static int Entrar(int lotacaoElevador, int capacidade)
        {
            //Deve acrescentar uma pessoa no elevador (só deve acrescentar se ainda houver
            //espaço)
            if (lotacaoElevador < capacidade)
            {
                lotacaoElevador++;
            }
            return lotacaoElevador;
        }

        public static int Sair(int lotacaoElevador)
        {
            //Deve remover uma pessoa do elevador (só deve remover se houver alguém
            //dentro dele)
            if (lotacaoElevador > 0)
            {
                lotacaoElevador--;
            }
            return lotacaoElevador;
        }

        public static int Subir(int totalDeAndares, int andar)
        {
            //Deve subir um andar (não deve subir se já estiver no último andar)
            if (andar < totalDeAndares)
            {
                andar++;
            }
            return andar;
        }

        public static int Descer(int totalDeAndares, int andar)
        {
            //Deve descer um andar (não deve descer se já estiver no térreo)
            if (andar > 0)
            {
                andar--;
            }
            return andar;
        }
    }
}
