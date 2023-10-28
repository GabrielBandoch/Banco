/*
Eng de Software, 2ª fase
Programação Orientada a Objetos
Aluno: Xunda von Silva
 */


using Banco;

// "prepara" o nosso banco de dados
List<Conta> bancoDados = new List<Conta>();

// prepara a tela do computador para ser usada pelo software
Tela tela = new Tela();
tela.configurarTela();

// crias as variáveis que serão usadas no menu de opções 
string opcao;
List<string> menuPrincipal = new List<string>();
menuPrincipal.Add("1 - Lançar transação ");
menuPrincipal.Add("2 - Emitir extrato   ");
menuPrincipal.Add("3 - Consultar conta  ");
menuPrincipal.Add("4 - Bloqueio de conta");
menuPrincipal.Add("5 - Cadastro de conta");
menuPrincipal.Add("0 - Sair             ");

// agora vem o programa de verdade
while (true)
{
    tela.montarTelaSistema("Banco de Sistema");
    opcao = tela.mostrarMenu(menuPrincipal, 3, 3);

    // o usuario pediu pra sair do sistema
    if (opcao == "0") break;


    // o usuário pediu para lançar movimentos na conta
    if (opcao == "1")
    {
        tela.montarMoldura(7, 5, 70, 12, "Movimentação");

        // pergunta o numero da conta
        Console.SetCursorPosition(8, 7);
        Console.Write("Numero  : ");
        string num = Console.ReadLine();

        // procura pela conta
        int x;
        bool achou = false;
        for (x=0; x<bancoDados.Count; x++)
        {
            if (bancoDados[x].Numero == num)
            {
                achou = true;
                break;
            }
        }

        // se achou a conta
        if (achou)
        {
            // pergunta o tipo (debito ou credito)
            Console.SetCursorPosition(8, 8);
            Console.Write("Tipo D/C: ");
            string tip = Console.ReadLine().ToUpper();

            // pergunta o motivo
            Console.SetCursorPosition(8, 9);
            Console.Write("Motivo  : ");
            string mot = Console.ReadLine();

            // pergunta o valor
            Console.SetCursorPosition(8, 10);
            Console.Write("Valor   : ");
            decimal val = Convert.ToDecimal(Console.ReadLine());

            // pergunta se confirma o movimento
            Console.SetCursorPosition(8, 11);
            Console.Write("Confirma (S/N) : ");
            string resp = Console.ReadLine().ToUpper();

            if (resp == "S")
            {
                bancoDados[x].registrarMovimento(tip, mot, val);
            }
        }
        else
        {
            // se não achou a conta
            Console.SetCursorPosition(8, 8);
            Console.Write("Conta não encontrada. Pressione uma tecla.");
            Console.ReadKey(true);
        }
    }


    // o usuário deseja emitir extrato
    if (opcao == "2")
    {
        // prepara a tela e pergunta a conta
        Console.Clear();
        tela.montarMoldura(0, 0, 79, 3, "Extrato");
        Console.SetCursorPosition(1, 2);
        Console.Write("Conta : ");
        string num = Console.ReadLine();

        // procura a conta
        int x;
        bool achou = false;
        for (x = 0; x < bancoDados.Count; x++)
        {
            if (bancoDados[x].Numero == num)
            { 
                achou = true;
                break;
            }
        }

        // mostra o extrato ou uma mensagem de erro
        Console.SetCursorPosition(0, 4);
        if (achou) Console.Write(bancoDados[x].recuperarExtrato());
        else Console.Write("Conta não existe.");
        Console.ReadKey(true);
    }



    // o usuario pediu para consultar uma conta
    if (opcao == "3")
    {
        tela.montarMoldura(7, 5, 70, 9, "Consulta");

        // pergunta o numero da conta
        Console.SetCursorPosition(8, 7);
        Console.Write("Numero  : ");
        string num = Console.ReadLine();

        // verifica se a conta NUM existe
        Console.SetCursorPosition(8, 8);
        bool achou = false;
        for(int x=0; x<bancoDados.Count; x++)
        {
            // verifica se o objeto CONTA na posicao X do
            // banco de dados refere-se à conta NUM solicitada
            if (bancoDados[x].Numero == num)
            {
                // encontrou a conta
                achou = true;
                Console.Write(bancoDados[x].mostrarDados());
                break;
            }
        }
        if (!achou) Console.Write("Conta não existe!");
        Console.ReadKey(true);
    }


    // usuario pediu pra cadastrar uma nova cona
    if (opcao == "5")
    {
        tela.montarMoldura(7, 7, 40, 12, "Nova conta");

        // pergunta o numero da conta
        Console.SetCursorPosition(8, 9);
        Console.Write("Numero  : ");
        string num = Console.ReadLine();

        // pergunta o titular da conta
        Console.SetCursorPosition(8, 10);
        Console.Write("Titular : ");
        string tit = Console.ReadLine();

        // solicita confirmação para cadastro
        Console.SetCursorPosition(8, 11);
        Console.Write("Confirma cadastro (S/N) : ");
        string resp = Console.ReadLine();

        // coloca a nova conta no BD caso o usuário confirme
        // o cadastro
        if (resp.ToUpper()=="S")
        {
            // "cadastra" no BD
            bancoDados.Add(  new Conta(num,tit)  );

            // Conta c = new Conta(num,tit);
            // bancoDados.Add(c);
        }
    }
}
