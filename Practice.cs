
internal class Program
{
    public static void Main(string[] args)
    {
    }

    public static int Sum(int n)
    {
        if (n == 1)
        {
            return 1;
        }
        return n + Sum(n - 1);
    }
}