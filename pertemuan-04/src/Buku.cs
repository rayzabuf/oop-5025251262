// File ini berisi TODO -- lihat SOAL.md untuk kontrak lengkap tiap level.
// Bagian bertanda TODO(Level N) adalah tugas kalian; kode lain sudah
// disediakan. Jangan mengubah nama/tipe yang sudah ada kecuali TODO
// memintanya secara eksplisit.

namespace Pertemuan04;

public class Buku
{
    // TODO(Level 1): field PUBLIK di bawah ini melanggar enkapsulasi (siapa pun
    //   bisa mengubahnya sembarangan). Jadikan field PRIVATE (awali nama dengan
    //   _) lalu ekspos lewat properti read-only: public get, tanpa setter
    //   publik. Nama properti tetap Isbn, Judul, StokTotal, StokTersedia.
    private string _isbn = "";
    private string _judul = "";
    private int _stokTotal;
    private int _stokTersedia;

    public string Isbn => _isbn;
    public string Judul => _judul;
    public int StokTotal => _stokTotal;
    public int StokTersedia => _stokTersedia;

    // TODO(Level 8): properti di bawah ini menerima nilai apa saja. Beri nilai
    //   awal 7 dan tambahkan logika validasi di accessor set (perlu field
    //   pendukung): nilai harus 1..30, di luar itu lempar
    //   ArgumentOutOfRangeException dan JANGAN mengubah nilai lama.
    private int _batasHariPinjam = 7;

    public int BatasHariPinjam
    {
        get => _batasHariPinjam;
        set
        {
            if (value < 1 || value > 30)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Batas hari pinjam harus berada di antara 1 dan 30.");
            }
            _batasHariPinjam = value;
        }
    }

    // TODO(Level 2): validasi di AWAL konstruktor -- judul null/kosong/spasi
    //   saja atau stokTotal negatif -> lempar ArgumentException
    //   (ArgumentOutOfRangeException juga boleh); jangan ada state yang berubah
    //   kalau ditolak.
    // TODO(Level 6): validasi & normalisasi ISBN -- buang tanda '-' dan spasi;
    //   hasilnya harus tepat 13 digit angka dengan digit cek ISBN-13 yang benar;
    //   kalau tidak, lempar ArgumentException. Isbn menyimpan versi TANPA '-'.
    public Buku(string isbn, string judul, int stokTotal)
    {
        if (string.IsNullOrWhiteSpace(judul))
        {
            throw new ArgumentException("Judul tidak boleh kosong atau hanya spasi.", nameof(judul));
        }

        if (stokTotal < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(stokTotal), "Stok total tidak boleh negatif.");
        }

        if (isbn == null)
        {
            throw new ArgumentNullException(nameof(isbn), "ISBN tidak boleh null.");
        }

        string cleanIsbn = isbn.Replace("-", "").Replace(" ", "");
        if (cleanIsbn.Length != 13 || !cleanIsbn.All(char.IsDigit))
        {
            throw new ArgumentException("ISBN harus berupa 13 digit angka.", nameof(isbn));
        }

        int sum = 0;
        for (int i = 0; i < 13; i++)
        {
            int digit = cleanIsbn[i] - '0';
            int weight = (i % 2 == 0) ? 1 : 3;
            sum += digit * weight;
        }

        if (sum % 10 != 0)
        {
            throw new ArgumentException("Digit cek ISBN tidak valid.", nameof(isbn));
        }

        // TODO(Level 1): isi Isbn, Judul, StokTotal dari parameter; StokTersedia
        //   awal = stokTotal.
        _isbn = cleanIsbn;
        _judul = judul;
        _stokTotal = stokTotal;
        _stokTersedia = stokTotal;
    }

    public void Pinjam()
    {
        // TODO(Level 3): kurangi StokTersedia satu. Kalau stok sudah 0, lempar
        //   InvalidOperationException dan biarkan stok tetap.
        if (_stokTersedia <= 0)
        {
            throw new InvalidOperationException("Stok buku tidak tersedia untuk dipinjam.");
        }
        _stokTersedia--;
    }

    public void Kembalikan()
    {
        // TODO(Level 4): tambah StokTersedia satu. Kalau stok sudah sama dengan
        //   StokTotal (tidak ada yang sedang dipinjam), lempar
        //   InvalidOperationException dan biarkan stok tetap.
        if (_stokTersedia >= _stokTotal)
        {
            throw new InvalidOperationException("Semua eksemplar buku sudah ada di perpustakaan.");
        }
        _stokTersedia++;
    }

    // Level 5: properti TERHITUNG -- tanpa field pendukung, tanpa setter.
    public double PersentaseTersedia
    {
        get
        {
            // TODO(Level 5): kembalikan StokTersedia / StokTotal * 100 (double).
            //   Kalau StokTotal = 0 kembalikan 0 (bukan NaN).
            if (_stokTotal == 0)
            {
                return 0.0;
            }
            return (double)_stokTersedia / _stokTotal * 100.0;
        }
    }

    public string Status
    {
        get
        {
            // TODO(Level 5): kembalikan "Tersedia" kalau StokTersedia > 0,
            //   selain itu "Habis".
            return _stokTersedia > 0 ? "Tersedia" : "Habis";
        }
    }

}
