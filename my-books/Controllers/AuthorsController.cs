﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public AuthorsService _authorsService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }
        [HttpPost("add-author")]
        public IActionResult AddBook([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok();
        }
        [HttpGet("get-author-with-book /{authorId}")]
        public IActionResult GetAuthorWithBook(int authorId)
        {
            var response = _authorsService.GetAuthorWithBooks(authorId);
            return Ok(response);
        }
    }
}
