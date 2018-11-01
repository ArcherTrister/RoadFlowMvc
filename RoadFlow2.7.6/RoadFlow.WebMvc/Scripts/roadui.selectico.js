﻿//选择图标
;RoadUI.SelectIco = function (options)
{
    var instance = this;
    var defaults = {
        obj: null,
        x: true
    };

    this.opts = $.extend(defaults, options);
    var $source = $(this.opts.obj);
    var validate = $source.attr('validate');
    var val = $source.val();
    var id = $source.attr('id');
    var name = $source.attr('name');
    var more = $source.attr('more');
    var source = $source.attr("source");
    var title = $source.attr("title");
    if (title == null || title == undefined) title = "选择图标";
    if (!source || source.length == 0)
    {
        source = RoadUI.Core.rooturl() + "/Images/Ico";
    }

    if (name == null || name == undefined) name = id;

    more = more == null || more == undefined ? "0" : more.toLowerCase() == "true" || more == "1" ? "1" : "0";
    source = source == null || source == undefined ? "" : source;

    $source.removeClass().addClass("mytext");
    //$source.prop("readonly", true);
    $source.css({ "background-position-x": "3px", "color": "#666", "background-image": "url(" + RoadUI.Core.rooturl() + val + ")", "background-repeat": "no-repeat", "padding-left": "23px", "background-position-y": "center" });
    var $but = $('<input type="button" class="mybutton" style="border-left:none;margin:0;" value="选择" />');
    var $label = $('<label type="msg"></label>');

    if (!val || val.substr(0, 2) == "fa")
    {
        $source.css({ "padding-left": "3px", "background-image": "" });
    }

    if ($source.prop("disabled"))
    {
        $but.prop("disabled", true);
    }
    else
    {
        $but.bind('click', function ()
        {
            new RoadUI.Window().open({
                id: "ico_" + id, title: title, width: 800, height: 606,
                url: '/Controls/SelectIco/Index?more=' + more + '&id=' + id + '&source=' + source + '&values=' + val, openerid: RoadUI.Core.query("tabid")
            });
        });
    }

    $source.after($but, $label);
    this.setIco = function ($obj, ico)
    {
        if (!ico)
        {
            ico = $obj.val();
        }
        if (!ico || ico.substr(0, 2) == "fa")
        {
            $source.css({ "padding-left": "3px", "background-image": "" });
        }
        else
        {
            $obj.css({ "padding-left": "20px", "background-image": "url(" + RoadUI.Core.rooturl() + ico + ")" });
        }
    }
}