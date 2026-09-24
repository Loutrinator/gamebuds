namespace GamebudsAPI.Models
{
    public class WordleWord
    {
        public int Id { get; set; }
        public required string Word { get; set; }
        public required string Lang { get; set; }
    }
}