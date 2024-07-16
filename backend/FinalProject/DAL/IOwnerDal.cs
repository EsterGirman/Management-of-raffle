using FinalProject.Models;

namespace FinalProject.DAL
{
    public interface IOwnerDal
    {
        public Task<Owner> Add(Owner Owner);
        public Task<List<Owner>> getAllOwners();
        public Task<Owner> getOwnerById(int id);
        public Task<Owner> deleteOwners(int id);
        public Task<Owner> updateOwner(int id, Owner o);
    }
}
