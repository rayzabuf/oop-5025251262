
namespace Proyek;

public class Makanan : Produk
{
    public Makanan(string nama, decimal harga, int stok)
        : this(nama, harga, stok, "Makanan")
    {
    }

    public Makanan(
        string nama,
        decimal harga,
        int stok,
        string kategori
    ) : base(nama, harga, stok)
    {
        if (string.IsNullOrWhiteSpace(kategori))
            throw new ArgumentException("Kategori tidak boleh kosong.");

        Kategori = kategori;
    }

    public string Kategori { get; }

    public override decimal HitungHarga(int jumlah)
    {
        if (jumlah <= 0)
            throw new ArgumentException("Jumlah harus lebih dari nol.");

        return Harga * jumlah;
    }

    public override string ToString()
    {
        return $"{Nama} - Rp{Harga:N0} (Kategori: {Kategori}, Stok: {Stok})";
    }
}

