using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TeamManager.Controllers.Utils;
using TeamManager.Interfaces;
using TeamManager.ViewModels;

namespace TeamManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JogadoresController : ControllerBase
    {
        private readonly IJogadorViewModelService _jogadorService;
        private readonly ITimeViewModelService _timeService;

        public JogadoresController(IJogadorViewModelService jogadorService, ITimeViewModelService timeService)
        {
            _jogadorService = jogadorService;
            _timeService = timeService;
        }

        #region GET
        //Retorna todos os jogadores
        [HttpGet]
        public IEnumerable<JogadorViewModel> GetAll() => _jogadorService.GetAll();

        //Retorna um jogador pelo id
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            var jogador = _jogadorService.Get(id);
            if (jogador == null)
                return NotFound(new ResponseFormatter($"Não existe jogador com Id {id}"));
            return Ok(jogador);
        }

        //Retorna todos os jogadores pelo TimeId
        [HttpGet("TimeId/{timeId}")]
        public IActionResult GetByTimeId(int timeId)
        {
            if (_timeService.GetAll().FirstOrDefault(t => t.Id == timeId) == null)
                return NotFound(new ResponseFormatter($"Não existe time com Id {timeId}"));

            var jogadores = _jogadorService.GetAll().Where(j => j.TimeId == timeId);
            if (jogadores.Count() == 0)
                return Ok(new ResponseFormatter($"O time com id {timeId} ainda não tem jogadores cadastrados."));

            return Ok(jogadores);
        }

        //Retorna todos os jogadores pelo intervalo de idade min-max
        [HttpGet("Idade")]
        public IActionResult GetByIdade(int max = 100, int min = 18)
        {
            if (min > max)
                return BadRequest(new ResponseFormatter($"O parâmetro 'min' não pode ser maior que o parâmetro 'max'"));

            var jogadores = _jogadorService.GetAll().Where(j => j.Idade >= min && j.Idade <= max);

            if (jogadores.Count() == 0)
                return NotFound(new ResponseFormatter($"Não existem jogadores cadastrados na faixa de idade {min}-{max}"));

            return Ok(jogadores);
        }
        #endregion

        #region POST
        //Cria um registro
        [HttpPost]
        public IActionResult Create(JogadorViewModel jogador)
        {
            if (_timeService.GetAll().FirstOrDefault(t => t.Id == jogador.TimeId) == null)
                return NotFound(new ResponseFormatter($"Não existe time com Id {jogador.TimeId}"));

            _jogadorService.Insert(jogador);
            jogador.Id = _jogadorService.GetAll().Max(j => j.Id);

            return Created("", jogador);
        }
        #endregion

        #region PUT
        //Atualiza um registro pelo id
        [HttpPut("{id}")]
        public IActionResult Update(JogadorViewModel jogador, int id)
        {
            try
            {
                if (_timeService.GetAll().FirstOrDefault(t => t.Id == jogador.TimeId) == null)
                    return NotFound(new ResponseFormatter($"Não existe time com Id {jogador.TimeId}"));
                jogador.Id = id;
                _jogadorService.Update(jogador);
            }
            catch (System.Exception)
            {
                return NotFound(
                    new ResponseFormatter($"Não foi possível atualizar o jogador com id {id}. " +
                    $"Verifique se existe um jogador com este id no sistema."));
            }

            return Ok(jogador);
        }
        #endregion

        #region DELETE
        //Exclui um registro pelo id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_jogadorService.Get(id) == null)
                return NotFound(new ResponseFormatter($"Não existe jogador com Id {id}"));

            _jogadorService.Delete(id);

            return Ok(new ResponseFormatter("Jogador excluído com sucesso."));
        }
        #endregion
    }
}
