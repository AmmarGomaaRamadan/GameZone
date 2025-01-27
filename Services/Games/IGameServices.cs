namespace GameZone.Services.Games
{
    public interface IGameServices
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task Create(CreateGameViewModel model);
        Task<Game?> Update(EditGameViewModel model);
        bool Delete(int id);
    }
}
