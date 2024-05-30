(function ($) {
    var textboxDefaultOptions = {
    };
    $.fn.Textbox = function (opts) {
        if (opts.type == "number" || $(this).attr('data-type') == "number")
            $(this).unbind('keydown').keydown(function (e) {
                if (e.keyCode == 8 || e.keyCode == 46)
                    return true;
                return !isNaN(e.key) && +this.value + e.key <= opts.maxValue;
            });

        return this;
    };
}(jQuery));

function PostDataTo(url, data, target) {
    var form = $("<form>").attr({
        "method": "POST",
        "action": url,
        "target": target || "_blank"
    });

    addControl(data);

    function addControl(items, parent) {
        for (var key in items) {
            //if (typeof (items[key]) === "object")
            //    addControl(items[key], (parent || "") + ((parent || "") == "" ? key : "[" + key + "]"))
            //else
                form.append(
                    $("<input>").attr({
                        "type": "hidden",
                        "name": (parent || "") + ((parent || "") == "" ? key : "[" + key + "]"),
                        "value": typeof (items[key]) === "object" ? JSON.stringify(items[key]) : items[key]
                    })
                );
        }
    }

    $("body").append(form);

    form.submit();
    form.remove();
}

function generateXMLString(obj, parentTagName) {
    var xmlStr = "";
    var childTagName = parentTagName.substr(0, parentTagName.length - 1);

    if (!obj.length)
        return null;

    xmlStr += "<" + parentTagName + ">";
    for (var row in obj) {
        var pk = parseInt(row) + 1;
        xmlStr += "<" + childTagName + ">";
        xmlStr += "<id>" + pk + "</id>";
        for (var col in obj[row]) {
            if (typeof (obj[row][col]) === "object" && obj[row][col] !== null)
                xmlStr += "<" + col + ">" + generateXMLString(obj[row][col], col) + "</" + col + ">";
            else
                xmlStr += "<" + col + ">" + obj[row][col] + "</" + col + ">";
        }
        xmlStr += "</" + childTagName + ">";
    }
    xmlStr += "</" + parentTagName + ">";

    return encodeURI(xmlStr);
}

$.prototype.DataSet = function () { };

var Cookie = {
    Set: function (name, value, days) {
        var expires;
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            expires = "; expires=" + date.toGMTString();
        }
        else {
            expires = "";
        }
        document.cookie = name + "=" + value + expires + "; path=/";
    },
    Get: function (c_name) {
        if (document.cookie.length > 0) {
            c_start = document.cookie.indexOf(c_name + "=");
            if (c_start != -1) {
                c_start = c_start + c_name.length + 1;
                c_end = document.cookie.indexOf(";", c_start);
                if (c_end == -1) {
                    c_end = document.cookie.length;
                }
                return unescape(document.cookie.substring(c_start, c_end));
            }
        }
        return "";
    }
};


var Url = {
    Combine: function (url, data) {
        for (key in data) {
            if (url.indexOf("?") > -1)
                url += "&" + key + "=" + data[key];
            else
                url += "?" + key + "=" + data[key];
        }

        return url;
    }
};

var Page = {
    Content: {
        Loading: function (selector) {
            $(selector).append(
                $("<img>").attr({
                    src: "/contents/images/loading.gif"
                }).addClass("center")
                ).append(
                $("<div>").html("Loading")
                .css({
                    "text-align": "center"
                })
                );
        }
    },
    Preload: {
        Show: function (msg) {
            $("body").append(
                $("<div>")
                    .addClass("divLoading")
                    .append(
                        $("<div>")
                        .addClass("title")
                        .html(msg || "Loading")
                    )
                );
        },
        Hide: function () {
            $(".divLoading").remove();
        }
    },
    Toast: function (opts, delay) {
        var defaultCSS = {
            "display": "inline-block",
            "position": "fixed",
            "background-color": "black",
            "font-size": "24px",
            "text-align": "center",
            "vertical-align": "center",
            "color": "#fff",
            "width": "600px",
            "height": "60px",
            "line-height": "60px",
            "margin": "auto",
            "top": "300px",
            "left": "0",
            "right": "0",
            "border-radius": "5px",
            "z-index": "9999",
            "opacity": "0.75"
        };

        for (var cssOpt in opts.css)
            defaultCSS[cssOpt] = opts.css[cssOpt];

        if(opts.css !== undefined)
            defaultCSS["line-height"] = opts.css["height"] || defaultCSS["height"];
        if (typeof (opts) === "string")
            opts = { message: opts };

        $("body").append(
            $("<div>")
                .addClass("divToast")
                .css(defaultCSS)
                .html(opts.message)
            )

        setTimeout(function () {
            $(".divToast").fadeOut(((opts.delay || delay) || 2000) / 2,
            function () {
                $(".divToast").remove();
                if(typeof(opts.onclose) === "function")
                    opts.onclose();
            });
        }, (opts.delay || delay) || 2000);
        
    }
}