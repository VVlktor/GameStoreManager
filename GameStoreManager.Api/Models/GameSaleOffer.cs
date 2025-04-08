namespace GameStoreManager.Client.Models
{
    public class GameSaleOffer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Platform { get; set; }
        public DateTime LastAlterDate { get; set; }
    }
}
