using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hotelRoomDataAppend : System.Web.UI.Page
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
                    //errMsgLabel.Text = "資料內容存檔完成!";
                    Response.Redirect("hotelData.aspx");
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
            if (房型TextBox.Text.Trim() == "")
            {
                blnValid = false;
                errMsgLabel.Text = "房型不可空白!";
            }
        }

        if (blnValid)
        {
            dbSql.SelectCommand = "Select [uid] From [room] Where [ID] = @ID";
            dbSql.SelectParameters.Clear();
            dbSql.SelectParameters.Add("ID", IDTextBox.Text.Trim());
            dvSql = (System.Data.DataView)dbSql.Select();
            if (dvSql.Count > 0)
            {
                if (dvSql[0]["uid"].ToString().Trim() != uidLiteral.Text)
                {
                    blnValid = false;
                    errMsgLabel.Text = "ID 重覆!";
                }
            }
        }

        if (blnValid)
        {
            if (旅店DropDownList.SelectedValue == "")
            {
                blnValid = false;
                errMsgLabel.Text = "請選取隸屬旅店!";
            }
        }

        if (價錢TextBox.Text.Trim() == "")
        {
            blnValid = false;
            errMsgLabel.Text = "價錢不可空白!";
        }

        if (blnValid)
        {
            try
            {
                int nPrice = Convert.ToInt32(價錢TextBox.Text.Trim());
            }
            catch (Exception ex)
            {
                blnValid = false;
                errMsgLabel.Text = "價錢請輸入正確的數值!";
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
            dbSql.InsertCommand = "INSERT INTO [room] ([ID], [H_ID], [type], [prices], [description]) VALUES (@ID, @H_ID, @type, @prices, @description)";
            dbSql.InsertParameters.Clear();
            dbSql.InsertParameters.Add("ID", IDTextBox.Text.Trim());
            dbSql.InsertParameters.Add("H_ID", 旅店DropDownList.SelectedValue);
            dbSql.InsertParameters.Add("type", 房型TextBox.Text.Trim());
            dbSql.InsertParameters.Add("prices", System.TypeCode.Int32, 價錢TextBox.Text.Trim());
            dbSql.InsertParameters.Add("description", 描述TextBox.Text.Trim());

            nRecord = dbSql.Insert();
        }

        Application.UnLock();

        return nRecord;
    }

    public void OpenDatabase_and_LinkTo()
    {
        dbSql.SelectCommand = "Select [ID], [name] From [hotel] Order By [ID] asc";
        dbSql.SelectParameters.Clear();
        dvSql = (System.Data.DataView)dbSql.Select();
        if (dvSql.Count > 0)
        {
            旅店DropDownList.DataSource = dvSql;
            旅店DropDownList.DataTextField = "name";
            旅店DropDownList.DataValueField = "ID";
            旅店DropDownList.DataBind();
            旅店DropDownList.Items.Insert(0, new ListItem("請選擇", ""));
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