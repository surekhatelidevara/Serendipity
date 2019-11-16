using DataManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SubMenuDAL
/// </summary>
public class SubMenuDAL
{
    DataUtilities objUtilities = new DataUtilities();
    public DataSet GetSubMenuDetails(int SubMenuID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@SubMenuID", SubMenuID);
        return objUtilities.ExecuteDataSet("GetSubMenuDetails",ht);
    }
}