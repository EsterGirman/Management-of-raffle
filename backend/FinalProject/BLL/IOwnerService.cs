using FinalProject.Models;

namespace FinalProject.BLL
{
    public interface IOwnerService
    {
        public Owner Add(Owner Owner);
        public List<Owner> getAllOwners();
        public Owner getOwnerById(int id);
        public Owner deleteOwners(int id);
        public Owner updateOwner(int id, Owner o);
    }
}
