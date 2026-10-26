
namespace Proyek;

public class DiskonMahasiswa : IDiskon
{
    public string NamaDiskon
    {
        get { return "Diskon Mahasiswa"; }
    }

    public decimal HitungPotongan(decimal subtotal)
    {
        if (subtotal < 0)
            throw new ArgumentException("Subtotal tidak boleh negatif.");

        return subtotal * 10 / 100;
    }
}
