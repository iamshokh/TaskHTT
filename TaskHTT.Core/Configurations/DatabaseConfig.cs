﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHTT.Core.Configurations
{
    public class DatabaseConfig
    {
        public PgSqlConfig PgSql { get; set; } = new();
    }

    public class PgSqlConfig
    {
        public string ConnectionString { get; set; } = "";
    }
}
