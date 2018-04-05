using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbUtility;

namespace Models
{
    public partial class PermissionData
    {
        PermissionMap _PermissionMap = new PermissionMap();

        public PermissionMap PermissionMap
        {
            get
            {
                if (this.PID > 0 && (_PermissionMap == null || _PermissionMap.ID != this.PID))
                {
                    _PermissionMap = new PermissionMapLogic().GetPermissionMap(this.PID);
                }
                if (_PermissionMap == null) _PermissionMap = new PermissionMap();
                return _PermissionMap;
            }
            set { _PermissionMap = value; }
        }
    }
}
