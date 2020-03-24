﻿using System;
using System.Collections.Generic;
using System.Text;
using TowerSoft.Repository;
using TowerSoft.RepositoryTests.TestObjects;

namespace TowerSoft.RepositoryTests.SQLite {
    public class CountTestRepository : Repository<CountTest> {
        public CountTestRepository(UnitOfWork uow) : base(uow.DbAdapter) { }

        public CountTest GetByID(int id) {
            return GetSingleEntity(WhereEqual(x => x.ID, id));
        }

        public CountTest GetByName(string name) {
            return GetSingleEntity(WhereEqual(x => x.Name, name));
        }
    }
}