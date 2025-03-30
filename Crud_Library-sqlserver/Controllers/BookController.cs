using Crud_Library_sqlserver.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;
using Crud_Library_sqlserver.Models;
using Crud_Library_sqlserver.Dto;

namespace Crud_Library_sqlserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IbookInterface _bookInterface;

        public BookController(IbookInterface bookInterface)
        {
            _bookInterface = bookInterface;
        }

        [HttpGet]
        public async Task<IActionResult> BuscarBook()
        {
            var books = await _bookInterface.BuscarBook();
            return Ok(books);
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult> BuscarBookPorId(int bookId)
        {
            var book = await _bookInterface.BuscarBookPorId(bookId);

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> CriarBook(BookCriarDto bookCriarDto)
        {
            var books = await _bookInterface.CriarBook(bookCriarDto);
            return Ok(books);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarBook(int id, [FromBody] BookEditarDto bookEditarDto)
        {
            if (id != bookEditarDto.Id)
            {
                return BadRequest("O ID da URL não corresponde ao ID do objeto.");
            }

            var books = await _bookInterface.EditarBook(bookEditarDto);

            return Ok(books);
        }


        [HttpDelete]
        public async Task<IActionResult> RemoverBook(int bookId)

        {
            var books = await _bookInterface.RemoverBook(bookId);

            return Ok(books);
        }
    }
}
