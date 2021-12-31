using System;
using System.Linq;
using B4RX63_HFT_2021221.Models;

namespace B4RX63_HFT_2021221.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            RestService rest = new RestService("http://localhost:25294");

            CreateMethods cm = new CreateMethods(rest);
            Menu menu = new Menu(rest, cm);
            menu.OpenMenu();
        }
    }
}
