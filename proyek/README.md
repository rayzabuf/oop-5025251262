# Proyek ETS PBO

> Baca `SOAL.md` dulu. Ganti semua `TULIS_DI_SINI` di berkas ini, `AI-LOG.md`, dan `PROSES.md`. Berkas yang masih berisi
> `TULIS_DI_SINI` dianggap belum diisi.

## Identitas

- Nama: Muhammad Rayza Buftiem
- NRP: 5025251262
- Domain (NRP dibagi 6, ambil sisanya): Kasir Kantin

## Domain saya

Jelaskan dengan kata-kata sendiri (2-3 kalimat): siapa penggunanya dan masalah apa yang diselesaikan aplikasi ini.

Karena NRP saya jika dibagi 6 bersisa 0 maka saya mendapatkan domain Aplikasi Kasir Kantin digunakan oleh kasir untuk mencatat pesanan makanan dan minuman pelanggan. Aplikasi ini membantu menghitung total harga, memberikan diskon, memproses pembayaran, dan menampilkan kembalian. Aplikasi juga menangani pesanan yang melebihi stok agar transaksi tidak diproses secara tidak semestinya.

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
        +Nama string
        +Harga decimal
        +Stok int
        +HitungHarga(int jumlah) decimal
        +KurangiStok(int jumlah) void
    }

    class Makanan {
        +HitungHarga(int jumlah) decimal
    }

    class Minuman {
        +HitungHarga(int jumlah) decimal
    }

    class PaketHemat {
        +HitungHarga(int jumlah) decimal
    }

    class Pesanan
    class IDiskon {
        <<interface>>
        +HitungDiskon(decimal total) decimal
    }

    class DiskonMahasiswa
    class DiskonJumat
    class Kasir
    class StokHabisException
    class PembayaranException
    class PenyimpananPesanan

    Produk <|-- Makanan
    Produk <|-- Minuman
    Produk <|-- PaketHemat
    IDiskon <|.. DiskonMahasiswa
    IDiskon <|.. DiskonJumat
    Pesanan --> Produk
    Kasir --> Pesanan
    Kasir --> IDiskon
    Produk ..> StokHabisException
    Kasir ..> PembayaranException
    Kasir --> PenyimpananPesanan
```

## Status kebutuhan

Isi kolom Status dengan `selesai`, `sebagian`, atau `belum`.

| ID | Kebutuhan | Status | Catatan |
|---|---|---|---|
| K1 | Enkapsulasi | sebagian | Field private dan properti |
| K2 | Komposisi dan pewarisan | sebagian | Ada kelas turunan produk |
| K3 | Polimorfisme |sebagian|Override HitungHarga()|
| K4 | Abstract class dan interface | sebagian | Ada Produk dan IDiskon |
| K5 | Exception dan life cycle | sebagian |Menangani error pembayaran dan stok|
| K6 | Aplikasi berjalan | selesai |Build dan demo berhasil|
| Khas | Aturan khas domain | sebagian | Harga, diskon, pembayaran, dan stok|
| Bonus | Bonus yang dikerjakan | belum |Belum ada bonus|

## Yang belum selesai

Masih perlu ngecek lagi apakah semua ketentuan di SOAL.md udah terpenuhi, merapikan beberapa bagian kode, melengkapi AI-LOG.md dan PROSES.md, serta memastikan commit tugas udah sesuai ketentuan.
