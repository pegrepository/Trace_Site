namespace BlazorApp1.DataBase.NewMesContext
{
    public class MesSelected
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public TimeSpan TimeT { get; set; }
        public string? NameProduct { get; set; }
        public string? Station { get; set; }
        public string? BarCodeSearch { get; set; }
        public int? KU { get; set; }
        public string? Result { get; set; }
    }
}
