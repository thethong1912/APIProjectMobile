﻿using APIProjectMobile.Repository;
using APIProjectMobile.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProjectMobile.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipment;
        public EquipmentService(IEquipmentRepository equipment)
        {
            _equipment = equipment;
        }

        public async Task AddEquipmentSV(EquipmentInfoVM equipment)
        {
            await _equipment.AddEquipment(equipment);
        }

        public async Task<bool> DeleteEquipmentSV(int id)
        {
            try
            {
                bool check = await _equipment.DeleteEquipment(id);
                if (check == true) return true;
                else return false;
            }
            catch (DbUpdateException)
            {
                throw;
            }

        }

        public IQueryable<EquipmentInfoVM> GetEquipmentSV(int id)
        {
            return _equipment.GetEquipment(id);
        }

        public IQueryable<EquipmentBasicVM> GetListEquipmentVM()
        {
            return _equipment.GetListEquipment();
        }

        public IQueryable<EquipmentBasicVM> SearchListEquipmentVM(string eName)
        {
            return _equipment.SearchListEquipment(eName.Trim());
        }
        public Task<int> UpdateEquipmentSV(int id, EquipmentInfoVM equipment)
        {
            return _equipment.UpdateEquipment(id, equipment);
        }
    }
    public interface IEquipmentService
    {
        IQueryable<EquipmentBasicVM> GetListEquipmentVM();
        IQueryable<EquipmentBasicVM> SearchListEquipmentVM(string eName);
        Task AddEquipmentSV(EquipmentInfoVM equipment);
        Task<bool> DeleteEquipmentSV(int id);
        IQueryable<EquipmentInfoVM> GetEquipmentSV(int id);
        Task<int> UpdateEquipmentSV(int id, EquipmentInfoVM equipment);

    }
}
