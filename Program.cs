using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.Text.RegularExpressions;

namespace adress
{
    // страна, город, индекс, улица, дом, квартира
    internal class Program
    {
        static void Main(string[] args)
        {
            string adress_pattern = @"^([a-zA-Z])*\,([a-zA-Z])*\,\d{6}\,([a-zA-Z])*[0-9]{1,2}[A-Z]{1}\,[0-9]{1,4}$";
            Regex r_adress = new Regex(adress_pattern);
            Write("Введите имя файла: ");
            string path = ReadLine();
            string adress;
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    WriteLine("Пример адреса: Страна, Город, 000000, Улица 0, 00");
                    Write("Введите адрес: ");
                    adress = ReadLine();
                }
                WriteLine(r_adress.IsMatch(adress) ? "correct" : "incorrect");
            }

            
            using (FileStream fs = new FileStream(path, FileMode.Open)) 
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    WriteLine(sr.ReadToEnd());
                }
            }
        }
    }
}
