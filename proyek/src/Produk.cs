
namespace Proyek;

public abstract class Produk
{
    private string nama;
    private decimal harga;
    private int stok;

    public string Nama
    {
        get { return nama; }
    }

    public decimal Harga
    {
        get { return harga; }
    }

    public int Stok
{
    get { return stok; }
    private set
    {
        if (value < 0)
            throw new ArgumentException("Stok tidak boleh negatif.");

        stok = value;
    }
}

    protected Produk(string nama, decimal harga, int stok)
    {
        this.nama = nama;
        this.harga = harga;
        this.stok = stok;
    }

    public abstract decimal HitungHarga(int jumlah);

public void KurangiStok(int jumlah)
{
    if (jumlah <= 0)
        throw new ArgumentException(
            "Jumlah pembelian harus lebih dari nol."
        );

    if (jumlah > stok)
        throw new StokHabisException(
            $"Stok {Nama} tidak mencukupi."
        );

    Stok = stok - jumlah;
}
}
