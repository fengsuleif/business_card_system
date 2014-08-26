<%@ Page Language="C#" AutoEventWireup="true" CodeFile="human_view.aspx.cs" Inherits="human_view" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>人力资源</title>
    <link href="text.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
    
    <br /><br /><br /><br />
<div class="conent2">
<table border="0" cellspacing="0" cellpadding="0" width="100%">
  <tbody>
  <tr valign="top">
    <td style="height: 324px">
      <div class="kuang4">
      <div class="tiao4">详细信息</div>
      </div>
      
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
      <table border="0 "cellspacing="1" cellpadding="5" width="100%" 
        bgcolor="#cccccc"><tbody> 
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <tr valign="top">
           
            
          <td bgcolor="#ffffff" align="left" style="width: 280px"><b>姓名</b><br />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("name") %><br />
          <b>邮件</b><br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("mail") %><br />
          <b>电话</b><br />
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("phone") %> <br />        
          <b>单位</b><br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("units") %> <br />        
          <b>职务</b><br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("duty") %><br />
           <b>邮编</b><br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("zip") %><br />
           <b>地址</b><br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("address") %><br /></td>
          <td bgcolor="#ffffff">
            <div class="kuang4a">
            <div class="tiao4a">备注信息</div>
            <div class="padd10">
            <div class="list3">
            个人描述：<br /><%#Eval("allcontent") %><br />
             对传知行的看法和建议：<br /><%#Eval("advice") %>
              </div></div></div></td></tr></ItemTemplate></asp:Repeater></tbody></table>
              </ContentTemplate>
        </asp:UpdatePanel>
      
              
              
              </td>
    <td rowspan="2 "width="10" style="height: 324px"></td>
    <td bgcolor="#eaeaea" rowspan="2" width="200" style="height: 324px"><div class="tiao4">联系人名单</div>
  
      <div class="padd10">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"  ChildrenAsTriggers="true">
           <ContentTemplate>
          
          <asp:Repeater ID="Repeater2" runat="server">
         <ItemTemplate>
      <a href="human_view.aspx?id=<%#Eval("id") %>" class="lan" onclick="dh"><%#Eval("name") %> </a><br />
            
      </ItemTemplate>
       </asp:Repeater>
        <webdiyer:aspnetpager id="AspNetPager1" runat="server" HorizontalAlign="center" PageSize="20" OnPageChanged="AspNetPager1_PageChanged"></webdiyer:aspnetpager>
    </ContentTemplate>
     </asp:UpdatePanel> </div></td></tr></tbody></table>
<div class="kuang10"></div>
<table border="0" cellspacing="0" cellpadding="0" width="100%">
  <tbody>
  <tr valign="top">
    <td width="8"></td>
    </tr></tbody></table>
<!--//////////--></div><!--内容end--><!--底部-->
<div class="conent2"><br />
</div>
    </div>
    </form>
</body>
</html>
