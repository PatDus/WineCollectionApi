using WineCollection.Entities;
using WineCollection.Models;

namespace WineCollection.Services
{
    public interface ICellarService
    {
        public int Create(CreateCellarDto dto);
        public List<CellarDto> GetAll();
        public WineCellar Get(int id);
        public void DeleteById(int id);
        public void UpdateCellar(int id);

    }
}