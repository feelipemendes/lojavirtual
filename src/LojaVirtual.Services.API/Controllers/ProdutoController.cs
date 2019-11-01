using AutoMapper;
using LojaVirtual.Application.Interfaces;
using LojaVirtual.Application.Utils;
using LojaVirtual.Application.ViewModels;
using LojaVirtual.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace LojaVirtual.Services.API.Controllers
{
    [Produces("application/json")]
    [Route("api/produto")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _service;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //POST: api/produto/cadastrar
        [HttpPost]
        public IActionResult Cadastrar([FromBody] ProdutoCadastroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ValidationUtil.GetErrors(ModelState));// 400
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

        //PUT api/produto/atualizar
        [HttpPut]
        public IActionResult Atualizar([FromBody] ProdutoEdicaoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ValidationUtil.GetErrors(ModelState));// 400
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

        //DELETE api/produto/excluir
        [HttpDelete("{idProduto}")]
        public IActionResult Excluir(string idProduto)
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

        ////GET api/produto/obtertodos
        [HttpGet]
        public IActionResult ObterTodos()
        {
            try
            {
                var list = _mapper.Map<List<ProdutoConsultaViewModel>>
                                (_service.ObterTodos());

                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //GET api/produto/obterporid
        [HttpGet("{idProduto}")]
        public IActionResult ObterPorId(string idProduto)
        {
            try
            {
                var produto = _mapper.Map<ProdutoConsultaViewModel>(_service.ObterPorId(idProduto));

                if (produto == null)
                {
                    return Ok("Produto não encontrado.");
                }

                return Ok(produto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}