using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for ActDB
/// </summary>
public class ActDB
{
	public ActDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataSet setProject( string _uId , 
                                        string _acaYear ,
	                                    string _semester ,
	                                    string _instituteId ,
	                                    string _projectNameTh ,
	                                    string _projectNameEn ,
	                                    string _projectDetail ,
	                                    string _projectTypeId ,
                                        string _targetGroup,
                                        string _username,
                                        string _facultyIdPermission,
                                        string _startDateRecruit,
                                        string _endDateRecruit,
                                        string _facultyStr,
                                        string _classYearStr,
                                        string _studentCodeStr,
                                        string _projectDetailEn,
                                        string _projectStatusId
        )
    {
        return DbConfiguration.ExecuteQuery("sp_actSetProject", CommandType.StoredProcedure,
                new SqlParameter("uId", _uId),
                new SqlParameter("acaYear", _acaYear),
                new SqlParameter("semester", _semester),
                new SqlParameter("instituteId", _instituteId),
                new SqlParameter("projectNameTh", _projectNameTh),
                new SqlParameter("projectNameEn", _projectNameEn),
                new SqlParameter("projectDetail", _projectDetail),
                new SqlParameter("projectTypeId", _projectTypeId),
                new SqlParameter("targetGroup", _targetGroup),
                new SqlParameter("username", _username),
                new SqlParameter("facultyId", _facultyIdPermission),
                new SqlParameter("startDateRecruit", _startDateRecruit),
                new SqlParameter("endDateRecruit", _endDateRecruit),
                new SqlParameter("expressionFaculty", _facultyStr),
                new SqlParameter("expressionClassYear", _classYearStr),
                new SqlParameter("expressionStudentCode", _studentCodeStr),
                new SqlParameter("projectDetailEn", _projectDetailEn),
                new SqlParameter("projectStatusId", _projectStatusId)
                
            );


    }


    public static DataSet getListBudget(string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("Select * , case when '" + _facultyId + "' = facultyId then '1' else '0' end  as statusEdit From fnc_actGetListBudgetType() where (facultyId = '" + _facultyId + "') OR (facultyId = 'MU-01') order by case when facultyId ='MU-01' then '0' else '1' end  ");
    }

    public static DataSet getListInstitute(string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListInstitute", CommandType.StoredProcedure,
                new SqlParameter("facultyId", _facultyId)
            );
    }

    public static DataSet getListTargetGroup()
    {
        return DbConfiguration.ExecuteQuery("Select * From fnc_actGetListTargetGroup()");
    }

    public static DataSet getListProjectType(string _projectTypeId)
    {
        if (_projectTypeId == "")
        {
            return DbConfiguration.ExecuteQuery("select * from fnc_actGetListProjectType() where startYear >= 2562");
        }
        else
        {
            return DbConfiguration.ExecuteQuery("select * from fnc_actGetListProjectType() ");
        }
    }

    public static DataSet getListProjectStatus()
    {
        return DbConfiguration.ExecuteQuery("select * from fnc_actGetListProjectStatus()");
    }

    public static DataSet getListAcaYear()
    {
        return DbConfiguration.ExecuteQuery("select distinct acaYear,(select case when month(getdate()) >= 8 then year(getdate())+543 else year(getdate())+543 - 1 end ) as currentAcaYear from [fnc_curGetListAcademicYearTerm]('')  order by acaYear desc");
    }

    public static DataSet getListSemester()
    {
        return DbConfiguration.ExecuteQuery("select distinct semester from [fnc_curGetListAcademicYearTerm]('')");
    }

    public static DataSet getListProgram(string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("select * from fnc_acaGetListProgram('" + _facultyId + "')");
    }



    public static DataSet getListProject(string _facultyId, string _acaYear, string _semester, string _projectName,string _createdBy)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListProject", CommandType.StoredProcedure,
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("acaYear", _acaYear),
                new SqlParameter("semester", _semester),
                new SqlParameter("projectName", _projectName),
                new SqlParameter("createdBy", _createdBy)
            );
    }

    public static DataSet getListProjectDetail(string _projectId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListProjectDetail", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectId)
            );
    }

    public static DataSet getListProjectBudget(string _projectId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListProjectBudget", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectId)
            );
    }

    public static DataSet getListProjectIndicator(string _projectId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListProjectIndicator", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectId)
            );
    }


    public static DataSet getListIndicator(string _facultyId)
    {
        // return DbConfiguration.ExecuteQuery("select * , case when '" + _facultyId + "' = facultyId then '1' else '0' end  as statusEdit from fnc_actGetListIndicator() where (facultyId = '" + _facultyId + "') OR (facultyId = 'MU-01') order by case when facultyId ='MU-01' then '0' else '1' end  ");
        return DbConfiguration.ExecuteQuery("select [abbrevEn] indicatorAbbrevEn,[abbrevTh] IndicatorAbbrevTh,[nameTh]  indicatorNameTh ,nameEn indicatorNameEn,* , case when '" + _facultyId + "' = facultyId then '1' else '0' end  as statusEdit from actIndicator where  cancelStatus is null and ((facultyId = '" + _facultyId + "') OR (facultyId = 'MU-01')) order by case when facultyId ='MU-01' then '0' else '1' end ");

    }

    public static DataSet getListFaculty(string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("select * from fnc_acaGetListFaculty() where id = case when '" + _facultyId + "' = 'MU-01' then id else '" + _facultyId + "' end ");
    }

    public static DataSet getListSection(string _projectId, string _studentId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListSectionByProjectId", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectId),
                new SqlParameter("username", _studentId)
            );
    }


    public static DataSet getListCharacter(string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("select * , case when '" + _facultyId + "' = facultyId then '1' else '0' end  as statusEdit from fnc_actGetListCharacter() where (facultyId = '" + _facultyId + "') OR (facultyId = 'MU-01') order by case when facultyId ='MU-01' then '0' else '1' end  ");
    }

    public static DataSet getListGroupCharacter(string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("select *, case when '" + _facultyId + "' = facultyId then '1' else '0' end  as statusEdit from fnc_actGetListGroupCharacter() where (facultyId = '" + _facultyId + "') OR (facultyId = 'MU-01') order by case when facultyId ='MU-01' then '0' else '1' end  ");
    }
    

    public static DataSet getListProjectCharacter(string _projectId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListProjectCharacter", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectId)
            );
    }


    public static DataSet getListProjectDeviceInfo(string _projectId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListProjectDevice", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectId)
            );
    }

    public static DataSet getListProjectPicture(string _projectId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListProjectPicture", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectId)
            );
    }

    public static DataSet getListDevice()
    {
        return DbConfiguration.ExecuteQuery("select * from fnc_actGetListDevice()");
    }

    public static DataSet setIndicator(  string _indicatorNameTh ,
	                                        string _indicatorNameEn ,
	                                        string _indicatorAbbrevTh ,
	                                        string _indicatorAbbrevEn ,
	                                        string _startYear ,
	                                        string _endYear ,
	                                        string _username ,
	                                        string _facultyId ,
	                                        string _uId )
    {
        return DbConfiguration.ExecuteQuery("sp_actSetIndicator", CommandType.StoredProcedure,
                new SqlParameter("indicatorNameTh", _indicatorNameTh),
                new SqlParameter("indicatorNameEn", _indicatorNameEn),
                new SqlParameter("indicatorAbbrevTh", _indicatorAbbrevTh),
                new SqlParameter("indicatorAbbrevEn", _indicatorAbbrevEn),
                new SqlParameter("startYear", _startYear),
                new SqlParameter("endYear", _endYear),
                new SqlParameter("username", _username),
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("uId", _uId)
            );
    }


    public static DataSet setCharater(string _characterNameTh ,
	                                string _characterNameEn ,
	                                string _characterAbbrevTh ,
	                                string _characterAbbrevEn ,
	                                string _startYear ,
	                                string _endYear ,
	                                string _groupCharacterId ,
	                                string _username ,
	                                string _facultyId ,
	                                string _uId )
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCharater", CommandType.StoredProcedure,
                new SqlParameter("characterNameTh", _characterNameTh),
                new SqlParameter("characterNameEn", _characterNameEn),
                new SqlParameter("characterAbbrevTh", _characterAbbrevTh),
                new SqlParameter("characterAbbrevEn", _characterAbbrevEn),
                new SqlParameter("startYear", _startYear),
                new SqlParameter("endYear", _endYear),
                new SqlParameter("groupCharacterId", _groupCharacterId),
                new SqlParameter("username", _username),
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("uId", _uId)
            );
    }



    public static DataSet setBudgetType(string _budgetTypeNameTh,
                                string _budgetTyperNameEn,
                                string _startYear,
                                string _endYear,
                                string _username,
                                string _uId,
                                string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetBudgetType", CommandType.StoredProcedure,
                new SqlParameter("budgetTypeNameTh ", _budgetTypeNameTh),
                new SqlParameter("budgetTyperNameEn", _budgetTyperNameEn),
                new SqlParameter("startYear", _startYear),
                new SqlParameter("endYear", _endYear),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId),
                new SqlParameter("facultyId", _facultyId)
            );
    }


    public static DataSet setDeviceInfo(string _deviceInfoNameTh,
                            string _deviceInfoNameEn,
                            string _deviceNumber,
                            string _username,
                            string _uId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetDeviceInfo", CommandType.StoredProcedure,
                new SqlParameter("deviceInfoNameTh ", _deviceInfoNameTh),
                new SqlParameter("deviceInfoNameEn", _deviceInfoNameEn),
                new SqlParameter("deviceNumber", _deviceNumber),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId)
            );
    }

    public static DataSet setProjectSection(string _uId,
                                            string _projectId,
                                            string _sectionNameTh,
                                            string _sectionNameEn,
                                            string _startDateProjectSection,
                                            string _endDateProjectSection,
                                            string _amountSection,
                                            string _placeSection,
                                            string _username,
                                            string _txtMuxRefId,
                                            string _ddlStatusPassMux,
                                            string _ddlStatusEnrollmentMux)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetProjectSection", CommandType.StoredProcedure,
                new SqlParameter("projectId ", _projectId),
                new SqlParameter("sectionNameTh", _sectionNameTh),
                new SqlParameter("sectionNameEn", _sectionNameEn),
                new SqlParameter("startDateProjectSection", _startDateProjectSection),
                new SqlParameter("endDateProjectSection", _endDateProjectSection),
                new SqlParameter("amountSection", _amountSection),
                new SqlParameter("placeSection", _placeSection),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId),
                new SqlParameter("muxRefId", _txtMuxRefId),
                new SqlParameter("statusPassMux", _ddlStatusPassMux),
                new SqlParameter("statusEnrollmentMux", _ddlStatusEnrollmentMux) 

            );
    }


    public static DataSet setProjectBudget(string _uId,
                                            string _projectId,
                                            string _budgetTypeId,
                                            string _budget,
                                            string _paid,
                                            string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetProjectBudget", CommandType.StoredProcedure,
                new SqlParameter("projectId ", _projectId),
                new SqlParameter("budgetTypeId", _budgetTypeId),
                new SqlParameter("budget", _budget),
                new SqlParameter("paid", _paid),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId)
            );
    }

    public static DataSet setProjectIndicator(string _uId,
                                        string _sectionId,
                                        string _indicatorId,
                                        string _projectIndicatoeHour,
                                        string _username,
                                        string _subIndicatorId,
                                        string _description)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetProjectIndicatorNew", CommandType.StoredProcedure,
                new SqlParameter("sectionId", _sectionId),
                new SqlParameter("indicatorId", _indicatorId),
                new SqlParameter("projectIndicatoeHour", _projectIndicatoeHour),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId),
                new SqlParameter("subIndicator", _subIndicatorId),
                new SqlParameter("description", _description)
            );
    }

    public static DataSet setProjectCharacter(string _uId,
                                    string _sectionId,
                                    string _characterStr,
                                    string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetProjectCharacter", CommandType.StoredProcedure,
                new SqlParameter("sectionId", _sectionId),
                new SqlParameter("characterStr", _characterStr),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId)
            );
    }

    public static DataSet setProjectDevice(string _uId,
                                string _sectionId,
                                string _deviceId,
                                string _startDateDevice,
                                string _endDateDevice,
                                string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetProjectDevice", CommandType.StoredProcedure,
                new SqlParameter("sectionId", _sectionId),
                new SqlParameter("deviceId", _deviceId),
                new SqlParameter("startDateDevice", _startDateDevice),
                new SqlParameter("endDateDevice", _endDateDevice),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId)
            );
    }



    public static DataSet setUpdateProject(    string _uId,
                                               string _acaYear,
                                               string _semester,
                                               string _instituteId,
                                               string _projectNameTh,
                                               string _projectNameEn,
                                               string _projectDetail,
                                               string _projectTypeId,
                                               string _username,
                                               string _projectId,
                                               string _facultyId,
                                               string _startDateRecruit,
                                               string _endDateRecruit,
                                               string _facultyStr,
                                               string _classYearStr,
                                               string _studentCodeStr,
                                               string _projectDetailEn)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetUpdateProject", CommandType.StoredProcedure,
                new SqlParameter("uId", _uId),
                new SqlParameter("acaYear", _acaYear),
                new SqlParameter("semester", _semester),
                new SqlParameter("instituteId", _instituteId),
                new SqlParameter("projectNameTh", _projectNameTh),
                new SqlParameter("projectNameEn", _projectNameEn),
                new SqlParameter("projectDetail", _projectDetail),
                new SqlParameter("projectTypeId", _projectTypeId),
                new SqlParameter("username", _username),
                new SqlParameter("projectId", _projectId),
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("startDateRecruit", _startDateRecruit),
                new SqlParameter("endDateRecruit", _endDateRecruit),
                new SqlParameter("expressionFaculty", _facultyStr),
                new SqlParameter("expressionClassYear", _classYearStr),
                new SqlParameter("expressionStudentCode", _studentCodeStr),
                new SqlParameter("projectDetailEn", _projectDetailEn)
            );


    }


    public static DataSet setProjectPicture(string _uId,
                            string _projectId,
                            string _pictureName,
                            string _pictureDetail,
                            string _filename,
                            string _username,
                            string _typeFileUploadId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetProjectPicture", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectId),
                new SqlParameter("pictureName", _pictureName),
                new SqlParameter("pictureDetail", _pictureDetail),
                new SqlParameter("filename", _filename),
                new SqlParameter("username", _username),
                new SqlParameter("typeFileUploadId", _typeFileUploadId),
                new SqlParameter("uId", _uId)
            );
    }


    public static DataSet getListStudentRegist(string _projectId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListStudentRegist", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectId)
            );

    }



    public static DataSet setStudentRegistSection(string _uId,
                            string _projectId,
                            string _sectionId,
                            string _studentCode,
                            string _username,
                            string _positionId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetStudentRegistSection", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectId),
                new SqlParameter("sectionId", _sectionId),
                new SqlParameter("studentCode", _studentCode),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId),
                new SqlParameter("positionId", _positionId)
            );
    }

    public static DataSet setCancelStudentRegist(string _transsectionregistid, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelStudentRegist", CommandType.StoredProcedure,
                new SqlParameter("transsectionregistid", _transsectionregistid),
                new SqlParameter("username", _username)
            );
    }


    public static DataSet setGroupCharacter(string _groupCharacterNameTh,
                                 string _groupCharacterNameEn,
                                 string _groupCharacterAbbrevTh,
                                 string _groupCharacterAbbrevEn,
                                 string _startYear,
                                 string _endYear,
                                 string _username,
                                 string _uId,
                                 string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetGroupCharacter", CommandType.StoredProcedure,
                new SqlParameter("groupCharacterNameTh", _groupCharacterNameTh),
                new SqlParameter("groupCharacterNameEn", _groupCharacterNameEn),
                new SqlParameter("groupCharacterAbbrevTh", _groupCharacterAbbrevTh),
                new SqlParameter("groupCharacterAbbrevEn", _groupCharacterAbbrevEn),
                new SqlParameter("startYear", _startYear),
                new SqlParameter("endYear", _endYear),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId),
                new SqlParameter("facultyId", _facultyId)
                
            );
    }


    public static DataSet getListSectionBySectionId(string _projectSectionId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListSectionBySectionId", CommandType.StoredProcedure,
                new SqlParameter("projectSectionId", _projectSectionId)
            );
    }





    public static DataSet setUpdateProjectSection(string _uId,
                                            string _projectSectionId,
                                             string _sectionNameTh,
                                            string _sectionNameEn,
                                            string _startDateProjectSection,
                                            string _endDateProjectSection,
                                            string _amountSection,
                                            string _placeSection,
                                            string _username,
                                            string _txtMuxRefId,
                                            string _ddlStatusPassMux,
                                            string _ddlStatusEnrollmentMux)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetUpdateProjectSection", CommandType.StoredProcedure,
                new SqlParameter("projectSectionId ", _projectSectionId),
                new SqlParameter("sectionNameTh", _sectionNameTh),
                new SqlParameter("sectionNameEn", _sectionNameEn),
                new SqlParameter("startDateProjectSection", _startDateProjectSection),
                new SqlParameter("endDateProjectSection", _endDateProjectSection),
                new SqlParameter("amountSection", _amountSection),
                new SqlParameter("placeSection", _placeSection),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId),
                new SqlParameter("muxRefId", _txtMuxRefId),
                new SqlParameter("statusPassMux", _ddlStatusPassMux),
                new SqlParameter("statusEnrollmentMux", _ddlStatusEnrollmentMux)
            );
    }



    public static DataSet getListTransProjectBudget(string _transProjectBubgetId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListTransProjectBudget", CommandType.StoredProcedure,
                new SqlParameter("transProjectBubgetId", _transProjectBubgetId)
            );
    }


    public static DataSet setUpdateTransProjectBudget(string _uId,
                                            string _transProjectBubgetId,
                                            string _budgetTypeId,
                                            string _budget,
                                            string _paid,
                                            string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetUpdateTransProjectBudget", CommandType.StoredProcedure,
                new SqlParameter("transProjectBubgetId ", _transProjectBubgetId),
                new SqlParameter("budgetTypeId", _budgetTypeId),
                new SqlParameter("budget", _budget),
                new SqlParameter("paid", _paid),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId)
            );
    }



    public static DataSet getListTransProjectIndicator(string _transSectionIndicatorId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListTransProjectIndicator", CommandType.StoredProcedure,
                new SqlParameter("transSectionIndicatorId", _transSectionIndicatorId)
            );
    }



    public static DataSet setUpdateTransProjectIndicator(string _uId,
                                        string _sectionId,
                                        string _indicatorId,
                                        string _projectIndicatoeHour,
                                        string _username,
                                        string _transSectionIndicatorId,
                                        string _subIndicatorId,
                                        string _description)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetUpdateTransProjectIndicatorNew", CommandType.StoredProcedure,
                new SqlParameter("sectionId", _sectionId),
                new SqlParameter("indicatorId", _indicatorId),
                new SqlParameter("projectIndicatoeHour", _projectIndicatoeHour),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId),
                new SqlParameter("transSectionIndicatorId", _transSectionIndicatorId),
                new SqlParameter("subIndicatorId", _subIndicatorId),
                new SqlParameter("description", _description)
            );
    }



    public static DataSet getListTransProjectDevice(string _transSectionDeviceId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListTransProjectDevice", CommandType.StoredProcedure,
                new SqlParameter("transSectionDeviceId", _transSectionDeviceId)
            );
    }



    public static DataSet setUpdateTransProjectDevice(string _uId,
                            string _sectionId,
                            string _deviceId,
                            string _startDateDevice,
                            string _endDateDevice,
                            string _username,
                            string _transSectionDeviceId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetUpdateTransProjectDevice", CommandType.StoredProcedure,
                new SqlParameter("", _transSectionDeviceId),
                new SqlParameter("deviceId", _deviceId),
                new SqlParameter("startDateDevice", _startDateDevice),
                new SqlParameter("endDateDevice", _endDateDevice),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId),
                new SqlParameter("transSectionDeviceId", _transSectionDeviceId)
            );
    }


    public static DataSet setCancelProjectPicture(string _transProjectPictureId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelProjectPicture", CommandType.StoredProcedure,
                new SqlParameter("transProjectPictureId", _transProjectPictureId),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet setCancelProjectDevice(string _transSectionDeviceId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelProjectDevice", CommandType.StoredProcedure,
                new SqlParameter("transSectionDeviceId", _transSectionDeviceId),
                new SqlParameter("username", _username)
            );
    }


    public static DataSet setCancelProjectIndicator(string _transSectionIndicatorId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelProjectIndicator", CommandType.StoredProcedure,
                new SqlParameter("transSectionIndicatorId", _transSectionIndicatorId),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet setCancelProjectBudget(string _transProjectBubgetId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelProjectBudget", CommandType.StoredProcedure,
                new SqlParameter("transProjectBubgetId", _transProjectBubgetId),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet setCancelSection(string _sectionId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelSection", CommandType.StoredProcedure,
                new SqlParameter("sectionId", _sectionId),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet getListConfigIndicator(string _indicatorId, string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListConfigIndicator", CommandType.StoredProcedure,
                new SqlParameter("indicatorId", _indicatorId),
                new SqlParameter("facultyId", _facultyId)
            );
    }


    public static DataSet setUpdateConfigIndicator(string _indicatorNameTh,
                                            string _indicatorNameEn,
                                            string _indicatorAbbrevTh,
                                            string _indicatorAbbrevEn,
                                            string _startYear,
                                            string _endYear,
                                            string _username,
                                            string _facultyId,
                                            string _uId,
                                            string _indicatorId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetUpdateConfigIndicator", CommandType.StoredProcedure,
                new SqlParameter("indicatorNameTh", _indicatorNameTh),
                new SqlParameter("indicatorNameEn", _indicatorNameEn),
                new SqlParameter("indicatorAbbrevTh", _indicatorAbbrevTh),
                new SqlParameter("indicatorAbbrevEn", _indicatorAbbrevEn),
                new SqlParameter("startYear", _startYear),
                new SqlParameter("endYear", _endYear),
                new SqlParameter("username", _username),
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("uId", _uId),
                new SqlParameter("indicatorId", _indicatorId)
            );
    }


    public static DataSet getListConfigCharacter(string _characterId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListConfigCharacter", CommandType.StoredProcedure,
                new SqlParameter("characterId", _characterId)
            );
    }



    public static DataSet setUpdateConfigCharater(string _characterNameTh,
                                    string _characterNameEn,
                                    string _characterAbbrevTh,
                                    string _characterAbbrevEn,
                                    string _startYear,
                                    string _endYear,
                                    string _groupCharacterId,
                                    string _username,
                                    string _facultyId,
                                    string _uId,
                                    string _characterId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetUpdateConfigCharater", CommandType.StoredProcedure,
                new SqlParameter("characterNameTh", _characterNameTh),
                new SqlParameter("characterNameEn", _characterNameEn),
                new SqlParameter("characterAbbrevTh", _characterAbbrevTh),
                new SqlParameter("characterAbbrevEn", _characterAbbrevEn),
                new SqlParameter("startYear", _startYear),
                new SqlParameter("endYear", _endYear),
                new SqlParameter("groupCharacterId", _groupCharacterId),
                new SqlParameter("username", _username),
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("uId", _uId),
                new SqlParameter("characterId", _characterId)
            );
    }


    public static DataSet getListConfigBudget(string _budgetId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListConfigBudget", CommandType.StoredProcedure,
                new SqlParameter("budgetId", _budgetId)
            );
    }




    public static DataSet setUpdateConfigBudget(string _budgetTypeNameTh,
                            string _budgetTyperNameEn,
                            string _startYear,
                            string _endYear,
                            string _username,
                            string _uId,
                            string _budgetTypeId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetUpdateConfigBudget", CommandType.StoredProcedure,
                new SqlParameter("budgetTypeNameTh ", _budgetTypeNameTh),
                new SqlParameter("budgetTypeNameEn", _budgetTyperNameEn),
                new SqlParameter("startYear", _startYear),
                new SqlParameter("endYear", _endYear),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId),
                new SqlParameter("budgetTypeId", _budgetTypeId)
            );
    }


    public static DataSet getListConfigDevice(string _deviceId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListConfigDevice", CommandType.StoredProcedure,
                new SqlParameter("deviceId", _deviceId)
            );
    }


    public static DataSet setUpdateConfigDevice(string _deviceInfoNameTh,
                            string _deviceInfoNameEn,
                            string _deviceNumber,
                            string _username,
                            string _uId,
                            string _deviceId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetUpdateConfigDevice", CommandType.StoredProcedure,
                new SqlParameter("deviceInfoNameTh ", _deviceInfoNameTh),
                new SqlParameter("deviceInfoNameEn", _deviceInfoNameEn),
                new SqlParameter("deviceNumber", _deviceNumber),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId),
                new SqlParameter("deviceId", _deviceId)
            );
    }


    public static DataSet getListConfigGroupCharacter(string _groupCharacterId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListConfigGroupCharacter", CommandType.StoredProcedure,
                new SqlParameter("groupCharacterId", _groupCharacterId)
            );
    }


    public static DataSet setUpdateConfigGroupCharacter(string _groupCharacterNameTh,
                                 string _groupCharacterNameEn,
                                 string _groupCharacterAbbrevTh,
                                 string _groupCharacterAbbrevEn,
                                 string _startYear,
                                 string _endYear,
                                 string _username,
                                 string _uId,
                                 string _facultyId,
                                 string _groupCharacterId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetUpdateConfigGroupCharacter", CommandType.StoredProcedure,
                new SqlParameter("groupCharacterNameTh", _groupCharacterNameTh),
                new SqlParameter("groupCharacterNameEn", _groupCharacterNameEn),
                new SqlParameter("groupCharacterAbbrevTh", _groupCharacterAbbrevTh),
                new SqlParameter("groupCharacterAbbrevEn", _groupCharacterAbbrevEn),
                new SqlParameter("startYear", _startYear),
                new SqlParameter("endYear", _endYear),
                new SqlParameter("username", _username),
                new SqlParameter("uId", _uId),
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("groupCharacterId", _groupCharacterId)
            );
    }

    public static DataSet setCancelConfigIndicator(string _indicatorId,string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelConfigIndicator", CommandType.StoredProcedure,
                new SqlParameter("indicatorId", _indicatorId),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet setCancelConfigCharacter(string _characterId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelConfigCharacter", CommandType.StoredProcedure,
                new SqlParameter("characterId", _characterId),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet setCancelConfigBudget(string _budgetId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelConfigBudget", CommandType.StoredProcedure,
                new SqlParameter("budgetId", _budgetId),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet setCancelConfigDevice(string _deviceId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelConfigDevice", CommandType.StoredProcedure,
                new SqlParameter("deviceId", _deviceId),
                new SqlParameter("username", _username)
            );
    }


    public static DataSet setCancelConfigGroupCharacter(string _groupCharaterId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelConfigGroupCharater", CommandType.StoredProcedure,
                new SqlParameter("groupCharaterId", _groupCharaterId),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet setCancelProjectCharacter(string _transSectionCharacterId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelProjectCharacter", CommandType.StoredProcedure,
                new SqlParameter("transSectionCharacterId", _transSectionCharacterId),
                new SqlParameter("username", _username)
            );
    }


    public static DataSet getListPosition(string _statusPerson)
    {
        return DbConfiguration.ExecuteQuery("select * from fnc_actGetListPosition() where personelTypeId = case when '" + _statusPerson + "' = '' then personelTypeId else '" + _statusPerson + "' end ");
    }



    public static DataSet getListProjectForApprove(string _acaYear, string _semester, string _facultyId, string _projectStatusId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListProjectForApprove", CommandType.StoredProcedure,
                new SqlParameter("acaYear", _acaYear),
                new SqlParameter("semester", _semester),
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("projectStatusId", _projectStatusId)
            );
    }

    public static DataSet setApproveProject(string _projectid, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetApproveProject", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectid),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet getListChkStudentInSection(string _studentCode,string _sectionId,string _positionId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListChkStudentInSection", CommandType.StoredProcedure,
                new SqlParameter("studentCode", _studentCode),
                new SqlParameter("sectionId", _sectionId),
                new SqlParameter("positionId", _positionId)
            );
    }

    public static DataSet setListStudentRegist(DataTable _dataList, string _uId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetListStudentRegist", CommandType.StoredProcedure,
                new SqlParameter("dataList", _dataList),
                new SqlParameter("uId", _uId),
                new SqlParameter("username", _username)
            );
    }


    public static DataSet rptProjectSummary(string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptProjectSummary", CommandType.StoredProcedure,
                new SqlParameter("facultyId", _facultyId)
            );
    }

    public static DataSet rptProjectSummaryDetail(string _facultyId, string _acaYear)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptProjectSummaryDetail", CommandType.StoredProcedure,
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("acaYear", _acaYear)
            );
    }


    public static DataSet getPermission(string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetPermission", CommandType.StoredProcedure,
                new SqlParameter("username", _username)
            );
    }



    public static DataSet getListProjectActive(string _acaYear)
    {
        return DbConfiguration.ExecuteQuery("select * from fnc_actGetListProjectActive('" + _acaYear + "') where getdate() between startDateRecruit and endDateRecruit order by createdDate desc  ");
    }

    public static DataSet setCancelProject(string _projectId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelProject", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectId),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet SetUpdateStudentPosition(string _transSectionRegistId,string _positionId,string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetUpdateStudentPosition", CommandType.StoredProcedure,
                new SqlParameter("transSectionRegistId", _transSectionRegistId),
                new SqlParameter("positionId", _positionId),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet setCloseProject(string _projectid, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCloseProject", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectid),
                new SqlParameter("username", _username)
            );
    }


    public static DataSet getChkForCloseProject(string _projectId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetChkForCloseProject", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectId)
            );
    }

    public static DataSet getListStudentCompleteCondition(string _acaYear)
    {
        return DbConfiguration.ExecuteQuery("select * from fnc_actGetListStudentCompleteCondition('" + _acaYear + "') order by orderMapping");
    }


    public static DataSet getListClassYear()
    {
        return DbConfiguration.ExecuteQuery(" select * from fnc_actGetListClassYear() order by class ");
    }
   


    public static DataSet getListSummaryProjectByStudent(string _studentCode, string _stdFNameTh,string _stdLNameTh,string _programId,string _groupIndicatorId,string _groupCharacterId)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptGetListSummaryProjectByStudent", CommandType.StoredProcedure,
                new SqlParameter("studentCode", _studentCode),
                new SqlParameter("stdFNameTh", _stdFNameTh),
                new SqlParameter("stdLNameTh", _stdLNameTh),
                new SqlParameter("programId", _programId),
                new SqlParameter("groupIndicatorId", _groupIndicatorId),
                new SqlParameter("groupCharacterId", _groupCharacterId)
            );
    }



    public static DataSet setCancelStdRegistByCheckBox(DataTable _dataList, string _username)
    {

        return DbConfiguration.ExecuteQuery("sp_actSetCancelStdRegistByCheckBox", CommandType.StoredProcedure,
                new SqlParameter("dataList", _dataList),
                new SqlParameter("username", _username)
            );

    }


    public static DataSet rptStudentCompleteActivityGroupAcaYear(string _facultyId)
    {

        return DbConfiguration.ExecuteQuery("sp_actRptStudentCompleteActivityGroupAcaYear", CommandType.StoredProcedure,
                new SqlParameter("facultyId", _facultyId)
            );

    }

    public static DataSet rptStudentCompleteActivityGroupFaculty(string _facultyId,string _acaYear)
    {

        return DbConfiguration.ExecuteQuery("sp_actRptStudentCompleteActivityGroupFaculty", CommandType.StoredProcedure,
                new SqlParameter("acaYear", _acaYear),
                new SqlParameter("facultyId", _facultyId)
            );

    }

    public static DataSet rptStudentCompleteActivityGroupProgram(string _facultyId, string _acaYear)
    {

        return DbConfiguration.ExecuteQuery("sp_actRptStudentCompleteActivityGroupProgram", CommandType.StoredProcedure,
                new SqlParameter("acaYear", _acaYear),
                new SqlParameter("facultyId", _facultyId)
            );

    }






    public static DataSet rptStudentCompleteActivityGroupStudent(string _facultyId, string _acaYear)
    {   
        return DbConfiguration.ExecuteQuery("sp_actRptStudentCompleteActivityGroupStudent", CommandType.StoredProcedure,
                new SqlParameter("acaYear", _acaYear),
                new SqlParameter("facultyId", _facultyId)
            );
    }



    public static DataSet getListTypeCompleteAct()
    {
        return DbConfiguration.ExecuteQuery(" select * from fnc_actGetListTypeCompleteAct() ");
    }


    public static DataSet rptStatisticGroupAcaYear(string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptStatisticGroupAcaYear", CommandType.StoredProcedure,
                new SqlParameter("facultyId", _facultyId)
            );
    }


    public static DataSet getListStudentProfile(string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetStudent", CommandType.StoredProcedure,
               new SqlParameter("studentId", _username)
           );
    }

    public static DataSet rptGetListActivityAllByStudentId(string _studentId, string _stsProject)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptGetListActivityAllByStudentId", CommandType.StoredProcedure,
               new SqlParameter("studentId", _studentId),
               new SqlParameter("stsProject", _stsProject)
           );
    }


   public static DataSet getListIndicatorByYearStd(string _studentCode)
    {
        return DbConfiguration.ExecuteQuery("   select * from fnc_actGetListIndicator()  where '25'+left('" + _studentCode + "',2) between startYear and isnull(endYear,year(getdate())+543)  and facultyId = 'MU-01'  ");
    }

   public static DataSet getListProjectTypeByStudentYear(string _studentId)
   {
        return DbConfiguration.ExecuteQuery("sp_actGetListProjectTypeByStudentYear", CommandType.StoredProcedure,
               new SqlParameter("studentId", _studentId)
           );
   }

   public static DataSet getListProjectForStudentShopping(string _activityName, string _acaYear, string _projectType, string _projectStatus, string _studentId)
   {
        return DbConfiguration.ExecuteQuery("sp_actGetListProjectForStudentShopping", CommandType.StoredProcedure,
               new SqlParameter("activityName", _activityName),
               new SqlParameter("acaYear", _acaYear),
               new SqlParameter("projectType", _projectType),
               new SqlParameter("projectStatus", _projectStatus),
               new SqlParameter("studentId", _studentId)
           );
   }

   public static DataSet getListActivitySchorlarship(string _studentId)
   {
       return DbConfiguration.ExecuteQuery("sp_actRptStudentCompleteForScholarship", CommandType.StoredProcedure,
              new SqlParameter("studentId", _studentId)
          );
   }

   public static DataSet getListProjectForStudentScholarShip(string _acaYear, string _studentId)
   {
       return DbConfiguration.ExecuteQuery("sp_actGetListProjectForStudentScholarShip", CommandType.StoredProcedure,
              new SqlParameter("acaYear", _acaYear),
              new SqlParameter("studentId", _studentId)
          );
   }


   public static DataSet setListSendActForScholarship(string _acaYear,string _studentId,string _username)
   {

       return DbConfiguration.ExecuteQuery("sp_actSetListSendActForScholarship", CommandType.StoredProcedure,
               new SqlParameter("acaYear", _acaYear),
               new SqlParameter("studentId", _studentId),
               new SqlParameter("username", _username)
           );

   }

    
   public static DataSet getListSchStudentSendAct()
   {
       return DbConfiguration.ExecuteQuery("sp_actGetListSchStudentSendAct", CommandType.StoredProcedure);
   }


   public static DataSet rptProjectBudgetByAcaYear(string _acaYear, string _facultyId)
   {

       return DbConfiguration.ExecuteQuery("sp_actRptProjectBudgetByAcaYear", CommandType.StoredProcedure,
               new SqlParameter("acaYear", _acaYear),
               new SqlParameter("facultyId", _facultyId)
           );

   }


   public static DataSet getListIndicatorHoursForStudentShopping(string _projectId)
   {

       return DbConfiguration.ExecuteQuery("sp_actGetListIndicatorHoursForStudentShopping", CommandType.StoredProcedure,
               new SqlParameter("projectId", _projectId)
           );

   }


   public static DataSet setListSectionForShopping(DataTable _dataList, string _username)
   {
       return DbConfiguration.ExecuteQuery("sp_actSetListSectionForShopping", CommandType.StoredProcedure,
               new SqlParameter("dataList", _dataList),
               new SqlParameter("username", _username)
           );

   }

   public static DataSet getListATForPrint(string _studentYear, string _facultyId, string _programId, string _studentCode,string _statusRequest)
   {

       return DbConfiguration.ExecuteQuery("sp_actActListATForPrint", CommandType.StoredProcedure,
               new SqlParameter("studentYear", _studentYear),
               new SqlParameter("facultyId", _facultyId),
               new SqlParameter("programId", _programId),
               new SqlParameter("studentCode", _studentCode),
               new SqlParameter("statusRequest", _statusRequest)
               
           );

   }

   public static DataSet getListStudentYear()
   {

       return DbConfiguration.ExecuteQuery("sp_actActGetListStudentYear", CommandType.StoredProcedure);

   }


   public static DataSet getActivityTranscript(string _studentCode, string _stdFNameTh, string _stdLNameTh, string _programId)
   {
       return DbConfiguration.ExecuteQuery("sp_actRptGetActivityTranscript", CommandType.StoredProcedure,
               new SqlParameter("studentCode", _studentCode),
               new SqlParameter("stdFNameTh", _stdFNameTh),
               new SqlParameter("stdLNameTh", _stdLNameTh),
               new SqlParameter("programId", _programId)
           );
   }

   public static DataSet getMahidolCoreValue(string _studentId, string _facultyId, string _programId,string _acaYear,string _semester,string _groupIndicatorId)
   {
       return DbConfiguration.ExecuteQuery("sp_actRptGetMahidolCoreValue", CommandType.StoredProcedure,
               new SqlParameter("studentId", _studentId),
               new SqlParameter("facultyId", _facultyId),
               new SqlParameter("programId", _programId),
               new SqlParameter("acaYear", _acaYear),
               new SqlParameter("semester", _semester),
               new SqlParameter("groupIndicatorId", _groupIndicatorId)
               
           );
   }

   public static DataSet getCharacterSummary(string _studentId, string _groupCharacterId, string _facultyId, string _programId, string _acaYear, string _semester)
   {
       return DbConfiguration.ExecuteQuery("sp_actRptGetCharacterSummary", CommandType.StoredProcedure,
               new SqlParameter("studentId", _studentId),
               new SqlParameter("groupCharacterId", _groupCharacterId),
               new SqlParameter("facultyId", _facultyId),
               new SqlParameter("programId", _programId),
               new SqlParameter("acaYear", _acaYear),
               new SqlParameter("semester", _semester)
               
           );
   }

   public static DataSet getListStudentForSpiderGraph(string _facultyId, string _programId, string _studentCode, string _firstName, string _lastName)
   {
       return DbConfiguration.ExecuteQuery("sp_actRptGetListStudentSpiderGraph", CommandType.StoredProcedure,
               new SqlParameter("facultyId", _facultyId),
               new SqlParameter("programId", _programId),
               new SqlParameter("studentCode", _studentCode),
               new SqlParameter("firstName", _firstName),
               new SqlParameter("lastName", _lastName)
           );
   }

   public static DataSet getListStudentForSpiderGraphFacultyLevel( string _acaYear, string _semester,string _facultyId, string _programId,string _groupIndicatorId,string _groupCharacterId)
   {
       return DbConfiguration.ExecuteQuery("sp_actRptGetListStudentSpiderFacultyLevel", CommandType.StoredProcedure,
               new SqlParameter("facultyId", _facultyId),
               new SqlParameter("programId", _programId),
               new SqlParameter("acaYear", _acaYear),
               new SqlParameter("semester", _semester),
               new SqlParameter("groupIndicatorId", _groupIndicatorId),
               new SqlParameter("groupCharacterId", _groupCharacterId)
           );
   }


   public static DataSet getSpiderUniversityLevel(string _acaYear, string _semester, string _facultyId,string _groupIndicatorId,string _groupCharacterId)
   {
       return DbConfiguration.ExecuteQuery("sp_actRptGetSpiderUniversityLevel", CommandType.StoredProcedure,
               new SqlParameter("facultyId", _facultyId),
               new SqlParameter("acaYear", _acaYear),
               new SqlParameter("semester", _semester),
               new SqlParameter("groupIndicatorId", _groupIndicatorId),
               new SqlParameter("groupCharacterId", _groupCharacterId)
           );
   }


    public static DataSet getListPublicEventPicture(string _menuVal,string _projectId,string _studentId,string _publicEventName,string _ddlFaculty, string _dateStart, string _dateEnd, string _ddlProjectStatus,string _statusPublicEvent,string _ddlGroupIndicator,string _ddlIndicator,string _ddlSubIndicator)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptGetListPublicEventPicture", CommandType.StoredProcedure,
             new SqlParameter("menuVal", _menuVal),
             new SqlParameter("projectId", _projectId),
             new SqlParameter("studentId", _studentId),
             new SqlParameter("publicEventName", _publicEventName),
             new SqlParameter("facultyId", _ddlFaculty),
             new SqlParameter("dateStart", _dateStart),
             new SqlParameter("dateEnd", _dateEnd),
             new SqlParameter("projectStatusId", _ddlProjectStatus),
             new SqlParameter("statusPublicEvent", _statusPublicEvent),
             new SqlParameter("groupIndicatorId", _ddlGroupIndicator),
             new SqlParameter("IndicatorId", _ddlIndicator),
             new SqlParameter("SubIndicatorId", _ddlSubIndicator)

             );
    }

    public static DataSet setLikeProject(string _studentId,string _projectId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetLikeProject", CommandType.StoredProcedure,
             new SqlParameter("studentId", _studentId),
             new SqlParameter("projectId", _projectId),
             new SqlParameter("username", _username)
             );
    }

    public static DataSet setCancelLikeProject(string _studentId, string _projectId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelLikeProject", CommandType.StoredProcedure,
             new SqlParameter("studentId", _studentId),
             new SqlParameter("projectId", _projectId)
             );
    }

    public static DataSet setJoinProjectSection(string _sectionId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetJoinProjectSection", CommandType.StoredProcedure,
             new SqlParameter("sectionId", _sectionId),
             new SqlParameter("username", _username)
             );
    }

    public static DataSet setCancelJoinProjectSection(string _sectionId, string _username,string _invoiceId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelJoinProjectSection", CommandType.StoredProcedure,
             new SqlParameter("sectionId", _sectionId),
             new SqlParameter("username", _username),
             new SqlParameter("invoiceId", _invoiceId)
             );
    }
    

    public static DataSet rptStatisticGroupAcaYearNew(string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptStatisticGroupAcaYearNew", CommandType.StoredProcedure,
                new SqlParameter("facultyId", _facultyId)
            );
    }


    public static DataSet getListRptSumHrAndCountActStudent(string _facultyId, string _programId, string _studyYear,string _acaYear)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptGetListSumHrAndCountActStudent", CommandType.StoredProcedure,
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("programId", _programId),
                new SqlParameter("class", _studyYear),
                new SqlParameter("acaYear", _acaYear)
            );
    }

    public static DataSet getListSubIndicator(string _indicatorId, string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("select * , case when '" + _facultyId + "' = facultyId then '1' else '0' end  as statusEdit from actSubIndicator where indicatorId = '"+ _indicatorId + "' order by case when facultyId ='MU-01' then '0' else '1' end  ");
    }

    public static DataSet getListActivityStudentHIDEF(string _studentId)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptGetListActivityStudentHIDEF", CommandType.StoredProcedure,
         new SqlParameter("studentId", _studentId)
     );
    }

    public static DataSet getListStudentRegisOnline( string _projectId,string _sectionId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListStudentRegisOnline", CommandType.StoredProcedure,
             new SqlParameter("projectId", _projectId),
             new SqlParameter("sectionId", _sectionId)

             );
    }

    public static DataSet getListGroupIndicator()
    {
        return DbConfiguration.ExecuteQuery("select * FROM [Infinity].[dbo].[vw_refActGroupIndicator] ");
    }

    public static DataSet getProjectForCount(string _acaYear, string _semester, string _facultyId, string _groupIndicatorId, string _groupCharacterId)
    {
        return DbConfiguration.ExecuteQuery(@"
		Declare @startYear varchar(4) , @endYear varchar(4)
		SELECT top 1 @startYear = startYear , @endYear = isnull(endYear,year(getdate())+543) 
		FROM [Infinity].[dbo].[actIndicator]
		where groupIndicatorId = '"+ _groupIndicatorId + @"'
		

		select count(id) as countProjectAll
		from fnc_actGetListProject('"+ _facultyId + @"','','','','')
		where acaYear between @startYear and @endYear
		and  cancelStatus is null
		and acaYear = case when '" + _acaYear + "' = '' then  acaYear else '" + _acaYear + @"' end 
        and semester =  case when '" + _semester + "' = '' then  semester else '" + _semester + "' end    ");

    }

    public static DataSet getListActivitiesOnline(string _studentId)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptGetListActivitiesOnline", CommandType.StoredProcedure,
             new SqlParameter("studentId", _studentId)

             );
    }

    public static DataSet getListFileUploadType()
    {
        return DbConfiguration.ExecuteQuery("select * FROM [Infinity].[dbo].actFileUploadType where [cancelStatus] is null ");
    }

    public static DataSet getProjectId(string _username)
    {
        return DbConfiguration.ExecuteQuery("SELECT top 1 [id]  FROM[Infinity].[dbo].[actProject]  where createdBy = '"+ _username + "'  order by createdDate desc");
    }
    public static DataSet getTransStudentPass(string _studentId)
    {
        return DbConfiguration.ExecuteQuery("select *,convert(varchar(10),createdDate,103) as createdDate,convert(varchar(5), createdDate, 8) as createdTime from actTransStudentPass  where studentId = '" + _studentId + "' ");
    }

    public static DataSet getTransStudentPassByStudentCode(string _studentCode)
    {
        return DbConfiguration.ExecuteQuery("select * from actTransStudentPass    where studentId in ( select id from stdStudent where studentCode = '"+ _studentCode + "' ) ");
    }


    public static DataSet getInvoiceStudentForPayment(string _invoiceId, string _sectionId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetInvoiceStudentForPayment", CommandType.StoredProcedure,
             new SqlParameter("invoiceId", _invoiceId),
             new SqlParameter("sectionId", _sectionId)
             );
    }

    public static DataSet actSetUpdateNewRef1(string _studentId, string _invoiceId, string _qrNewRef1, string _ref_2, string _billerId)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetUpdateNewRef1", CommandType.StoredProcedure,
             new SqlParameter("studentId", _studentId),
             new SqlParameter("invoiceId", _invoiceId),
             new SqlParameter("qrNewRef_1", _qrNewRef1),
             new SqlParameter("qrRef_2", _ref_2),
             new SqlParameter("billerId", _billerId)
             );
    }

    public static DataSet getStudentKey(string _studentCode,string _stdFName, string _stdLName)
    {
         return DbConfiguration.ExecuteQuery(@"select top 1 studentId ,studentCode
            from vw_refStdStudent
            where studentCode = case when '"+ _studentCode + "' = '' then studentCode else '" + _studentCode + @"' end
            and isnull(firstName, '') + isnull(lastName, '') like
                case when '" + _stdFName + "' + '"+ _stdLName + "' = '' then isnull(firstName, '') + isnull(lastName, '') else '%" + _stdFName + "' + '" + _stdLName + "%' end order by studentCode desc");
    }

    public static DataSet getListStudent()
    {
        return DbConfiguration.ExecuteQuery(" select studentId,studentCode, facultyCode, facNameTh, progNameTh, fullNameTh,fullNameEn,firstName,lastName from vw_refStdStudent");
    }

    public static DataSet getListStudentByCode(string studentCode)
    {
        return DbConfiguration.ExecuteQuery(" select studentId,studentCode, facultyCode, facNameTh, progNameTh, fullNameTh,fullNameEn,firstName,lastName from vw_refStdStudent where studentCode = '"+ studentCode + "'");
    }

    public static DataSet getListRptStatisticDepartment(string _facultyId,string _groupIndicatorId, string _ddlYearReport, string _ddlMonthReport)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptStatisticDepartmentFillterYear", CommandType.StoredProcedure,
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("groupIndicatorId", _groupIndicatorId),
                new SqlParameter("yearReport", _ddlYearReport),
                new SqlParameter("monthReport", _ddlMonthReport)
            );
    }



    public static DataSet getMahidolCoreValueUniversity(string _studentId, string _facultyId, string _programId, string _acaYear, string _semester, string _groupIndicatorId ,string _indicatorId)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptGetMahidolCoreValueUniversity", CommandType.StoredProcedure,
                new SqlParameter("studentId", _studentId),
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("programId", _programId),
                new SqlParameter("acaYear", _acaYear),
                new SqlParameter("semester", _semester),
                new SqlParameter("groupIndicatorId", _groupIndicatorId),
                new SqlParameter("indicatorId", _indicatorId)

            );
    }



    public static DataSet getCharacterSummaryUniversity(string _studentId, string _groupCharacterId, string _facultyId, string _programId, string _acaYear, string _semester)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptGetCharacterSummaryUniversity", CommandType.StoredProcedure,
                new SqlParameter("studentId", _studentId),
                new SqlParameter("groupCharacterId", _groupCharacterId),
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("programId", _programId),
                new SqlParameter("acaYear", _acaYear),
                new SqlParameter("semester", _semester)

            );
    }

    public static DataSet setApiCollectATHours(DataTable _dataList)
    {

        return DbConfiguration.ExecuteQuery("sp_actSetApiCollectATHours", CommandType.StoredProcedure,
                new SqlParameter("dataList", _dataList)
            );

    }

    public static DataSet getListRptStudentKPITransection(string _facultyId, string _programId, string _studyYear)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptGetListStudentKPITransection", CommandType.StoredProcedure,
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("programId", _programId),
                new SqlParameter("studyYear", _studyYear)
            );
    }

    public static DataSet getApiPermission(string apiKey,string serviceName)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetApiPermission", CommandType.StoredProcedure,
                new SqlParameter("apiKey", apiKey),
                new SqlParameter("serviceName", serviceName)
            );
    }

    public static DataSet getListRptHidefSummary(string _facultyId, string _programId, string _studyYear)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptGetListHidefSummary", CommandType.StoredProcedure,
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("programId", _programId),
                new SqlParameter("studyYear", _studyYear)
            );
    }

    public static DataSet getRequestDoc(string _studentId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetRequestDoc", CommandType.StoredProcedure,
                new SqlParameter("studentId", _studentId)
            );
    }
    public static DataSet setRequestDoc(string _studentId, string _ddlRequestReason, string _txtOtherReason, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetRequestDoc", CommandType.StoredProcedure,
                new SqlParameter("studentId", _studentId),
                new SqlParameter("requestReasonId", _ddlRequestReason),
                new SqlParameter("otherReason", _txtOtherReason),
                new SqlParameter("username", _username)

            );
    }
    public static DataSet setCancelRequestDoc(int _requestDocId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelRequestDoc", CommandType.StoredProcedure,
                new SqlParameter("requestDocId", _requestDocId),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet getListRequestReason()
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListRequestReason", CommandType.StoredProcedure);
    }

    public static DataSet setNewClub(string _txtClubNameTh, string _txtClubNameEn, string _txtClubDetailTh
        , string _txtClubDetailEn, string _txtMail, string _txtPlace, string _txtPhone, string _facultyId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetNewClub", CommandType.StoredProcedure,
                new SqlParameter("ClubNameTh", _txtClubNameTh),
                new SqlParameter("ClubNameEn", _txtClubNameEn),
                new SqlParameter("ClubDetailTh", _txtClubDetailTh),
                new SqlParameter("ClubDetailEn", _txtClubDetailEn),
                new SqlParameter("Mail", _txtMail),
                new SqlParameter("Place", _txtPlace),
                new SqlParameter("Phone", _txtPhone),
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("username", _username)
            );
    }



    public static DataSet getListStudentInClub(string _clubId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListStudentInClub", CommandType.StoredProcedure,
            new SqlParameter("clubId", _clubId));
    }

    public static DataSet getListClub(string _facultyId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListClub", CommandType.StoredProcedure,
            new SqlParameter("facultyId", _facultyId));
    }

    public static DataSet setCancelClub(string _clubId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelClub", CommandType.StoredProcedure,
                new SqlParameter("clubId", _clubId),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet setCancelStudentInClub(string _id, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetCancelStudentInClub", CommandType.StoredProcedure,
                new SqlParameter("id", _id),
                new SqlParameter("username", _username)
            );
    }
    public static DataSet setNewStudentInClubByStudentCode(string _ddlAcaYear, string _ddlSemester,string _ddlClub,string _ddlPosition ,string _txtStudentCode, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetStudentInClubByStudentCode", CommandType.StoredProcedure,
                new SqlParameter("acaYear", _ddlAcaYear),
                new SqlParameter("semester", _ddlSemester),
                new SqlParameter("ClubId", _ddlClub),
                new SqlParameter("PositionId", _ddlPosition),
                new SqlParameter("StudentCode", _txtStudentCode),
                new SqlParameter("username", _username)
            );
    }
    public static DataSet setNewStudentInClubByFile(string _ddlAcaYear,string _ddlSemester, string _ddlClub ,DataTable _dt ,string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetStudentInClubByFile", CommandType.StoredProcedure,
                new SqlParameter("acaYear", _ddlAcaYear),
                new SqlParameter("semester", _ddlSemester),
                new SqlParameter("ClubId", _ddlClub),
                new SqlParameter("dataList", _dt),
                new SqlParameter("username", _username)
            );
    }
    public static DataSet getListClubById(string _clubId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListClubById", CommandType.StoredProcedure,
            new SqlParameter("clubId", _clubId));
    }

    public static DataSet setEditClub(string _txtClubNameTh, string _txtClubNameEn, string _txtClubDetailTh
    , string _txtClubDetailEn, string _txtMail, string _txtPlace, string _txtPhone, string _clubId, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetEditClub", CommandType.StoredProcedure,
                new SqlParameter("ClubNameTh", _txtClubNameTh),
                new SqlParameter("ClubNameEn", _txtClubNameEn),
                new SqlParameter("ClubDetailTh", _txtClubDetailTh),
                new SqlParameter("ClubDetailEn", _txtClubDetailEn),
                new SqlParameter("Mail", _txtMail),
                new SqlParameter("Place", _txtPlace),
                new SqlParameter("Phone", _txtPhone),
                new SqlParameter("clubId", _clubId),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet getListTransStudentClub(string _studentCode)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListTransStudentClub", CommandType.StoredProcedure,
            new SqlParameter("studentCode", _studentCode));
    }

    public static DataSet getListActATHIDEF(string _studentCode)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptGetListActATHIDEF", CommandType.StoredProcedure,
         new SqlParameter("studentCode", _studentCode)
     );
    }

    public static DataSet getValidateForSubmitProject(string _projectid)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetValidateForSubmitProject", CommandType.StoredProcedure,
                new SqlParameter("projectid", _projectid)
            );
    }

    public static DataSet setSubmitProject(string _projectid, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetSubmitProject", CommandType.StoredProcedure,
                new SqlParameter("projectid", _projectid),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet getListDetailForSendmail(string projectId)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetListProjectDetailForSendmail", CommandType.StoredProcedure,
                new SqlParameter("projectId", projectId)
            );
    }

    public static DataSet setStudentSurveyAPI(DataTable _dataList, string _username)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetStudentSurveyAPI", CommandType.StoredProcedure,
                new SqlParameter("dataList", _dataList),
                new SqlParameter("username", _username)
            );
    }

    public static DataSet getCheckStudentSurveyWeSpace(string _studentId,string yearBE)
    {
        return DbConfiguration.ExecuteQuery("sp_actGetCheckStudentSurveyWeSpace", CommandType.StoredProcedure,
                new SqlParameter("studentId", _studentId),
                new SqlParameter("academicYear", yearBE)
            );
    }

    public static DataSet setProjectSendMail(string _projectId, string _remark, DateTime _expiryDate, string _username,string txtCreatedBy)
    {
        return DbConfiguration.ExecuteQuery("sp_actSetProjectSendMail", CommandType.StoredProcedure,
                new SqlParameter("projectId", _projectId),
                new SqlParameter("remark", _remark),
                new SqlParameter("expiryDate", _expiryDate),
                new SqlParameter("username", _username),
                new SqlParameter("receiver", txtCreatedBy)
            );
    }


    public static DataSet getListRpt21StSummary(string _facultyId, string _programId, string _studyYear)
    {
        return DbConfiguration.ExecuteQuery("sp_actRptGetList21StSummary", CommandType.StoredProcedure,
                new SqlParameter("facultyId", _facultyId),
                new SqlParameter("programId", _programId),
                new SqlParameter("studyYear", _studyYear)
            );
    }

    public static DataSet getListYearFillterReport()
    {
        return DbConfiguration.ExecuteQuery("SELECT distinct year([SnapShotDate])+543 as 'year'  FROM [Infinity].[dbo].[actSnapShotStatisticDepartment] ");
    }

    public static DataSet getListMonthFillterReport()
    {
        return DbConfiguration.ExecuteQuery("Select * From fnc_reqGetListMonth()");
    }
    

}