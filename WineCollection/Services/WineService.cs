using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WineCollection.Authorization;
using WineCollection.Entities;
using WineCollection.Exceptions;
using WineCollection.Models;

namespace WineCollection.Services
{
    public class WineService : IWineService
    {
        private readonly WineCollectionDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public WineService(WineCollectionDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }



        public WineDto GetById(int id)
        {
            int userId = (int)_userContextService.GetUserId;
            var wine = _dbContext.Wines
                    .Include(w => w.Color)
                    .Include(w => w.GrapeVariety)
                    .Include(w => w.Vineyard).ThenInclude(v => v.Country)
                    .FirstOrDefault(w => w.Id == id && w.UserId == userId);

            if (wine is null)
                throw new NotFoundException("Wine not found");

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, wine,
               new WineOperationRequirement(ResourceOperation.Read)).Result;

            if (!authorizationResult.Succeeded)
                throw new ForbidException("You are not permitted to access this resource");

            var result = _mapper.Map<WineDto>(wine);
            return result;
        }


        public List<WineDto> GetAll()
        {
            int userId = (int)_userContextService.GetUserId;

            var wines = _dbContext.Wines
                .Include(w => w.Color)
                .Include(w => w.GrapeVariety)
                .Include(w => w.Vineyard).ThenInclude(v => v.Country)
                .Where(w => w.UserId == userId)
                .ToList();

            if (wines is null || wines.Count == 0)
                throw new NotFoundException("Wines not found");

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, wines[0],
               new WineOperationRequirement(ResourceOperation.Read)).Result;

            if (!authorizationResult.Succeeded)
                throw new ForbidException("You are not permitted to access this resource");

            var winesDtos = _mapper.Map<List<WineDto>>(wines);

            return winesDtos;
        }

        public int Create(int wineCellarId, CreateWineDto dto)
        {
            int userId = (int)_userContextService.GetUserId;
            var cellar = _dbContext.WineCellars.FirstOrDefault(c => c.Id == wineCellarId);

            var winesAmountInCellar = _dbContext.Wines
                .Where(w => w.WineCellarId == wineCellarId)
                .Count();
            if (winesAmountInCellar >= cellar.Capacity)
            {
                throw new CellarIsFullException("Your cellar is full");
            };

            if (cellar is null)
                throw new NotFoundException("Cellar not found");




            var wine = _mapper.Map<Wine>(dto);
            wine.WineCellarId = wineCellarId;
            wine.UserId = userId;


            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, cellar,
              new WineCellarOperationRequirement(ResourceOperation.Create)).Result;

            if (!authorizationResult.Succeeded)
                throw new ForbidException("You are not permitted to create this resource");

            _dbContext.Add(wine);
            _dbContext.SaveChanges();

            return wine.Id;
        }

        //not finished
        public void UpdateWine(int id, int wineCellarId, UpdateWineDto dto)
        {

            var wine = _dbContext
                .Wines
                .FirstOrDefault(w => w.Id == id && w.WineCellarId == wineCellarId);

            if (wine is null)
                throw new NotFoundException("Wine not found");

            //var wineDto = _mapper.Map<Wine>(dto);

            wine.Name = dto.Name;

            //_dbContext.Update(wine);
            // _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            int userId = (int)_userContextService.GetUserId;

            var wine = _dbContext.Wines
                .FirstOrDefault(w => w.Id == id && w.UserId == userId);

            if (wine is null)
                throw new NotFoundException("Wine not found");

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, wine,
              new WineOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
                throw new ForbidException("You are not permitted to delete this resource");

            _dbContext.Remove(wine);
            _dbContext.SaveChanges();
        }


    }
}

