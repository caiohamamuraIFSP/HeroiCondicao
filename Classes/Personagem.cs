public abstract class Personagem
{
    protected int vida = 300;
    public int mana = 100;
    public int stamina = 100;
    protected Arma arma;
    public Item item;
    public abstract int Ataca(char variante, ref Personagem personagem);

    public abstract int UsaItem(Item item);
    public void EquipaArma(Arma arma)
    {
        this.arma = arma;
    }
        public void AdicionaItem(Item item){
        this.item = item;
    }

    public virtual int getVida()
    {
        return vida;
    }

    public virtual void recebeDano(int dano)
    {
        vida -= dano;
    }

    public virtual Personagem AtualizaCondicao()
    {
        return this;
    }
}