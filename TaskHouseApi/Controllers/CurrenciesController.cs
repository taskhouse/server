using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskHouseApi.Model;
using TaskHouseApi.Persistence.UnitOfWork;
using TaskHouseApi.Service;

namespace TaskHouseApi.Controllers
{
    [Route("api/[controller]")]
    public class CurrenciesController : Controller
    {
        private ICurrencyRESTService service;
        private IUnitOfWork unitOfWork;

        // constructor injects registered repository
        public CurrenciesController(IUnitOfWork unitOfWork, ICurrencyRESTService service)
        {
            this.unitOfWork = unitOfWork;
            this.service = service;
        }

        // GET: api/Currencies/
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Currency c = await service.GetCurrenciesAsync();

            Currency exists = unitOfWork.Currencies.Retrieve(1);

            if (c == null)
            {
                return NotFound(); // 404 Resource not found
            }

            if (exists != null)
            {
                return new ObjectResult(c);
            }

            unitOfWork.Currencies.Create(c);
            unitOfWork.Save();

            return new ObjectResult(c);
        }

        // GET: api/Currencies/[id]
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            Currency c = unitOfWork.Currencies.Retrieve(Id);
            if (c == null)
            {
                return NotFound(); // 404 Resource not found
            }

            return new ObjectResult(c); // 200 ok
        }
    }
}
