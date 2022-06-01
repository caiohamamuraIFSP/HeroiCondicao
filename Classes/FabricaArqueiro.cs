public class FabricaArqueiro:FabricaEquipamentos{
    public override Arma CriaArma(){
        return new Arco();
    }

    public override Item CriaItem(){
        return new Item();
    }
    
}