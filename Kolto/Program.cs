using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> lista = new Dictionary<string, int>();
            StreamReader sr = new StreamReader("Versek.txt");
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Replace(".", ",").Replace("-", ",").Replace(" ", ",").Replace("!", ",").Replace("?", ",").Split(Convert.ToChar(","));
                foreach (var item in line)
                {
                    string litem = item.ToLower();
                    if (!lista.ContainsKey(litem))
                    {
                        lista.Add(litem, 1);
                    }
                    else if (lista.ContainsKey(litem))
                    {
                        lista[litem]++;
                    }
                }
            }
            foreach (var key in new List<string>(lista.Keys))
            {
                if (key == "a" || key == "az" || key == "és" || key == "hogy" || key == "-" || key == "")
                {
                    lista.Remove(key);
                }
            }
            List<KeyValuePair<string, int>> sortLista = lista.ToList();
            sortLista.Sort((x, y) => y.Value.CompareTo(x.Value));
            Dictionary<string, int> sortedLista = sortLista.ToDictionary(x => x.Key, x => x.Value);
            int szamlal = 10;
            foreach (KeyValuePair<string, int> item in sortedLista)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
                if (--szamlal == 0) break;
            }

            Console.ReadKey();
        }
    }
}
