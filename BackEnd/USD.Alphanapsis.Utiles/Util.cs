using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel; 
using System.IO;
using System.Reflection; 

namespace USD.Alphanapsis.Utiles
{
    public class Util
    {
        //public static void EliminarRutaBarcode(string codigo)
        //{
        //    var ruta = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/BarCode");
        //    ruta = string.Format("{0}\\{1}.png", ruta, codigo);

        //    if (File.Exists(ruta))
        //    {
        //        File.Delete(@ruta);
        //    }
            
        //}
        //public static string ObtenerRutaBarcode(string codigo)
        //{
        //    var ruta = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/BarCode");
        //    ruta = string.Format("{0}\\{1}.png", ruta, codigo);
        //    return ruta;
        //}
        public static IEnumerable<T> EnumToList<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            Array enumValArray = Enum.GetValues(enumType);
            List<T> enumValList = new List<T>(enumValArray.Length);

            foreach (int val in enumValArray)
            {
                enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
            }

            return enumValList;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description.ToUpper() == description.ToUpper())
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description.ToUpper())
                        return (T)field.GetValue(null);
                }
            }
            //throw new ArgumentException("Not found.", "description");
            return default(T);
        }

        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }


        public static T Get<T>(string key)
        {
            var builder = new ConfigurationBuilder();
            IConfigurationRoot configurationRoot = null;
            string path = Path.Combine(Directory.GetCurrentDirectory(), GetAppSettingsFile());
            builder.AddJsonFile(path, false);
            configurationRoot = builder.Build();

            var appSetting = configurationRoot.GetSection("AppSettings").GetSection(key).Value;
            if (string.IsNullOrWhiteSpace(appSetting)) return default(T);

            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)(converter.ConvertFromInvariantString(appSetting));
        }

        public static string GetAppSettingsFile()
        {
            string _env = "dev";
            try
            {
                var config = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json", false)
                                    .Build();

                _env = config.GetSection("Environment").Value;
            }
            catch (Exception)
            {
                _env = "dev";
            }

            var fileName = $"appsettings.{_env}.json";
            return fileName;
        }

        public static T Convert<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return default(T);

            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T)(converter.ConvertFromInvariantString(key));
        }

        public static string EnLetras(string num)
        {
            string res, dec = "";
            int entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert<double>(num);
            }
            catch
            {                
                return "";
            }


            entero =(int)(Math.Truncate(nro));
            decimales = (int)Math.Round((nro - entero) * 100, 2);

            if (decimales > 0)
            {
                dec = " CON " +decimales.ToString() + "/ 100";
            }

            res = toText(Convert<double>(entero.ToString())) + dec;

            return res;
            
        }

        private static string toText(double value)
        {

            string Num2Text = "";
            value = Math.Truncate(value);

            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }
            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }
            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }


            return Num2Text;


        }

        public static bool EsNumero(string sValor, bool bIncluyeDecimal)
        {
            bool flag = false;
            int num = 0;
            sValor = sValor.Trim();
            for (int index = 0; index < sValor.Length; ++index)
            {
                if ((int)sValor[index] >= 48 && (int)sValor[index] <= 57)
                    flag = true;
                else if ((int)sValor[index] == 45)
                {
                    if (index == 0)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                else if (bIncluyeDecimal && (int)sValor[index] == 46)
                {
                    ++num;
                    if (num <= 1)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                else
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        //public static string GetUrl(string url)
        //{
        //    return VirtualPathUtility.ToAbsolute(url);
        //}

        public static string GenerarToken(int longitud)
        {
            Guid miGuid = Guid.NewGuid();
            string token = System.Convert.ToBase64String(miGuid.ToByteArray());
            token = token.Replace("=", "").Replace("+", "").Replace("/", "");
            return token.Substring(0, longitud);
        }

        //public static string ConvertirTextoImagen(string nombre, string pruebas, string muestra, string edad)
        //{
        //    Bitmap bitma = new Bitmap(1, 1);

        //    int bitmapW = Util.Get<int>("Eti.Img.Bitmap.W");
        //    int bitmapH = Util.Get<int>("Eti.Img.Bitmap.H");
        //    int pruebasX = Util.Get<int>("Eti.Img.Pruebas.X");
        //    int pruebasY = Util.Get<int>("Eti.Img.Pruebas.Y");
        //    int muestraX = Util.Get<int>("Eti.Img.Muestra.X");
        //    int muestraY = Util.Get<int>("Eti.Img.Muestra.Y");
        //    int nombreX = Util.Get<int>("Eti.Img.Nombres.X");
        //    int nombreY = Util.Get<int>("Eti.Img.Nombres.Y");


        //    Color verde = Color.FromArgb(151,250,51);

        //    //Font font = new Font("Calibri", 13, FontStyle.Bold, GraphicsUnit.Pixel);
        //    Font font = new Font("Calibri", 9.0f, FontStyle.Bold);

        //    Graphics graphics = Graphics.FromImage(bitma);

        //    bitma = new Bitmap(bitma, new Size(bitmapW, bitmapH));

        //    graphics = Graphics.FromImage(bitma);

        //    graphics.DrawString(pruebas, font, new SolidBrush(Color.Black), pruebasX, pruebasY);
        //    graphics.DrawString(muestra, font, new SolidBrush(Color.Black), muestraX, muestraY);
        //    var paciente = nombre;
        //    paciente += edad == "" ? "" : " " + edad + "a.";
        //    graphics.DrawString(paciente, font, new SolidBrush(Color.Black), nombreX, nombreY);

        //    graphics.Flush();
        //    graphics.Dispose();

        //    ImageConverter converter = new ImageConverter();
        //    var imm = (byte[])converter.ConvertTo(bitma, typeof(byte[]));

        //    string result = System.Convert.ToBase64String(imm);

        //    return result;
        
        //}

        //public static Image Base64ToImage(string base64String)
        //{
        //    // Convert base 64 string to byte[]
        //    byte[] imageBytes = System.Convert.FromBase64String(base64String);
        //    // Convert byte[] to Image
        //    using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
        //    {
        //        Image image = Image.FromStream(ms, true);
        //        return image;
        //    }
        //}

    }
}
