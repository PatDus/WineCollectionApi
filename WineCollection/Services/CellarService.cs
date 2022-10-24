using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WineCollection.Authorization;
using WineCollection.Entities;
using WineCollection.Exceptions;
using WineCollection.Models;

namespace WineCollection.Services
{
    public class CellarService : ICellarService
    {

        private readonly WineCollectionDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserContextService _userContextService;

        public CellarService(WineCollectionDbContext dbContext, IMapper mapper, IAuthorizationService authorizationService, IUserContextService userContextService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _authorizationService = authorizationService;
            _userContextService = userContextService;
        }

        public int Create(CreateCellarDto dto)
        {
            var newCellar = _mapper.Map<WineCellar>(dto);
            newCellar.UserId = (int)_userContextService.GetUserId;

            _dbContext.Add(newCellar);
            _dbContext.SaveChanges();


            return newCellar.Id;
        }


        public List<CellarDto> GetAll()
        {
            int userId = (int)_userContextService.GetUserId;

            Console.WriteLine(userId);
            var cellars = _dbContext.WineCellars
                .Where(wc => wc.UserId == userId)
                .Include(wc => wc.Wines)
                .ToList();

            if (cellars is null || cellars.Count == 0)
                throw new NotFoundException("There is no user's cellars");

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, cellars[0],
                new WineCellarOperationRequirement(ResourceOperation.Read)).Result;

            if (!authorizationResult.Succeeded)
                throw new ForbidException("You are not permitted to access this resource");

            var cellarDtos = _mapper.Map<List<CellarDto>>(cellars);
            return cellarDtos;
        }

        public WineCellar Get(int id)
        {
            int userId = (int)_userContextService.GetUserId;

            var cellar = _dbContext.WineCellars
                .Include(wc => wc.Wines)
                .FirstOrDefault(wc => wc.Id == id && wc.UserId == userId);

            if (cellar is null)
                throw new NotFoundException("Cellar not found");

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, cellar,
                new WineCellarOperationRequirement(ResourceOperation.Read)).Result;

            if (!authorizationResult.Succeeded)
                throw new ForbidException("You are not permitted to access this resource");

            var cellarDto = _mapper.Map<CellarDto>(cellar);
            return cellar;
        }

        public void DeleteById(int id)
        {
            int userId = (int)_userContextService.GetUserId;
            var cellar = _dbContext.WineCellars
                .FirstOrDefault(wc => wc.Id == id && wc.UserId == userId);

            if (cellar is null)
                throw new NotFoundException("Cellar not found");

            var authorizationResult = _authorizationService.AuthorizeAsync(_userContextService.User, cellar,
                new WineCellarOperationRequirement(ResourceOperation.Delete)).Result;

            if (!authorizationResult.Succeeded)
                throw new ForbidException("You are not permitted to delete this resource");

            var cellarDto = _mapper.Map<CellarDto>(cellar);
            _dbContext.Remove(cellarDto);
            _dbContext.SaveChanges();
        }

        //not finished
        public void UpdateCellar(int id)
        {
            var cellar = _dbContext.WineCellars
                .FirstOrDefault(wc => wc.Id == id);


            if (cellar is null)
                throw new NotFoundException("Cellar not found");
        }

    }
}
