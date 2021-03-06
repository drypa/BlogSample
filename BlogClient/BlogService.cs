﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34209
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IBlogService")]
public interface IBlogService
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBlogService/AddComment", ReplyAction = "http://tempuri.org/IBlogService/AddCommentResponse")]
    void AddComment(Blog.BusinessEntities.Comment comment);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBlogService/AddComment", ReplyAction = "http://tempuri.org/IBlogService/AddCommentResponse")]
    System.Threading.Tasks.Task AddCommentAsync(Blog.BusinessEntities.Comment comment);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBlogService/AddPost", ReplyAction = "http://tempuri.org/IBlogService/AddPostResponse")]
    void AddPost(Blog.BusinessEntities.BlogPost post);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBlogService/AddPost", ReplyAction = "http://tempuri.org/IBlogService/AddPostResponse")]
    System.Threading.Tasks.Task AddPostAsync(Blog.BusinessEntities.BlogPost post);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBlogService/DeletePost", ReplyAction = "http://tempuri.org/IBlogService/DeletePostResponse")]
    void DeletePost(Blog.BusinessEntities.BlogPost post);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBlogService/DeleteComment", ReplyAction = "http://tempuri.org/IBlogService/DeleteCommentResponse")]
    void DeleteComment(Blog.BusinessEntities.Comment comment);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBlogService/DeletePost", ReplyAction = "http://tempuri.org/IBlogService/DeletePostResponse")]
    System.Threading.Tasks.Task DeletePostAsync(Blog.BusinessEntities.BlogPost post);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBlogService/GetComments", ReplyAction = "http://tempuri.org/IBlogService/GetCommentsResponse")]
    [System.ServiceModel.Web.WebInvoke(Method = "GET", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Bare)]
    Blog.BusinessEntities.Comment[] GetComments(System.Guid postId);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBlogService/GetComments", ReplyAction = "http://tempuri.org/IBlogService/GetCommentsResponse")]
    System.Threading.Tasks.Task<Blog.BusinessEntities.Comment[]> GetCommentsAsync(System.Guid postId);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBlogService/GetPost", ReplyAction = "http://tempuri.org/IBlogService/GetPostResponse")]
    [System.ServiceModel.Web.WebInvoke(Method = "GET", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Bare)]
    Blog.BusinessEntities.BlogPost GetPost(System.Guid postId);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBlogService/GetPost", ReplyAction = "http://tempuri.org/IBlogService/GetPostResponse")]
    System.Threading.Tasks.Task<Blog.BusinessEntities.BlogPost> GetPostAsync(System.Guid postId);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBlogService/GetPosts", ReplyAction = "http://tempuri.org/IBlogService/GetPostsResponse")]
    [System.ServiceModel.Web.WebInvoke(Method = "GET", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Bare)]
    Blog.BusinessEntities.BlogPost[] GetPosts();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IBlogService/GetPosts", ReplyAction = "http://tempuri.org/IBlogService/GetPostsResponse")]
    System.Threading.Tasks.Task<Blog.BusinessEntities.BlogPost[]> GetPostsAsync();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IBlogServiceChannel : IBlogService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class BlogServiceClient : System.ServiceModel.ClientBase<IBlogService>, IBlogService
{

    public BlogServiceClient()
    {
    }

    public BlogServiceClient(string endpointConfigurationName) :
        base(endpointConfigurationName)
    {
    }

    public BlogServiceClient(string endpointConfigurationName, string remoteAddress) :
        base(endpointConfigurationName, remoteAddress)
    {
    }

    public BlogServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
        base(endpointConfigurationName, remoteAddress)
    {
    }

    public BlogServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
        base(binding, remoteAddress)
    {
    }

    public void AddComment(Blog.BusinessEntities.Comment comment)
    {
        base.Channel.AddComment(comment);
    }

    public System.Threading.Tasks.Task AddCommentAsync(Blog.BusinessEntities.Comment comment)
    {
        return base.Channel.AddCommentAsync(comment);
    }

    public void AddPost(Blog.BusinessEntities.BlogPost post)
    {
        base.Channel.AddPost(post);
    }

    public System.Threading.Tasks.Task AddPostAsync(Blog.BusinessEntities.BlogPost post)
    {
        return base.Channel.AddPostAsync(post);
    }

    public void DeletePost(Blog.BusinessEntities.BlogPost post)
    {
        base.Channel.DeletePost(post);
    }

    public void DeleteComment(Blog.BusinessEntities.Comment comment)
    {
        base.Channel.DeleteComment(comment);
    }

    public System.Threading.Tasks.Task DeletePostAsync(Blog.BusinessEntities.BlogPost post)
    {
        return base.Channel.DeletePostAsync(post);
    }

    public Blog.BusinessEntities.Comment[] GetComments(System.Guid postId)
    {
        return base.Channel.GetComments(postId);
    }

    public System.Threading.Tasks.Task<Blog.BusinessEntities.Comment[]> GetCommentsAsync(System.Guid postId)
    {
        return base.Channel.GetCommentsAsync(postId);
    }

    public Blog.BusinessEntities.BlogPost GetPost(System.Guid postId)
    {
        return base.Channel.GetPost(postId);
    }

    public System.Threading.Tasks.Task<Blog.BusinessEntities.BlogPost> GetPostAsync(System.Guid postId)
    {
        return base.Channel.GetPostAsync(postId);
    }

    public Blog.BusinessEntities.BlogPost[] GetPosts()
    {
        return base.Channel.GetPosts();
    }

    public System.Threading.Tasks.Task<Blog.BusinessEntities.BlogPost[]> GetPostsAsync()
    {
        return base.Channel.GetPostsAsync();
    }
}
