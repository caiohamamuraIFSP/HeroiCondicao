public abstract class Personagem
{
    public int vida = 300;
    public int mana = 100;
    public int stamina = 100;
    protected Arma arma;
    public Item item;
    public abstract int Ataca(char variante);

    public abstract int UsaItem(Item item);
    public void EquipaArma(Arma arma)
    {
        this.arma = arma;
    }
        public void AdicionaItem(Item item){
        this.item = item;
    }
}