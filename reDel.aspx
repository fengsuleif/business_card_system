<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reDel.aspx.cs" Inherits="reDel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />   
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
		</style>
        <script type="text/javascript">
            $(document).ready(function () {
                $('#select6').change(function () {
                    // alert("adfdfdsfdsf");
                    $.post("w.aspx", { Classid: $('#select6').val() }, function (data) {
                        $('#form3').empty(); $('#form3').html(data); $("#form3 .ch-datagrid .YOUR_SELECTOR_Modal").live('click', function () {
                            $(".YOUR_SELECTOR_Modal").modal({
                                "width": "70%",
                                "height": "66%"
                            }); return false;
                        }); $("#xxx a").live("click", function () { $.post("w.aspx", { gpage: $(this).text(), Classid: $('#select6').val() }, function (data) { $('#form3').empty(); $('#form3').html(data); }); return false; });
						
						$("#send_ckid11").live("click", function () { var str = "";
            $("[name=mycheckall]:checkbox:checked").each(function () {
                str += $(this).val() + ",";
            });
            //alert(str.substring(0,str.length-1));
			if( !window.confirm("确定删除如下编号数据:\r\n"+str.substring(0,str.length-1)) ){return false;}
			})
						
                    });
                });

                // $("#yyy a").click(function () { $.post("w.aspx", { gpage: $(this).text() }, function (data) { $('#tb').empty(); $('#tb').html(data); }); return false; })
                $("#Esearch").click(function () {
                    $.post("w.aspx", { s: $("#Etext").val() }, function (data) { $('#form3').empty();$("#form3 .ch-datagrid .YOUR_SELECTOR_Modal").live('click', function () {
                        $(".YOUR_SELECTOR_Modal").modal({
                            "width": "70%",
                            "height": "66%"
                        }); return false;
                    }); 
					$("#send_ckid11").live("click", function () {  var str = "";
            $("[name=mycheckall]:checkbox:checked").each(function () {
                str += $(this).val() + ",";
            });
            //alert(str.substring(0,str.length-1));
			if( !window.confirm("确定删除如下编号数据:\r\n"+str.substring(0,str.length-1)) ){return false;}
			});
					$('#form3').html(data); }); 
                })
            })
           </script>
            
        <link rel="stylesheet" href="css/chico-mesh.css" />			
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
 <h2>文章搜索</h2> 
   
    <label>搜索：</label><input type="text" name="Wsearch" id="Etext"/> <input type="submit" value="确定" id="Esearch"  class="ch-btn ch-btn-small ch-btn-skin" />   
     
    <label>列出此分类文章：</label>
    <select id="select6" name="W2class"   style="border: 1px solid #CCC;padding: 5px 4px;
margin: 5px 0;"> 
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
     </select>    
  
    </div>
    <div class="ch-box">
    <form id="form3" action="reDel.aspx?action=adel" method="post">

  <div id="tb">
    <table class="ch-datagrid" >
    <caption>信息管理</caption>
    <thead>
    <tr>
     <th scope="col"><input type="checkbox" name="checkall" id="ckid"/>全选</th><th scope="col">id</th><th>姓名</th><th>邮箱</th><th>电话</th><th scope="col"  style="width:170px">管理</th>
    </tr>
    </thead>
    <tbody>
    <%if (Request.QueryString["gpage"] != null && int.Parse(Request.QueryString["gpage"]) > 1)         
      {
          gettable2();
      }else{
          gettable();
      }
 %>
 
   </tbody>
    </table> 
    <input type="submit" class="ch-btn ch-btn-small ch-icon-remove" value="删除所选" id="send_ckid" />
    </div>
    <% Fwrite(20);%> 
		
  </form>
  
  <div id="invisible-content" class="ch-hide">
  <div class="ch-box-lite">
	<h1>修改分类</h1>
    <form id="form2" action="" method="post">
    <label>分类名：</label><input type="text" name="Xuser" />
     <label>URL：</label><input type="text" name="Xurl" />
    <div class="radio_class">    
    <label>类型：</label>  
    <input type="radio" name="Xpw1" value="10"  checked="checked" onClick="settab1(this,event);" /> [独立分类]
    <input type="radio" name="Xpw1" value="1"  onclick="settab2(this,event);" /> [子分类]
    </div>
    <label>所属分类：</label>
    <select id="select20" name="X2class"  disabled="disabled"  style="border: 1px solid #CCC;padding: 5px 4px;
margin: 5px 0;">
     <option value="0">北京</option>
   <option value="1">上海</option>
   <option value="2">南京</option>
     </select>
    <input type="submit" value="确定"  class="ch-btn ch-btn-small ch-btn-skin" />  
    </form>
    </div>
 </div>
			</div>
		</div>

		<div class="ch-footer ch-box">
			
		</div>

 

	<script src="js/chico-min-0.11.js"></script>
    <script>
       
        $("#ckid").click(function(){
            if (this.checked){
                $("[name=mycheckall]:checkbox").attr("checked", true);
            } else {
                $("[name=mycheckall]:checkbox").attr("checked",false );
             }
        });

        $("#send_ckid").click(function () {
            //var str = "is checked:\r\n";
			var str = "";
            $("[name=mycheckall]:checkbox:checked").each(function () {
                str += $(this).val() + ",";
            });
            //alert(str.substring(0,str.length-1));
			if( !window.confirm("确定删除如下编号数据:\r\n"+str.substring(0,str.length-1)) ){return false;}
        });

        $(".radio_class>input").click(function () {
            var radio_input = $(this).val();
            if (radio_input === "10") {
                $("#select6").attr("disabled", "disabled");
            } else if (radio_input === "1") {
                $("#select6").removeAttr("disabled");
            }
           
        });
        
          
        function setaction(elem,event) {
            var auri = $(elem).attr("href");
            var data = $(elem).attr("data");
            data = data.split(",");
            $("#form2").attr({ action: auri });
            $("#form2>input:eq(0)").attr({ value: data[2] });
            $("#form2>input:eq(1)").attr({ value: data[3] });
           
        }

        function settab1(elem, event) {
        $("#select20").attr("disabled", "disabled");
        }

        function settab2(elem, event) {
        $("#select20").removeAttr("disabled");
    }

   
    </script>
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
			    "width": "70%",
			    "height": "60%"
			}),

	    // Modal with invisible DOM Content		
			ch_moda_invisible = $(".Fdialog").modal("#invisible-content"),

	    // Transition
			ch_tran = $(".YOUR_SELECTOR_Transition").transition(),	  

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
			    "from": "2010/11/05",
			    "to": "2012/11/25"
			}),		

	    // Form
			ch_form = $('#form1').form(),

	    // Watchers
			ch_icon = $("#input_ico").required("啊哦"),
            ch_icon2 = $("#input_ico2").required("密码也没填写"),
            ch_wch6 = $(".radio2").required("用户类型也是必选");

	   
	   	</script>    

</body>
</html>
