using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;

namespace DatabaseThucHanh.Models.ViewModel
{
    public class ProductSearchVM
    {
      //  public IEnumerable<Product> Products { get; set; }
        public string SearchTerm { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string SortOrder { get; set; }
        //trang sản phẩm hiện tại
        public int PageNumber { get; set; } 
        // số sản phẩm tối đa ỏ 1 trang
        public int PageSize { get; set; } = 10;
        // danh sách sản phẩm phân trang
        public PagedList.IPagedList<Product> Products { get; set; }

    }
}