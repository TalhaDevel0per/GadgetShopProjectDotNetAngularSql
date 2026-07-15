using HocGadgetShopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

namespace HocGadgetShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        [Route("SaveCustomerData")]
        public ActionResult SaveCustomerData(CustomerRequestDto requestDto)
        {
            //try
            {
                using (SqlConnection connection = new SqlConnection()
                {
                    ConnectionString = @"Server=localhost\SQLEXPRESS01;Database=gadgetshop;Trusted_Connection=True;"
                })
                {
                    SqlCommand command = new SqlCommand()
                    {
                        CommandText = "dbo.sp_SaveCustomerDetails",
                        CommandType = CommandType.StoredProcedure,
                        Connection = connection
                    };

                    command.Parameters.AddWithValue("@CustomerId", requestDto.CustomerId);
                    command.Parameters.AddWithValue("@FirstName", requestDto.FirstName);
                    command.Parameters.AddWithValue("@LastName", requestDto.LastName);
                    command.Parameters.AddWithValue("@Email", requestDto.Email);
                    command.Parameters.AddWithValue("@RegistrationDate", requestDto.RegistrationDate);
                    command.Parameters.AddWithValue("@Phone", requestDto.Phone);


                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();

                    return Ok();
                }
            }
        }

        [HttpGet]
        [Route("GetCustomerData")]
        public ActionResult GetCustomerData()
        {
            //try
            {
                using (SqlConnection connection = new SqlConnection()
                {
                    ConnectionString = @"Server=localhost\SQLEXPRESS01;Database=gadgetshop;Trusted_Connection=True;"
                })
                {
                    SqlCommand command = new SqlCommand()
                    {
                        CommandText = "dbo.sp_GetCustomerDetails",
                        CommandType = CommandType.StoredProcedure,
                        Connection = connection
                    };


                    connection.Open();
                    List<CustomerDto> customers = new List<CustomerDto>();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerDto customerDto = new CustomerDto();
                            customerDto.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                            customerDto.FirstName = Convert.ToString(reader["FirstName"]);
                            customerDto.LastName = Convert.ToString(reader["LastName"]);
                            customerDto.Phone = Convert.ToString(reader["Phone"]);
                            customerDto.Email = Convert.ToString(reader["Email"]);
                            customerDto.RegistrationDate = Convert.ToString(reader["RegistrationDate"]);
                            customers.Add(customerDto);
                        }
                    }

                    connection.Close();

                    return Ok(customers);
                }



            }
        }


        [HttpDelete]
        [Route("DeleteCustomerData")]
        public ActionResult DeleteCustomerData(int customerId)
        {
            //try
            {
                using (SqlConnection connection = new SqlConnection()
                {
                    ConnectionString = @"Server=localhost\SQLEXPRESS01;Database=gadgetshop;Trusted_Connection=True;"
                })
                {
                    SqlCommand command = new SqlCommand()
                    {
                        CommandText = "dbo.sp_DeleteCustomerDetails",
                        CommandType = CommandType.StoredProcedure,
                        Connection = connection
                    };

                    command.Parameters.AddWithValue("@CustomerId", customerId);



                    connection.Open();
                    command.ExecuteNonQuery();

                    connection.Close();

                    return Ok();
                }

            }
        }

        [HttpPut]
        [Route("UpdateInventoryData")]
        public ActionResult UpdateCustomerData(CustomerRequestDto customerRequest)
        {
            //try
            {
                using (SqlConnection connection = new SqlConnection()
                {
                    ConnectionString = @"Server=localhost\SQLEXPRESS01;Database=gadgetshop;Trusted_Connection=True;"
                })
                {
                    SqlCommand command = new SqlCommand()
                    {
                        CommandText = "dbo.sp_UpdateCustomerDetails",
                        CommandType = CommandType.StoredProcedure,
                        Connection = connection
                    };
                    connection.Open();

                    command.Parameters.AddWithValue("@CustomerId", customerRequest.CustomerId);
                    command.Parameters.AddWithValue("@FirstName", customerRequest.FirstName);
                    command.Parameters.AddWithValue("@LastName", customerRequest.LastName);
                    command.Parameters.AddWithValue("@Email", customerRequest.Email);
                    command.Parameters.AddWithValue("@RegistrationDate", customerRequest.RegistrationDate);
                    command.Parameters.AddWithValue("@Phone", customerRequest.Phone);


                    command.ExecuteNonQuery();
                    connection.Close();

                    return Ok("Updated Successfully");
                }





            }
        }
    }
}

