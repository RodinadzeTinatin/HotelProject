﻿using HotelProject.Data;
using HotelProject.Models;
using HotelProject.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository.SQLClient
{
    public class HotelRepository : IHotelRepository
    {
        public async Task<List<Hotel>> GetHotels()
        {
            List<Hotel> result = new();
            const string sqlExpression = "sp_GetAllHotels";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        if (reader.HasRows)
                        {
                            result.Add(new Hotel()
                            {
                                Id = reader.GetInt32(0),
                                Name = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                                Rating = !reader.IsDBNull(2) ? reader.GetDouble(2) : 0,
                                Country = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty,
                                City = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty,
                                PhyisicalAddress = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty
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
        public async Task<List<Hotel>> GetHotelsWithoutManager()
        {
            List<Hotel> result = new();
            const string sqlExpression = "sp_GetHotelsWithoutManager";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        if (reader.HasRows)
                        {
                            result.Add(new Hotel()
                            {
                                Id = reader.GetInt32(0),
                                Name = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                                Rating = !reader.IsDBNull(2) ? reader.GetDouble(2) : 0,
                                Country = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty,
                                City = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty,
                                PhyisicalAddress = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty
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
        public async Task<Hotel> GetSingleHotel(int id)
        {
            Hotel result = new();
            const string sqlExpression = "sp_GetSingleHotel";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", id);

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        if (reader.HasRows)
                        {
                            result.Id = reader.GetInt32(0);
                            result.Name = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;
                            result.Rating = !reader.IsDBNull(2) ? reader.GetDouble(2) : 0;
                            result.Country = !reader.IsDBNull(3) ? reader.GetString(3) : string.Empty;
                            result.City = !reader.IsDBNull(4) ? reader.GetString(4) : string.Empty;
                            result.PhyisicalAddress = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
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
        public async Task AddHotel(Hotel hotel)
        {
            string sqlExpression = "sp_AddHotel";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new(sqlExpression, connection);

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("name", hotel.Name);
                    command.Parameters.AddWithValue("rating", hotel.Rating);
                    command.Parameters.AddWithValue("country", hotel.Country);
                    command.Parameters.AddWithValue("city", hotel.City);
                    command.Parameters.AddWithValue("phyisicalAddress", hotel.PhyisicalAddress);

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
        public async Task UpdateHotel(Hotel hotel)
        {
            string sqlExpression = "sp_UpdateHotel";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new(sqlExpression, connection);

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("name", hotel.Name);
                    command.Parameters.AddWithValue("rating", hotel.Rating);
                    command.Parameters.AddWithValue("country", hotel.Country);
                    command.Parameters.AddWithValue("city", hotel.City);
                    command.Parameters.AddWithValue("phyisicalAddress", hotel.PhyisicalAddress);
                    command.Parameters.AddWithValue("hotelId", hotel.Id);

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
        public async Task DeleteHotel(int id)
        {
            string sqlExpression = @$"sp_DeleteHotel";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("hotelId", id);

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
