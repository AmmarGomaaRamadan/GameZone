
using GameZone.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GameZone.Services.Games
{
    public class GameServices : IGameServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _coverImagePath;

        public GameServices(ApplicationDbContext applicationDbContext,IWebHostEnvironment webHostEnvironment)
        {
            _context = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
            _coverImagePath = $"{webHostEnvironment.WebRootPath}/{Settings.filePath}";
        }
        public IEnumerable<Game> GetAll()
        {
            return _context.Games.Include(g => g.Category).Include(g => g.GameDevices)
                .ThenInclude(gd => gd.Device).AsNoTracking().ToList<Game>();
        }

        public Game? GetById(int id)
        {
            return _context.Games.Include(g => g.Category).Include(g => g.GameDevices)
                 .ThenInclude(gd => gd.Device).AsNoTracking().SingleOrDefault(g => g.Id == id);

        }
        public async Task Create(CreateGameViewModel model)
        {
            var coverName = await saveimage(model.Cover);

            Game game = new()
            {
                Name = model.Name,
                Description = model.Description,
                Cover = coverName,
                CategoryId = model.CategoryId,

                GameDevices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()

            };
            _context.Add(game);
            _context.SaveChanges();
        }

        public async Task<Game?>  Update(EditGameViewModel model)
        {
            var Game = _context.Games.Include(g=>g.GameDevices).SingleOrDefault(g=>g.Id==model.Id);

            bool newcover = model.Cover is not null;
            var currentCover=Game.Cover;

            if (Game == null)
                return null;

            Game.Name= model.Name;
            Game.Description= model.Description;
            Game.CategoryId= model.CategoryId;
            Game.GameDevices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();
           
            if (newcover)
            {
             Game.Cover = await saveimage(model.Cover!);
            }
           
            var effectedRows= _context.SaveChanges();
            if(effectedRows > 0)
            {
                var cover = Path.Combine(Settings.filePath, currentCover);
                File.Delete(cover);
            }
            else
            {
                var cover = Path.Combine(Settings.filePath, Game.Cover);
                File.Delete(cover);
                return null;
            }
            return Game;
        }
        [HttpDelete]
        public bool Delete(int id)
        {
            bool deleted = false;
            var game = _context.Games.Find(id);
            if (game is null)
            {
                return deleted;
            }
            _context.Remove(game);
            int effected = _context.SaveChanges();
            if (effected > 0)
            {
                var cover = Path.Combine(_coverImagePath, game.Cover);
                File.Delete(cover);
                deleted = true;
            }
            return deleted;
        }
        private async Task<string> saveimage(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_coverImagePath, coverName);
            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);
            stream.Dispose();
            return coverName;
        }

    }
}
