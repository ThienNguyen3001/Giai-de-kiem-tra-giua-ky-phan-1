using System;

namespace ConsoleApplication1
{
    class Program
    {
        static int UCLN(int a, int b)
        {
            /*
                Tìm UCLN quá kinh điển rồi nên mình không nói lại nữa
            */
            while (a != b)
            {
                if (a > b)
                    a -= b;
                else
                    b -= a;
            }
            return a;
        }
        static void PI_0()
        {
            int a, b;
            Console.WriteLine("Nhap so tu nhien a: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap so tu nhien b: ");
            b = int.Parse(Console.ReadLine());

            //Ở đây chỉ biện luận trường hợp đặc biệt (có số 0)
            if (a == 0)
            {
                if (b == 0)
                {
                    Console.WriteLine("Khong ton tai UCLN, BCNN");
                    //Hàm return; dùng để thoát hàm void
                    return;
                }
                else
                {
                    Console.WriteLine("UCLN la: " + b);
                    Console.WriteLine("Khong ton tai BCNN");
                    return;
                }
            }
            else
            {
                if (b == 0)
                {
                    Console.WriteLine("UCLN la: " + a);
                    Console.WriteLine("Khong ton tai BCNN");
                    return;
                }
            }
            //Khi không còn trường hợp bằng 0 nữa thì tính bth

            int ucln = UCLN(a, b);
            int bcnn = a * b / ucln; //Công thức : BCNN = (a*b)/UCLN(a,b). Ai làm bt đày đủ sẽ biết
            Console.WriteLine("UCLN : " + ucln);
            Console.WriteLine("BCNN : " + bcnn);

        }
        static void PI_1()
        {
            string s;
            Console.WriteLine("Nhap chuoi: ");
            s = Console.ReadLine();
            Console.WriteLine("Tong cac ky so trong s la: " + TongKySo(s));

        }
        static int TongKySo(string s)
        {
            s = '!' + s;// Tạo rào cho đầu chuỗi để xử lý trường hợp dấu âm đầu

            int tong = 0;
            int so = 0;

            /*
                Code đã bao gồm phần sử lý số âm (Th đặc biệt)
             */
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] >= '0' && s[i] <= '9')// Kiểm tra xem có phải là số không
                {
                    if (s[i - 1] == '-')
                    {
                        so = int.Parse(s[i].ToString());// Chuyển ký tự số thành số nguyên
                        so *= -1;
                        tong += so;
                    }
                    else
                    {
                        so = int.Parse(s[i].ToString());
                        so *= 1;// Ko cần thiết ghi
                        tong += so;
                    }
                    so = 0;
                }
            }
            return tong;
        }
        static void PI_2()
        {
            Random random = new Random();//Nhập random dữ liệu

            int n = random.Next(1, 15);
            Console.WriteLine("n = " + n);
            int[] a = new int[n];

            int tong = 0;
            for (int i = 0; i < n; i++)
            {
                a[i] = random.Next(1, 100);

                // Kiểm tra luôn cho tiết kiệm vòng lặp
                if ((a[i] % 2 != 0) && (a[i] >= 50 && a[i] <= 100))// Xét điều kiện
                {
                    tong += DaoNguoc(a[i]);
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Tong dao nguoc cac so le (50-100) la: " + tong);

        }
        static int DaoNguoc(int n)
        {
            /*
    TH1: n = 123
    Lần lặp 1 : 
        soNguoc = (123 % 10) + 0*10 = 3
        n = 123 / 10 = 12
    Lần lặp 2 : 
        soNguoc = (12 % 10) + 3*10 = 32
        n = 12 / 10 = 1
    Lần lặp 3 : 
        soNguoc = (1 % 10) + 32*10 = 321
        n = 1 / 10 = 0 ==> KT vòng lặp


    TH2: n = 50 (Biết thêm chứ chắn chắn sẽ ko đụng TH này vì chỉ tính số lẻ)
    Lần lặp 1 : 
        soNguoc = (50 % 10) + 0*10 = 0
        n = 50 / 10 = 5
    Lần lặp 2 : 
        soNguoc = (5 % 10) + 0*10 = 5
        n = 5 / 10 = 0 ==> KT vòng lặp

    TH3: n = 5 (Cái này chỉ cần xài if đẻ biện luận)


       Còn có cách khác là cho nhập chuỗi rồi dùng int.Parse(s[i].ToString()) để chuyển thành số nguyên
            ==> Cách tổng quát hóa dùng để giải những số siêu lớn mà kiểu dữ liệu không đáp ứng nỗi
 */
            int soNguoc = 0;
            while (n > 0)
            {
                soNguoc = n % 10 + soNguoc * 10;
                n /= 10;
            }
            return soNguoc;
        }
        static void Main(string[] args)
        {
            //PI_0();
            //PI_1();
            PI_2();

            Console.ReadKey();

        }
    }
}