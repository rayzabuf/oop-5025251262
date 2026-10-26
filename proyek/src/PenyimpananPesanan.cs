
namespace Proyek;

public class PenyimpananPesanan : IDisposable
{
    private bool sudahDitutup;

    public PenyimpananPesanan()
    {
        Console.WriteLine("Penyimpanan pesanan siap digunakan.");
    }

    public void Dispose()
    {
        if (!sudahDitutup)
        {
            sudahDitutup = true;
            Console.WriteLine("Sumber daya pesanan selesai digunakan.");
        }
    }
}
