
using System.Linq;
class DebitCard
{
    private string _pin;
    public string Pin
    {
        get { return _pin; }
        set {
            bool isOnlyDigits = !string.IsNullOrEmpty(value) && value.All(char.IsDigit);
            if ((value.Length == 4 || value.Length == 6) && isOnlyDigits)
                _pin = value;
            else
                System.Console.WriteLine("invalid");
        }
    }
}

class M
{
    static void Main()
    {
        DebitCard card = new DebitCard();
        card.Pin = "123f";
    }
}
