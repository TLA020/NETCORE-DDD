using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reservations.API.Application.Commands;
using Reservations.API.Application.Queries;
using Reservations.API.ViewModels;
using Reservations.Domain.Models;

namespace Reservations.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    public class CustomersController : ControllerBase
    {
        private readonly ICustomerQueries _queries;
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;


        public CustomersController( ILogger<CustomersController> logger, IMediator mediator, ICustomerQueries queries, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //tla: just simple boilerplating,   never tested and w.i.p
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                var created = await _mediator.Send(new CreateCustomerCommand(customer));

                if (!created)
                {
                    return BadRequest("Could not create customer");
                }
                return Ok("customer created");
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception trown: {ex}", ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _queries.GetCustomers();
                var response = _mapper.Map<List<CustomerViewModel>>(customers);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception trown: {ex}", ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            try
            {
                var customer = await _queries.GetCustomerById(id);

                if (customer == null)
                {
                    return NotFound("Customer not found");
                }

                var response = _mapper.Map<CustomerViewModel>(customer);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception trown: {ex}", ex.ToString());
                return BadRequest(ex.Message);
            }
        }

    }
}