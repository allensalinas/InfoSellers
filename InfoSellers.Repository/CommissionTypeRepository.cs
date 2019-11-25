using InfoSellers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSellers.Repository
{
    public class CommissionTypeRepository : IRepository<CommissionTypeDTO, int>
    {
        public CommissionTypeDTO Create(CommissionTypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CommissionTypeDTO> Read()
        {
            using (Persistence.InfoSellersEntities data = new Persistence.InfoSellersEntities())
            {
                return data.CommissionType.Select(t => new CommissionTypeDTO()
                {
                    ID = t.ID,
                    CommissionTypeName = t.CommissionTypeName,
                    CommissionValue = t.CommissionValue
                }).ToList();
            }
        }

        public CommissionTypeDTO ReadById(int id)
        {
            using (Persistence.InfoSellersEntities data = new Persistence.InfoSellersEntities())
            {
                var entity = data.CommissionType.Find(id);
                if (entity != null)
                {
                    return new CommissionTypeDTO()
                    {
                        ID = entity.ID,
                        CommissionTypeName = entity.CommissionTypeName,
                        CommissionValue = entity.CommissionValue
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public CommissionTypeDTO Update(CommissionTypeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
