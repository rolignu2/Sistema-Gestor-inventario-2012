using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace Delatorre.Modulos
{
    public class Expresiones
    {



        public static string GetExpresionDidYouMean(string Cadena)
        {
            string retValue = string.Empty;
            try
            {
                string uri = "https://www.google.com/tbproxy/spell?lang=es:";
                using (WebClient webclient = new WebClient())
                {
                    string postData = string.Format("<?xml version=\"1.0\" encoding=\"utf-8\" ?><spellrequest textalreadyclipped=\"0\" ignoredups=\"0\" ignoredigits=\"1\" "
                    + "ignoreallcaps=\"1\"><text>{0}</text></spellrequest>", Cadena);

                    webclient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    byte[] bytes = Encoding.ASCII.GetBytes(postData);
                    byte[] response = webclient.UploadData(uri, "POST", bytes);
                    string data = Encoding.ASCII.GetString(response);
                    if (data != string.Empty)
                    {
                        retValue = Regex.Replace(data, @"<(.|\n)*?>", string.Empty).Split('\t')[0];
                    }
                }
            }
            catch
            {

            }
            return retValue;


        }
    }
}
