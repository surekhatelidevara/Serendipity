using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using DataManager;

/// <summary>
/// Summary description for MainMenuDAL
/// </summary>
public class MainMenuDAL
{
    DataUtilities objUtilities = new DataUtilities();
    public DataSet GetMainMenuDetails()
    {
        return objUtilities.ExecuteDataSet("GetMainMenuDetails");
    }
}