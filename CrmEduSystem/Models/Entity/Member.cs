using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbUtility;

namespace Models
{
    public partial class Member
    {
        /// <summary>
        /// 角色
        /// </summary>
        Role _Role = new Role();
        public Role Role
        {
            get
            {
                if (RoleID > 0 && (_Role == null || _Role.ID != this.RoleID))
                {
                    _Role = new RoleLogic().GetRole(RoleID);
                }
                if (_Role == null) _Role = new Role();
                return _Role;
            }
            set
            {
                _Role = value;
            }
        }
    }
}



