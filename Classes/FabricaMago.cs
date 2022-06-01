class FabricaMago : FabricaEquipamentos
{

    public override Arma CriaArma()
    {
        return new Cajado();
    }

    public override Item CriaItem()
    {
        return new Item();
    }
}