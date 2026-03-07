using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using saltingandhashing.Models;
using saltingandhashing.Services.Context;

namespace saltingandhashing.Services
{
    public class BlogItemService
    {
        private readonly DataContext _context;
        public BlogItemService(DataContext context)
        {
            _context = context;
        }

        public bool AddBlogItems(BlogItemModel newBlogItem)
        {
            bool result;
            _context.Add(newBlogItem);
            result = _context.SaveChanges() != 0;
            return result;
        }

        public bool DeleteBlogItem(BlogItemModel blogItemToDelete)
        {
            _context.Update(blogItemToDelete);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<BlogItemModel> GetAllBlogItems()
        {
            return _context.BlogInfo;
        }

        public IEnumerable<BlogItemModel> GetBlogItemsByCategory(string category)
        {
            return _context.BlogInfo.Where(item => item.Category == category);
        }

        public IEnumerable<BlogItemModel> GetItemsByDate(string date)
        {
            return _context.BlogInfo.Where(item => item.Date == date);
        }

        public IEnumerable<BlogItemModel> GetItemsByTag(string tag)
        {
            List<BlogItemModel> AllBlogsWithTag = new List<BlogItemModel>();
            var allItems = GetAllBlogItems().ToList();

            for(int i = 0; i < allItems.Count; i++)
            {
                BlogItemModel Item = allItems[i];
                var itemArr = Item.Tags.Split(", ");
                for (int j = 0; i < itemArr.Length; j++)
                {
                    if (itemArr.Contains(tag))
                    AllBlogsWithTag.Add(Item);
                    break;
                }
            }
            return AllBlogsWithTag;

        }

        public bool UpdateBlogItems(BlogItemModel blogUpdate)
        {
            _context.Update(blogUpdate);
            return _context.SaveChanges() != 0;
        }

        public IEnumerable<BlogItemModel> GetPublishedItems()
        {
            return _context.BlogInfo.Where(item => item.isPublished);
        }
    }
}