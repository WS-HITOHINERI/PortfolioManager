namespace PortfolioManager
{
    public class AppInfo
    {
        public string Title { get; set; }
        public string CreatedAt { get; set; }
        public string Link { get; set; } // ← LinkUrl を統合
        public string Summary { get; set; }
        public string Concept { get; set; }
        public string ImageUrl { get; set; }

        [System.Text.Json.Serialization.JsonIgnore] // JSON保存対象外
        public Image ImageObject { get; set; } // 表示用画像
    }
}

