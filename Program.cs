using System;

class Program
{
    static bool run = true;
    static void Main(string[] args)
    {
        while(run){
        Personagem arqueiro = Arqueiro.Cria();
        Personagem mago = Mago.Cria();
        Batalha batalha1 = new Batalha(mago, arqueiro);
        }
    }
}