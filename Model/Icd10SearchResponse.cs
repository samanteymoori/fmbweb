namespace FMBPublic.Model
{
    public class Icd10SearchResponse
    {
        public float ID { get; set; }
        public string ICD10Code { get; set; }

        public float IsHeader { get; set; }

        public string LongDescription { get; set; }
    }
}