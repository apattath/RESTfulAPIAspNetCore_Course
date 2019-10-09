using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.API.Models;
using Library.API.Helpers;
using Library.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/authors")]
    public class AuthorsController : Controller
    {
        private ILibraryRepository _libraryRepository;

        public AuthorsController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorList = _libraryRepository.GetAuthors();

            var authorDtoList = AutoMapper.Mapper.Map<IEnumerable<AuthorDto>>(authorList);
            return Ok(authorDtoList);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(Guid id)
        {
            var author = _libraryRepository.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }

            var authorDto = AutoMapper.Mapper.Map<AuthorDto>(author);

            return Ok(authorDto);
        }
    }
}