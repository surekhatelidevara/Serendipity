using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EntityManager;
using DataManager;
public partial class MasterPage : System.Web.UI.MasterPage
{
    MainMenuDAL objMainMenuDAL = new MainMenuDAL();
    SubMenuDAL objSubMenuDAL = new SubMenuDAL();
    DataSet dataset = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        DataSet ds = objMainMenuDAL.GetMainMenuDetails(0);
        
        DataTable dt = ds.Tables[0];
        HtmlGenericControl main = UList("Menuid", "nav navbar-nav");
        foreach (DataRow row in dt.Rows)
        {
            dataset = objMainMenuDAL.GetSubMenuForMain(Convert.ToInt32(row["MainMenuID"]));
            DataTable dtSub = dataset.Tables[0];
            if (dtSub.Rows.Count > 0)
            {
                HtmlGenericControl sub_menu = LIList(row["MenuName"].ToString(), row["MainMenuID"].ToString(), "");
                HtmlGenericControl ul = new HtmlGenericControl("ul");
                foreach (DataRow r in dtSub.Rows)
                {
                    ul.Controls.Add(LIList(r["SubMenuName"].ToString(), row["MainMenuID"].ToString(), ""));
                }
                sub_menu.Controls.Add(ul);
                main.Controls.Add(sub_menu);
            }
            else
            {
                main.Controls.Add(LIList(row["MenuName"].ToString(), row["MainMenuID"].ToString(), ""));
            }
        }
        Panel1.Controls.Add(main);
    }


    private HtmlGenericControl UList(string id, string cssClass)
    {
        HtmlGenericControl ul = new HtmlGenericControl("ul");
        ul.ID = id;
        ul.Attributes.Add("class", cssClass);
        return ul;
    }
    private HtmlGenericControl LIList(string innerHtml, string rel, string url)
    {
        HtmlGenericControl li = new HtmlGenericControl("li");
        li.Attributes.Add("rel", rel);
        li.InnerHtml = "<a href=" + string.Format("http://{0}", url) + ">" + innerHtml + "<i class='fa fa-angle-down'></i></a>";
        return li;
    }
}
