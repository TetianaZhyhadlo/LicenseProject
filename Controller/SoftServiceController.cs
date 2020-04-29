﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LicenseProject.Models;
using LicenseProject.Service;

namespace LicenseProject.Controller
{
    [Route("api/soft")]
    [ApiController]
    public class SoftServiceController : ControllerBase
    {
        
        readonly IService<Soft> service;

        public SoftServiceController(IService<Soft> service)
        {
            this.service = service;
        }

        [HttpGet]
        public List<Soft> Get()
        {
            return service
                .GetAll();
        }

        [HttpGet("{id}")]
        public Soft Get(int id)
        {
            return service.FindById(id);
        }

        [HttpPost("save")]
        public List<Soft> Post([FromBody] Soft value)
        {
            return service
                .GetAll()
                .ToList();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           
        }

        //public SoftsController(Context context)
        //{
        //    _context = context;
        //}

        //// GET: api/Softs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Soft>>> GetSofts()
        //{
        //    return await _context.Softs.ToListAsync();
        //}

        //// GET: api/Softs/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Soft>> GetSoft(int id)
        //{
        //    var soft = await _context.Softs.FindAsync(id);

        //    if (soft == null)
        //    {
        //        return NotFound();
        //    }

        //    return soft;
        //}

        //// PUT: api/Softs/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSoft(int id, Soft soft)
        //{
        //    if (id != soft.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(soft).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SoftExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Softs
        //[HttpPost]
        //public async Task<ActionResult<Soft>> PostSoft(Soft soft)
        //{
        //    _context.Softs.Add(soft);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetSoft", new { id = soft.ID }, soft);
        //}

        //// DELETE: api/Softs/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Soft>> DeleteSoft(int id)
        //{
        //    var soft = await _context.Softs.FindAsync(id);
        //    if (soft == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Softs.Remove(soft);
        //    await _context.SaveChangesAsync();

        //    return soft;
        //}

        //private bool SoftExists(int id)
        //{
        //    return _context.Softs.Any(e => e.ID == id);
        //}
    }
}