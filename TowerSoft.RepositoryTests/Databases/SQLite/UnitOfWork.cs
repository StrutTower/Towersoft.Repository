﻿using System;
using System.Collections.Generic;
using System.Linq;
using TowerSoft.Repository;
using TowerSoft.Repository.Interfaces;
using TowerSoft.Repository.SQLite;
using TowerSoft.RepositoryTests.Interfaces;

namespace TowerSoft.RepositoryTests.SQLite {
    public class UnitOfWork : IUnitOfWork, IRepositoryUnitOfWork {
        public UnitOfWork(string path) {
            DbAdapter = new SQLiteDbAdapter($"Data Source={path};Version=3;");
        }

        public IDbAdapter DbAdapter { get; }

        public void BeginTransaction() {
            DbAdapter.BeginTransaction();
        }

        public void CommitTransaction() {
            DbAdapter.CommitTransaction();
        }

        public void RollbackTransaction() {
            DbAdapter.RollbackTransaction();
        }

        public void Dispose() {
            DbAdapter.Dispose();
        }

        /// <summary>
        /// Stores repositories that have been initialized
        /// </summary>
        private readonly Dictionary<Type, object> _repos = new Dictionary<Type, object>();

        public TRepo GetRepo<TRepo>() where TRepo : IDbRepository {
            Type type = typeof(TRepo);

            if (!_repos.ContainsKey(type)) _repos[type] = Activator.CreateInstance(type, this);
            return (TRepo)_repos[type];
        }
    }
}
