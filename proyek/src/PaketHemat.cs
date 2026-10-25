
namespace Proyek;

public class PaketHemat : Produk
{
    private decimal diskonPaket;

    public PaketHemat(
        string nama,
        decimal harga,
        int stok,
        decimal diskonPaket
    ) : base(nama, harga, stok)
    {
        if (diskonPaket < 0 || diskonPaket > harga)
        {
            throw new ArgumentException(
                "Diskon paket harus antara nol dan harga produk."
            );
        }

        this.diskonPaket = diskonPaket;
    }

    public override decimal HitungHarga(int jumlah)
    {
        if (jumlah <= 0)
        {
            throw new ArgumentException(
                "Jumlah pembelian harus lebih dari nol."
            );
        }

        return (Harga - diskonPaket) * jumlah;
    }

    public override string ToString()
    {
        return $"{Nama} - Paket hemat Rp{Harga - diskonPaket:N0}";
    }
}
