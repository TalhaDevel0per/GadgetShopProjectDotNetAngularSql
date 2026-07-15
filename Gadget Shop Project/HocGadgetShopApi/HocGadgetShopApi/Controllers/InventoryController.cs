//using HocGadgetShopApi.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Data;
//using System.Data.SqlClient;

//namespace HocGadgetShopApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class InventoryController : ControllerBase
//    {
//        [HttpPost]
//        public ActionResult SaveInventoryData(InventoryRequestDto requestDto)
//        {
//            using (SqlConnection connection = new SqlConnection()
//            {
//                ConnectionString = @"Server=localhost\SQLEXPRESS01;Database=gadgetshop;Trusted_Connection=True;"
//            })
//            {
//                SqlCommand command = new SqlCommand()
//                {
//                    CommandText = "dbo.sp_SaveInventoryData",
//                    CommandType = CommandType.StoredProcedure,
//                    Connection = connection
//                };

//                command.Parameters.AddWithValue("@ProductId", requestDto.ProductId);
//                command.Parameters.AddWithValue("@ProductName", requestDto.ProductName);
//                command.Parameters.AddWithValue("@AvailableQty", requestDto.AvailableQty);
//                command.Parameters.AddWithValue("@ReOrderPoint", requestDto.ReOrderPoint);

//                connection.Open();
//                command.ExecuteNonQuery();

//                return Ok();
//            }
//        }

//        [HttpGet]
//        [Route("GetInventoryData")]
//        public ActionResult GetInventoryData()
//        {
//            using (SqlConnection connection = new SqlConnection()
//            {
//                ConnectionString = @"Server=localhost\SQLEXPRESS01;Database=gadgetshop;Trusted_Connection=True;"
//            })
//            {
//                SqlCommand command = new SqlCommand()
//                {
//                    CommandText = "dbo.sp_GetInventoryData",
//                    CommandType = CommandType.StoredProcedure,
//                    Connection = connection
//                };

//                connection.Open();

//                List<InventoryDto> response = new List<InventoryDto>();

//                using (SqlDataReader sqlDataReader = command.ExecuteReader())
//                {
//                    while (sqlDataReader.Read())
//                    {
//                        InventoryDto inventoryDto = new InventoryDto();

//                        inventoryDto.ProductId = Convert.ToInt32(sqlDataReader["ProductId"]);
//                        inventoryDto.ProductName = Convert.ToString(sqlDataReader["ProductName"]);
//                        inventoryDto.AvailableQty = Convert.ToInt32(sqlDataReader["AvailableQty"]);
//                        inventoryDto.ReOrderPoint = Convert.ToInt32(sqlDataReader["ReOrderPoint"]);

//                        response.Add(inventoryDto);
//                    }
//                }


//                return Ok(response);
//            }
//        }

//        [HttpDelete]
//        [Route("DeleteInventoryData")]
//        public ActionResult DeleteInventoryData(int productId)
//        {
//            try
//            {
//                using (SqlConnection connection = new SqlConnection()
//                {
//                    ConnectionString = @"Server=localhost\SQLEXPRESS01;Database=gadgetshop;Trusted_Connection=True;"
//                })
//                {
//                    SqlCommand command = new SqlCommand()
//                    {
//                        CommandText = "dbo.sp_DeleteInventoryDetails",
//                        CommandType = CommandType.StoredProcedure,
//                        Connection = connection
//                    };

//                    connection.Open();

//                    command.Parameters.AddWithValue("@ProductId", productId);


//                    command.ExecuteNonQuery();

//                    connection.Close();
//                    return Ok();
//                }
//            }

//            }

//        [HttpPut]
//        [Route("UpdateInventoryData")]
//        public ActionResult UpdateInventoryData(InventoryRequestDto inventoryRequest)
//        {
//            try
//            {
//                using (SqlConnection connection = new SqlConnection()
//                {
//                    ConnectionString = @"Server=localhost\SQLEXPRESS01;Database=gadgetshop;Trusted_Connection=True;"
//                })
//                {
//                    SqlCommand command = new SqlCommand()
//                    {
//                        CommandText = "dbo.sp_UpdateInventoryData",
//                        CommandType = CommandType.StoredProcedure,
//                        Connection = connection
//                    };

//                    connection.Open();

//                    command.Parameters.AddWithValue("@ProductId", inventoryRequest.ProductId);
//                    command.Parameters.AddWithValue("@ProductName", inventoryRequest.ProductName);
//                    command.Parameters.AddWithValue("@AvailableQty", inventoryRequest.AvailableQty);
//                    command.Parameters.AddWithValue("@ReOrderPoint", inventoryRequest.ReOrderPoint);




//                    command.ExecuteNonQuery();

//                    connection.Close();
//                    return Ok();
//                }
//            }


//            catch (Exception ex)
//            {
//                Console.WriteLine(ex);
//                return Ok();
//            }




//        }




//// CLEAR CODE  IS HERE //
///



using HocGadgetShopApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace HocGadgetShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        // ==========================
        // INSERT DATA
        // ==========================
        [HttpPost]
        public ActionResult SaveInventoryData(InventoryRequestDto requestDto)
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
                        CommandText = "dbo.sp_SaveInventoryData",
                        CommandType = CommandType.StoredProcedure,
                        Connection = connection
                    };

                    command.Parameters.AddWithValue("@ProductId", requestDto.ProductId);
                    command.Parameters.AddWithValue("@ProductName", requestDto.ProductName);
                    command.Parameters.AddWithValue("@AvailableQty", requestDto.AvailableQty);
                    command.Parameters.AddWithValue("@ReOrderPoint", requestDto.ReOrderPoint);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return Ok("Data Saved Successfully");
                }
            }
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }

        // ==========================
        // GET DATA
        // ==========================
        [HttpGet]
        [Route("GetInventoryData")]
        public ActionResult GetInventoryData()
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
                        CommandText = "dbo.sp_GetInventoryData",
                        CommandType = CommandType.StoredProcedure,
                        Connection = connection
                    };

                    connection.Open();

                    List<InventoryDto> response = new List<InventoryDto>();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InventoryDto inventory = new InventoryDto();

                            inventory.ProductId = Convert.ToInt32(reader["ProductId"]);
                            inventory.ProductName = Convert.ToString(reader["ProductName"]);
                            inventory.AvailableQty = Convert.ToInt32(reader["AvailableQty"]);
                            inventory.ReOrderPoint = Convert.ToInt32(reader["ReOrderPoint"]);

                            response.Add(inventory);
                        }
                    }

                    return Ok(response);
                }
            }
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }

        // ==========================
        // DELETE DATA
        // ==========================
        [HttpDelete]
        [Route("DeleteInventoryData")]
        public ActionResult DeleteInventoryData([FromQuery] int productId)
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
                        CommandText = "dbo.sp_DeleteInventoryDetails",
                        CommandType = CommandType.StoredProcedure,
                        Connection = connection
                    };

                    command.Parameters.AddWithValue("@ProductId", productId);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return Ok("Deleted Successfully");
                }
            }
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }

        // ==========================
        // UPDATE DATA
        // ==========================
        [HttpPut]
        [Route("UpdateInventoryData")]
        public ActionResult UpdateInventoryData(InventoryRequestDto requestDto)
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
                        CommandText = "dbo.sp_UpdateInventoryData",
                        CommandType = CommandType.StoredProcedure,
                        Connection = connection
                    };
                    connection.Open();

                    command.Parameters.AddWithValue("@ProductId", requestDto.ProductId);
                    command.Parameters.AddWithValue("@ProductName", requestDto.ProductName);
                    command.Parameters.AddWithValue("@AvailableQty", requestDto.AvailableQty);
                    command.Parameters.AddWithValue("@ReOrderPoint", requestDto.ReOrderPoint);


                    command.ExecuteNonQuery();
                    connection.Close();

                    return Ok("Updated Successfully");
                }
            }
        }



                }
            }
        