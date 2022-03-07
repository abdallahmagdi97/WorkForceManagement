﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WFM.Data;
using WFM.Models;
using Microsoft.AspNetCore.Authorization;
using WFM.Models.Filter;
using WFM.Models.Wrappers;

namespace WFM.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket([FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var tickets = await _context.Ticket.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToListAsync();
            var ticketList = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                var ticketSkills = await _context.TicketSkills.Where(t => t.TicketRefId == ticket.Id).ToListAsync();
                var skills = new List<int>();
                foreach (var skill in ticketSkills)
                {
                    if (!skills.Contains(skill.SkillRefId))
                    {
                        skills.Add(skill.SkillRefId);
                    }
                }
                ticket.Skills = skills;
                ticketList.Add(ticket);
            }
            return Ok(new PagedResponse<List<Ticket>>(ticketList, validFilter.PageNumber, validFilter.PageSize, ticketList.Count()));
        }

        // GET: api/Tickets/5
        [Route("GetTicketById/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }
            var ticketSkills = await _context.TicketSkills.Where(t => t.TicketRefId == id).ToListAsync();
            var skills = new List<int>();
            foreach (var skill in ticketSkills)
            {
                if (!skills.Contains(skill.SkillRefId))
                {
                    skills.Add(skill.SkillRefId);
                }
            }
            ticket.Skills = skills;
            return ticket;
        }
        // GET: api/Customers/GetStatusTickets/5
        [Route("GetStatusTickets/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetStatusTickets(int id, [FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var tickets = await _context.Ticket.Where(x => x.StatusRefId == id).Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToListAsync();

            var ticketSkills = await _context.TicketSkills.Where(t => t.TicketRefId == id).ToListAsync();
            var skills = new List<int>();
            var ticketList = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                foreach (var skill in ticketSkills)
                {
                    if (!skills.Contains(skill.SkillRefId))
                    {
                        skills.Add(skill.SkillRefId);
                    }
                }
                ticket.Skills = skills;
                ticketList.Add(ticket);
            }
            return Ok(new PagedResponse<List<Ticket>>(ticketList, validFilter.PageNumber, validFilter.PageSize, ticketList.Count()));
        }
        // GET: api/Customers/GetTechTickets/5
        [Route("GetTechTickets/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTechTickets(int id, [FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var tickets = await _context.Ticket.Where(x => x.TechRefId == id).Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToListAsync();
            var ticketSkills = await _context.TicketSkills.Where(t => t.TicketRefId == id).ToListAsync();
            var skills = new List<int>();
            var ticketList = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                foreach (var skill in ticketSkills)
                {
                    if (!skills.Contains(skill.SkillRefId))
                    {
                        skills.Add(skill.SkillRefId);
                    }
                }
                ticket.Skills = skills;
                ticketList.Add(ticket);
            }
            return Ok(new PagedResponse<List<Ticket>>(ticketList, validFilter.PageNumber, validFilter.PageSize, ticketList.Count())); ;
        }
        // GET: api/Customers/GetCustomerMeters/5
        [Route("GetCustomerTickets/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetCustomerTickets(int id, [FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var tickets = await _context.Ticket.Where(x => x.CustomerRefId == id).Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToListAsync();
            var ticketSkills = await _context.TicketSkills.Where(t => t.TicketRefId == id).ToListAsync();
            var skills = new List<int>();
            var ticketList = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                foreach (var skill in ticketSkills)
                {
                    if (!skills.Contains(skill.SkillRefId))
                    {
                        skills.Add(skill.SkillRefId);
                    }
                }
                ticket.Skills = skills;
                ticketList.Add(ticket);
            }
            return Ok(new PagedResponse<List<Ticket>>(ticketList, validFilter.PageNumber, validFilter.PageSize, ticketList.Count()));
        }
        // GET: api/Customers/GetMeterTickets/5
        [Route("GetMeterTickets/{id}")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetMeterTickets(int id, [FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var tickets = await _context.Ticket.Where(x => x.MeterRefId == id).Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToListAsync();
            var ticketSkills = await _context.TicketSkills.Where(t => t.TicketRefId == id).ToListAsync();
            var skills = new List<int>();
            var ticketList = new List<Ticket>();
            foreach (var ticket in tickets)
            {
                foreach (var skill in ticketSkills)
                {
                    if (!skills.Contains(skill.SkillRefId))
                    {
                        skills.Add(skill.SkillRefId);
                    }
                }
                ticket.Skills = skills;
                ticketList.Add(ticket);
            }
            return Ok(new PagedResponse<List<Ticket>>(ticketList, validFilter.PageNumber, validFilter.PageSize, ticketList.Count()));
        }
        // PUT: api/Tickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return BadRequest();
            }
            ticket.LastUpdateDate = DateTime.Now;
            if (ticket.Skills == null)
            {
                ticket.Skills = new List<int>();
            }
            _context.Entry(ticket).State = EntityState.Modified;
            _context.TicketSkills.RemoveRange(_context.TicketSkills.Where(t => t.TicketRefId == id).ToArray());
            foreach (var skill in ticket.Skills)
            {
                var ticketSkill = new TicketSkills() { TicketRefId = id, SkillRefId = skill };
                    _context.TicketSkills.Add(ticketSkill);
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Ticket updated successfully" });
        }

        // POST: api/Tickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            ticket.CreationDate = DateTime.Now;
            _context.Ticket.Add(ticket);
            await _context.SaveChangesAsync();
            foreach (var skill in ticket.Skills)
            {
                var ticketSkill = new TicketSkills() { TicketRefId = ticket.Id, SkillRefId = skill };
                _context.TicketSkills.Add(ticketSkill);
            }
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // POST: api/Customer/QueryParam
        [Route("SearchTickets")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Ticket>>> SearchTicket([FromBody] Models.TicketSearchModel ticket, [FromQuery] PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            int customerId = 0;
            int meterId = 0;
            if (!string.IsNullOrEmpty(ticket.MeterNumber.TrimEnd()))
            {
                var meter = _context.Meter.Where(m => m.Number.Contains(ticket.MeterNumber)).FirstOrDefault();
                meterId = meter.Id;
            }
            if (!string.IsNullOrEmpty(ticket.CustomerNationalId.TrimEnd()))
            {
                var customer = _context.Customer.Where(m => m.NationalID.Contains(ticket.CustomerNationalId)).FirstOrDefault();
                customerId = customer.Id;
            }
            if (!string.IsNullOrEmpty(ticket.CustomerName.TrimEnd()))
            {
                var customer = _context.Customer.Where(m => m.Name.Contains(ticket.CustomerName)).FirstOrDefault();
                customerId = customer.Id;
            }
            if (!string.IsNullOrEmpty(ticket.CustomerMobile.TrimEnd()))
            {
                var customer = _context.Customer.Where(m => m.Mobile.Contains(ticket.CustomerMobile)).FirstOrDefault();
                customerId = customer.Id;
            }
            var tickets = await _context.Ticket.Where(t => t.CustomerRefId == customerId || t.MeterRefId == meterId).Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToListAsync();
            if (tickets.Count() == 0)
            {
                tickets = await _context.Ticket.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize).ToListAsync();
            }
            return Ok(new PagedResponse<List<Ticket>>(tickets, validFilter.PageNumber, validFilter.PageSize, tickets.Count()));
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> DeleteTicket(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();

            var ticketSkills = await _context.TicketSkills.Where(ts => ts.TicketRefId == id).ToListAsync();
            if (ticketSkills.Count == 0)
                return ticket;
            foreach (var ticketSkill in ticketSkills)
                _context.TicketSkills.Remove(ticketSkill);
            return StatusCode(StatusCodes.Status200OK, new Response { Status = "Success", Message = "Ticket deleted successfully" });
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
