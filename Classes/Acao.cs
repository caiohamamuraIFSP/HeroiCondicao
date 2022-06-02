public class Acao 
{
    public void RealizaAcao(char acao, Personagem pers1, ref Personagem pers2)
    {
        if (acao == '1' || acao == '2')
            {
                int dano = pers1.Ataca(acao, ref pers2);
                pers2.recebeDano(dano);
                System.Console.WriteLine("Dano: " + dano);
            }
            else if (acao == '3')
            {
                pers1.UsaItem(pers1.item);
            }
            else
            {
                System.Console.WriteLine("escolha uma ação válida! : '1' , '2' ou '3'");
            }
    }
}