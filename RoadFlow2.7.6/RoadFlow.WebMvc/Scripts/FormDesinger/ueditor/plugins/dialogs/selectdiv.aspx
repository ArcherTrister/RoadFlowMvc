<%@ Page Language="C#" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script type="text/javascript" src="../../dialogs/internal.js"></script>
    <script type="text/javascript" src="../common.js"></script>
    <%=WebMvc.Common.Tools.IncludeFiles %>
</head>
<body>
<%
    WebMvc.Common.Tools.CheckLogin();
    RoadFlow.Platform.WorkFlowForm workFlowFrom = new RoadFlow.Platform.WorkFlowForm(); 
%>

<div class="wrapper">
    <div id="tabhead" class="tabhead">
        <span class="tab focus" data-content-id="text_attr">&nbsp;&nbsp;属性&nbsp;&nbsp;</span>
        <span class="tab" data-content-id="text_event">&nbsp;&nbsp;事件&nbsp;&nbsp;</span>
    </div>
    <div id="tabbody" class="tabbody"  style="height:330px;">
        <div id="text_attr" class="panel focus">
            <table cellpadding="0" cellspacing="1" border="0" width="100%" class="formtable">
                <tr>
                    <th style="width:80px;">绑定字段:</th>
                    <td><select class="myselect2" id="bindfiled" style="width:255px"></select></td>
                </tr>
                <tr>
                    <th>默认值:</th>
                    <td><input type="text" class="mytext" id="defaultvalue" style="width:290px; margin-right:6px;"/><select class="myselect" onchange="setDefaultValue(document.getElementById('defaultvalue'), this.value);" style="width:150px"><%=workFlowFrom.GetDefaultValueSelect("") %></select></td>
                </tr>
                <tr>
                    <th>控件宽度:</th>
                    <td><input type="text" id="width" class="mytext" style="width:150px" />
                        弹出宽度:<input type="text" id="windowwidth" class="mytext" style="width:80px" />PX
                        弹出高度:<input type="text" id="windowheight" class="mytext" style="width:80px" />PX
                    </td>
                </tr>
                <tr>
                    <th>弹出页面:</th>
                    <td colspan="3">
                        <select class="myselect" style="width:130px; max-height:200px;" onchange="form_types_change(this.value);" id="form_types">
                            <option value=""></option>
                            <%=new RoadFlow.Platform.AppLibrary().GetTypeOptions() %>
                        </select>
                        <select class="myselect" style="width:290px;" id="form_forms" onchange="loadFields(this.value);"></select> 
                    </td>
                </tr>
                <tr>
                    <th>获取标题:</th>
                    <td>关键字段:<select class="myselect" id="pkfield"></select>
                        &nbsp;&nbsp;标题字段:<select class="myselect" id="titlefield"></select></td>
                </tr>
                <tr>
                    <th>参数名称:</th>
                    <td>
                        <input type="text" class="mytext" style="width:90%;" id="paramsname" />
                    </td>
                </tr>
                <tr>
                    <th>参数值:</th>
                    <td>
                        <textarea class="mytextarea" style="width:99%;height:60px;" id="paramsvalue"></textarea>
                        <div>这里写JS脚本，例 $("#TempTest_CustomForm\\.Title").val() 获取表单中某个控件值</div>
                    </td>
                </tr>
            </table>    
        </div>

        <div id="text_event" class="panel">
          <%Server.Execute("events.aspx"); %>
        </div>
    </div>
</div>

<script type="text/javascript">
    var oNode = null, thePlugins = 'formselectdiv';
    var attJSON = parent.formattributeJSON;

    var parentEvents = parent.formEvents;
    var events = [];
    var eventsid = RoadUI.Core.newid(false);

    function form_types_change(value)
    {
        $.ajax({
            url: "/AppLibrary/GetApps", data: { type: value }, async: false, type: "post", success: function (txt)
            {
                $("#form_forms").html('<option value=""></option>' + txt);
            }
        });
    }

    function loadFields(value)
    {
        $.ajax({
            url: "/ProgramBuilder/GetFieldsOptions", data: { applibaryid: value }, async: false, type: "post", success: function (txt)
            {
                $("#titlefield").html('<option value=""></option>' + txt);
                $("#pkfield").html('<option value=""></option>' + txt);
            }
        });
    }

    $(function ()
    {
        if (UE.plugins[thePlugins].editdom)
        {
            oNode = UE.plugins[thePlugins].editdom;
        }
        biddingFileds(attJSON, oNode ? $(oNode).attr("id") : "", $("#bindfiled"));
        if (oNode)
        {
            $text = $(oNode);
            $("#defaultvalue").val(RoadUI.Core.decodeUri($text.attr('defaultvalue') || ""));
            if ($text.attr('width1')) $("#width").val($text.attr('width1'));
            if ($text.attr('data-windowwidth')) $("#windowwidth").val($text.attr('data-windowwidth'));
            if ($text.attr('data-windowheight')) $("#windowheight").val($text.attr('data-windowheight'));
            $("#form_types").val($text.attr("form_types")).change();
            $("#form_forms").val($text.attr("appid")).change();
            $("#titlefield").val($text.attr("titlefield"));
            $("#pkfield").val($text.attr("pkfield"));
            $("#paramsvalue").val(RoadUI.Core.decodeUri($text.attr("paramsvalue" || "")));
            $("#paramsname").val($text.attr("paramsname"));
            if ($text.attr('eventsid'))
            {
                eventsid = $text.attr('eventsid');
                events = getEvents(eventsid);
            }
        }
        initTabs();
    });

    dialog.oncancel = function ()
    {
        if (UE.plugins[thePlugins].editdom)
        {
            delete UE.plugins[thePlugins].editdom;
        }
    };
    dialog.onok = function ()
    {
        var bindfiled = $("#bindfiled").val();
        var id = attJSON.dbconn && attJSON.dbtable && bindfiled ? attJSON.dbtable + '.' + bindfiled : "";
        var width = $("#width").val();
        var defaultvalue = $("#defaultvalue").val();
        var form_types = $("#form_types").val();
        var titlefield = $("#titlefield").val();
        var pkfield = $("#pkfield").val();
        var form_forms = $("#form_forms").val();
        var paramsvalue = $("#paramsvalue").val();
        var paramsname = $("#paramsname").val();
        var windowwidth = $("#windowwidth").val();
        var windowheight = $("#windowheight").val();

        var html = '<input type="text" id="' + id + '" type1="flow_selectdiv" name="' + id + '" value="弹出选择" ';
        if (width)
        {
            html += 'style="width:' + width + '" ';
            html += 'width1="' + width + '" ';
        }
        if (windowwidth)
        {
            html += 'data-windowwidth="' + windowwidth + '" ';
        }
        if (windowheight)
        {
            html += 'data-windowheight="' + windowheight + '" ';
        }

        html += 'defaultvalue="' + encodeURIComponent(defaultvalue) + '" ';
        html += 'form_types="' + form_types + '" ';
        html += 'appid="' + form_forms + '" ';
        html += 'titlefield="' + titlefield + '" ';
        html += 'pkfield="' + pkfield + '" ';
        html += 'paramsvalue="' + encodeURIComponent(paramsvalue) + '" ';
        html += 'paramsname="' + paramsname + '" ';

        if (events.length > 0)
        {
            html += 'eventsid="' + eventsid + '" ';
            setEvents(eventsid);
        }
        html += '/>';

        if (oNode)
        {
            $(oNode).after(html);
            domUtils.remove(oNode, false);
        }
        else
        {
            editor.execCommand('insertHtml', html);
        }
        delete UE.plugins[thePlugins].editdom;
    }
</script>
</body>
</html>