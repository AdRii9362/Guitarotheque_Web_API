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
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Services
{

    public class AccessoireService : IAccessoireService
    {
        private readonly IAccessoireRepository _accessoireRepository;

        public AccessoireService(IAccessoireRepository accessoireRepository)
        {
            _accessoireRepository = accessoireRepository;
        }
        public void Delete(int id_Accessoire)
        {
            _accessoireRepository.Delete(id_Accessoire);
        }

        public AccessoireModel Get(int id_Accessoire)
        {
            AccessoireData data = _accessoireRepository.Get(id_Accessoire);

            return AccessoireMapper.DalAccessToBll(data);
        }

        public IEnumerable<AccessoireModel> GetAll()
        {
            IEnumerable<AccessoireData> dataList = _accessoireRepository.GetAll();
            return dataList.Select(data => AccessoireMapper.DalAccessToBll(data));
        }

        public void Insert(AccessoireModel accessoire)
        {
            AccessoireData data = AccessoireMapper.BllAccessToDal(accessoire);
            _accessoireRepository.Insert(data);
        }

        public bool Update(AccessoireModel accessoire, int id_Accessoire)
        {
            AccessoireData data = AccessoireMapper.BllAccessToDal(accessoire);

            // Vérifier si l'accessoire à mettre à jour existe
            AccessoireData accessoireData = _accessoireRepository.Get(id_Accessoire);

            if (accessoireData == null)
            {
                return false;
            }

            // Effectuer la mise à jour des propriétés de l'accessoire existant avec les nouvelles valeurs
            accessoireData.Description = accessoire.Description;
            accessoireData.Libelle = accessoire.Libelle;
            accessoireData.Prix = accessoire.Prix;

            bool UpdatedAccessoire = _accessoireRepository.Update(accessoireData, id_Accessoire);
            return UpdatedAccessoire;
        }
    }
}
