using AutoMapper;
using Crud_Library_sqlserver.Dto;
using Crud_Library_sqlserver.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Crud_Library_sqlserver.Services
{
    public class BookService : IbookInterface
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public BookService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseModel<BookListarDto>> BuscarBookPorId(int bookId)
        {
             ResponseModel < BookListarDto > response = new ResponseModel<BookListarDto> ();
            using(var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"))) 
            {
                var bookBanco = await connection.QueryFirstOrDefaultAsync<Book>("select * from Books where id = @Id" , new {Id = bookId});

                var bookMapeado = _mapper.Map<BookListarDto>(bookBanco);
                response.Dados = bookMapeado;

                return response;
            }
        }

        public async Task<ResponseModel<List<BookListarDto>>> BuscarBook()
        {

            ResponseModel<List<BookListarDto>> response = new ResponseModel<List<BookListarDto>> ();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                var booksBanco = await connection.QueryAsync<Book>("select * from Books");

                var bookMapeado = _mapper.Map<List<BookListarDto>>(booksBanco);

                response.Dados = bookMapeado; 

            } 
            return response;
        }

        public async Task<ResponseModel<List<BookListarDto>>> CriarBook(BookCriarDto bookCriarDto)
        {
            ResponseModel<List<BookListarDto>> response = new ResponseModel<List<BookListarDto>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var bookBanco = await connection.ExecuteAsync("insert into Books (Title, Author, Year, Available) " +
                    "values (@Title, @Author, @Year, @Available)", bookCriarDto);

                var books = await ListarBooks(connection);

                var booksMapeados = _mapper.Map<List<BookListarDto>>(books);

                response.Dados = booksMapeados;
            }
            return response;
        }

        private static async Task<IEnumerable<Book>> ListarBooks(SqlConnection connection)
        {
            return await connection.QueryAsync<Book>("select * from Books");
        }

        public async Task<ResponseModel<List<BookListarDto>>> EditarBook(BookEditarDto bookEditarDto)
        {
            ResponseModel<List<BookListarDto>> response = new ResponseModel<List<BookListarDto>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var booksBanco = await connection.ExecuteAsync("update Books set Title = @Title," +
                                                                                "Author = @Author, Year = @Year , Available = @Available where Id = @Id", bookEditarDto);

                var books = await ListarBooks(connection);

                var booksMapeados = _mapper.Map<List<BookListarDto>>(books);

                response.Dados = booksMapeados;
            }
            return response;

        }

        public async Task<ResponseModel<List<BookListarDto>>> RemoverBook(int bookId)
        {
            ResponseModel<List<BookListarDto>> response = new ResponseModel<List<BookListarDto>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var booksBanco = await connection.ExecuteAsync("delete from Books where id = @Id", new {Id = bookId});

                var books = await ListarBooks(connection);

                var booksMapeados = _mapper.Map < List<BookListarDto>>(books);

                response.Dados = booksMapeados;
            }

            return response;
        }
    }
}
