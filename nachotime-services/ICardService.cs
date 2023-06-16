using nachotime_api_models.Models;

namespace nachotime_services
{
    public interface ICardService
    {
        Task CreateCardAsync(CardApiModel cardApiModel);
        Task<IEnumerable<CardApiModel>> GetAllCardsAsync();
        Task<CardApiModel> GetCardByIdAsync(Guid id);
        Task UpdateCardAsync(CardApiModel cardApiModel);
    }
}