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
    public DataSet GetSubMenuDetails()
    {
        return objUtilities.ExecuteDataSet("GetSubMenuDetails");
    }
}