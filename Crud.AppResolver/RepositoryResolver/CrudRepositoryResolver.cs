using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Crud.AppResolver.CommonResolver.Model;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Crud.AppResolver.RepositoryResolver
{
    public class CrudRepositoryResolver: ICrudRepositoryResolver
    {
        public readonly IConfiguration _configuration;
        public readonly MySqlConnection _mySqlConnection;
        

        public CrudRepositoryResolver(IConfiguration configuration)
        {
            _configuration = configuration;
            _mySqlConnection = new MySqlConnection(_configuration[key: "ConnectionStrings:DBSettingConnection"]);
        }

        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = new CreateRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string SqlQuery = "Insert Into CrudOperationTable (UserName,Age) value (@UserName,@Age)";
                using(MySqlCommand command = new MySqlCommand(SqlQuery,_mySqlConnection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 180;
                    command.Parameters.AddWithValue(parameterName: "@UserName", request.UserName);
                    command.Parameters.AddWithValue(parameterName: "@Age", request.Age);
                    _mySqlConnection.Open();
                    int Status = await command.ExecuteNonQueryAsync();

                    if(Status<=0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong";
                    }
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                _mySqlConnection.Close();
            }
            return response;
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            ReadRecordResponse response = new ReadRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string SqlQuery = "Select UserName,Age from CrudOperationTable";
                using (MySqlCommand command = new MySqlCommand(SqlQuery,_mySqlConnection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 180;
                    _mySqlConnection.Open();
                    using(MySqlDataReader mySqlDataReader = (MySqlDataReader)await command.ExecuteReaderAsync())
                    {
                        if(mySqlDataReader.HasRows)
                        {
                            response.readRecordData = new List<ReadRecordData>();
                            while(await mySqlDataReader.ReadAsync())
                            {
                                ReadRecordData dbData = new ReadRecordData();
                                dbData.UserName = mySqlDataReader[name: "UserName"] != DBNull.Value ? mySqlDataReader[name: "UserName"].ToString() : string.Empty;
                                dbData.Age = mySqlDataReader[name: "Age"] != DBNull.Value ? Convert.ToInt32(mySqlDataReader[name: "Age"]) : 0;
                                response.readRecordData.Add(dbData);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _mySqlConnection.Close();
            }

            return response;
        }

        public async Task<UpdateRecordResponse> UpdateRecord(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = new UpdateRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            string SqlQuery = "Update CrudOperationTable Set UserName = @UserName,Age=@Age where Id = @Id";

            try
            {
                using(MySqlCommand command = new MySqlCommand(SqlQuery, _mySqlConnection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 180;
                    command.Parameters.AddWithValue(parameterName:"@UserName" , request.UserName);
                    command.Parameters.AddWithValue(parameterName: "@Age", request.Age);
                    command.Parameters.AddWithValue(parameterName: "@Id", request.Id);
                    _mySqlConnection.Open();

                    int status = await command.ExecuteNonQueryAsync();

                    if(status <=0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something went wrong";
                    }

                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _mySqlConnection.Close();

            }
            return response;
        }

        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = new DeleteRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            string SqlQuery = "Delete from CrudOperationTable where Id=@Id";

            try
            {
                using(MySqlCommand command = new MySqlCommand(SqlQuery, _mySqlConnection))
                {
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandTimeout = 180;
                    command.Parameters.AddWithValue(parameterName: "@Id", request.Id);
                    _mySqlConnection.Open();

                    int status = await command.ExecuteNonQueryAsync();

                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something went wrong";
                    }

                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _mySqlConnection.Close();

            }
            return response;

        }
    }
}
