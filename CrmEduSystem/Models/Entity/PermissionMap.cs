using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbUtility;

namespace Models
{
    public partial class PermissionMap
    {
        Menu _Menu = new Menu();

        public Menu Menu
        {
            get
            {
                if (this.MID > 0 && (_Menu == null || _Menu.ID != this.MID))
                {
                    _Menu = new MenuLogic().GetMenu(this.MID);
                }
                if (_Menu == null) _Menu = new Menu(); ;
                return _Menu;
            }
            set { _Menu = value; }
        }
    }
}
