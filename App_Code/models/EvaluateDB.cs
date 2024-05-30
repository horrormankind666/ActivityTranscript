using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for EvaluateDB
/// </summary>
public class EvaluateDB
{
	public EvaluateDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static DataSet GetListEvaluate(string _year, string _semester, string _facultyId, string _evaluateType) 
    {
        return DbConfiguration.ExecuteQuery(
            "Select * From fnc_evaGetListForm(@year, @semester, @facultyId, @evaluateType)",
            new SqlParameter("year", _year),
            new SqlParameter("semester", _semester),
            new SqlParameter("facultyId", _facultyId),
            new SqlParameter("evaluateType", _evaluateType)
        );
    }
    public static DataSet Sp_evaGetListFormQuestionDefault(string _year, string _semester, string _modelTypeId)
    {
        return DbConfiguration.ExecuteQuery("sp_evaGetListFormQuestionDefault", CommandType.StoredProcedure,
                new SqlParameter("acaYear", _year),
                new SqlParameter("semester", _semester),
                new SqlParameter("modelTypeId", _modelTypeId)
            );
    }
    public static Dictionary<string, object> Get_EvaluateInfo(string id)
    {
        DataTable _dt = DbConfiguration.ExecuteQuery(@"SELECT * FROM [dbo].[evaModelForm] WHERE id = @id",
                new SqlParameter("id", id)
            ).Tables[0];

        Dictionary<string, object> _result = new Dictionary<string, object>();
        foreach (DataColumn _col in _dt.Columns) {
            _result.Add(_col.ColumnName, _dt.Rows[0][_col.ColumnName]);
        }

        return _result;
    }
    public static DataSet Sp_evaGetListFormQuestionFaculty(string id) 
    {
        return DbConfiguration.ExecuteQuery(@"sp_evaGetListFormQuestionFaculty", 
            CommandType.StoredProcedure,
            new SqlParameter("id", id)
            );
    }
    public static DataSet Sp_evaGetSubjects(params string[] _subjectsId)
    {
        DataTable _dt = new DataTable();
        _dt.Columns.Add("key");
        foreach (string id in _subjectsId)
            _dt.Rows.Add(id);

        SqlParameter _sqlParamSubjectsId = new SqlParameter();
        _sqlParamSubjectsId.ParameterName = "tbl_subjectId";
        _sqlParamSubjectsId.SqlDbType = SqlDbType.Structured;
        _sqlParamSubjectsId.Value = _dt;

        return DbConfiguration.ExecuteQuery("sp_evaGetSubjects", CommandType.StoredProcedure, _sqlParamSubjectsId);
    }
    public static bool CheckEvaluateIsPublish(string id) 
    {
        return DbConfiguration.ExecuteScalar(@"   SELECT CASE WHEN
                                                    EXISTS(
                                                        SELECT id
                                                        FROM [dbo].[evaGroupSchedule] 
                                                        WHERE frmId = @frmid
                                                    ) THEN 1 ELSE 0 END",
                                            new SqlParameter("frmid", id)) == "1";
    }
    public class Subject {
        public static DataSet Sp_evaGetSubjectSectionList(string _subjectId, string _acaYear, string _semester) {
            return DbConfiguration.ExecuteQuery(
                "sp_evaGetSubjectSectionList", 
                CommandType.StoredProcedure, 
                new SqlParameter("subjectId", _subjectId),
                new SqlParameter("acaYear", _acaYear),
                new SqlParameter("semester", _semester)
                );
        }
        public static DataSet Sp_evaGetSubjectConditionList(string _formId, string _subjectId, string _acaYear, string _semester)
        {
            return DbConfiguration.ExecuteQuery("sp_evaGetSubjectConditionList", CommandType.StoredProcedure,
                    new SqlParameter("formid", _formId),
                    new SqlParameter("subjectid", _subjectId),
                    new SqlParameter("acaYear", _acaYear),
                    new SqlParameter("semester", int.Parse(_semester))
                );
        }
        public static DataSet Sp_evaGetListSubjectInstructors(string _subjectId, string _acaYear, string _semester) { 
            return DbConfiguration.ExecuteQuery("sp_evaGetListSubjectInstructors", CommandType.StoredProcedure,
                    new SqlParameter("subjectId", _subjectId),
                    new SqlParameter("acaYear", _acaYear),
                    new SqlParameter("semester", _semester)
                );
        }
    }
    public class Evaluate {
        public static DataSet Sp_evaGetFormAndCondition(string _acaYear, string _semester, string _subjectId) { 
            return DbConfiguration.ExecuteQuery("sp_evaGetFormAndCondition", CommandType.StoredProcedure,
                    new SqlParameter("acaYear", _acaYear),
                    new SqlParameter("semester", int.Parse(_semester)),
                    new SqlParameter("subjectid", _subjectId)
                );
        }
        public static string Sp_evaSetForm(params SqlParameter[] parameter)
        {
            DataSet _ds = DbConfiguration.ExecuteQuery("[dbo].[sp_evaSetForm]", CommandType.StoredProcedure, parameter);

            Dictionary<string, object> _json = new Dictionary<string, object>();

            foreach (DataColumn _col in _ds.Tables[0].Columns)
                _json.Add(_col.ColumnName, _ds.Tables[0].Rows[0][_col.ColumnName]);

            return Newtonsoft.Json.JsonConvert.SerializeObject(_json);
        }
        public static string Sp_evaUpdateForm(params SqlParameter[] parameter)
        {
            DataSet _ds = DbConfiguration.ExecuteQuery("[dbo].[sp_evaUpdateForm]", CommandType.StoredProcedure, parameter);

            Dictionary<string, object> _json = new Dictionary<string, object>();

            foreach (DataColumn _col in _ds.Tables[0].Columns)
                _json.Add(_col.ColumnName, _ds.Tables[0].Rows[0][_col.ColumnName]);
            
            return Newtonsoft.Json.JsonConvert.SerializeObject(_json);
        }
        public static DataSet Sp_evaStudentListForm(string _studentId) { 
            return DbConfiguration.ExecuteQuery("[dbo].[sp_evaStudentListForm]", CommandType.StoredProcedure,
                    new SqlParameter("studentId", _studentId)
                );
        }
        public static string Sp_evaStudentSendAnswer(params SqlParameter[] parameter) { 
            DataSet _ds = DbConfiguration.ExecuteQuery("[dbo].[sp_evaStudentSendAnswer]", CommandType.StoredProcedure, parameter);

            Dictionary<string, object> _json = new Dictionary<string, object>();

            foreach (DataColumn _col in _ds.Tables[0].Columns)
                _json.Add(_col.ColumnName, _ds.Tables[0].Rows[0][_col.ColumnName]);

            return Newtonsoft.Json.JsonConvert.SerializeObject(_json);
        }
        public static Dictionary<string, object> getEvaluateInfo(string _frmId) {
            DataTable _formInfoDt = DbConfiguration.ExecuteQuery(@"SELECT * FROM [dbo].[evaModelForm] WHERE id = @frmid",
                    new SqlParameter("frmid", _frmId)
                ).Tables[0];

            Dictionary<string, object> evaObject = new Dictionary<string, object>();

            foreach (DataColumn _col in _formInfoDt.Columns)
                evaObject.Add(_col.ColumnName, _formInfoDt.Rows[0][_col.ColumnName]);

            return evaObject;
        }
        public static DataTable Sp_getEvaluateAnswers(string _studentId, string _frmId, string _conId, string _insId) { 
            return DbConfiguration.ExecuteQuery("sp_getEvaluateAnswers", CommandType.StoredProcedure, 
                    new SqlParameter("studentId", _studentId),
                    new SqlParameter("frmId", _frmId),
                    new SqlParameter("conditionId", _conId),
                    new SqlParameter("instructorId", _insId)
                ).Tables[0];
        }
        public static bool CheckSubmitedStatus(string _frmId, string _conId, string _insId) {
            return (int)DbConfiguration.ExecuteScalar(@"SELECT CASE WHEN EXISTS(
                                                            SELECT  1
                                                            FROM    [dbo].[evaTransEvaluate]
                                                            WHERE   [studentId] = @studentId
                                                            AND [conditionId]   = @conditionId
                                                            AND [frmId]         = @frmId
                                                            AND [instructorId]  = @instructorId
                                                            ) 
                                                        THEN 1 
                                                        ELSE 0 
                                                        END", 
                    new SqlParameter("studentId", new Login("student").StudentId), 
                    new SqlParameter("conditionId", _conId),
                    new SqlParameter("frmId", _frmId),
                    new SqlParameter("instructorId", _insId)) == 1;
        }
    }
}