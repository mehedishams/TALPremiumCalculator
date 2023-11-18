using DataModel.Context;
using TALWebAPI.Persistence.Interfaces;

namespace TALWebAPI.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TALDBContext BaseTalContext;
        public RepositoryBase(TALDBContext talContext)
        {
            BaseTalContext = talContext;
        }
    }
}
