﻿using System;
using System.Data.SqlClient;
using Npgsql;

namespace Bookish.Models.Database
{
    public static class Database
    {
        public static  NpgsqlConnection Connect()
        {
            return new NpgsqlConnection(
                "User ID=postgres;Password=Newxbox360;Host=localhost;Port=5432;Database=Bookish;");
        }

    }
}