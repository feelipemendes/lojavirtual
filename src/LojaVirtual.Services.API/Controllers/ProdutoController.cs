using AutoMapper;
using LojaVirtual.Application.Interfaces;
using LojaVirtual.Application.ViewModels;
using LojaVirtual.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LojaVirtual.Services.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Produto")]
    [EnableCors("AllowAnyOrigin")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _service;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //POST api/produto
        [HttpPost]        
        public IActionResult Post([FromBody] ProdutoCadastroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();// 400
            }

            try
            {
                var produto = _mapper.Map<Produto>(model);
                _service.Inserir(produto);

                return Ok($"Produto '{model.Nome}' cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                //INTERNAL SERVER ERROR
                return StatusCode(500, e.Message);
            }
        }

        //PUT api/produto
        [HttpPut]
        public IActionResult Put([FromBody] ProdutoEdicaoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult(); // 400
            }

            try
            {
                var produto = _mapper.Map<Produto>(model);
                _service.Atualizar(model.Id, produto);

                return Ok($"Produto '{model.Nome}' atualizado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //DELETE api/produto/id
        [HttpDelete("{idProduto}")]
        public IActionResult Delete(int idProduto)
        {
            try
            {
                var produto = _service.ObterPorId(idProduto);

                if (produto == null)
                {
                    return Ok("Produto não encontrado.");
                }

                _service.Detetar(idProduto);

                return Ok("Produto excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //GET api/produto
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = _mapper.Map<List<ProdutoConsultaViewModel>>(_service.ObterTodos());

                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //GET api/produto/id
        [HttpGet("{idProduto}")]
        public IActionResult GetById(int idProduto)
        {
            try
            {
                var produto = _mapper.Map<ProdutoConsultaViewModel>(_service.ObterPorId(idProduto));

                return Ok(produto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}