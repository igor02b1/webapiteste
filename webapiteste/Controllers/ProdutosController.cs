﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapiteste.Context;
using webapiteste.Models;

namespace webapiteste.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public ActionResult<IEnumerable<Produto>>Get()
        {
            var produtos = _context.Produtos.AsNoTracking().ToList();

            if(produtos is null)
            {
                return NotFound("Produtos não encontrados...");
            }

            return Ok(produtos);
        }

        [HttpGet("{id:int}", Name ="ObterProduto")]
        public ActionResult<Produto> GetPorID(int id)
        {
            var produto = _context.Produtos.AsNoTracking().FirstOrDefault(x => x.ProdutoId == id);

            if(produto is null)
            {
                return NotFound("Produto não encontrado...");
            }

            return produto;
        }

        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if(produto is null)
            {
                return BadRequest();
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Produto produto)
        {
            if(id != produto.ProdutoId)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var produto = _context.Produtos.Find(id);

            if(produto is null)
            {
                return NotFound("Produto não encontrado");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);
        }
    }
}
