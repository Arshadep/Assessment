using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RequestWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RequestService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RequestService.svc or RequestService.svc.cs at the Solution Explorer and start debugging.
    public class RequestService : IRequestService
    {
        public int CheckForRequests()
        {

            int result;
            var ConString = ConfigurationManager.ConnectionStrings["DBReqContext"].ConnectionString;
            string Query = "select count(Status) from Requests";
            
            using (SqlConnection con = new SqlConnection(ConString))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                 result = (int)cmd.ExecuteScalar();
                 return result;
            }


        }

        public GetRequestList GetInfo()
        {
            GetRequestList g = new GetRequestList();
            var ConString = ConfigurationManager.ConnectionStrings["DBReqContext"].ConnectionString;
            string Query = "select RequestId,CreatedAt,Status,UpdatedAt from Requests";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Mytab");
                myAdapter.Fill(dt);
                g.ReqTble = dt;
                return g;
            }
        }

        public void UpdateRequest(int requestID, bool approve)
        {
            var ConString = ConfigurationManager.ConnectionStrings["DBReqContext"].ConnectionString;
            string Query = "update Requests set Status=@status,UpdatedAt=@UpdatedAt where RequestId='" + requestID + "'";

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                //SqlDataReader reader = cmd.ExecuteReader();
                if (approve)
                {
                    SqlCommand cmdApprove = new SqlCommand(Query, con);
                    cmdApprove.Parameters.AddWithValue("@status", 1);
                    cmdApprove.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmdApprove.ExecuteNonQuery();

                }
                else
                {
                    SqlCommand cmdRejected = new SqlCommand(Query, con);
                    cmdRejected.Parameters.AddWithValue("@status", 2);
                    cmdRejected.Parameters.AddWithValue("@UpdatedAt", DateTime.Now);
                    cmdRejected.ExecuteNonQuery();
                }



                //if (reader.HasRows)
                //{
                //    while (reader.Read())
                //    {


                //        var val1 = reader[0].ToString();
                //        var val2 = reader[1].ToString();
                //        var val3 = reader[2].ToString();
                //        var val4 = reader[3].ToString();


                //    }
                //    reader.Close();
                //}


            }


        }
    }
}
