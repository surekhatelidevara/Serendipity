using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using DataManager;
using System.Collections;

/// <summary>
/// Summary description for MainMenuDAL
/// </summary>
public class MainMenuDAL
{
    DataUtilities objUtilities = new DataUtilities();
    public DataSet GetMainMenuDetails(int MainMenuID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@MainMenuID",MainMenuID);
        return objUtilities.ExecuteDataSet("GetMainMenuDetails", ht);
    }
}