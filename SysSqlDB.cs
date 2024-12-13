using System;
using System.Collections.Generic;
using System.Web;

public class SysSqlDB : System.Web.UI.WebControls.SqlDataSource
{
    //讀取 SQL Express 資料庫
    private const string providerstr = "System.Data.SqlClient";
    private const string connstr = "Data Source=DESKTOP-JJ7PRVU\\SQLEXPRESS04;Initial Catalog=homework;Integrated Security=True";




    public SysSqlDB()
        : base(providerstr, connstr, "")
    {
    }

    //簡化 Select() 方法的用法
    public System.Collections.IEnumerable Select()
    {
        return base.Select(new System.Web.UI.DataSourceSelectArguments());
    }

    //也保留原始 Select() 方法的用法
    public System.Collections.IEnumerable Select(System.Web.UI.DataSourceSelectArguments arguments)
    {
        return base.Select(arguments);
    }

    public string GetString_ConnectionString
    {
        get { return connstr; }
    }

    public string GetString_ProviderName
    {
        get { return providerstr; }
    }

}
