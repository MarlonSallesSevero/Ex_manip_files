using System;
using System.IO;
using System.Globalization;
using EX.Entities;
namespace EX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path:");
            string sourceFilePath = Console.ReadLine();
            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);
                string sourceFolderPath = Path.GetDirectoryName(sourceFilePath);
                string targetFolderPath = sourceFilePath + @"\out";
                string targetFilePath = targetFolderPath + @"\summary.csv";
                Directory.CreateDirectory(targetFolderPath);
                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (var item in lines)
                    {
                        string[] campos = item.Split(',');
                        string name = campos[0];
                        double price = double.Parse(campos[1], CultureInfo.InvariantCulture);
                        int qtd = int.Parse(campos[3], CultureInfo.InvariantCulture);
                        Product prod = new Product(name, price, qtd);
                        sw.WriteLine(prod.nome + "," + prod.total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine($"Erro:\n{ex.Message}");
            }
            finally
            {
                string a = Console.ReadLine();
            }
        }
    }
}
