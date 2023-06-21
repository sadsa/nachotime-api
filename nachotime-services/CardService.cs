using AutoMapper;
using Microsoft.EntityFrameworkCore;
using nachotime_api_models.Models;
using nachotime_common.Exceptions;
using nachotime_data.Models;
using nachotime_data.Repository;

namespace nachotime_services;

public class CardService : ICardService
{

    private readonly ICardRepository _repository;
    private readonly IMapper _mapper;

    public CardService(ICardRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task CreateCardAsync(CardApiModel cardApiModel)
    {
        Card card = _mapper.Map<Card>(cardApiModel);
        await _repository.CreateCardAsync(card);
    }

    public async Task<IEnumerable<CardApiModel>> GetAllCardsAsync()
    {
        var dbCards = await _repository.GetAllCardsAsync().ToListAsync();
        return _mapper.Map<IEnumerable<CardApiModel>>(dbCards);
    }

    public async Task<CardApiModel> GetCardByIdAsync(Guid id)
    {
        var dbCard = await _repository.GetCardByIdAsync(id);
        if (dbCard == null) throw new NotFoundException();
        return _mapper.Map<CardApiModel>(dbCard);
    }

    public async Task UpdateCardAsync(CardApiModel cardApiModel)
    {
        var dbCard = await _repository.GetCardByIdAsync(cardApiModel.Id);
        if (dbCard == null) throw new NotFoundException(nameof(dbCard));
        _mapper.Map<CardApiModel, Card>(cardApiModel, dbCard);
        await _repository.SaveChangesAsync();
    }
}
