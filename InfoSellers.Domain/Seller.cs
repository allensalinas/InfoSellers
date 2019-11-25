using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoSellers.Domain.Model;
using InfoSellers.DTO;
using InfoSellers.EventLogger;
using InfoSellers.Repository;

namespace InfoSellers.Domain
{
    public class Seller
    {
        private const string ENCRYPTION_KEY = "12345678901234567890123456789012";
        private const string OK = "OK";
        private string ValidateEntity(SellerDTO seller)
        {
            if (seller == null)
            {
                return "Null seller";
            }
            if (String.IsNullOrEmpty(seller.Nit) || seller.Nit.Length<5 || seller.Nit.Length>20)
            {
                return "Invalid NIT";
            }
            if (String.IsNullOrEmpty(seller.FullName) || seller.FullName.Length>200)
            {
                return "Invalid fullname";
            }
            if (String.IsNullOrEmpty(seller.Phone) || seller.Phone.Length > 20)
            {
                return "Invalid phone";
            }
            if (String.IsNullOrEmpty(seller.SellerAddress) || seller.SellerAddress.Length > 200)
            {
                return "Invalid address";
            }
            if (seller.RolID<=0)
            {
                return "Invalid rol";
            }
            if (seller.PenaltyPercentage < 0 || seller.PenaltyPercentage > 100)
            {
                return "Invalid penalty percentage";
            }

            return OK;
        }

        public OperationResult<SellerDTO> Create(SellerDTO seller)
        {
            var validation = ValidateEntity(seller);
            if (validation != OK)
            {
                return new OperationResult<SellerDTO>(validation, Logger.LogEvent(validation));
            }
            try
            {
                var rol = new InfoSellers.Repository.RolRepository().ReadById(seller.RolID);
                if (rol==null)
                {
                    return new OperationResult<SellerDTO>("Specified rol was not found", Logger.LogEvent(validation));
                }
                var commissionType = new CommissionTypeRepository().ReadById(rol.CommissionTypeID);

                var repository = new InfoSellers.Repository.SellerRepository();

                seller.CurrentCommission = commissionType.CommissionValue;

                var encryptedNIT = SecurityHelper.EncryptString(ENCRYPTION_KEY, seller.Nit);
                seller.Nit = encryptedNIT;
                var newSeller = repository.Create(seller);
                return new OperationResult<SellerDTO>(seller);
            }
            catch (Exception ex)
            {
                return new OperationResult<SellerDTO>("Error creating the seller", Logger.LogEvent(ex.Message));
            }
        }

        public OperationResult<bool> Delete(int id)
        {
            if (id<=0)
            {
                return new OperationResult<bool>("Invalid id", Logger.LogEvent("Invalid id"));
            }
            try
            {
                var repository = new SellerRepository();
                var seller = repository.ReadById(id);
                if (seller!=null)
                {
                    repository.Delete(id);
                    return new OperationResult<bool>(true);
                }
                else
                {
                    return new OperationResult<bool>("The specified id was not found", Logger.LogEvent("The specified id was not found"));
                }
            }
            catch (Exception ex)
            {
                return new OperationResult<bool>("Error deleting the seller", Logger.LogEvent("Error deleting the seller"));
            }
        }

        public OperationResult<IEnumerable<SellerDTO>> ListSellers()
        {
            try
            {
                var sellers = new SellerRepository().Read();
                foreach (var item in sellers)
                {
                    item.Nit = SecurityHelper.DecryptString(ENCRYPTION_KEY, item.Nit);
                }
                return new OperationResult<IEnumerable<SellerDTO>>(sellers);
            }
            catch (Exception ex)
            {
                return new OperationResult<IEnumerable<SellerDTO>>("Error listing the sellers", Logger.LogEvent(ex.Message));
            }
        }

        public OperationResult<SellerDTO> Update(SellerDTO seller)
        {
            var validation = ValidateEntity(seller);
            if (validation != OK)
            {
                return new OperationResult<SellerDTO>(validation, Logger.LogEvent(validation));
            }
            if (seller.ID<=0)
            {
                return new OperationResult<SellerDTO>("Invalid ID", Logger.LogEvent(validation));
            }
            try
            {
                var repository = new InfoSellers.Repository.SellerRepository();
                var dbSeller = repository.ReadById(seller.ID);
                if (dbSeller == null)
                {
                    return new OperationResult<SellerDTO>("ID specified was not found", Logger.LogEvent(validation));
                }
                seller.PenaltyPercentage = dbSeller.PenaltyPercentage; //This value cannot change
                var rol = new InfoSellers.Repository.RolRepository().ReadById(seller.RolID);
                if (rol == null)
                {
                    return new OperationResult<SellerDTO>("Specified rol was not found", Logger.LogEvent(validation));
                }
                var commissionType = new CommissionTypeRepository().ReadById(rol.CommissionTypeID);
                seller.CurrentCommission = commissionType.CommissionValue;
                if (seller.Active != dbSeller.Active)
                {
                    if (!seller.Active) //Deactivating seller...
                    {
                        seller.CurrentCommission = commissionType.CommissionValue - (commissionType.CommissionValue * (dbSeller.PenaltyPercentage / 100));
                    }
                }

                var encryptedNIT = SecurityHelper.EncryptString(ENCRYPTION_KEY, seller.Nit);
                seller.Nit = encryptedNIT;

                var updatedSeller = repository.Update(seller);
                return new OperationResult<SellerDTO>(updatedSeller);
            }
            catch (Exception ex)
            {
                return new OperationResult<SellerDTO>("Error updating the seller", Logger.LogEvent(ex.Message));
            }
        }


        public OperationResult<List<RolDTO>> ListRoles()
        {
            try
            {
                return new OperationResult<List<RolDTO>>(new Repository.RolRepository().Read());
            }
            catch (Exception ex)
            {
                return new OperationResult<List<RolDTO>>("Error getting roles", Logger.LogEvent(ex.Message));
            }
        }

        public OperationResult<List<CommissionTypeDTO>> ListCommisionTypes()
        {
            try
            {
                return new OperationResult<List<CommissionTypeDTO>>(new Repository.CommissionTypeRepository().Read());
            }
            catch (Exception ex)
            {
                return new OperationResult<List<CommissionTypeDTO>>("Error getting commission types", Logger.LogEvent(ex.Message));
            }
        }
    }
}