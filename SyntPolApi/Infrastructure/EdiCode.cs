using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyntPolApi.Infrastructure
{
    public class EdiCode
    {
        public static String START = "UNH";
        public static String NUMER = "BGM+380+";
        public static String DATA_WYSTAWIENIA = "DTM+137:";
        public static String DATA_DOSTAWY = "DTM+35:";
        public static String NUMER_ZAMOWIENIA = "RFF+ON:";
        public static String DATA_ZAMOWIENIA = "DTM+171:";
        public static String NUMER_DOKUMENTU = "RFF+DQ:";
        public static String DOSTAWCA = "NAD+SU+4012345500004::9++";
        public static String DOSTAWCA_NIP = "RFF+VA:";
        public static String ODBIORCA = "NAD+BY+4012345500004::9++";
        public static String ADRES_DOSTAWY = "NAD+DP+4012345500004::9++";
        public static String STAWKA_PODATKU = "TAX+7+VAT+++:::";
        public static String LIN = "LIN+";
        public static String PIA = "PIA+1+";
        public static String ILOSC = "QTY+47:";
        public static String PRI = "PRI+AAA:";
        public static String MOA = "MOA+";
        public static String CNT = "CNT+2:";
        public static String MOA66 = "MOA+66:";
        public static String MOA77 = "MOA+77:";
        public static String MOA79 = "MOA+79:";
        public static String MOA124 = "MOA+124:";
        public static String MOA125 = "MOA+125:";

        public String imie;
    }
}
