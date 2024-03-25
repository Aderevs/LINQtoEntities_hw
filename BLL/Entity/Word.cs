namespace BLL.Entity
{
    public class Word
    {
        public Guid Id { get; set; }
        public string Header { get; set; }
        public string KeyWord { get; set; }
        public List<KeyParams> ProductLink { get; set; }
    }
}
