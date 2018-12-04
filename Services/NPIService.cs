using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMBPublic.Model;
using System.Data.SqlClient;

namespace FMBPublic.Services
{
    public class NPIService : INPIService
    {

        private string cs;
        public NPIService(string _cs)
        {
            this.cs = _cs;
        }
        public List<NPISearchResult> SearchNPI(NPISearchRequest request)
        {
            List<NPISearchResult> res = new List<NPISearchResult>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(@"SELECT TOP 100 CONVERT(bigint	, ROW_NUMBER() OVER( ORDER BY NPI) ) Id,
                * FROM (SELECT * FROM (SELECT [NPI],CASE WHEN [Provider_Last_Name_Legal_Name_] IS NOT NULL 
                THEN ISNULL([Provider_Last_Name_Legal_Name_], '')
                ELSE[Provider_Organization_Name_Legal_Business_Name_] END AS LastNameOrEntity ,
                ISNULL([Provider_Name_Prefix_Text],'') [Prefix],
                ISNULL([Provider_First_Name],'')+' '+ISNULL([Provider_Middle_Name],'') FirstAndMiddle,
                [Provider_First_Line_Business_Mailing_Address]+CHAR(10)+[Provider_Second_Line_Business_Mailing_Address] MailingAddress,
                [Provider_Business_Mailing_Address_State_Name] [State],
                [Provider_Business_Mailing_Address_Postal_Code]
                        [Zip],[Healthcare_provider_taxonomy_code_1] Taxonomy
                        FROM[dbo].[NPI] ) AS SUB
                WHERE(@FirstName IS NULL OR FirstAndMiddle LIKE '%'+@FirstName+'%')
                AND(@LastName_E IS NULL OR LastNameOrEntity LIKE '%'+@LastName_E+'%')
                AND(@NPI =0 OR NPI = @NPI)
                AND(@State = 'All States' OR State LIKE '%'+@State+'%')) AS SUB", conn))
                {
                    comm.Parameters.AddWithValue("@FirstName", DBN( request.FirstName));
                    comm.Parameters.AddWithValue("@LastName_E", DBN(request.LastName_E));
                    comm.Parameters.AddWithValue("@NPI", request.NPI);
                    comm.Parameters.AddWithValue("@State", request.State);

                    var reader = comm.ExecuteReader();
                    object[] o = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(o);
                        res.Add(new NPISearchResult()
                        {
                            Id = long.Parse(o[0].ToString()),
                            NPI = decimal.Parse(o[1].ToString()),
                            LastNameOrEntity = o[2].ToString(),
                            Prefix = o[3].ToString(),
                            FirstAndMiddle = o[4].ToString(),
                            MailingAddress = o[5].ToString(),
                            State = o[6].ToString(),
                            Zip = o[7].ToString(),
                            Taxonomy= o[8].ToString()
                        });
                    }
                    conn.Close();
                }
            }
            return res;
        }

        private object DBN(string firstName)
        {
            if (firstName == null)
                return DBNull.Value;
            return firstName;
        }

     
    }
}
