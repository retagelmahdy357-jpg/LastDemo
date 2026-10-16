namespace LastDemo.Repo.IRepo
{
    public interface IGenericRepo<Tentity>where Tentity : class
    {
        public Task add(Tentity tentity);
        public void Update(Tentity tentity);
        public void Delete(Tentity tentity);
        public Task<Tentity> GetById(int id);
        public Task<List<Tentity>> GetAll();
    }
}
