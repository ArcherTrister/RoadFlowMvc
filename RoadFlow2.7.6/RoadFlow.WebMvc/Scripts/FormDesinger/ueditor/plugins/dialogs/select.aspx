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
        <span class="tab" data-content-id="text_default" onclick="loadOptions();">&nbsp;&nbsp;默认值&nbsp;&nbsp;</span>
        <span class="tab" data-content-id="text_event">&nbsp;&nbsp;事件&nbsp;&nbsp;</span>
    </div>
    <div id="tabbody" class="tabbody" style="height:390px;">
        <div id="text_attr" class="panel focus">
    <table cellpadding="0" cellspacing="1" border="0" width="100%" class="formtable">
        <tr>
            <th style="width:80px;">绑定字段：</th>
            <td><select class="myselect2" id="bindfiled" style="width:227px"></select></td>
        </tr>
        <tr>
            <th>宽度：</th>
            <td><input type="text" class="mytext" id="width" value="" />
                <input type="checkbox" name="hasempty" id="hasempty" value="1" style="vertical-align:middle; margin-left:15px;" />
                <label style="vertical-align:middle;" for="hasempty">添加空选项</label>
            </td>
        </tr>  
        <tr>
            <th>数据源：</th>
            <td><%=workFlowFrom.GetDataSourceRadios("datasource","0","onclick='dsChange(this.value);'") %></td>
        </tr>
        <tr id="ds_dict">
            <th>字典项：</th>
            <td><input type="text" class="mydict" id="ds_dict_value" more="0" value="" />
                <input type="checkbox" style="vertical-align:middle; margin-left:15px;" id="ds_dict_ischild" value="1" /><label style="vertical-align:middle;" for="ds_dict_ischild">加载下级</label>
                <span style="margin-left:15px;">值字段：</span><select class="myselect" style="" id="ds_dict_valuefield">
                    <option value="RoadFlow.Platform.Dictionary.OptionValueField.ID">ID</option>
                    <option value="RoadFlow.Platform.Dictionary.OptionValueField.Code">唯一代码</option>
                    <option value="RoadFlow.Platform.Dictionary.OptionValueField.Value">值</option>
                    <option value="RoadFlow.Platform.Dictionary.OptionValueField.Title">标题</option>
                    <option value="RoadFlow.Platform.Dictionary.OptionValueField.Note">备注</option>
                    <option value="RoadFlow.Platform.Dictionary.OptionValueField.Other">其他</option>
                </select>
            </td>
        </tr>  
        <tr id="ds_custom" style="display:none;">
            <th>自定义选项：</th>
            <td>
                <div style="margin:0 auto; padding:0 5px;">
                <div style="height:25px; padding:2px 0;">格式：选项文本1,选项值1;选项文本2,选项值2</div>
                    <textarea class="mytextarea" id="custom_string" style="height:122px; width:100%;"></textarea>
                </div>
            </td>
        </tr>  
        <tr id="ds_sql" style="display:none;">
            <th>SQL语句：</th>
            <td>
                <table border="0" style="width:100%;">
                    <tr>
                        <td style="width:80%">
                          <div>1.SQL应返回两个字段的数据源</div>
                          <div>2.第一个字段为值，第二个字段为标题</div>
                          <div>3.如果只返回一个字段则值和标题一样</div>
                        </td>
                        
                    </tr>
                    <tr>
                        <td colspan="2" style="padding-top:4px;">
                            <div>数据连接：<select class="myselect" id="ds_sql_dbconn"><%=new RoadFlow.Platform.DBConnection().GetAllOptions() %></select>
                                <input type="button" value="测试SQL" onclick="testSql($('#ds_sql_value').val(), $('#ds_sql_dbconn').val());" class="mybutton" />
                            </div>
                            <div style="margin-top:5px;"><textarea cols="1" rows="1" id="ds_sql_value" style="width:99%; height:65px; font-family:Verdana;" class="mytextarea"></textarea></div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>  
        <tr>
            <th>联动：</th>
            <td>字段：<select id="Linkage_Field" class="myselect" style="width:180px;"></select>
                <span style="margin-left:8px;">选项来源：<input style="vertical-align:middle;" type="radio" onclick="$('#Linkage_Source_sql_link').show();" value="sql" id="Linkage_Source_sql" name="Linkage_Source"/><label style="vertical-align:middle;" for="Linkage_Source_sql">SQL</label>
                    <input style="vertical-align:middle;" type="radio" value="url" id="Linkage_Source_url" onclick="$('#Linkage_Source_sql_link').hide();" name="Linkage_Source"/><label style="vertical-align:middle;" for="Linkage_Source_url">URL</label>
                    <input style="vertical-align:middle;" type="radio" value="dict" id="Linkage_Source_dict" onclick="$('#Linkage_Source_sql_link').hide();" name="Linkage_Source"/><label style="vertical-align:middle;" for="Linkage_Source_dict">数据字典下级</label>
                </span>
                <div style="margin-top:6px; display:none;" id="Linkage_Source_sql_link">数据连接：<select class="myselect" id="Linkage_Source_sql_conn"><%=new RoadFlow.Platform.DBConnection().GetAllOptions() %></select>
                    <input type="button" value="测试SQL" onclick="testSql($('#Linkage_Source_text').val(), $('#Linkage_Source_sql_conn').val());" class="mybutton" />
                </div>
                <div style="margin-top:6px;">
                    <textarea class="mytextarea" id="Linkage_Source_text" style="height:62px; width:99%;"></textarea>
                </div>
            </td>
        </tr> 
    </table>
   
    </div>
        <div id="text_default" class="panel">
            <div id="text_default_list" style="height:288px; overflow:auto;">

            </div>
        </div>
        <div id="text_event" class="panel">
           <%Server.Execute("events.aspx"); %>
        </div>
    </div>
</div>
<script type="text/javascript">
    var oNode = null, thePlugins = 'formselect';
    var attJSON = parent.formattributeJSON;
    var fieldsArray = getFields(attJSON.dbconn, attJSON.dbtable);
    var parentEvents = parent.formEvents;
    var events = [];
    var eventsid = RoadUI.Core.newid(false);
    $(function ()
    {
        $("#ds_sql_dbconn").val(attJSON.dbconn || "");
        if (UE.plugins[thePlugins].editdom)
        {
            oNode = UE.plugins[thePlugins].editdom;
        }
        biddingFileds(attJSON, oNode ? $(oNode).attr("id") : "", $("#bindfiled"));

        var $elements = $("[type1]", dialog.editor.document);
        var filedOptions = [];
        for (var i = 0; i < $elements.length; i++)
        {
            if (!$elements.eq(i) || !$elements.eq(i).attr("id")) continue;
            var note1 = '';
            for (var j = 0; j < fieldsArray.length; j++)
            {
                if (attJSON.dbtable + '.' + fieldsArray[j].name == $elements.eq(i).attr("id") && fieldsArray[j].note && fieldsArray[j].note.length > 0)
                {
                    note1 = '(' + fieldsArray[j].note + ')';
                    break;
                }
            }
            var txt = $elements.eq(i).attr("id").indexOf('.') >= 0
                ? $elements.eq(i).attr("id").split('.')[1] + note1 + '-' + '' + $elements.eq(i).attr("id").split('.')[0] + ''
                : $elements.eq(i).attr("id");

            filedOptions.push('<option' + ($elements.eq(i).attr("id") == '' ? ' selected="selected"' : '') + ' value="' + $elements.eq(i).attr("id") + '">' + txt + '</option>');
        }
        $("#Linkage_Field").html('<option value=""></option>' + filedOptions.join(''));

        if (oNode)
        {
            $text = $(oNode);
            $("#width").val($text.attr("width1"));
            $("#hasempty").prop("checked", "1" == $text.attr("hasempty"));
            $("#Linkage_Field").val($text.attr('linkagefield'));
            $("#Linkage_Source_url").prop("checked", 'url' == $text.attr("linkagesource"));
            $("#Linkage_Source_sql").prop("checked", 'sql' == $text.attr("linkagesource"));
            $("#Linkage_Source_dict").prop("checked", 'dict' == $text.attr("linkagesource"));
            $("#Linkage_Source_text").val($text.attr('linkagesourcetext'));
            $("#Linkage_Source_sql_conn").val($text.attr('linkagesourceconn'));
            
            if ('sql' == $text.attr("linkagesource"))
            {
                $("#Linkage_Source_sql_link").show();
            }

            $("input[name='datasource'][value='" + $text.attr('datasource') + "']").prop('checked', true);
            if ("1" == $text.attr("datasource"))
            {
                $("#ds_dict").hide();
                $("#ds_sql").hide();
                $("#ds_custom").show();
                var custionJSONString = $text.attr("customopts");
                if ($.trim(custionJSONString).length > 0)
                {
                    var customJSON = JSON.parse(custionJSONString);
                    var customString = [];
                    for (var i = 0; i < customJSON.length; i++)
                    {
                        customString.push(customJSON[i].title + "," + customJSON[i].value);
                    }
                    $("#custom_string").val(customString.join(';'));
                }
                new RoadUI.DragSort($("#custom_sort"));
            }
            else if ("0" == $text.attr("datasource"))
            {
                $("#ds_dict").show();
                $("#ds_sql").hide();
                $("#ds_custom").hide();
                $("#ds_dict_value").val($text.attr('dictid'));
                $("#ds_dict_ischild").prop("checked", '1' == $text.attr('ischild'));
                $("#ds_dict_valuefield").val($text.attr('valuefiled'));
                new RoadUI.Dict().setValue($("#ds_dict_value"));
            }
            else if ("2" == $text.attr("datasource"))
            {
                $("#ds_dict").hide();
                $("#ds_sql").show();
                $("#ds_custom").hide();
                $("#ds_sql_dbconn").val($text.attr('dbconn'));
                $("#ds_sql_value").val($text.attr('sql'));
            }

            if ($text.attr('eventsid'))
            {
                eventsid = $text.attr('eventsid');
                events = getEvents(eventsid);
            }
        }

        new RoadUI.DragSort($("#custom_sort"));
        initTabs();
    });

    function loadOptions()
    {
        var $listDiv = $("#text_default_list");
        var datasource = $(":checked[name='datasource']").val();
        var dvalue = $(":checked", $listDiv).val() || ($(oNode).attr("defaultvalue") || "");
        $listDiv.html('');
        if ("1" == datasource)
        {
            var custom_string = ($("#custom_string").val() || "").split(';');
            for (var i = 0; i < custom_string.length; i++)
            {
                var titlevalue = custom_string[i].split(',');
                if (titlevalue.length != 2)
                {
                    continue;
                }
                var title = titlevalue[0];
                var value = titlevalue[1];
                var option = '<div><input type="radio" ' + (value == dvalue ? 'checked="checked"' : '') + ' value="' + value + '" id="defaultvalue_' + value + '" style="vertical-align:middle;" name="defaultvalue"/><label style="vertical-align:middle;" for="defaultvalue_' + value + '">' + title + '(' + value + ')</label></div>';
                $listDiv.append(option);
            }
        }
        else if ("0" == datasource)
        {
            var dictid = $("#ds_dict_value").val();
            $.ajax({
                url: "getdictchilds.aspx?dictid=" + dictid, cache: false, async: false, dataType: "json", success: function (json)
                {
                    for (var i = 0; i < json.length; i++)
                    {
                        var title = json[i].title;
                        var value = json[i].id;
                        var option = '<div><input type="radio" ' + (value == dvalue ? 'checked="checked"' : '') + ' value="' + value + '" id="defaultvalue_' + value + '" style="vertical-align:middle;" name="defaultvalue"/><label style="vertical-align:middle;" for="defaultvalue_' + value + '">' + title + '(' + value + ')</label></div>';
                        $listDiv.append(option);
                    }
                }
            });
        }
        else if ("2" == datasource)
        {
            var sql = $("#ds_sql_value").val();
            $.ajax({
                url: "getsqljson.aspx", type: "post", data: { sql: sql, conn: attJSON.dbconn }, cache: false, async: false, dataType: "json", success: function (json)
                {
                    for (var i = 0; i < json.length; i++)
                    {
                        var title = json[i].title;
                        var value = json[i].id;
                        var option = '<div><input type="radio" ' + (value == dvalue ? 'checked="checked"' : '') + ' value="' + value + '" id="defaultvalue_' + value + '" style="vertical-align:middle;" name="defaultvalue"/><label style="vertical-align:middle;" for="defaultvalue_' + value + '">' + title + '(' + value + ')</label></div>';
                        $listDiv.append(option);
                    }
                }
            });
        }
    }

    function dsChange(value)
    {
        if (value == 0)
        {
            $("#ds_dict").show();
            $("#ds_custom").hide();
            $("#ds_sql").hide();
        }
        else if (value == 1)
        {
            $("#ds_dict").hide();
            $("#ds_sql").hide();
            $("#ds_custom").show();
        }
        else if (value == 2)
        {
            $("#ds_dict").hide();
            $("#ds_custom").hide();
            $("#ds_sql").show();
        }
    }

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
        var datasource = $(":checked[name='datasource']").val();
        var width = $("#width").val();
        var hasempty = $("#hasempty").prop("checked") ? "1" : "0";
        var radios = [];
        var dictid = "";
        var ischild = "";
        var valuefiled = "";
        var sql = "";
        var dbconn = "";
        var dvalue = $(":checked[name='defaultvalue']", $("#text_default_list")).val() || "";
        if ("1" == datasource)
        {
            var custom_string = ($("#custom_string").val() || "").split(';');
            for (var i = 0; i < custom_string.length; i++)
            {
                var titlevalue = custom_string[i].split(',');
                if (titlevalue.length != 2)
                {
                    continue;
                }
                var title = titlevalue[0];
                var value = titlevalue[1];
                radios.push({ title: title, value: value });
            }
        }
        else if ("0" == datasource)
        {
            dictid = $("#ds_dict_value").val();
            ischild = $("#ds_dict_ischild").prop("checked") ? "1" : "0";
            valuefiled = $("#ds_dict_valuefield").val();
        }
        else if ("2" == datasource)
        {
            dbconn = $("#ds_sql_dbconn").val();
            sql = $("#ds_sql_value").val();
        }

        var html = '<input type="text" type1="flow_select" id="' + id + '" name="' + id + '" datasource="' + datasource + '" dictid="' + dictid + '"' + (ischild ? ' ischild="' + ischild + '"' : '') + (valuefiled ? ' valuefiled="' + valuefiled + '"' : '') + ' value="下拉列表框" defaultvalue="' + dvalue + '" hasempty="' + hasempty + '"';
        if (width)
        {
            html += 'style="width:' + width + '" ';
            html += 'width1="' + width + '" ';
        }
        if ("1" == datasource)
        {
            html += "customopts='" + JSON.stringify(radios) + "' ";
        }
        if ("2" == datasource)
        {
            html += 'dbconn="' + dbconn + '" ';
            html += 'sql="' + sql.replaceAll('"', '&quot;') + '" ';
        }

        html += ' linkagefield="' + $("#Linkage_Field").val() + '"';
        html += ' linkagesource="' + $(":checked[name='Linkage_Source']").val() + '"';
        html += ' linkagesourcetext="' + $("#Linkage_Source_text").val().replaceAll('"', '&quot;') + '"';
        html += ' linkagesourceconn="' + $("#Linkage_Source_sql_conn").val() + '"';

        if (events.length > 0)
        {
            html += 'eventsid="' + eventsid + '" ';
            setEvents(eventsid);
        }

        html += ' />';
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