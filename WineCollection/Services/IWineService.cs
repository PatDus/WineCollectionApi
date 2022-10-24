using WineCollection.Models;

namespace WineCollection.Services
{
    public interface IWineService
    {
        int Create(int cellarId, CreateWineDto dto);
        List<WineDto> GetAll();
        WineDto GetById(int id);
        void DeleteById(int id);
        void UpdateWine(int id, int wineCellarId, UpdateWineDto dto);
    }
}