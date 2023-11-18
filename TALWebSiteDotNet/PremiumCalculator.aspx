<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PremiumCalculator.aspx.cs" Inherits="TALWebSiteDotNet.PremiumCalculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TAL Premium Calculator</title>
    <style type="text/css">
        .auto-style1 {
            width: 267px;
        }
        .auto-style2 {
            width: 241px;
        }
    </style>
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css"/>
    <script src="Scripts/CalculateAge.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#txtDOB").datepicker({
                dateFormat: "dd/mm/yy"
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>TAL Premium Calculator</h1>
        </div>
        <table style="width: 100%;" class="styled-table">
            <tr>
                <td class="auto-style2">Name:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtName" runat="server" MaxLength="50" ToolTip="Client name" Width="100%" CausesValidation="True"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Must provide name" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revName" runat="server" ControlToValidate="txtName" ErrorMessage="Name contains invalid characters" ForeColor="#FF3300" Display="Dynamic" ValidationExpression="^([a-zA-Z \'-]{1,40})"></asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td class="auto-style2">DOB:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtDOB" runat="server" MaxLength="12" Width="100%" CausesValidation="True" onchange="CalculateAge(this)"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="txtDOB" ErrorMessage="Must provide DOB" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revDOB" runat="server" ControlToValidate="txtDOB" ErrorMessage="Not a valid date (dd/mm/yyyy)" ForeColor="#FF3300" Display="Dynamic" ValidationExpression="(^(((0[1-9]|1[0-9]|2[0-8])[\/](0[1-9]|1[012]))|((29|30|31)[\/](0[13578]|1[02]))|((29|30)[\/](0[4,6,9]|11)))[\/](19|[2-9][0-9])\d\d$)|(^29[\/]02[\/](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)"></asp:RegularExpressionValidator>
                </td>
            </tr>

            <tr>
                <td class="auto-style2">Age:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtAge" runat="server" Width="70%" AutoPostBack="True"></asp:TextBox>
                    <asp:Label ID="lblYears" runat="server" Text="year(s)" Enabled="false"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="auto-style2">Death – Sum Insured:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtSI" runat="server" MaxLength="10" Width="100%" CausesValidation="True"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvSI" runat="server" ControlToValidate="txtSI" ErrorMessage="Must provide SI" ForeColor="#FF3300" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revSI" runat="server" ControlToValidate="txtSI" ErrorMessage="SI must have digits only" ForeColor="#FF3300" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            <tr>
                <td class="auto-style2" style="vertical-align:top" >Occupation:</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlOccupation" DataTextField="OccupationName" DataValueField="OccupationId" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlOccupation_SelectedIndexChanged" OnDataBound="ddlOccupation_DataBound">
                    </asp:DropDownList>
                </td>
            </tr>
            
        </table>
        <br />
        <asp:Button ID="btnCalculate" runat="server" OnClick="btnCalculate_Click" Text="Calculate Monthly Premium" />
        <br />
        <div>
            <h4>Monthly premium for the occupation and age:</h4>
            <span>
                <asp:TextBox ID="txtMonthlyPremium" runat="server" MaxLength="5" readonly="true" Width="10%"/>$
            </span>
        </div>
    </form>
</body>
</html>
