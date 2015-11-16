﻿using System;
using System.Data;
using Blog.BusinessEntities;
using Blog.BusinessLogic.Mappings;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace Blog.BusinessLogic
{
    public class NHibernateConfigurator
    {
        private static Configuration configuration;
        private static ISessionFactory sessionFactory;

        public Configuration GetConfiguration()
        {
            if (configuration != null)
            {
                return configuration;
            }
            return (configuration = BuildConfiguration());
        }

        public ISessionFactory GetSessionFactory()
        {
            if (sessionFactory != null)
            {
                return sessionFactory;
            }
            return (sessionFactory = GetConfiguration().BuildSessionFactory());
        }

        private static Configuration BuildConfiguration()
        {
            var configure = new Configuration();

            configure.SessionFactoryName("SessionFactoryName");

            configure.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2008Dialect>();
                db.Driver<SqlClientDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.ConnectionString = new AppSettingsHelper().GetConnectionString("BlogDb");
                db.Timeout = 10;

                db.LogFormattedSql = true;
                db.LogSqlInConsole = true;
                db.AutoCommentSql = true;
            });
            InitMappings(configure);

            return configure;
        }

        private static HbmMapping GetMappings()
        {
            var mapper = new ModelMapper();

            mapper.AddMapping<BlogPostMapping>();
            mapper.AddMapping<CommentMapping>();

            HbmMapping mapping = mapper.CompileMappingFor(new[] { typeof(BlogPost), typeof(Comment) });

            return mapping;
        }

        private static void InitMappings(Configuration config)
        {
            HbmMapping mapping = GetMappings();
            config.AddDeserializedMapping(mapping, "NHSchema");
            SchemaMetadataUpdater.QuoteTableAndColumns(config);
        }
    }
}
