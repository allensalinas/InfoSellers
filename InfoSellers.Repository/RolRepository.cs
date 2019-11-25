using InfoSellers.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSellers.Repository
{
    public class RolRepository : IRepository<RolDTO, int>
    {
        public RolDTO Create(RolDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<RolDTO> Read()
        {
            using (Persistence.InfoSellersEntities data = new Persistence.InfoSellersEntities())
            {
                return data.Rol.Select(t => new RolDTO()
                {
                    ID = t.ID,
                    RolName = t.RolName,
                    CommissionTypeID = t.ID
                }).ToList();
            }
        }

        public RolDTO ReadById(int id)
        {
            using (Persistence.InfoSellersEntities data = new Persistence.InfoSellersEntities())
            {
                var entity = data.Rol.Find(id);
                if (entity != null)
                {
                    return new RolDTO()
                    {
                        ID = entity.ID,
                        RolName = entity.RolName,
                        CommissionTypeID = entity.ID
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public RolDTO Update(RolDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
