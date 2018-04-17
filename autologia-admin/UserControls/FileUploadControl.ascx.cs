using System;
using System.Configuration;

public partial class UserControls_FileUploadControl : System.Web.UI.UserControl
{
    private string _accessName;
    public string AccessName
    {
        get { return _accessName; }
        set
        {
            _accessName = value;
            FileUpload1.Attributes["onchange"] = string.Format("FileSelected_{0}(this.value)", value);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (FileUpload1.FileName != null && FileUpload1.FileBytes.Length != 0)
        {
            string path =
                Server.MapPath("~\\" + ConfigurationManager.AppSettings["UploadFilesFolder"] + "\\" +
                               FileUpload1.FileName);
            FileUpload1.SaveAs(path);
        }
    }
}