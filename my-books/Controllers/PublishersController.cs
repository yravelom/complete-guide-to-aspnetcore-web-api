using Microsoft.AspNetCore.Http;
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
    public class PublishersController : ControllerBase
    {
        public PublishersService _publishersService;
        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publishersService.AddPublisher(publisher);
            return Ok();
        }
        [HttpGet("get-publisher-book-with-author/{publisherId}")]
        public IActionResult GetPublisherData(int publisherId)
        {
            var _response = _publishersService.GetPublisherData(publisherId);
            return Ok(_response);
        }
        [HttpDelete("delete-publisher-by-id/{publisherId}")]
        public IActionResult DeletePublisherById(int publisherId)
        {
            _publishersService.DeletePublisherById(publisherId);
            return Ok();
        }
    }
}
