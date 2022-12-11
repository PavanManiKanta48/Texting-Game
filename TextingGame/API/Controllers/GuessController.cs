using Domain.GuessUser;
using Microsoft.AspNetCore.Mvc;
using Persistence.Model;
using Service.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuessController : ControllerBase
    {
        private readonly DbTextingGameContext _dbGuessContext;
        private readonly IGuessServices _GuessServices;

        public GuessController(DbTextingGameContext dbGuessContext, IGuessServices guessServices)
        {
            _dbGuessContext = dbGuessContext;
            _GuessServices = guessServices;
        }

        //[HttpGet]
        //public List<ListOfResultResponse> GetGuess()
        //{
        //    try
        //    {
        //        _GuessServices.GetGuess().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new(ex.Message);
        //    }
        //}
    }
}
