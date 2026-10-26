
namespace Proyek;

public class DiskonJumat : IDiskon
{
    public string NamaDiskon
    {
        get { return "Diskon Jumat"; }
    }

    public decimal HitungPotongan(decimal subtotal)
    {
        if (subtotal < 0)
            throw new ArgumentException("Subtotal tidak boleh negatif.");

        return subtotal * 5 / 100;
    }
}
