using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Mensagem");
            Console.WriteLine("2. Concatenar nome e sobrenome");
            Console.WriteLine("3. Calcular valores");
            Console.WriteLine("4. Quantidade de caracteres");
            Console.WriteLine("5. Verificar placa");
            Console.WriteLine("6. Dias");
            Console.WriteLine("7. Sair");
            Console.WriteLine("-----------------------------------");

            int opcao;
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                continue;
            }

            // Executa a funcionalidade com base na opção escolhida
            switch (opcao)
            {
                case 1:
                    HelloWorld();
                    break;
                case 2:
                    FullName();
                    break;
                case 3:
                    Calculate();
                    break;
                case 4:
                    TextLength();
                    break;
                case 5:
                    VerifyPlate();
                    break;
                case 6:
                    Days();
                    break;
                case 7:
                    Console.WriteLine("Saindo do programa...");
                    return;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }
    }

    static void HelloWorld()
    {
        Console.WriteLine("Digite seu nome:");
        string nome = Console.ReadLine();

        // Concatenando o nome do usuário com a mensagem de boas-vindas
        string mensagem = "Olá, " + nome + "! Seja muito bem-vindo!";

        // Exibindo a mensagem
        Console.WriteLine(mensagem);
        Console.WriteLine();
    }

    static void FullName()
    {
        Console.WriteLine("Digite seu nome:");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite seu sobrenome:");
        string sobrenome = Console.ReadLine();

        string nomeCompleto = nome + " " + sobrenome;
        Console.WriteLine("Nome completo: " + nomeCompleto);
        Console.WriteLine();
    }

    static void Calculate()
    {
        double value1, value2;

        Console.WriteLine("Digite o primeiro número:");
        while (!double.TryParse(Console.ReadLine(), out value1))
        {
            Console.WriteLine("Valor inválido. Por favor, digite um número válido:");
        }

        Console.WriteLine("Digite o segundo número:");
        while (!double.TryParse(Console.ReadLine(), out value2))
        {
            Console.WriteLine("Valor inválido. Por favor, digite um número válido:");
        }

        Console.WriteLine("Soma: " + (value1+value2));
        Console.WriteLine("Subtração: " + (value1-value2));
        Console.WriteLine("Multiplicação: " + (value1*value2));

        if (value2 != 0)
        {
            Console.WriteLine("Divisão : " + (value1 / value2));
        }
        else
        {
            Console.WriteLine("Erro: Divisão por zero!");
        }

        Console.WriteLine("Média: " + (value1 * value2) / 2);
        Console.WriteLine();

    }

    static void TextLength()
    {
        string value;
        int length;

        Console.WriteLine("Digite um texto");
        value = Console.ReadLine();

        length = value.Trim().Length;

        Console.WriteLine($"O texto possui {length} caracteres.");
        Console.WriteLine();
    }

    static void VerifyPlate()
    {
        Console.WriteLine("Digite a placa do veículo (formato: ABC1234):");
        string plate = Console.ReadLine();
        bool validPlate = ValidatePlate(plate);
        string isValidPlate = validPlate ? "Sim :)" : "Não :(";

        Console.WriteLine("Placa válida ? " + isValidPlate);
        Console.WriteLine();
    }

    static bool ValidatePlate(string plate)
    {
        Regex regex = new Regex(@"^[A-Za-z]{3}\d{4}$");
        return regex.IsMatch(plate);
    }

    static void Days()
    {
        Console.WriteLine("Escolha o formato de exibição da data atual:");
        Console.WriteLine("1. Formato completo (dia da semana, dia do mês, mês, ano, hora, minutos, segundos)");
        Console.WriteLine("2. Apenas a data no formato '01/03/2024'");
        Console.WriteLine("3. Apenas a hora no formato de 24 horas");
        Console.WriteLine("4. A data com o mês por extenso");

        int opcao;
        if (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 4)
        {
            Console.WriteLine("Opção inválida. Por favor, digite um número de 1 a 4.");
            return;
        }

        DateTime dataAtual = DateTime.Now;
        string formato = "";

        switch (opcao)
        {
            case 1:
                formato = "dddd, dd, MMM, yyyy, HHHH, mmmm, ssss";
                break;
            case 2:
                formato = "dd/MM/yyyy";
                break;
            case 3:
                formato = "HH:mm:ss";
                break;
            case 4:
                formato = "dd 'de' MMMM 'de' yyyy";
                break;
        }

        Console.WriteLine("A data atual é: " + dataAtual.ToString(formato));
        Console.WriteLine();
    }
}