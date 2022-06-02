using System;

public class Arqueiro : Personagem
{
    static Random rnd = new Random();
    public static Personagem Cria()
    {
        Personagem arqueiro = new Arqueiro();
        FabricaEquipamentos fabricaArqueiro = new FabricaArqueiro();
        arqueiro.EquipaArma(fabricaArqueiro.CriaArma());
        arqueiro.AdicionaItem(fabricaArqueiro.CriaItem());
        return arqueiro;
    }

    private Arqueiro() { }
    public override int Ataca(char variante, ref Personagem personagem)
    {
        if (variante == '1')
        {
            System.Console.WriteLine("Flecha normal");
            var dano = rnd.Next(1, 4) + this.arma.forca;
            var critico = rnd.Next(0, 100);
            if (critico > 5)
            {
                return dano;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return dano * 2;
            }
        }
        if (variante == '2')
        {
            if (this.stamina >= 5)
            {
                System.Console.WriteLine("Flecha especial");
                personagem = AdicionaCondicao(personagem);
                var dano = rnd.Next(0, 8) + this.arma.forca;
                var critico = rnd.Next(0, 100);
                this.stamina = this.stamina - 5;
                if (critico > 25)
                {
                    return dano;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    return dano * 2;
                }
            }
            else
            {
                System.Console.WriteLine("muito cansado para isso");
                return 0;
            }
        }
        else
        {
            return 0;
        }
    }

    public Personagem AdicionaCondicao(Personagem personagem)
    {
        var rand = new Random();
        int aleatorio = rand.Next(0,4);
        if (aleatorio == 0)
            return Envenenado.Envenenar(personagem);
        else if (aleatorio == 1)
            return Envenenado.Envenenar(personagem);
        else   
            return personagem;
    }
    
    public override int UsaItem(Item item)
    {
        return this.vida = this.vida + item.modificador;
    }
}