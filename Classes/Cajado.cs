using System;

public class Cajado : Arma{
    public Cajado(){
        this.forca = DefineForca();
    }

    protected override int DefineForca(){
        Random rnd = new Random();
        var forca = rnd.Next(10,14);
        return forca;
    }
}