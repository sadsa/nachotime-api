using Microsoft.AspNetCore.Mvc;
using nachotime_api_models.Models;
using nachotime_services;

namespace nachotime_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _service;

        public CardsController(ICardService service)
        {
            _service = service;
        }

        [HttpGet()]
        async public Task<IEnumerable<CardApiModel>> Get()
        {
            return await _service.GetAllCardsAsync();
        }

        [HttpGet("{id:guid}")]
        async public Task<CardApiModel> Get(Guid id)
        {
            return await _service.GetCardByIdAsync(id);
        }

        [HttpPost()]
        async public Task Create(CardApiModel cardApiModel)
        {
            await _service.CreateCardAsync(cardApiModel);
        }

        [HttpPut()]
        async public Task Update(CardApiModel cardApiModel)
        {
            await _service.UpdateCardAsync(cardApiModel);
        }
    }
}