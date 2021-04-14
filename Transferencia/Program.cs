using System;
using System.Collections.Generic;

namespace Transferencia
{
    class Program
    {
        static List<Conta> ListContas = new List<Conta>();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                    ListarContas();
                    break;
                    case "2":
                    InserirConta();
                    break;
                    case "3":
                    Transferir();
                    break;
                    case "4":
                    SacarConta();
                    break;
                    case "5":
                    DepositarConta();
                    break;
                    case "C":
                    Console.Clear();
                    break;
                    default:
                    throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();


            }
            
            
            Console.WriteLine("Obrigado por usar nosso serviço");

            
        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTranferencia = double.Parse(Console.ReadLine());

            ListContas[indiceContaOrigem].Tranferir(valorTranferencia,ListContas[indiceContaDestino]);
        }

        private static void DepositarConta()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            ListContas[indiceConta].Depositar(valorDeposito);
        }

        private static void SacarConta()
        {
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorRetirada = double.Parse(Console.ReadLine());

            ListContas[indiceConta].Sacar(valorRetirada);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas ");
            if (ListContas.Count==0)
            {
                Console.WriteLine("Nehuma conta cadastrada.");
                return;
            }
            for (int i=0; i<ListContas.Count; i++)
            {
                Conta conta=ListContas[i];
                Console.Write("#{0} - ",i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta" );
            Console.WriteLine ("Digite 1 para conta Fisica ou 2 para Juridita: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome= Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double  entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                                        tipoConta:(TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome:entradaNome);
            ListContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("c- limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            String opcaoUsiario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsiario;
        }


    }
}
