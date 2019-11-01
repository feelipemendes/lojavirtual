using System;
using System.Collections.Generic;
using AutoMapper;
using LojaVirtual.Application.Interfaces;
using LojaVirtual.Application.ViewModels;
using LojaVirtual.Domain.Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Services.API.Controllers
{

    [Produces("application/json")]
    [Route("api/categoria")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _service;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //POST api/categoria/cadastrar
        [HttpPost]        
        public IActionResult Cadastrar([FromBody] CategoriaCadasatroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();// 400
            }

            try
            {
                var categoria = _mapper.Map<Categoria>(model);
                _service.Inserir(categoria);

                return Ok($"Categoria '{model.Nome}' cadastrada com sucesso.");
            }
            catch (Exception e)
            {
                //INTERNAL SERVER ERROR
                return StatusCode(500, e.Message);
            }
        }

        //PUT api/categoria/atualizar
        [HttpPut("{idCategoria}")]
        public IActionResult Atualizar(string idCategoria, [FromBody] CategoriaEdicaoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult(); // 400
            }

            try
            {
                var categoria = _mapper.Map<Categoria>(model);

                categoria.Id = idCategoria;
                _service.Atualizar(idCategoria, categoria);

                return Ok($"Categoria '{model.Nome}' atualizada com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //DELETE api/categoria/excluir
        [HttpDelete("{idCategoria}")]
        public IActionResult Excluir(string idCategoria)
        {
            try
            {
                var categoria = _service.ObterPorId(idCategoria);

                if (categoria == null)
                {
                    return Ok("Categoria não encontrada.");
                }

                _service.Detetar(idCategoria);

                return Ok("Categoria excluída com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //GET api/categoria/obtertodos
        [HttpGet]        
        public IActionResult ObterTodos()
        {
            try
            {
                var list = _mapper.Map<List<CategoriaConsultaViewModel>>(_service.ObterTodos());

                return Ok(list);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //GET api/categoria/obterporid
        [HttpGet("{idCategoria}")]
        public IActionResult ObterPorId(string idCategoria)
        {
            try
            {
                var categoria = _mapper.Map<CategoriaConsultaViewModel>(_service.ObterPorId(idCategoria));

                if (categoria == null)
                {
                    return Ok("Categoria não encontrada.");
                }

                return Ok(categoria);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
