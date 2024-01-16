﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public sealed class Connection
    {
        private string _connectionString;

        /// <summary>
        /// Permet de construire mon objet connexion basé sur la chaine de connexion
        /// Test également l'ouverture de la connexion
        /// </summary>
        /// <param name="connectionString">La chaine de connexion</param>
        /// <exception cref="SqlException">Survient si la chaine de connexion est invalide ou si le serveru n'est pas disponible</exception>
        public Connection(string connectionString)
        {
            _connectionString = connectionString;

            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
            }
        }

        public object? ExecuteScalar(Command command)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand sqlCommand = CreateCommand(command, connection))
                {
                    connection.Open();
                    object result = sqlCommand.ExecuteScalar();
                    return (result is DBNull) ? null : result;
                }
            }
        }

        public IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<IDataReader, TResult> selector)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand sqlCommand = CreateCommand(command, connection))
                {
                    connection.Open();
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            yield return selector(dataReader);
                        }
                    }
                }
            }
        }
        public int ExecuteNonQuery(Command command)
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand sqlCommand = CreateCommand(command, connection))
                {
                    connection.Open();
                    return sqlCommand.ExecuteNonQuery();
                }
            }
        }

        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;

            return connection;
        }

        private SqlCommand CreateCommand(Command command, SqlConnection connection)
        {
            SqlCommand sqlCommand = connection.CreateCommand();
            sqlCommand.CommandText = command.Query;

            if (command.IsStoredProcedure)
                sqlCommand.CommandType = CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> kvp in command.Parameters)
            {
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = kvp.Key;
                parameter.Value = kvp.Value;

                sqlCommand.Parameters.Add(parameter);
            }

            return sqlCommand;
        }
    }
}
