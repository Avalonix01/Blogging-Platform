namespace BlogPlatform.Endpoints;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class V1
    {
        private const string _version = "v1";
        private const string _base = $"{ApiBase}/{_version}";  // api/v1

        public static class Blogs
        {
            private const string _base = $"{V1._base}/blogs"; // api/v1/blogs/
            public const string GetAll = _base;
            public const string Create = _base;
            public const string Delete = $"{_base}/{{id:guid}}"; // api/v1/blogs/id
        }

        public static class Categories
        {
            private const string _base = $"{V1._base}/books"; // api/v1/books
            public const string GetAll = _base;
            public const string Create = _base;
            public const string Delete = $"{_base}/{{id:guid}}"; // api/v1/books/id
        }

        public static class Comments
        {
            private const string _base = $"{V1._base}/comments"; // api/v1/comments/
            public const string GetAll = _base;
            public const string Create = _base;
            public const string Delete = $"{_base}/{{id:guid}}"; // api/v1/comments/id
        }
    }
}