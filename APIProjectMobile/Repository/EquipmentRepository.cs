using APIProjectMobile.Enum;
using APIProjectMobile.Models;
using APIProjectMobile.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProjectMobile.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ProjectMobileContext _context;

        public EquipmentRepository(ProjectMobileContext context)
        {
            _context = context;
        }

        public async Task AddEquipment(EquipmentInfoVM equipment)
        {
            TblEquipment equipmentModel = new TblEquipment();
            equipmentModel.EquipmentName = equipment.EquipmentName;
            equipmentModel.EquipmentImage = equipment.EquipmentImage;
            equipmentModel.EquipmentDes = equipment.EquipmentDes;
            equipmentModel.EquipmentQuantity = equipment.EquipmentQuantity;
            equipmentModel.EquipmentStatus = Status.AVAILABLE;
            equipmentModel.EquipmentIsDelete = IsDelete.ACTIVE;
            // change here
            _context.TblEquipment.Add(equipmentModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<bool> DeleteEquipment(int id)
        {
            var equipment = await _context.TblEquipment.FindAsync(id);
            if (equipment == null)
            {
                return false;
            }
            try
            {
                equipment.EquipmentIsDelete = IsDelete.ISDELETED;
                _context.Entry(equipment).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public IQueryable<EquipmentInfoVM> GetEquipment(int id)
        {
            var equipment = _context.TblEquipment
                                    .Where(equip => equip.EquipmentId == id && equip.EquipmentIsDelete == IsDelete.ACTIVE)
                                    .Select(eq => new EquipmentInfoVM
                                    {
                                        EquipmentId = eq.EquipmentId,
                                        EquipmentDes = eq.EquipmentDes,
                                        EquipmentImage = eq.EquipmentImage,
                                        EquipmentName = eq.EquipmentName,
                                        EquipmentQuantity = eq.EquipmentQuantity,
                                    });
            return equipment;
        }

        public IQueryable<EquipmentBasicVM> GetListEquipment()
        {
            var listEquipment = _context.TblEquipment
                                            .Where(eq => eq.EquipmentIsDelete.Equals(IsDelete.ACTIVE))
                                            .Select(eq => new EquipmentBasicVM
                                            {
                                                EquipmentId = eq.EquipmentId,
                                                EquipmentName = eq.EquipmentName,
                                                EquipmentImage = eq.EquipmentImage,
                                                EquipmentDes = eq.EquipmentDes,
                                                EquipmentQuantity = eq.EquipmentQuantity,
                                            });
            return listEquipment;
        }

        public IQueryable<EquipmentBasicVM> SearchListEquipment(string eName)
        {
            var listEquipment = _context.TblEquipment
                                            .Where(eq => eq.EquipmentName.Contains(eName) && eq.EquipmentIsDelete.Equals(IsDelete.ACTIVE))
                                            .Select(eq => new EquipmentBasicVM
                                            {
                                                EquipmentId = eq.EquipmentId,
                                                EquipmentName = eq.EquipmentName,
                                                EquipmentImage = eq.EquipmentImage,
                                                EquipmentDes = eq.EquipmentDes,
                                                EquipmentQuantity = eq.EquipmentQuantity,
                                            });
            return listEquipment;
        }
        public async Task<int> UpdateEquipment(int id, EquipmentInfoVM equipment)
        {
            TblEquipment equipmentModel = await _context.TblEquipment.FindAsync(id);
            if (equipmentModel == null) return -1;
            equipmentModel.EquipmentName = equipment.EquipmentName;
            equipmentModel.EquipmentQuantity = equipment.EquipmentQuantity;
            equipmentModel.EquipmentImage = equipment.EquipmentImage;
            equipmentModel.EquipmentDes = equipment.EquipmentDes;

            _context.Entry(equipmentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return equipmentModel.EquipmentId;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquipmentExists(id))
                {
                    return -1;
                }
                else throw;
            }
        }

        private bool EquipmentExists(int id)
        {
            return _context.TblEquipment.Any(e => e.EquipmentId == id);
        }

    }
    public interface IEquipmentRepository
    {
        IQueryable<EquipmentBasicVM> GetListEquipment();
        IQueryable<EquipmentBasicVM> SearchListEquipment(string eName);
        Task AddEquipment(EquipmentInfoVM equipment);
        Task<bool> DeleteEquipment(int id);
        IQueryable<EquipmentInfoVM> GetEquipment(int id);
        Task<int> UpdateEquipment(int id, EquipmentInfoVM equipment);
    }
}
