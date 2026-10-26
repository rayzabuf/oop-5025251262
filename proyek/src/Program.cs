// Titik masuk aplikasi. Ganti isi berkas ini dengan demo (menu atau skenario berurutan)
// yang memperlihatkan semua aturan khas domain kalian, termasuk skenario gagal yang
// ditangani exception. Kelas-kelas domain ditulis di berkas terpisah.


using Proyek;

Console.WriteLine("=== DEMO KASIR KANTIN ===");

using (PenyimpananPesanan penyimpanan = new PenyimpananPesanan())
{
    Makanan nasiGoreng = new Makanan("Nasi Goreng", 15000, 5);
    Minuman esTeh = new Minuman("Es Teh", 5000, 10, true, 1000);
    PaketHemat paket = new PaketHemat("Paket Hemat", 20000, 3, 15);

    Pesanan pesanan = new Pesanan();

    pesanan.TambahProduk(nasiGoreng, 1);
    pesanan.TambahProduk(esTeh, 2);
    pesanan.TambahProduk(paket, 1);

    Kasir kasir = new Kasir(new DiskonMahasiswa());

    Console.WriteLine("\nPembayaran dengan uang kurang:");

    try
    {
        kasir.ProsesPembayaran(pesanan, 10000);
    }
    catch (PembayaranException ex)
    {
        Console.WriteLine($"Pembayaran gagal: {ex.Message}");
    }
    finally
    {
        Console.WriteLine("Percobaan pembayaran selesai.");
    }

    Console.WriteLine("\nPembayaran dengan uang cukup:");

    try
    {
        kasir.ProsesPembayaran(pesanan, 50000);
    }
    catch (PembayaranException ex)
    {
        Console.WriteLine($"Pembayaran gagal: {ex.Message}");
    }

    Console.WriteLine("\nPercobaan memesan stok berlebihan:");

    try
    {
        pesanan.TambahProduk(nasiGoreng, 100);
    }
    catch (StokHabisException ex)
    {
        Console.WriteLine($"Pesanan gagal: {ex.Message}");
    }
}

Console.WriteLine("\nDemo selesai.");
