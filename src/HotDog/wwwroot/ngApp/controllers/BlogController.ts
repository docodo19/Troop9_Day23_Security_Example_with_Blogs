namespace HotDog.Controllers {

    export class BlogController {
        public blogs;

        constructor(private blogService:HotDog.Services.BlogService) {
            this.blogs = blogService.getActiveBlogs();
        }

    }

    export class UserBlogController {
        public blogs;

        constructor(private blogService: HotDog.Services.BlogService) {
            this.blogs = blogService.getUserBlogs();
        }

    }

    export class AdminBlogController {
        public blogs;

        constructor(private blogService: HotDog.Services.BlogService) {
            this.blogs = blogService.getAllBlogs();
        }

    }


}