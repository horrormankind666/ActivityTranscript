using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for ScriptsRegister
/// </summary>
public class PageConfiguration
{
    Dictionary<string, string[]> Scripts;
    Dictionary<string, string[]> Styles;
    public PageConfiguration()
    {
        Scripts = new Dictionary<string, string[]>();
        Styles = new Dictionary<string, string[]>();

        //กำหนดค่าการลงทะเบียน file scripts
        Scripts.Add("Bootstrap", new string[] {
            //"/jquery-3.1.1.js",
            "/jquery-2.js",
            "/jquery-ui.js",
            "/scripts/moment-with-locales.js",
            "/scripts/bootstrap/js/bootstrap.js",
            "/scripts/bootstrap/js/bootstrap-select.js",
            "/scripts/bootstrap/js/bootstrap-datetimepicker.js"
        });

        Scripts.Add("DataTable", new string[] { 
            "/scripts/datatables/*.js",
        });

        Scripts.Add("ActivityTranscript", new string[] { 
            "/scripts/sitescript.js",
            "/scripts/main.js",
            "/scripts/heightchart/highcharts.js",
            "/scripts/heightchart/highcharts-more.js",
            "/scripts/heightchart/modules/exporting.js",
             "/scripts/heightchart/modules/export-data.js"
        });

        Scripts.Add("jstree", new string[] { 
            "/scripts/jstree/jstree.min.js"
        });

        //กำหนดค่าการลงทะเบียน file stylesheets
        Styles.Add("Bootstrap", new string[] { 
            "/contents/normalize.css",
            "/contents/bootstrap/css/bootstrap.css",
            "/contents/bootstrap/css/bootstrap-theme.css",
            "/contents/bootstrap/css/bootstrap-select.min.css",
            "/contents/bootstrap/css/bootstrap-datetimepicker.css",
            //"/contents/bootstrap/simple-sidebar.css",
        });

        Styles.Add("DataTable", new string[] { 
            "/contents/datatables/*.css",
        });

        Styles.Add("ActivityTranscript", new string[] { 
            "/contents/sitecontent.css",
            "/contents/jquery-ui.css"
        });

        Styles.Add("jstree", new string[] { 
            "/contents/jstree/style.min.css"
        });
    }
    public Dictionary<string, string[]> GetScripts()
    {
        return this.Scripts;
    }
    public Dictionary<string, string[]> GetStyles() 
    {
        return Styles; // form-group
    }
}