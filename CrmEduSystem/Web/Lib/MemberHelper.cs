
namespace Lib
{    
    public class MemberHelper
    {
        /// <summary>
        /// 得到用户头像
        /// </summary>
        public static string Avatar(string avatar)
        {
            if (string.IsNullOrEmpty(avatar))
                return Common.UrlHelper.HostUrl + "/areas/admin/content/img/avatar.png";
            else
                return avatar.ToString();
        }
        /// <summary>
        /// 得到用户头像
        /// </summary>
        public static string Avatar(int ID)
        {
            if (ID > 0)
                return Avatar(new Models.MemberLogic().GetMember(ID).Avatar);
            else
                return Avatar(string.Empty);
        }
    }
    
}
