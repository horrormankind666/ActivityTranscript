/// <reference path="../../jquery-3.1.1.js" />

function displayDetail(e) {
    var divSubject = $(e).parents('.divSubject');
    var divDetail = divSubject.find(".divDetail");
    if (divDetail.is(":hidden"))
    {
        divDetail.load("../datas/SubjectHandler.ashx?action=GetSubjectDetail", function (response) {
            $(this).html(response);
            $(this).show();
        });
    }
    else
    {
        divDetail.children().remove();
        divDetail.hide();
    }
}

function loadSubjectForm() {
    
}