

using nachotime_data.Models;

namespace nachotime_data.Repository
{
    public interface ICardRepository
    {
        Task CreateCardAsync(Card card);
        IQueryable<Card> GetAllCardsAsync();
        Task<Card?> GetCardByIdAsync(Guid id);
        Task UpdateCardAsync(Card card);
    }
}