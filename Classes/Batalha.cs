public class Batalha
{
    public int turno = 1;
    public Batalha(Personagem personagem1, Personagem personagem2)
    {
        //Refatorar Tudo, mudar o metodo ataca para void?
        while (personagem1.vida > 0 && personagem2.vida > 0)
        {
            System.Console.WriteLine("Vida P1: " + personagem1.vida + " | Vida P2: " + personagem2.vida);
            bool naoAgiu = true;
            while (naoAgiu)
            {
                if (this.turno == 1)
                {

                    char acao = Console.ReadLine()[0];
                    if (acao == '3')
                    {
                        personagem1.UsaItem(personagem1.item);
                    }
                    int dano = personagem1.Ataca(acao);
                    if (dano == 0)
                    {
                        System.Console.WriteLine("escolha uma ação válida! : '1' , '2' ou '3'");
                    }
                    else
                    {
                        personagem2.vida = personagem2.vida - dano;
                        System.Console.WriteLine("Dano: " + dano);
                        naoAgiu = false;
                    }
                }
                else
                {
                    Random rnd = new Random();
                    int acaoBruto = rnd.Next(0, 3);
                    char acao = Convert.ToChar(acaoBruto + 49);
                    if (acao == '3')
                    {
                        personagem2.UsaItem(personagem2.item);
                    }
                    else
                    {
                        int dano = personagem2.Ataca(acao);
                        personagem1.vida = personagem1.vida - dano;
                        System.Console.WriteLine("Dano: " + dano);
                        naoAgiu = false;
                    }
                }
            }
            Console.ResetColor();
            trocaTurno();
        }
    }
    public int trocaTurno()
    {
        int turno = (this.turno * (-1));
        this.turno = turno;
        return turno;
    }
}