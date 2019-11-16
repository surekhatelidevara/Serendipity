using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityManager
{
    public class SubMenuEntity
    {
        public int SubMenuID { get; set; }
        public int MainMenuID { get; set; }
        public string SubMenuName { get; set; }
        public int Status { get; set; }
    }
}