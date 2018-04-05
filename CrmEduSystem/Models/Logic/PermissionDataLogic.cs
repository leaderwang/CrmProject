using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbUtility;
using Common;


namespace Models
{
    public partial class PermissionDataLogic
    {
        DBContext db = new DBContext();


        /// <summary>
        /// 清除某人或某角色的权限记录
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="type">type=0为角色，否则为用户</param>
        public void DeleteByMIDOrRID(int id, int type)
        {
            string sql = "";
            if (type == 0)
            {
                sql = "DELETE FROM [dbo].[PermissionData] WHERE [RID]=" + id;
            }
            else
            {
                sql = "DELETE FROM [dbo].[PermissionData] WHERE [MID]=" + id;
            }
            db.ExecuteNonQuerySql(sql);
        }
    }
}
