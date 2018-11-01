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
<br />
<table cellpadding="0" cellspacing="1" border="0" width="95%" class="formtable">
    <tr>
        <th style="width:120px;">绑定字段：</th>
        <td><select class="myselect2" id="bindfiled" style="width:227px"></select></td>
    </tr>
    <tr>
        <th>格式：</th>
        <td><input type="text" id="formatstring" class="mytext" style="width:227px" /></td>
    </tr>
    <tr>
        <th>位数：</th>
        <td><input type="text" id="length" class="mytext" style="width:227px" /></td>
    </tr>
    <tr>
        <th>当前编号字段：</th>
        <td><select class="myselect" id="maxfiled" style="width:227px"></select></td>
    </tr>
    <tr>
        <th>宽度：</th>
        <td><input type="text" id="width" class="mytext" style="width:150px" /></td>
    </tr>
    <tr>
        <th>背景文字：</th>
        <td><input type="text" id="placeholdertext" class="mytext" style="width:95%" /></td>
    </tr>
    <tr>
        <th>SQL条件：</th>
        <td><textarea id="sqlwhere" class="mytextarea" style="width:95%;height:60px;"></textarea></td>
    </tr>
</table>
<script type="text/javascript">
    var oNode = null, thePlugins = 'formserialnumber';
    var attJSON = parent.formattributeJSON;
    $(function ()
    {
        if (UE.plugins[thePlugins].editdom)
        {
            oNode = UE.plugins[thePlugins].editdom;
        }
        biddingFileds(attJSON, oNode ? $(oNode).attr("id") : "", $("#bindfiled"));
        biddingFileds(attJSON, oNode ? (attJSON.dbtable || "") + '.' + $(oNode).attr("maxfiled") : "", $("#maxfiled"));
        if (oNode)
        {
            $text = $(oNode);
            if ($text.attr('width1')) $("#width").val($text.attr('width1'));
            //$("#lstype").val($text.attr('lstype'));
            $("#formatstring").val($text.attr('formatstring'));
            $("#sqlwhere").val(RoadUI.Core.decodeUri($text.attr('sqlwhere')));
            $("#length").val($text.attr('length'));
            $("#placeholdertext").val($text.attr('placeholder') || '');
        }
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
        var maxfiled = $("#maxfiled").val();
        var id = attJSON.dbconn && attJSON.dbtable && bindfiled ? attJSON.dbtable + '.' + bindfiled : "";
        var width = $("#width").val();
        //var lstype = $("#lstype").val();
        var formatstring = $("#formatstring").val();
        var sqlwhere = $("#sqlwhere").val();
        var length = $("#length").val();
        var placeholdertext = $("#placeholdertext").val() || '';
        var html = '<input type="text" type1="flow_serialnumber" id="' + id + '" maxfiled="' + maxfiled + '" name="' + id + '" value="流水号" ';
        if (width)
        {
            html += 'style="width:' + width + '" ';
            html += 'width1="' + width + '" ';
        }
        if (placeholdertext)
        {
            html += 'placeholder="' + placeholdertext.replace('"', '') + '" ';
        }
        //html += 'lstype="' + lstype + '" ';
        html += 'formatstring="' + formatstring + '" ';
        html += 'sqlwhere="' + encodeURIComponent(sqlwhere) + '" ';
        html += 'length="' + length + '" ';
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
