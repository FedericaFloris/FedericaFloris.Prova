using AcademyF.Week1.Forme.Interfaces;
using AcademyF.Week1.Forme.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week1.Forme
{
    internal static class InterazioneUtente
    {
        //static RepositoryRettangoliMOCK repoRettangoli = new RepositoryRettangoliMOCK();
        //static RepositoryRettangoliFile repoRettangoli = new RepositoryRettangoliFile();
        static IRepository<Rettangolo> repoRettangoli = new RepositoryRettangoliFile();//per passare da Mock a File devo caambiare solo la partr dx
        static IRepository<Cerchio> repoCerchi = new RepositoryCerchioFile();
        internal static void Start()
        {
            bool continua = true;
            while (continua)
            {
                int scelta = Menu();
                switch (scelta)
                {
                    case 1:
                        VisualizzaTuttiRettangoli();
                        break;
                    case 2:
                        AggiungiRettangolo();
                        break;
                    case 3:
                        RicercaRettangoloPerNome();
                        break;
                    case 4:
                        VisualizzaCerchi();
                        break;
                    case 5:
                        AggiungiUnCerchio();
                        break;
                    case 6:
                        CercareIlCerchioPerRaggio();
                        break;
                    case 0:
                        Console.WriteLine("Arrivederci");
                        continua = false;
                        break;
                    default:
                        Console.WriteLine("Scelta errata"); //lo uso solo se nel while tolgo &&
                        break;

                }
            }
        }

        private static void AggiungiUnCerchio()
        {
            Console.WriteLine("Inserisci il nome del cerchio:");
            string nome = Console.ReadLine();
            int x;
            do
            {
                Console.WriteLine("Inserisci la coordinata x intero:");
            } while (!int.TryParse(Console.ReadLine(), out x));
            int y;
            do
            {
                Console.WriteLine("Inserisci la coordinata y intero:");
            } while (!int.TryParse(Console.ReadLine(), out y));
            double raggio;
            do
            {
                Console.WriteLine("Inserisci il raggio:");
            } while (!double.TryParse(Console.ReadLine(), out raggio));
            Cerchio cerchioDaAggiungere = new Cerchio() { Name= nome , X=x, Y=y, Raggio=raggio};
            bool esito = repoCerchi.Aggiungi(cerchioDaAggiungere);
            if (esito == true)
            {
                Console.WriteLine("Rettangolo aggiunto corretamente");
            }
            else
            {
                Console.WriteLine("Errore");
            }
        }

        private static void VisualizzaCerchi()
        {
            var listacerchi = repoCerchi.GetAll();
            if (listacerchi.Count == 0)
            {
                Console.WriteLine("la lista è vuota");
            }
            else
            {
                foreach(var item in listacerchi)
                {
                    item.Disegna();
                }
            }
        }

        private static void CercareIlCerchioPerRaggio()
        {
            double raggioCercato;
            do
            {
                Console.WriteLine("Che cerchi vuoi vedere?Inserisci il raggio");

            } while (!double.TryParse(Console.ReadLine(), out raggioCercato));
            var listaCerchi = repoCerchi.GetAll();
            bool esistenza= false;
            foreach(var item in listaCerchi)
            {
                if(item.Raggio == raggioCercato)
                {
                    item.Disegna();
                    esistenza = true;
                    
                }
               
            }
            if(esistenza == false)
            {
                Console.WriteLine("Il cerchio non esiste");
            }
            
            
            

        }

        private static void RicercaRettangoloPerNome()
        {
            Console.WriteLine("Inserisci il nome del nuovo rettangolo che vuoi creare");
            string nome = Console.ReadLine();
            var listaRettangoli = repoRettangoli.GetAll();
            foreach (var r in listaRettangoli)
            {
                if(r.Name == nome)
                {
                    r.Disegna();
                    return;
                }
            }
            Console.WriteLine("Rettangolo non esiste");
        }

        private static void AggiungiRettangolo()
        {
            Console.WriteLine("Inserisci il nome del rettangolo:");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci la base del rettangolo");
            double baseRettangolo;
           while (!double.TryParse(Console.ReadLine(), out  baseRettangolo))
           {
                Console.WriteLine("Riprova. Inserisci un numero");
           }
            double altezzaRettangolo;
            do
            {
                Console.WriteLine("Inserisci l altezza del rettangolo");
            } while (!double.TryParse(Console.ReadLine(), out altezzaRettangolo));

            var nuovoRettangolo = new Rettangolo() { Name = nome, Base = baseRettangolo, Altezza = altezzaRettangolo };
            bool esito = repoRettangoli.Aggiungi(nuovoRettangolo);
            if(esito == true)
            {
                Console.WriteLine("Rettangolo aggiunto corretamente");
            }
            else
            {
                Console.WriteLine("Errore");
            }

            

        }

        private static void VisualizzaTuttiRettangoli()
        {
            var listaRettangoliRecuperata=repoRettangoli.GetAll();
            if(listaRettangoliRecuperata.Count == 0)
            {
                Console.WriteLine("Lista vuota");
            }
            else
            {
                Console.WriteLine("Ecco l'elenco dei rettangoli");
                foreach (var item in listaRettangoliRecuperata)
                {
                    item.Disegna(); //non ho il toString
                    //altrimenti avrei fatto Console.WriteLine(item)
                }
            }
        }

        private static int Menu()
        {
            Console.WriteLine("--------Menu--------");
            Console.WriteLine("1.Visualizza tutti i Rettangoli");
            Console.WriteLine("2.Aggiungi un Rettangolo");
            Console.WriteLine("3.Cerca un rettangolo per nome");
            Console.WriteLine("4.Visualizza tutti i cerchi");
            Console.WriteLine("5.Aggiungi un cerchio");
            Console.WriteLine("6.Cerca i cerchi con un determinato raggio");
            Console.WriteLine("\n0.Exit");
            Console.WriteLine("\n Inserisci la tua scelta:");

            //int.TryParse(Console.ReadLine(), out int sceltaUtente);
            int sceltaUtente;
            while(!int.TryParse(Console.ReadLine(), out sceltaUtente) /*&& sceltaUtente<=3 && sceltaUtente>=0*/)
            {
                Console.WriteLine("Riprova. Devi inserire un numero utente");

            }
            return sceltaUtente;

        }
    }
}
