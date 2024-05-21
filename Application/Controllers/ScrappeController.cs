using Application.ModelBinders;
using AutoMapper;
using Contracts;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Linq;
using WebScrapperLibrary;


namespace RecogniseDesign.Controllers
{



    [Route("api/scrapper")]
    [ApiController]

    public class ScrappeController : ControllerBase
    {

        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        private readonly IMapper _mapper;
        private readonly WebScraper _webScraper;
        public ScrappeController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, WebScraper webScraper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _webScraper = webScraper;
        }



        [HttpGet, Authorize(Roles = "Administrator")]
        
        public async Task<IActionResult> ScrapeWebsite([FromQuery] int pageCount = 1)
        {
            var scrapedData = _webScraper.ScrapeWebsite("https://www.ebay.com/sch/i.html?_from=R40&_nkw=microwave&_sacat=0", pageCount);
            if (scrapedData == null)
            {
                _logger.LogError("the scaraped data is empty");
                return BadRequest("the scaraped data is empty");
            }

            var scrapedProducts = _mapper.Map<IEnumerable<ScrappedData>>(scrapedData);

            foreach (var product in scrapedProducts)
            {
                // Console.Write("inside loop");
                _repository.ScrappedData.AddProduct(product);
                Debug.WriteLine(product);
            }

            await _repository.SaveAsync();

            return Ok();
        }


        [HttpGet("products") , Authorize(Roles = "Manager, Administrator, Guest")]
        public async Task<IActionResult> GetProductsFromDb()
        {

            var items = await _repository.ScrappedData.GetScrappedDataAsync(trackChanges: false);
            if (items == null)
            {
                _logger.LogInfo($"there is no product scrapped in your database");
                return NotFound();
            }

            var productsToReturn = _mapper.Map<IEnumerable<ScrappedProductReadDto>>(items);

            return Ok(productsToReturn);

        }
        
        [HttpPost, Authorize(Roles = "Administrator, Manager")]
        public async Task<IActionResult> AddProduct([FromBody] ScrappedDataForCreationDto product)
        {
            if (product == null)
            {
                _logger.LogError($"there was no product that was sent");
                return BadRequest($"there was no product that was sent");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError($"invalid model state for adding product");
                return UnprocessableEntity(ModelState);
            }
            var productEntity = _mapper.Map<ScrappedData>(product);
            _repository.ScrappedData.AddProduct(productEntity);

            await _repository.SaveAsync();

            var productReturned = _mapper.Map<ScrappedProductReadDto>(productEntity);
            return Ok(productReturned);
        }


        [HttpGet("{productId}", Name = "ProductById"), Authorize(Roles = "Manager, Administrator, Guest")]
        public async Task<IActionResult> GetProduct(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                _logger.LogError($"there was no product id provided");
                return BadRequest($"there was no product id provided");
            }

            var productFromDb = await _repository.ScrappedData.GetProductAsync(productId, trackChanges: false);
            if (productFromDb == null)
            {
                _logger.LogInfo($"product with id: {productId} doesn't exist in the database.");
                return NotFound();
            }

            var scrappedDataDto = _mapper.Map<ScrappedProductReadDto>(productFromDb);
            return Ok(scrappedDataDto);
        }



        [HttpPut("{productId}"),  Authorize(Roles = "Manager, Administrator")]
        
        public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] ScrappedProductForUpdateDto product)
        {
            if (product == null)
            {
                _logger.LogError("ProductForUpdateDto object sent from client is null.");
                return BadRequest("ProductForUpdateDto object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ProductForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }

            var productEntity = await _repository.ScrappedData.GetProductAsync(productId, trackChanges: true);
            if (productEntity == null)
            {
                _logger.LogInfo($"Prdouct with id: {productId} doesn't exist in the database.");
                return NotFound();
            }

            _mapper.Map(product, productEntity);
            await _repository.SaveAsync();

            return NoContent();
        }



        [HttpDelete("{productId}"), Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var product = await _repository.ScrappedData.GetProductAsync(productId, trackChanges: false);
            if (product == null)
            {
                _logger.LogInfo($"Product with id: {productId} doesn't exist in the database.");
                return NotFound();
            }

            _repository.ScrappedData.DeleteProduct(product);
            await _repository.SaveAsync();

            return NoContent();
        }

    }
}


