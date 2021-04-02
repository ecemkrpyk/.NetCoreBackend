using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    //temel mesajlar 
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime="sistem bakımda";
        public static string ProductsListed="ürünler listelendi";
        public static string ProductOfCategoryCountError="bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExists= "böyle ismi başka bir ürün var ";
        public static string CategoryLımıtExceded="kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string AuthorizationDenied="yetkiniz yok";
        public static string Registered="kayıt oldu";
        public static string UserNotFound="kullanıcı bulunamadı";
        public static string PasswordError="parola hatası";
        public static string SuccessLogin="başarılı giriş";
        public static string UserAvailable="kullanıcı mevcut";
        public static string TokenCreated="token oluşturuldu";
    }
}
