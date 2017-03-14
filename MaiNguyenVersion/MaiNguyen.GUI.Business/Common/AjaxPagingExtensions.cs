﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace MaiNguyen.GUI.Business.Common
{
    public static class AjaxPagingExtensions
    {
        public static string Pager(this AjaxHelper ajaxHelper, Options options)
        {
            var divRow = new TagBuilder("div");
           // divRow.AddCssClass("row");
            var divCol5 = new TagBuilder("div");
            divCol5.AddCssClass("col-sm-5");
            var divCol7 = new TagBuilder("div");
            divCol7.AddCssClass("col-sm-7 text-right");
            //Create the new label.
            //var div = new TagBuilder("div");
            //div.AddCssClass("pagination pagination-normal pagination-right");

            string showing = string.Empty;
            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            //var totalPage = options.TotalItemCount <= options.PageSize ? 1 : options.TotalItemCount % options.PageSize == 0 ? options.TotalItemCount / options.PageSize : options.TotalItemCount / options.PageSize + 1;
            int totalPage;
            if (options.TotalItemCount % options.PageSize == 0)
            {
                totalPage = options.TotalItemCount / options.PageSize;
            }
            else
            {
                totalPage = options.TotalItemCount / options.PageSize + 1;
            }
            if (options.LimitPage != null)
            {
                int from;
                int to;
                if (totalPage - options.CurrentPage >= options.LimitPage / 2)
                {
                    if (options.CurrentPage > options.LimitPage.Value / 2)
                    {
                        from = options.CurrentPage - (options.LimitPage.Value / 2);
                        to = (options.LimitPage.Value - (options.LimitPage.Value / 2)) + options.CurrentPage;
                    }
                    else
                    {
                        from = 1;
                        to = options.LimitPage.Value + 1;
                    }

                }
                else
                {
                    from = totalPage - options.LimitPage.Value + 1;
                    to = totalPage + 1;
                }
                if (from < 1) from = 1;
                if (to > totalPage) to = totalPage + 1;

                if (options.IsShowFirstLast && from > 1)
                {
                    var link = String.Format(options.Link, 1);
                    var onclick = !string.IsNullOrEmpty(options.OnClick) ? String.Format(options.OnClick, 1) : "";
                    var isActive = 1 == options.CurrentPage ? "active" : "";
                    ul.InnerHtml += String.Format("<li class='{0}'><a href='{1}' data-page='1' onclick='{2}'>{3}</a></li>", isActive, link, onclick, "<span class='glyphicon glyphicon-fast-backward'></span>");
                }
                for (var i = from; i < to; i++)
                {
                    var li = new TagBuilder("li");
                    var isActive = i == options.CurrentPage ? "active" : "";
                    var link = String.Format(options.Link, i);
                    var onclick = !string.IsNullOrEmpty(options.OnClick) ? String.Format(options.OnClick, i) : "";
                    ul.InnerHtml += String.Format("<li class='{0}'><a href='{1}' data-page='{3}' onclick='{2}'>{3}</a></li>", isActive, link, onclick, i);
                }
                if (options.IsShowFirstLast && to - 1 < totalPage)
                {
                    var link = String.Format(options.Link, totalPage);
                    var onclick = !string.IsNullOrEmpty(options.OnClick) ? String.Format(options.OnClick, totalPage) : "";
                    var isActive = totalPage == options.CurrentPage ? "active" : "";
                    ul.InnerHtml += String.Format("<li class='{0}'><a href='{1}' data-page='{4}' onclick='{2}'>{3}</a></li>", isActive, link, onclick, "<span class='glyphicon glyphicon-fast-forward'></span>", totalPage);
                }

                //Showing 21 to 30 of 57 entries
                if (options.CurrentPage > 0 && options.PageSize > 0)
                {
                    showing = String.Format("Hiển thị {0} đến {1} của {2} mục", (((options.CurrentPage - 1) * options.PageSize) + 1), (options.CurrentPage * options.PageSize), options.TotalItemCount);
                }
            }
            divCol5.InnerHtml = showing.ToString();
           // div.InnerHtml = ul.ToString();
            divCol7.InnerHtml = ul.ToString();
            divRow.InnerHtml = divCol5.ToString() + divCol7.ToString();
            return divRow.ToString();
        }
    }
    public class Options
    {
        public string ActionName;
        public string ControllerName;
        public int CurrentPage;
        public int PageSize;
        public int TotalItemCount;
        public string Link = "";
        public string OnClick = "";
        public Options(){}
        public int? LimitPage = 5;
        public string CssClass { get; set; }
        public bool IsShowControls { get; set; }
        public bool IsShowFirstLast { get; set; }
        public bool IsShowPages { get; set; }


    }
   
}