using System;


namespace Calculadora.ConsoleApp
{
    class Program
    {
        #region Requisito Funcional 01 [OK]
        //Nossa calculadora deve ter a possibilidade de somar dois números
        #endregion

        #region Requisito Funcional 02 [OK]
        //Nossa calculadora deve ter a possibilidade fazer várias operações de soma
        #endregion

        #region Requisito Funcional 03 [OK]
        //Nossa calculadora deve ter a possibilidade fazer várias operações de soma e de subtração
        #endregion

        #region Requisito Funcional 04 [OK]
        //Nossa calculadora deve ter a possibilidade fazer as quatro operações básicas da matemática
        #endregion

        #region Requisito Funcional 05 [OK]
        //Nossa calculadora deve validar a opções do menu [OK]
        #endregion

        #region BUG 01 [OK]
        //Nossa calculadora deve realizar as operações com "0"
        #endregion

        #region Requisito Funcional 06 [OK]
        /** Nossa calculadora deve permitir visualizar as operações já realizadas
         *  Critérios:
         *      1 - A descrição da operação realizada deve aparecer assim, exemplo:
         *          2 + 2 = 4
         *          10 - 5 = 5
         *          
         *      2 - Caso não nehuma operação foi realizada, mostrar a msg:
         *          Nehuma operação foi realizada ainda
         */
        #endregion

        #region Requisto Não Funcional 01
        //Todas as funcionalidades implementadas,
        //precisamos melhorar o entendimento do nosso código
        #endregion


        static string[] operacoesRealizadas = new string[100];
        static void Main(string[] args)
        {
                string opcao = "";
                int contadorOperacoesRealizadas = 0;

                while (true)
                {
                    MostrarMenu();

                    opcao = Console.ReadLine();

                    if (EhOpcaoInvalida(opcao)) //AND 
                    {
                        MostrarMensagem("Opção inválida! Tente novamente");

                        continue;
                    }

                    if (EhOpcaoVisualizacao(opcao))
                    {
                        Console.WriteLine();

                        if (contadorOperacoesRealizadas == 0)
                            MostrarMensagem("Nehuma operação foi realizada ainda. Tente novamente");

                        else
                            MostrarOperacoesRealizadas(operacoesRealizadas);

                        Console.ReadLine();

                        Console.Clear();

                        continue;
                    }

                    if (EhOpcaoSair(opcao))
                        break;

                    double primeiroNumero, segundoNumero;

                    primeiroNumero = ObterNumero("primeiro");

                    do
                    {
                        segundoNumero = ObterNumero("segundo");

                        if (SegundoNumeroInvalido(opcao, segundoNumero))
                            MostrarMensagem("Segundo número inválido! Tente novamente");

                    } while (SegundoNumeroInvalido(opcao, segundoNumero));


                Calculadora calcula = new Calculadora();
                calcula.Resultado(opcao, primeiroNumero, segundoNumero);

                string operacaoRealizada = $"{primeiroNumero} {calcula} {segundoNumero} = {calcula}";

                RegistrarOperacaoRealizada(ref contadorOperacoesRealizadas, operacaoRealizada);

            }
            }
        private static int RegistrarOperacaoRealizada(ref int contadorOperacoesRealizadas, string operacaoRealizada)
        {
            operacoesRealizadas[contadorOperacoesRealizadas] = operacaoRealizada;

            contadorOperacoesRealizadas++;

            return contadorOperacoesRealizadas;
        }
        private static bool SegundoNumeroInvalido(string opcao, double segundoNumero)
            {
                return opcao == "4" && segundoNumero == 0;
            }

            private static double ObterNumero(string ordem)
            {
                Console.Write($"Digite o {ordem} número: ");

                double numero = Convert.ToDouble(Console.ReadLine());

                return numero;
            }

            private static bool EhOpcaoSair(string opcao)
            {
                return opcao.Equals("s", StringComparison.OrdinalIgnoreCase);
            }

            private static void MostrarOperacoesRealizadas(string[] operacoesRealizadas)
            {
                for (int i = 0; i < operacoesRealizadas.Length; i++)
                {
                    if (operacoesRealizadas[i] != null)
                        Console.WriteLine(operacoesRealizadas[i]);
                }
            }

            private static bool EhOpcaoVisualizacao(string opcao)
            {
                return opcao == "5";
            }

            private static void MostrarMensagem(string mensagem)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(mensagem);

                Console.ResetColor();

                Console.ReadLine();

                Console.Clear();
            }

            private static void MostrarMenu()
            {
                Console.WriteLine("Calculadora Tabajara 1.7.1");

                Console.WriteLine();

                Console.WriteLine("Digite 1 para somar");

                Console.WriteLine("Digite 2 para subtrair");

                Console.WriteLine("Digite 3 para multiplicação");

                Console.WriteLine("Digite 4 para divisão");

                Console.WriteLine("Digite 5 para visualizar as operações realizadas");

                Console.WriteLine();

                Console.WriteLine("Digite S para sair");
            }

            private static bool EhOpcaoInvalida(string opcao)
            {
                return opcao != "1" && opcao != "2" && opcao != "3"
                                    && opcao != "4" && opcao != "5"
                                    && opcao != "S" && opcao != "s";
            }
    }
}
