<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hotelData.aspx.cs" Inherits="hotelData" %>

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
                    <td align="left" valign="top" bgcolor="#FFECC9">旅店資料</td>
                  </tr>
                  <tr>
                    <td align="right" valign="top">
                      <table border="0" cellspacing="2" cellpadding="2">
                        <tr>
                          <td><a href="hotelDataAppend.aspx">新增旅店資料</a></td>
                          <td><a href="hotelRoomDataAppend.aspx">新增房間資料</a></td>
                        </tr>
                    </table>
                    </td>
                  </tr>
                  <tr>
                    <td align="left" valign="top">
                      <table width="1250" border="0" cellspacing="2" cellpadding="2">
                        <tr>
                          <td width="100" height="40" bgcolor="#808080" style="text-align: center; color: #FFFFFF;">旅店編號</td>
                          <td width="150" height="40" bgcolor="#808080" style="text-align: center; color: #FFFFFF;">旅店名稱</td>
                          <td width="350" height="40" bgcolor="#808080" style="text-align: center; color: #FFFFFF;">旅店描述</td>
                          <td width="530" height="40" bgcolor="#808080" style="text-align: center; color: #FFFFFF;">房型</td>
                        </tr>
                        <asp:Literal ID="dataLiteral" runat="server" />
                      </table>
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
