
namespace Proyek;

public class PaketHemat : Produk
{
    private decimal diskon;

    public decimal Diskon
    {
        get { return diskon; }
    }

    public PaketHemat(
        string nama,
        decimal harga,
        int stok,
        decimal diskon
    ) : base(nama, harga, stok)
    {
        if (diskon < 0 || diskon > 100)
            throw new ArgumentException(
                "Diskon harus antara 0 sampai 100 persen.");

        this.diskon = diskon;
    }

    public override decimal HitungHarga(int jumlah)
    {
        if (jumlah <= 0)
            throw new ArgumentException("Jumlah harus lebih dari nol.");

        decimal hargaDiskon = Harga * (1 - diskon / 100);

        return hargaDiskon * jumlah;
    }

    public override string ToString()
    {
        return $"{Nama} - Rp{Harga:N0} (Diskon: {Diskon}%, Stok: {Stok})";
    }
}
