using System.Collections.Generic;
using System.Linq;
using System;

namespace System.Web.Mvc
{
    public interface IPagedList
    {
        int TotalPage //总页数
        {
            get;
        }

        int TotalCount
        {
            get;
            set;
        }

        int PageIndex
        {
            get;
            set;
        }

        int PageSize
        {
            get;
            set;
        }

        bool IsPreviousPage
        {
            get;
        }

        bool IsNextPage
        {
            get;
        }
    }

    public class PagedList<T> : List<T>, IPagedList
    {
        public PagedList(IQueryable<T> source, int? index, int? pageSize)
        {
            if (index == null) { index = 1; }
            if (pageSize == null) { pageSize = 10; }
            this.TotalCount = source.Count();
            this.PageSize = pageSize.Value;
            this.PageIndex = index.Value;
            this.AddRange(source.Skip((index.Value - 1) * pageSize.Value).Take(pageSize.Value));
        }

        public int TotalPage
        {
            get { return (int)System.Math.Ceiling((double)TotalCount / PageSize); }
        }

        public int TotalCount
        {
            get;
            set;
        }
        /// <summary>
        /// 5/1、a、s、px
        /// </summary>
        public int PageIndex
        {
            get;
            set;
        }

        public int PageSize
        {
            get;
            set;
        }

        public bool IsPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool IsNextPage
        {
            get
            {
                return ((PageIndex) * PageSize) < TotalCount;
            }
        }
    }

    public static class Pagination
    {
        public static PagedList<T> ToPagedList<T>(this IOrderedQueryable<T> source, int? index, int? pageSize)
        {
            return new PagedList<T>(source, index, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IOrderedQueryable<T> source, int? index)
        {
            return new PagedList<T>(source, index, 10);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int? index, int? pageSize)
        {
            return new PagedList<T>(source, index, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int? index)
        {
            return new PagedList<T>(source, index, 10);
        }
    }
}

//5/1/a/s/p/x