using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntPolApi.Infrastructure
{
    public class EdiParser
    {
        public String Save
                           (String invoiceId, String issueDate, String deliveryDate, String supplierName,
                           String deliveryStreet, String supplierZipCode, String supplierCity, String supplierNIP,
                           String customerName, String customerStreet, String customerZipCode, String customerCity,
                           String customerNIP, String VATrate, String lp, String produkt,
                           String ilosc, String CNetto, String WNetto, String WBrutto)

        {
            issueDate = issueDate.Replace("-", "");
            deliveryDate = deliveryDate.Replace("-", "");
            StringBuilder invoiceInEDIFormat = new StringBuilder();
            invoiceInEDIFormat.AppendLine("UNH+1+INVOIC:D:96A:UN:EAN008\'");
            invoiceInEDIFormat.AppendLine("BGM+380+" + invoiceId + "+9\'");
            invoiceInEDIFormat.AppendLine("DTM+137:" + issueDate + ":102\'");
            invoiceInEDIFormat.AppendLine("DTM+35:" + deliveryDate + ":102\'");
            invoiceInEDIFormat.AppendLine("RFF+ON:\'");
            invoiceInEDIFormat.AppendLine("DTM+171:" + issueDate + ":102\'");
            invoiceInEDIFormat.AppendLine("RFF+DQ:" + invoiceId + "\'");
            invoiceInEDIFormat.AppendLine("NAD+SU+4012345500004::9++" + supplierName + "::::: +ul. " + deliveryStreet + ":::+" + supplierCity + "++" + supplierZipCode + "+PL\'");
            invoiceInEDIFormat.AppendLine("RFF+VA:" + supplierNIP + "\'");
            invoiceInEDIFormat.AppendLine("");
            invoiceInEDIFormat.AppendLine("NAD+BY+4012345500004::9++" + customerName + "::::: +ul. " + customerStreet + ":::+" + customerCity + "++" + customerZipCode + "+PL\'");
            invoiceInEDIFormat.AppendLine("NAD+DP+4012345500004::9++" + customerName + "::::: +ul. " + customerStreet + ":::+" + customerCity + "++" + customerZipCode + "+PL\'");
            invoiceInEDIFormat.AppendLine("RFF+VA:" + customerNIP + "'");
            invoiceInEDIFormat.AppendLine("TAX+7+VAT+++:::" + VATrate + "+S\'");
            invoiceInEDIFormat.AppendLine("");
            invoiceInEDIFormat.AppendLine("LIN+" + lp + "++4000862141404:EU\'");
            invoiceInEDIFormat.AppendLine("PIA+1+" + produkt + ":GN\'");
            invoiceInEDIFormat.AppendLine("QTY+47:" + ilosc + ":PR\'");
            invoiceInEDIFormat.AppendLine("PRI+AAA:" + CNetto + "\'");
            invoiceInEDIFormat.AppendLine("MOA+66:" + WNetto + ":PLN\'");
            invoiceInEDIFormat.AppendLine("");
            invoiceInEDIFormat.AppendLine("");
            invoiceInEDIFormat.AppendLine("UNS+S\'");
            invoiceInEDIFormat.AppendLine("CNT+2:" + lp + "\'");
            invoiceInEDIFormat.AppendLine("MOA+77:" + WBrutto + "\'");
            invoiceInEDIFormat.AppendLine("MOA+79:" + WNetto + "\'");
            invoiceInEDIFormat.AppendLine("MOA+124:\'");
            invoiceInEDIFormat.AppendLine("MOA+125:\'");
            invoiceInEDIFormat.AppendLine("UNT+52+1\'");

            return invoiceInEDIFormat.ToString();
        }
    }
}
