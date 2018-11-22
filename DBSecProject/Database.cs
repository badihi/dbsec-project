﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSecProject
{
    public class Database
    {
        private NpgsqlConnection connection;
        private Subject Subject { get; set; } = null;
        public Database(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
            /*using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Insert some data
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO data (some_field) VALUES (@p)";
                    cmd.Parameters.AddWithValue("p", "Hello world");
                    cmd.ExecuteNonQuery();
                }

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT some_field FROM data", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        Console.WriteLine(reader.GetString(0));
            }*/
        }

        public void Connect()
        {
            connection.Open();
        }

        public void Login(string username, string password)
        {
            var cmd = new NpgsqlCommand("SELECT * FROM subjects WHERE username = @username AND password = @password", connection);
            cmd.Parameters.AddWithValue("username", username);
            cmd.Parameters.AddWithValue("password", password);
            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.Read())
                {
                    throw new Exception("Username or password is not correct");
                }

                Subject = new Subject
                {
                    Username = reader.GetString(1),
                    Password = reader.GetString(2)
                };
            }
        }

        public bool IsAuthenticated()
        {
            return Subject != null;
        }
    }
}