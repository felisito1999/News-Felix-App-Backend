using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Library.Models
{
    public class ArticleModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public byte[] MainImage { get; set; }
        public string Body { get; set; }
        public string UploadedUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPublished { get; set; }
        public List<CategoryModel> Categories { get; set; }
        public DateTime? PublishedAt { get; set; }
    }
}
