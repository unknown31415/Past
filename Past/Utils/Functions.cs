using System;

namespace Past.Utils
{
    public class Functions
    {
        private static Random random = new Random();

        public static string ByteArrayToString(byte[] data)
        {
            return BitConverter.ToString(data).Replace("-", " ");
        }

        public static string ByteArrayToString(byte[] data, int length)
        {
            return BitConverter.ToString(data, 0, length).Replace("-", " ");
        }

        public static string RandomString(int lenght, bool upper)
        {
            string str = string.Empty;
            for (int i = 1; i <= lenght; i++)
            {
                int num = random.Next(0, 26);
                str += (char)('a' + num);
            }
            if (upper)
                return str.ToUpper();
            return str;
        }
    }
}
