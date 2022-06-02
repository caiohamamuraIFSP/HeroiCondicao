using System;

public class Envenenado : Personagem
{
    Personagem personagem;
    static Random rnd = new Random();
    private int turnos = 3;

    public static Personagem Envenenar(Personagem personagem)
    {
        if (personagem.GetType().ToString() == "Envenenado")
        {
            Console.WriteLine("Já está envenenado!!!");
            ((Envenenado)personagem).RenovaVeneno();
            return personagem;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Envenenado!!!");
            Console.ResetColor();
            return new Envenenado(personagem);
        }
    }

    private Envenenado(Personagem personagem)
    {
        this.personagem = personagem;
    }

    public override int Ataca(char variante, ref Personagem personagem)
    {
        int dano = this.personagem.Ataca(variante, ref personagem);
        int danoReduzido = (int)(dano * 0.8);
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"Você está fraco por causa do veneno, seu dano foi reduzido de {dano} para {danoReduzido}!");
        Console.ResetColor();
        return dano;
    }

    public override int getVida()
    {
        return personagem.getVida();
    }

    public override void recebeDano(int dano)
    {
        personagem.recebeDano(dano);
    }

    public override int UsaItem(Item item)
    {
        return this.mana = this.mana + item.modificador;
    }

    public override Personagem AtualizaCondicao()
    {
        int danoVeneno = (int)Math.Ceiling(personagem.getVida() * 0.1);
        this.personagem.recebeDano(danoVeneno);
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine($"Envenenado, perdeu {danoVeneno} de vida!!!");
        Console.ResetColor();
        turnos--;

        if (turnos <= 0)
            return personagem;
        
        return this;
    }

    private void RenovaVeneno()
    {
        turnos = 3;
    }
}