﻿using Guitarotheque_BLL.Interfaces;
using Guitarotheque_BLL.Mapper;
using Guitarotheque_BLL.Models;
using Guitarotheque_DAL.Data;
using Guitarotheque_DAL.Interfaces;
using Guitarotheque_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitarotheque_BLL.Services
{
    public class GuitareService : IGuitareService
    {

        private readonly IGuitareRepository _guitareRepository;

        public GuitareService(IGuitareRepository guitareRepository)
        {
            _guitareRepository = guitareRepository;
        }
        public void Delete(int id_Guitare)
        {
            _guitareRepository.Delete(id_Guitare);
        }

        public GuitareModel Get(int id_Guitare)
        {
            GuitareData data = _guitareRepository.Get(id_Guitare);

            return GuitareMapper.DalGuitareToBll(data);
        }

        public IEnumerable<GuitareModel> GetByGuitariste(int id_Guitariste)
        {
            IEnumerable<GuitareData> datalist = _guitareRepository.GetByGuitariste(id_Guitariste);

            return datalist.Select(data => GuitareMapper.DalGuitareToBll(data));
        }
        public IEnumerable<GuitareModel> GetAll()
        {
            IEnumerable<GuitareData> datalist = _guitareRepository.GetAll();

            return datalist.Select(data => GuitareMapper.DalGuitareToBll(data));
        }

        public void Insert(GuitareModel guitare)
        {
            GuitareData data = GuitareMapper.BllGuitareToDal(guitare);
           

            _guitareRepository.Insert(data);
        }

        public bool Update(GuitareModel guitare, int id_Guitare)
        {
            

            GuitareData guitareData = _guitareRepository.Get(id_Guitare);

            if(guitareData == null)
            {
                return false;
            }

            guitareData.Libelle = guitare.Libelle;
            guitareData.Prix = guitare.Prix;
            guitareData.AnneeDeSortie = guitare.AnneeDeSortie;
            guitareData.Description = guitare.Description;
            guitareData.NbrCordes = guitare.NbrCordes;

            bool updatedGuitare = _guitareRepository.Update(guitareData, id_Guitare);

            return updatedGuitare;


        }

        public bool GuitareExists(int id_Guitare)
        {
            // Utilisez la méthode Get pour vérifier si la guitare existe
            return _guitareRepository.Get(id_Guitare) != null;
        }

        public bool UpdateImgGuitares(GuitareModel guitare, int id_Guitare)
        {
            

            GuitareData guitareData = _guitareRepository.Get(id_Guitare);

            if (guitareData == null)
            {
                return false;
            }

            guitareData.UrlImage = guitare.UrlImage;


            bool updatedUrlImage = _guitareRepository.UpdateImgGuitares(guitareData, id_Guitare);

            return updatedUrlImage;

        }

        public IEnumerable<GuitareModel> GetAllPagination(int pageNumber)
        {
            int pageSize = 9; // Taille de la page
            IEnumerable<GuitareData> dataList = _guitareRepository.GetAllPagination(pageNumber, pageSize);
            return dataList.Select(data => GuitareMapper.DalGuitareToBll(data));
        }
    }
}
