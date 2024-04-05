﻿using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Exceptions;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository
{
    public class ManagerRepository
    {
        private readonly HotelRepository _hotelRepository;
        public ManagerRepository()
        {
            _hotelRepository = new HotelRepository();
        }

        public async Task<List<Manager>> GetManagers()
        {
            List<Manager> result = new();
            const string sqlExpression = "sp_GetAllManagers";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        if (reader.HasRows)
                        {
                            result.Add(new Manager()
                            {
                                Id = !reader.IsDBNull(0) ? reader.GetInt32(0) : 0,
                                FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                                LastName = !reader.IsDBNull(2) ? reader.GetString(2) : string.Empty,
                                HotelId = !reader.IsDBNull(3) ? reader.GetInt32(3) : 0,
                            });
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }

                return result;
            }
        }
        public async Task AddManager(Manager manager)
        {
            string sqlExpression = "sp_addManager";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    var allHotels = await _hotelRepository.GetHotels();

                    if (manager.HotelId <= 0)
                    {
                        throw new HotelNotFoundException();
                    }

                    if (!allHotels.Any(x => x.Id == manager.HotelId))
                    {
                        throw new HotelNotFoundException();
                    }

                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("firstName", manager.FirstName);
                    command.Parameters.AddWithValue("lastName", manager.LastName);
                    command.Parameters.AddWithValue("hotelId", manager.HotelId);

                    await connection.OpenAsync();

                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("Query didn't effect any data");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }

        }
        public async Task UpdateManager(Manager manager)
        {
            string sqlExpression = "sp_UpdateManager";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("firstName", manager.FirstName);
                    command.Parameters.AddWithValue("lastName", manager.LastName);
                    command.Parameters.AddWithValue("hotelId", manager.HotelId);
                    command.Parameters.AddWithValue("id", manager.Id);

                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("Query didn't effect any data");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }

        }
        public async Task DeleteManager(int id)
        {
            string sqlExpression = "sp_DeleteManager";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", id);

                    await connection.OpenAsync();
                    int rowsAffected = await command.ExecuteNonQueryAsync();

                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("Query didn't effect any data");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }

        }
    }
}
