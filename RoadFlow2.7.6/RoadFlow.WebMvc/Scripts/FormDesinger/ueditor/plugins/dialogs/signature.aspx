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

<table cellpadding="0" cellspacing="1" border="0" width="98%" class="formtable" style="margin-top:10px;">
    <tr>
        <th style="width:80px;">绑定字段:</th>
        <td><select class="myselect2" id="bindfiled" style="width:255px"></select></td>
    </tr>
    <tr>
        <th>是否需要密码:</th>
        <td>
            <input type="radio" value="1" name="ispassword" id="ispassword1" style="vertical-align:middle;"/><label for="ispassword1" style="vertical-align:middle;">是</label>
            <input type="radio" value="0" name="ispassword" id="ispassword0" style="vertical-align:middle;"/><label for="ispassword0" style="vertical-align:middle;">否</label>
           
        </td>
    </tr>
</table>    
     

<script type="text/javascript">
    var oNode = null, thePlugins = 'formsignature';
    var attJSON = parent.formattributeJSON;

    var parentEvents = parent.formEvents;
    var events = [];
    var eventsid = RoadUI.Core.newid(false);
    var fieldsArray = getFields(attJSON.dbconn, attJSON.dbtable);
    var elements = $();
    $(function ()
    {
        if (UE.plugins[thePlugins].editdom)
        {
            oNode = UE.plugins[thePlugins].editdom;
        }
        elements = $("[type1]", dialog.editor.document);
        biddingFileds(attJSON, oNode ? $(oNode).attr("id1") : "", $("#bindfiled"));
        if (oNode)
        {
            $text = $(oNode);
            var ispassword = $text.attr("ispassword") || "";
            if ("1" == ispassword)
            {
                $("#ispassword1").prop("checked", true);
            }
            else
            {
                $("#ispassword0").prop("checked", true);
            }
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
        var id = attJSON.dbconn && attJSON.dbtable && bindfiled ? attJSON.dbtable + '.' + bindfiled : "";
        var ispassword = $(":checked[name='ispassword']").val();
        var src = 'string.Concat("/Content/UserSigns/", RoadFlow.Platform.Users.CurrentUserID, ".gif")';
        
        var html = '<input type="button" type1="flow_signature" isflow="1" id="' + id + '_text" class="mybutton" onclick="signature(\'' + id + '_text\',false);" id1="' + id + '" name="' + id + '_text" value=" 签 章 " ';
        html += 'ispassword="' + ispassword + '" ';
        html += 'src=\'@(' + src + ')\'';
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