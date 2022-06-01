public class Mago : Personagem
{
    static Random rnd = new Random();
    public static Personagem Cria()
    {
        Personagem mago = new Mago();
        FabricaEquipamentos fabricaMago = new FabricaMago();
        mago.EquipaArma(fabricaMago.CriaArma());
        mago.AdicionaItem(fabricaMago.CriaItem());
        return mago;
    }

    private Mago() { }

    public override int Ataca(char variante)
    {
        if (variante == '1')
        {
            System.Console.WriteLine("Magia normal");
            var dano = rnd.Next(0, 5) + this.arma.forca;
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
            if (this.mana >= 8)
            {
                System.Console.WriteLine("Magia especial");
                var dano = rnd.Next(10, 15) + this.arma.forca;
                var critico = rnd.Next(0, 100);
                this.mana = this.mana - 8;
                if (critico > 10)
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
                System.Console.WriteLine("i need more mana");
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
        return this.mana = this.mana + item.modificador;
    }
}