using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;

/// <summary>
/// Summary description for EvaluationUI
/// </summary>
public class EvaluationUI
{
    
    public static string Breadcrumb(string Year, string Semester)
    {
        StringBuilder _sb = new StringBuilder();
        string _lblDocumentInfo = string.Empty;
        bool chkSelectedDoc = false;

        if (Year.Equals("") || Semester.Equals(""))
            _lblDocumentInfo = "โปรดเลือกเอกสารก่อน";
        else
        {
            _lblDocumentInfo = string.Format(" ปี {0} เทอม {1}", Year, Semester);
            chkSelectedDoc = true;
        }

        _sb.AppendFormat(@"<ol class='breadcrumb'>
                            <li style='cursor:pointer'><a class='btnNav2SelDoc'>ปีการศึกษาของเอกสารการประเมิน</a></li>
                            <li class='active'{1}>{0}</li>
                        </ol>"
            , _lblDocumentInfo
            , chkSelectedDoc ? " data-isdocselected=''" : ""
                              );

        return _sb.ToString();
    }
    public static string SideMenu() {
        Login _userInfo = new Login("staff");
        StringBuilder _sb = new StringBuilder();
        DataSet model = MasterDataDB.Sp_evaGetSideMenu(_userInfo.Username, _userInfo.AccessFacultyId);

        Func<string, string, bool> checkChildMenu = (menupath, parentmenu) => {
            if(!HttpContext.Current.Request.ApplicationPath.Equals("/"))
                menupath = menupath.Replace(HttpContext.Current.Request.ApplicationPath, "");
            return model.Tables[1].Select("menuPath='" + menupath + "' AND parentpath='" + parentmenu + "'").Count() > 0;
        };

        _sb.Append(@"<div class='list-group'>");
        _sb.AppendFormat(@"<a href='{0}' class='list-group-item{1}'><i class='glyphicon glyphicon-home pull-right'></i> หน้าหลัก</a>",
            (HttpContext.Current.Request.ApplicationPath.Equals("/") ? "" : HttpContext.Current.Request.ApplicationPath) + "/modules/staff/",
            HttpContext.Current.Request.FilePath.ToLower().Contains("/staff/default.aspx") ? " list-group-item-info" : "");
        foreach (DataRow _role in model.Tables[0].Rows) {
            _sb.AppendFormat("<a href='#' class='list-group-item'><strong>{0}</strong></a>", _role["roleName"].ToString());
            foreach (DataRow _menu in model.Tables[1].Select("roleid=" + _role["id"].ToString())) {
                if (_menu["show"].Equals("N")) { } //ดักเมนูที่กำหนดค่าซ่อนไว้
                else if (checkChildMenu(HttpContext.Current.Request.FilePath, _menu["parentpath"].ToString()))
                {//(HttpContext.Current.Request.FilePath.Contains(_menu["menuPath"].ToString()))
                    _sb.AppendFormat("<a href='{1}' class='list-group-item list-group-item-info' style='padding-left: 30px;'><i class='glyphicon glyphicon-minus'></i> {0}</a>",
                    _menu["menuName"].ToString(),
                    "#");

                }
                else
                {
                    _sb.AppendFormat("<a href='{1}' class='list-group-item' style='padding-left: 30px;'><i class='glyphicon glyphicon-minus'></i> {0}</a>",
                    _menu["menuName"].ToString(),
                    (HttpContext.Current.Request.ApplicationPath.Equals("/") ? "" : HttpContext.Current.Request.ApplicationPath) + _menu["menuPath"].ToString());
                    //_sb.AppendFormat("Request path: {0}, Parent menu path: {1}", HttpContext.Current.Request.FilePath, _menu["parentpath"].ToString());
                }

                
            }
        }
        _sb.Append(@"</div>");

        return _sb.ToString();
    }
    public class Staff
    {
        static Dictionary<string, string> NavMenu {
            get { 
                var _menus = new Dictionary<string, string>();
                _menus.Add("รายวิชา", "frmCourse.aspx");
                _menus.Add("แบบประเมิน", "frmEvaluation.aspx");
                _menus.Add("กำหนดเวลาทำประเมิน", "frmSetPeriod.aspx");
                _menus.Add("รายงาน", "frmReport.aspx");

                return _menus;
            }
        }
        public static string StaffContentNavBar(int TabActiveIndex, string Year, string Semester)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("<ul class='nav nav-tabs'>");
            int _index = 0;
            foreach (var item in NavMenu) {
                if(TabActiveIndex == _index)
                    _sb.AppendFormat("<li role='presentation' class='active'><a href='#'>{0}</a></li>", item.Key);
                else
                    _sb.AppendFormat("<li role='presentation'><a href='{0}?year={1}&semester={2}'>{3}</a></li>", item.Value, Year, Semester, item.Key);
                _index++;
            }
            _sb.Append("</ul>");

            return _sb.ToString();
        }
        public static string StaffContentNavBar(string PageName, string Year, string Semester)
        {
            StringBuilder _sb = new StringBuilder();
            _sb.Append("<ul class='nav nav-tabs'>");
            int _index = 0;
            foreach (var item in NavMenu)
            {
                if (item.Value == PageName)
                    _sb.AppendFormat("<li role='presentation' class='active'><a href='#'>{0}</a></li>", item.Key);
                else
                    _sb.AppendFormat("<li role='presentation'><a href='{0}?year={1}&semester={2}'>{3}</a></li>", item.Value, Year, Semester, item.Key);
                _index++;
            }
            _sb.Append("</ul>");

            return _sb.ToString();
        }
    }
    public class Subject
    {
        public static DataTable GenerateSearchListTable(DataTable _source)
        {
            DataTable _dt = new DataTable();
            _dt.Columns.Add("Id");
            _dt.Columns.Add("content");

            foreach (DataRow _sourcerow in _source.Rows)
            {
                DataRow _row = _dt.NewRow();
                StringBuilder _sb = new StringBuilder();

                string _frmSubject, _btnGroup;

                _frmSubject = string.Format(@"<span class='label label-info lblFormCount' style='cursor:pointer; padding: 5px;'>{0}</span>",
                    _sourcerow["countModule"].Equals(0) ? "n/a" : _sourcerow["countModule"] + " เงื่อนไข");

                foreach (string conditionName in _sourcerow["conditions"].ToString().Split(',')) {
                    _frmSubject += string.Format(@"<span class='label label-success lblFormCount' style='cursor:pointer; margin-left: 3px; padding: 5px;'>{0}</span>", conditionName);
                }

                _btnGroup = string.Format(@"<div class='btn-group' role='group' aria-label='...'>
                                                  <!--<button type='button' class='btn btn-xs btn-default'><span class='glyphicon glyphicon-list-alt'></span> เงื่อนไข</button>-->
                                                  <button type='button' class='btn btn-xs btn-default btnConfigTeacher'><span class='glyphicon glyphicon-user'></span> อาจารย์</button>
                                                </div>");

                _sb.AppendFormat(@" <div class='divSubject' data-subjectid='{5}'>
                                            <div>
                                                <dl class='dl-horizontal'>
                                                    <dt>รหัสรายวิชา</dt>
                                                    <dd>{0}</dd>
                                                    <dt>ชื่อรายวิชา</dt>
                                                    <dd>{1}</dd>
                                                    <dd>{2}</dd>
                                                    <dt>เงื่อนไข</dt>
                                                    <dd>{3}</dd>
                                                </dl>
                                            </div>
                                            <div class='divDetail' style='display:none;'></div>
                                            <div class='pull-right'>{4}</div>
                                        </div>",
                                _sourcerow["subjectCode"],
                                _sourcerow["subjectNameTh"],
                                _sourcerow["subjectNameEn"],
                                _frmSubject,
                                _btnGroup,
                                _sourcerow["subjectid"]
                    );

                _row["content"] = _sb.ToString();

                _dt.Rows.Add(_row);
            }

            return _dt;
        }
        public static string GenerateDropDownListItem(DataTable _source, params string[] _subjectsId) {
            StringBuilder _sb = new StringBuilder();

            foreach (DataRow _row in _source.Rows) {
                _sb.AppendFormat("<option value='{0}' data-subtext='{2}'{3}>{1}</option>", 
                    _row["subjectId"],
                    _row["subjectCode"].ToString() + " - " +
                    (string.IsNullOrEmpty(_row["subjectNameTh"].ToString()) ? _row["subjectNameEn"] : _row["subjectNameTh"]),
                    (string.IsNullOrEmpty(_row["subjectNameTh"].ToString()) ? "" : _row["subjectNameEn"]),
                    (_subjectsId.Contains(_row["subjectId"]) ? " selected='selected'" : "")
                    );
            }

            return _sb.ToString();
        }
        public static string RenderSubjectCoditionSectionList(string _acaYear, string _semester, string _formId, params string[] subjectsid) {
            StringBuilder _sb = new StringBuilder();

            var models = EvaluateDB.Sp_evaGetSubjects(subjectsid);

            foreach (DataRow _row in models.Tables[0].Rows) { 
                _sb.AppendFormat(@"<div class='row divSubject' style='margin: 5px;' data-subjectid='{3}'>
                                        <ul class='nav nav-tabs'>
                                            <li role='presentation' class='active'>
                                                <a><strong>{3}</strong> {0} - {1}</a>
                                            </li>
                                            <li role='presentation' class='active pull-right'>
                                                <a style='background-color: #c9302c; color: #fff; border-radius: 15px 15px 0 0;'>
                                                    <i class='glyphicon glyphicon-remove btnRemoveSubject'></i>
                                                </a>
                                            </li>
                                            <li role='presentation' class='active pull-right'>
                                                <a class='btnAddCondition' style='background-color: #5cb85c; color: #fff; border-radius: 15px 15px 0 0;'>
                                                    <i class='glyphicon glyphicon-plus'></i>
                                                    เพิ่มเงื่อนไข
                                                </a>
                                            </li>
                                        </ul>
                                        <div class='container-fluid divSubjectConditions nav-tabs-content'>{2}</div>
                                    </div>",
                                    _row["nameTh"],
                                    _row["nameEn"],
                                    CoditionList(_row["id"].ToString(), _acaYear, _semester, _formId),
                                    _row["codeEn"]
                                    );
            }

            return _sb.ToString();
        }
        public static string CoditionList(string _subjectId, string _acaYear, string _semester, string _formId) {
            StringBuilder _sb = new StringBuilder();

            DataTable _conditionDt = EvaluateDB.Subject.Sp_evaGetSubjectConditionList(_formId, _subjectId, _acaYear, _semester).Tables[0];

            DataTable _formInfoDt = DbConfiguration.ExecuteQuery(@"SELECT * FROM [dbo].[evaModelForm] WHERE id = @frmid",
                new SqlParameter("frmid", _formId)
            ).Tables[0];
            string modelTypeId = _formInfoDt.Rows[0]["modelTypeId"].ToString();

            StringBuilder _query = new StringBuilder();
            _query.AppendFormat(@"  SELECT  *
                                    FROM    fnc_regGetListStrInstructor(@instCode)");

            foreach (DataRow _row in _conditionDt.Rows)
            {
                _sb.Append(
                    ConditionPanel(
                        _row["conditionName"].ToString(), 
                        _row["expression"].ToString(), 
                        _row["userInput"].ToString(),
                        DbConfiguration.ExecuteQuery(_query.ToString(), new SqlParameter("instCode", _row["instructors"])).Tables[0],
                        modelTypeId.Equals("TYS002")
                    )
                );
            }


            return _sb.ToString();
        }
        public static string ConditionPanel(string _conditionName, string _content, string _userinput, DataTable _instructors, bool IsTeacherEvaluate)
        {
            StringBuilder _sb = new StringBuilder();
            string _conditionStr = string.Empty;

            DataTable _userinputDt = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(_userinput);

            _sb.Append("<div class='container-fluid divCondition' style='margin-top:5px;'>");
            _sb.Append("    <div class='panel panel-default'>");
            _sb.Append("        <div class='panel-heading'>");
            _sb.AppendFormat("      <h3 class='panel-title'>{0}</h3>", _conditionName);
            _sb.Append("        </div>");
            _sb.Append("        <div class='panel-body'>");
            _sb.Append("            <h4>รายละเอียดผู้ประเมิน</h4>");
            _sb.Append("                <ul>");

            foreach (DataRow _row in _userinputDt.Rows)
            {
                _conditionStr += "          <li>";
                _conditionStr += string.Format("<div style='padding-left: 10px; padding-top: 0px; margin-top: 0px;'>{0}</div>", _row["parameter"]);
                _conditionStr += string.Format("<div style='padding-left: 10px; padding-top: 0px; margin-top: 0px;'>{0}</div>", _row["value"]);
                _conditionStr += "          </li>";
            }

            _sb.Append(string.IsNullOrEmpty(_conditionStr) ? "<li><div style='padding-left: 10px; padding-top: 0px; margin-top: 0px;'>ทุกคน</div></li>" : _conditionStr);
            _sb.Append("                </ul>");

            if (IsTeacherEvaluate)
            {
                _sb.Append("            <div class='containner-fluid'>");
                _sb.Append("            <h4>รายละเอียดอาจารย์</h4>");
                _sb.Append("                <ul>");

                foreach (DataRow _row in _instructors.Rows)
                {
                    _sb.Append("                <li>");
                    _sb.AppendFormat("              <div style='padding-left: 10px; padding-top: 0px; margin-top: 0px;'>{0}</div>", _row["instructorTFullName"]);
                    _sb.AppendFormat("              <div style='display: inline-block; padding-left: 10px; font-size: 10px; padding-top: 0px; margin-top: 0px;'>{0}</div>", _row["instructorEFullName"]);
                    _sb.Append("                </li>");
                }

                _sb.Append("                </ul>");
                _sb.Append("            </div>");
            }
            
            _sb.Append("        </div>");
            _sb.Append("    </div>");
            _sb.Append("</div>");

            return _sb.ToString();
        }
        public static string CreateConditionPanel(string _formId, string _subjectId, string _acaYear, string _semester) {
            DataTable _formInfoDt = DbConfiguration.ExecuteQuery(@"SELECT * FROM [dbo].[evaModelForm] WHERE id = @frmid",
                new SqlParameter("frmid", _formId)
            ).Tables[0];
            string modelTypeId = _formInfoDt.Rows[0]["modelTypeId"].ToString();

            StringBuilder _sb = new StringBuilder();

            DataTable _sectionList = EvaluateDB.Subject.Sp_evaGetSubjectSectionList(_subjectId, _acaYear, _semester).Tables[0];
            DataTable _instructorList = EvaluateDB.Subject.Sp_evaGetListSubjectInstructors(_subjectId, _acaYear, _semester).Tables[0];

            _sb.Append(@"<div class='row divCondition'>");
            _sb.Append(@"   <div class='container-fluid'>");
            _sb.Append(@"       <div class='row'>");
            _sb.Append(@"           <input type='text' class='form-control input-lg no-border txtConditionName' placeholder='เงื่อนไข' />");
            _sb.Append(@"       </div>");
            _sb.Append(@"       <div class='container-fluid divCase'>");
            _sb.Append(@"           <input type='checkbox' class='chkActiveCase checkAll' /> ทุกคน");
            _sb.Append(@"       </div>");
            _sb.Append(@"       <div class='container-fluid divCase'>");
            _sb.Append(@"           <input type='checkbox' class='chkActiveCase' data-parameter='@sectionId' /> กำหนดโดยกลุ่มเรียน");
            _sb.Append(@"           <select class='form-control ddlSections caseValue ddlSelectPicker' title='กลุ่มเรียน' multiple>");

            foreach(DataRow _section in _sectionList.Rows)
                _sb.AppendFormat(@"     <option value='{0}' data-subtext='{2}'>{1}</option>", _section["id"], _section["section"], _section["remark"]);

            _sb.Append(@"           </select>");
            _sb.Append(@"       </div>");
            _sb.Append(@"       <div class='container-fluid divCase'>");
            _sb.Append(@"           <input type='checkbox' class='chkActiveCase' data-parameter='@studentCode' /> กำหนดโดยรหัสนักศึกษา");
            _sb.Append(@"           <input type='text' class='form-control txtStudentId caseValue' placeholder='ตัวอย่าง: ระบุเป็นช่วง 59218335-59218340 หรือ เป็นรายการ 59889964, 59889973' />");
            _sb.Append(@"       </div>");

            if (modelTypeId.Equals("TYS002"))
            {
                _sb.Append(@"       <div class='container-fluid divInstructors'>");
                _sb.Append(@"       <ul style='padding-left: 16px;padding-top: 10px;'>");
                _sb.Append(@"           <li>กำหนดรายชื่ออาจารย์ที่จะประเมิณ</li>");
                _sb.Append(@"       </ul>");
                _sb.Append(@"           <select class='form-control ddlInstructors caseValue ddlSelectPicker' title='รายชื่ออาจารย์ผู้สอน' multiple>");

                foreach(DataRow _instructor in _instructorList.Rows)
                    _sb.AppendFormat(@"     <option value='{0}'>{1}</option>", _instructor["instructorId"], _instructor["instructorName"]);
                    

                _sb.Append(@"           </select>");
                _sb.Append(@"       </div>");
            }

            _sb.Append(@"       <hr/>");
            _sb.Append(@"       <div class='container-fluid'>");
            _sb.Append(@"           <div class='pull-right' style='padding-bottom: 15px;'>");
            _sb.Append(@"               <button class='btn btn-success btnSave'><i class='glyphicon glyphicon-save'></i></button>");
            _sb.Append(@"               <button class='btn btn-danger btnRemove'><i class='glyphicon glyphicon-remove'></i></button>");
            _sb.Append(@"           </div>");
            _sb.Append(@"       </div>");
            _sb.Append(@"   </div>");
            _sb.Append(@"</div>");

            return _sb.ToString();
        }
        
        public static string GenerateTeacherList(string _subjectId, string _acaYear, string _semester) {
            StringBuilder _sb = new StringBuilder();

            DataTable _teachersDt = EvaluateDB.Subject.Sp_evaGetListSubjectInstructors(_subjectId, _acaYear, _semester).Tables[0];

            _sb.Append("<ul>");

            foreach (DataRow _row in _teachersDt.Rows) {
                _sb.AppendFormat("<li>{0}</li>", _row["instructorName"]);
            }

            _sb.Append("</ul>");

            return _sb.ToString();
        }

#region frmSetPeriod.aspx
        public static string GenerateSubjectsList(string _acaYear, string _semester, params string[] _subjectid) {
            StringBuilder _sb = new StringBuilder();

            var models = EvaluateDB.Sp_evaGetSubjects(_subjectid);

            foreach (DataRow subject in models.Tables[0].Rows) { 
                _sb.AppendFormat("<div class='row divSubject' data-subjectid='{0}'>", subject["id"]);
                _sb.AppendFormat("<h4 style='border-bottom: 1px solid #000; display:inline-block;'>{0} - {1}</h4>", subject["nameTh"], subject["nameEn"]);
                _sb.Append("    <hr style='margin: 5px auto;' />");
                _sb.Append("    <div class='container-fluid divEvaluates' style='margin: 0px; padding: 0px;'>");
                _sb.Append("        <div style='text-align: center;'>Loading</div>");
                _sb.Append("    </div>");
                _sb.Append("</div>");
            }

            return _sb.ToString();
        }
        public static string RenderEvaluateWithCondition(string _acaYear, string _semester, string _subjectid) {
            StringBuilder _sb = new StringBuilder();

            var model = EvaluateDB.Evaluate.Sp_evaGetFormAndCondition(_acaYear, _semester, _subjectid);

            _sb.Append("<ul>");
            foreach (DataRow _form in model.Tables[0].Rows) {
                _sb.AppendFormat("<li>{0} - {1}",  _form["id"], _form["modelNameTh"]);
                var _conditions = model.Tables[1].Select("frmId = '" + _form["id"] + "'");

                if (_conditions.Count() > 0)
                {
                    _sb.Append("<ul>");
                    foreach (DataRow _condition in _conditions)
                    {
                        _sb.AppendFormat("<li data-id='{1}'>{0} <b>{2}</b></li>", _condition["conditionName"],
                            _condition["id"],
                            (_condition["startDate"] == DBNull.Value && _condition["endDate"] == DBNull.Value ? 
                                "" : 
                                string.Format("[{0} ถึง {1}]",
                                    _condition["startDate"] == DBNull.Value ? "วันนี้" : ((DateTime)_condition["startDate"]).ToString("dd/MM/yyyy HH:mm", CultureInfo.GetCultureInfo("th-TH")),
                                    _condition["endDate"] == DBNull.Value ? "วันนี้" : ((DateTime)_condition["endDate"]).ToString("dd/MM/yyyy HH:mm", CultureInfo.GetCultureInfo("th-TH"))
                                )
                            )
                        );
                    }
                    _sb.Append("</ul>");
                }

                _sb.Append("</li>");
            }
            _sb.Append("</ul>");

            return _sb.ToString();
        }
#endregion
    }
    public class Evaluate {
        public static string GetListQuestion(string _year, string _semester, string _modelTypeId) {
            return GetListQuestion(_year, _semester, _modelTypeId, "", null);
        }
        public static string GetListQuestion(string _year, string _semester, string _modelTypeId, DataSet _customQuestionDs)
        {
            return GetListQuestion(_year, _semester, _modelTypeId, "", _customQuestionDs);
        }
        public static string GetListQuestion(string _year, string _semester, string _modelTypeId, string frmId = "", DataSet _customQuestionDs = null) {
            DataSet model = EvaluateDB.Sp_evaGetListFormQuestionDefault(_year, _semester, _modelTypeId);
            DataTable _questionDt = model.Tables[0];
            bool isPublish = EvaluateDB.CheckEvaluateIsPublish(frmId);

            if (_customQuestionDs != null)
            {
                foreach (DataRow _customQuestionRow in _customQuestionDs.Tables[0].Rows)
                {
                    DataRow _newRow = model.Tables[0].NewRow();

                    foreach (DataColumn _customQuestionColumn in _customQuestionDs.Tables[0].Columns) {
                        _newRow[_customQuestionColumn.ColumnName] = _customQuestionRow[_customQuestionColumn.ColumnName] == null ? DBNull.Value : _customQuestionRow[_customQuestionColumn.ColumnName];
                    }

                    model.Tables[0].Rows.Add(_newRow);
                }

                _questionDt = model.Tables[0].OrderBy(new Orderer() { key = "keyCode", direction = SortDirection.Ascending });
            }

            StringBuilder _result = new StringBuilder();

            _result.Append("<div class='list-group'>");
            foreach (DataRow _row in _questionDt.Rows)
            {
                string _elementQuestion = string.Empty;
                switch (_row["questionTypeId"].ToString())
                {
                    case "TYQ001": _elementQuestion = 
                        Question.Ranking(
                        _row["questionTName"].ToString(), 
                        _row["questionEName"].ToString(), 
                        int.Parse(_row["rankMax"].ToString()),
                        _row["isNA"].ToString()); 
                        break;

                    case "TYQ002": _elementQuestion = Question.MultiChoice(_row["id"].ToString(),
                        _row["questionTName"].ToString(),
                        _row["questionEName"].ToString(),
                        _row["answerXML"].ToString());
                        //_row["id"].ToString().StartsWith("FQA") ?
                        //Question.MultiChoice(_row["id"].ToString(), 
                        //_row["questionTName"].ToString(),
                        //_row["questionEName"].ToString(),
                        //_row["answerXML"].ToString()) :
                        //""; 
                        break;

                    case "TYQ003": _elementQuestion = 
                        Question.RadioChoice(_row["id"].ToString(), 
                        _row["questionTName"].ToString(),
                        _row["questionEName"].ToString(),
                        _row["answerXML"].ToString()); 
                        break;

                    case "TYQ004": _elementQuestion = 
                        Question.TextQuestion(_row["questionTName"].ToString(),
                        _row["questionEName"].ToString()); 
                        break;

                    case "TYQ005": _elementQuestion = 
                        Question.TextTitle(_row["questionTName"].ToString(),
                        _row["questionEName"].ToString());
                        break;

                    default: break;
                }
                
                _result.AppendFormat("<a class='list-group-item {1} default-question' data-keycode='{2}' data-question-type-id='{3}' data-question-id='{4}'><div class='row'>{0}</div></a>", 
                    _elementQuestion,

                    //hight light สีสำหรับหรับประเภท Text title.
                    _row["questionTypeId"].ToString() == "TYQ005" ? "divTextTitle alert-warning" : "",
                    _row["keyCode"].ToString(),
                    _row["questionTypeId"].ToString(),
                    _row["id"].ToString()
                );
            }

            //_result.Append(_customQuestion);
            _result.Append("</div>");

            return _result.ToString();
        }
        public static string RenderEditableQuestion(string _frmId) {
            StringBuilder _sb = new StringBuilder();

            var _formInfo = EvaluateDB.Evaluate.getEvaluateInfo(_frmId);
            DataSet _defaultQuestion = EvaluateDB.Sp_evaGetListFormQuestionDefault(_formInfo["acaYear"].ToString(), _formInfo["semester"].ToString(), _formInfo["modelTypeId"].ToString());
            DataSet _customQuestion = EvaluateDB.Sp_evaGetListFormQuestionFaculty(_frmId);
            DataTable _questionDt = new DataTable();

            foreach (DataRow _customQuestionRow in _customQuestion.Tables[0].Rows) {
                DataRow _appendRow = _defaultQuestion.Tables[0].NewRow();

                foreach (DataColumn _customQuestionColumn in _customQuestion.Tables[0].Columns)
                    _appendRow[_customQuestionColumn.ColumnName] = _customQuestionRow[_customQuestionColumn.ColumnName];

                _defaultQuestion.Tables[0].Rows.Add(_appendRow);
            }

            _questionDt = _defaultQuestion.Tables[0].OrderBy(new Orderer() { key = "keyCode", direction = SortDirection.Ascending });
            _sb.Append("<div class='list-group'>");
            foreach (DataRow _question in _questionDt.Rows) {
                if (_question["id"].ToString().StartsWith("MQA"))
                {
                    string _questionElement = string.Empty;

                    switch (_question["questionTypeId"].ToString())
                    {
                        case "TYQ001": _questionElement = Question.Ranking(
                                _question["questionTName"].ToString(),
                                _question["questionEName"].ToString(), 
                                int.Parse(_question["rankMax"].ToString()),
                                _question["isNA"].ToString()); 
                            break;
                        case "TYQ002":
                            _questionElement = Question.MultiChoice(
                                _question["id"].ToString(),
                                _question["questionTName"].ToString(),
                                _question["questionEName"].ToString(),
                                _question["answerXML"].ToString());
                            break;
                        case "TYQ003":
                            _questionElement = Question.RadioChoice(
                                _question["id"].ToString(),
                                _question["questionTName"].ToString(),
                                _question["questionEName"].ToString(),
                                _question["answerXML"].ToString()); 
                            break;
                        case "TYQ004":
                            _questionElement = Question.TextQuestion(
                                _question["questionTName"].ToString(),
                                _question["questionEName"].ToString()); 
                            break;
                        case "TYQ005":
                            _questionElement = Question.TextTitle(
                                _question["questionTName"].ToString(),
                                _question["questionEName"].ToString());
                            break;
                        default: break;
                    }

                    _sb.AppendFormat("<a class='list-group-item default-question {4}' data-questiontype-id='{1}' data-question-id='{2}' data-keycode='{3}'><div class='row'>{0}</div></a>", 
                        _questionElement,
                        _question["questionTypeId"],
                        _question["id"],
                        _question["keyCode"],
                        _question["questionTypeId"].ToString() == "TYQ005" ? "divTextTitle alert-warning" : ""
                        );
                }
                else
                {
                    Dictionary<string, object> _jsonInfo = new Dictionary<string, object>();
                    foreach (DataColumn _col in _question.Table.Columns)
                        switch (_col.ColumnName)
                        {
                            case "answerXML": 
                                _jsonInfo.Add(_col.ColumnName, 
                                    Newtonsoft.Json.JsonConvert.SerializeObject(DbConfiguration.XMLTextToDataSet(_question["answerXML"].ToString())));
                                    break;
                            default: _jsonInfo.Add(_col.ColumnName, _question[_col.ColumnName]); 
                                break;
                        }

                    string _element = string.Empty;

                    switch (_question["questionTypeId"].ToString())
                    {
                        case "TYQ005": _element = Question.CustomTextTitle(); break;
                        default: _element = Question.CustomQuestionPanel(); break;
                    }

                    _sb.AppendFormat("<a class='list-group-item custom-question-panel' data-json='{1}'><div class='row'>{0}</div></a>",
                        _element,
                        Newtonsoft.Json.JsonConvert.SerializeObject(_jsonInfo)
                    );
                }
            }
            _sb.Append("</div>");
            
            return _sb.ToString();
        }
        public static string RenderCustomQuestion(string _questionContent, bool _isTitle = false) {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendFormat("<a class='list-group-item {1}'><div class='row'>{0}</div></a>",
                    _questionContent, _isTitle ? "alert-warning" : ""
                );

            return _sb.ToString();
        }
        public static string ListAvaliableEvaluate(string _evaType) {
            StringBuilder _sb = new StringBuilder();
            Login _login = new Login("student");
            DataSet model = EvaluateDB.Evaluate.Sp_evaStudentListForm(_login.StudentId);
            DataRow[] _evaluateList = model.Tables[0].Select("modelTypeId='" + _evaType + "'");

            if (_evaluateList.Length > 0)
            {
                //_sb.Append("<ul>");
                foreach (DataRow _row in _evaluateList)
                {
                    string _image = string.Empty;
                    string _lblName = _row["subjectId"] + " - " + _row["nameEn"] + "(" + _row["conditionName"] + ")";
                    StringBuilder _urlParam = new StringBuilder();
                    _urlParam.AppendFormat(@"frmid={0}&conid={1}&insid={2}", _row["frmId"], _row["conditionId"], _row["instructorId"]);

                    if(_row["modelTypeId"].Equals("TYS002")){
                        _image = string.Format(" data-image-path='{0}'", _row["instructorPhoto"]);
                        _lblName = _row["subjectId"] + " - " + _row["nameEn"] + " (" + _row["conditionName"] + ") - " + _row["instructorEFullName"];
                    }
                    _sb.AppendFormat("<div class='divEvaluate'>{2}<a href='{3}' target='_self' style='margin-left: 5px;'{0}>{1}</a></div>"
                        , _image
                        , _lblName
                        , (int)_row["IsDone"] == 1 ? "<i class='glyphicon glyphicon-check alert-success'></i>" : "<i class='glyphicon glyphicon-unchecked'></i>"
                        , "frmEvaluation.aspx?f=" + Utility.StringEncryption(_urlParam.ToString()));//((int)_row["IsDone"] == 1 ? "frmViewEvaluation.aspx?f=" : "frmEvaluation.aspx?f=") + Utility.StringEncryption(_urlParam.ToString()));
                }
                //_sb.Append("</ul>");
            }
            else
                _sb.Append("<div class='text-center'><h4>ไม่มีรายการแบบประเมิน</h4></div>");

            return _sb.ToString();
        }
    }
    public class Question {
        public static string TextTitle(string _questionStrTh, string _questionStrEn) {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendFormat("<div class='col-sm-9'>{0}<p>{1}</p></div>",_questionStrTh, _questionStrEn);

            return _sb.ToString();
        }
        public static string Ranking(string _questionStrTh, string _questionStrEn, int _maxScore, string isNA) {
            StringBuilder _sb = new StringBuilder();
            string _scoreButtonGroup = string.Empty;

            _scoreButtonGroup = "<div class='btn-group pull-right' data-toggle='buttons'>";
            for (int index = _maxScore; index >= 1; index--)
            {
                _scoreButtonGroup += string.Format(@"   <label class='btn btn-default btnRank' data-btn-active='{1}' data-value='{0}'>
                                                            <input type='radio' name='rdoEvaType' id='option1'>{0}
                                                        </label>"
                                                , index
                                                , Math.Ceiling(((decimal)_maxScore / 2)) == index ? "btn-warning" :
                                                (Math.Ceiling(((decimal)_maxScore / 2)) < index ? "btn-success" : "btn-danger"));
            }
            
            if(isNA.Equals("Y"))
                _scoreButtonGroup += string.Format(@"   <label class='btn btn-warning active btnRank' data-btn-active='btn-warning' data-value='{0}'>
                                                            <input type='radio' name='rdoEvaType' id='option1'>{0}
                                                        </label>", "N/A");
            _scoreButtonGroup += "</div>";

            _sb.AppendFormat("<div class='col-sm-12' style='padding-left:50px;'>{0}<p>{1}</p></div><div class='col-sm-12 pull-right'>{2}</div>",
                _questionStrTh,
                _questionStrEn,
                _scoreButtonGroup
                );

            return _sb.ToString();
        }
        public static string MultiChoice(string id, string _questionStrTh, string _questionStrEn, string _answerText)
        {
            DataSet _ds = DbConfiguration.XMLTextToDataSet(_answerText);
            Func<string, string, string> CreateLabel = (strTh, strEn) =>
            {
                return string.Format(@"<div>{0}<div>{1}</div></div>", strTh, strEn);
            };
            Func<string, string, string> CreateTextField = (strTh, strEn) =>
            {
                return string.Format(@"<input type='text' class='form-control input-sm' placeholder='{0} {1}' disabled />", strTh, strEn);
            };
            StringBuilder _chkGroup = new StringBuilder();

            _chkGroup.Append("<div style='margin-left:20px;'>");
            if (_ds.Tables.Count > 0)
                foreach (DataRow _row in _ds.Tables[0].Rows) {
                    _chkGroup.AppendFormat(@"<div class='checkbox'>
                                                <label>
                                                    <input type='checkbox' name='{2}' value='{0}'>{1}
                                                </label>
                                            </div>"
                                            , _row["id"]
                                            , _row["isRemark"].Equals("Y") ?
                                            CreateTextField(_row["choiceSubNameTh"].ToString(), _row["choiceSubNameEn"].ToString()) :
                                            CreateLabel(_row["choiceSubNameTh"].ToString(), _row["choiceSubNameEn"].ToString())
                                            , id);
                }
            _chkGroup.Append("</div>");

            StringBuilder _sb = new StringBuilder();

            _sb.AppendFormat("<div class='col-sm-12'>{0}<p>{1}</p><div>{2}</div></div>", 
                _questionStrTh, 
                _questionStrEn, 
                _chkGroup.ToString()
            );

            return _sb.ToString();
        }
        public static string RadioChoice(string id, string _questionStrTh, string _questionStrEn, string _answerText)
        {
            DataSet _ds = DbConfiguration.XMLTextToDataSet(_answerText);
            Func<string, string, string> CreateLabel = (strTh, strEn) =>
            {
                return string.Format(@"<div>{0}<div>{1}</div></div>", strTh, strEn);
            };
            Func<string, string, string> CreateTextField = (strTh, strEn) =>
            {
                return string.Format(@"<input type='text' class='form-control input-sm' placeholder='{0} {1}' disabled />", strTh, strEn);
            };
            StringBuilder _rdbGroup = new StringBuilder();

            _rdbGroup.Append("<div style='margin-left:20px;'>");
            if(_ds.Tables.Count > 0)
                foreach (DataRow _row in _ds.Tables[0].Rows)
                {
                    _rdbGroup.AppendFormat(@"<div class='radio'>
                                                <label>
                                                    <input type='radio' name='{2}' value='{0}'>{1}
                                                </label>
                                            </div>"
                                            , _row["id"]
                                            , _row["isRemark"].Equals("Y") ?
                                            CreateTextField(_row["choiceSubNameTh"].ToString(), _row["choiceSubNameEn"].ToString()) :
                                            CreateLabel(_row["choiceSubNameTh"].ToString(), _row["choiceSubNameEn"].ToString())
                                            , id);
                }
            _rdbGroup.Append("</div>");

            StringBuilder _sb = new StringBuilder();

            _sb.AppendFormat("<div class='col-sm-12'>{0}<p>{1}</p><div>{2}</div></div>", 
                _questionStrTh, 
                _questionStrEn,
                _rdbGroup.ToString());

            return _sb.ToString();
        }
        public static string TextQuestion(string _questionStrTh, string _questionStrEn)
        {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendFormat("<div class='col-sm-12'>{0}<p>{1}</p><div style='margin-left: 20px;'><textarea class='form-control' disabled></textarea></div></div>", _questionStrTh, _questionStrEn);

            return _sb.ToString();
        }
        public static string CustomQuestionPanel() {
            StringBuilder _sb = new StringBuilder();

            // หัวข้อคำถามชื่อคำถามภาษาไทย อังกฤษ
            _sb.Append(@"<div class='row' style='margin-bottom: 10px;'>
                            <div class='col-sm-8'>
                                <input type='text' class='form-control input-lg no-border txtQuestionTitleTh' placeholder='หัวข้อคำถาม' />
                                <input type='text' class='form-control input-lg no-border txtQuestionTitleEn' placeholder='Question title' />
                            </div>
                            <div class='col-sm-4'>
                                <select class='selectpicker show-tick'  data-style='btn-info' data-header='เลือกประเภทคำถาม' style=''>
                                    <option value='TYQ003' data-question-type='.divMultipleChoice' data-subtext='Multiple choices'>ตัวเลือก</option>
                                    <option value='TYQ002' data-question-type='.divCheckboxes' data-subtext='Checkboxes'>เลือกได้มากกว่าหนึง</option>
                                    <option data-divider='true'></option>
                                    <option value='TYQ001' data-question-type='.divArrayRank' data-subtext='Linear scale'>น้ำหนัก</option>
                                    <option data-divider='true'></option>
                                    <option value='TYQ004' data-question-type='.divOpenText' data-subtext='Open text'>คำถามปลายเปิด</option>
                                </select>
                            </div>
                        </div>");

            // แผลงเนื้อหาคำถาม
            _sb.Append(@"<div class='row' style='margin-left:15px;'>");

            // แผลงคำถามประเภทตัวเลือก
            _sb.Append(@"   <div class='col-sm-12 question-panel divMultipleChoice active'>
                                <div class='row divAddOption'>
                                    <input type='radio' name='rdbNewQuestion' />
                                    <input type='text' class='no-border addOption' style='width:70px;' placeholder='เพิ่มตัวเลือก' />
                                    <span class='addOther'>
                                        &nbsp;Or&nbsp;
                                        <span style='cursor:pointer;color:blue;'>เพิ่มอื่นๆ</span>
                                    </span>
                                </div>
                            </div>");

            // แผลงคำถามประเภทเลือกได้มากกว่า 1 ตัวเลือก
            _sb.Append(@"   <div class='col-sm-12 question-panel divCheckboxes' style='display:none;'>
                                <div class='row divAddOption'>
                                    <input type='checkbox' name='chkNewQuestion' />
                                    <input type='text' class='no-border addOption' style='width:70px;' placeholder='เพิ่มตัวเลือก' />
                                    <span class='addOther'>
                                        &nbsp;Or&nbsp;
                                        <span style='cursor:pointer;color:blue;'>เพิ่มอื่นๆ</span>
                                    </span>
                                </div>
                            </div>");

            // แผลงคำถามประเภทน้ำหนักคะแนน
            _sb.Append(@"   <div class='col-sm-12 question-panel divArrayRank' style='display:none;'>
                                <div class='row'>
                                    <div class='form-group col-sm-2'>
                                        <div class='col-sm-12'>
                                            <select class='form-control no-border input-sm selMaxRange'>
                                                <option value='1'>คะแนนสูงสุด</option>
                                                <option value='1'>1</option>
                                                <option value='2'>2</option>
                                                <option value='3'>3</option>
                                                <option value='4'>4</option>
                                                <option value='5' selected>5</option>
                                                <option value='6'>6</option>
                                                <option value='7'>7</option>
                                                <option value='8'>8</option>
                                                <option value='9'>9</option>
                                                <option value='10'>10</option>
                                            </select>
                                        </div>
                                        <div class='col-sm-12'>
                                            <input type='checkbox' class='chkIsNA' /> N/A
                                            <!--<label class='col-sm-2'>N/A</label>
                                            <div class='col-sm-9'>
                                                <div class='btn-group' data-toggle='buttons'>
                                                    <label class='btn btn-success btnNA btn-on btn-xs active' data-btn-active='btn-success'>
                                                    <input type='radio' value='1' name='rdbNA' checked='checked'>ON</label>
                                                    <label class='btn btn-default btnNA btn-off btn-xs' data-btn-active='btn-danger'>
                                                    <input type='radio' value='0' name='rdbNA'>OFF</label>
                                                </div>
                                            </div>-->
                                        </div>
                                    </div>
                                    <div class='col-sm-10 divScoreGroup' style='border-left: 0.1px solid gray;'>&nbsp;</div>
                                </div>
                            </div>");

            // แผลงคำถามปลายเปิด
            _sb.Append(@"   <div class='col-sm-12 question-panel divOpenText' style='display:none;'>
                                <div class='container'>
                                    <textarea class='form-control no-border' placeholder='คำตอบ' rows='1' disabled></textarea>
                                </div>
                            </div>
                            <div class='col-sm-12'>
                                <hr/>
                                <div class='btn-toolbar pull-right'>
                                    <div class='btn-group' style='margin-right: 10px;'>
                                        <div class='btn btn-info btnDuplicate'><span class='glyphicon glyphicon-duplicate'></span></div>
                                    </div>
                                    <div class='btn-group' style='margin-right: 10px;'>
                                        <div class='btn btn-danger btnRemove'><span class='glyphicon glyphicon-trash'></span></div>
                                    </div>
                                </div>
                            </div>");

            _sb.Append(@"</div>");

            return _sb.ToString();
        }
        public static string CustomTextTitle() {
            StringBuilder _sb = new StringBuilder();

            _sb.AppendFormat(@" <div class='row divTextTitle active'>
                                    <div class='col-sm-9'>{0}<p>{1}</p></div>
                                    <div class='col-sm-12'>{2}</div>
                                </div>",
                                "<input type='text' class='form-control no-border input-lg txtQuestionTitleTh' placeholder='หัวข้อคำถาม' />",
                                "<input type='text' class='form-control no-border input-lg txtQuestionTitleEn' placeholder='Question title' />",
                                @"<hr/>
                                <div class='btn-toolbar btn-group pull-right' style='margin-right: 10px;'>
                                    <div class='btn btn-danger btnRemove'><span class='glyphicon glyphicon-trash'></span></div>
                                </div>");

            return _sb.ToString();
        }
        public static string CustomRanking(int MaxRange, bool isNotAvalible = true)
        {
            StringBuilder _sb = new StringBuilder();

            _sb.Append("<div class='pull-right'>");
            _sb.Append("<input type='text' class='no-border text-right' value='มากสุด' style='margin-right:5px;width:100px;' />");
            _sb.Append("<div class='btn-group' data-toggle='buttons'>");

            for (int i = MaxRange; i > 0; i--) {
                _sb.Append("<label class='btn btn-default btnRank' data-btn-active='btn-success'>");
                _sb.AppendFormat("<input type='radio' name='rdoEvaType' id='option1'>{0}", i);
                _sb.Append("</label>");
            }

            if (isNotAvalible)
            {
                _sb.Append("<label class='btn btn-warning btnRank' data-btn-active='btn-warning'>");
                _sb.AppendFormat("<input type='radio' name='rdoEvaType' id='option1'> N/A");
                _sb.Append("</label>");
            }

            _sb.Append("</div>");
            _sb.Append("<input type='text' class='no-border' value='น้อยสุด' style='margin-left:5px;width:100px;' />");
            _sb.Append("</div>");

            return MaxRange == 0 ? "" : _sb.ToString();
        }
        public static string CustomRadiobuttonOption() {
            StringBuilder _sb = new StringBuilder();

            _sb.Append(@"<div class='row divOption'>
                            <input type='radio' name='rdbNewQuestion'>
                            <input type='text' class='no-border txtOptionDescriptTh' placeholder='Option 1'>
                            <span class='glyphicon glyphicon-remove btnRemove'></span>
                        </div>");

            return _sb.ToString();
        }
        public static string CustomCheckboxOption() {
            StringBuilder _sb = new StringBuilder();

            _sb.Append(@"<div class='row divOption'>
                            <input type='checkbox' name='chkNewQuestion'>
                            <input type='text' class='no-border txtOptionDescriptTh' placeholder='Option 1'>
                            <span class='glyphicon glyphicon-remove btnRemove'></span>
                        </div>");

            return _sb.ToString();
        }
    }
}