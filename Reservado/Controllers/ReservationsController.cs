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

    public class ReservationsController : ControllerBase
    {
        private readonly IReservationQueries _queries;
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationQueries queries, ILogger<ReservationsController> logger, IMediator mediator, IMapper mapper)
        {
            _queries = queries;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //tla: just simple boilerplating,   never tested and w.i.p

        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            try
            {
                var reservations = await _queries.GetReservations();

                var response = _mapper.Map<List<ReservationViewModel>>(reservations);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception trown: {ex}", ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(Guid id)
        {
            try
            {
                var reservation = await _queries.GetReservationByID(id);

                if (reservation == null)
                {
                    return NotFound("Reservation not found");
                }

                var response = _mapper.Map<ReservationViewModel>(reservation);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception trown: {ex}", ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] Reservation reservation)
        {
            try
            {
                var created = await _mediator.Send(new CreateReservationCommand(reservation));

                if (!created)
                {
                    return BadRequest("Could not create reservation");
                }
                return Ok("reservation created");
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception trown: {ex}", ex.ToString());
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(Guid id)
        {
            try
            {
                var deleted = await _mediator.Send(new DeleteReservationCommand(id));

                if (!deleted)
                {
                    return BadRequest("Could not delete reservation");
                }

                return Ok("reservation deleted");
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception trown: {ex}", ex.ToString());
                return BadRequest(ex.Message);
            }
        }

    }
}