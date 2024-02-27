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

        public void Insert(GuitaristeModel guitariste, List<int> Id_Guitare)
        {
            GuitaristeData data = GuitaristeMapper.BllGuitaristeToDal(guitariste);

            _guitaristeRepository.Insert(data, Id_Guitare);
        }

        public bool Update(GuitaristeModel guitariste, int id_Guitariste, List<int> Id_Guitares)
        {
            // Convertir les données du modèle BLL en données du modèle DAL
            GuitaristeData data = GuitaristeMapper.BllGuitaristeToDal(guitariste);

            // Appeler la méthode Update de la DAL en passant les données du guitariste et la liste des ID des guitares
            bool updatedGuitariste = _guitaristeRepository.Update(data, id_Guitariste, Id_Guitares);

            // Retourner le résultat de la mise à jour
            return updatedGuitariste;
        }

        //Methode Exists voir DAL guitaristeRepository
        public bool GuitaristeExists(string nom, string prenom, DateTime dateNaiss)
        {
            return _guitaristeRepository.GuitaristeExists(nom, prenom, dateNaiss);
        }

        public bool GuitaristeExists(int id_Guitariste)
        {
            return _guitaristeRepository.GuitaristeExists(id_Guitariste);
        }


    }
}
