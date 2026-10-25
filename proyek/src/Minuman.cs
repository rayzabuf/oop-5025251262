
namespace Proyek;

public class Minuman : Produk
{
    public Minuman(string nama, decimal harga, int stok)
        : base(nama, harga, stok)
    {
    }

    public override decimal HitungHarga(int jumlah)
    {
        return Harga * jumlah;
    }
}
