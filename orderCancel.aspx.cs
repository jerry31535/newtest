using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class orderCancel : System.Web.UI.Page
{

    private SysSqlDB dbSql = new SysSqlDB();
    private System.Data.DataView dvSql;


    public void On_ButtonClick(Object sender, System.Web.UI.WebControls.CommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Submit":
                if (SaveData() > 0)
                {
                    errMsgLabel.Text = "您已取消訂房完成!";
                    submitButton.Visible = false;
                }
                break;
        }
    }

    public int SaveData()
    {
        int nRecord = 0;

        Application.Lock();

        dbSql.UpdateCommand = "UPDATE [booking] SET [isCancel] = @isCancel Where [uid] = @uid ";
        dbSql.UpdateParameters.Clear();
        dbSql.UpdateParameters.Add("isCancel", System.TypeCode.Boolean, true.ToString());

        dbSql.UpdateParameters.Add("uid", uidLiteral.Text.Trim());
        nRecord = dbSql.Update();

        Application.UnLock();

        return nRecord;
    }

    public void OpenDatabase_and_LinkTo()
    {
        String strTemp = "";

        SysSqlDB dbTempSql = new SysSqlDB();
        System.Data.DataView dvTempSql;

        uidLiteral.Text = Request["uid"];
        if (uidLiteral.Text.Trim() == "")
        {
            Response.Redirect("order.aspx");
        }

        dbSql.SelectCommand = "Select * From [booking] Where [uid] = @uid";
        dbSql.SelectParameters.Clear();
        dbSql.SelectParameters.Add("uid", uidLiteral.Text.Trim());
        dvSql = (System.Data.DataView)dbSql.Select();
        if (dvSql.Count > 0)
        {
            DateTime datDate;
            String str訂房日期 = "";
            String str住房日期 = "";
            String str入住天數 = "";
            String str旅店房型 = "";
            String str付款金額 = "";

            datDate = Convert.ToDateTime(dvSql[0]["orderDate"].ToString().Trim());
            str訂房日期 = datDate.ToString("yyyy/MM/dd");

            datDate = Convert.ToDateTime(dvSql[0]["checkinDate"].ToString().Trim());
            str住房日期 = datDate.ToString("yyyy/MM/dd");

            str入住天數 = dvSql[0]["days"].ToString().Trim();
            str付款金額 = dvSql[0]["totalPrices"].ToString().Trim();

            dbTempSql.SelectCommand = "Select * From [room] Where [ID] = @ID";
            dbTempSql.SelectParameters.Clear();
            dbTempSql.SelectParameters.Add("ID", dvSql[0]["R_ID"].ToString().Trim());
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

            訂房日期Literal.Text = str訂房日期;
            住房日期Literal.Text = str住房日期;
            入住天數Literal.Text = str入住天數;
            旅店房型Literal.Text = str旅店房型;
            付款金額Literal.Text = str付款金額;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OpenDatabase_and_LinkTo();
        }
    }
}