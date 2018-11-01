UE.compule = {
    getDefaultValue: function (defaultValue)
    {
        return RoadUI.Core.decodeUri(defaultValue);
    },
    getEventScript: function ($control)
    {
        var eventsid = $control.attr("eventsid");
        $control.removeAttr("eventsid");
        if (!eventsid || $.trim(eventsid).length == 0)
        {
            return;
        }
        var events = getEvents(eventsid);
        if (!$.isArray(events))
        {
            return;
        }
        var script = '';
        for (var i = 0; i < events.length; i++)
        {
            if (!events[i].name || $.trim(events[i].name).length == 0 || !events[i].script || $.trim(events[i].script).length == 0)
            {
                continue;
            }
            var functionName = events[i].name + "_" + eventsid;
            var cng = $control.attr(events[i].name) || "";
            if (cng.indexOf(functionName + " (this);") == -1)
            {
                $control.attr(events[i].name, (cng.length > 0 ? cng + ';' : '') + functionName + " (this);");
            }

            script += '<script type="text/javascript">function ' + functionName + '(srcObj){' + events[i].script + '}</script>';
        }
        $control.after(script)
    },
    getEventScriptString: function (eventsid)
    {
        var json = { attr: "", script: "" };
        if (!eventsid || $.trim(eventsid).length == 0)
        {
            return json;
        }
        var events = getEvents(eventsid);
        if (!$.isArray(events))
        {
            return json;
        }
        var attr = "", scripts = "";
        for (var i = 0; i < events.length; i++)
        {
            if (!events[i].name || $.trim(events[i].name).length == 0 || !events[i].script || $.trim(events[i].script).length == 0)
            {
                continue;
            }
            var functionName = events[i].name + "_" + eventsid;
            attr += ' ' + events[i].name + '=\'' + functionName + '(this);\''
            scripts += ' <script type="text/javascript">function ' + functionName + '(srcObj){' + events[i].script + '}</script>';
        }
        json.attr = attr;
        json.script = scripts;
        return json;
    },
    getTextHtml: function ($control)
    {
        $control.attr("isflow", "1").attr("value", "").attr("class", "mytext").attr("title", "");
        var defaultValue = $control.attr("defaultvalue");
        $control.attr("value", UE.compule.getDefaultValue(defaultValue));
        UE.compule.getEventScript($control);
        $control.removeAttr("defaultvalue").removeAttr("ondblclick").removeAttr("width1");
    },
    getSumTextHtml: function ($control)
    {
        $control.attr("isflow", "1").attr("value", "").attr("class", "mytext").attr("title", "");
        var defaultValue = $control.attr("defaultvalue");
        $control.attr("value", UE.compule.getDefaultValue(defaultValue));

        UE.compule.getEventScript($control);
        var id = $control.attr("id");
        var tofixed = $control.attr("tofixed");
        var sumstr = $control.attr("sumstr") && $control.attr("sumstr").length > 0 ? JSON.parse($control.attr("sumstr")) : [];
        if (sumstr.length > 0)
        {
            var js = '';
            js += '<span><script type="text\/javascript">';
            js += 'function sum_' + id.replace('.', '_') + '()';
            js += '{';
            var js1 = '';
            var elements = $("[type1]", dialog.editor.document);
            
            for (var i = 0; i < sumstr.length; i++)
            {
                var json = sumstr[i];
                var field = json.field;
                var sum = json.sum;
                var leftkh = json.leftkh;
                var rightkh = json.rightkh;

                if (!field || field.length == 0)
                {
                    continue;
                }
                js1 += leftkh + 'parseFloat($("#' + field.replace('.', '\\\\.') + '").val()||"0")' + rightkh + sum;

                for (var j = 0; j < elements.size() ; j++)
                {
                    if (elements.eq(j).attr("id") == field)
                    {
                        var cng = elements.eq(j).attr("onchange") || "";
                        if (cng.indexOf('sum_' + id.replace('.', '_') + '();') == -1)
                        {
                            elements.eq(j).attr('onchange', (cng.length > 0 ? cng + ';' : '') + 'sum_' + id.replace('.', '_') + '();');
                        }
                    }
                }
            }
            js += '$("#' + id.replace('.', '\\\\.') + '").val(parseFloat(eval(' + js1 + ') || "0")' + (tofixed ? '.toFixed(' + tofixed + ')' : '') + ');';
            js += '$("#' + id.replace('.', '\\\\.') + '").change();';
            js += '}';
            js += "<\/script></span>";  
            $control.after(js);
        }
        $control.removeAttr("defaultvalue").removeAttr("ondblclick").removeAttr("width1").removeAttr("sumstr").removeAttr("tofixed");
        $control.attr("type1", "flow_text");
    },
    getTextareaHtml: function ($control)
    {
        var id = $control.attr("id");
        var maxlength = $control.attr("maxlength");
        var defaultValue = $control.attr("defaultvalue");
        var defaultValue1 = UE.compule.getDefaultValue(defaultValue);
        var placeholder = $control.attr('placeholder') || '';
        var textarea = '<textarea isflow="1" type1="flow_textarea" id="' + id + '" name="' + id + '" class="mytext" ';
        textarea += 'style="' + $control.attr("style") + '"';
        if (maxlength)
        {
            textarea += ' maxlength="' + maxlength + '" ';
        }
        if (placeholder)
        {
            textarea += ' placeholder="' + placeholder.replace('"', '') + '" ';
        }
        textarea += '>';
        if (defaultValue1)
        {
            textarea += defaultValue1;
        }
        textarea += '</textarea>';
        $textarea = $(textarea);
        $textarea.attr("eventsid", $control.attr("eventsid"));
        $control.after($textarea);
        UE.compule.getEventScript($textarea);
        $control.remove();

    },
    getRadioOrCheckboxHtml: function ($control, type)
    {
        $control.attr("isflow", "1");
        var id = $control.attr("id");
        var datasource = $control.attr("datasource");
        var eventsid = $control.attr("eventsid");
        var eventsJson = { attr: "", script: "" };
        var eventArrs = "", eventScripts = "";
        var defaultvalue = $.trim($control.attr("defaultvalue") || "");
        if (eventsid)
        {
            eventsJson = UE.compule.getEventScriptString(eventsid);
            eventArrs = eventsJson.attr;
            eventScripts = eventsJson.script;
        }
        if ("0" == datasource)//数据字典
        {
            var dictid = $control.attr("dictid");
            var radios = '';

            if ('radio' == type)
            {
                radios = '<span>@Html.Raw(BDictionary.GetRadiosByID("' + dictid + '".ToGuid(), "' + id + '", RoadFlow.Platform.Dictionary.OptionValueField.ID, "' + defaultvalue + '", "isflow=\'1\' type1=\'flow_radio\'' + eventArrs + '"))' + eventScripts + '</span>';
            }
            else if ('checkbox' == type)
            {
                radios = '<span>@Html.Raw(BDictionary.GetCheckboxsByID("' + dictid + '".ToGuid(), "' + id + '", RoadFlow.Platform.Dictionary.OptionValueField.ID, "' + defaultvalue + '", "isflow=\'1\' type1=\'flow_checkbox\'' + eventArrs + '"))' + eventScripts + '</span>';
            }

            $control.after(radios);
            $control.remove();
        }
        else if ("1" == datasource)//自定义
        {
            var customopts = {};
            try
            {
                customopts = JSON.parse($control.attr("customopts"));
            }
            catch (e) { alert($control.attr("id") + " 自定义选项错误!"); }

            var radios = '';
            for (var i = 0; i < customopts.length; i++)
            {
                var title = customopts[i].title;
                var value = customopts[i].value;
                if (!title || !value)
                {
                    continue;
                }
                radios += '<input type="' + type + '" name="' + id + '" id="' + id + '_' + i.toString() + '" value="' + $.trim(value) + '" ' + (defaultvalue == $.trim(value) ? 'checked="checked"' : '') + ' style="vertical-align:middle;" isflow="1" type1="flow_' + type + '"' + eventArrs + '/>';
                radios += '<label for="' + id + '_' + i.toString() + '" style="vertical-align:middle;margin-right:3px;">' + $.trim(title) + '</label>';
            }
            radios += eventScripts;
            $control.after(radios);
            $control.remove();
        }
        else if ("2" == datasource)//SQL
        {
            var dbconn = $control.attr("dbconn");
            var sql = $control.attr("sql");
            var radios = '';
            if ("radio" == type)
            {
                radios += '<span>@Html.Raw(new RoadFlow.Platform.WorkFlowForm().GetRadioFromSql("' + dbconn + '", "' + sql.replaceAll('"', '\"') + '", "' + id + '", "' + defaultvalue + '", "isflow=\'1\' type1=\'flow_radio\'' + eventArrs + '"))' + eventScripts + '</span>';
            }
            else if ("checkbox" == type)
            {
                radios += '<span>@Html.Raw(new RoadFlow.Platform.WorkFlowForm().GetCheckboxFromSql("' + dbconn + '", "' + sql.replaceAll('"', '\"') + '", "' + id + '", "' + defaultvalue + '", "isflow=\'1\' type1=\'flow_checkbox\'' + eventArrs + '"))' + eventScripts + '</span>';
            }
            $control.after(radios);
            $control.remove();
        }
    },
    getSelectHtml: function ($control)
    {
        $control.attr("isflow", "1");
        var id = $control.attr("id");
        var datasource = $control.attr("datasource");
        var width1 = $control.attr("width1");
        var defaultvalue = $.trim($control.attr("defaultvalue") || "");
        var hasempty = $control.attr("hasempty");
        var linkagefield = $control.attr("linkagefield");
        var linkagesource = $control.attr("linkagesource");
        var linkagesourcetext = $control.attr("linkagesourcetext");
        var linkagesourceconn = $control.attr("linkagesourceconn");

        var radios = '<select class="myselect" id="' + id + '" name="' + id + '" ' + (width1 ? 'style="width:' + width1 + '"' : '') + ' isflow="1" type1="flow_select"';
        if (linkagefield && linkagefield.length > 0)//设置了联动
        {
            radios += ' linkagefield="' + linkagefield + '"';
            radios += ' linkagesource="' + linkagesource + '"';
            radios += ' linkagesourcetext="' + linkagesourcetext + '"';
            radios += ' linkagesourceconn="' + linkagesourceconn + '"';
            radios += ' onchange="RoadUI.Core.loadOptions(this);"';
        }
        radios += '>';
        if ("0" == datasource)//数据字典
        {
            var dictid = $control.attr("dictid");
            var ischild = $control.attr("ischild");
            var valuefiled = $control.attr("valuefiled") || "RoadFlow.Platform.Dictionary.OptionValueField.ID";
            if ("1" == hasempty)
            {
                radios += '<option value=""></option>';
            }
            radios += '@Html.Raw(BDictionary.GetOptionsByID("' + dictid + '".ToGuid(), ' + valuefiled + ', "' + defaultvalue + '", ' + ("1" == ischild ? 'true' : 'false') + '))';
            radios += '</select>';
            var $radios = $(radios);
            $radios.attr("eventsid", $control.attr("eventsid"));
            $control.after($radios);
            UE.compule.getEventScript($radios);
            $control.remove();
        }
        else if ("1" == datasource)//自定义
        {
            var customopts = {};
            try
            {
                customopts = JSON.parse($control.attr("customopts"));
            }
            catch (e) { alert($control.attr("id") + " 自定义选项错误!"); }

            //var radios = '<select class="myselect" id="' + id + '" name="' + id + '" ' + (width1 ? 'style="width:' + width1 + '"' : '') + ' isflow="1" type1="flow_select">';
            if ("1" == hasempty)
            {
                radios += '<option value=""></option>';
            }
            for (var i = 0; i < customopts.length; i++)
            {
                var title = customopts[i].title;
                var value = customopts[i].value;
                if (!title || !value)
                {
                    continue;
                }
                radios += '<option value="' + value + '" ' + (defaultvalue == $.trim(value) ? 'selected="selected"' : '') + '>' + title + '</option>';
            }
            radios += '</select>';
            var $radios = $(radios);
            $radios.attr("eventsid", $control.attr("eventsid"));
            $control.after($radios);
            UE.compule.getEventScript($radios);
            $control.remove();
        }
        else if ("2" == datasource)//SQL
        {
            var dbconn = $control.attr("dbconn");
            var sql = $control.attr("sql");
            //var radios = '<select class="myselect" id="' + id + '" name="' + id + '" ' + (width1 ? 'style="width:' + width1 + '"' : '') + ' isflow="1" type1="flow_select">';
            if ("1" == hasempty)
            {
                radios += '<option value=""></option>';
            }
            radios += '@Html.Raw(new RoadFlow.Platform.WorkFlowForm().GetOptionsFromSql("' + dbconn + '", "' + sql.replaceAll('"', '\"') + '", "' + defaultvalue + '"))';
            radios += '</select>';
            var $radios = $(radios);
            $radios.attr("eventsid", $control.attr("eventsid"));
            $control.after($radios);
            UE.compule.getEventScript($radios);
            $control.remove();
        }
    },
    getComboxHtml: function ($control)
    {
        $control.attr("isflow", "1");
        var id = $control.attr("id");
        var datasource = $control.attr("datasource");
        var width1 = $control.attr("width1");
        var width2 = $control.attr("width2");
        var height1 = $control.attr("height1") || "";
        var defaultvalue = $.trim($control.attr("defaultvalue") || "") || $.trim($control.attr("defaultvalue1") || "");
        var hasempty = "0";
        var listmode = $control.attr("listmode") || "0";
        var ismultiple = $control.attr("ismultiple") || "0";

        if ("0" == datasource)//数据字典
        {
            if ("1" != listmode)
            {
                var dictid = $control.attr("dictid");
                var radios = '<select class="mycombox" id="' + id + '" name="' + id + '" ' + ("1" == ismultiple ? ' more="1"' : '') + (width1 ? ' style="width:' + width1 + '"' : '') + (width2 ? 'width1="' + width2 + '"' : '') + (height1 ? 'height1="' + height1 + '"' : '') + ' datasource="' + datasource + '" listmode="' + listmode + '" isflow="1" type1="flow_combox">';
                if ("1" == hasempty)
                {
                    radios += '<option value=""></option>';
                }
                radios += '@Html.Raw(BDictionary.GetOptionsByID("' + dictid + '".ToGuid(), RoadFlow.Platform.Dictionary.OptionValueField.ID, "' + defaultvalue + '"))';
                radios += '</select>';
                var $radios = $(radios);
                $radios.attr("eventsid", $control.attr("eventsid"));
                $control.after($radios);
                UE.compule.getEventScript($radios);
                $control.remove();
            }
            else
            {
                var dictid = $control.attr("dictid");
                var table = '<span class="mycombox" id="' + id + '" name="' + id + '" ' + (width1 ? 'style="width:' + width1 + '"' : '') + (width2 ? 'width1="' + width2 + '"' : '') + (height1 ? 'height1="' + height1 + '"' : '') + ' datasource="' + datasource + '" listmode="' + listmode + '" isflow="1" type1="flow_combox"';
                table += "1" == ismultiple ? ' more="1"' : '';
                table += '>';
                table += '@Html.Raw(BDictionary.GetComboxTableHtmlByID("' + dictid + '",RoadFlow.Platform.Dictionary.OptionValueField.ID,"' + defaultvalue + '"))';
                table += '</span>';
                var $table = $(table);
                $table.attr("eventsid", $control.attr("eventsid"));
                $control.after($table);
                UE.compule.getEventScript($table);
                $control.remove();
            }
        }
        else if ("1" == datasource)//自定义
        {
            var customopts = {};
            try
            {
                customopts = JSON.parse($control.attr("customopts"));
            }
            catch (e) { alert($control.attr("id") + " 自定义选项错误!"); }

            var radios = '<select class="mycombox" id="' + id + '" name="' + id + '" ' + ("1" == ismultiple ? ' more="1"' : '') + (width1 ? 'style="width:' + width1 + '"' : '') + (width2 ? 'width1="' + width2 + '"' : '') + (height1 ? 'height1="' + height1 + '"' : '') + ' datasource="' + datasource + '" listmode="' + listmode + '" isflow="1" type1="flow_combox">';
            if ("1" == hasempty)
            {
                radios += '<option value=""></option>';
            }
            for (var i = 0; i < customopts.length; i++)
            {
                var title = customopts[i].title;
                var value = customopts[i].value;
                if (!title || !value)
                {
                    continue;
                }
                radios += '<option value="' + value + '" ' + (defaultvalue == $.trim(value) ? 'selected="selected"' : '') + '>' + title + '</option>';
            }
            radios += '</select>';
            var $radios = $(radios);
            $radios.attr("eventsid", $control.attr("eventsid"));
            $control.after($radios);
            UE.compule.getEventScript($radios);
            $control.remove();
        }
        else if ("2" == datasource)//SQL
        {
            if ("1" != listmode)
            {
                var dbconn = $control.attr("dbconn");
                var sql = $control.attr("sql");
                var radios = '<select class="mycombox" id="' + id + '" name="' + id + '" ' + ("1" == ismultiple ? ' more="1"' : '') + (width1 ? 'style="width:' + width1 + '"' : '') + (width2 ? 'width1="' + width2 + '"' : '') + (height1 ? 'height1="' + height1 + '"' : '') + ' datasource="' + datasource + '" listmode="' + listmode + '" isflow="1" type1="flow_combox">';
                if ("1" == hasempty)
                {
                    radios += '<option value=""></option>';
                }
                radios += '@Html.Raw(new RoadFlow.Platform.WorkFlowForm().GetOptionsFromSql("' + dbconn + '", "' + sql.replaceAll('"', '\"') + '", "' + defaultvalue + '"))';
                radios += '</select>';
                var $radios = $(radios);
                $radios.attr("eventsid", $control.attr("eventsid"));
                $control.after($radios);
                UE.compule.getEventScript($radios);
                $control.remove();
            }
            else
            {
                var dbconn = $control.attr("dbconn");
                var sql = $control.attr("sql");
                var table = '<span class="mycombox" id="' + id + '" name="' + id + '" ' + (width1 ? 'style="width:' + width1 + '"' : '') + (width2 ? 'width1="' + width2 + '"' : '') + (height1 ? 'height1="' + height1 + '"' : '') + ' datasource="' + datasource + '" listmode="' + listmode + '" isflow="1" type1="flow_combox"';
                table += "1" == ismultiple ? ' more="1"' : '';
                table += '>';
                table += '@Html.Raw(new RoadFlow.Platform.WorkFlowForm().GetComboxTableHtmlFromSql("' + dbconn + '", "' + sql.replaceAll('"', '\"') + '", "' + defaultvalue + '"))';
                table += '</span>';
                var $table = $(table);
                $table.attr("eventsid", $control.attr("eventsid"));
                $control.after($table);
                UE.compule.getEventScript($table);
                $control.remove();
            }
        }
        else if ("3" == datasource)//URL
        {
            if ("1" != listmode)
            {
                var url = $control.attr("url");
                var radios = '<select class="mycombox" id="' + id + '" name="' + id + '" ' + ("1" == ismultiple ? ' more="1"' : '') + (width1 ? 'style="width:' + width1 + '"' : '') + (width2 ? 'width1="' + width2 + '"' : '') + (height1 ? 'height1="' + height1 + '"' : '') + ' datasource="' + datasource + '" listmode="' + listmode + '" isflow="1" type1="flow_combox">';
                if ("1" == hasempty)
                {
                    radios += '<option value=""></option>';
                }
                radios += '@Html.Raw(new RoadFlow.Platform.WorkFlowForm().GetOptionsFromUrl("' + encodeURIComponent(url) + '", "' + defaultvalue + '"))';
                radios += '</select>';
                var $radios = $(radios);
                $radios.attr("eventsid", $control.attr("eventsid"));
                $control.after($radios);
                UE.compule.getEventScript($radios);
                $control.remove();
            }
            else
            {
                var url = $control.attr("url");
                var cols = ($control.attr("cols") || "").split(',');
                var gettextsurl = $control.attr("gettextsurl");
                var queryfield = $control.attr("queryfield");
                var table = '<span class="mycombox" id="' + id + '" name="' + id + '" ' + (width1 ? 'style="width:' + width1 + '"' : '') + (width2 ? 'width1="' + width2 + '"' : '') + (height1 ? 'height1="' + height1 + '"' : '') + ' datasource="' + datasource + '" listmode="' + listmode + '" isflow="1" type1="flow_combox"';
                table += "1" == ismultiple ? ' more="1"' : '';
                table += '>';
                if (queryfield)
                {

                    var queryfieldArray = queryfield.split(';');
                    table += '<div class="querybar">';
                    for (var i = 0; i < queryfieldArray.length; i++)
                    {
                        var q = queryfieldArray[i].split(',');
                        var title = "";
                        var field = "";
                        if (q.length > 0)
                        {
                            field = q[0];
                            title = field;
                        }
                        if (q.length > 1)
                        {
                            title = q[1];
                        }
                        if (title && field)
                        {
                            table += title + '：<input type="text" id="' + field + '" name="' + field + '" class="mytext" />';
                        }
                    }
                    table += '<input style="margin-left:6px;" type="button" value=" 查询 " class="mybutton"/></div>';
                }
                table += '<table dataurl="' + url + '" gettextsurl="' + gettextsurl + '" query=""><thead><tr>';
                for (var i = 0; i < cols.length; i++)
                {
                    table += '<th>' + cols[i] + '</th>';
                }
                table += '</tr></thead><tbody></tbody></table>';
                table += '</span>';
                var $table = $(table);
                $table.attr("eventsid", $control.attr("eventsid"));
                $control.after($table);
                UE.compule.getEventScript($table);
                $control.remove();
            }
        }
    },
    getOrgHtml: function ($control)
    {
        $control.attr("isflow", "1").attr("value", "").attr("class", "mymember").attr("title", "");;
        var defaultValue = $control.attr("defaultvalue");
        $control.attr("value", UE.compule.getDefaultValue(defaultValue));
        var org_type = $control.attr("org_type");
        if (org_type)
        {
            $control.attr("dept", org_type.indexOf(",0,") >= 0 ? "1" : "0");
            $control.attr("station", org_type.indexOf(",1,") >= 0 ? "1" : "0");
            $control.attr("user", org_type.indexOf(",2,") >= 0 ? "1" : "0");
            $control.attr("workgroup", org_type.indexOf(",3,") >= 0 ? "1" : "0");
            $control.attr("unit", org_type.indexOf(",4,") >= 0 ? "1" : "0");
        }
        var org_rang = $control.attr("org_rang");
        var rootid = '';
        switch (org_rang)
        {
            case "0": //发起者部门
                rootid = '@BWorkFlowTask.GetFirstSnderDeptID(FlowID.ToGuid(), GroupID.ToGuid())';
                break;
            case "1": //处理者部门
                rootid = '@RoadFlow.Platform.Users.CurrentDeptID';
                break;
            case "2": //自定义
                rootid = $control.attr("org_rang1");
                break;
        }
        $control.attr("rootid", rootid).removeAttr("defaultvalue").removeAttr("width1").removeAttr("ondblclick").removeAttr("org_type").removeAttr("org_rang1").removeAttr("org_rang");
    },
    getDictHtml: function ($control)
    {
        var ismore = $control.attr("ismore");
        var isroot = $control.attr("isroot");
        var isparent = $control.attr("isparent");

        var datasource = $control.attr("datasource") || "";
        switch (datasource)
        {
            case "0": //数据字典
                var ds_dict_value = $control.attr("ds_dict_value");
                var ds_dict_allchild = $control.attr("ds_dict_allchild");
                $control.attr("class", "mylrselect").attr("title", "").attr("rootid", ds_dict_value).attr("ischild", ds_dict_allchild).attr("isparent", isparent);
                $control.attr("isroot", isroot).attr("ismore", ismore);
                $control.removeAttr("listtype").removeAttr("listtype").removeAttr("ds_dict_allchild");
                $control.removeAttr("ds_dict_value").removeAttr("ds_sql_dbconn").removeAttr("ds_sql_value").removeAttr("ds_url_value0");
                $control.removeAttr("ds_url_value1").removeAttr("ds_table_conn").removeAttr("ds_table_table").removeAttr("ds_table_valuefield");
                $control.removeAttr("ds_table_titlefield").removeAttr("ds_table_parentfield").removeAttr("ds_table_where");
                break;
            case "1": //SQL
                var ds_sql_dbconn = $control.attr("ds_sql_dbconn");
                var ds_sql_value = $control.attr("ds_sql_value");
                $control.attr("class", "mylrselect").attr("title", "").attr("dbconn", ds_sql_dbconn).attr("sql", ds_sql_value);
                $control.attr("isroot", isroot).attr("ismore", ismore).attr("isparent", isparent);
                $control.removeAttr("listtype").removeAttr("listtype").removeAttr("ds_dict_allchild");
                $control.removeAttr("ds_dict_value").removeAttr("ds_sql_dbconn").removeAttr("ds_sql_value").removeAttr("ds_url_value0");
                $control.removeAttr("ds_url_value1").removeAttr("ds_table_conn").removeAttr("ds_table_table").removeAttr("ds_table_valuefield");
                $control.removeAttr("ds_table_titlefield").removeAttr("ds_table_parentfield").removeAttr("ds_table_where");
                break;
            case "2": //URL
                var ds_url_value0 = $control.attr("ds_url_value0");
                var ds_url_value1 = $control.attr("ds_url_value1");
                var ds_url_gettitle = $control.attr("ds_url_gettitle");
                $control.attr("class", "mylrselect").attr("title", "").attr("url0", encodeURIComponent(ds_url_value0)).attr("url1", encodeURIComponent(ds_url_value1)).attr("url2", encodeURIComponent(ds_url_gettitle));
                $control.attr("isroot", isroot).attr("ismore", ismore).attr("isparent", isparent);
                $control.removeAttr("listtype").removeAttr("listtype").removeAttr("ds_dict_allchild");
                $control.removeAttr("ds_dict_value").removeAttr("ds_sql_dbconn").removeAttr("ds_sql_value").removeAttr("ds_url_value0");
                $control.removeAttr("ds_url_value1").removeAttr("ds_table_conn").removeAttr("ds_table_table").removeAttr("ds_table_valuefield");
                $control.removeAttr("ds_table_titlefield").removeAttr("ds_table_parentfield").removeAttr("ds_table_where");
                break;
            case "3": //表
                var ds_table_conn = $control.attr("ds_table_conn");
                var ds_table_table = $control.attr("ds_table_table");
                var ds_table_valuefield = $control.attr("ds_table_valuefield");
                var ds_table_titlefield = $control.attr("ds_table_titlefield");
                var ds_table_parentfield = $control.attr("ds_table_parentfield");
                var ds_table_where = $control.attr("ds_table_where");
                $control.attr("class", "mylrselect").attr("title", "").attr("dbconn", ds_table_conn).attr("dbtable", ds_table_table).attr("valuefield", ds_table_valuefield);
                $control.attr("titlefield", ds_table_titlefield).attr("parentfield", ds_table_parentfield).attr("where", encodeURIComponent(ds_table_where));
                $control.attr("isroot", isroot).attr("ismore", ismore).attr("isparent", isparent);
                $control.removeAttr("listtype").removeAttr("listtype").removeAttr("ds_dict_allchild");
                $control.removeAttr("ds_dict_value").removeAttr("ds_sql_dbconn").removeAttr("ds_sql_value").removeAttr("ds_url_value0");
                $control.removeAttr("ds_url_value1").removeAttr("ds_table_conn").removeAttr("ds_table_table").removeAttr("ds_table_valuefield");
                $control.removeAttr("ds_table_titlefield").removeAttr("ds_table_parentfield").removeAttr("ds_table_where");
                break;
        }
        $control.attr("isflow", "1").attr("value", "");
        $control.removeAttr("width1");
    },
    getDateTimeHtml: function ($control)
    {
        $control.attr("isflow", "1").attr("value", "").attr("class", "mycalendar").attr("title", "");
        var defaultValue = $control.attr("defaultvalue");
        $control.attr("value", UE.compule.getDefaultValue(defaultValue));
        $control.removeAttr("width1").removeAttr("ondblclick");
        UE.compule.getEventScript($control);
    },
    getFilesHtml: function ($control)
    {
        $control.attr("isflow", "1").attr("value", "").attr("class", "myfile").attr("title", "");
        $control.removeAttr("width1").removeAttr("ondblclick");
    },
    getHiddenHtml: function ($control)
    {
        var id = $control.attr("id");
        var defaultValue = $control.attr("defaultvalue");
        var html = '<input type="hidden" id="' + id + '" name="' + id + '" isflow="1" type1="flow_hidden" value="' + UE.compule.getDefaultValue(defaultValue) + '"';
        html += '/>';
        $control.after(html);
        $control.remove();
    },
    getHtmlHtml: function ($control, json)
    {
        formattributeJSON = json || parent.formattributeJSON;
        formattributeJSON.hasEditor = "1";
        var id = $control.attr("id");
        var table = '', field = '';
        var idArray = id.split('.');
        if (idArray.length == 2)
        {
            table = idArray[0];
            field = idArray[1];
        }
        //var maxlength = $control.attr("maxlength");
        var textarea = '<textarea isflow="1" model="html" type1="flow_textarea" id="' + id + '" name="' + id + '" class="mytextarea" ';
        textarea += 'style="' + $control.attr("style") + '"';
        //if (maxlength)
        //{
        //    textarea += ' maxlength="' + maxlength + '" ';
        //}
        textarea += '>';
        textarea += '@Html.Raw(BWorkFlow.GetFromFieldData(initData, "' + table + '","' + field + '"))';
        textarea += '</textarea>';
        $control.after(textarea);
        $control.remove();
    },
    getLabelHtml: function ($control)
    {
        var defaultValue = $control.attr("defaultvalue");
        var label = '<label style="';
        if ($control.attr("fontsize"))
        {
            label += 'font-size:' + $control.attr("fontsize") + ';';
        }
        if ($control.attr("fontcolor"))
        {
            label += 'color:' + $control.attr("fontcolor") + ';';
        }
        if ("1" == $control.attr("fontbold"))
        {
            label += 'font-weight:bold;';
        }
        if ("1" == $control.attr("fontstyle"))
        {
            label += 'font-style:italic;';
        }
        label += '" >';
        label += UE.compule.getDefaultValue(defaultValue);
        label += '</label>';
        $control.after(label);
        $control.remove();
    },
    getGridHtml: function ($control)
    {
        var params = $control.attr("params");
        if (!params || $.trim(params).length == 0)
        {
            params = "";
        }
        var tableid = "tab_" + RoadUI.Core.newid(false);

        var div = '<div style="margin:0 auto;';
        if ($control.attr("width1"))
        {
            div += 'width:' + $control.attr("width1") + ';';
        }
        if ($control.attr("height1"))
        {
            div += 'height:' + $control.attr("height1") + ';';
            div += 'overflow:auto;';
        }
        div += '" ';
        if (tableid)
        {
            div += 'id="' + tableid + '"';
        }
        div += '>';
        div += '<script type="text/javascript">';
        div += 'var params = "' + RoadUI.Core.decodeUri(params) + '";';
        div += '$(function(){$.ajax({url:"../WorkFlowFormDesigner/GetFormGridHtml@(Request.Url.Query)",data:{"dbconnid":"@DBConnID","dataformat":"' + $control.attr("dataformat") + '","datasource":"' + $control.attr("datasource") + '","datasource1":"' + $control.attr("datasource1") + '","params":params},type:"POST",success:function(html){$("#' + tableid + '").html(html);}});});';
        div += '';
        div += '</script>';
        
        $control.after(div);
        $control.remove();
    },
    getButtonHtml: function ($control)
    {
        UE.compule.getEventScript($control);
    },
    getSelectDivHtml: function ($control)
    {
        $control.attr("isflow", "1").attr("value", "").attr("class", "myselectdiv").attr("title", "");
        var defaultValue = $control.attr("defaultvalue");
        $control.attr("value", UE.compule.getDefaultValue(defaultValue));
        UE.compule.getEventScript($control);
        $control.removeAttr("defaultvalue").removeAttr("ondblclick").removeAttr("width1").removeAttr("form_types");
    },
    getSerialNumberHtml: function ($control)
    {
        var id = $control.attr("id");
        var maxfiled = $control.attr("maxfiled");
        $control.attr("isflow", "1").attr("value", "").attr("class", "mytext").attr("title", "");
        $control.prop("readonly", true);
        $control.css("background-color", "#e8e8e8");
        //var defaultValue = $control.attr("defaultvalue");
        //$control.attr("value", UE.compule.getDefaultValue(defaultValue));
        //UE.compule.getEventScript($control);
        $control.after('<input type="hidden" value="' + id + '" name="HasSerialNumber"/><input type="hidden" value="{\'formatstring\':\'' + $control.attr("formatstring") + '\',\'sqlwhere\':\'' + $control.attr("sqlwhere") + '\',\'length\':\'' + $control.attr("length") + '\',\'maxfiled\':\'' + maxfiled + '\'}" name="HasSerialNumberConfig_' + id + '"/>');
        $control.removeAttr("ondblclick").removeAttr("width1").removeAttr("lstype").removeAttr("formatstring").removeAttr("ynfiled").removeAttr("ynfiledvalue");
    },

    getSubTableHtml_Text: function (colnumJSON, id, i, iscount)
    {
        var editmode = colnumJSON.editmode;
        var scripts = editmode.scripts;
        var input = '<input type="text" class="mytext" issubflow="1" type1="subflow_text" ';
        input += 'name="' + id + '_' + i + '_' + colnumJSON.name + '" ';
        input += 'id="' + id + '_' + i + '_' + colnumJSON.name + '" ';
        input += 'colname="' + colnumJSON.name + '" ';
        if (editmode.text_width)
        {
            input += 'style="width:' + editmode.text_width + '" ';
        }
        if (editmode.text_maxlength)
        {
            input += 'maxlength="' + parseInt(editmode.text_maxlength) + '" ';
        }
        input += 'value="' + UE.compule.getDefaultValue(editmode.text_defaultvalue) + '" ';
        if (iscount)
        {
            input += 'iscount="1" onblur="formrun.subtableCount(\'' + id + '\',\'' + colnumJSON.name + '\',\'countspan_' + id + '_' + colnumJSON.name + '\');" ';
        }
        if (editmode.text_valuetype)
        {
            input += 'valuetype="' + editmode.text_valuetype + '" ';
        }
        if (scripts && $.isArray(scripts))
        {
            for (var i = 0; i < scripts.length; i++)
            {
                if (colnumJSON.name == scripts[i].filed && scripts[i].script && scripts[i].script.length > 0)
                {
                    var eventsName = scripts[i].name + "_" + scripts[i].id;
                    input += scripts[i].name + ' = "' + eventsName + '(this);"';
                }
            }
        }
        input += '/>';
        if (scripts && $.isArray(scripts))
        {
            input += '<script type="text/javascript">';
            for (var i = 0; i < scripts.length; i++)
            {
                if (colnumJSON.name == scripts[i].filed && scripts[i].script && scripts[i].script.length > 0)
                {
                    var eventsName = scripts[i].name + "_" + scripts[i].id;
                    input += 'function ' + eventsName + '(srcObj){' + scripts[i].script + '}';
                }
            }
            input += '</script>';
        }
        return input;
    },
    getSubTableHtml_Textarea: function (colnumJSON, id, i, iscount)
    {
        var editmode = colnumJSON.editmode;
        var scripts = editmode.scripts;
        var textarea = '<textarea class="mytextarea" name="' + id + '_' + i + '_' + colnumJSON.name + '" id="' + id + '_' + i + '_' + colnumJSON.name + '" issubflow="1" type1="subflow_textarea" ';
        var width = editmode.textarea_width;
        var height = editmode.textarea_height;
        textarea += 'colname="' + colnumJSON.name + '" ';
        if (width && height)
        {
            textarea += 'style="width:' + width + ';height:' + height + '" ';
        }
        else if (width || height)
        {
            if (width)
            {
                textarea += 'style="width:' + width + '" ';
            }
            if (height)
            {
                textarea += 'style="height:' + height + '" ';
            }
        }

        if (editmode.text_valuetype)
        {
            input += 'valuetype="' + editmode.text_valuetype + '" ';
        }

        if (editmode.textarea_maxlength)
        {
            textarea += 'maxlength="' + parseInt(editmode.textarea_maxlength) + '" ';
        }
        if (scripts && $.isArray(scripts))
        {
            for (var i = 0; i < scripts.length; i++)
            {
                if (colnumJSON.name == scripts[i].filed && scripts[i].script && scripts[i].script.length > 0)
                {
                    var eventsName = scripts[i].name + "_" + scripts[i].id;
                    textarea += scripts[i].name + ' = "' + eventsName + '(this);"';
                }
            }
        }
        textarea += '>';
        textarea += UE.compule.getDefaultValue(editmode.textarea_defaultvalue);
        textarea += '</textarea>';
        if (scripts && $.isArray(scripts))
        {
            textarea += '<script type="text/javascript">';
            for (var i = 0; i < scripts.length; i++)
            {
                if (colnumJSON.name == scripts[i].filed && scripts[i].script && scripts[i].script.length > 0)
                {
                    var eventsName = scripts[i].name + "_" + scripts[i].id;
                    textarea += 'function ' + eventsName + '(srcObj){' + scripts[i].script + '}';
                }
            }
            textarea += '</script>';
        }
        return textarea;
    },
    getSubTableHtml_OptionsFromString: function (str, type, name, colname, iscount, value)//type:0 option 1 checkbox 2 radio name:checkbox radio时的名称
    {
        var select = '';
        var strarray = str.split(';');
        for (var i = 0; i < strarray.length; i++)
        {
            var strarray1 = strarray[i].split(',');
            if (strarray1.length == 0)
            {
                continue;
            }
            var val = strarray1[0];
            var txt = val;
            if (strarray1.length > 1)
            {
                txt = strarray1[1];
            }
            type = type || 0;
            value = $.trim(value || "");
            switch (type)
            {
                case 0:
                    select += '<option value="' + val.toString().replaceAll('"', '') + '" ' + (value == val.toString().replaceAll('"', '') ? 'selected="selected"' : '') + '>' + txt + '</option>';
                    break;
                case 1:
                    select += '<input type="checkbox" colname="' + colname + '" issubflow="1" type1="subflow_checkbox" name="' + name + '" id="' + name + '" value="' + val.toString().replaceAll('"', '') + '" ' + (value.indexOf(val.toString().replaceAll('"', '')) >= 0 ? 'checked="checked"' : '') + ' style="vertical-align:middle;"/>';
                    select += '<label style="vertical-align:middle;" for="' + name + '">' + txt + '</label>';
                    break;
                case 2:
                    select += '<input type="radio" colname="' + colname + '" issubflow="1" type1="subflow_radio" name="' + name + '" id="' + name + '" value="' + val.toString().replaceAll('"', '') + '" ' + (value == val.toString().replaceAll('"', '') ? 'checked="checked"' : '') + ' style="vertical-align:middle;"/>';
                    select += '<label style="vertical-align:middle;" for="' + name + '">' + txt + '</label>';
                    break;
            }
        }
        return select;
    },
    getSubTableHtml_Select: function (colnumJSON, id, i, iscount)
    {
        var editmode = colnumJSON.editmode;
        var scripts = editmode.scripts;
        var select = '<select class="myselect" name="' + id + '_' + i + '_' + colnumJSON.name + '" id="' + id + '_' + i + '_' + colnumJSON.name + '" issubflow="1" type1="subflow_select" ';
        select += 'colname="' + colnumJSON.name + '" ';
        if (editmode.select_width)
        {
            select += 'style="width:' + editmode.select_width + '" ';
        }
        if (editmode.select_Linkage_Field && editmode.select_Linkage_Field.length > 0)//设置了联动
        {
            select += ' linkagefield="' + id + '_' + i + '_' + editmode.secondtable + "_" + editmode.select_Linkage_Field + '"';
            select += ' linkagefieldcolname="' + editmode.secondtable + "_" + editmode.select_Linkage_Field + '"';
            select += ' linkagesource="' + editmode.select_Linkage_Source + '"';
            select += ' linkagesourcetext="' + editmode.select_Linkage_Source_text + '"';
            select += ' linkagesourceconn="' + editmode.select_Linkage_Source_sql_conn + '"';
            //select += ' issubtable="1"';
            select += ' onchange="RoadUI.Core.loadOptions(this);"';
        }
        if (scripts && $.isArray(scripts))
        {
            for (var i = 0; i < scripts.length; i++)
            {
                if (colnumJSON.name == scripts[i].filed && scripts[i].script && scripts[i].script.length > 0)
                {
                    var eventsName = scripts[i].name + "_" + scripts[i].id;
                    select += scripts[i].name + ' = "' + eventsName + '(this);"';
                }
            }
        }
        select += '>';
        var ds = editmode.select_ds;
        var dvalue = editmode.select_default || "";
        switch (ds)
        {
            case "select_dsdict":
                var rootid = editmode.select_ds_dict;
                var select_ds_dict_ischild = editmode.select_ds_dict_ischild && "1" == editmode.select_ds_dict_ischild;
                if ("1" == editmode.select_hasempty)
                {
                    select += '<option value=""></option>';
                }
                select += '@Html.Raw(BDictionary.GetOptionsByID("' + rootid + '".ToGuid(), RoadFlow.Platform.Dictionary.OptionValueField.ID, "' + dvalue + '", ' + (select_ds_dict_ischild ? "true" : "false") + '))';
                break;
            case "select_dssql":
                var conn = editmode.select_ds_dbconn;
                var sql = editmode.select_ds_sql;
                if ("1" == editmode.select_hasempty)
                {
                    select += '<option value=""></option>';
                }
                select += '@Html.Raw(new RoadFlow.Platform.WorkFlowForm().GetOptionsFromSql(DBConnID, "' + sql.replaceAll('"', '\"') + '", "' + dvalue + '"))';
                break;
            case "select_dsstring":
                var str = editmode.select_ds_string;
                if ("1" == editmode.select_hasempty)
                {
                    select += '<option value=""></option>';
                }
                select += UE.compule.getSubTableHtml_OptionsFromString(str, 0, "", "", "", dvalue);
                break;
        }
        select += '</select>';
        if (scripts && $.isArray(scripts))
        {
            select += '<script type="text/javascript">';
            for (var i = 0; i < scripts.length; i++)
            {
                if (colnumJSON.name == scripts[i].filed && scripts[i].script && scripts[i].script.length > 0)
                {
                    var eventsName = scripts[i].name + "_" + scripts[i].id;
                    select += 'function ' + eventsName + '(srcObj){' + scripts[i].script + '}';
                }
            }
            select += '</script>';
        }
        return select;
    },
    getSubTableHtml_Checkbox: function (colnumJSON, id, i, iscount)
    {
        var editmode = colnumJSON.editmode;
        var checkbox = '';
        var ds = editmode.checkbox_ds;
        var name = id + '_' + i + '_' + colnumJSON.name;
        var dvalue = editmode.checkbox_default || "";
        switch (ds)
        {
            case "checkbox_dsdict":
                var rootid = editmode.checkbox_ds_dict;
                checkbox = '<span>@Html.Raw(BDictionary.GetCheckboxsByID("' + rootid + '".ToGuid(), "' + name + '", RoadFlow.Platform.Dictionary.OptionValueField.ID, "' + dvalue + '", "issubflow=\'1\' type1=\'subflow_checkbox\' colname=\'' + colnumJSON.name + '\'"))</span>';
                break;
            case "checkbox_dssql":
                var conn = editmode.checkbox_ds_dbconn;
                var sql = editmode.checkbox_ds_sql;
                checkbox = '@Html.Raw(new RoadFlow.Platform.WorkFlowForm().GetCheckboxFromSql(DBConnID, "' + sql.replaceAll('"', '\"') + '", "' + name + '", "' + dvalue + '", "issubflow=\'1\' type1=\'subflow_checkbox\' colname=\'' + colnumJSON.name + '\'"))';
                break;
            case "checkbox_dsstring":
                var str = editmode.checkbox_ds_string;
                checkbox += UE.compule.getSubTableHtml_OptionsFromString(str, 1, name, colnumJSON.name, "", dvalue);
                break;
        }

        return checkbox;
    },
    getSubTableHtml_Radio: function (colnumJSON, id, i, iscount)
    {
        var editmode = colnumJSON.editmode;
        var radio = '';
        var ds = editmode.radio_ds;
        var name = id + '_' + i + '_' + colnumJSON.name;
        var dvalue = editmode.radio_default || "";
        switch (ds)
        {
            case "radio_dsdict":
                var rootid = editmode.radio_ds_dict;
                radio = '<span>@Html.Raw(BDictionary.GetRadiosByID("' + rootid + '".ToGuid(), "' + name + '", RoadFlow.Platform.Dictionary.OptionValueField.ID, "' + dvalue + '", "issubflow=\'1\' type1=\'subflow_radio\' colname=\'' + colnumJSON.name + '\'"))</span>';
                break;
            case "radio_dssql":
                var conn = editmode.radio_ds_dbconn;
                var sql = editmode.radio_ds_sql;
                radio = '@Html.Raw(new RoadFlow.Platform.WorkFlowForm().GetRadioFromSql(DBConnID, "' + sql.replaceAll('"', '\"') + '", "' + name + '", "' + dvalue + '", "issubflow=\'1\' type1=\'subflow_radio\'" colname=\'' + colnumJSON.name + '\'"))';
                break;
            case "radio_dsstring":
                var str = editmode.radio_ds_string;
                radio += UE.compule.getSubTableHtml_OptionsFromString(str, 2, name, colnumJSON.name, "", dvalue);
                break;
        }

        return radio;
    },
    getSubTableHtml_DateTime: function (colnumJSON, id, i, iscount)
    {
        var editmode = colnumJSON.editmode;
        var scripts = editmode.scripts;
        var datetime = '<input type="text" class="mycalendar" name="' + id + '_' + i + '_' + colnumJSON.name + '" id="' + id + '_' + i + '_' + colnumJSON.name + '" issubflow="1" type1="subflow_datetime" value="' + UE.compule.getDefaultValue(editmode.datetime_defaultvalue) + '" ';
        datetime += 'colname="' + colnumJSON.name + '" ';
        if (editmode.datetime_min)
        {
            datetime += 'mindate="' + editmode.datetime_min + '"';
        }
        if (editmode.datetime_max)
        {
            datetime += 'maxdate="' + editmode.datetime_max + '"';
        }
        if ("1" == editmode.datetime_istime)
        {
            datetime += ' istime="1"';
        }
        if (editmode.datetime_format)
        {
            datetime += ' format="' + editmode.datetime_format + '"';
        }
        if (editmode.datetime_width)
        {
            datetime += 'style="width:' + editmode.datetime_width + '" ';
        }
        if (scripts && $.isArray(scripts))
        {
            for (var i = 0; i < scripts.length; i++)
            {
                if (colnumJSON.name == scripts[i].filed && scripts[i].script && scripts[i].script.length > 0)
                {
                    var eventsName = scripts[i].name + "_" + scripts[i].id;
                    datetime += scripts[i].name + ' = "' + eventsName + '(this);"';
                }
            }
        }
        datetime += '/>';
        if (scripts && $.isArray(scripts))
        {
            datetime += '<script type="text/javascript">';
            for (var i = 0; i < scripts.length; i++)
            {
                if (colnumJSON.name == scripts[i].filed && scripts[i].script && scripts[i].script.length > 0)
                {
                    var eventsName = scripts[i].name + "_" + scripts[i].id;
                    datetime += 'function ' + eventsName + '(srcObj){' + scripts[i].script + '}';
                }
            }
            datetime += '</script>';
        }
        return datetime;
    },
    getSubTableHtml_Org: function (colnumJSON, id, i, iscount)
    {
        var editmode = colnumJSON.editmode;
        var org = '<input type="text" class="mymember" name="' + id + '_' + i + '_' + colnumJSON.name + '" id="' + id + '_' + i + '_' + colnumJSON.name + '" issubflow="1" type1="subflow_org" value="' + UE.compule.getDefaultValue(editmode.org_defaultvalue) + '" ';
        org += 'colname="' + colnumJSON.name + '" ';
        var org_type = editmode.org_type;
        if (org_type)
        {
            org += ' dept="' + (org_type.indexOf(",0,") >= 0 ? "1" : "0") + '"';
            org += ' station="' + (org_type.indexOf(",1,") >= 0 ? "1" : "0") + '"';
            org += ' user="' + (org_type.indexOf(",2,") >= 0 ? "1" : "0") + '"';
            org += ' workgroup="' + (org_type.indexOf(",3,") >= 0 ? "1" : "0") + '"';
            org += ' unit="' + (org_type.indexOf(",4,") >= 0 ? "1" : "0") + '"';
        }
        if (editmode.org_width)
        {
            org += 'style="width:' + editmode.org_width + '" ';
        }
        org += ' more="' + editmode.org_more + '"';
        var rootid = '';
        switch (editmode.org_rang)
        {
            case "0": //发起者部门
                rootid = '@BWorkFlowTask.GetFirstSnderDeptID(FlowID.ToGuid(), GroupID.ToGuid())';
                break;
            case "1": //处理者部门
                rootid = '@(RoadFlow.Platform.Users.CurrentDeptID)';
                break;
            case "2": //自定义
                rootid = editmode.org_rang1;
                break;
        }
        if (rootid)
        {
            org += ' rootid="' + rootid + '"';
        }
        org += '/>';
        return org;
    },
    getSubTableHtml_Dict: function (colnumJSON, id, i, iscount)
    {
        var editmode = colnumJSON.editmode;
        var dict = '<input type="text" class="mydict" name="' + id + '_' + i + '_' + colnumJSON.name + '" id="' + id + '_' + i + '_' + colnumJSON.name + '" issubflow="1" type1="subflow_dict" ';
        dict += 'colname="' + colnumJSON.name + '" ';
        if (editmode.dict_width)
        {
            dict += 'style="width:' + editmode.dict_width + '" ';
        }
        if (editmode.dict_rang)
        {
            dict += 'rootid="' + editmode.dict_rang + '" ';
        }
        dict += 'more="' + editmode.dict_more + '" ';
        dict += '/>';
        return dict;
    },
    getSubTableHtml_Files: function (colnumJSON, id, i, iscount)
    {
        var editmode = colnumJSON.editmode;
        var files = '<input type="text" class="myfile" name="' + id + '_' + i + '_' + colnumJSON.name + '" id="' + id + '_' + i + '_' + colnumJSON.name + '" issubflow="1" type1="subflow_files" ';
        files += 'colname="' + colnumJSON.name + '" ';
        if (editmode.files_width)
        {
            files += 'style="width:' + editmode.files_width + '" ';
        }
        if (editmode.files_filetype)
        {
            files += 'filetype="' + editmode.files_filetype + '" ';
        }
        files += '/>';
        return files;
    },
    getSubTableHtml: function ($control)
    {
        var id = $control.attr("id");
        var subtableJSON = {};

        for (var i = 0; i < parent.formsubtabs.length; i++)
        {
            if (parent.formsubtabs[i].id == id)
            {
                subtableJSON = parent.formsubtabs[i];
                break;
            }
        }
        if (!subtableJSON.id || !subtableJSON.colnums || subtableJSON.colnums.length == 0)
        {
            return;
        }

        var edittds = '';
        var counttds = [];//合计列
        var hasCountColnum = false;//是否有合计列
        var guid = RoadUI.Core.newid(false);
        var showIndex = "1" == subtableJSON.showindex;
        var sortstring = subtableJSON.sortstring;

        //排序
        subtableJSON.colnums.sort(UE.compule.compare("index"));
        
        if ("1" != subtableJSON.editmodel)
        {
            var index = 0;
            var html = '<table class="flowformsubtable" data-showindex="' + (showIndex ? "1" : "0") + '" data-sortstring="' + sortstring + '" style="width:99%;margin:0 auto;" cellPadding="0" cellspacing="1" issubflowtable="1" id="subtable_' + id + '">';
            html += '<thead>';
            html += '<tr>';
            if (showIndex)
            {
                html += '<th style="text-align:center;width:50px;">序号</th>';
                edittds += '<td style="text-align:center;"><label name="showindex">1</label></td>';
            }
            for (var i = 0; i < subtableJSON.colnums.length; i++)
            {
                var colnumJSON = subtableJSON.colnums[i];
                if ("1" != colnumJSON.isshow)
                {
                    continue;
                }
                var align = 'left';
                if (0 == colnumJSON.align)
                {
                    align = 'left';
                }
                else if (1 == colnumJSON.align)
                {
                    align = 'center';
                }
                else if (2 == colnumJSON.align)
                {
                    align = 'right';
                }
                var width = colnumJSON.width;
                html += '<th style="text-align:' + align + ';' + (width ? 'width:' + width + ';' : '') + 'padding-right:3px;">';
                html += colnumJSON.showname || colnumJSON.name;
                if (index == 0)
                {
                    html += '<input type="hidden" name="flowsubtable_id" value="' + id + '" />';
                    html += '<input type="hidden" name="flowsubtable_' + id + '_secondtable" value="' + subtableJSON.secondtable + '" />';
                    html += '<input type="hidden" name="flowsubtable_' + id + '_primarytablefiled" value="' + subtableJSON.primarytablefiled + '" />';
                    html += '<input type="hidden" name="flowsubtable_' + id + '_secondtableprimarykey" value="' + subtableJSON.secondtableprimarykey + '" />';
                    html += '<input type="hidden" name="flowsubtable_' + id + '_secondtablerelationfield" value="' + subtableJSON.secondtablerelationfield + '" />';
                }
                html += '</th>';

                var editelement = '';
                var editmode = colnumJSON.editmode;
                var editmode1 = editmode.editmode || "text";
                var iscount = "1" == colnumJSON.issum;
                edittds += '<td colname="' + colnumJSON.name + '" iscount="' + colnumJSON.issum + '" style="text-align:' + align + ';padding-right:3px;">';
                if (index == 0)
                {
                    edittds += '<input type="hidden" name="hidden_guid_' + id + '" value="' + guid + '" />';
                    edittds += '<input type="hidden" name="flowsubid" value="' + id + '" />';
                }
                switch (editmode1)
                {
                    case "text":
                        editelement = UE.compule.getSubTableHtml_Text(colnumJSON, id, guid, iscount);
                        break;
                    case "textarea":
                        editelement = UE.compule.getSubTableHtml_Textarea(colnumJSON, id, guid, iscount);
                        break;
                    case "select":
                        editelement = UE.compule.getSubTableHtml_Select(colnumJSON, id, guid, iscount);
                        break;
                    case "checkbox":
                        editelement = UE.compule.getSubTableHtml_Checkbox(colnumJSON, id, guid, iscount);
                        break;
                    case "radio":
                        editelement = UE.compule.getSubTableHtml_Radio(colnumJSON, id, guid, iscount);
                        break;
                    case "datetime":
                        editelement = UE.compule.getSubTableHtml_DateTime(colnumJSON, id, guid, iscount);
                        break;
                    case "org":
                        editelement = UE.compule.getSubTableHtml_Org(colnumJSON, id, guid, iscount);
                        break;
                    case "dict":
                        editelement = UE.compule.getSubTableHtml_Dict(colnumJSON, id, guid, iscount);
                        break;
                    case "files":
                        editelement = UE.compule.getSubTableHtml_Files(colnumJSON, id, guid, iscount);
                        break;
                }
                edittds += editelement;
                edittds += '</td>';

                if (!hasCountColnum && "1" == colnumJSON.issum)
                {
                    hasCountColnum = true;
                }

                if (iscount)
                {
                    var coltitle = colnumJSON.showname || colnumJSON.name;
                    counttds.push({ "id": id, "name": colnumJSON.name, "title": coltitle });
                }
                index++;
            }
            html += '<th>'

            html += '</th>'
            html += '</tr>';
            html += '</thead>';
            html += '<tbody>';
            html += '<tr type1="listtr">';
            html += edittds;
            html += '<td>'
            html += '<input type="button" class="mybutton" style="margin-right:4px;" value="增加" onclick="formrun.subtableNewRow(this);"/>';
            html += '<input type="button" class="mybutton" value="删除" onclick="formrun.subtableDeleteRow(this);"/>';
            html += '</td>'
            html += '</tr>';

            if (hasCountColnum)//添加合计行
            {
                html += '<tr type1="counttr">';
                html += '<td colspan="' + (subtableJSON.colnums.length + 1).toString() + '" align="right" style="padding-right:20px; text-align:right;">';
                for (var j = 0; j < counttds.length; j++)
                {
                    html += '<span style="margin-right:10px;">' + counttds[j].title +
                        '合计：<label id="countspan_' + counttds[j].id + '_' + counttds[j].name + '">0</label></span>';
                }
                html += '</td>';
                html += '</tr>';
            }

            html += '</tbody>';
            html += '</table>';

            $control.after(html);
            $control.remove();
        }
        else //弹出方式
        {
            var index = 0;
            var html1 = '<table class="flowformsubtable" data-showindex="' + (showIndex ? "1" : "0") + '" data-sortstring="' + sortstring + '" style="width:99%;margin:0 auto;" cellPadding="0" cellspacing="1" issubflowtable="1" id="subtable_' + id + '">';
            html1 += '<thead>';
            html1 += '<tr>';
            if (showIndex)
            {
                html1 += '<th style="text-align:center;width:50px;">序号</th>';
            }
            for (var i = 0; i < subtableJSON.colnums.length; i++)
            {
                var colnumJSON = subtableJSON.colnums[i];
                if ("1" != colnumJSON.isshow)
                {
                    continue;
                }
                html1 += '<th style="text-align:left;">';
                html1 += colnumJSON.showname || colnumJSON.name;
                html1 += '</th>'

            }
            html1 += '<th style="width:10%; text-align:left;">'
            html1 += '<input type="button" class="mybutton" value="添加" onclick="subtable_addrow_' + id.replace('.', '') + '();"/>';
            html1 += '</th>'
            html1 += '</tr>';
            html1 += '</thead>';
            html1 += '<tbody>';
            html1 += '@{';
            html1 += 'System.Data.DataTable Dt_' + id + ' = new RoadFlow.Platform.DBConnection().GetDataTable(DBConnID, "' + subtableJSON.secondtable + '","' + subtableJSON.secondtablerelationfield + '", InstanceID, "' + sortstring + '");';
            html1 += 'RoadFlow.Platform.WorkFlowForm bWorkFlowForm_' + id + ' = new RoadFlow.Platform.WorkFlowForm();';
            html1 += 'int showIndex = 0;';
            html1 += 'foreach(System.Data.DataRow dr in Dt_' + id + '.Rows){';
            html1 += '';
            html1 += '<tr>';
            if (showIndex)
            {
                html1 += '<td style="text-align:center;"><label name="showindex">@(++showIndex)</label></td>';
            }
            for (var i = 0; i < subtableJSON.colnums.length; i++)
            {
                var colnumJSON = subtableJSON.colnums[i];
                if ("1" != colnumJSON.isshow)
                {
                    continue;
                }
                html1 += '<td>';
                html1 += '@bWorkFlowForm_' + id + '.GetDisplayString(dr["' + colnumJSON.fieldname + '"].ToString(), "' + (colnumJSON.displaymode || "normal") + '", "' + (colnumJSON.displaymodeformat || "") + '", DBConnID, "' + (colnumJSON.displaymodesql || "") + '" )';
                html1 += '</td>';
            }
            html1 += '<td>';
            html1 += '<input type="button" class="mybutton" value="编辑" data-id="@dr["' + subtableJSON.secondtableprimarykey + '"]" onclick="subtable_editrow_' + id + '(\'@dr["' + subtableJSON.secondtableprimarykey + '"]\');" style="margin-right:4px;" name="flowsubtable_' + id + '_editbutton" />';
            html1 += '<input type="button" class="mybutton" value="删除" onclick="subtable_deleterow_' + id + '(\'@dr["' + subtableJSON.secondtableprimarykey + '"]\');" name="flowsubtable_' + id + '_editbutton"/>';
            html1 += '</td>';
            html1 += '</tr>';
            html1 += '}}';
            html1 += '</tbody>';
            html1 += '</table>';

            var $scriptdiv = $('<div></div>');
            var script1 = '';
            script1 += '<script type="text/javascript">';
            script1 += 'function subtable_addrow_' + id + '()';
            script1 += '{';
            script1 += 'var subtableid = "' + id + '";';
            script1 += 'var instanceid = "@InstanceID";';
            script1 += 'var tabid = \'@Request.QueryString["tabid"]\';';
            script1 += 'var appid = \'@Request.QueryString["appid"]\';';
            if (subtableJSON.secondtablerelationfield && $.trim(subtableJSON.secondtablerelationfield).length > 0)
            {
                script1 += 'if($.trim(instanceid).length==0)';
                script1 += '{';
                script1 += 'alert("请先保存主表数据再添加!");return;';
                script1 += '}';
            }
            script1 += 'new RoadUI.Window().open({url:"/WorkFlowRun/SubTableEdit?editmodel=1&flowid=@FlowID&stepid=@StepID&secondtableeditform=' + subtableJSON.editform + '&primarytableid=" + instanceid + "&secondtablerelationfield=' + subtableJSON.secondtable + '.' + subtableJSON.secondtablerelationfield + '&appid="+appid,openerid:tabid,title:"添加",height:' + (subtableJSON.displaymodeheight || 500) + ',width:' + (subtableJSON.displaymodewidth || 800) + '});';
            script1 += '}';
            script1 += 'function subtable_editrow_' + id + '(id, display)';
            script1 += '{';
            script1 += 'var subtableid="' + id + '";';
            script1 += 'var instanceid="@Request.QueryString["instanceid"]";';
            script1 += 'var tabid=\'@Request.QueryString["tabid"]\';';
            script1 += 'var appid = \'@Request.QueryString["appid"]\';';
            script1 += 'new RoadUI.Window().open({url:"/WorkFlowRun/SubTableEdit?editmodel=1&flowid=@FlowID&stepid=@StepID&secondtableeditform=' + subtableJSON.editform + '&secondtable=' + subtableJSON.secondtable + '&secondtableconnid=@DBConnID&secondtableprimarykey=' + subtableJSON.secondtableprimarykey + '&instanceid="+id+"&primarytableid="+instanceid+"&secondtablerelationfield=' + subtableJSON.secondtable + '.' + subtableJSON.secondtablerelationfield + '&appid="+appid+"&display=" + (display || ""),openerid:tabid,title:1==display ? "查看" : "编辑",height:' + (subtableJSON.displaymodeheight || 500) + ',width:' + (subtableJSON.displaymodewidth || 800) + '});';
            script1 += '}';
            script1 += 'function subtable_deleterow_' + id + '(id)';
            script1 += '{';
            script1 += 'var subtableid = "' + id + '";';
            script1 += 'var instanceid = "<%=InstanceID%>";';
            script1 += 'var tabid = \'@Request.QueryString["tabid"]\';';
            script1 += 'var appid = \'@Request.QueryString["appid"]\';';
            script1 += 'if(!confirm("您真的要删除该记录吗?")){return;}';
            script1 += '$.ajax({url:"/WorkFlowRun/SubTableDelete?secondtableeditform=' + subtableJSON.editform + '&secondtableconnid=@DBConnID&secondtable=' + subtableJSON.secondtable + '&secondtableprimarykey=' + subtableJSON.secondtableprimarykey + '&secondtablepkvalue="+id+"&appid="+appid,async:false,cache:false,success:function(txt){alert(txt);window.location=window.location;}});';
            script1 += '}';

            script1 += '$(function(){';
            script1 += 'var isdisplay = \'1\'==\'@Request.QueryString["display"]\';';
            script1 += 'var ' + subtableJSON.secondtable + '_Status=(fieldStatus.' + (subtableJSON.secondtable + '_' + subtableJSON.secondtableprimarykey).toLowerCase() + '||"").split(\'_\');';
            script1 += 'if(' + subtableJSON.secondtable + '_Status.length>0 || isdisplay){';
            script1 += 'var ' + subtableJSON.secondtable + '_Status1=' + subtableJSON.secondtable + '_Status[0];';
            script1 += 'if("1"==' + subtableJSON.secondtable + '_Status1 || "2"==' + subtableJSON.secondtable + '_Status1 || isdisplay){';
            script1 += '$("#subtable_' + id + ' thead tr th:last input").remove();';
            script1 += '$("#subtable_' + id + ' tbody tr").each(function(){';
            script1 += '$("td:last input:last",$(this)).remove();';
            script1 += '$("td:last input:first",$(this)).attr("value","查看").removeAttr("onclick").bind("click",function(){';
            script1 += 'subtable_editrow_' + id + '($(this).attr("data-id"),1);';
            script1 += '});';
            script1 += '});';
            script1 += '}'
            script1 += '}';
            script1 += '});';

            script1 += '</script>';
            $scriptdiv.text(script1 + html1);
            $control.after($scriptdiv);
            $control.remove();
        }
    },
    compare: function (property)
    {
        return function (a, b)
        {
            var value1 = a[property];
            var value2 = b[property];
            return value1 - value2;
        }
    }
};