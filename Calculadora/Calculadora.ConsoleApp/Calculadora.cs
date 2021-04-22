using System;


namespace Calculadora.ConsoleApp
{
    class Calculadora
    {
        public void Resultado(string opcao, double primeiroNumero, double segundoNumero)
        {
            double resultado = 0;

            switch (opcao)
            {
                case "1": resultado = primeiroNumero + segundoNumero; break;

                case "2": resultado = primeiroNumero - segundoNumero; break;

                case "3": resultado = primeiroNumero * segundoNumero; break;

                case "4": resultado = primeiroNumero / segundoNumero; break;

                default:
                    break;
            }
            Console.WriteLine(resultado);

            Console.WriteLine();

            Console.ReadLine();

            Console.Clear();
            //simbolo operação
            string simboloOperacao = "";

            switch (opcao)
            {
                case "1": simboloOperacao = "+"; break;

                case "2": simboloOperacao = "+"; break;

                case "3": simboloOperacao = "+"; break;

                case "4": simboloOperacao = "+"; break;

                default:
                    break;
            }

            string operacaoRealizada = $"{primeiroNumero} {simboloOperacao} {segundoNumero} = {resultado}";

        }

    }
}
