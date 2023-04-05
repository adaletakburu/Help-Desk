using System.Collections.Generic;

namespace HelpDesk.Common.Pagination.Wrappers
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(IList<T> data)
        {
            Data = data;
        }
        public IList<T> Data { get; set; }
    }

}
