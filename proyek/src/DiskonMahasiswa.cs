
namespace Proyek;

public class DiskonMahasiswa : IDiskon
{
    public string NamaDiskon
    {
        get { return "Diskon Mahasiswa"; }
    }

    public decimal HitungDiskon(decimal total)
    {
        return total * 0.10m;
    }
}
