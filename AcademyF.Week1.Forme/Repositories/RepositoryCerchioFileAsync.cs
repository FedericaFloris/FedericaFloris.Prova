using AcademyF.Week1.Forme.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week1.Forme.Repositories
{
    internal class RepositoryCerchioFileAsync : IFileSerializable<Cerchio>
    {
        string path = @"C:\Users\federica.floris\Desktop\AcademyF.Week1-master\AcademyF.Week1.Forme\Repositories\Cerchio.txt";
        public async Task<bool> AggiungiFileAsync(Cerchio item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLineAsync($"{item.Name}-{item.X}-{item.Y}-{item.Raggio}");
            }
           
            return true;
        }

        public async Task<List<Cerchio>> GetAllAsync()
        {
            List<Cerchio> cerchi = new List<Cerchio>();

            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = await sr.ReadToEndAsync();
                if (string.IsNullOrEmpty(contenutoFile))
                {
                    return new List<Cerchio>();
                }
                else
                {
                    var righeDelFile = contenutoFile.Split("\r\n");
                    for (int i = 0; i < righeDelFile.Length - 1; i++)
                    {
                        //spilto la singola riga del mio file
                        var campiDellaRiga = righeDelFile[i].Split("-");
                        //creo il mio rettangolo
                        Cerchio c = new Cerchio();
                        c.Name = campiDellaRiga[0];
                        c.X = int.Parse(campiDellaRiga[1]);
                        c.Y = int.Parse(campiDellaRiga[2]);
                        c.Raggio = double.Parse(campiDellaRiga[3]);
                        cerchi.Add(c);
                    }
                }
                return cerchi;
            }
        }
    }
}
