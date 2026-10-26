# Proyek ETS PBO

> Baca `SOAL.md` dulu. Ganti semua `TULIS_DI_SINI` di berkas ini, `AI-LOG.md`, dan `PROSES.md`. Berkas yang masih berisi
> `TULIS_DI_SINI` dianggap belum diisi.

## Identitas

- Nama: Muhammad Rayza Buftiem
- NRP: 5025251262
- Domain (NRP dibagi 6, ambil sisanya): Kasir Kantin

## Domain saya

Jelaskan dengan kata-kata sendiri (2-3 kalimat): siapa penggunanya dan masalah apa yang diselesaikan aplikasi ini.

Aplikasi Kasir Kantin digunakan untuk membantu pencatatan pesanan makanan dan minuman di kantin kampus. Aplikasi menghitung harga berdasarkan jenis produk, menerapkan diskon melalui kebijakan yang dapat diganti, menjaga stok produk, serta menampilkan struk pembayaran dan kembalian.

## Cara menjalankan

```bash
dotnet build proyek/src
dotnet run --project proyek/src
```

## Diagram kelas

Ganti contoh ini dengan diagram kelas proyek kalian (sintaks Mermaid, tampil otomatis di GitHub).

```
classDiagram
    class Produk {
        <<abstract>>
        -string nama
        -decimal harga
        -int stok
        +HitungHarga(int jumlah) decimal*
        +KurangiStok(int jumlah) void
        +ToString() string
    }

    class Makanan
    class Minuman
    class PaketHemat

    class Pesanan {
        -List~ItemPesanan~ daftarProduk
        +TambahProduk(Produk produk, int jumlah) void
        +HitungSubtotal() decimal
    }

    class IDiskon {
        <<interface>>
        +NamaDiskon string
        +HitungPotongan(decimal subtotal) decimal
    }

    class DiskonMahasiswa
    class DiskonJumat

    class Kasir {
        -IDiskon diskon
        +ProsesPembayaran(Pesanan pesanan, decimal uangDiterima) void
    }

    class StokHabisException
    class PembayaranException
    class PenyimpananPesanan {
        +Dispose() void
    }

    Produk <|-- Makanan
    Produk <|-- Minuman
    Produk <|-- PaketHemat
    IDiskon <|.. DiskonMahasiswa
    IDiskon <|.. DiskonJumat
    Kasir --> IDiskon : menggunakan
    Kasir --> Pesanan : memproses
    Pesanan o-- Produk : menyimpan item
    Produk ..> StokHabisException : melempar
    Kasir ..> PembayaranException : melempar
    PenyimpananPesanan ..|> IDisposable
```

## Status kebutuhan

Isi kolom Status dengan `selesai`, `sebagian`, atau `belum`.

| ID | Kebutuhan | Status | Catatan |
|---|---|---|---|
| K1 | Enkapsulasi | Sebagian | Validasi data |
| K2 | Komposisi dan pewarisan | Sebagian | Inheritance dan composition |
| K3 | Polimorfisme | Selesai |Override method|
| K4 | Abstract class dan interface | Selesai |Implementasi interface|
| K5 | Exception dan life cycle | Sebagian |Custom exception dan IDisposable|
| K6 | Aplikasi berjalan | Selesai |Build dan run berhasil|
| Khas | Aturan khas domain | Sebagian |Harga, diskon, dan stok|
| Bonus | Bonus yang dikerjakan | Belum |Belum dikerjakan|

## Yang belum selesai

Untuk saat ini, program Kasir Kantin sudah bisa dijalankan dan fitur utamanya sudah berjalan. Tapi, masih ada beberapa bagian yang perlu diperbaiki dan dicek lagi, terutama pengelolaan stok saat pembayaran gagal. README, AI-LOG, dan PROSES juga perlu dipastikan sudah terisi dengan benar. Selain itu, masih perlu mengecek lagi apakah semua ketentuan tugas sudah terpenuhi dan memastikan kode bisa dipahami untuk persiapan ujian lisan.
