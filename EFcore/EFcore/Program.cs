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
                Lession1 lession = new Lession1(context);
                lession.ShowProductOfStore();
            }
        }
    }
}
