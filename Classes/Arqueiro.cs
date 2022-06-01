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
    public override int Ataca(char variante)
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
    public override int UsaItem(Item item)
    {
        return this.vida = this.vida + item.modificador;
    }
}