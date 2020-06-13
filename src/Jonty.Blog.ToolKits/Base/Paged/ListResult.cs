using System.Collections.Generic;

namespace Jonty.Blog.ToolKits.Base.Paged
{
    public class ListResult<T>:IListResult<T>
    {
        IReadOnlyList<T> item;

        public IReadOnlyList<T> Item
        {
            get => item ?? (item = new List<T>());
            set => item = value;
        }

        public ListResult(){}

        public ListResult(IReadOnlyList<T> item)
        {
            Item = item;
        }
    }
}