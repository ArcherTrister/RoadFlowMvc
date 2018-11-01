<%@ Page Language="C#" %>
<%
    string query = "appid=" + Request.QueryString["appid"] + "&tabid=" + Request.QueryString["appid"];
    string rootid = new RoadFlow.Platform.Dictionary().GetIDByCode("FormTypes").ToString();
    WebMvc.Common.Tools.CheckLogin();
%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script type="text/javascript" src="../../dialogs/internal.js"></script>
    <script type="text/javascript" src="../common.js"></script>
    <%=WebMvc.Common.Tools.IncludeFiles %>
</head>
<body style="padding:0; margin:0; overflow:hidden;">
<form method="post">
    <table cellpadding="0" cellspacing="1" border="0" width="100%">
        <tr>
            <td style="vertical-align:top; padding:5px 5px 0 5px;">
                <div id="TypeDiv" style="overflow:auto;width:200px;"></div> 
            </td>
            <td style="vertical-align:top; padding:2px 0 0 3px; border-left:1px solid #cccccc;">
                <div id="ListDiv" style="overflow:auto;">
                    <table cellpadding="0" cellspacing="1" border="0" width="99%" align="center">
                        <tr>
                            <td align="left" height="35">
                                名称：<input type="text" class="mytext" style="width:160px;" id="form_name" value="" name="form_name" />
                                <input type="button" class="mybutton" onclick="query(null, 1);" value=" 查 询 " />
                            </td>
                        </tr>
                    </table>
                    <table id="listtable"></table>
                    <div class="buttondiv"></div>
                </div>
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        var roadTree = null;
        var curPageSize = '<%=Request.QueryString["pagesize"]%>';
        var curPageNumber = '<%=Request.QueryString["pagenumber"]%>';
        var appid = '<%=Request.QueryString["appid"]%>';
        var iframeid = '<%=Request.QueryString["iframeid"]%>';
        var typeid = '<%=Request.QueryString["typeid"]%>';
        $(function ()
        {
            var height = $(window).height();
            $('#TypeDiv').css('height', height - 10);
            $('#ListDiv').css('height', height - 10);
            roadTree = new RoadUI.Tree({ id: "TypeDiv", path: "/Dict/Tree1?ischild=1&root=<%=rootid%>", refreshpath: "/Dict/TreeRefresh", onclick: treeClick });
            $("#listtable").jqGrid({
                url: RoadUI.Core.rooturl() + "/WorkFlowFormDesigner/Query",
                postData: { "__RequestVerificationToken": $("input[name='__RequestVerificationToken']").val(), appid: appid, typeid: typeid, openlist: "1" },
                mtype: 'POST',
                datatype: "json",
                colNames: ['表单名称', '创建人', '创建时间', '修改时间', ''],
                colModel: [
                    { name: 'Name', index: 'Name'},
                    { name: 'CreateUserName', index: 'CreateUserName' },
                    { name: 'CreateTime', index: 'CreateTime' },
                    { name: 'LastModifyTime', index: 'LastModifyTime' },
                    { name: 'Edit', index: '', sortable: false }
                ],
                sortname: "CreateTime",
                sortorder: "desc",
                height: '100%',
                width: $(window).width()-200,
                loadComplete: function ()
                {
                    var gridObj = $("#listtable");
                    var records = gridObj.getGridParam("userData");
                    curPageSize = records.pagesize;
                    curPageNumber = records.pagenumber;
                    $(".buttondiv").html(RoadUI.Core.getPager1(records.total, records.pagesize, records.pagenumber, "query"));
                }
            });

        });
        $(window).resize(function ()
        {
            $("#listtable").setGridWidth($(window).width());
        });
        function query(size, number)
        {
            var data = {
                __RequestVerificationToken: $("input[name='__RequestVerificationToken']").val(),
                form_name: $("#form_name").val(), appid: appid, typeid: typeid, openlist: "1",
                pagesize: size || curPageSize, pagenumber: number || curPageNumber
            };
            $("#listtable").setGridParam({ postData: data }).trigger("reloadGrid");
        }
        function treeClick(json)
        {
            typeid = json.id;
            query();
        }
        function reLoad(id)
        {
            roadTree.refresh(id);
        }
        function openform(id)
        {
            $.ajax({
                url: "/WorkFlowFormDesigner/GetHtml?id=" + id, async: false, cache: false,
                success: function (html)
                {
                    editor.setContent(html);
                }
            });
            $.ajax({
                url: "/WorkFlowFormDesigner/GetAttribute?id=" + id, dataType: "JSON", async: false, cache: false,
                success: function (json)
                {
                    parent.formattributeJSON = json;
                }
            });
            $.ajax({
                url: "/WorkFlowFormDesigner/Getsubtable?id=" + id, dataType: "JSON", async: false, cache: false,
                success: function (json)
                {
                    parent.formsubtabs = json;
                }
            });
            $.ajax({
                url: "/WorkFlowFormDesigner/GetEvents?id=" + id, dataType: "JSON", async: false, cache: false,
                success: function (json)
                {
                    parent.formEvents = json;
                }
            });
            dialog.close();
        }
        function delform(id)
        {
            if (!confirm('您真的要删除该表单吗?'))
            {
                return;
            }
            $.ajax({
                url: 'delete.aspx?id=' + id, cache: false, async: false, success: function (txt)
                {
                    if ("1" == txt)
                    {
                        query();
                    }
                    else
                    {
                        alert(txt);
                    }
                }
            });
        }
    </script>
    </form>
 </body>
 </html>