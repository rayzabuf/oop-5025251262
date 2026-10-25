
namespace Proyek;

public class Pesanan
{
    private readonly List<Produk> daftarProduk = new();
    private readonly List<int> daftarJumlah = new();

    public IReadOnlyList<Produk> DaftarProduk
    {
        get { return daftarProduk.AsReadOnly(); }
    }

    public IReadOnlyList<int> DaftarJumlah
    {
        get { return daftarJumlah.AsReadOnly(); }
    }


public void TambahProduk(Produk produk, int jumlah)
{
    if (produk == null)
    {
        throw new ArgumentException("Produk tidak boleh kosong.");
    }

    if (jumlah <= 0)
    {
        throw new ArgumentException(
            "Jumlah pembelian harus lebih dari nol."
        );
    }

    produk.KurangiStok(jumlah);

    daftarProduk.Add(produk);
    daftarJumlah.Add(jumlah);
}


    public decimal HitungTotal()
    {
        decimal total = 0;

        for (int i = 0; i < daftarProduk.Count; i++)
        {
            total += daftarProduk[i].HitungHarga(daftarJumlah[i]);
        }

        return total;
    }
}
