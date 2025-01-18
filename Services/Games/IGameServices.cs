namespace GameZone.Services.Games
{
    public interface IGameServices
    {
         Task Create(CreateGameViewModel model);
        IEnumerable<Game> GetAll();
    }
}
