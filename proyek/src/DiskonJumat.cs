
namespace Proyek;

public class DiskonJumat : IDiskon
{
    public string NamaDiskon
    {
        get { return "Diskon Jumat"; }
    }

    public decimal HitungDiskon(decimal total)
    {
        return total * 0.05m;
    }
}
