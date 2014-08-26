<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNews.aspx.cs" Inherits="AddNews"  validateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />   
    <link rel="stylesheet" href="css/chico-0.11.css">   
<style>
			body {
				color: #333333;
			    font: 13px/20px Arial,Helvetica,"Nimbus Sans L",sans-serif;
			}
			
			.ch-box {
				border: 1px solid #ccc;
				padding: 10px;
				margin: 10px auto;
			}
			#Wsummary{height: 125px;
                     width: 600px;
                     vertical-align: top;
                     }
            #Wcontent{height: 500px;
                     width: 600px;
                     vertical-align: top;
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
		</style>
         <link rel="stylesheet" href="css/chico-mesh.css">		
		<script charset="utf-8" src="kindeditor-4.1.2/kindeditor-min.js"></script>
		<script charset="utf-8" src="kindeditor-4.1.2/lang/zh_CN.js"></script>
		<script>
		    var editor, editor1;
		    KindEditor.ready(function (K) {
		    
			 editor1 = K.create('#Wcontent', {
			    cssPath: 'kindeditor-4.1.2/plugins/code/prettify.css',
			    uploadJson: 'kindeditor-4.1.2/asp.net/upload_json.ashx',
			    fileManagerJson: 'kindeditor-4.1.2/asp.net/file_manager_json.ashx',
				allowFileManager : true,
				afterCreate : function() {
					var self = this;
					K.ctrl(document, 13, function() {
						self.sync();
						K('form[name=form1]')[0].submit();
					});
					K.ctrl(self.edit.doc, 13, function() {
						self.sync();
						K('form[name=form1]')[0].submit();
					});
				}
			});


K('input[name="viewServer"]').click(function () {
                                        editor.loadPlugin('filemanager', function() {
                                                editor.plugin.filemanagerDialog({
                                                        viewType : 'VIEW',
                                                        dirName : 'photo',
                                                        clickFn : function(url, title) {
                                                                document.getElementsByName("photo")[0].src=url;
                                                                document.getElementsByName("photoval")[0].value=url;
                                                                editor.hideDialog();
                                                        }
                                                });
                                        });
                                });


		        editor = K.create('textarea[name="summary"]', {
		            resizeType: 1,
		            allowPreviewEmoticons: false,
		            allowImageUpload: true,
		            cssPath: 'kindeditor-4.1.2/plugins/code/prettify.css',
		            uploadJson: 'kindeditor-4.1.2/asp.net/upload_json.ashx',
		            fileManagerJson: 'kindeditor-4.1.2/asp.net/file_manager_json.ashx',
		            allowFileManager: true,
		            items: [
						'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
						'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
						'insertunorderedlist', '|', 'emoticons', 'image', 'link']
		        });
		    });
		</script>

	</head>			
			
	<body>
     <div class="ch-header ch-box">
			<h1>页头</h1>
		</div>
		
		<div class="ch-g1-4">
			<!--#Include File="dh.htm"-->  
		</div>

		
		<div class="ch-g3-4">
			<div class="ch-box ch-rightcolumn">
			<div class="ch-box">
 <h2>添加内容</h2> 
   <form id="form1" action="AddNews.aspx?action=in" method="post">
     
    <label>姓名：</label><input type="text" name="cname" size="60" id="cname" /><br />
    <label>邮件：</label><input type="text" name="cmail" size="60" id="cmail" ><br />
    <label>电话：</label><input type="text" name="cphone" size="60"  id="cphone"/><br />
    <label>单位：</label><input type="text" name="cduty"   size="60" />  <br />       
    <label>职业：</label><input type="text" name="cunits"   size="60"  /> <br />  
    <label>备注：</label><textarea id="Wcontent" name="callcontent"  > </textarea> <br />
    <label>分类：</label>
    <select id="select6" name="ctype"    style="border: 1px solid #CCC;padding: 5px 4px;margin: 5px 0;">
      <option value="0">请选择</option>
      <option value="1">学者</option>
     <option value="2">志愿者</option>
     <option value="3">媒体</option>
     <option value="4">律师</option>
     <option value="5">基金会</option>
     <option value="6">NGO</option>
     <option value="7">企业</option>
     <option value="8">驻华大使</option>
     <option value="9">政府</option>
     <option value="10">其它</option>
     <option value="11">金融</option>
     <option value="12">公安系统</option>  
    </select> <br />
    <input type="submit" value="确定"  class="ch-btn ch-btn-small ch-btn-skin" />    
    </form>
    </div>
   </div>
		

		<div class="ch-footer ch-box">
			<p>footer</p>
		</div>

 
 <script type="text/javascript" src="js/jquery.js"></script>
	<script src="js/chico-min-0.11.js"></script>
   
	<script>

	    // Menu
	    ch_menu = $(".YOUR_SELECTOR_Menu").menu(),

	    // Dropdown
			ch_drop = $(".myDropdown").dropdown(),

	    // Carousel
			myCarousel = $(".myCarousel").carousel({
			    "pagination": true
			}),

	    // Modal
			ch_moda = $(".YOUR_SELECTOR_Modal").modal({
			    "width": "700px",
			    "height": "300px"
			}),

	    // Modal with invisible DOM Content		
			ch_moda_invisible = $(".Fdialog").modal("#invisible-content"),

	    // Transition
			ch_tran = $(".YOUR_SELECTOR_Transition").transition(),

	    // Layer on click
			ch_layeC = $(".YOUR_SELECTOR_LayerCloseButton").layer({
			    "event": "click",
			    "closable": "button",
			    "content": "#invisible-content-for-layer",
			    "width": 500
			}),

	    // Layer on click
			ch_laye = $(".YOUR_SELECTOR_LayerOnclick").layer({
			    "event": "click",
			    "content": "#invisible-content",
			    "width": 70
			}),

	    // Layer on mouseover
			ch_layr = $(".YOUR_SELECTOR_LayerOnmouseover").layer("<p>foo</p>"),

	    // Tab Navigator
			ch_tabs = $(".YOUR_SELECTOR_TabNavigator").tabNavigator(),

	    // Expando
			ch_expa = $(".YOUR_SELECTOR_Expando").expando(),

	    // Calendar
			calendar = $(".YOUR_SELECTOR_calendar").calendar({
			    "selected": [
					["2012/01/11", "2012/01/14"],
					["2012/01/23", "2012/01/27"],
					"2012/01/02"
				],
			    "from": "2010/11/05",
			    "to": "2012/11/25"
			}),

	    // Date Picker
			datePicker = $(".myDatePicker").datePicker({
			    "selected": "2011/11/15",
			    "from": "2000/11/05",
			    "to": "2015/11/25"
			}),

			ch_ico = $(".ch-form-ico").layer({
			    "content": "Help",
			    "event": "click",
			    "points": "lm rm",
			    "offset": "10 0"
			}),

	    // Form
			ch_form = $('#form1').form(),

	    // 验证表单
			ch_icon = $("#cname").required("名字没有填写"),
            ch_icon2 = $("#cmail").required("没有邮箱可以填写【无】"),
            ch_wch6 = $("#cphone").required("没有电话可以填写【无】");

	   
	   
	</script>
	
</body>
</html>
