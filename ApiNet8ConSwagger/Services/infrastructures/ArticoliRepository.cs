using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using ApiNet8ConSwagger.DataContexts;
using WaCube.Models;
using ApiNet8ConSwagger.Services.Interface;


namespace ApiNet8ConSwagger.Services.infrastructures
{
    public class ArticoliRepository : IArticoliRepository
    {
        private const string CacheKey = "ArticoliRepository";
        private DbContextCube dbContextCube;

        public ArticoliRepository(DbContextCube dbContextCube)
        {

            this.dbContextCube = dbContextCube;

        }



        private async Task<ICollection<Articoli>> GetInternaleAll()
        {
            //var selectQuery = "new(ar_codart,  ar_descr,   ar_unmis,ar_codtipa,   ar_pesolor,   ar_pesonet,   ar_confez2,   codditt,   ar_famprod ,   ar_datins ,   ar_codiva)";

            var listArt = await dbContextCube.Artico
                 .AsNoTracking()
                 .Where(w => w.codditt == "SA01")
                 .Select(x => new Articoli
                 {
                     ar_codart = x.ar_codart,
                     ar_descr = x.ar_descr,
                     ar_unmis = x.ar_unmis,
                     //ar_codtipa = x.ar_codtipa,
                     //ar_pesolor =x.ar_pesolor,
                     //ar_pesonet = x.ar_pesonet,
                     //ar_confez2 = x.ar_confez2,
                     //codditt = x.codditt,
                     //ar_famprod = x.ar_famprod,
                     //ar_datins = x.ar_datins,
                     //ar_codiva = x.ar_codiva 
                 })
           .ToListAsync();


            return listArt;
            //.OrderBy(a => a.ar_descr)
            //.ToListAsync();

        }
        public Task<ICollection<Articoli>> GetAll()
        {

            return GetInternaleAll();
        }



        public async Task<ICollection<Articoli>> GEtByDescrizioneAsync(string descrizione)
        {

            var list = await dbContextCube.Artico
                       .Where(x => x.codditt == "SA01" && x.ar_descr.Contains(descrizione))
                       .ToListAsync();

            return list;

        }


        public async Task<Articoli> GetByCodiceAsync(string codart)
        {
            Articoli? Art = await dbContextCube.Artico.Where(x => x.ar_codart == codart && x.codditt == "SA01").FirstOrDefaultAsync();

            return Art;
        }
        public async Task<int> SaveAsync(Articoli artico)
        {
            await dbContextCube.AddAsync(artico);

            return await dbContextCube.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(Articoli artico)
        {
            return await dbContextCube.SaveChangesAsync();
        }

    }
}