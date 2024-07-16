using FinalProject.Models;

namespace FinalProject.DAL
{
    public class OwnerDal:IOwnerDal
    {
        public Context Context { get; }
        public OwnerDal(Context Context)
        {
            this.Context = Context;
        }

        public async Task<List<Owner>> getAllOwners()
        {
            try
            {
                return Context.Owners.Select(x => x).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Owner> updateOwner(int id, Owner o)
        {
            try
            {
                List<Owner> lo = Context.Owners.Select(x => x).ToList();
                Owner oo = lo.Find(x => x.Id == id);
                oo.Name = o.Name;
                oo.Password = o.Password;
                oo.Phone = o.Phone;
                Context.SaveChanges();
                return oo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Owner> getOwnerById(int id)
        {
            try
            {
                List<Owner> lo = Context.Owners.Select(x => x).ToList();
                return lo.Find(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Owner> Add(Owner Owner)
        {
            try
            {
                Context.Owners.Add(Owner);
                Context.SaveChanges();
                return Owner;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Owner> deleteOwners(int id)
        {
            try
            {
                List<Owner> lo = Context.Owners.Select(x => x).ToList();
                Owner o = lo.Find(x => x.Id == id);
                Context.Owners.Remove(o);
                return o;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
