using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreCrud.Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductUpdated = "Ürün güncellendi.";
        public static string ProductDeleted = "Ürün silindi.";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductsListedById = "Ürünler listelendi";
        public static string ProductActived = "Ürün aktif edildi.";
        public static string ProductSuspended = "Ürün pasif hale getirildi.";
        public static string ProductNameInvalid = "Ürün ismi geçersizdir."; //for ex
        public static string ProductAddError = "Ürün eklenirken bir hata meydana geldi";

        public static string ProductPhotosAdded = "Ürün resmi(leri) eklendi.";
    }
}
