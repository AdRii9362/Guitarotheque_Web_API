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
    public class GroupeService : IGroupeService
    {
        private readonly IGroupeRepository _groupeRepository;

        public GroupeService(IGroupeRepository groupeRepository)
        {
            _groupeRepository = groupeRepository;
        }
        public void Delete(int id_Groupe)
        {
            _groupeRepository.Delete(id_Groupe);
        }

        public GroupeModel Get(int id_Groupe)
        {
            GroupeData data = _groupeRepository.Get(id_Groupe);

            return GroupeMapper.DalGroupeToBll(data);
        }

        public IEnumerable<GroupeModel> GetAll()
        {
            IEnumerable<GroupeData> datalist = _groupeRepository.GetAll();

            return datalist.Select(data => GroupeMapper.DalGroupeToBll(data));
        }

        public void Insert(GroupeModel groupe)
        {
            GroupeData data = GroupeMapper.BllGroupeToDal(groupe);

            _groupeRepository.Insert(data);
        }

        public bool Update(GroupeModel groupe, int id_Groupe)
        {
            GroupeData data = GroupeMapper.BllGroupeToDal(groupe);

            // Vérifier si l'accessoire à mettre à jour existe
            GroupeData groupeData = _groupeRepository.Get(id_Groupe);

            if(groupeData == null)
            {
                return false;
            }

            // Effectuer la mise à jour des propriétés de l'accessoire existant avec les nouvelles valeurs
            groupeData.Nom = groupe.Nom;
            groupeData.Genre = groupe.Genre;
            groupeData.AnneeCreation = groupe.AnneeCreation;

            bool updatedGroupe = _groupeRepository.Update(groupeData, id_Groupe);

            return updatedGroupe;
        }
    }
}
