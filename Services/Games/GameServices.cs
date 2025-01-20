﻿
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
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(model.Cover.FileName)}";
            var path=Path.Combine(_coverImagePath, coverName);
            using var stream=File.Create(path);
            await model.Cover.CopyToAsync(stream);
            stream.Dispose();

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

    }
}
