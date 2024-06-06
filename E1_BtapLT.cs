// See https://aka.ms/new-console-template for more information
using System;

namespace TuyenSinhDaiHoc
{
    // Định nghĩa ngoại lệ tùy chỉnh
    public class AgeOutOfRangeException : Exception
    {
        public AgeOutOfRangeException() : base("Do tuoi khong hop le de nhap hoc dai hoc.")
        {
        }

        public AgeOutOfRangeException(string message) : base(message)
        {
        }

        public AgeOutOfRangeException(string message, Exception inner) : base(message, inner)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Nhap tuoi cua sinh vien: ");
                int tuoi = int.Parse(Console.ReadLine());

                KiemTraTuoiNhapHoc(tuoi);

                Console.WriteLine("Sinh vien du dieu kien nhap hoc.");
            }
            catch (AgeOutOfRangeException ex)
            {
                Console.WriteLine($"Loi nhap hoc: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Du lieu nhap khong hop le. Vui long nhap mot so nguyen cho tuoi.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Da xay ra loi khong mong muon: {ex.Message}");
            }
        }

        static void KiemTraTuoiNhapHoc(int tuoi)
        {
            if (tuoi < 18 || tuoi > 25)
            {
                throw new AgeOutOfRangeException();
            }
        }
    }
}
