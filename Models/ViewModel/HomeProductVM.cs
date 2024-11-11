using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using DatabaseThucHanh.Models;

namespace DatabaseThucHanh.Models.ViewModel
{
        public class HomeProductVM
        {
        public int PageSize { get; set; } = 10;
        public string SearchTerm { get; set; }
        public List<Product> FeaturedProducts { get; set; } // Sản phẩm nổi bật
        public IPagedList<Product> NewProducts { get; set; } // Sản phẩm mới
    }
}



