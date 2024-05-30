<%@ WebHandler Language="C#" Class="actConfigHandler" %>

using System;
using System.Web;
using System.Text;
using System.Data;
public class actConfigHandler : IHttpHandler {

    public HttpContext _c;
    string _username;
    string _facultyIdPermission;
    string _facultyNamePermission;
    string _facultyCodePermission;
    string _levelPermission;
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        _c = context;
        string _act = _c.Request["action"];
        Login _login = new Login("staff");
        _username = _login.Username;
        //_username = "jate.khr"; // เอาขึ้น 10.90.101.101

        DataSet _ds = ActDB.getPermission(_username);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow _dr in _ds.Tables[0].Rows)
            {
                _facultyIdPermission = _dr["facultyId"].ToString();
                _facultyNamePermission = _dr["facultyNameTh"].ToString();
                _facultyCodePermission = _dr["facultyCode"].ToString();
                _levelPermission = _dr["levelPermission"].ToString();
            }
        }
        else
        {
            _c.Response.Redirect("https://smartedu.mahidol.ac.th/Authen/staff/login.aspx");
        }

        switch (_act)
        {
            case "getListConfigManage":
                getListConfigManage();
                break;
            case "loadSlidebarMenu":
                loadSlidebarMenu();
                break;
            case "loadBarMenu":
                loadBarMenu();
                break;

            case "setIndicator":
                setIndicator();
                break;
            case "setCharater":
                setCharater();
                break;
            case "setBudgetType":
                setBudgetType();
                break;
            case "setDeviceInfo":
                setDeviceInfo();
                break;
            case "setGroupCharacter":
                setGroupCharacter();
                break;
            case "editConfigIndicator":
                editConfigIndicator();
                break;
            case "setUpdateConfigIndicator":
                setUpdateConfigIndicator();
                break;
            case "editConfigCharacter":
                editConfigCharacter();
                break;
            case "setUpdateConfigCharater":
                setUpdateConfigCharater();
                break;
            case "editConfigBudget":
                editConfigBudget();
                break;

            case "setUpdateConfigBudget":
                setUpdateConfigBudget();
                break;
            case "editConfigDevice":
                editConfigDevice();
                break;
            case "setUpdateConfigDevice":
                setUpdateConfigDevice();
                break;
            case "editConfigGroupCharacter":
                editConfigGroupCharacter();
                break;

            case "setUpdateConfigGroupCharacter":
                setUpdateConfigGroupCharacter();
                break;

            case "setCancelConfigIndicator":
                setCancelConfigIndicator();
                break;

            case "setCancelConfigCharacter":
                setCancelConfigCharacter();
                break;

            case "setCancelConfigBudget":
                setCancelConfigBudget();
                break;
            case "setCancelConfigDevice":
                setCancelConfigDevice();
                break;
            case "setCancelConfigGroupCharacter":
                setCancelConfigGroupCharacter();
                break;
        }
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: ยกเลิกรายการ setCancelConfigGroupCharacter
    /// Method : setCancelConfigGroupCharacter
    public void setCancelConfigGroupCharacter()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _groupCharacterId = _c.Request["groupCharacterId"];
        ActDB.setCancelConfigGroupCharacter(_groupCharacterId, _username);
        _c.Response.Write(_returnText);

    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: ยกเลิกรายการ setCancelConfigDevice
    /// Method : setCancelConfigDevice
    public void setCancelConfigDevice()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _deviceId = _c.Request["deviceId"];
        ActDB.setCancelConfigDevice(_deviceId, _username);
        _c.Response.Write(_returnText);

    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: ยกเลิกรายการ ConfigBudget
    /// Method : setCancelConfigBudget
    public void setCancelConfigBudget()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _budgetId = _c.Request["budgetId"];
        ActDB.setCancelConfigBudget(_budgetId, _username);
        _c.Response.Write(_returnText);

    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: ยกเลิกรายการ ConfigCharacter
    /// Method : setCancelConfigCharacter
    public void setCancelConfigCharacter()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _characterId = _c.Request["characterId"];
        ActDB.setCancelConfigCharacter(_characterId, _username);
        _c.Response.Write(_returnText);

    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: ยกเลิกรายการ ConfigIndicator
    /// Method : setCancelConfigIndicator
    public void setCancelConfigIndicator()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _indicatorId = _c.Request["indicatorId"];
        ActDB.setCancelConfigIndicator(_indicatorId,_username);
        _c.Response.Write(_returnText);

    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: update ข้อมูล Group Character ใหม่
    /// Method : setUpdateConfigGroupCharacter
    public void setUpdateConfigGroupCharacter()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _groupCharacterNameTh = _c.Request["groupCharacterNameTh"];
        string _groupCharacterNameEn = _c.Request["groupCharacterNameEn"];
        string _groupCharacterAbbrevTh = _c.Request["groupCharacterAbbrevTh"];
        string _groupCharacterAbbrevEn = _c.Request["groupCharacterAbbrevEn"];
        string _startYear = _c.Request["startYear"];
        string _endYear = _c.Request["endYear"];
        string _groupCharacterId = _c.Request["groupCharacterId"];
        ActDB.setUpdateConfigGroupCharacter(_groupCharacterNameTh,
                                 _groupCharacterNameEn,
                                 _groupCharacterAbbrevTh,
                                 _groupCharacterAbbrevEn,
                                 _startYear,
                                 _endYear,
                                 _username,
                                 _uId,
                                 _facultyIdPermission,
                                 _groupCharacterId);
        _c.Response.Write(_returnText);

    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: แสดงรายการข้อมูลสำหรับ editConfigGroupCharacter
    /// Method : editConfigGroupCharacter
    /// Sample : N/A
    public void editConfigGroupCharacter()
    {

        string _groupCharacterId = _c.Request["groupCharacterId"];
        string _html = ActUI.editConfigGroupCharacter(_groupCharacterId);

        _c.Response.Write(_html);


    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: Update ข้อมูล DeviceInfo ใหม่
    /// Method : setUpdateConfigDevice
    public void setUpdateConfigDevice()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _deviceInfoNameTh = _c.Request["deviceInfoNameTh"];
        string _deviceInfoNameEn = _c.Request["deviceInfoNameEn"];
        string _deviceNumber = _c.Request["deviceNumber"];
        string _deviceId = _c.Request["deviceId"];

        ActDB.setUpdateConfigDevice(_deviceInfoNameTh,
                                 _deviceInfoNameEn,
                                 _deviceNumber,
                                 _username,
                                 _uId,
                                 _deviceId);
        _c.Response.Write(_returnText);

    }




    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: แสดงรายการข้อมูลสำหรับ editConfigDevice
    /// Method : editConfigDevice
    /// Sample : N/A
    public void editConfigDevice()
    {

        string _deviceId = _c.Request["deviceId"];
        string _html = ActUI.editConfigDevices(_deviceId);

        _c.Response.Write(_html);


    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: Update ข้อมูล BudgetType 
    /// Method : setUpdateConfigBudget
    public void setUpdateConfigBudget()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _budgetTypeNameTh = _c.Request["budgetTypeNameTh"];
        string _budgetTyperNameEn = _c.Request["budgetTyperNameEn"];
        string _startYear = _c.Request["startYear"];
        string _endYear = _c.Request["endYear"];
        string _budgetId = _c.Request["budgetId"];

        ActDB.setUpdateConfigBudget(_budgetTypeNameTh,
                                 _budgetTyperNameEn,
                                 _startYear,
                                 _endYear,
                                 _username,
                                 _uId,
                                 _budgetId);
        _c.Response.Write(_returnText);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: แสดงรายการข้อมูลสำหรับ edit Config Budget
    /// Method : editConfigBudget
    /// Sample : N/A
    public void editConfigBudget()
    {

        string _budgetId = _c.Request["budgetId"];
        string _html = ActUI.editConfigBudget(_budgetId);

        _c.Response.Write(_html);


    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: Update ข้อมูล Charater ใหม่
    /// Method : setUpdateConfigCharater
    public void setUpdateConfigCharater()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _characterId = _c.Request["characterId"];
        string _uId = _c.Request["uId"];
        string _characterNameTh = _c.Request["characterNameTh"];
        string _characterNameEn = _c.Request["characterNameEn"];
        string _characterAbbrevTh = _c.Request["characterAbbrevTh"];
        string _characterAbbrevEn = _c.Request["characterAbbrevEn"];
        string _startYear = _c.Request["startYear"];
        string _endYear = _c.Request["endYear"];
        string _groupCharacterId = _c.Request["groupCharacterId"];



        ActDB.setUpdateConfigCharater(_characterNameTh,
                            _characterNameEn,
                            _characterAbbrevTh,
                            _characterAbbrevEn,
                            _startYear,
                            _endYear,
                            _groupCharacterId,
                            _username,
                            _facultyIdPermission,
                            _uId,
                            _characterId);
        _c.Response.Write(_returnText);
    }



    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: แสดงรายการข้อมูลสำหรับ edit Config Character
    /// Method : editConfigCharacter
    /// Sample : N/A
    public void editConfigCharacter()
    {

        string _characterId = _c.Request["characterId"];
        string _html = ActUI.editConfigCharacter(_characterId,_facultyIdPermission);

        _c.Response.Write(_html);


    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: Update ข้อมูล Indicator ใหม่
    /// Method : setUpdateConfigIndicator
    public void setUpdateConfigIndicator()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _indicatorId = _c.Request["indicatorId"];
        string _indicatorNameTh = _c.Request["indicatorNameTh"];
        string _indicatorNameEn = _c.Request["indicatorNameEn"];
        string _indicatorAbbrevTh = _c.Request["indicatorAbbrevTh"];
        string _indicatorAbbrevEn = _c.Request["indicatorAbbrevEn"];
        string _startYear = _c.Request["startYear"];
        string _endYear = _c.Request["endYear"];
        ActDB.setUpdateConfigIndicator(_indicatorNameTh,
                            _indicatorNameEn,
                            _indicatorAbbrevTh,
                            _indicatorAbbrevEn,
                            _startYear,
                            _endYear,
                            _username,
                            _facultyIdPermission,
                            _uId,
                            _indicatorId);
        _c.Response.Write(_returnText);
    }




    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 20 มิ.ย. 2560
    /// Perpose: แสดงรายการข้อมูลสำหรับ Edit Config Indicator
    /// Method : editConfigIndicator
    /// Sample : N/A
    public void editConfigIndicator()
    {

        string _indicatorId = _c.Request["indicatorId"];
        string _html = ActUI.editConfigIndicator(_indicatorId, _facultyIdPermission);

        _c.Response.Write(_html);


    }



    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 6 มิ.ย. 2560
    /// Perpose: Insert ข้อมูล Group Character ใหม่
    /// Method : setGroupCharacter
    public void setGroupCharacter()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _groupCharacterNameTh = _c.Request["groupCharacterNameTh"];
        string _groupCharacterNameEn = _c.Request["groupCharacterNameEn"];
        string _groupCharacterAbbrevTh = _c.Request["groupCharacterAbbrevTh"];
        string _groupCharacterAbbrevEn = _c.Request["groupCharacterAbbrevEn"];
        string _startYear = _c.Request["startYear"];
        string _endYear = _c.Request["endYear"];

        ActDB.setGroupCharacter(_groupCharacterNameTh,
                                 _groupCharacterNameEn,
                                 _groupCharacterAbbrevTh,
                                 _groupCharacterAbbrevEn,
                                 _startYear,
                                 _endYear,
                                 _username,
                                 _uId,
                                 _facultyIdPermission);
        _c.Response.Write(_returnText);

    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 3 มิ.ย. 2560
    /// Perpose: Insert ข้อมูล DeviceInfo ใหม่
    /// Method : setDeviceInfo
    public void setDeviceInfo()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _deviceInfoNameTh = _c.Request["deviceInfoNameTh"];
        string _deviceInfoNameEn = _c.Request["deviceInfoNameEn"];
        string _deviceNumber = _c.Request["deviceNumber"];

        ActDB.setDeviceInfo(     _deviceInfoNameTh,
                                 _deviceInfoNameEn,
                                 _deviceNumber,
                                 _username,
                                 _uId);
        _c.Response.Write(_returnText);

    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 3 มิ.ย. 2560
    /// Perpose: Insert ข้อมูล BudgetType ใหม่
    /// Method : setBudgetType
    public void setBudgetType()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _budgetTypeNameTh = _c.Request["budgetTypeNameTh"];
        string _budgetTyperNameEn = _c.Request["budgetTyperNameEn"];
        string _startYear = _c.Request["startYear"];
        string _endYear = _c.Request["endYear"];

        ActDB.setBudgetType(     _budgetTypeNameTh,
                                 _budgetTyperNameEn,
                                 _startYear,
                                 _endYear,
                                 _username,
                                 _uId,
                                 _facultyIdPermission);
        _c.Response.Write(_returnText);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 3 มิ.ย. 2560
    /// Perpose: Insert ข้อมูล Charater ใหม่
    /// Method : setCharater
    public void setCharater()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _characterNameTh = _c.Request["characterNameTh"];
        string _characterNameEn = _c.Request["characterNameEn"];
        string _characterAbbrevTh = _c.Request["characterAbbrevTh"];
        string _characterAbbrevEn = _c.Request["characterAbbrevEn"];
        string _startYear = _c.Request["startYear"];
        string _endYear = _c.Request["endYear"];
        string _groupCharacterId = _c.Request["groupCharacterId"];

        ActDB.setCharater(_characterNameTh,
                            _characterNameEn ,
                            _characterAbbrevTh ,
                            _characterAbbrevEn ,
                            _startYear ,
                            _endYear ,
                            _groupCharacterId ,
                            _username ,
                            _facultyIdPermission ,
                            _uId);
        _c.Response.Write(_returnText);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 3 มิ.ย. 2560
    /// Perpose: Insert ข้อมูล Indicator ใหม่
    /// Method : setIndicator
    public void setIndicator()
    {
        string _returnText = "บันทึกข้อมูลเรียบร้อย";
        string _uId = _c.Request["uId"];
        string _indicatorNameTh = _c.Request["indicatorNameTh"];
        string _indicatorNameEn = _c.Request["indicatorNameEn"];
        string _indicatorAbbrevTh = _c.Request["indicatorAbbrevTh"];
        string _indicatorAbbrevEn = _c.Request["indicatorAbbrevEn"];
        string _startYear = _c.Request["startYear"];
        string _endYear = _c.Request["endYear"];

        ActDB.setIndicator(_indicatorNameTh,
                            _indicatorNameEn,
                            _indicatorAbbrevTh,
                            _indicatorAbbrevEn,
                            _startYear,
                            _endYear,
                            _username,
                            _facultyIdPermission,
                            _uId);
        _c.Response.Write(_returnText);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 8 พ.ค. 2560
    /// Perpose: แสดงเมนู Menu bar
    /// Method : loadBarMenu
    /// Sample : N/A
    public void loadBarMenu()
    {
        string _html = ActUI.loadBarMenu(_username,_facultyCodePermission,_facultyNamePermission);

        _c.Response.Write(_html);
    }

    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 8 พ.ค. 2560
    /// Perpose: แสดงเมนู Side bar
    /// Method : loadSlidebarMenu
    /// Sample : N/A
    public void loadSlidebarMenu()
    {
        string _html = ActUI.loadSlidebarMenu(_levelPermission,_facultyCodePermission);
        _c.Response.Write(_html);
    }


    /// Auther : เจตน์ เครือชะเอม
    /// Date   : 2 มิ.ย. 2560
    /// Perpose: แสดงรายการข้อมูลเพื่อ Config ข้อมูลตั้งต้น
    /// Method : getListConfigManage
    /// Sample : N/A
    public void getListConfigManage()
    {
        string _html = ActUI.getListConfigIndicator(_facultyIdPermission);
        _c.Response.Write(_html);
    }


    public bool IsReusable {
        get {
            return false;
        }
    }

}