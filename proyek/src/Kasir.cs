
namespace Proyek;

public class Kasir
{
    private readonly IDiskon diskon;

    public Kasir(IDiskon diskon)
    {
        this.diskon = diskon
            ?? throw new ArgumentException("Diskon tidak boleh kosong.");
    }

    public void ProsesPembayaran(Pesanan pesanan, decimal uangDiterima)
    {
        if (pesanan == null)
            throw new ArgumentException("Pesanan tidak boleh kosong.");

        decimal subtotal = pesanan.HitungSubtotal();
        decimal potongan = diskon.HitungPotongan(subtotal);
        decimal totalBayar = subtotal - potongan;

        if (uangDiterima < totalBayar)
            throw new PembayaranException("Uang pembayaran kurang.");

        Console.WriteLine();
        Console.WriteLine("===== STRUK KASIR KANTIN =====");

        foreach (var item in pesanan.DaftarProduk)
        {
            Console.WriteLine(
                $"{item.produk.Nama} x{item.jumlah} = " +
                $"Rp{item.produk.HitungHarga(item.jumlah):N0}");
        }

        Console.WriteLine("------------------------------");
        Console.WriteLine($"Subtotal : Rp{subtotal:N0}");
        Console.WriteLine($"Diskon : {diskon.NamaDiskon}");
        Console.WriteLine($"Potongan : Rp{potongan:N0}");
        Console.WriteLine($"Total Bayar : Rp{totalBayar:N0}");
        Console.WriteLine("==============================");
        Console.WriteLine($"Uang diterima : Rp{uangDiterima:N0}");
        Console.WriteLine($"Kembalian : Rp{uangDiterima - totalBayar:N0}");
    }
}
