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

        public void Update(AccessoireModel accessoire, int id_Accessoire)
        {
            AccessoireData data = AccessoireMapper.BllAccessToDal(accessoire);
            _accessoireRepository.Update(data, id_Accessoire);
        }
    }
}
