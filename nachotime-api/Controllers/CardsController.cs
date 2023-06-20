using Microsoft.AspNetCore.Authorization;
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
        [Authorize("read:cards")]
        public async Task<IEnumerable<CardApiModel>> Get()
        {
            return await _service.GetAllCardsAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<CardApiModel> Get(Guid id)
        {
            return await _service.GetCardByIdAsync(id);
        }

        [HttpPost()]
        public async Task Create(CardApiModel cardApiModel)
        {
            await _service.CreateCardAsync(cardApiModel);
        }

        [HttpPut()]
        public async Task Update(CardApiModel cardApiModel)
        {
            await _service.UpdateCardAsync(cardApiModel);
        }
    }
}