using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hotelDataAppend : System.Web.UI.Page
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
            if (名稱TextBox.Text.Trim() == "")
            {
                blnValid = false;
                errMsgLabel.Text = "名稱不可空白!";
            }
        }

        if (blnValid)
        {
            dbSql.SelectCommand = "Select [uid] From [hotel] Where [ID] = @ID";
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

        return blnValid;
    }

    public int SaveData()
    {
        int nRecord = 0;

        Application.Lock();

        if (ValidateData())
        {
            dbSql.InsertCommand = "INSERT INTO [hotel] ([ID], [name], [description]) VALUES (@ID, @name, @description)";
            dbSql.InsertParameters.Clear();
            dbSql.InsertParameters.Add("ID", IDTextBox.Text.Trim());
            dbSql.InsertParameters.Add("name", 名稱TextBox.Text.Trim());
            dbSql.InsertParameters.Add("description", 描述TextBox.Text.Trim());

            nRecord = dbSql.Insert();
        }

        Application.UnLock();

        return nRecord;
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