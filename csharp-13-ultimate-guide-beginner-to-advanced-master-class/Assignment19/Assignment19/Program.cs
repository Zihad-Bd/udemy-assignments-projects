


    internal class Program
    {
        static void Main(string[] args)
        {
            byte a = (byte)10; //Convert this value into "short" type (assign into another short type of variable)
            short aa = a;
            int b = 10; //Convert this value into "short" type (assign into another short type of variable)
            short bb = (short)b;
            string c = "10.34"; //Convert this value into "double" type using Parse  //Also, convert the same value into "decimal" type  using TryParse
            double cc = double.Parse(c);
            bool isSuccessfull = decimal.TryParse(c, out decimal ccc);
            decimal d = 20.3M; //Convert this value into "string" type (assign into another string type of variable)
        string dd = System.Convert.ToString(d);
        System.Console.WriteLine("aa: " + a + ", bb: " + bb + ", " + "cc: " + cc + ", ccc: " + ccc + ", dd: " + dd);
        }
    }

