using HotelProject.Data;
using HotelProject.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.Repository
{
    public class RoomRepository
    {
        public async Task<List<Room>> GetRooms()
        {
            List<Room> result = new();
            const string sqlExpression = "sp_GetAllRooms";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        if (reader.HasRows)
                        {
                            result.Add(new Room()
                            {
                                Id = reader.GetInt32(0),
                                Name = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty,
                                IsFree = !reader.IsDBNull(2) && reader.GetBoolean(2),
                                HotelId = reader.GetInt32(3),
                                DailyPrice = !reader.IsDBNull(4) ? reader.GetDouble(4) : 0
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

        public async Task AddRoom(Room room)
        {
            string sqlExpression = "sp_AddRoom";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new(sqlExpression, connection);

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("name", room.Name);
                    command.Parameters.AddWithValue("isfree", room.IsFree);
                    command.Parameters.AddWithValue("hotelId", room.HotelId);
                    command.Parameters.AddWithValue("dailyPrice", room.DailyPrice);

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
        public async Task UpdateRoom(Room room)
        {
            string sqlExpression = "sp_UpdateRoom";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new(sqlExpression, connection);

                    command.CommandType = CommandType.StoredProcedure;
                    
                    command.Parameters.AddWithValue("id", room.Id);
                    command.Parameters.AddWithValue("name", room.Name);
                    command.Parameters.AddWithValue("isfree", room.IsFree);
                    command.Parameters.AddWithValue("hotelId", room.HotelId);
                    command.Parameters.AddWithValue("dailyPrice", room.DailyPrice);

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
        public async Task DeleteRoom(int id)
        {
            string sqlExpression = @$"sp_DeleteRoom";

            using (SqlConnection connection = new(ApplicationDbContext.ConnectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    SqlCommand command = new(sqlExpression, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("id", id);

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
