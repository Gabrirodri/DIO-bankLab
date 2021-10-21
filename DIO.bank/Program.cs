using System;
using System.Collections.Generic;

namespace DIO.bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
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
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();

            }
            Console.WriteLine("Obrigado por utilizar nosso serviços. ");
            Console.WriteLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite numero da conta de Origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite numero da conta de Destino: ");
            int contaDestino = int.Parse(Console.ReadLine());
            Console.WriteLine("Valor a ser Transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[contaOrigem].Transferir(valorTransferencia,listContas[contaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor do Deposito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");
            if(listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta Cadastrada");
                return;
            }
            for (int i = 0; i < listContas.Count; i++) 
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }

        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova Conta ");
            Console.WriteLine("Digite 1 para pessoa Fisica e 2 para pessoa Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite nome do Cliente: ");
            string entradaNome = Console.ReadLine();
            Console.WriteLine("Digite Saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());
            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu Dispor!!");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
