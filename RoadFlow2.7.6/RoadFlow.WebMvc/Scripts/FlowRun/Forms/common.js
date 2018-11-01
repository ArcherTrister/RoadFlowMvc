formrun = {
    getValidateType: function (valueType)//得到验证类型
    {
        valueType = valueType || "";
        var vtype = "empty";
        if (!valueType || $.trim(valueType).length == 0)
        {
            return vtype;
        }
        switch (parseInt(valueType))
        {
            case 0:
                vtype = "empty";
                break;
            case 1:
                vtype = "int";
                break;
            case 2:
                vtype = "decimal";
                break;
            case 3:
                vtype = "positiveint";
                break;
            case 4:
                vtype = "positivefloat";
                break;
            case 5:
                vtype = "negativeint";
                break;
            case 6:
                vtype = "negativefloat";
                break;
            case 7:
                vtype = "mobile";
                break;
        }
        return vtype;
    },
    initData: function (jsonData, dbtable, jsonStatus, displayModel)
    {
        if (!jsonData || !dbtable)
        {
            return;
        }
        
        if ("1" == $("#Form_HasUEditor").val())
        {
            $(".edui-default[id^='" + dbtable + "'],[type1='flow_html']").each(function ()
            {
                var id = $(this).attr("id");
                var filed = id.split('.')[1];
                var filedshow = 0;//字段显示状态
                var filedcheck = 0;//字段检查方式
                if ("1" != displayModel)
                {
                    var fieldstatus = '';
                    try { fieldstatus = eval("jsonStatus." + (dbtable + "_" + filed).toLowerCase()); } catch (e) { }
                    if (fieldstatus && fieldstatus.length > 0)
                    {
                        var fieldstatusArray = fieldstatus.split('_');
                        if (fieldstatusArray.length == 2)
                        {
                            filedshow = parseInt(fieldstatusArray[0]);
                            filedcheck = parseInt(fieldstatusArray[1]);
                        }
                    }
                }
                else
                {
                    filedshow = 1;
                }
                
                if (1 == filedcheck)
                {

                }
                else if (2 == filedcheck)
                {
                    $(this).attr("validate", "editor");
                }

                if (filedshow == 0)
                {

                }
                else if (filedshow == 1)
                {
                    var value = '';
                    try { value = eval("jsonData." + (dbtable + "_" + filed).toLowerCase()); } catch (e) { }
                    $(this).after(value).remove();
                }
                else if (filedshow == 2)
                {
                    $(this).remove();
                }
            });
        }

        $("[isflow='1']").each(function ()
        {
            var $control = $(this);
            var type1 = ($control.attr("type1") || "").toLowerCase();
            var name = $control.attr("name");
            if (type1 == "flow_org" || type1 == "flow_dict" || type1 == "flow_files" || type1 == "flow_signature" || type1 == "flow_selectdiv")//某些特定控件在原控件name上加了 _text
            {
                name = name.substr(0, name.lastIndexOf("_text"));
            }
            var field = (name || "").split('.');
            if (field.length != 2)
            {
                return true;
            }
            var fieldName = field[1];
           
            var fieldstatus = "1" != displayModel ? eval("jsonStatus." + (dbtable + "_" + fieldName).toLowerCase()) : "";
            var validatetype = formrun.getValidateType($control.attr("valuetype"));
            var initValue = eval("jsonData." + (dbtable + "_" + fieldName).toLowerCase());
           
            //验证类型
            var validate = formrun.initFlowControl(type1, $control, initValue, validatetype, fieldstatus, displayModel);
            if (validate && $.trim(validate).length > 0)
            {
                $control.attr("validate", validate);
            }
        });
        $("[issubflowtable='1']").each(function ()
        {
            var $table = $(this);
            var id = $("input[name='flowsubtable_id']", $table).val();
            var secondtable = $("input[name='flowsubtable_" + id + "_secondtable']", $table).val();
            var primarytablefiled = $("input[name='flowsubtable_" + id + "_primarytablefiled']", $table).val();
            var secondtableprimarykey = $("input[name='flowsubtable_" + id + "_secondtableprimarykey']", $table).val();
            var secondtablerelationfield = $("input[name='flowsubtable_" + id + "_secondtablerelationfield']", $table).val();
            var dbconnid = $("#Form_DBConnID").val();
            var primarytablefiledvalue = eval("jsonData." + (dbtable + "_" + primarytablefiled).toLowerCase());
            if (!primarytablefiledvalue)
            {
                var $ctls = $("tbody tr[type1='listtr'] [issubflow='1']", $table);
                for (var i = 0; i < $ctls.size() ; i++)
                {
                    var $ctl = $ctls.eq(i);
                    var subtype = $ctl.attr("type1");
                    var colname = $ctl.attr("colname");
                    var valtype = formrun.getValidateType($ctl.attr("valuetype"));
                    var subfieldstatus = "1" != displayModel ? eval("jsonStatus." + colname.toLowerCase()) : "";
                    var type1 = $ctl.attr("type1");
                    var ctlvalue = "";
                    if (type1 == "subflow_org" || type1 == "subflow_dict" || type1 == "subflow_files" || type1 == "subflow_signature" || type1 == "subflow_selectdiv")//某些特定控件在原控件name上加了 _text
                    {
                        ctlvalue = $ctl.prev().val();
                    }
                    else if (subtype == "subflow_radio" || subtype == "subflow_checkbox")
                    {
                        ctlvalue = $ctl.prop("checked") ? $ctl.val() : "";
                    }
                    else
                    {
                        ctlvalue = $ctl.val();
                    }
                    if(ctlvalue.length>0)
                    {
                        $ctl.attr("data-defaultvalue", ctlvalue);
                    }
                    var subvalidate = formrun.initFlowControl(subtype, $ctl, ctlvalue, valtype, subfieldstatus, displayModel);
                    if (subvalidate && $.trim(subvalidate).length > 0)
                    {
                        $ctl.attr("validate", subvalidate);
                    }
                }
            }
            else
            {
                var subtableFormats = [];
                $("[format]", $("tbody", $(this))).each(function ()
                {
                    subtableFormats.push("{\"fieldname\":\"" + $(this).attr("colname") + "\",\"format\":\"" + $(this).attr("format") + "\"}");
                });
                var ajaxUrl = RoadUI.Core.rooturl() + "/WorkFlowFormDesigner/GetSubTableData?secondtable=" + secondtable + "&primarytablefiled=" + primarytablefiled +
                    "&secondtableprimarykey=" + secondtableprimarykey + "&secondtablerelationfield=" + secondtablerelationfield +
                    "&primarytablefiledvalue=" + primarytablefiledvalue + "&dbconnid=" + dbconnid;
                $.ajax({
                    url: ajaxUrl, cache: false, async: false, type: "POST", data: { subtableformat: '[' + subtableFormats.join(',') + ']', sortstring: $table.attr("data-sortstring") }, dataType: "JSON", success: function (json)
                    {
                        var isReadonly = "1" == displayModel;//从表里只要有一个字段为只读，则隐藏最后一列添加删除行按钮
                        var countCols = [];//要计算合计的列
                   
                        for (var i = 0; i < json.length; i++)
                        {
                            var secondtableprimarykeyvalue = eval("json[i]." + (secondtable + "_" + secondtableprimarykey).toLowerCase());
                            var $newtr = formrun.subtableNewRow($("tbody tr:first td:last input[type='button']:first", $table), secondtableprimarykeyvalue, 1, true);
                            var $tds = $("td[colname]", $newtr);
                            for (var j = 0; j < $tds.length; j++)
                            {
                                var colname = $tds.eq(j).attr("colname");
                                var colvalue = eval("json[i]." + colname.toLowerCase());
                                var subfieldstatus = 1 != displayModel ? eval("jsonStatus." + colname.toLowerCase()) : "";
                                if (!isReadonly)
                                {
                                    var subfieldstatusArray = (subfieldstatus || "").split('_');
                                    if (subfieldstatusArray.length == 2 && subfieldstatusArray[0] == "1")
                                    {
                                        isReadonly = true;
                                    }
                                }
                                $("[issubflow='1']", $tds.eq(j)).each(function ()
                                {
                                    var $ctl = $(this);
                                    if (!colvalue || $.trim(colvalue).length == 0)
                                    {
                                        if (type1 == "subflow_org" || type1 == "subflow_dict" || type1 == "subflow_files" || type1 == "subflow_signature" || type1 == "subflow_selectdiv")//某些特定控件在原控件name上加了 _text
                                        {
                                            ctlvalue = $ctl.prev().val();
                                        }
                                        else if (subtype == "subflow_radio" || subtype == "subflow_checkbox")
                                        {
                                            ctlvalue = $ctl.prop("checked") ? $ctl.val() : "";
                                        }
                                        else
                                        {
                                            colvalue = $ctl.val();
                                        }
                                    }
                                    var subtype = $ctl.attr("type1");
                                    var valtype = formrun.getValidateType($ctl.attr("valuetype"));
                                    var subvalidate = formrun.initFlowControl(subtype, $ctl, colvalue, valtype, subfieldstatus, displayModel);
                                    if ("1" == $ctl.attr("iscount"))
                                    {
                                        countCols.push(colname);
                                    }
                                    if (subvalidate && $.trim(subvalidate).length > 0)
                                    {
                                        $ctl.attr("validate", subvalidate);
                                    }
                                });
                            }
                        }

                        //计算列合计
                        countCols = countCols.unique();
                        for (var i = 0; i < countCols.length; i++)
                        {
                            formrun.subtableCount(id, countCols[i], null, isReadonly);
                        }
                        //从表里只要有一个字段为只读，则隐藏最后一列添加删除行按钮
                        if (isReadonly)
                        {
                            $("thead tr th:last", $table).remove();
                            $("tbody tr[type1='listtr']", $table).each(function ()
                            {
                                $("td:last", $(this)).remove();
                            });
                            var $counttr = $("tbody tr[type1='counttr'] td", $table);
                            if($counttr.size()>0)
                            {
                                $counttr.attr("colspan",$("thead tr th", $table).size());
                            }
                        }
                        if (json.length > 0)
                        {
                            $("tbody tr[type1='listtr']:first", $table).remove();
                        }
                        //更新序号列
                        if ("1" == $table.attr("data-showindex"))
                        {
                            $("tbody tr[type1='listtr']", $table).each(function (index)
                            {
                                $("label[name='showindex']", $(this)).text((++index).toString());
                            });
                        }
                    }
                });
            }
        });
    },
    initFlowControl: function (type, $control, initValue, validatetype, fieldstatus, displayModel)
    {
        var validate = "";
        var filedshow = 1 == displayModel ? 1 : 0;//字段显示状态
        var filedcheck = 0;//字段检查方式
        if (fieldstatus && fieldstatus.length > 0)
        {
            var fieldstatusArray = fieldstatus.split('_');
            if (fieldstatusArray.length == 2)
            {
                filedshow = parseInt(fieldstatusArray[0]);
                filedcheck = parseInt(fieldstatusArray[1]);
            }
        }
        if (!initValue || $.trim(initValue).length == 0 || initValue.toLowerCase() == "null")
        {
            if (type == "flow_org" || type == "flow_dict" || type == "flow_files" || type == "flow_selectdiv")//某些特定控件取值要值前一个对象的值
            {
                initValue = $control.prev().val();
            }
            else if (type == "flow_checkbox" || type == "flow_radio" || type == "subflow_checkbox" || type == "subflow_radio")
            {
                initValue = $control.prop("checked") ? $control.val() : "";
            }
            else if (type == "flow_label")
            {
                initValue = $control.text();
            }
            else if (type == "flow_signature")
            {
                initValue = "";
            }
            else
            {
                initValue = $control.val();
            }
            if (!initValue || $.trim(initValue).length == 0 || initValue.toLowerCase() == "null")
            {
                initValue = "";
            }
            
        }
        switch (type)
        {
            case "flow_label":
                $control.text(initValue);
                break;
            case "flow_button":
                if (filedshow == 1)
                {
                    $control.prop("disabled", true);
                }
                else if (filedshow == 2)
                {
                    $control.remove();
                }
                break;
            case "flow_hidden":
                if (filedshow == 0)
                {
                    $control.val(initValue);
                }
                else if (filedshow == 1)
                {
                    //$control.after(initValue).remove();
                }
                else if (filedshow == 2)
                {
                    $control.remove();
                }
                if (1 == filedcheck)
                {
                    validate = "canempty," + (validatetype || "empty");
                }
                else if (2 == filedcheck)
                {
                    validate = validatetype || "empty";
                }
                break;
            case "flow_text":
            case "subflow_text":
            case "flow_serialnumber":
                if (filedshow == 0)
                {
                    $control.val(initValue);
                }
                else if (filedshow == 1)
                {
                    $control.after('<span>' + initValue + '</span>').remove();
                }
                else if (filedshow == 2)
                {
                    $control.remove();
                }
                if (1 == filedcheck)
                {
                    validate = "canempty," + (validatetype || "empty");
                }
                else if (2 == filedcheck)
                {
                    validate = validatetype || "empty";
                }
                break;
            case "flow_textarea":
            case "subflow_textarea":
                if (filedshow == 0)
                {
                    $control.val(initValue);
                }
                else if (filedshow == 1)
                {
                    $control.after("<span>" + initValue + "</span>");
                    $control.remove();
                }
                else if (filedshow == 2)
                {
                    $control.remove();
                }
                if (1 == filedcheck)
                {
                    validate = "canempty," + (validatetype || "empty");
                }
                else if (2 == filedcheck)
                {
                    validate = validatetype || "empty";
                }
                break;
            case "flow_html":
                if (filedshow == 0)
                {
                    $control.html(initValue);
                }
                else if (filedshow == 1)
                {
                    $control.after('<span>' + initValue + '</span>').remove();
                }
                else if (filedshow == 2)
                {
                    $control.remove();
                }
                if (1 == filedcheck)
                {
                    validate = "canempty," + (validatetype || "empty");
                }
                else if (2 == filedcheck)
                {
                    validate = validatetype || "empty";
                }
                break;
            case "flow_datetime":
            case "subflow_datetime":
                var value1 = "";
                if (initValue && initValue.trim().length > 0)
                {
                    /*var format = $control.attr("format");
                    if (!format || format.length == 0)
                    {
                        if ("1" == $control.attr("istime"))
                        {
                            value1 = RoadUI.Core.formatDate(initValue, "yyyy-MM-dd hh:mm");
                        }
                        else
                        {
                            value1 = RoadUI.Core.formatDate(initValue, "yyyy-MM-dd");
                        }
                    }
                    else
                    {
                        value1 = RoadUI.Core.formatDate(initValue, format);
                    }*/
                    value1 = initValue;
                }
                if (filedshow == 0)
                {
                    $control.val(value1);
                }
                else if (filedshow == 1)
                {
                    $control.after('<span>' + value1 + '</span>').remove();
                }
                else if (filedshow == 2)
                {
                    $control.remove();
                }
                
                if (1 == filedcheck)
                {
                    validate = "canempty," + (validatetype || "empty");
                }
                else if (2 == filedcheck)
                {
                    validate = validatetype || "empty";
                }
                break;
            case "flow_combox":
                if (filedshow == 0)
                {
                    $control.val(initValue);
                    if (initValue.length > 0)
                    {
                        new RoadUI.Combox().initValue($control.attr('id'), initValue);
                    }
                }
                else if (filedshow == 1)
                {
                    $control.val(initValue);
                    if (initValue.length > 0)
                    {
                        new RoadUI.Combox().initValue($control.attr('id'), initValue);
                    }

                    var text = $control.next().val();
                    $control.before('<span>' + text + '</span>');
                    $control.next().remove();
                    $control.remove();
                }
                else if (filedshow == 2)
                {
                    $control.next().remove();
                    $control.remove();
                }

                if (1 == filedcheck)
                {
                    validate = "canempty,empty";
                }
                else if (2 == filedcheck)
                {
                    validate = "empty";
                }
                break;
            case "flow_org":
            case "subflow_org":
                if (filedshow == 0)
                {
                    $control.prev().val(initValue);
                    if (initValue.length > 0)
                    {
                        new RoadUI.Member().setValue($control.prev());
                    }
                }
                else if (filedshow == 1)
                {
                    $control.prev().val(initValue);
                    if (initValue.length > 0)
                    {
                        new RoadUI.Member().setValue($control.prev());
                    }
                    $control.prev().remove();
                    $control.next().remove();
                    $control.after('<span>' + $control.val() + '</span>');
                    $control.remove();
                }
                else if (filedshow == 2)
                {
                    $control.prev().remove();
                    $control.next().remove();
                    $control.remove();
                }
                
                if (1 == filedcheck)
                {
                    validate = "canempty,empty";
                }
                else if (2 == filedcheck)
                {
                    validate = "empty";
                }
                break;
            case "flow_dict":
            case "subflow_dict":
                if (filedshow == 0)
                {
                    $control.prev().val(initValue);
                    new RoadUI.Dict().setValue($control.prev());
                }
                else if (filedshow == 1)
                {
                    $control.prev().val(initValue);
                    new RoadUI.Dict().setValue($control.prev());
                    $control.prev().remove();
                    $control.next().remove();
                    $control.after('<span>' + $control.val() + '</span>');
                    $control.remove();
                }
                else if (filedshow == 2)
                {
                    $control.prev().remove();
                    $control.next().remove();
                    $control.remove();
                }
                
                if (1 == filedcheck)
                {
                    validate = "canempty,empty";
                }
                else if (2 == filedcheck)
                {
                    validate = "empty";
                }
                break;
            case "flow_radio":
            case "subflow_radio":
                if (filedshow == 0)
                {
                    if (initValue.toLowerCase() == ($control.val() || "").toLowerCase())
                    {
                        $control.prop("checked", true);
                    }
                }
                else if (filedshow == 1)
                {
                    if (initValue == $control.val())
                    {
                        $control.remove();
                    }
                    else
                    {
                        $control.next("label").remove();
                        $control.remove();
                    }
                }
                else if (filedshow == 2)
                {
                    $control.next("label").remove();    
                    $control.remove();
                }
               
                if (1 == filedcheck)
                {
                    validate = "canempty,radio";
                }
                else if (2 == filedcheck)
                {
                    validate = "radio";
                }
                break;
            case "flow_checkbox":
            case "subflow_checkbox":
                if (filedshow == 0)
                {
                    if (("," + initValue.toLowerCase() + ",").indexOf("," + ($control.val() || "").toLowerCase() + ",") != -1)
                    {
                        $control.prop("checked", true);
                    }
                }
                else if (filedshow == 1)
                {
                    if (("," + initValue + ",").indexOf("," + $control.val() + ",") != -1)
                    {
                        $control.next("label").after("&nbsp;&nbsp;");
                        $control.remove();
                    }
                    else
                    {
                        $control.next("label").remove(); 
                        $control.remove();
                    }
                }
                else if (filedshow == 2)
                {
                    $control.next("label").remove(); 
                    $control.remove();
                }
                
                if (1 == filedcheck)
                {
                    validate = "canempty,checkbox";
                }
                else if (2 == filedcheck)
                {
                    validate = "checkbox";
                }
                break;
            case "flow_select":
            case "subflow_select":
                var linkagefield = $control.attr("linkagefield");
                if (linkagefield && linkagefield.length > 0)
                {
                    $control.val(initValue).change();
                }
                if (filedshow == 0)
                {
                    $control.val(initValue);
                }
                else if (filedshow == 1)
                {
                    var $opts = $control.children();
                    var optText = "";
                    for (var i = 0; i < $opts.size() ; i++)
                    {
                        if ($opts.eq(i).val() == initValue)
                        {
                            optText = $opts.eq(i).text();
                            break;
                        }
                    }
                    $control.after(optText);
                    $control.remove();
                }
                else if (filedshow == 2)
                {
                    $control.remove();
                }
                
                if (1 == filedcheck)
                {
                    validate = "canempty,empty";
                }
                else if (2 == filedcheck)
                {
                    validate = "empty";
                }
                break;
            case "flow_selectdiv":
            case "subflow_selectdiv":
                if (filedshow == 0)
                {
                    $control.prev().val(initValue);
                    new RoadUI.SelectDiv().setValue($control.prev());
                }
                else if (filedshow == 1)
                {
                    $control.prev().val(initValue);
                    new RoadUI.SelectDiv().setValue($control.prev());
                    $control.prev().remove();
                    $control.next().remove();
                    $control.after('<span>' + $control.val() + '</span>');
                    $control.remove();
                }
                else if (filedshow == 2)
                {
                    $control.prev().remove();
                    $control.next().remove();
                    $control.remove();
                }

                if (1 == filedcheck)
                {
                    validate = "canempty,empty";
                }
                else if (2 == filedcheck)
                {
                    validate = "empty";
                }
                break;
            case "flow_files":
            case "subflow_files":
                if (filedshow == 0)
                {
                    if ($.trim(initValue).length > 0)
                    {
                        $control.val('共' + initValue.split('|').length + '个文件');
                    }
                    $control.prev().val(initValue);
                }
                else if (filedshow == 1)
                {
                    var links = '';
                    if ($.trim(initValue).length > 0)
                    {
                        $.ajax({
                            url: RoadUI.Core.rooturl() + "/Files/GetShowString", data: { "files": initValue }, type: "post", success: function (links)
                            {
                                $control.next().remove();
                                $control.prev().remove();
                                $control.after(links);
                                $control.remove();
                            }
                        });
                        //var filesArray = initValue.split('|');
                        //for (var i = 0; i < filesArray.length; i++)
                        //{
                        //    var extName = (filesArray[i].substr(filesArray[i].lastIndexOf('.') + 1) || "").toLowerCase();
                        //    if ("jpg" == extName || "png" == extName || "gif" == extName)
                        //    {
                        //        links += '<span style="margin-right:5px;"><img src="' + filesArray[i] + '" /></sapn>';
                        //    }
                        //    else
                        //    {
                        //        links += '<span style="margin-right:5px;"><a target="_blank" href="' + filesArray[i] + '" class="blue">' + filesArray[i].substr(filesArray[i].lastIndexOf('/') + 1) + '</a></sapn>';
                        //    }
                        //}
                    }
                    else
                    {
                        links = "无";
                        $control.next().remove();
                        $control.prev().remove();
                        $control.after(links);
                        $control.remove();
                    }
                }
                else if (filedshow == 2)
                {
                    $control.prev().remove();
                    $control.next().remove();
                    $control.remove();
                }
                
                if (1 == filedcheck)
                {
                    validate = "canempty,empty";
                }
                else if (2 == filedcheck)
                {
                    validate = "empty";
                }
                    
                break;
            case "flow_signature":
                if (filedshow == 0)
                {
                    if (initValue && initValue.length > 0)
                    {
                        var id1 = $control.attr("id1");
                        $control.after('<span><img style="vertical-align:middle;margin-left:10px;" src="' + initValue + '" border="0" /><input type="hidden" name="' + id1 + '" value="' + initValue + '"/></span>');
                    }
                }
                else if (filedshow == 1)
                {
                    if (initValue && initValue.length > 0)
                    {
                        var id1 = $control.attr("id1");
                        $control.after('<span><img style="vertical-align:middle;" src="' + initValue + '" border="0" /></span>');
                        $control.remove();
                    }
                    else
                    {
                        $control.remove();
                    }
                }
                else if (filedshow == 2)
                {
                    $control.remove();
                }

                if (1 == filedcheck)
                {
                    validate = "signature";
                }
                else if (2 == filedcheck)
                {
                    validate = "signature";
                }
                break;
        }
        return validate;
    },
    subtableNewRow: function (but, pkValue, isAppend, isLoad)//pkValue：主键值 isAppend 0：为在当前行后增加 1：为在最后一行增加 isLoad:是否为二次加载
    {
        var $tr = $(but).parent().parent();
        var $table = $tr.parent().parent();
        var $newtr = $tr.clone();
        var guid = pkValue || RoadUI.Core.newid(false);
        var id = $("input[name='flowsubid']", $tr).val();
        $("[type1='subflow_text']", $newtr).each(function ()
        {
            var colname = $(this).attr("colname");
            $(this).attr("name", id + "_" + guid + "_" + colname).attr("id", id + "_" + guid + "_" + colname).val("");
        });
        $("[type1='subflow_textarea']", $newtr).each(function ()
        {
            var colname = $(this).attr("colname");
            $(this).attr("name", id + "_" + guid + "_" + colname).attr("id", id + "_" + guid + "_" + colname).val($(this).attr("defaultvalue"));
        });
        $("[type1='subflow_select']", $newtr).each(function ()
        {
            $this = $(this);
            var colname = $this.attr("colname");
            $this.attr("name", id + "_" + guid + "_" + colname).attr("id", id + "_" + guid + "_" + colname).val("");
            var linkagefieldcolname = $this.attr("linkagefieldcolname");
            if (linkagefieldcolname && linkagefieldcolname.length > 0)
            {
                $this.attr("linkagefield", id + "_" + guid + "_" + linkagefieldcolname);
            }
            if ($this.parent().parent().find("[linkagefieldcolname='" + $this.attr("colname") + "']").size() > 0)
            {
                $this.html('');
            }
        });
        $("[type1='subflow_checkbox']", $newtr).each(function ()
        {
            var colname = $(this).attr("colname");
            $(this).attr("name", id + "_" + guid + "_" + colname).attr("id", id + "_" + guid + "_" + colname).prop("checked", false);
        });
        $("[type1='subflow_radio']", $newtr).each(function ()
        {
            var colname = $(this).attr("colname");
            $(this).attr("name", id + "_" + guid + "_" + colname).attr("id", id + "_" + guid + "_" + colname).prop("checked", false);
        });
        $("[type1='subflow_datetime']", $newtr).each(function ()
        {
            var colname = $(this).attr("colname");
            $(this).attr("name", id + "_" + guid + "_" + colname).attr("id", id + "_" + guid + "_" + colname).val("");
            new RoadUI.Calendar().init($(this));
        });
        $("[type1='subflow_dict']", $newtr).each(function ()
        {
            $(this).prev().remove();
            $(this).next().remove();
            $(this).removeClass().addClass("mydict");
            var colname = $(this).attr("colname");
            $(this).attr("name", id + "_" + guid + "_" + colname).attr("id", id + "_" + guid + "_" + colname).val("");
            new RoadUI.Dict().init($(this));
        });
        $("[type1='subflow_org']", $newtr).each(function ()
        {
            var colname = $(this).attr("colname");
            $(this).attr("name", id + "_" + guid + "_" + colname).attr("id", id + "_" + guid + "_" + colname).val("");
            $(this).prev().remove();
            $(this).next().remove();
            $(this).removeClass().addClass("mymember");
            new RoadUI.Member().init($(this));
        });

        $("[type1='subflow_files']", $newtr).each(function ()
        {
            var colname = $(this).attr("colname");
            $(this).attr("name", id + "_" + guid + "_" + colname).attr("id", id + "_" + guid + "_" + colname).attr("value1", "").val("");
            $(this).prev().remove();
            $(this).next().remove();
            $(this).removeClass().addClass("myfile");
            new RoadUI.File().init($(this));
        });
        $("input[name^='hidden_guid_']", $newtr).val(guid);
        new RoadUI.Text().init($(".mytext", $newtr));
        new RoadUI.Button().init($("input[type='button']", $newtr));
        
        if (1 == isAppend)
        {
            $("tr[type1='listtr']:last", $table).after($newtr);
        }
        else
        {
            $tr.after($newtr);
        }
        //更新序号列
        if ("1" == $table.attr("data-showindex"))
        {
            $("tbody tr[type1='listtr']", $table).each(function (index)
            {
                $("label[name='showindex']", $(this)).text((++index).toString());
            });
        }
        return $newtr;
    },
    subtableDeleteRow: function (but)
    {
        var $table = $(but).parent().parent().parent().parent();
        var $tr = $(but).parent().parent();
        var $tds = $("td[iscount='1']", $tr);
        if ($("tbody tr[type1='listtr']", $table).size() > 1)
        {
            $tr.remove();
        }
        //重新计算合计
        if ($tds.size() > 0)
        {
            var id = $("input[name='flowsubtable_id']", $table).val();
            for (var i = 0; i < $tds.size() ; i++)
            {
                formrun.subtableCount(id, $tds.eq(i).attr("colname"));
            }
        }
        //更新序号列
        if ("1" == $table.attr("data-showindex"))
        {
            $("tbody tr[type1='listtr']", $table).each(function (index)
            {
                $("label[name='showindex']", $(this)).text((++index).toString());
            });
        }
    },
    subtableCount: function (id, colname, showid, isReadonly)//从表计算合计 id:从表ID, colname:列, showid：显示合计值的label id, isReadonly:是否为只读状态
    {
        var $table = $("#subtable_" + id);
        var $tds = $("tbody td[colname='" + colname + "']", $table);
        var count = 0;
        for (var i = 0; i < $tds.size() ; i++)
        {
            var val = isReadonly ? $.trim($tds.eq(i).find('span').text()) : $("input[type1='subflow_text']", $tds.eq(i)).val();
            if (val && !isNaN(val))
            {
                count = RoadUI.Core.accAdd(count, parseFloat(val));
            }
        }
        showid = showid || "countspan_" + id + "_" + colname;
        $("#" + showid).text(count);
    }
};
