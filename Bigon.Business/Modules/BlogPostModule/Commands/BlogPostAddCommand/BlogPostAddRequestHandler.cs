using MediatR;

namespace Bigon.Business.Modules.BlogPostModule.Commands.BlogPostAddCommand
{
    internal class BlogPostAddRequestHandler : IRequestHandler<BlogPostAddRequest, BlogPost>
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IFileService fileService;

        public BlogPostAddRequestHandler(IBlogPostRepository blogPostRepository, IFileService fileService)
        {
            this.blogPostRepository = blogPostRepository;
            this.fileService = fileService;
        }
        public async Task<BlogPost> Handle(BlogPostAddRequest request, CancellationToken cancellationToken)
        {
            var sanitizer = new HtmlSanitizer();
            var model = new BlogPost
            {
                Title = request.Title,
                Body = sanitizer.Sanitize(request.Body),
                CategoryId = request.CategoryId
            };

            model.ImagePath = fileService.Upload(request.File);
            model.Slug = fileService.Upload(request.File);

            blogPostRepository.Add(model);
            blogPostRepository.Save();

            blogPostRepository.ResolveTags(model,request.Tags);
            blogPostRepository.Save();

            return model;
           
           
        }
    }
}
