﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class modules_student_actRptMahidolCore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.StylesRegister("Bootstrap", "DataTable", "ActivityTranscript");
        Page.ScriptsRegister("Bootstrap", "DataTable", "ActivityTranscript");
    }
}