
namespace Proyek;

public class Minuman : Produk
{
    private bool pakaiEs;
    private decimal biayaEs;

    public bool PakaiEs
    {
        get { return pakaiEs; }
    }

    public Minuman(
        string nama,
        decimal harga,
        int stok,
        bool pakaiEs,
        decimal biayaEs
    ) : base(nama, harga, stok)
    {
        if (biayaEs < 0)
            throw new ArgumentException("Biaya es tidak boleh negatif.");

        this.pakaiEs = pakaiEs;
        this.biayaEs = biayaEs;
    }

    public override decimal HitungHarga(int jumlah)
    {
        if (jumlah <= 0)
            throw new ArgumentException("Jumlah harus lebih dari nol.");

        decimal hargaSatuan = Harga;

        if (pakaiEs)
            hargaSatuan += biayaEs;

        return hargaSatuan * jumlah;
    }

    public override string ToString()
    {
        return $"{Nama} - Rp{Harga:N0} (Stok: {Stok}, Pakai es: {PakaiEs})";
    }
}
