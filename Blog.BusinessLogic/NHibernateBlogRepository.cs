﻿using System;
using System.Collections.Generic;
using Blog.BusinessEntities;
using NHibernate;
using Ninject;

namespace Blog.BusinessLogic
{
    public class NHibernateBlogRepository : IBlogRepository
    {
        private readonly IAppSettingsHelper appSettings;
        private NHibernateConfigurator configurator;

        [Inject]
        public NHibernateBlogRepository(IAppSettingsHelper appSettingsHelper)
        {
            appSettings = appSettingsHelper;
        }

        private NHibernateConfigurator Configurator
        {
            get { return configurator ?? (configurator = new NHibernateConfigurator(appSettings)); }
        }

        public void AddComment(Comment comment)
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(comment);

                    transaction.Commit();
                }
            }
        }

        /// <summary>
        /// Добавить новую статью
        /// </summary>
        /// <param name="post">Статья для добавления</param>
        public void AddPost(BlogPost post)
        {
            using (ISession session = OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(post);

                    transaction.Commit();
                }
            }
        }

        public void DeleteComment(Comment comment)
        {
            using (ISession session = OpenSession())
            {
                session.Delete(comment);
                session.Flush();
            }
        }

        public void DeletePost(BlogPost post)
        {
            using (ISession session = OpenSession())
            {
                session.Delete(post);
                session.Flush();
            }
        }

        public IList<Comment> GetComments(Guid postId)
        {
            using (ISession session = OpenSession())
            {
                return session.QueryOver<Comment>().Where(x => x.Post.Id == postId).List<Comment>();
            }
        }

        public BlogPost GetPost(Guid postId)
        {
            using (ISession session = OpenSession())
            {
                return session.Get<BlogPost>(postId);
            }
        }

        /// <summary>
        /// Получение всех статей
        /// </summary>
        /// <returns>список всех статей</returns>
        public IList<BlogPost> GetPosts()
        {
            using (ISession session = OpenSession())
            {
                return session.QueryOver<BlogPost>().List<BlogPost>();
            }
        }

        private ISession OpenSession()
        {
            return Configurator.GetSessionFactory().OpenSession();
        }
    }
}
