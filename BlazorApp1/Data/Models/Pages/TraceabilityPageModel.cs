using Microsoft.EntityFrameworkCore;
using BlazorApp1.Database;
using BlazorApp1.DataBase.NewMesContext;

namespace BlazorApp1.Data.Models.Pages
{
    public class TraceabilityPageModel
    {
        public static string tabSelect = "display: inline-block;height: 60px;width: 300px;color: white;background-color: transparent;text-align: center;line-height: 60px;border: 0px solid black;-webkit-transform: translateY(20px);transform: translateY(20px);-webkit-animation: box_anim 1s;animation: box_anim 1s;";
        public static string tabNotSelect = "display: inline-block;height: 60px;width: 300px;color: white;background-color: transparent;text-align: center;line-height: 60px;border: 1px solid black;";

        public static string form_showStyle = " -webkit-animation: show_froms 1s; animation: show_froms 1s;";
        public static string form_NotshowStyle = "opacity:0;";
        //Текущий индекс таба
        public int IndexTabSelected { get; set; } = 0;
        //стиль таба как переменая
        public string? TabSearch_BarCode { get; set; }
        public string? TabSearch_Serial { get; set; }
        public string? TabSearch_DateTime { get; set; }
        public string? TabSearch_ICCID { get; set; }
        //Значения поиска табов
        public string? Value_BarCode { get; set; }
        public string? Value_Serial { get; set; }
        public DateTime Value_DateTime { get; set; } = DateTime.Now;
        public string? Value_ICCID { get; set; }
        //формы страниц с переменными стилей
        public string? from_BarCode { get; set; }
        public string? from_Serial { get; set; }
        public string? from_DateTime { get; set; }
        public string? from_ICCID { get; set; }

        private NewMes db { get; set; }//Запросы к БД
        public IQueryable<Mes>? DataLoad { get; set; }//Модель главной таблицы БД
        public ICollection<MesSelected> SelectItem { get; set; }
        public MesSelected InfoItem { get; set; }

        public void TabClick(int i)
        {
            switch (i)
            {
                case 1:
                    TabSearch_BarCode = tabSelect;
                    TabSearch_Serial = tabNotSelect;
                    TabSearch_DateTime = tabNotSelect;
                    TabSearch_ICCID = tabNotSelect;

                    from_BarCode = form_showStyle;
                    from_Serial = form_NotshowStyle;
                    from_DateTime = form_NotshowStyle;
                    from_ICCID = form_NotshowStyle;
                    break;
                case 2:
                    TabSearch_BarCode = tabNotSelect;
                    TabSearch_Serial = tabSelect;
                    TabSearch_DateTime = tabNotSelect;
                    TabSearch_ICCID = tabNotSelect;

                    from_BarCode = form_NotshowStyle;
                    from_Serial = form_showStyle;
                    from_DateTime = form_NotshowStyle;
                    from_ICCID = form_NotshowStyle;
                    break;
                case 3:
                    TabSearch_BarCode = tabNotSelect;
                    TabSearch_Serial = tabNotSelect;
                    TabSearch_DateTime = tabSelect;
                    TabSearch_ICCID = tabNotSelect;

                    from_BarCode = form_NotshowStyle;
                    from_Serial = form_NotshowStyle;
                    from_DateTime = form_showStyle;
                    from_ICCID = form_NotshowStyle;
                    break;
                case 4:
                    TabSearch_BarCode = tabNotSelect;
                    TabSearch_Serial = tabNotSelect;
                    TabSearch_DateTime = tabNotSelect;
                    TabSearch_ICCID = tabSelect;

                    from_BarCode = form_NotshowStyle;
                    from_Serial = form_NotshowStyle;
                    from_DateTime = form_NotshowStyle;
                    from_ICCID = form_showStyle;
                    break;
            }
            IndexTabSelected = i;
        }

        public void ClickSearch()
        {
            UpdateDb();
            switch (IndexTabSelected)
            {
                case 1:
                    DataLoad = db.Mes.Where(c => c.BarCode == Value_BarCode)
                        .Include(c => c.Pgs).Include(c => c.Ufk1).Include(c => c.Ufk3).Include(c => c.Printers);
                    break;
                case 2:
                    DataLoad = db.Mes.Where(c => c.BarCode == db.Ufk1.Where(c => c.Serial == Value_Serial).Select(c => c.MesBarCode).FirstOrDefault())
                        .Include(c => c.Pgs).Include(c => c.Ufk1).Include(c => c.Ufk3).Include(c => c.Printers);
                    break;
                case 3:
                    DataLoad = db.Mes.Where(c => (c.TimeCheck >= Value_DateTime) & (c.TimeCheck <= Value_DateTime.AddDays(1)))
                        .Include(c => c.Pgs).Include(c => c.Ufk1).Include(c => c.Ufk3).Include(c => c.Printers);
                    break;
                case 4:
                    DataLoad = db.Mes.Where(c => c.BarCode == db.Ufk3.Where(f => f.Iccid == Value_ICCID).Select(c => c.MesBarCode).FirstOrDefault())
                        .Include(c => c.Pgs).Include(c => c.Ufk1).Include(c => c.Ufk3).Include(c => c.Printers);
                    break;
            }
            if (DataLoad != null)
            {

            }
        }
        public void ClickItem(MesSelected sekMes)
        {
            InfoItem = sekMes;
        }
        private void UpdateDb()
        {
            db = new DataBase.NewMesContext.NewMes();
        }
        private void LoadDataSearch()
        {

        }
    }
}
