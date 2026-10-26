# PROSES

Berkas ini menjadi bahan utama ujian lisan. Tulis dengan kata-kata sendiri.

## 1. Domain dan masalahnya

Saya membuat program Kasir Kantin untuk menghitung belanja, diskon, pembayaran, dan mengatur stok produk.

## 2. Rancangan kelas

Kelas apa saja, siapa mewarisi siapa, siapa memiliki siapa, dan mengapa dirancang begitu.

Saya menggunakan class Produk sebagai induk dari Makanan, Minuman, dan PaketHemat. Class Pesanan mengatur pesanan, sedangkan Kasir memproses pembayaran dan diskon.



## 3. Satu keputusan desain dan alasannya

Contoh: memilih interface atau abstract class untuk suatu hal, mengapa.

Saya menggunakan interface IDiskon supaya jenis diskon bisa diganti tanpa harus mengubah kode di class Kasir.

## 4. Bug atau kendala (minimal dua)

Untuk tiap kendala: apa yang terjadi, bagaimana menemukan penyebabnya, bagaimana memperbaikinya.

1.Sempat salah membuka folder proyek, lalu diperbaiki dengan memastikan lokasi folder yang benar.

2.Menambahkan exception agar pembayaran dengan uang kurang bisa ditangani tanpa menghentikan program.