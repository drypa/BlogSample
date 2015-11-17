﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Blog.BusinessEntities;
using Dapper;

namespace Blog.BusinessLogic
{
    public class DapperBlogRepository : IBlogRepository
    {
        private readonly IAppSettingsHelper _appSettingsHelper;

        private readonly string selectPostWithCommentsQuery = @"select [Id]
      ,[CreateDate]
      ,[Description]
      ,[Text]
      ,[Title] 
  from [dbo].[BlogPost] where Id =  @postId;
  
  select [Id]
      ,[CreateDate]
      ,[Text]
  from [dbo].[Comment] where Post = @postId;
";
        private readonly string selectPostsQuery = @"SELECT [Id]
      ,[CreateDate]
      ,[Description]
      ,[Text]
      ,[Title]
  FROM [BlogService].[dbo].[BlogPost]
";

        public DapperBlogRepository(IAppSettingsHelper appSettingsHelper)
        {
            _appSettingsHelper = appSettingsHelper;
        }

        public void AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public void AddPost(BlogPost post)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(BlogPost post)
        {
            throw new NotImplementedException();
        }

        public BlogPost GetPost(Guid postId)
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                SqlMapper.GridReader data = connection.QueryMultiple(selectPostWithCommentsQuery, new { postId });
                BlogPost resultPost = data.Read<BlogPost>().SingleOrDefault();
                if (resultPost != null)
                {
                    resultPost.Comments = data.Read<Comment>().ToList();
                }
                return resultPost;
            }
        }

        public IList<BlogPost> GetPosts()
        {
            using (SqlConnection connection = GetOpenConnection())
            {
                return connection.Query<BlogPost>(selectPostsQuery).AsList();
            }
        }

        private SqlConnection GetOpenConnection()
        {
            var connection = new SqlConnection(_appSettingsHelper.GetConnectionString());
            connection.Open();
            return connection;
        }
    }
}