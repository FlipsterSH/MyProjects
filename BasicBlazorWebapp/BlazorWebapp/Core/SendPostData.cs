using System.Collections.Generic;

namespace BlazorWebapp.Core
{
    public class Selection
    {
        public string filter { get; set; }
        public List<string> values { get; set; }
    }

    public class Query
    {
        public string code { get; set; }
        public Selection selection { get; set; }
    }

    public class Response
    {
        public string format { get; set; }
    }

    public class ApiRequest
    {
        public List<Query> query { get; set; }
        public Response response { get; set; }
    }
}




