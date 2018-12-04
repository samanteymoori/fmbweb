using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FMBPublic.Model;
using System.Data.SqlClient;
using FMBPublic.Contracts;

namespace FMBPublic.Services
{
    public class Icd10Service : Iicd10Service
    {
        private string cs;
        public Icd10Service(string _cs)
        {
            this.cs = _cs;
        }
        public List<Icd10SearchResponse> SearchIcd10(Icd10SearchRequest request)
        {
            List<Icd10SearchResponse> res = new List<Icd10SearchResponse>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(@"
                SELECT Top 100 ID,Icd10Code,IsHeader,LongDescription FROM ICD10 
                WHERE
                 (@Description IS NULL OR ("+request.getCriteria()+@"))
                ORDER BY Icd10Code
                ", conn))
                {
                    comm.Parameters.AddWithValue("@Description", DBN(request.Description));

                    var reader = comm.ExecuteReader();
                    object[] o = new object[reader.FieldCount];
                    while (reader.Read())
                    {
                        reader.GetValues(o);
                        res.Add(new Icd10SearchResponse()
                        {
                            ID = float.Parse(o[0].ToString()),
                            ICD10Code= (o[1].ToString()),
                            IsHeader= float.Parse(o[2].ToString()),
                            LongDescription= (o[3].ToString()),

                        });
                    }
                    conn.Close();
                }
            }
            return res;
        }


        private object DBN(string code)
        {
            if (code == null)
                return DBNull.Value;
            return code;
        }
    }
}
