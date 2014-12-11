namespace Ktoto.Neprav.DAL
{
    public class InMemoryDalFactory: IDalFactory
    {
        public IDal Create()
        {
            return new InMemoryDal();
        }
    }
}