using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Service_Excange_Rates.Models.CallingStoredProcedure
{
    public class DataAccess
    {
        
            //using (OracleConnection con = new OracleConnection(connectionString))
            //{
            //    OracleCommand cmd = new OracleCommand("GET_PS_CARD_TYPE", con);
    public List<TestModel> GetData()
        {
            OracleConnection conn = new OracleConnection(WebConfigurationManager.ConnectionStrings["ConnString"].ConnectionString);
            string oracleQuery = "select * from Z_069_VIEW_EXCHANGE_RATES t";

            OracleCommand com = new OracleCommand(oracleQuery, conn);
            //com.CommandType = System.Data.CommandType.StoredProcedure;
            //com.Parameters.Add("RES", OracleDbType.RefCursor, System.Data.ParameterDirection.Output);
            List<TestModel> lis = new List<TestModel>();
            TestModel test = new TestModel();
            try
            {

                conn.Open();
                OracleDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {


                    test.valCode = dr["V_CODE"].ToString();
                    test.rateDt = dr["RATEDT"].ToString();
                    if (dr["BUYORSEL"].ToString() != null)
                    {
                        test.buyOrSel = Convert.ToInt32(dr["BUYORSEL"]);
                    }
                    else
                        test.buyOrSel = 0;
                    if (dr["RATE"].ToString() != null)
                    {
                        test.rate = Convert.ToDouble(dr["RATE"]);
                    }
                    else
                    {
                        test.rate = 0;
                    }
                    lis.Add(test);


                }
                dr.Close();


            }
            catch (Exception ex)
            {

            }
            finally
            {

                conn.Close();

            }
            return lis;
        }
    }
}