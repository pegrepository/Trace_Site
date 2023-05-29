using BlazorApp1.DataContext.Permissions;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data.Models.Pages
{
    public class SiteSettingsPageModel
    {
        public PermissionsContext DBContext { get; set; }

        /// <summary>
        /// Администрирование сайта
        /// </summary>
        /// <param name="permissionRules"></param>
        /// <param name="employeesList"></param>
        /// <param name="webSitePagesList"></param>
        /// <param name="permissionsList"></param>
        public SiteSettingsPageModel()
        {
            DBContext = new PermissionsContext();     
        }

        /// <summary>
        /// Создание правила
        /// </summary>
        /// <param name="permissionRule"></param>       
        public int CreateNewRule(PermissionRules permissionRule)
        {
            try
            {
                DBContext.Add(permissionRule);
                DBContext.SaveChanges();
                return permissionRule.RuleId;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        /// <summary>
        /// Удаление вида разрешения
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool DeletePermission(PermissionsList item)
        {
            try
            {
                //DBContext.Remove(item);
                DBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Удаление страницы
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public bool DeletePage(WebSitePagesList page)
        {
            try
            {
                //DBContext.Remove(page);
                DBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        /// <summary>
        /// Удаление правила
        /// </summary>
        /// <param name="permissionRule"></param>
        public bool DeleteRule(PermissionRules permissionRule)
        {
            try
            {
                DBContext.Remove(permissionRule);
                DBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Создание юзера
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public EmployeesList CreateNewUser(UserModel user)
        {
            EmployeesList newEmployee = new EmployeesList();
            //Если пользователь отсутствует в БД
            if (DBContext.EmployeesList.Where(e => e.EmployeeLogin == user.UserName).FirstOrDefault() == null)
            {
                newEmployee = new EmployeesList { EmployeeCard = user.CardId, EmployeeName = user.UserName };
                DBContext.Add(newEmployee);
                DBContext.SaveChanges();
            }
            return newEmployee;
        }

        /// <summary>
        /// Удаление юзера
        /// </summary>
        /// <param name="empl"></param>
        /// <returns></returns>
        public bool DeleteUser(EmployeesList empl)
        {
            try
            {
                var listToDelete = DBContext.PermissionRules.Where(e => e.EmployeeId == empl.EmployeeId).ToList();
                foreach(var rule in listToDelete)
                {
                    DBContext.Remove(rule);
                }
                DBContext.Remove(empl);
                DBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    public class PremisionRuleModel
    {
        public int EmployeeId { get; set; }
        public int PermissionId { get; set; }
        public int RuleId { get; set; }
    }
    public class UserModel
    {
        public string CardId { get; set; }
        public string userName = string.Empty;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
    }
}
