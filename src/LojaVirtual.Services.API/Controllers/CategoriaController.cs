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
    [EnableCors("AllowAnyOrigin")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _service;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //POST api/categoria
        [HttpPost]
        public IActionResult Post([FromBody] CategoriaCadasatroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();// 400
            }

            try
            {
                var categoria = _mapper.Map<Categoria>(model);
                _service.Inserir(categoria);

                return Ok($"Produto '{model.Nome}' cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                //INTERNAL SERVER ERROR
                return StatusCode(500, e.Message);
            }
        }

        //PUT api/categoria
        [HttpPut]
        public IActionResult Put([FromBody] CategoriaEdicaoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult(); // 400
            }

            try
            {
                var categoria = _mapper.Map<Categoria>(model);
                _service.Atualizar(model.Id, categoria);

                return Ok($"Categoria '{model.Nome}' atualizado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //DELETE api/categoria/id
        [HttpDelete("{idCategoria}")]
        public IActionResult Delete(int idCategoria)
        {
            try
            {
                var categoria = _service.ObterPorId(idCategoria);

                if (categoria == null)
                {
                    return Ok("Categoria não encontrado.");
                }

                _service.Detetar(idCategoria);

                return Ok("Categoria excluído com sucesso.");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //GET api/categoria
        [HttpGet]
        public IActionResult Get()
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

        //GET api/categoria/id
        [HttpGet("{idCategoria}")]
        public IActionResult GetById(int idCategoria)
        {
            try
            {
                var categoria = _mapper.Map<ProdutoConsultaViewModel>(_service.ObterPorId(idCategoria));

                return Ok(categoria);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
