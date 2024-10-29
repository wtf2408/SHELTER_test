namespace SHELTER_test_task_api
{
    public class Company : IEquatable<Company>
    {
        public int ID { get; set; }
        public int? ParentCompanyID { get; set; }
        public string Name { get; set; }
        public string INN { get; set; }
        public string Phone { get; set; }

        public bool Equals(Company? other)
        {
            return this.INN == other?.INN;
        }
        public override int GetHashCode()
        {
            return this.INN.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            return this.Equals(obj as Company);
        }
    }
}
