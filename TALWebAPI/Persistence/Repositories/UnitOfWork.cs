using DataModel.Context;
using TALWebAPI.Persistence.Interfaces;

namespace TALWebAPI.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TALDBContext _TALContext;
        private IRatingRepository _RatingRepo;
        private IOccupationRepository _OccupationRepo;

        public IRatingRepository RatingRepo =>
            _RatingRepo ??= new RatingRepository(_TALContext);

        public IOccupationRepository OccupationRepo =>
            _OccupationRepo ??= new OccupationRepository(_TALContext);

        public UnitOfWork(TALDBContext talContext)
        {
            _TALContext = talContext;
        }
    }
}
