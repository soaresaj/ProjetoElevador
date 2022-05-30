using System;
using ProjetoElevador.Model;


namespace ProjetoElevador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random passageiro = new Random();
            Random andarParada = new Random();
            Random sairEntrar = new Random();
            //Random subirDescer = new Random();

            int novoPassageiro = 0;
            int andarParaParar = 0;
            int sairOuEntrar = 0;
            int subir = 1;

            Console.WriteLine("Qual o número de movimentos do elevador desejados?");
            int movimentos = int.Parse(Console.ReadLine());

            // Início do procedimento com a inicialização das variáveis
            Elevador elevador = new Elevador();
            System.Collections.Generic.List<Elevador> listParametros = Model.Elevador.Inicializar();


            // O procedimento de entrada e saída dos passageiros e movimentação do elevador vai ocorrer movimentos vezes
            for (int i = 1; i <= movimentos; i++)
            {
                if (i == 1 || listParametros[0].andarAtual == 0)
                {
                    sairOuEntrar = 1;
                    //Número aleatório de passageiros para entrar
                    novoPassageiro = passageiro.Next(1, listParametros[0].capacidadeElevador);

                    for (int j = 1; j <= novoPassageiro; j++)
                    {
                        //Permite entrar até a lotação do elevador
                        if (listParametros[0].pessoasNoElevador < listParametros[0].capacidadeElevador)
                        {
                            listParametros[0].pessoasNoElevador = Model.Elevador.Entrar(listParametros[0].pessoasNoElevador, listParametros[0].capacidadeElevador);
                            Console.WriteLine($"O número de pessoas no elevador é {listParametros[0].pessoasNoElevador}.");
                        }

                    }
                }
                else
                    if (listParametros[0].pessoasNoElevador == 0) {
                    sairOuEntrar = 1;
                    }
                    else
                        sairOuEntrar = sairEntrar.Next(0, 1);

                if (listParametros[0].andarAtual == 0) {
                    subir = 1;
                }
                else if(listParametros[0].andarAtual == listParametros[0].totalAndares)
                {
                    subir = 0;
                }
                else if ((subir == 1) && (listParametros[0].andarAtual < listParametros[0].totalAndares)) 
                {

                }
                else if((subir == 0) && (listParametros[0].andarAtual > 0))
                {

                }
                    
                //Verifica se o elevador deve subir
                if ((subir == 1) && (listParametros[0].andarAtual < listParametros[0].totalAndares)) {
                    listParametros[0].andarAtual = Model.Elevador.Subir(listParametros[0].totalAndares, listParametros[0].andarAtual);
                    Console.WriteLine($"O elevador está no andar {listParametros[0].andarAtual}.");
                }
                //Verifica se o elevador deve descer
                else if ((subir == 0) && (listParametros[0].andarAtual > 0))
                {
                    listParametros[0].andarAtual = Model.Elevador.Descer(listParametros[0].totalAndares, listParametros[0].andarAtual);
                    Console.WriteLine($"O elevador está no andar {listParametros[0].andarAtual}.");

                }
                //Obtém um andar para Parar -- para facilitar só é possível descer 1 passagerio
                //Se estiver subindo e no último andar descem todos
                //Se estiver descendo e no térreo descem todos
                if ((listParametros[0].andarAtual == 0) || (listParametros[0].andarAtual == listParametros[0].totalAndares))
                {
                    andarParaParar = listParametros[0].andarAtual;
                }
                else
                    andarParaParar = andarParada.Next(1, listParametros[0].totalAndares);

                if (listParametros[0].andarAtual == andarParaParar)
                {
                    sairOuEntrar = sairEntrar.Next(0, 1);
                    if ((listParametros[0].andarAtual == 0) || (listParametros[0].andarAtual == listParametros[0].totalAndares))
                    {
                        novoPassageiro = listParametros[0].pessoasNoElevador;
                    }
                    else
                        novoPassageiro = passageiro.Next(1, 6);

                    if (sairOuEntrar == 0 && (listParametros[0].pessoasNoElevador > 0)) //Os passageiros irão sair
                    {
                        Console.WriteLine($"O Elevador parou no {andarParaParar}.");
                        if (novoPassageiro > listParametros[0].pessoasNoElevador) {
                            novoPassageiro = listParametros[0].pessoasNoElevador;
                        }

                        Console.WriteLine($"{novoPassageiro} passageiros irão sair.");
                        if ((subir == 1) && (listParametros[0].andarAtual == listParametros[0].totalAndares))
                        {
                            while (listParametros[0].pessoasNoElevador > 0)
                            {
                                listParametros[0].pessoasNoElevador = Model.Elevador.Sair(listParametros[0].pessoasNoElevador);
                                
                            }
                            Console.WriteLine($"O número de pessoas no elevador é {listParametros[0].pessoasNoElevador}.");
                        }
                        else if ((subir == 1) && (listParametros[0].andarAtual > 0 && listParametros[0].andarAtual < listParametros[0].totalAndares))
                        {
                            for (int j = 1; j <= novoPassageiro; j++)
                            {
                                listParametros[0].pessoasNoElevador = Model.Elevador.Sair(listParametros[0].pessoasNoElevador);

                            }
                            Console.WriteLine($"O número de pessoas no elevador é {listParametros[0].pessoasNoElevador}.");
                        }
                        else if ((subir == 0) && (listParametros[0].andarAtual == 0))
                        {                                                    
                            while (listParametros[0].pessoasNoElevador > 0)
                            {
                                listParametros[0].pessoasNoElevador = Model.Elevador.Sair(listParametros[0].pessoasNoElevador);

                            }
                            Console.WriteLine($"O número de pessoas no elevador é {listParametros[0].pessoasNoElevador}.");
                        }
                        else if ((subir == 0) && (listParametros[0].andarAtual > 0 && listParametros[0].pessoasNoElevador < listParametros[0].totalAndares))
                        {
                            for (int j = 1; j <= novoPassageiro; j++)
                            {
                                listParametros[0].pessoasNoElevador = Model.Elevador.Sair(listParametros[0].pessoasNoElevador);

                            }
                            Console.WriteLine($"O número de pessoas no elevador é {listParametros[0].pessoasNoElevador}.");
                        }
                    }
                    else //Os passageiros irão entrar
                    {
                        Console.WriteLine($"O Elevador parou no {andarParaParar}.");
                        if ((subir == 1) && (listParametros[0].andarAtual < listParametros[0].totalAndares))
                        {
                            for (int j = 1; j <= novoPassageiro; j++)
                            {
                                listParametros[0].pessoasNoElevador = Model.Elevador.Entrar(listParametros[0].pessoasNoElevador, listParametros[0].capacidadeElevador);

                            }
                            Console.WriteLine($"O número de pessoas no elevador é {listParametros[0].pessoasNoElevador}.");
                            
                        }
                        else if (subir == 0 && (listParametros[0].andarAtual > 0))
                        {
                            for (int j = 1; j <= novoPassageiro; j++)
                            {
                                listParametros[0].pessoasNoElevador = Model.Elevador.Entrar(listParametros[0].pessoasNoElevador, listParametros[0].capacidadeElevador);

                            }
                            Console.WriteLine($"O número de pessoas no elevador é {listParametros[0].pessoasNoElevador}.");
                            
                        }
 
                    }
 
                }

            }

        }

    }
  
}
