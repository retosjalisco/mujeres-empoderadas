using System;
using System.Security.Cryptography;
using System.Text;

namespace MujeresEmpoderadas
{
    public class Utilidades
    {
        public static void Log(string mensaje)
        {
            Console.WriteLine(mensaje);
            //string strArchivoLog = "~/Content/ErrorLog/ErrorLog.txt";

            //try
            //{
            //    if (!string.IsNullOrEmpty(mensaje))
            //    {
            //        using (FileStream file = new FileStream(HttpContext.Current.Server.MapPath(strArchivoLog), FileMode.Append, FileAccess.Write))
            //        {
            //            StreamWriter streamWriter = new StreamWriter(file);
            //            streamWriter.WriteLine(DateTime.Now + " - \r" + mensaje + "\r");
            //            streamWriter.Close();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        #region Seguridad

        public static string encriptarContrasena(string strContrasena)
        {
            string strSal = "";
            string strHash;

            strSal = CrearSal(strContrasena);
            strHash = HashContrasena(strSal, strContrasena);

            using (MD5 md5Hash = MD5.Create())
                strContrasena = ObtenerMd5Hash(md5Hash, strContrasena);

            return strContrasena;
        }

        public static string CrearSal(string strContrasena)
        {
            Rfc2898DeriveBytes hasher = new Rfc2898DeriveBytes(strContrasena,
                System.Text.Encoding.Default.GetBytes("NEMUEM@NicotinaEstudioMX"), 10000);
            return Convert.ToBase64String(hasher.GetBytes(25));
        }

        public static string HashContrasena(string Sal, string Contrasena)
        {
            Rfc2898DeriveBytes Hasher = new Rfc2898DeriveBytes(Contrasena,
                System.Text.Encoding.Default.GetBytes(Sal), 10000);
            return Convert.ToBase64String(Hasher.GetBytes(25));
        }

        static string ObtenerMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        // Verify a hash against a string. 
        static bool VerificarMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input. 
            string hashOfInput = ObtenerMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
