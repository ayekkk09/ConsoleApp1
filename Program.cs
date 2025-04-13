using System;


//Parent Class Karyawan
public class Karyawan
{
    // Menggunakan private agar tidak dapat sembarangan diakses di luar kelas
    private string nama; 
    //Nama karyawan
    private string id;
    //ID Karyawan
    private double gajiPokok;
    //Gaji Pokok karyawan

    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.nama = nama;
        this.id = id;
        this.gajiPokok = gajiPokok;
    }

    //Getter dan Setter
    public string Nama
    {
        //set digunakan untuk mengubah nilai sedangkan get untuk mengambil nilai
        get { return nama; }
        set { nama = value; }
    }

    public string ID
    {
        get { return id; }
        set { id = value; }
    }

    public double GajiPokok
    {
        get { return gajiPokok; }
        set { gajiPokok = value; }
    }

    
    //dibuat virtual agar dapat dioverride oleh class turunannya
    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

//class KaryawanTetap turunan dari class Karyawan
public class KaryawanTetap : Karyawan
{

    private const double BonusTetap = 500000;

    public KaryawanTetap(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    //mengoverride method HitungGaji dan menambahkan bonus tetap
    public override double HitungGaji()
    {
        return GajiPokok + BonusTetap;
    }
}

//class KaryawanKontrak turunan dari class Karyawan
public class KaryawanKontrak : Karyawan
{
    private const double PotonganKontrak = 200000;

    public KaryawanKontrak(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    //mengoverride method HitungGaji dan menguranginya dengan potongan kontrak
    public override double HitungGaji()
    {
        return GajiPokok - PotonganKontrak;
    }
}

//class KaryawanMagang turunan dari class Karyawan
public class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    //mengoverride method HitungGaji dan tetap sama dengan parent classnya
    public override double HitungGaji()
    {
        return GajiPokok;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Sistem Manajemen Karyawan ===");

        //meminta inputan dari user tentang jenis karyawannya
        Console.Write("Masukkan jenis karyawan (tetap/kontrak/magang): ");
        string jenis = Console.ReadLine()?.ToLower(); 
        //menggunakan ToLower agar saat input huruf besar atau kecil dibacanya sama

        Console.Write("Masukkan nama: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan ID: ");
        string id = Console.ReadLine();

        Console.Write("Masukkan gaji pokok: ");
        double gajiPokok;
        while (!double.TryParse(Console.ReadLine(), out gajiPokok))
        //menggunakan while agar saat inputan salah akan diulang sampai benar dan mencegah terjadinya error
        {
            Console.Write("Input tidak valid. Masukkan angka untuk gaji pokok: ");
        }

        Karyawan karyawan;

        //switchcase digunakan saat user memilih jenis karyawan yang diinput
        switch (jenis)
        {
            case "tetap":
                karyawan = new KaryawanTetap(nama, id, gajiPokok);
                break;
            case "kontrak":
                karyawan = new KaryawanKontrak(nama, id, gajiPokok);
                break;
            case "magang":
                karyawan = new KaryawanMagang(nama, id, gajiPokok);
                break;
            default:
                Console.WriteLine("Jenis karyawan tidak dikenali.");
                return;
        }

        double gajiAkhir = karyawan.HitungGaji();
        Console.WriteLine($"\nGaji akhir untuk {karyawan.Nama} (ID: {karyawan.ID}) adalah: Rp{gajiAkhir:N0}");
        //menampilkan nama karyawan, id karyawan, serta gaji akhir karyawan
    }
}
