namespace GameZone.Services.Games
{
    public interface IGameServices
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task Create(CreateGameViewModel model);
    }
}
