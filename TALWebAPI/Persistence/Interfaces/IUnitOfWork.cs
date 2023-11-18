namespace TALWebAPI.Persistence.Interfaces
{
    public interface IUnitOfWork
    {
        IRatingRepository RatingRepo { get; }
        IOccupationRepository OccupationRepo { get;  }
    }
}
