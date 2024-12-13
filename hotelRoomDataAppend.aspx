<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hotelRoomDataAppend.aspx.cs" Inherits="hotelRoomDataAppend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<form id="form1" runat="server">
<div>
<table width="95%" border="0" cellspacing="1" cellpadding="1">
  <tbody>
    <tr>
      <td align="center" valign="top"><table width="1200" border="0" cellspacing="0" cellpadding="0">
        <tbody>
          <tr>
            <td height="56" align="left" valign="top" bgcolor="#F08900" style="color: #FFFFFF; font-family: '微軟正黑體'; font-style: normal; font-weight: bold; font-size: 36px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-family: '微軟正黑體'">&nbsp;Mini HOTEL Booking</span></td>
          </tr>
          <tr>
            <td bgcolor="#F08900"><table width="1200" border="0" cellspacing="3" cellpadding="3">
              <tbody>
                <tr>
                  <td width="72">&nbsp;</td>
                  <td width="1107" bgcolor="#F08900"><table width="400" border="0" cellspacing="3" cellpadding="3">
                    <tbody>
                      <tr>
                        <td width="75" style="font-family: '微軟正黑體'; font-size: 16px; font-style: normal; color: #FFFFFF; font-weight: bolder;"><a href="index.aspx">首頁</a></td>
                        <td width="150" style="font-family: '微軟正黑體'; color: #FFFFFF; font-weight: bolder; font-size: 16px;"><a href="booking.aspx">我要訂房</a></td>
                        <td width="250" style="font-family: '微軟正黑體'; color: #FFFFFF; font-weight: bolder; font-size: 16px;"><a href="order.aspx">訂房查詢</a></td>
                        <td width="150" style="font-family: '微軟正黑體'; color: #FFFFFF; font-weight: bolder; font-size: 16px;"><a href="hotelData.aspx">旅店資料</a></td>
                        <td width="24" style="font-family: '微軟正黑體'; color: #FFFFFF; font-weight: bolder; font-size: 16px;">&nbsp;</td>
                      </tr>
                    </tbody>
                  </table></td>
                </tr>
              </tbody>
            </table></td>
          </tr>
          <tr>
            <td height="125" align="center" valign="top" bgcolor="#F0F0F0">
                <table width="1000" border="0" cellspacing="8" cellpadding="8">
                <tbody>
                  <tr>
                    <td align="left" valign="top" bgcolor="#FFECC9">新增旅店房間資料</td>
                  </tr>
                  <tr>
                    <td align="left" valign="top">
                      <table width="990" border="0" cellspacing="6" cellpadding="6">
                      <tbody>
                        <tr><asp:Literal ID="uidLiteral" Visible="false" runat="server" />
                          <td width="80">ID：</td>
                          <td><asp:TextBox ID="IDTextBox" MaxLength="50" runat="server" /></td>
                        </tr>
                        <tr>
                          <td>房型：</td>
                          <td><asp:TextBox ID="房型TextBox" MaxLength="50" runat="server" /></td>
                        </tr>
                        <tr>
                          <td valign="top">描述：</td>
                          <td><asp:TextBox ID="描述TextBox" TextMode="MultiLine" Rows="10" MaxLength="250" runat="server" /></td>
                        </tr>
                        <tr>
                          <td>每日價錢：</td>
                          <td><asp:TextBox ID="價錢TextBox" MaxLength="5" runat="server" /></td>
                        </tr>
                        <tr>
                          <td>隸屬旅店：</td>
                          <td>
                              <asp:DropDownList ID="旅店DropDownList" runat="server"></asp:DropDownList>
                          </td>
                        </tr>
                      </tbody>
                      </table>
                    </td>
                  </tr>
                </tbody>
                </table>
            </td>
          </tr>
          <tr>
            <td align="center" valign="middle">
                <asp:Label ID="errMsgLabel" Font-Size="Large" ForeColor="Red" runat="server" />
            </td>
          </tr>
          <tr>
            <td align="center" valign="middle">
                <asp:Button ID="submitButton" OnCommand="On_ButtonClick" CommandName="Submit" Text="確定存檔" runat="server" />
            </td>
          </tr>
          <tr>
            <td>&nbsp;</td>
          </tr>
          <tr>
            <td height="33" bgcolor="#3C3C3C" style="text-align: center; font-size: 14px; font-family: '微軟正黑體'; color: #FFFFFF;">邱芷婕Copyright © 2024™。版權所有</td>
          </tr>
        </tbody>
      </table></td>
    </tr>
  </tbody>
</table>
</div>
</form>
</body>
</html>
