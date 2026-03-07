using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using saltingandhashing.Models;
using saltingandhashing.Services;

namespace saltingandhashing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogItemService _data;
        public BlogController(BlogItemService dataFromService)
        {
            _data = dataFromService;
        }

        //AddBlogItems
        [HttpPost("AddBlogItems")]

        public bool AddBlogItems(BlogItemModel newBlogItem)
        {
            return _data.AddBlogItems(newBlogItem);
        }

        [HttpGet("GetBlogItems")]

        public IEnumerable<BlogItemModel> GetBlogItems()
        {
            return _data.GetAllBlogItems();
        }

        [HttpGet("GetBlogItemsByCategory/{category}")]
        public IEnumerable<BlogItemModel> GetItemsByCategory(string category)
        {
            return _data.GetBlogItemsByCategory(category);
        }

        [HttpGet("GetItemsByTag/{tag}")]
        public IEnumerable<BlogItemModel> GetItemsByTag(string tag)
        {
            return _data.GetItemsByTag(tag);
        }

        //getitemsbydate (can make datetime for project)
        [HttpGet("GetItemsByDate/{date}")]
        public IEnumerable<BlogItemModel> GetItemsByDate(string date)
        {
            return _data.GetItemsByDate(date);
        }

        [HttpPut("BlogUpdate/{blogUpdate}")]
        public bool UpdateBlogItems(BlogItemModel blogUpdate)
        {
            return _data.UpdateBlogItems(blogUpdate);
        }

        [HttpPut("DeleteBlogItem/{BlogToDelete}")]
        public bool DeleteBlogItem(BlogItemModel BlogItemToDelete)
        {
            return _data.DeleteBlogItem(BlogItemToDelete);
        }

        [HttpGet("GetPublishedItems")]
        public IEnumerable<BlogItemModel> GetPublishedItems()
        {
            return _data.GetPublishedItems();
        }
    }
}