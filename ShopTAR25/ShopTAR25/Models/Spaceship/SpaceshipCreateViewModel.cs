namespace ShopTAR25.Models.Spaceship
{
    public class SpaceshipCreateViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Classification { get; set; } = string.Empty;
        public DateTime? BuildTime { get; set; }
        public int? crew { get; set; }
        public int? EnginePower { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
