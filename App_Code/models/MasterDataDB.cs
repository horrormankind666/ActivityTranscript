using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MasterDataContext
/// </summary>
public class MasterDataDB
{
	public MasterDataDB()
	{

	}
    public static DataSet GetListYearSemester() {
        return DbConfiguration.ExecuteQuery("Select Distinct acaYear, semester from [fnc_curGetListAcademicYearTerm]('')");
    }
    //public static DataSet Sp_evaGetListSubjectListEvaluate(string _year, string _semester, string _facultyid) { 
    //    return DbConfiguration.ExecuteQuery("sp_evaGetListSubjectListEvaluate", CommandType.StoredProcedure,
    //            new SqlParameter("acaYear", _year),
    //            new SqlParameter("semester", _semester),
    //            new SqlParameter("facultyId", _facultyid)
    //        );
    //}
    public static DataSet Sp_evaGetListSubject(string _year, string _semester, string _facultyid)
    {
        return DbConfiguration.ExecuteQuery("sp_evaGetListSubject", CommandType.StoredProcedure,
                new SqlParameter("acaYear", _year),
                new SqlParameter("semester", _semester),
                new SqlParameter("facultyId", _facultyid)
            );
    }
    public static DataSet Sp_evaGetSideMenu(string _username, string _facid) {
        return DbConfiguration.ExecuteQuery("sp_evaGetSideMenu", CommandType.StoredProcedure,
                new SqlParameter("username", _username),
                new SqlParameter("facId", _facid)
            );
    }
    public static DataSet Sp_evaGetListUserPrivilage(string _username) {
        return DbConfiguration.ExecuteQuery("sp_evaGetListUserPrivilage", CommandType.StoredProcedure,
                new SqlParameter("username", _username)
            );
    }
    public static Dictionary<string, object> get_EvaModelType_Info(string _id)
    {
        DataTable _dt = DbConfiguration.ExecuteQuery(@"SELECT * FROM [dbo].[evaModelType] WHERE id = @id",
                new SqlParameter("@id", _id)
            ).Tables[0];

        Dictionary<string, object> _result = new Dictionary<string, object>();
        foreach (DataColumn _col in _dt.Columns)
        {
            _result.Add(_col.ColumnName, _dt.Rows[0][_col.ColumnName]);
        }

        return _result;
    }
}