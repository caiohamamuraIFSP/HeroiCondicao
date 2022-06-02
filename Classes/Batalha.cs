using System;

public class Batalha
{
    public int turno = 1;

    public Batalha(Personagem personagem1, Personagem personagem2)
    {
        Acao acao = new Acao();
        //Refatorar Tudo, mudar o metodo ataca para void?
        while (personagem1.getVida() > 0 && personagem2.getVida() > 0)
        {
            System.Console.WriteLine("Vida P1: " + personagem1.getVida() + " | Vida P2: " + personagem2.getVida());
            if (this.turno == 1)
            {
                char acaoEscolhida = RecebeAcao();
                acao.RealizaAcao(acaoEscolhida, personagem1, ref personagem2);
                personagem1 = personagem1.AtualizaCondicao();
            }
            else
            {
                Random rnd = new Random();
                int acaoBruto = rnd.Next(1, 4);
                char acaoEscolhida = acaoBruto.ToString()[0];
                acao.RealizaAcao(acaoEscolhida, personagem2, ref personagem1);
                personagem2 = personagem2.AtualizaCondicao();
            }
            Console.ResetColor();
            trocaTurno();
        }
        
    }

    private char RecebeAcao()
    {
        while (true)
        {
            ConsoleKeyInfo escolha = Console.ReadKey(true);
            if (escolha.Key == ConsoleKey.D1)
                return '1';
            if (escolha.Key == ConsoleKey.D2)
                return '2';
            if (escolha.Key == ConsoleKey.D3)
                return '3';
        }
    }

    public int trocaTurno()
    {
        int turno = (this.turno * (-1));
        this.turno = turno;
        return turno;
    }
}