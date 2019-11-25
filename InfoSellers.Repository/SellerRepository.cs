using InfoSellers.DTO;
using InfoSellers.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace InfoSellers.Repository
{
    public class SellerRepository : IRepository<SellerDTO, int>
    {
        public SellerDTO Create(SellerDTO entity)
        {
            using (InfoSellersEntities data = new InfoSellersEntities())
            {
                var newSeller = new Seller()
                {
                    Nit = entity.Nit,
                    Active = entity.Active,
                    CurrentCommission = entity.CurrentCommission,
                    FullName = entity.FullName,
                    PenaltyPercentage = entity.PenaltyPercentage,
                    Phone = entity.Phone,
                    RolID = entity.RolID,
                    SellerAddress = entity.SellerAddress
                };
                data.Seller.Add(newSeller);
                data.SaveChanges();
                entity.ID = newSeller.ID;
            }
            return entity;
        }

        public void Delete(int id)
        {
            using (InfoSellersEntities data = new InfoSellersEntities())
            {
                data.Seller.Remove(data.Seller.Find(id));
                data.SaveChanges();
            }
        }

        public List<SellerDTO> Read()
        {
            using (InfoSellersEntities data = new InfoSellersEntities())
            {
                return data.Seller.Select(q => new SellerDTO()
                {
                    ID = q.ID,
                    FullName = q.FullName,
                    Active = q.Active,
                    CurrentCommission = q.CurrentCommission,
                    Nit = q.Nit,
                    PenaltyPercentage = q.PenaltyPercentage,
                    Phone = q.Phone,
                    RolID = q.RolID,
                    SellerAddress = q.SellerAddress
                }).ToList();
            }
        }

        public SellerDTO ReadById(int id)
        {
            using (InfoSellersEntities data = new InfoSellersEntities())
            {
                var entity = data.Seller.Find(id);
                if (entity != null)
                {
                    return new SellerDTO()
                    {
                        ID = entity.ID,
                        FullName = entity.FullName,
                        Active = entity.Active,
                        CurrentCommission = entity.CurrentCommission,
                        Nit = entity.Nit,
                        PenaltyPercentage = entity.PenaltyPercentage,
                        Phone = entity.Phone,
                        RolID = entity.RolID,
                        SellerAddress = entity.SellerAddress
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public SellerDTO Update(SellerDTO entity)
        {
            using (InfoSellersEntities data = new InfoSellersEntities())
            {
                var d = data.Seller.Find(entity.ID);
                d.Nit = entity.Nit;
                d.FullName = entity.FullName;
                d.PenaltyPercentage = entity.PenaltyPercentage;
                d.Phone = entity.Phone;
                d.RolID = entity.RolID;
                d.SellerAddress = entity.SellerAddress;
                d.Active = entity.Active;
                d.CurrentCommission = entity.CurrentCommission;
            }
            return entity;
        }
    }
}