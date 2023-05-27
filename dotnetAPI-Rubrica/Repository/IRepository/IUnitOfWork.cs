namespace dotnetAPI_footballTeam.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITeamRepository TeamRepository { get; }
        IPlayerRepository PlayerRepository { get; }
    }
}
