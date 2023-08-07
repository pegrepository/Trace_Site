using BlazorApp1.DataContext.Permissions;
using Newtonsoft.Json;

namespace BlazorApp1.Components.Authorization
{
    public class Authorization
    {

        private static EmployeesList responseEmployees = null;
        private static WebSitePagesList responseWebSitePagesList = null;
        private static PermissionRules responsePermissionRules = null;

        public static bool AuthorizationCheck(string userName, string pageName)
        {
            GettingPermissionDataFromApi(userName, pageName);

            if (responseEmployees == null)
            {
                //TODO:Выполняем POst В Emloyees таблицу
            }

            if (responseWebSitePagesList == null)
            {
                //TODO:Выполнеяем POst В WebSitePagesLis таблицу
            }

            //Проверка на Админа; Админ это 1, просто user  это 2
            if (responsePermissionRules.PermissionId == 1)
            {
               return true;
            }
            else
            {
               return false;
            }
        }

        private static void GettingPermissionDataFromApi(string userName, string pageName)
        {

            Parallel.Invoke(
                () =>
                {
                    using (var client = new System.Net.WebClient())
                    {
                        responseEmployees = JsonConvert.DeserializeObject<List<DataContext.Permissions.EmployeesList>>(client.DownloadString($"http://192.168.96.139:5139/api/Permissions/GetFrom_EmployeesList_ByEmployeeLogin/{userName}")).FirstOrDefault();//Посылаем запрос на получение строки
                    }
                },

                () =>
                {
                    using (var client2 = new System.Net.WebClient())
                    {
                        responseWebSitePagesList = JsonConvert.DeserializeObject<List<DataContext.Permissions.WebSitePagesList>>(client2.DownloadString($"http://192.168.96.139:5139/api/Permissions/GetFrom_WebSitePagesList_ByWebSitePageName/{pageName}")).FirstOrDefault();//Посылаем запрос на получение строки
                    }
                });

            using (var client3 = new System.Net.WebClient())
            {
                responsePermissionRules = JsonConvert.DeserializeObject<List<DataContext.Permissions.PermissionRules>>(client3.DownloadString($"http://192.168.96.139:5139/api/Permissions/GetFrom_PermissionRule_ByEmployeeIdAndWebSitePageId/{responseEmployees.EmployeeId}/{responseWebSitePagesList.WebSitePageId}")).FirstOrDefault();
            };
        }

    }
}
