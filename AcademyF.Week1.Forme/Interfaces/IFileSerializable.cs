using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.Week1.Forme.Interfaces
{
    public interface IFileSerializable<T>
    {
        Task<List<T>> GetAllAsync();

        Task<bool> AggiungiFileAsync(T item);
    }
}
