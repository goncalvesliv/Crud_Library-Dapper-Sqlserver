using Crud_Library_sqlserver.Dto;
using Crud_Library_sqlserver.Models;


namespace Crud_Library_sqlserver.Services
{
    public interface IbookInterface
    {
        Task<ResponseModel<List<BookListarDto>>> BuscarBook();
        Task<ResponseModel<BookListarDto>> BuscarBookPorId(int bookId);

        Task<ResponseModel<List<BookListarDto>>> CriarBook(BookCriarDto bookCriarDto);

        Task<ResponseModel<List<BookListarDto>>> EditarBook(BookEditarDto bookEditarDto);

        Task<ResponseModel<List<BookListarDto>>> RemoverBook(int bookId);
    }
}
