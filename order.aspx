<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order.aspx.cs" Inherits="order" %>

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
                <table width="1250" border="0" cellspacing="8" cellpadding="8">
                <tbody>
                  <tr>
                    <td align="left" valign="top" bgcolor="#FFECC9">訂房查詢</td>
                  </tr>
                  <tr>
                    <td align="left" valign="top">
                      <table width="1250" border="0" cellspacing="2" cellpadding="2">
                        <tr>
                          <td width="150" height="40">請輸入您的 ID ：</td>
                          <td>
                              <asp:TextBox ID="IDTextBox" MaxLength="50" runat="server" />
                          </td>
                          <td>
                              <asp:ImageButton ID="queryButton" OnCommand="On_ButtonClick" CommandName="Query" ImageUrl="image/Group 87.png" runat="server" />
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                  <tr>
                    <td align="center" valign="top">
                      <asp:Label ID="errMsgLabel" Font-Size="Large" ForeColor="Red" runat="server" />
                    </td>
                  </tr>
                </tbody>
                </table>
            </td>
          </tr>
          <tr>
            <td height="125" align="center" valign="top" bgcolor="#F0F0F0">
                <table width="1250" border="0" cellspacing="8" cellpadding="8">
                <tbody>
                  <tr>
                    <td align="left" valign="top" bgcolor="#FFECC9">訂房記錄</td>
                  </tr>
                  <tr>
                    <td align="left" valign="top">
                      <asp:Panel ID="dataPanel" Visible="false" runat="server">
                      <table width="1250" border="0" cellspacing="2" cellpadding="2">
                        <tr>
                          <td width="23" height="40" bgcolor="#808080" style="text-align: center; color: #FFFFFF;"></td>
                          <td width="121" height="40" bgcolor="#808080" style="text-align: center; color: #FFFFFF;">訂房日期</td>
                          <td width="137" height="40" bgcolor="#808080" style="text-align: center; color: #FFFFFF;">住房日期</td>
                          <td width="30" height="40" bgcolor="#808080" style="text-align: center; color: #FFFFFF;">入住天數</td>
                          <td width="439" height="40" bgcolor="#808080" style="text-align: center; color: #FFFFFF;">旅店／房型</td>
                          <td width="115" height="40" bgcolor="#808080" style="text-align: center; color: #FFFFFF;">付款金額</td>
                          <td width="105" height="40" bgcolor="#808080" style="text-align: center; color: #FFFFFF;">住房狀態</td>
                        </tr>
                        <asp:Literal ID="dataLiteral" runat="server" />
                      </table>
                      </asp:Panel>
                    </td>
                  </tr>
                </tbody>
                </table>
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
