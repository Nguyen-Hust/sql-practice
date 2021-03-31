using EFcore.BLL;
using System;
using System.Linq;

namespace EFcore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BikeStoreDbContext())
            {
                Lesson1 lesson = new Lesson1(context);
                //Sử dụng các hàm của lesson ứng với các bài
                /*Tất cả customers, sắp xếp theo thứ tự số lượng order họ mua từ cao đến thấp.*/
                lesson.ShowCustomers();
                /*Tất cả categories, và số lượng orders của từng category.*/
                lesson.ShowCategory();
                /*Danh sách products sắp xếp theo số lượng order từ cao đến thấp.*/
                lesson.ShowProduct();
                /*Danh sách cửa hàng, và các loại product đã được bán trong từng cửa hàng.*/
                lesson.ShowProductOfStore();
            }
        }
    }
}
