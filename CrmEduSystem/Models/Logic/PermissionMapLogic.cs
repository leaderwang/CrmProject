using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbUtility;
using Common;


namespace Models
{
    public partial class PermissionMapLogic
    {
        /// <summary>
        /// 添加菜单权限
        /// </summary>
        /// <param name="menuID"></param>
        public static void AddMenuPermissionMap(int menuID)
        {
            try
            {
                var mt = new PermissionMapLogic().GetPermissionMap(new PermissionMap() { MID = menuID, Name = "菜单" });
                if (mt == null || mt.ID == 0)
                {
                    var pml = new PermissionMapLogic();
                    var pmt = new PermissionMap()
                    {
                        SortID = 0,
                        MID = menuID,
                        Name = "菜单",
                        Description = "菜单",
                        IsBasic = 0,
                        CreateUserID = 2,
                        LastUpdateUserID = 2,
                        CreateDate = DateTime.Now,
                        LastUpdateDate = DateTime.Now,
                        IsDeleted = false
                    };
                    pml.Add(pmt);
                }

            }
            catch { }
        }

    }
}
