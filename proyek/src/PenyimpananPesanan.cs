
namespace Proyek;

public class PenyimpananPesanan : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Sumber daya pesanan selesai digunakan.");
    }
}
