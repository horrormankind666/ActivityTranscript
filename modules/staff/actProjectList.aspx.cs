using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class modules_staff_actProjectList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.StylesRegister("Bootstrap", "DataTable", "ActivityTranscript");
        Page.ScriptsRegister("Bootstrap", "DataTable", "ActivityTranscript");

        //Random generator = new Random();
        //int _number = 5;
        //String _newGendigit = _number.ToString("D5");
        //Response.Write(_newGendigit);

        //string _data = "OPRL00035";

        //string _dataRunning = "";

        //int _maxLength = _data.Length;
        //int _stringMax = 0;

        ////Response.Write(_maxLength);
        //Response.Write("DATA : "+_data);
        //for (int i=0; i<_maxLength; i++)
        //{
        //    //Response.Write(i);
        //            //Response.Write(_data.Substring(i,1));
        //            try
        //            {
        //                int result = int.Parse(_data.Substring(i, 1));
        //                //Response.Write(" Valid integer: " + _data.Substring(i, 1));

        //            }
        //            catch
        //            {
        //                //Response.Write(" Valid string: " + _data.Substring(i, 1));
        //                if (_stringMax < i)
        //                {
        //                    _stringMax = i; 
        //                }
        //            }
        //}
        ////Response.Write(" ตำแหน่งสตริงมากสุดคือ "+_stringMax);
        ////Response.Write(" เลขรันนิ่งที่ต้องรันต่อ " + _data.Substring(_stringMax+1));

        //_dataRunning = _data.Substring(_stringMax+1);
        //String _running = (Convert.ToInt64(_dataRunning) + 1).ToString("D"+_data.Substring(_stringMax).Length);
        //String _result = _data.Substring(0, _stringMax + 1) + _running;
        //Response.Write(" RESULT : "+_result);

        //divSlideBarMenu.InnerHtml = ActUI.loadSlidebarMenu();
        //divBarMenu.InnerHtml = ActUI.loadBarMenu();




        //string _data = "OPRL0099";
        //string _dataRunning = "";
        //int _maxLength = _data.Length;
        //int _stringMax = 0;
        //Response.Write("DATA : " + _data);
        //for (int i = 0; i < _maxLength; i++)
        //{
        //    try
        //    {
        //        int result = int.Parse(_data.Substring(i, 1));
        //    }
        //    catch
        //    {
        //        if (_stringMax < i)
        //        {
        //            _stringMax = i;
        //        }
        //    }
        //}

        ////Response.Write(_data.Substring(_stringMax+1).Length);
        //_dataRunning = _data.Substring(_stringMax + 1);
        //String _running = (Convert.ToInt64(_dataRunning) + 1).ToString("D" + _data.Substring(_stringMax).Length);

        //String _result = _data.Substring(0, _stringMax + 1) + TakeLast("0000000000" + _running, _data.Substring(_stringMax+1).Length);
        ////Response.Write(_result);
        //Response.Write(" RESULT : " + _result);
    }

    //private string TakeLast(string input, int num)
    //{
    //    if (num > input.Length)
    //    {
    //        num = input.Length;
    //    }
    //    return input.Substring(input.Length - num);
    //}
  
}