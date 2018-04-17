<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FileUploadControl.ascx.cs"
    Inherits="UserControls_FileUploadControl" %>
<script type="text/javascript">
    function SubmitUpload_<%=AccessName %>() {
        document.getElementById('Submit_<%=AccessName %>').click();
        var fileName = document.getElementById('fileName_<%=AccessName %>').value;
        return fileName;
    }

    function FileSelected_<%=AccessName %>(value) {
        var start = value.lastIndexOf('\\');
        if (start != -1)
            value = value.substr(start + 1);

        document.getElementById('fileName_<%=AccessName %>').value = value;
    }
</script>
<div>
    <input id="fileName_<%=AccessName %>" type="hidden" />
    <div style="text-align: right">
        <asp:FileUpload ID="FileUpload1" runat="server" size="20" CssClass="file-upload" />
    </div>
    <input id="Submit_<%=AccessName %>" type="button" value="submit" onclick="submit()" style="display: none" />
</div>
