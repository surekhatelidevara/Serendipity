using DataManager;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityManager;
using System.Data;
/// <summary>
/// Summary description for LayoutDAL
/// </summary>
namespace BusinessLogic
{
    public class LayoutDAL
    {
        DataUtilities objUtilities = new DataUtilities();
        public DataSet GetLayoutDetails(int LayoutID)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@LayoutID", LayoutID);
            return objUtilities.ExecuteDataSet("GetLayoutDetails", ht);
        }
    }
}