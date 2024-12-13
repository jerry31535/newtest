<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderCancel.aspx.cs" Inherits="orderCancel" %>

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
                  <tr><asp:Literal ID="uidLiteral" Visible="false" runat="server" />
                    <td align="left" valign="bottom" bgcolor="#FFECC9" style="font-family: '微軟正黑體'; font-size: 18px;">您的訂房資訊</td>
                  </tr>
                  <tr>
                    <td align="left" valign="top">
                      <table width="990" border="0" cellspacing="6" cellpadding="6">
                      <tbody>
                        <tr>
                          <td width="150">訂房日期：</td>
                          <td><span style="font-family: '微軟正黑體'; font-size: 18px; color: #001FA0;"><asp:Literal ID="訂房日期Literal" runat="server" /></span></td>
                        </tr>
                        <tr>
                          <td>住房日期：</td>
                          <td><span style="font-family: '微軟正黑體'; font-size: 18px; color: #001FA0;"><asp:Literal ID="住房日期Literal" runat="server" /></span></td>
                        </tr>
                        <tr>
                          <td>入住天數：</td>
                          <td><span style="font-family: '微軟正黑體'; font-size: 18px; color: #001FA0;"><asp:Literal ID="入住天數Literal" runat="server" /></span></td>
                        </tr>
                        <tr>
                          <td>您選擇的旅店房型：</td>
                          <td><span style="font-family: '微軟正黑體'; font-size: 18px; color: #001FA0;"><asp:Literal ID="旅店房型Literal" runat="server" /></span></td>
                        </tr>
                        <tr>
                          <td width="150">付款金額：</td>
                          <td><span style="font-family: '微軟正黑體'; font-size: 18px; color: #001FA0;"><asp:Literal ID="付款金額Literal" runat="server" /></span></td>
                        </tr>
                      </tbody>
                      </table>
                    </td>
                  </tr>
                  <tr>
                    <td align="center" valign="top">
                        <asp:Label ID="errMsgLabel" Font-Size="Large" ForeColor="Red" runat="server" />
                    </td>
                  </tr>
                  <tr>
                    <td align="center" valign="top">
                        <asp:ImageButton ID="submitButton" OnCommand="On_ButtonClick" CommandName="Submit" ImageUrl="image/Group 89.png" runat="server" />
                    </td>
                  </tr>
                  </tbody>
                </table>
            </td>
          </tr>
          <tr>
            <td align="center" valign="middle">
                
            </td>
          </tr>
          <tr>
            <td align="center" valign="middle">
                
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
