using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresDefteri
{
    class Adres
    { 
        public string AdSoyad;
        public string Telefon;
        public string Eposta;
    }

    /*Aşağıdaki liste static olarak işaretlenmeseydi
     new Ortak().tumAdresler; ->static olmazsa
     Bütün formlardan aynı listeye ulaşamazdık.

    Ortak.tumAdresler;  -> static olursa

    //Listemizi static işaretleyerek bütün uygulamada tek bir listenin kullanılmasını garanti etmiş olduk.
         */
    class Ortak
    {
        public static List<Adres> tumAdresler;
    }
}
