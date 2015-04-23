<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyContentsDetails.ascx.cs" Inherits="MyCustomModule.Web.UI.MyContents.MyContentsDetails" %>
<%@ Register TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>

<sitefinity:ResourceLinks ID="resourcesLinks2" runat="server" UseEmbeddedThemes="true" Theme="Default">    
    <sitefinity:ResourceFile Name="MyCustomModule.Web.Resources.CustomStylesWebFormsView.css" AssemblyInfo="MyCustomModule.MyCustomModuleClass, MyCustomModule" Static="True" />
</sitefinity:ResourceLinks>
<div class="sfDialog sfFormDialog sfMaxDialogFake">
    <fieldset class="sfNewContentForm">
        <asp:HyperLink ID="goBackButton" runat="server" CssClass="sfBack">
                <asp:Literal runat="server" Text='<%$Resources:MyCustomModuleResources, BackToLabel %>'></asp:Literal>
        </asp:HyperLink>
        <h1>
            <asp:Literal ID="titleCreate" runat="server" Text='<%$Resources:MyCustomModuleResources, CreateAMyContent %>'></asp:Literal>
            <asp:Literal ID="titleEdit" runat="server" Text='<%$Resources:MyCustomModuleResources, EditAMyContent %>'></asp:Literal>
        </h1>
    
        <div class="sfForm sfFirstForm">
            <ul class="sfFormIn">
                <li class="sfTitleField">
                    <label for="<%= titleControl.ClientID %>" class="sfTxtLbl">
                        <asp:Literal runat="server" Text='<%$Resources:MyCustomModuleResources, MyContentTitleLabel %>'></asp:Literal>
                    </label>
                    <asp:TextBox ID="titleControl" runat="server" ValidationGroup="details" CssClass="sfTxt"></asp:TextBox>
                    <div class="sfExample">
                        <asp:Literal ID="myContentTitleDescription" runat="server" Text='<%$Resources:MyCustomModuleResources, MyContentTitleDescription %>'></asp:Literal>
                    </div>
                    <asp:RequiredFieldValidator ID="myContentTitleRequiredValidator" runat="server" ValidationGroup="details" ControlToValidate="titleControl" Display="Dynamic">
                        <div class="sfError"><asp:Literal runat="server" ID="myContentTitleCannotBeEmpty" Text='<%$Resources:MyCustomModuleResources, MyContentTitleCannotBeEmpty %>' /></div>
                    </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="myContentTitleLengthValidator" runat="server" ControlToValidate="titleControl" ValidationGroup="details" Display="Dynamic" ValidationExpression="^([\w\W]{1,255})$">
                        <div class="sfError"><asp:Literal ID="myContentTitleLengthErrorLiteral" runat="server" Text='<%$Resources:MyCustomModuleResources, MyContentTitleInvalidLength %>' /></div>
                    </asp:RegularExpressionValidator>
                </li>
                <li class="sfFormSeparator sfShortField80">
                    <label for="<%= myNumberControl.ClientID %>" class="sfTxtLbl">
                        <asp:Literal runat="server" Text='<%$Resources:MyCustomModuleResources, MyContentMyNumberLabel %>'></asp:Literal>
                    </label>
                    <asp:TextBox ID="myNumberControl" runat="server" CssClass="sfTxt"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="myContentMyNumberRegularExpressionValidator" runat="server" ControlToValidate="myNumberControl" ValidationGroup="details" Display="Dynamic" ValidationExpression="^-?\d{1,10}$">
                        <div class="sfError"><asp:Literal ID="myContentMyNumberIsInvalid" runat="server" Text='<%$Resources:MyCustomModuleResources, MyContentMyNumberIsInvalid %>' /></div>
                    </asp:RegularExpressionValidator>
                </li>
                <li class="sfFormSeparator">
                    <label for='<%= myDateControl.ClientID %>' class="sfTxtLbl">
                        <asp:Literal runat="server" Text='<%$Resources:MyCustomModuleResources, MyContentMyDateLabel %>'></asp:Literal>
                    </label>
					<telerik:RadDateTimePicker ID="myDateControl" runat="server">
                        <DateInput cssclass="sfTxt hasDatepicker valid" runat="server" DateFormat="MM/dd/yyyy HH:mm"></DateInput>
                        <Calendar>
                            <SpecialDays>
                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-CssClass="rcToday"></telerik:RadCalendarDay>
                            </SpecialDays>
                        </Calendar>
                        <TimeView TimeFormat="HH:mm:ss"></TimeView>
                    </telerik:RadDateTimePicker>
                </li>
            </ul>
        </div>

        <div class="sfButtonArea sfMainFormBtns">
            <asp:LinkButton ID="saveButton" runat="server" OnClick="OnSaveButtonClick" ValidationGroup="details" CausesValidation="true" CssClass="sfLinkBtn sfSave">
                <span id="createButtonText" runat="server" class="sfLinkBtnIn">
                    <asp:Literal runat="server" Text='<%$Resources:MyCustomModuleResources, CreateThisMyContentButton %>' />
                </span>
                <span id="saveChangesButtonText" runat="server" class="sfLinkBtnIn">
                    <asp:Literal runat="server" Text='<%$Resources:MyCustomModuleResources, SaveChangesLabel %>' />
                </span>
            </asp:LinkButton>
            <asp:HyperLink ID="cancelButton" runat="server" CssClass="sfCancel sfCancelMyContentButton">
                <asp:Literal runat="server" Text='<%$Resources:MyCustomModuleResources, CancelLabel %>' />
            </asp:HyperLink>
        </div>
    </fieldset>
</div>