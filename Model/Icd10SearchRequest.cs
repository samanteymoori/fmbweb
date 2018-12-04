using System;
using System.Collections.Generic;
using System.Text;

namespace FMBPublic.Model
{
    public class Icd10SearchRequest
    {
        public string Code { get; set; }
        public string Description { get; set; }

        internal string getCriteria()
        {
            List<string> lst = new List<string>();
            var parts = Description.Split(new string[] { " " }, StringSplitOptions.None);
            foreach (var item in parts)
            {
                lst.Add("[LongDescription] LIKE '%" + item + "%'");

            }
            return string.Join(" AND ", lst.ToArray());
        }
    }
}