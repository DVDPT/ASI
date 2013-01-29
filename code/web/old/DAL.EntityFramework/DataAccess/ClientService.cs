using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
    public class ClientService : IClientService
    {
        private ASITechContext _ctx;

        public ClientService(ASITechContext ctx)
        {
            _ctx = ctx;
        }

        public IClient Get(int key)
        {
            return _ctx.Clients.SingleOrDefault(c => c.Id == key);
        }

        public IQueryable<IClient> Query()
        {
            return _ctx.Clients;
        }

        public void Create(IClient obj)
        {
            _ctx.Clients.Add(obj as Client);
        }

        public void Update(IClient obj)
        {
        }

        public void Delete(IClient obj)
        {
            _ctx.Clients.Remove(obj as Client);
        }

        public void Delete(int key)
        {
            Delete(Get(key));
        }
    }
}
