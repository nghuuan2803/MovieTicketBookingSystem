using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTBS.Shared.Helper
{
    public class GenerateSeatLayout
    {
        public static string Generate(int soHang, int soCot, List<int> offset)
        {
            var boCuc = new int[soHang, soCot];

            // Lặp qua hàng và cột để tạo bố cục
            for (int i = 0; i < soHang; i++)
            {
                for (int j = 0; j < soCot; j++)
                {
                    if (i == soHang - 1) // Hàng cuối
                    {
                        boCuc[i, j] = 2; // Ghế đôi
                    }
                    else if (offset.Contains(j)) // Ghế trống (cột 3 và 14)
                    {
                        boCuc[i, j] = 0;
                    }
                    else
                    {
                        boCuc[i, j] = 1; // Ghế thường
                    }
                }
            }

            // Convert ma trận thành JSON
            string boCucJson = JsonConvert.SerializeObject(boCuc);
            return boCucJson;
        }
    }
}
