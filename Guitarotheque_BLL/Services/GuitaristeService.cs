using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Mapper;
using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using Guitarotheque_DAL.Interfaces;
using Guitarotheque_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Services
{
    public class GuitaristeService : IGuitaristeService
    {

        private readonly IGuitaristeRepository _guitaristeRepository;

        public GuitaristeService(IGuitaristeRepository guitaristeRepository)
        {
            _guitaristeRepository = guitaristeRepository;
        }

        public void Delete(int Id_Guitariste)
        {
            _guitaristeRepository.Delete(Id_Guitariste);
        }

        public GuitaristeModel Get(int Id_Guitariste)
        {
            GuitaristeData data = _guitaristeRepository.Get(Id_Guitariste);

            return GuitaristeMapper.DalGuitaristeToBll(data);
        }

        public IEnumerable<GuitaristeModel> GetAll()
        {
            IEnumerable<GuitaristeData> datalist = _guitaristeRepository.GetAll();

            return datalist.Select(data => GuitaristeMapper.DalGuitaristeToBll(data));
        }

        public void Insert(GuitaristeModel guitariste)
        {
            GuitaristeData data = GuitaristeMapper.BllGuitaristeToDal(guitariste);

            _guitaristeRepository.Insert(data);
        }

        public bool Update(GuitaristeModel guitariste, int id_Guitariste)
        {
            GuitaristeData data = GuitaristeMapper.BllGuitaristeToDal(guitariste);

            GuitaristeData guitaristeData = _guitaristeRepository.Get(id_Guitariste);

            if (guitaristeData == null)
            {
                return false;
            }

            guitaristeData.Nom = guitariste.Nom;
            guitaristeData.Prenom = guitariste.Prenom;
            guitaristeData.DateNaiss = guitariste.DateNaiss;


            bool updatedGuitariste = _guitaristeRepository.Update(guitaristeData, id_Guitariste);

            return updatedGuitariste;
        }
    }
}
