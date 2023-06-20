using Microsoft.EntityFrameworkCore;
using nachotime_data.Models;

namespace nachotime_data.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly NachotimeDbContext _context;

        public CardRepository(NachotimeDbContext context)
        {
            _context = context;
        }

        public async Task CreateCardAsync(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Card> GetAllCardsAsync()
        {
            return _context.Cards;
        }

        public async Task<Card?> GetCardByIdAsync(Guid id)
        {
            return await _context.Cards.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}