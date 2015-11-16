﻿using System;
using System.Data;
using Blog.BusinessEntities;
using Blog.BusinessLogic.Mappings;
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
        
        public Configuration GetConfiguration()
        {
            if (configuration != null)
            {
                return configuration;
            }
            return (configuration = BuildConfiguration());
        }

        private static void Init(Configuration config)
        {
            HbmMapping mapping = GetMappings();
            config.AddDeserializedMapping(mapping, "NHSchema");
            SchemaMetadataUpdater.QuoteTableAndColumns(config);
        }


        private static HbmMapping GetMappings()
        {
            ModelMapper mapper = new ModelMapper();

            mapper.AddMapping<BlogPostMapping>();
            mapper.AddMapping<CommentMapping>();

            HbmMapping mapping = mapper.CompileMappingFor(new[] { typeof(BlogPost), typeof(Comment) });

            return mapping;
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
            Init(configure);
            return configure;
        }
    }
}