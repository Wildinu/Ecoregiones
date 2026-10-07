public static class GameManager
{
    public static bool llave1 = false; 
    public static bool llave2 = false; 

    public static bool TieneLasDosLlaves()
    {
        return llave1 && llave2;
    }

    
    public static void Reiniciar()
    {
        llave1 = false;
        llave2 = false;
    }
}
