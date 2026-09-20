public class Mau {
    public const ConsoleColor maudo = ConsoleColor.Red;
    public const ConsoleColor mauxanh = ConsoleColor.Green;
    public const ConsoleColor mauvang = ConsoleColor.Yellow;
    public const ConsoleColor mauvangdam = ConsoleColor.DarkYellow;

    public static void tomau(string noidung, ConsoleColor mau, bool xuongdong = false){
        Console.ForegroundColor = mau;
        if(xuongdong) Console.WriteLine(noidung);
        else Console.Write(noidung);
        Console.ResetColor();
    }
}