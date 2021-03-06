﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using TowerSoft.Repository;
using TowerSoft.Repository.Maps;
using TowerSoft.Repository.MySql;
using TowerSoft.RepositoryTests.TestObjects;

namespace TowerSoft.RepositoryTests {
    /// <summary>
    /// Fake repository for unit tests
    /// </summary>
    public class FauxRepository : DbRepository<TestObject> {
        public FauxRepository() : base(new MySqlDbAdapter("")) { }

        public FauxRepository(string overrideTableName) : base(new MySqlDbAdapter(""), overrideTableName) { }

        public FauxRepository(EntityMap<TestObject> entityMap) : base(new MySqlDbAdapter(""), entityMap) { }

        public FauxRepository(bool useManualMaps) : base(new MySqlDbAdapter(""), "", GetMaps()) { }

        private static ICollection<IMap> GetMaps() {
            return new[] {
                new AutonumberMap("ID"),
                new Map("Title"),
                new Map("Description"),
                new Map("StatusID"),
                new Map("InputOn"),
                new Map("InputByID"),
                new Map("IsActive")
            };
        }

        public string GetTableName() {
            return TableName;
        }

        public IMap GetAutonumberMap() {
            return Mappings.AutonumberMap;
        }

        public List<IMap> GetPrimaryKeyMaps() {
            return Mappings.PrimaryKeyMaps;
        }

        public List<IMap> GetAllMaps() {
            return Mappings.AllMaps;
        }
    }
}
