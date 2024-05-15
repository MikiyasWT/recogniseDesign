using AutoMapper;
using Contracts;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public IActionResult ScrapeWebsite([FromQuery] int pageCount = 1)
    {
        var response = _webScraper.ScrapeWebsite("https://www.ebay.com/sch/i.html?_from=R40&_nkw=microwave&_sacat=0", pageCount);
        return Ok(response);
    }
  }
}


