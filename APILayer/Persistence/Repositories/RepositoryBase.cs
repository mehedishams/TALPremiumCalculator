using DataModel.Context;
using TALWebAPI.Persistence.Interfaces;

namespace TALWebAPI.Persistence.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TALContext BaseTalContext;
        public RepositoryBase(TALContext talContext)
        {
            BaseTalContext = talContext;
        }
    }
}
