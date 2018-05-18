<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Monitoramento.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Cadastro de Cliente</h2>
            <table>
                <tr>
                    <td>Nome</td>
                </tr>
                <tr>
                    <td><asp:TextBox runat="server" ID="txtnome"/></td>
                </tr>
                <tr>
                    <td>Descriçao</td>
                </tr>
                <tr>
                    <td><asp:TextBox runat="server" ID="txtdescricao"/></td>
                </tr>
                <tr>
                    <td>Quantidade de Camera</td>
                </tr>
                <tr>
                    <td><asp:TextBox runat="server" ID="txtqtd_camera" OnTextChanged="txtqtd_camera_TextChanged" AutoPostBack="true"/></td>
                </tr>
                <tr>
                    <td>Valor do Pacote</td>
                </tr>
                <tr>
                    <td><asp:TextBox runat="server" ID="txtvalor_pacote" OnTextChanged="txtvalor_pacote_TextChanged"  AutoPostBack="true"/></td>
                </tr>
                <tr>
                    <td>Fidelidade</td>
                </tr>
                <tr>
                    <td> <asp:CheckBox ID="chckfidelidade" runat="server" Text="Sim" OnCheckedChanged="chckfidelidade_CheckedChanged"  AutoPostBack="true"/>  </td>
                </tr>
                <tr>
                    <td>Plano</td>
                </tr>
                <tr>
                    <td><asp:TextBox runat="server" ID="txtplano"  /></td>
                </tr>
                <tr>
                    <td>Valor Total</td>
                </tr>
                <tr>
                    <td><asp:TextBox runat="server" ID="txtvalor_total" /></td>
                </tr><tr>
                    <td> <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" /> </td>
                </tr>
            </table>
            <br>

            <asp:GridView ID="GridMonitoramento" runat="server" AutoGenerateColumns="true"></asp:GridView>
           
        </div>
    </form>
</body>
</html>
