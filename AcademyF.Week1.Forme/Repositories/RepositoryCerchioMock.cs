using AcademyF.Week1.Forme.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week1.Forme.Repositories
{
    internal class RepositoryCerchioMock : IRepository<Cerchio>
    {
        private List<Cerchio> listaCerchi = new List<Cerchio>()
        {
            new Cerchio() { Name = "C1", Raggio = 16, X=5, Y=6 },
            new Cerchio() { Name = "C2", Raggio = 50, X=25, Y=10 },
            new Cerchio() { Name = "C3", Raggio = 50, X=25, Y=10 }
        };
        public bool Aggiungi(Cerchio item)
        {
            if(item == null)
            {
                return false;
            }
            else
            {
                listaCerchi.Add(item);
                return true;
            }
        }

        public List<Cerchio> GetAll()
        {
            return listaCerchi;
        }
    }
}
