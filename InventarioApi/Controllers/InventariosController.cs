﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventarioApi.Data;
using InventarioApi.Models;

namespace InventarioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InventariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Inventarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventario>>> GetInventario()
        {
            return await _context.Inventario.ToListAsync();
        }

        // GET: api/Inventarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventario>> GetInventario(string id)
        {
            var inventario = await _context.Inventario.FindAsync(id);

            if (inventario == null)
            {
                return NotFound();
            }

            return inventario;
        }

        // PUT: api/Inventarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventario(string id, Inventario inventario)
        {
            if (id != inventario.Producto)
            {
                return BadRequest();
            }

            _context.Entry(inventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Inventarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventario>> PostInventario(Inventario inventario)
        {
            _context.Inventario.Add(inventario);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InventarioExists(inventario.Producto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInventario", new { id = inventario.Producto }, inventario);
        }

        // DELETE: api/Inventarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventario(string id)
        {
            var inventario = await _context.Inventario.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            _context.Inventario.Remove(inventario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventarioExists(string id)
        {
            return _context.Inventario.Any(e => e.Producto == id);
        }
    }
}
