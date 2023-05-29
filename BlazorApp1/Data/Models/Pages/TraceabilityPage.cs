namespace BlazorApp1.Data.Models.Pages
{
    public class TraceabilityPage
    {
        public Dictionary<int, string> SearchType = new Dictionary<int, string>
        {
            {1, "Поиск по Баркоду" },
            {2, "Поиск по Серийному номеру" },
            {3, "Поиск по Дате" },
            {4, "Поиск по ICCID" },
            {5, "Поиск по BoxId" }
        };

    }
    public class CPtableModel
    {
        public int Id { get; set; }
        public string BarCode { get; set; }
        public int? ProductId { get; set; }
        public DateTime? CheckTime { get; set; }
        public string Name { get; set; }
        public bool Result { get; set; }
        public string? Error { get; set; }
    }
}
