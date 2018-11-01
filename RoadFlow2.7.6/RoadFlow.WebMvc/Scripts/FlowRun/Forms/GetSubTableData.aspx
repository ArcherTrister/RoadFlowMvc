<%@ Page Language="C#" %>
<%
    string secondtable = Request["secondtable"];
    string primarytablefiled = Request["primarytablefiled"];
    string secondtableprimarykey = Request["secondtableprimarykey"];
    string primarytablefiledvalue = Request["primarytablefiledvalue"];
    string secondtablerelationfield=Request["secondtablerelationfield"];
    string dbconnid = Request["dbconnid"];
    string subtableformat = Request["subtableformat"];
    string sortstring = Request["sortstring"];
    string sortField = sortstring.IsNullOrEmpty() ? secondtableprimarykey : sortstring;

    LitJson.JsonData data = new RoadFlow.Platform.WorkFlow().GetSubTableData(dbconnid, secondtable, secondtablerelationfield, primarytablefiledvalue, sortField, subtableformat);

    Response.Write(data.ToJson());
%>