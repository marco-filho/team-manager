using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TeamManager.Controllers.Utils;
using TeamManager.Interfaces;
using TeamManager.ViewModels;

namespace TeamManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private readonly ITimeViewModelService _timeService;

        public TimesController(ITimeViewModelService timeService) => _timeService = timeService;

        #region GET
        //Retorna todos os times
        [HttpGet]
        public IEnumerable<TimeViewModel> GetAll() => _timeService.GetAll();

        //Retorna um time pelo id com seus respectivos jogadores cadastrados
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var time = _timeService.IncludeJogadores().SingleOrDefault(t => t.Id == id);

            if (time == null)
                return NotFound(new ResponseFormatter($"Não existe time com Id {id}"));

            return Ok(time);
        }

        //Retorna todos os times com seus respectivos jogadores cadastrados
        [HttpGet("listar")]
        public IActionResult GetAllAndList()
        {
            var times = _timeService.IncludeJogadores();

            return Ok(times);
        }
        #endregion

        #region POST
        //Cria um registro
        [HttpPost]
        public IActionResult Create(TimeViewModel time)
        {
            time.DataInclusao = DateTime.UtcNow;

            _timeService.Insert(time);
            time.Id = _timeService.GetAll().Max(t => t.Id);

            return Created("", time);
        }
        #endregion

        #region PUT
        //Atualiza um registro pelo id
        [HttpPut("{id}")]
        public IActionResult Update(TimeViewModel time, int id)
        {
            try
            {
                time.Id = id;
                time.DataInclusao = DateTime.UtcNow;
                _timeService.Update(time);
            }
            catch (Exception)
            {
                return NotFound(
                    new ResponseFormatter($"Não foi possível atualizar o time com id {id}. " +
                    $"Verifique se existe um time com este id no sistema."));
            }

            return Ok(time);
        }
        #endregion

        #region DELETE
        //Exclui um registro pelo id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_timeService.Get(id) == null)
                return NotFound(new ResponseFormatter($"Não existe time com Id {id}"));

            _timeService.Delete(id);

            return Ok(new ResponseFormatter("Time excluído com sucesso."));
        }
        #endregion
    }
}
