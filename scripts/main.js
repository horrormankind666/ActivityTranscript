$(function () {
    (function checkIsDocSelect() {
        if (!($("[data-isdocselected]").is("li")) && $(".breadcrumb li").length > 1)
        {
            $(".breadcrumb").find("li:first").popover({
                html: true,
                content: '<h4 style="color:#f00;"><strong>กรุณากดที่นี่เพื่อเลือกเอกสาร</strong></h4>',
                placement: 'bottom'
            });
            $(".breadcrumb").find("li:first").popover("show");
        }
            //alert("กรุณาเลือกเอกสาร");
    })();
    $(".privilage-fac").on('click', function () {
        $(".privilage-fac").find("i").remove();
        $(".privilage-fac").find("a").attr("style", "");
        //$(".privilage-fac").removeClass("selected");
        var facId = $(this).data("facid");
        $(this)
            //.addClass("selected")
            .find("a")
            .css({
                "font-weight": "bold"
            })
            .append(
                $("<i>")
                    .addClass("glyphicon glyphicon-ok")
                    .css({
                        "margin-left": "10px"
                    })
            );

        setAccessFaculty(facId);
    });
    $(".btnNav2SelDoc").click(function () {
        $.post("../datas/MasterDataHandler.ashx",
            {
                action: "PinLastPointPoint",
                url: window.location.href
            },
            function (){
                window.location.href = "frmDocument.aspx"
        });
    });
    function setAccessFaculty(facId) {
        $.post("../datas/MasterDataHandler.ashx",
            {
                action: "SetAccessFaculty",
                facId: facId
            },
            function () {
                Page.Preload.Show();
                window.location.reload();
            });
    }
});