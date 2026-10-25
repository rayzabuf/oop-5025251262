
namespace Proyek;

public class Kasir
{
    private IDiskon diskon;

    public Kasir(IDiskon diskon)
    {
        if (diskon == null)
        {
            throw new ArgumentException("Diskon tidak boleh kosong.");
        }

        this.diskon = diskon;
    }

    public void CetakStruk(Pesanan pesanan)
    {
        if (pesanan == null)
        {
            throw new ArgumentException("Pesanan tidak boleh kosong.");
        }

        decimal subtotal = pesanan.HitungTotal();
        decimal potongan = diskon.HitungDiskon(subtotal);
        decimal totalBayar = subtotal - potongan;

        Console.WriteLine("\n===== STRUK KASIR KANTIN =====");

        for (int i = 0; i < pesanan.DaftarProduk.Count; i++)
        {
            Produk produk = pesanan.DaftarProduk[i];
            int jumlah = pesanan.DaftarJumlah[i];

            decimal harga = produk.HitungHarga(jumlah);

            Console.WriteLine(
                $"{produk.Nama} x{jumlah} = Rp{harga:N0}"
            );
        }

        Console.WriteLine("------------------------------");
        Console.WriteLine($"Subtotal    : Rp{subtotal:N0}");
        Console.WriteLine($"Diskon      : {diskon.NamaDiskon}");
        Console.WriteLine($"Potongan    : Rp{potongan:N0}");
        Console.WriteLine($"Total Bayar : Rp{totalBayar:N0}");
        Console.WriteLine("==============================");
    }


public void ProsesPembayaran(Pesanan pesanan, decimal jumlahBayar)
{
    if (pesanan == null)
    {
        throw new ArgumentException("Pesanan tidak boleh kosong.");
    }

    if (jumlahBayar < 0)
    {
        throw new PembayaranException(
            "Jumlah pembayaran tidak boleh negatif."
        );
    }

    decimal subtotal = pesanan.HitungTotal();
    decimal potongan = diskon.HitungDiskon(subtotal);
    decimal totalBayar = subtotal - potongan;

    if (jumlahBayar < totalBayar)
    {
        throw new PembayaranException(
            "Uang pembayaran kurang."
        );
    }

    CetakStruk(pesanan);

    Console.WriteLine($"Uang diterima : Rp{jumlahBayar:N0}");
    Console.WriteLine($"Kembalian     : Rp{jumlahBayar - totalBayar:N0}");
}

}
