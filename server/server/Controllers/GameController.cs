using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Models.Games;
using server.Models.Responses;
using server.Services.Interfaces;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpGet]
    public async Task<BaseResponse<IEnumerable<Game>>> GetGames()
    {
        var games = await _gameService.GetAll();
        return games;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Game game)
    {
        var response = await _gameService.Create(game);
        if (response.StatusCodes == Models.Enums.StatusCode.Error)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGame(int id)
    {
        var response = await _gameService.GetById(id);

        if (response.StatusCodes == Models.Enums.StatusCode.NotFound)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> delete(int id)
    {
        var response = await _gameService.Delete(id);

        if (response.StatusCodes == Models.Enums.StatusCode.NotFound)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpGet("serach")]
    public async Task<IActionResult> GameSearch(string title)
    {
        var response = await _gameService.SearchGame(title);

        return Ok(response);
    }

}