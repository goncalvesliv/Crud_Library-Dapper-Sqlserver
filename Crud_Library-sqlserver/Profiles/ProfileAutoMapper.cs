using AutoMapper;
using Crud_Library_sqlserver.Dto;
using Crud_Library_sqlserver.Models;
using System.Runtime.InteropServices;

namespace Crud_Library_sqlserver.Profiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper() {
            CreateMap<Book, BookListarDto>();
        }
    }
}
