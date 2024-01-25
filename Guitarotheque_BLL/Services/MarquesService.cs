using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Mapper;
using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using Guitarotheque_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Services
{
    public class MarquesService : IMarquesService
    {

        private readonly IMarqueRepository _marqueRepository;

        public MarquesService(IMarqueRepository marqueRepository)
        {
            _marqueRepository = marqueRepository;
        }
        public void Delete(int id_Marque)
        {
            _marqueRepository.Delete(id_Marque);
        }

        public MarquesModel Get(int id_Marque)
        {
            MarquesData data = _marqueRepository.Get(id_Marque);

            return MarquesMapper.DalMarquesToBll(data);
        }

        public IEnumerable<MarquesModel> GetAll()
        {
            IEnumerable<MarquesData> datalist = _marqueRepository.GetAll();

            return datalist.Select(data => MarquesMapper.DalMarquesToBll(data));
        }

        public void Insert(MarquesModel marque)
        {
            MarquesData data = MarquesMapper.BllMarquesToDal(marque);

            _marqueRepository.Insert(data);
        }

        public bool Update(MarquesModel marque, int id_Marque)
        {
            MarquesData data = MarquesMapper.BllMarquesToDal(marque);

            MarquesData marquesData = _marqueRepository.Get(id_Marque);

            if(marquesData == null)
            {
                return false;
            }

            marquesData.Nom = marque.Nom;
            marquesData.SiegeSocial = marque.SiegeSocial;
            marquesData.Description = marque.Description;

            bool updatedMarques = _marqueRepository.Update(marquesData, id_Marque);

            return updatedMarques;
        }
    }
}
