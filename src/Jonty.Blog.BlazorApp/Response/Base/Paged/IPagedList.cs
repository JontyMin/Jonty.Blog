﻿namespace Jonty.Blog.BlazorApp.Response.Base.Paged
{
    public interface IPagedList<T>:IListResult<T>,IHasTotalCount
    {
        
    }
}