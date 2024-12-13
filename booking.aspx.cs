using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class booking : System.Web.UI.Page
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
                    errMsgLabel.Text = "您已訂房完成!";
                    submitButton.Visible = false;
                }
                break;
        }
    }

    public bool ValidateData()
    {
        Boolean blnValid = true;

        if (IDTextBox.Text.Trim() == "")
        {
            blnValid = false;
            errMsgLabel.Text = "ID 不可空白!";
        }

        if (blnValid)
        {
            if (姓名TextBox.Text.Trim() == "")
            {
                blnValid = false;
                errMsgLabel.Text = "姓名不可空白!";
            }
        }

        if (blnValid)
        {
            if (電話TextBox.Text.Trim() == "")
            {
                blnValid = false;
                errMsgLabel.Text = "電話不可空白!";
            }
        }

        if (blnValid)
        {
            if (旅店DropDownList.SelectedValue == "" || 房型DropDownList.SelectedValue == "")
            {
                blnValid = false;
                errMsgLabel.Text = "請選擇旅店和房型!";
            }
        }

        if (blnValid)
        {
            if (住房日期TextBox.Text.Trim() == "")
            {
                blnValid = false;
                errMsgLabel.Text = "住房日期不可空白!";
            }
            else
            {
                try
                {
                    DateTime datDay = Convert.ToDateTime(住房日期TextBox.Text.Trim());
                }
                catch (Exception ex)
                {
                    blnValid = false;
                    errMsgLabel.Text = "請輸入正確的住房日期!";
                }
            }

        }

        if (blnValid)
        {
            if (入住天數TextBox.Text.Trim() == "")
            {
                blnValid = false;
                errMsgLabel.Text = "入住天數不可空白!";
            }
            else
            {
                try
                {
                    int nDays = Convert.ToInt32(入住天數TextBox.Text.Trim());
                }
                catch (Exception ex)
                {
                    blnValid = false;
                    errMsgLabel.Text = "入住天數請輸入正確的數值!";
                }
            }

        }

        return blnValid;
    }

    public int SaveData()
    {
        int nRecord = 0;

        Application.Lock();

        if (ValidateData())
        {
            DateTime curdate = DateTime.Now;

            // 檢查 ID 是否已存在且 name 是否一致
            dbSql.SelectCommand = "Select [name] From [customer] Where [ID] = @ID";
            dbSql.SelectParameters.Clear();
            dbSql.SelectParameters.Add("ID", IDTextBox.Text.Trim());
            dvSql = (System.Data.DataView)dbSql.Select();

            if (dvSql.Count > 0)
            {
                string existingName = dvSql[0]["name"].ToString().Trim();
                if (!existingName.Equals(姓名TextBox.Text.Trim(), StringComparison.Ordinal))
                {
                    errMsgLabel.Text = "此 ID 已被使用，但姓名不匹配，請更換其他 ID!";
                    Application.UnLock();
                    return nRecord;
                }
            }

            int nDays = Convert.ToInt32(入住天數TextBox.Text.Trim());
            int nMoney = 0;

            dbSql.SelectCommand = "Select * From [room] Where [ID] = @ID ";
            dbSql.SelectParameters.Clear();
            dbSql.SelectParameters.Add("ID", 房型DropDownList.SelectedValue);
            dvSql = (System.Data.DataView)dbSql.Select();
            if (dvSql.Count > 0)
            {
                int nPrePrice = Convert.ToInt32(dvSql[0]["prices"].ToString().Trim());
                nMoney = nPrePrice * nDays;
            }

            dbSql.InsertCommand = "INSERT INTO [booking] ([ID], [C_ID], [R_ID], [orderDate], [checkinDate], [days], [totalPrices], [method], [isCancel], [refund]) VALUES (@ID, @C_ID, @R_ID, @orderDate, @checkinDate, @days, @totalPrices, @method, @isCancel, @refund)";
            dbSql.InsertParameters.Clear();
            dbSql.InsertParameters.Add("ID", curdate.ToString("yyyyMMddHHmmss"));
            dbSql.InsertParameters.Add("C_ID", IDTextBox.Text.Trim());
            dbSql.InsertParameters.Add("R_ID", 房型DropDownList.SelectedValue);
            dbSql.InsertParameters.Add("orderDate", System.TypeCode.DateTime, 訂房日期Literal.Text.Trim());
            dbSql.InsertParameters.Add("checkinDate", System.TypeCode.DateTime, 住房日期TextBox.Text.Trim());
            dbSql.InsertParameters.Add("days", System.TypeCode.Int32, 入住天數TextBox.Text.Trim());
            dbSql.InsertParameters.Add("totalPrices", System.TypeCode.Int32, nMoney.ToString());
            dbSql.InsertParameters.Add("method", 付款方式DropDownList.SelectedValue);
            dbSql.InsertParameters.Add("isCancel", System.TypeCode.Boolean, false.ToString());
            dbSql.InsertParameters.Add("refund", System.TypeCode.Int32, "0");

            nRecord = dbSql.Insert();

            if (nRecord > 0 && dvSql.Count == 0)
            {
                dbSql.InsertCommand = "INSERT INTO [customer] ([ID], [name], [email], [phone]) VALUES (@ID, @name, @email, @phone)";
                dbSql.InsertParameters.Clear();
                dbSql.InsertParameters.Add("ID", IDTextBox.Text.Trim());
                dbSql.InsertParameters.Add("name", 姓名TextBox.Text.Trim());
                dbSql.InsertParameters.Add("email", EmailTextBox.Text.Trim());
                dbSql.InsertParameters.Add("phone", 電話TextBox.Text.Trim());
                dbSql.Insert();
            }
        }

        Application.UnLock();

        return nRecord;
    }


    public void On_Room_SelectedIndexChanged(Object sender, EventArgs e)
    {
        errMsgLabel.Text = "";
        金額Literal.Text = "";

        if (入住天數TextBox.Text.Trim() != "")
        {
            int nDays = 0;
            try
            {
                nDays = Convert.ToInt32(入住天數TextBox.Text.Trim());

                if (房型DropDownList.SelectedValue != "")
                {
                    dbSql.SelectCommand = "Select * From [room] Where [ID] = @ID ";
                    dbSql.SelectParameters.Clear();
                    dbSql.SelectParameters.Add("ID", 房型DropDownList.SelectedValue);
                    dvSql = (System.Data.DataView)dbSql.Select();
                    if (dvSql.Count > 0)
                    {
                        int nPrePrice = Convert.ToInt32(dvSql[0]["prices"].ToString().Trim());
                        int nTotalPrice = nPrePrice * nDays;
                        金額Literal.Text = "" + nTotalPrice;
                    }
                }
            }
            catch (Exception ex)
            {
                errMsgLabel.Text = "請輸入入住天數！";
            }
        }
        else
        {
            errMsgLabel.Text = "請輸入入住天數！";
        }
    }

    public void On_Hotel_SelectedIndexChanged(Object sender, EventArgs e)
    {
        errMsgLabel.Text = "";
        金額Literal.Text = "";

        房型DropDownList.Items.Clear();
        房型DropDownList.Items.Insert(0, new ListItem("請選擇房型", ""));

        if (旅店DropDownList.SelectedValue != "")
        {
            dbSql.SelectCommand = "Select [ID], ('ID：' + [ID] + '，房型：' + [type] + '，每日價錢：' + CONVERT(varchar, [prices])) As [title] From [room] Where [H_ID] = @H_ID Order By [ID] asc";
            dbSql.SelectParameters.Clear();
            dbSql.SelectParameters.Add("H_ID", 旅店DropDownList.SelectedValue);
            dvSql = (System.Data.DataView)dbSql.Select();
            if (dvSql.Count > 0)
            {
                房型DropDownList.DataSource = dvSql;
                房型DropDownList.DataTextField = "title";
                房型DropDownList.DataValueField = "ID";
                房型DropDownList.DataBind();
                房型DropDownList.Items.Insert(0, new ListItem("請選擇房型", ""));
            }
        }
    }

    public void OpenDatabase_and_LinkTo()
    {
        DateTime curdate = DateTime.Now;

        訂房日期Literal.Text = curdate.ToString("yyyy/MM/dd");
        住房日期TextBox.Text = curdate.AddDays(1).ToString("yyyy/MM/dd");
        入住天數TextBox.Text = "1";

        dbSql.SelectCommand = "Select [ID], [name] From [hotel] Order By [ID] asc";
        dbSql.SelectParameters.Clear();
        dvSql = (System.Data.DataView)dbSql.Select();
        if (dvSql.Count > 0)
        {
            旅店DropDownList.DataSource = dvSql;
            旅店DropDownList.DataTextField = "name";
            旅店DropDownList.DataValueField = "ID";
            旅店DropDownList.DataBind();
            旅店DropDownList.Items.Insert(0, new ListItem("請選擇旅店", ""));

            房型DropDownList.Items.Insert(0, new ListItem("請選擇房型", ""));
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