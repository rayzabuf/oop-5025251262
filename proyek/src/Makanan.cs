
namespace Proyek;

public class Makanan : Produk
{
    public Makanan(string nama, decimal harga, int stok)
        : this(nama, harga, stok, true)
    {
    }

    public Makanan(string nama, decimal harga, int stok, bool tersedia)
        : base(nama, harga, stok)
    {
        if (!tersedia)
        {
            throw new ArgumentException(
                "Makanan tidak tersedia untuk dijual."
            );
        }
    }

    public override decimal HitungHarga(int jumlah)
    {
        if (jumlah <= 0)
        {
            throw new ArgumentException(
                "Jumlah pembelian harus lebih dari nol."
            );
        }

        return Harga * jumlah;
    }
}
