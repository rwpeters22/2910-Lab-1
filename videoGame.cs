using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class videoGame : IComparable<videoGame>
    {
        private string name;
        private string platform;
        private int year;
        private string genre;
        private string publisher;
        private decimal naSales;
        private decimal euSales;
        private decimal jpSales;
        private decimal otherSales;
        private decimal globalSales;

        public videoGame (string name, string platform, int year, string genre, string publisher, decimal naSales, decimal euSales, decimal jpSales, decimal otherSales, decimal globalSales)
        {
            this.name = name;
            this.platform = platform;
            this.year = year;
            this.genre = genre;
            this.publisher = publisher;
            this.naSales = naSales;
            this.euSales = euSales;
            this.jpSales = jpSales;
            this.otherSales = otherSales;
            this.globalSales = globalSales;
        }

        public string GetPublisher()
        {
            return publisher;
        }

        public string GetGenre()
        {
            return genre;
        }

        public int CompareTo(videoGame vg)
        {
            if (vg == null)
            {
                return 1;
            }

            if (vg != null)
            {
                return this.name.CompareTo(vg.name);
            }

            else
            {
                throw new ArgumentException("Not a valid title.");
            }
        }

        public override string ToString()
        {
            string str = $"\n{name}";
            str += $"\n{platform}";
            str += $"\n{year}";
            str += $"\n{genre}";
            str += $"\n{publisher}";
            str += $"\n{naSales}";
            str += $"\n{euSales}";
            str += $"\n{jpSales}";
            str += $"\n{otherSales}";
            str += $"\n{globalSales}";

            return str;
        }

    }
}
