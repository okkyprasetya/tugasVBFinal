<%@ page language="vb" autoeventwireup="false" codebehind="latihan1.aspx.vb" inherits="studentAdmissionWebApp.latihan1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<%--    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td align="right">Username :</td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rvUsername" runat="server"
                            ErrorMessage="Username masih kosong"
                            ControlToValidate="txtUsername" SetFocusOnError="true" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit"
                            OnClick="btnSubmit_Click" />
                    </td>
                    <td></td>
                </tr>
            </table>
            <hr />
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>
    </form>--%>
    <form id="form2" runat="server">
        <div>
            <asp:FileUpload id="fpImage" runat="server"/><br /><br />
            <asp:Button ID="buttonUpload_Click" Text="Upload File" runat="server" onClick="buttonUpload_Click_Click"/><br /><br />
            <asp:DataList ID="dlImage" runat="server" RepeatColumns="3">
                <ItemTemplate>
                    <asp:Image ID="imgUpload" 
                        ImageUrl='<%# Eval("Name", "~/UploadImage/{0}") %>' Width="200px" 
                        runat="server" />
                </ItemTemplate>
            </asp:DataList>
            <asp:Label ID="lblError" ForeColor="Red" runat="server" />
        </div>
    </form>
</body>
</html>
