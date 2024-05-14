using AutoMapper;
using Contracts;
using Entities.Dto;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RecogniseDesign.Controllers
{



    [Route("api/scrapper")]
    [ApiController]
    public class ScrappeController : ControllerBase
    {

    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    private readonly IMapper _mapper;  
    public ScrappeController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
    }
  }
}


