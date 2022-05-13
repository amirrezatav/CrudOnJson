using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDONJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            // string root = Directory.GetCurrentDirectory();
            string root = "."; // exe directory 
            JsonFile jsonFile = new JsonFile(root);

            Sheep babaei = new Sheep()
            {
                Id = 1,
                Name = "sab",
                Age = 3,
            };
            jsonFile.Create<Sheep>(babaei);

            babaei = new Sheep()
            {
                Id = 2,
                Name = "askhar",
                Age = 9,
            };
            jsonFile.Create<Sheep>(babaei);
            babaei = new Sheep()
            {
                Id = 3,
                Name = "has",
                Age = 8,
            };
            jsonFile.Create(babaei);
            babaei = new Sheep()
            {
                Id = 4,
                Name = "ham",
                Age = 7,
            };
            jsonFile.Create(babaei);
            babaei = new Sheep()
            {
                Id = 5,
                Name = "bab",
                Age = 6,
            };
            jsonFile.Create(babaei);



            jsonFile.Delete<Sheep>(x => x.Id == 5);

            babaei = new Sheep()
            {
                Id = 5,
                Name = "sal",
                Age = 6,
            };

            jsonFile.Update(babaei , x => x.Id == 5);

        }
    }
}
