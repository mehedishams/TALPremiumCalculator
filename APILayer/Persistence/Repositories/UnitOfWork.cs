using DataModel.Context;
using TALWebAPI.Persistence.Interfaces;

namespace TALWebAPI.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TALContext _TALContext;
        private IRatingRepository _RatingRepo;

        public IRatingRepository RatingRepo =>
            _RatingRepo ??= new RatingRepository(_TALContext);

        public UnitOfWork(TALContext talContext)
        {
            _TALContext = talContext;
        }
    }
}
