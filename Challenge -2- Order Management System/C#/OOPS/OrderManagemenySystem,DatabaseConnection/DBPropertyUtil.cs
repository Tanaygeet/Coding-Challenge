/* Tanaygeet Shrivastava */

using System;
using System.IO;

namespace OrderManagementSystem.util
{
    public class DBPropertyUtil
    {
        public static string GetConnectionString(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);
                foreach (string line in lines)
                {
                    if (line.StartsWith("connectionString="))
                    {
                        return line.Substring("connectionString=".Length);
                    }
                }
                throw new Exception("Connection string not found.");
            }
            catch (Exception ex)
            {
                throw new Exception("Error reading connection string file: " + ex.Message);
            }
        }
    }
}


