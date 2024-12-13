using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hotelData : System.Web.UI.Page
{

    private SysSqlDB dbSql = new SysSqlDB();
    private System.Data.DataView dvSql;


    public void OpenDatabase_and_LinkTo()
    {
        String strHtml = "";
        String strTemp = "";

        SysSqlDB dbTempSql = new SysSqlDB();
        System.Data.DataView dvTempSql;

        dbSql.SelectCommand = "Select * From [hotel] Order By [ID] Asc";
        dbSql.SelectParameters.Clear();
        dvSql = (System.Data.DataView)dbSql.Select();
        for (int i = 0; i < dvSql.Count; i++)
        {
            strTemp = "";
            dbTempSql.SelectCommand = "Select * From [room] Where [H_ID] = @H_ID Order By [ID] Asc";
            dbTempSql.SelectParameters.Clear();
            dbTempSql.SelectParameters.Add("H_ID", dvSql[i]["ID"].ToString().Trim());
            dvTempSql = (System.Data.DataView)dbTempSql.Select();
            for (int n = 0; n < dvTempSql.Count; n++)
            {
                strTemp += ((n == 0) ? "" : "<br/>");
                strTemp += "ID：" + dvTempSql[n]["ID"].ToString().Trim();
                strTemp += "&nbsp;&nbsp;&nbsp;房型：" + dvTempSql[n]["type"].ToString().Trim();
                strTemp += "&nbsp;&nbsp;&nbsp;價錢：" + dvTempSql[n]["prices"].ToString().Trim();
            }

            strHtml += "<tr>";
            strHtml += "<td>";
            strHtml += dvSql[i]["ID"].ToString().Trim();
            strHtml += "</td>";
            strHtml += "<td>";
            strHtml += dvSql[i]["name"].ToString().Trim();
            strHtml += "</td>";
            strHtml += "<td>";
            strHtml += dvSql[i]["description"].ToString().Trim();
            strHtml += "</td>";
            strHtml += "<td>";
            strHtml += strTemp;
            strHtml += "</td>";
            strHtml += "</tr>";
        }

        dataLiteral.Text = strHtml;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OpenDatabase_and_LinkTo();
        }
    }
}