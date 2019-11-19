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
using BusinessLogic;
public partial class MasterPage : System.Web.UI.MasterPage
{
    MainMenuDAL objMainMenuDAL = new MainMenuDAL();
    SubMenuDAL objSubMenuDAL = new SubMenuDAL();
    DataSet dataset = new DataSet();
    LayoutEntity objLayoutEntity = new LayoutEntity();
    LayoutDAL objLayoutDAL = new LayoutDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindMenu();
            BindLogo();
        }
    }
    public void BindLogo()
    {
        try
        {
            dataset = objLayoutDAL.GetLayoutDetails(1);
            lblMail.Text = dataset.Tables[0].Rows[0]["EmailID"].ToString();
            lblPhone.Text = dataset.Tables[0].Rows[0]["PhoneNumber"].ToString();
            string image="/images/"+ dataset.Tables[0].Rows[0]["LogoImage"].ToString();
            imgLogo.ImageUrl = image;
        }
        catch
        {

        }
    }
    public void BindMenu()
    {
        try
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
                    HtmlGenericControl sub_menu = LIList(row["MenuName"].ToString(), row["MainMenuID"].ToString(), row["Url"].ToString());
                    HtmlGenericControl ul = new HtmlGenericControl("ul");
                    foreach (DataRow r in dtSub.Rows)
                    {
                        ul.Controls.Add(LIList(r["SubMenuName"].ToString(), row["MainMenuID"].ToString(), r["Url"].ToString()));
                    }
                    sub_menu.Controls.Add(ul);
                    main.Controls.Add(sub_menu);
                }
                else
                {
                    main.Controls.Add(LIList(row["MenuName"].ToString(), row["MainMenuID"].ToString(), row["Url"].ToString()));
                }
            }
            Panel1.Controls.Add(main);
        }
        catch
        {

        }
       
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
        li.InnerHtml = "<a href=" + string.Format("http://{0}", url) + ">" + innerHtml + "</a>";
        return li;
    }
}
