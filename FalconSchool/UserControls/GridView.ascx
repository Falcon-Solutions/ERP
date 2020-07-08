<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GridView.ascx.cs" Inherits="FalconSchool.User_Controls.GridView" %>

<%@ Import Namespace="System.Reflection" %>


<%-- Show the Headers --%>
<div class="form-group">
    <div class="card">
        <h5 class="card-header hidden"></h5>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-striped table-bordered first">
                    <thead>
                        <tr>
                            <% foreach (PropertyInfo prop in this.Columns)
                                { %>
                            <th><%= prop.Name %></th>
                            <% } %>
                        </tr>
                    </thead>
                    <%-- Show the Rows --%>
                    <tbody>

                        <% foreach (object row in this.Rows)
                            { %>
                        <tr class="<%= this.FlipCssClass( "item", "alternatingItem") %>">

                            <%-- Show Each Column --%>
                            <% foreach (PropertyInfo prop in this.Columns)
                                { %>

                            <td><% var typeCode = Type.GetTypeCode(prop.PropertyType); %>


                                <%-- String Columns --%>
                                <% if (typeCode == TypeCode.String)
                                    { %>
                                <%= GetColumnValue(row, prop.Name)%>

                                <% } %>

                                <%-- DateTime Columns --%>
                                <% if (typeCode == TypeCode.DateTime)
                                    { %>

                                <%= GetColumnValue(row, prop.Name, "{0:D}")%>

                                <% } %>


                                <%-- Decimal Columns --%>
                                <% if (typeCode == TypeCode.Decimal)
                                    { %>

                                <%= GetColumnValue(row, prop.Name, "{0:c}") %>

                                <% } %>


                                <%-- Boolean Columns --%>
                                <% if (typeCode == TypeCode.Boolean)
                                    { %>
                                <% if ((bool)(this.GetColumnValue(row, prop.Name)))
                                    { %>

                                <input type="checkbox" disabled="disabled" checked="checked" />
                                <% }
                                    else
                                    { %>

                                <input type="checkbox" disabled="disabled" />
                                <% } %>
                                <% } %>


                                <%-- Integer Columns --%>
                                <% if (typeCode == TypeCode.Int32)
                                    { %>

                                <%= GetColumnValue(row, prop.Name)%>

                                <% } %>
               
                            </td>
                            <% } %>
                           
                        </tr>
                        <% } %>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>
