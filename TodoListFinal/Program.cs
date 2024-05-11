var TODOList = new List<string>();
bool isValid = true;

do
{
    Console.WriteLine("---------------------------------------");
    Console.WriteLine("" +
        "Olá!\n" +
        "O que você deseja fazer?\n" +
        "[1] Ver todos os TODOs\n" +
        "[2] Adicionar um TODO\n" +
        "[3] Remover um TODO\n" +
        "[4] Sair");
    Console.WriteLine("---------------------------------------");

    string? userInput = Console.ReadLine();

    bool tryParseInput = int.TryParse(userInput, out int number);

    if (tryParseInput)
    {
        Console.WriteLine();
        TODOProgram(number);
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine("Escolha uma opção válida!\n");
    }


} while (isValid);

void TODOProgram(int userInput)
{
    switch (userInput)
    {
        case 1:
            ShowAllTODO(TODOList);
            break;
        case 2:
            AddNewTODO(TODOList);
            break;
        case 3:
            RemoveTODO(TODOList);
            break;
        case 4:
            isValid = false;
            break;
        default:
            Console.WriteLine("Opção inválida ou vazia!");
            break;
    }
}

void ShowAllTODO(List<string> TODOList)
{
    if (TODOList.Count > 0)
    {
        int i = 1;
        foreach (string TODO in TODOList)
        {
            Console.WriteLine($"{i}. {TODO}");
            i++;
        }
    }
    else
    {
        Console.WriteLine("Ainda não foi adicionado nenhum TODO para a lista!\n");
    }
}

void AddNewTODO(List<string> TODOList)
{
    Console.WriteLine("Insira a descrição do TODO:");
    string? newTODO = Console.ReadLine();
    if (string.IsNullOrEmpty(newTODO))
    {
        Console.WriteLine("Valor nulo ou vazio!\n");
    }
    else
    {
        if (TODOList.Contains(newTODO))
        {
            Console.WriteLine("Já existe um TODO com essa descrição!\n");
        }
        else
        {
            TODOList.Add(newTODO);
        }
    }
}

void RemoveTODO(List<string> TODOList)
{
    bool loop = true;
    do
    {
        Console.WriteLine("Insira o índice do TODO que deseja remover:\n");
        ShowAllTODO(TODOList);
        Console.WriteLine();
        if (TODOList.Count > 0)
        {
            string? userInput = Console.ReadLine();
            Console.WriteLine();
            bool tryParseInput = int.TryParse(userInput, out int parsedUserInput);
            if (!tryParseInput)
            {
                Console.WriteLine("Valor inválido! Tente novamente.\n");
            }
            else if (TODOList.Count < parsedUserInput) 
            {
                Console.WriteLine("Valor fora de índice! Tente novamente\n");
            }
            else
            {
                int realIndex = parsedUserInput - 1;
                Console.WriteLine("TODO removido: " + TODOList[realIndex]);
                TODOList.RemoveAt(realIndex);
                loop = false;
            }

        }
    } while (loop);
}


