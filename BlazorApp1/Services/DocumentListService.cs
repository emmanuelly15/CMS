using BlazorApp1.Data;
using BlazorApp1.Models;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApp1.Services
{
    public class DocumentListService
    {
        protected readonly ApplicationDbContext _dbcontext;

        public DocumentListService(ApplicationDbContext _db)
        {
            _dbcontext = _db;
        }

        public List<DocumentListClass> docobj()
        {
            return _dbcontext.Imageuploads.ToList();
        }
    }
}
