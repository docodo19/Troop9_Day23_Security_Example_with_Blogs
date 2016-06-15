namespace HotDog.Services {

    export class BlogService {
        private blogResource;

        constructor($resource:angular.resource.IResourceService) {
            this.blogResource = $resource('/api/blog/:id', null, {
                getActiveBlogs: {
                    method: 'GET',
                    url: '/api/blog/getactiveblogs',
                    isArray: true
                },
                getUserBlogs: {
                    method: 'GET',
                    url: '/api/blog/getuserblogs',
                    isArray: true
                },
                getAllBlogs: {
                    method: 'GET',
                    url: '/api/blog/getallblogs',
                    isArray: true
                }
            });
        }

        getActiveBlogs() {
            return this.blogResource.getActiveBlogs();
        }

        getUserBlogs() {
            return this.blogResource.getUserBlogs();
        }

        getAllBlogs() {
            return this.blogResource.getAllBlogs();
        }



    }
    angular.module('HotDog').service('blogService', BlogService);

}