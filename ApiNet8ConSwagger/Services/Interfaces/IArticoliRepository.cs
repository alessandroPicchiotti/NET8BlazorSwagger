using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaCube.Models;

namespace ApiNet8ConSwagger.Services.Interface
{
    public interface IArticoliRepository
    {
        Task<ICollection<Articoli>> GEtByDescrizioneAsync(string descrizione);
        Task<Articoli> GetByCodiceAsync(string codart);
        Task<ICollection<Articoli>> GetAll();

        Task<int> SaveAsync(Articoli artico);
        Task<int> UpdateAsync(Articoli artico);

    }
}

