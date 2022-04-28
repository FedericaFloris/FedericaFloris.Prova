using AcademyF.Week1.Forme.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week1.Forme.Repositories
{
    internal class RepositoryRettangoliFile : IRepository<Rettangolo>
    {
        //1)path
        string path = @"C:\Users\federica.floris\Desktop\AcademyF.Week1-master\AcademyF.Week1.Forme\Repositories\Rettangolo.txt";
        //voglio recuperare questi rettangoli da file

        public bool Aggiungi(Rettangolo item)
        {
            //devo scrivere su file il rettangolo da aggiungere
            using(StreamWriter sw = new StreamWriter(path,true))//true mi fa scrivere in coda
            {
                sw.WriteLine($"{item.Name},{item.Base},{item.Altezza}");
            }
            return true;
        }

        public List<Rettangolo> GetAll()
        {
            //Dichiaro la lista che mi serve dopo da far uscire
            List<Rettangolo> rettangoli = new List<Rettangolo>();
            //attenzione dello leggere devo usare la streamreader
            using(StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd(); //legge il contenuto del file e lo mette in una stringa
                //controllo se il file e vuoto o meno
                if(string.IsNullOrEmpty(contenutoFile)) //contenutoFile == null || contenutoFile == "" stessa roba cerca se vuota o null
                {
                    return new List<Rettangolo>();
                }
                else
                {
                    var righeDelFile=contenutoFile.Split("\r\n"); //metto in ogni casella tutta la riga
                    for(int i =0; i < righeDelFile.Length-1; i++)
                    {
                        //spilto la singola riga del mio file
                        var campiDellaRiga=righeDelFile[i].Split(",");
                        //creo il mio rettangolo
                        Rettangolo r = new Rettangolo();
                        r.Name = campiDellaRiga[0];
                        r.Base = double.Parse(campiDellaRiga[1]);//trasforma double in parse perchè campidellariga è stringa
                        r.Altezza = double.Parse(campiDellaRiga[2]);
                        rettangoli.Add(r);
                    }
                }
                return rettangoli;
            }
        }
    }
}
