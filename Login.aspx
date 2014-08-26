<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录</title>
     <link rel="stylesheet" href="css/chico-0.11.css" />
    <script src="js/jquery.js" type="text/javascript"></script> 
     <style type="text/css">
			body {
				color: #333333;
			    font: 13px/20px Arial,Helvetica,"Nimbus Sans L",sans-serif;
			}
			
			.ch-box {
				border: 1px solid #ccc;
				padding: 10px;
				margin: 10px auto;
			}
			
			.ch-header {
				height: 50px;
				padding: 20px 10px;
				background: #eee;
				margin: 10px auto 0px;
			}
			
			.ch-footer {
				clear:both;
				text-align: center;
				margin: 10px auto;
				background: #eee;				
			}
			#asform{ margin:0 auto; text-align:center; padding-top:20em;}
		</style>  
</head>
<body>
 <div class="ch-box">
			
		<h2>登录验证</h2>
   <div class="ch-box-lite gocenter">
		
		<form method="post" action="Login.aspx" id="asForm" class="ch-form">
			
				<label for="autocomplete">用户名:</label>													
				<input type="text" class="autoComplete" placeholder="用户名" /><br />
			
			
				<label for="autocomplete2">
					密&nbsp;&nbsp; 码:
				</label>													
				<input type="password" class="autoComplete2"  placeholder="密码" />
			
				<label for="autocomplete3"><br />
					验证码:
				</label>													
				<input type="text" class="autoComplete3"  name="ys" /><br />
			
		
				<input type="submit" name="autoCompleteSubmit" class="ch-btn ch-primary">
		
		</form>
	</div>
    </div>
    	<script src="js/chico-min-0.11.js"></script>
        <script type="text/javascript">
            // Watchers
            ch_icon = $(".autoComplete").required("请输入用户名"),
            ch_icon2 = $(".autoComplete2").required("请输入密码"),
            ch_wch6 = $(".autoComplete3").required("验证码没输入啊");
        </script>
</body>
</html>
