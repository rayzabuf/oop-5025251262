
namespace Proyek;

public class Pesanan
{
    private readonly List<(Produk produk, int jumlah)> daftarProduk = new();

    public IReadOnlyList<(Produk produk, int jumlah)> DaftarProduk
    {
        get { return daftarProduk.AsReadOnly(); }
    }

    public void TambahProduk(Produk produk, int jumlah)
    {
        if (produk == null)
            throw new ArgumentException("Produk tidak boleh kosong.");

        if (jumlah <= 0)
            throw new ArgumentException("Jumlah harus lebih dari nol.");

        if (jumlah > produk.Stok)
            throw new StokHabisException(
                $"Stok {produk.Nama} tidak mencukupi.");

        produk.KurangiStok(jumlah);
        daftarProduk.Add((produk, jumlah));
    }

    public decimal HitungSubtotal()
    {
        decimal subtotal = 0;

        foreach (var item in daftarProduk)
        {
            subtotal += item.produk.HitungHarga(item.jumlah);
        }

        return subtotal;
    }

    public override string ToString()
    {
        return $"Pesanan berisi {daftarProduk.Count} jenis produk, " +
               $"subtotal Rp{HitungSubtotal():N0}";
    }
}
