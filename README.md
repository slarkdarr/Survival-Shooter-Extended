# IF3210-2022-Unity-27

Survival Shooter: Extended

## Deskripsi Aplikasi

Survival Shooter: Extended merupakan permainan ekstensi Survival Shooter dari Unity Learn di mana terdapat beberapa fitur tambahan pada permainan ini, misalnya *orbs*, *weapon upgrade*, dan *additional mobs*. Survival Shooter sendiri adalah sebuah permainan 3D sederhana di mana pemain harus berusaha bertahan dari serangan boneka-boneka zombie dengan cara menembaknya.

## Cara Kerja Aplikasi

- Saat aplikasi dijalankan, pemain akan diarahkan ke Main Menu. Di Main Menu, terdapat empat buah opsi, yaitu:
    - "Play" -> Opsi ini akan memulai permainan dengan mode *default* adalah **Zen/Endless Mode**
    - "Settings" -> Opsi ini akan membuka *settings* dari permainan. Di *settings*, pemain dapat menentukan nama pemain dan memilih *Game Mode*
    - "Board" -> Opsi ini akan membuka **Local Scoreboard** dari permainan. **Local Scoreboard** ini sendiri terbagi menjadi dua, yaitu *scoreboard* untuk **Zen/Endless Mode** dan **Wave Mode**:
        - **Local Scoreboard Zen/Endless Mode** -> Menampilkan nama pemain, dan waktu *survival*
        - **Local Scoreboard Wave Mode** -> Menampilkan nama pemain, *wave* terjauh dan skor total yang didapat dalam satu kali bermain
    - "Quit" -> Opsi ini akan menutup permainan

- Setelah pemain menentukan nama pemain dan memilih **Game Mode** (jika diinginkan) melalui opsi **Settings**, pemain dapat memulai permainan dengan menekan opsi **Play**

- Pemain memiliki beberapa atribut dengan spesifikasi sebagai berikut:
    - Terdapat tiga atribut yang ada, yakni:
        - ⚔️ Power -> Menyatakan kekuatan shoot pemain
        - ⚡ Speed -> Menyatakan kecepatan pemain dalam bergerak
        - ❤️ Health -> Menyatakan jumlah nyawa pemain
    - Setiap atribut ditampilkan pada layar
    - Setiap atribut memiliki nilai awal dan batas maksimal tertentu

- Jika pemain memulai permainan dengan mode **Zen/Endless Mode**:
    - Mobs akan ter-*spawn* secara *random* di *map* setiap beberapa detik sekali. Mobs yang ada meliputi Zombunny, Zombear, Hellephant, Skeleton, Bomber, dan Boss
    - Orbs juga akan ter-*spawn* secara *random* di *map* setiap beberapa detik sekali
    - Setiap 15 detik sekali, pemain dapat memilih sebuah *weapon upgrade*
    - Skor akhir permainan dihitung berdasarkan waktu *survival* pemain

- Jika pemain memulai permainan dengan mode **Wave Mode**:
    - Setiap *wave* akan memiliki kapasitas bobot (*weight*) untuk musuh yang di-*spawn*
    - Setiap *wave* memiliki *pool* musuh yang mungkin keluar
    - Musuh semakin sulit untuk tiap *wave*, dalam kata lain tiap *wave* memiliki kapasitas bobot yang meningkat
    - Setiap *wave* dengan nomor kelipatan 3, akan memiliki sebuah *boss mob* sebagai lawan dan beberapa *mobs* lain. *Boss mob* ini tidak memiliki bobot
    - Setiap menyelesaikan *wave boss*, pemain dapat memilih sebuah *weapon upgrade*
    - Batas jumlah maksimal *wave* adalah 9
    - Mobs biasa seperti Zombunny, Zombear, dan Hellephant akan muncul sejak *wave* pertama
    - Mobs lainnya, yaitu Skeleton akan muncul sejak *wave* 4 dan Bomber akan muncul sejak *wave* 7
    - Pada setiap *wave*, setiap musuh yang dibunuh memberikan skor yang telah ditentukan

- Permainan akan selesai ketika jumlah nyawa pemain 0

- Saat permainan selesai, akan tampil layar **Game Over** yang menampilkan performa hasil permainan bergantung *Game Mode*:
    - **Zen/Endless Mode** -> Menampilkan waktu *survival* permainan
    - **Wave Mode** -> Menampilkan *wave* dan skor yang didapat

### Keterangan
*Orbs* yang ada dalam permainan meliputi:
- 🟢 Power Orb -> Meningkatkan kekuatan shoot pemain
- 🟡 Speed Orb -> Meningkatkan kecepatan pemain dalam bergerak
- 🔴 Health Orb -> Meningkatkan jumlah nyawa pemain  

*Weapon upgrade* yang ada dalam permainan meliputi:
- Diagonal Weapon -> Menambahkan 2 bullet ke arah diagonal kiri dan kanan
- Faster Weapon -> Meningkatkan kecepatan tembak senjata
- Longer Range Weapon -> Meningkatkan jarak tembak senjata

## Library

- UnityEngine -> Untuk melakukan import terhadap kelas-kelas di dalam Unity yang telah diimplementasi
- UnityEngine.UI -> Untuk mendapatkan atribut dari setiap UI component di Unity
- UnityEngine.SceneManagement -> Melakukan manajemen scene pada saat run-time
- System.Collections -> Memberikan struktur data tambahan yang kompatibel dengan Unity
- System.Collections.Generic -> Memberikan struktur data generik tambahan yang kompatibel dengan Unity
- System.Linq -> Melakukan query terhadap data source
- TMPro -> Mendapatkan atribut dari TextMeshPro yang menggunakan teknik Advanced Text Rendering

## Screenshot

Add here

## Pembagian Kerja

13519107 - Daffa Ananda Pratama R:
Implementasi Power Attribute, Additional Mobs, Weapon Upgrade, dan README  

13519141 - Naufal Yahya Kurnianto:
Implementasi Speed Attribute, Orbs, Local Scoreboard, Main Menu, Game Over  

13519201 - M Rayhan Ravianda:
Implementasi Health Attribute dan Game Mode
