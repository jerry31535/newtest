using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class order : System.Web.UI.Page
{

    private SysSqlDB dbSql = new SysSqlDB();
    private System.Data.DataView dvSql;


    public void On_ButtonClick(Object sender, System.Web.UI.WebControls.CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Query":
                if (IDTextBox.Text.Trim() == "")
                {
                    errMsgLabel.Text = "您的 ID 不可空白!";
                }
                else
                {
                    errMsgLabel.Text = "";
                    DisplayData();
                }
                break;
        }
    }

    public void DisplayData()
    {
        String strHtml = "";
        String strTemp = "";

        SysSqlDB dbTempSql = new SysSqlDB();
        System.Data.DataView dvTempSql;

        dbSql.SelectCommand = "Select * From [booking] Where [C_ID] = @C_ID Order By [orderDate] Desc";
        dbSql.SelectParameters.Clear();
        dbSql.SelectParameters.Add("C_ID", IDTextBox.Text.Trim());
        dvSql = (System.Data.DataView)dbSql.Select();
        if (dvSql.Count > 0)
        {
            DateTime curDate = DateTime.Now;
            DateTime datDate;
            String str訂房日期 = "";
            String str住房日期 = "";
            String str入住天數 = "";
            String str旅店房型 = "";
            String str付款金額 = "";
            String str住房狀態 = "";

            for (int i = 0; i < dvSql.Count; i++)
            {
                datDate = Convert.ToDateTime(dvSql[i]["orderDate"].ToString().Trim());
                str訂房日期 = datDate.ToString("yyyy/MM/dd");

                datDate = Convert.ToDateTime(dvSql[i]["checkinDate"].ToString().Trim());
                str住房日期 = datDate.ToString("yyyy/MM/dd");
                if (dvSql[i]["isCancel"].ToString().ToLower() == "true")
                {
                    str住房狀態 = "已取消";
                }
                else if (String.Compare(str住房日期, curDate.ToString("yyyy/MM/dd")) > 0)
                {
                    String strUrl = "orderCancel.aspx?uid=" + dvSql[i]["uid"].ToString().Trim();
                    str住房狀態 = "<a href='" + strUrl + "'>我要取消訂房</a>";
                }

                str入住天數 = dvSql[i]["days"].ToString().Trim();
                str付款金額 = dvSql[i]["totalPrices"].ToString().Trim();

                dbTempSql.SelectCommand = "Select * From [room] Where [ID] = @ID";
                dbTempSql.SelectParameters.Clear();
                dbTempSql.SelectParameters.Add("ID", dvSql[i]["R_ID"].ToString().Trim());
                dvTempSql = (System.Data.DataView)dbTempSql.Select();
                if (dvTempSql.Count > 0)
                {
                    String str旅店ID = dvTempSql[0]["H_ID"].ToString().Trim();

                    strTemp += "ID：" + dvTempSql[0]["ID"].ToString().Trim();
                    strTemp += "&nbsp;&nbsp;&nbsp;房型：" + dvTempSql[0]["type"].ToString().Trim();

                    dbTempSql.SelectCommand = "Select * From [hotel] Where [ID] = @ID";
                    dbTempSql.SelectParameters.Clear();
                    dbTempSql.SelectParameters.Add("ID", str旅店ID);
                    dvTempSql = (System.Data.DataView)dbTempSql.Select();
                    if (dvTempSql.Count > 0)
                    {
                        str旅店房型 = dvTempSql[0]["name"].ToString().Trim() + "&nbsp;&nbsp;&nbsp;" + strTemp;
                    }
                }

                strHtml += "<tr>";
                strHtml += "<td align='center'>";
                strHtml += (i + 1).ToString();
                strHtml += "</td>";
                strHtml += "<td align='center'>";
                strHtml += str訂房日期;
                strHtml += "</td>";
                strHtml += "<td align='center'>";
                strHtml += str住房日期;
                strHtml += "</td>";
                strHtml += "<td align='center'>";
                strHtml += str入住天數;
                strHtml += "</td>";
                strHtml += "<td align='left'>";
                strHtml += str旅店房型;
                strHtml += "</td>";
                strHtml += "<td align='right'>";
                strHtml += str付款金額;
                strHtml += "</td>";
                strHtml += "<td align='center'>";
                strHtml += str住房狀態;
                strHtml += "</td>";
                strHtml += "</tr>";
            }

            dataLiteral.Text = strHtml;
            dataPanel.Visible = true;
        }
        else
        {
            errMsgLabel.Text = "查無您的訂房記錄!";
            dataPanel.Visible = false;
        }
    }

    public void OpenDatabase_and_LinkTo()
    {
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OpenDatabase_and_LinkTo();
        }
    }
}