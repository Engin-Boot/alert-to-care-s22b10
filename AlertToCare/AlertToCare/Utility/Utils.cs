using System;
using Npgsql;

namespace AlertToCare.Utility
{
    public class Utils
    {
        public static string[] NpgsqlDataReaderToStringArrayConvertor(NpgsqlDataReader dr)
        {
            while (dr.Read())
            {
                var Record = new string[dr.FieldCount];
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    Record[i] = dr[i].ToString();
                }

                return Record;
            }

            return null;
        }
        public static bool IsValueNull(object value)
        {
            return (value == null);
        }
        public static bool IsLengthValid(string word, int length)
        {
            return word.Length == length;
        }
    }
}
