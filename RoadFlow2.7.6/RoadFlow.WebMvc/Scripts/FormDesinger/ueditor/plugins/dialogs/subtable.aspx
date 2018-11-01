﻿<%@ Page Language="C#" %>

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
    RoadFlow.Platform.AppLibrary bappLibrary = new RoadFlow.Platform.AppLibrary();
    string appLibraryTypes = bappLibrary.GetTypeOptions();
    string displayModelOptions = workFlowFrom.GetDisplayModeOptions("");
%>
<table cellpadding="0" cellspacing="1" border="0" width="98%" class="formtable" style="margin-top:6px;">
    <tr>
        <th style="width:118px;">从表：</th>
        <td style="width:25%;"><select class="myselect2" id="secondtable" style="width:195px" onchange="table_change(this)"></select></td>
        <th style="width:80px;">从表主键：</th>
        <td style="width:25%;"><select class="myselect2" id="secondtableprimarykey" style="width:195px"></select></td>
        <th style="width:80px;">主表字段：</th>
        <td style="width:25%;"><select class="myselect2" id="primarytablefiled" style="width:195px"></select></td>
    </tr>
    
    <tr>
        <th>与主表关联字段：</th>
        <td><select class="myselect2" id="secondtablerelationfield" style="width:195px"></select></td>
        <th>编辑方式：</th>
        <td>
            <input type="radio" value="0" onclick="setEdit(0);" checked="checked" id="secondtableeditmodel_0" name="editmodel" style="vertical-align:middle;"/><label for="secondtableeditmodel_0" style="vertical-align:middle;">常规</label>
            <input type="radio" value="1" onclick="setEdit(1);" id="secondtableeditmodel_1" name="editmodel" style="vertical-align:middle;"/><label for="secondtableeditmodel_1" style="vertical-align:middle;">弹出</label>
        </td>
        <th>显示序号：</th>
        <td><input type="checkbox" id="showindex" name="showindex" value="1" style="vertical-align:middle;" /></td>
    </tr>
    <tr>
        <th><span id="editmodeltitle" style="display:none;">编辑表单：</span></th>
        <td colspan="3">
            <div id="editmodeldiv" style="display:none;">
            <select class="myselect" style="width:110px;" onchange="form_types_change(this.value);" id="form_types">
                <option value=""></option>
                <%=appLibraryTypes %>
            </select>
            <select class="myselect" style="width:180px;" id="editform" ></select> 
            &nbsp;宽度：<input style="width:70px;" type="text" class="mytext" id="editmodel_width" />
            &nbsp;高度：<input style="width:70px;" type="text" class="mytext" id="editmodel_height" />
            </div>
        </td>
        <th>排序：</th>
        <td><input style="width:98%;" type="text" class="mytext" id="sortstring" /></td>
    </tr>
</table>
<div style="width:98%; margin:5px auto 0 auto; height:380px; overflow:auto;">
    <table cellpadding="0" cellspacing="1" border="0" width="98%" class="listtable" id="listtable">
        <thead>
            <tr>
                <th style="width:18%;"><input type="checkbox" style="vertical-align:middle;" onclick="checkall(this);" />显示列</th>
                <th style="width:10%;">显示名称</th>
                <th style="width:10%;">对齐方式</th>
                <th style="width:5%;">宽度</th>
                <th style="width:25%;">编辑模式</th>
                <th style="width:35%;">显示模式</th>
                <th style="width:5%;">合计</th>
                <th style="width:8%;">显示顺序</th>
            </tr>
        </thead>
        <tbody>
            
        </tbody>
    </table>
</div>
<script type="text/javascript">
    var oNode = null, thePlugins = 'formsubtable';
    var attJSON = parent.formattributeJSON;
    var dbconn = attJSON.dbconn || "";
    var dbtable = attJSON.dbtable || "";
    var initJSON = {};
    $(function ()
    {
        var secondtable = '';
        var primarytablefiled = '';
        var secondtableprimarykey = '';
        var secondtablerelationfield = '';
        if (UE.plugins[thePlugins].editdom)
        {
            oNode = UE.plugins[thePlugins].editdom;
        }
        if (oNode)
        {
            $text = $(oNode);
            var id = $text.attr("id");
            for (var i = 0; i < parent.formsubtabs.length; i++)
            {
                if (parent.formsubtabs[i].id == id)
                {
                    initJSON = parent.formsubtabs[i];
                    break;
                }
            }

            if (initJSON)
            {
                secondtable = initJSON.secondtable;
                primarytablefiled = initJSON.primarytablefiled;
                secondtableprimarykey = initJSON.secondtableprimarykey;
                secondtablerelationfield = initJSON.secondtablerelationfield;
                $("input[name='editmodel'][value='" + initJSON.editmodel + "']").prop("checked", true);
                $("#form_types").val(initJSON.editformtype).change();
                $("#editform").val(initJSON.editform);
                $("#editmodel_width").val(initJSON.displaymodewidth);
                $("#editmodel_height").val(initJSON.displaymodeheight);
                $("#showindex").prop("checked", "1" == initJSON.showindex);
                $("#sortstring").val(initJSON.sortstring);
            }
        }

        $("#secondtable").html(getTableOps(dbconn, secondtable));
        $("#primarytablefiled").html(getFieldsOps(dbconn, dbtable, primarytablefiled));
        if (secondtable.length > 0)
        {
            table_change($("#secondtable").get(0), secondtableprimarykey, secondtablerelationfield);
            setEdit(initJSON.editmodel);
        }

    });
    function table_change(obj, fields, fields1)
    {
        if (!obj || !obj.value) return;
        var conn = dbconn;
        var table = obj.value;
        var opts = getFieldsOps(conn, table, fields);
        var opts1 = getFieldsOps(conn, table, fields1);
        $("#secondtableprimarykey").html(opts);
        $("#secondtablerelationfield").html(opts1);
        addTableFields(opts, table);

    }
    function getAlignOptions(align)
    {
        var options = '<option value="0"' + ("0" == align ? 'selected="selected"' : '') + '>左对齐</option>';
        options += '<option value="1"' + ("1" == align ? 'selected="selected"' : '') + '>居中</option>';
        options += '<option value="2"' + ("2" == align ? 'selected="selected"' : '') + '>右对齐</option>';
        return options;
    }
    function addTableFields(opts, table)
    {
        var $tbody = $("#listtable tbody");
        var $thead = $("#listtable thead");
        $tbody.html('');
        $(opts).each(function (index)
        {
            var filed = $(this).val();
            var filedNoNote = $(this).text();
            if (filed.length == 0)
            {
                return true;
            }

            var isshow = false;
            var issum = false;
            var showname = "";
            var showtype = "";
            var index = "";
            var editmode = {};
            var displaymode = "";
            var displaymodeformat = "";
            var displaymodesql = "";
            var align = "";
            var width = "";
            if (initJSON && initJSON.colnums)
            {
                for (var i = 0; i < initJSON.colnums.length; i++)
                {
                    if (initJSON.colnums[i].name == table + "_" + filed)
                    {
                        var colnumjson = initJSON.colnums[i];
                        isshow = "1" == colnumjson.isshow;
                        issum = "1" == colnumjson.issum;
                        showname = colnumjson.showname;
                        editmode = colnumjson.editmode;
                        displaymode = colnumjson.displaymode;
                        displaymodeformat = colnumjson.displaymodeformat;
                        displaymodesql = colnumjson.displaymodesql;
                        index = colnumjson.index || "";
                        align = colnumjson.align || "";
                        width = colnumjson.width || "";
                        if (editmode && editmode.title) showtype = editmode.title;
                        break;
                    }
                }
            }

            var tr = '<tr>';
            tr += '<td style="background-color:#ffffff; height:28px; word-break:normal; white-space:normal;"><input type="checkbox" name="field" value="' + filed + '" id="field_' + filed + '" ' + (isshow ? 'checked="checked"' : '') + ' style="vertical-align:middle;" /><label style="vertical-align:middle;" for="field_' + filed + '">' + filedNoNote + '</label></td>';
            tr += '<td style="background-color:#ffffff;"><input type="text" class="mytext" name="name_' + filed + '" value="" />' + '</td>';
            tr += '<td style="background-color:#ffffff;"><select class="myselect" style="width:70px;" id="field_align_' + filed + '">' + getAlignOptions(align) + '</select></td>'
            tr += '<td style="background-color:#ffffff;"><input type="text" class="mytext" style="width:40px;" id="field_width_' + filed + '" value="' + width + '" />' + '</td>';
            tr += '<td style="background-color:#ffffff;"><input type="hidden" value="" id="set_' + filed + '_hidden"/><input type="text" class="mytext" readonly="readonly" style="width:100px;mraing-right:0;" name="set_' + filed + '" id="set_' + filed + '" value="' + showtype + '"/><input type="button" class="mybutton" style="border-left:none 0;margin:0;" value="设置" onclick="filedEditSet(\'' + filed + '\');"/>' + '</td>';
            tr += '<td style="background-color:#ffffff;"><select class="myselect" style="width:130px;" onchange="setDisplayModel(this);" id="field_display_' + filed + '"><%=displayModelOptions%></select></td>';
            tr += '<td style="background-color:#ffffff;"><input type="checkbox" name="field_count" value="' + filed + '" id="field_count_' + index + '" ' + (issum ? 'checked="checked"' : '') + ' style="vertical-align:middle;" /></td>';
            tr += '<td style="background-color:#ffffff;"><input type="text" class="mytext" id="field_index_' + filed + '" style="width:40px;" value="' + index + '"/></td>';
            tr += '</tr>';
            var $tr = $(tr);
            if (showname)
            {
                $("input[name='name_" + filed + "']", $tr).val(showname);
            }
            if (editmode)
            {
                $("input[id='set_" + filed + "_hidden']", $tr).val(JSON.stringify(editmode));
            }
            $tbody.append($tr);
            var $sel = $("#field_display_" + filed, $tr);
            $sel.val(displaymode);
            setDisplayModel($sel.get(0), displaymodeformat, displaymodesql);
            new RoadUI.Text().init($(".mytext"), $tr);
            new RoadUI.Button().init($(".mybutton"), $tr);
            new RoadUI.Select().init($(".myselect"), $tr);
            var editmodeval = $(":checked[name='editmodel']").val();
            if ("1" == editmodeval)
            {
                $("td:eq(4)", $("tr", $tbody)).hide();
                $("th:eq(4)", $("tr", $thead)).hide();

                $("td:eq(5)", $("tr", $tbody)).show();
                $("th:eq(5)", $("tr", $thead)).show();
            }
            else
            {
                $("td:eq(5)", $("tr", $tbody)).hide();
                $("th:eq(5)", $("tr", $thead)).hide();

                $("td:eq(4)", $("tr", $tbody)).show();
                $("th:eq(4)", $("tr", $thead)).show();
            }

        });
    }
    function filedEditSet(field)
    {
        top.mainDialog.open({
            id: "from_set_" + field,
            url: "/Scripts/FormDesinger/ueditor/plugins/dialogs/subtableset.aspx?eid=set_" + field + "&dbconn=" + dbconn + "&secondtable=" + $("#secondtable").val() + "&field=" + field,
            title: field + "-编辑模式设置", width: 800, height: 580
        });
    }
    function checkall(obj)
    {
        $("input[name='field']").prop('checked', $(obj).prop('checked'));
    }
    function form_types_change(value)
    {
        $.ajax({
            url: "/AppLibrary/GetApps", data: { type: value }, async: false, type: "post", success: function (txt)
            {
                $("#editform").html('<option value=""></option>' + txt);
            }
        });
    }
    function setEdit(model)
    {
        var $tbody = $("#listtable tbody");
        var $thead = $("#listtable thead");
        if (model == 0)
        {
            $("#editmodeltitle").hide();
            $("#editmodeldiv").hide();

            $("td:eq(5)", $("tr", $tbody)).hide();
            $("th:eq(5)", $("tr", $thead)).hide();

            $("td:eq(4)", $("tr", $tbody)).show();
            $("th:eq(4)", $("tr", $thead)).show();
        }
        else if (model == 1)
        {
            $("#editmodeltitle").show();
            $("#editmodeldiv").show();

            $("td:eq(4)", $("tr", $tbody)).hide();
            $("th:eq(4)", $("tr", $thead)).hide();

            $("td:eq(5)", $("tr", $tbody)).show();
            $("th:eq(5)", $("tr", $thead)).show();
        }
    }
    function setDisplayModel(selObj, format, sql)
    {
        var model = selObj.value;
        var $obj = $(selObj);
        var id = $obj.attr("id");
        switch (model)
        {
            case "datetime_format":
            case "number_format":
            case "string_format":
                $obj.next("span").remove();
                $obj.after('<span style="margin-left:8px;">格式：<input style="width:160px;" type="text" id="' + id + '_format" value="' + (format || "") + '" class="mytext"/></span>');
                new RoadUI.Text().init($("#" + id + "_format"));
                break;
            case "table_fieldvalue":
                $obj.next("span").remove();
                $obj.after('<span style="margin-left:8px;">查询：<input style="width:160px;" type="text" id="' + id + '_sql" value="' + (sql || "") + '" class="mytext"/></span>');
                new RoadUI.Text().init($("#" + id + "_sql"));
                break;
                break;
            default:
                $obj.next("span").remove();
                break;
                //case "table_fieldvalue":
                //    $obj.next("span").remove();
                //    $obj.after('<span style="margin:5px 0 0 8px; background:#e8e8e8;">' +
                //        '<div style="margin:5px;">连接：<select class="myselect" style="width:100px;" id="' + id + '_dbconn"></select>' +
                //        '&nbsp;&nbsp;表：<select class="myselect" style="width:100px;" id="' + id + '_table"></select></div>' +
                //        '<div style="margin:5px;">字段：<select class="myselect" style="width:100px;" id="' + id + '_field"></select>' +
                //        '&nbsp;&nbsp;关联字段：<select class="myselect" style="width:100px;" id="' + id + '_relationfield"></select></div>' +
                //        '</span>');
                //    new RoadUI.Select().init($(".myselect", $obj.next('span')));
                //    break;
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
        var secondtable = $("#secondtable").val();
        var primarytablefiled = $("#primarytablefiled").val();
        var secondtableprimarykey = $("#secondtableprimarykey").val();
        var secondtablerelationfield = $("#secondtablerelationfield").val();
        var json = {};
        json.secondtable = secondtable;
        json.primarytablefiled = primarytablefiled;
        json.secondtableprimarykey = secondtableprimarykey;
        json.secondtablerelationfield = secondtablerelationfield;
        json.editmodel = $(":checked[name='editmodel']").val();
        json.editformtype = $("#form_types").val();
        json.editform = $("#editform").val();
        json.displaymodewidth = $("#editmodel_width").val();
        json.displaymodeheight = $("#editmodel_height").val();
        json.showindex = $("#showindex").prop("checked") ? "1" : "0";
        json.sortstring = $("#sortstring").val();
        json.colnums = [];
        $("#listtable tbody tr").each(function (index)
        {
            var field = $("input[type='checkbox'][id^='field_']", $(this)).val();
            var jstr = $("input[id='set_" + field + "_hidden']", $(this)).val();
            var colnum = {};
            colnum.name = secondtable + "_" + field;
            colnum.fieldname = field;
            colnum.isshow = $("input[type='checkbox'][id^='field_']", $(this)).prop("checked") ? "1" : "0";
            colnum.showname = $("input[name='name_" + field + "']", $(this)).val();
            colnum.editmode = jstr.length > 0 ? JSON.parse(jstr) : {};
            colnum.displaymode = $("[id='field_display_" + field + "']", $(this)).val();
            colnum.displaymodeformat = $("[id='field_display_" + field + "_format']", $(this)).val();
            colnum.displaymodesql = $("[id='field_display_" + field + "_sql']", $(this)).val();
            colnum.issum = $("input[type='checkbox'][name='field_count']", $(this)).prop("checked") ? "1" : "0";
            colnum.index = $("input[id='field_index_" + field + "']", $(this)).val();
            colnum.align = $("[id='field_align_" + field + "']", $(this)).val();
            colnum.width = $("[id='field_width_" + field + "']", $(this)).val();
            json.colnums.push(colnum);

        });
        var id = secondtable + "_" + primarytablefiled + "_" + secondtableprimarykey + "_" + secondtablerelationfield;
        var html = '<input type="text" isflow="1" readonly="readonly" type1="flow_subtable" id="' + id + '" style="width:99%;height:50px;" value="子表" ';
        html += '/>';
        json.id = id;
        var isadd = true;
        for (var i = 0; i < parent.formsubtabs.length; i++)
        {
            if (parent.formsubtabs[i].id == id)
            {
                parent.formsubtabs[i] = json;
                isadd = false;
                break;
            }
        }
        if (isadd)
        {
            parent.formsubtabs.push(json);
        }
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