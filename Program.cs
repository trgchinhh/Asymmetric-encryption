public class Program {
    public static bool nhap_noidung(ref string noidung){
        Console.Write("\t(?) Nhập nội dung: ");
        string str_noidung = Console.ReadLine()!;
        if(string.IsNullOrEmpty(str_noidung)){
            Console.WriteLine("\t\t(!) Không để nội dung trống !");
            return false;
        }
        noidung = str_noidung;
        return true;
    }

    public static bool nhap_duongdan(ref string duongdan_vao, ref string duongdan_ra){
        Console.Write("\t(?) Đường dẫn file vào: ");
        duongdan_vao = Console.ReadLine()!;
        if(!File.Exists(duongdan_vao)){
            Console.WriteLine("\t(!) File {0} không tồn tại !", duongdan_vao);
            return false;
        }
        Console.Write("\t(?) Đường dẫn file ra: ");
        duongdan_ra = Console.ReadLine()!;
        if(File.Exists(duongdan_ra)){
            Console.WriteLine("\t(!) File {0} đã tồn tại !", duongdan_ra);
        }
        return true;
    }

    public static void dungchuongtrinh(){
        Console.Write("\nNhấn phím bất kỳ để tiếp tục...");
        Console.ReadKey();
    }

    public static void Main(){
        RSA rsa = new RSA();
        // cặp khóa 128 bit (pubkey: 64 - prikey: 64)
        rsa.sinhcapkhoa(128);

        // biến dùng chung 
        string noidung = "", banma = "", bangoc = "";
        string duongdan_vao = "", duongdan_ra = "";

        string banner = @"┌──────────────────────────────┐
│       Mã hóa ứng dụng        │
│ Mô phỏng mã hóa bất đối xứng │
│ Tác giả: Trường Chinh        │
│ Github: Github.com/trgchinhh │
└──────────────────────────────┘
";

        string menu = @"
[01] Nhập nội dung
[02] Mã hóa nội dung 
[03] Giải mã nội dung
[04] Mã hóa nội dung file
[05] Giải mã nội dung file  
[06] Xem cặp khóa
[07] Thoát  
        ";

        while(true){
            Console.Clear();
            Console.WriteLine(banner);
            Console.WriteLine(
                "[-] Nội dung: " + (string.IsNullOrEmpty(noidung) ? "Chưa có" : noidung)
            );
            Console.WriteLine(menu);
            Console.Write("[-] Lựa chọn: ");
            int luachon;
            int.TryParse(Console.ReadLine()!, out luachon);
            if(luachon == 1){
                Console.WriteLine("\n[Nhập nội dung]");
                if(nhap_noidung(ref noidung)){
                    Console.WriteLine("\t(*) Đã ghi nhận nội dung mới !");
                } 
                else {
                    Console.WriteLine("\t(!) Ghi nội dung mới chưa thành công !");
                }
            }
            else if(luachon == 2){
                Console.WriteLine("\n[Mã hóa]");
                if(!string.IsNullOrEmpty(noidung)){
                    banma = rsa.mahoa(noidung);
                    rsa.in_mahoa(banma);
                }
                else {
                    Console.WriteLine("\t(!) Chưa có nội dung vui lòng chọn [1] để nhập !");
                }
            }
            else if(luachon == 3){
                Console.WriteLine("\n[Giải mã]");
                if(!string.IsNullOrEmpty(banma)){
                    bangoc = rsa.giaima(banma);
                    rsa.in_giaima(bangoc);
                }
                else {
                    Console.WriteLine("\t(!) Chưa có nội dung bản mã vui lòng chọn [2] để mã hóa !");
                }
            }
            else if(luachon == 4){
                if(nhap_duongdan(ref duongdan_vao, ref duongdan_ra)){
                    rsa.mahoa_file(duongdan_vao, duongdan_ra);
                }
            }
            else if(luachon == 5){
                if(nhap_duongdan(ref duongdan_vao, ref duongdan_ra)){
                    rsa.giaima_file(duongdan_vao, duongdan_ra);
                }
            }
            else if(luachon == 6){
                Console.WriteLine("\n[Cặp khóa]");
                rsa.xemcapkhoa(20);
            } 
            else if(luachon == 7){
                Console.WriteLine("\n[Thoát]");
                break;
            }
            else {
                Console.WriteLine("\n\t(!) Vui lòng nhập lựa chọn hợp lệ !");
                continue;
            }
            dungchuongtrinh();
        }
    }
}