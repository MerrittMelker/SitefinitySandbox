<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MyContentsPage.ascx.cs" Inherits="MyCustomModule.Web.UI.MyContents.MyContentsPage" %>
<%@ Register TagPrefix="sitefinity" Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" %>
<%@ Register TagPrefix="telerik" Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" %>

<sitefinity:ResourceLinks ID="resourcesLinks" runat="server">
    <sitefinity:ResourceFile Name="Styles/Grid.css" />
    <sitefinity:ResourceFile Name="Styles/MenuMoreActions.css" />
    <sitefinity:ResourceFile Name="Styles/Window.css" />
    <sitefinity:ResourceFile Name="Styles/Layout.css" />
</sitefinity:ResourceLinks>
<sitefinity:ResourceLinks ID="resourcesLinks2" runat="server" UseEmbeddedThemes="true" Theme="Default">
    <sitefinity:ResourceFile Name="MyCustomModule.Web.Resources.CustomStylesWebFormsView.css" AssemblyInfo="MyCustomModule.MyCustomModuleClass, MyCustomModule" Static="True" />
</sitefinity:ResourceLinks>

<h1 class="sfBreadCrumb">
    <asp:Literal ID="MyCustomModule" runat="server" Text='MyCustomModule'></asp:Literal>
</h1>

<!-- no myContents created screen -->
<div runat="server" id="myContentsDecisionScreen" style="display:none;" class="sfEmptyList">
    <p class="sfMessage sfMsgNeutral sfMsgVisible"><asp:Literal ID="Literal1" runat="server" Text='<%$Resources:MyCustomModuleResources, NoMyContentsCreatedMessage %>'></asp:Literal></p>
    <ol class="sfWhatsNext">
        <li class="sfCreateItem">
            <a href='<%= GetDetailsPageUrl() %>'>
                <asp:Literal ID="Literal2" runat="server" Text='<%$Resources:MyCustomModuleResources, CreateAMyContent %>'></asp:Literal>
                <span class="sfDecisionIcon"></span>
            </a>
        </li>
    </ol>
</div>

<div class="sfMain sfClearfix" runat="server" id="myContentsMainPage">
    <div class="sfContent" >
        <!-- toolbar -->
        <div id="toolbar" class="sfAllToolsWrapper">
            <div class="sfAllTools">
                <ul class="sfActions">
                    <li class="sfMainAction">
                        <a href='<%= GetDetailsPageUrl() %>' class="sfLinkBtn sfSave">
                            <span class="sfLinkBtnIn">
                                <asp:Literal ID="createUserMyContentLiteral" runat="server" Text='<%$Resources:MyCustomModuleResources, CreateAMyContent %>' />
                            </span>
                        </a>
                    </li>
                    <li class="sfGroupBtn">
                        <a id="deleteItemsButton" class="sfLinkBtn sfDisabledLinkBtn">
                            <span class="sfLinkBtnIn">
                                <asp:Literal runat="server" Text='<%$Resources:MyCustomModuleResources, DeleteLabel %>' />
                            </span>
                        </a>
                        <telerik:RadWindow ID="deleteConfirmationWindow" runat="server" Width="450" Height="280" Modal="true" VisibleStatusbar="false" VisibleOnPageLoad="false" Behavior="Close" CssClass="sfInpageWnd sfAutoHeightInpageWnd">
                            <ContentTemplate>
                                <p>
                                    <span id="batchDeleteMyContentConfirmationSpan">
                                        <asp:Label runat="server" Text='<%$Resources:MyCustomModuleResources, DeleteMyContentConfirmationMessage %>' />
                                    </span>
                                </p>
                                <div class="sfButtonArea">
                                    <asp:LinkButton id="confirmDeleteButton" OnClick="OnConfirmDeleteButtonClicked" runat="server" CssClass="sfLinkBtn sfDelete">
                                        <span class="sfLinkBtnIn">
                                            <asp:Literal ID="batchDeleteMyContentButtonLiteral" runat="server" Text='<%$Resources:MyCustomModuleResources, YesDeleteTheseItemsButton %>' />
                                        </span>
                                    </asp:LinkButton>
                                    <a id="cancelDeleteButton" class="sfCancel">
                                        <asp:Literal runat="server" Text='<%$Resources:MyCustomModuleResources, CancelLabel %>' />
                                    </a>
                                </div>
                            </ContentTemplate>
                        </telerik:RadWindow>
                        <telerik:RadWindow ID="batchDeleteConfirmationWindow" runat="server" Width="450" Height="280" Modal="true" VisibleStatusbar="false" VisibleOnPageLoad="false" Behavior="Close" CssClass="sfInpageWnd sfAutoHeightInpageWnd">
                            <ContentTemplate>
                                <p>
                                    <span id="batchDeleteMyContentCountLabel"></span>
                                    <span>
                                        <asp:Literal runat="server" Text='<%$Resources:MyCustomModuleResources, BatchDeleteConfirmationMessage %>' />                                        
                                    </span>
                                </p>
                                <div class="sfButtonArea">
                                    <asp:LinkButton id="confirmBatchDeleteButton" OnClick="OnConfirmBatchDeleteButtonClicked" runat="server" CssClass="sfLinkBtn sfDelete">
                                        <span class="sfLinkBtnIn">
                                            <asp:Literal runat="server" Text='<%$Resources:MyCustomModuleResources, YesDeleteTheseItemsButton %>' />
                                        </span>
                                    </asp:LinkButton>
                                    <a id="cancelBatchDeleteButton" class="sfCancel">
                                        <asp:Literal runat="server" Text='<%$Resources:MyCustomModuleResources, CancelLabel %>' />
                                    </a>
                                </div>
                            </ContentTemplate>
                        </telerik:RadWindow>
                    </li>
                    <li class="sfQuickSort sfNoMasterViews">
                        <asp:Label ID="headerTextCombo" AssociatedControlID="sortDropDown" runat="server" Text='<%$Resources:MyCustomModuleResources, SortLabel %>' />
                        <telerik:RadWindow ID="customSortingWindow" runat="server" Width="450" Height="280" Modal="true" VisibleStatusbar="false" VisibleOnPageLoad="false" Behavior="Close" CssClass="sfSelectorDialog sfInpageWnd sfAutoHeightInpageWnd">
                            <ContentTemplate>
                                <div class="sfSortingCondition" id="sfSortingCondition">
                                    <h1><asp:literal ID="customSortingDialogHeader" runat="server" Text="<%$Resources:MyCustomModuleResources, CustomSortingDialogHeader%>" /></h1>
                                    <ul id="customSortingDialog_ctl00_ctl00_sortConditionContainer" class="sfSortRules">
                                        <li>
                                            <label class="sortByLabel sfTxtLbl" for='<%= customSortByDropdown.ClientID %>'>Sort by</label>
                                            <asp:DropDownList ID="customSortByDropdown" runat="server" CssClass="sortBySelect valid" />
                                            <div class="sfInlineBlock">
                                                <ol class="sfRadioList">
                                                    <li>
                                                        <input type="radio" id="ascRadioChoice" runat="server" value="ASC" checked="True"><label for="<%= ascRadioChoice.ClientID %>">Ascending</label>
                                                    </li>
                                                    <li>
                                                        <input type="radio" id="descRadioChoice" runat="server" value="DESC"><label for="<%= descRadioChoice.ClientID %>">Descending</label></li>
                                                </ol>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                                <div class="sfButtonArea sfSelectorBtns">
                                    <asp:LinkButton ID="applyCustomSortingButton" runat="server" OnClientClick="applyCustomSortingClicked();" CssClass="sfLinkBtn sfSave">
                                        <asp:Label runat="server" CssClass="sfLinkBtnIn" Text="<%$ Resources:Labels, Save %>" />
                                    </asp:LinkButton>
                                    <asp:Literal ID="orLiteral" runat="server" Text="<%$Resources:MyCustomModuleResources, OrLabel%>" />
                                    <a id="cancelCustomSortingButton" class="sfCancel">
                                        <asp:Literal ID="cancelCustomSortingLiteral" runat="server" Text="<%$Resources:MyCustomModuleResources, CancelLabel %>" />
                                    </a>
                                </div>
                            </ContentTemplate>
                        </telerik:RadWindow>
                        <asp:DropDownList ID="sortDropDown" runat="server">
                            <asp:ListItem Text="Last created on top" Value="DateCreated DESC"></asp:ListItem>
                            <asp:ListItem Text="Last modified on top" Value="LastModified DESC"></asp:ListItem>
                            <asp:ListItem Text="By Title (A-Z)" Value="Title ASC"></asp:ListItem>
                            <asp:ListItem Text="By Title (Z-A)" Value="Title DESC"></asp:ListItem>
                            <asp:ListItem Text="----------" disabled="disabled" Value="unselectable"></asp:ListItem>
                            <asp:ListItem Text="Custom Sorting" Value="custom"></asp:ListItem>
                            <asp:ListItem Text="Edit Custom Sorting" Value="editcustom"></asp:ListItem>
                        </asp:DropDownList>
                    </li>
                </ul>
            </div>
        </div>

        <!-- main area -->
        <div class="sfWorkArea" id="workArea">
            <div>
                <telerik:RadGrid ID="MyContentsMaster" runat="server" DataSourceID="myContentsDataSource" ClientSettings-Selecting-EnableDragToSelectRows="false"
                    AllowPaging="true" AllowCustomPaging="true" AutoGenerateColumns="false" AllowMultiRowSelection="true" OnDataBound="MyContentsGrid_DataBound" PageSize="50">
                    <MasterTableView EnableViewState="false" CssClass="rgTopOffset rgMasterTable">
                        <Columns>
                            <telerik:GridClientSelectColumn UniqueName="ClientSelectColumn" ItemStyle-CssClass="sfCheckBoxCol" HeaderStyle-CssClass="sfCheckBoxCol" />
                            <telerik:GridTemplateColumn HeaderText='<%$Resources:MyCustomModuleResources, MyContentTitleLabel %>' ItemStyle-CssClass="sfTitleCol">
                                <ItemTemplate>
                                    <a href='<%# GetDetailsPageUrl(Eval("Id").ToString()) %>' class="sfEditButton sfItemTitle sfactive">
                                        <strong><%# Eval("Title") %></strong>
                                    </a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText='<%$Resources:MyCustomModuleResources, MyContentMyNumberLabel %>' ItemStyle-CssClass="sfLarge">
                                <ItemTemplate>
                                    <div class="dmDescription"><%# ((int?)Eval("MyNumber")).HasValue ? ((int?)Eval("MyNumber")).Value.ToString() : string.Empty %></div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText='<%$Resources:MyCustomModuleResources, MyContentMyDateLabel %>' ItemStyle-CssClass="sfLarge">
                                <ItemTemplate>
                                    <div class="dmDescription"><%# ((DateTime?)Eval("MyDate")).HasValue ? ((DateTime?)Eval("MyDate")).Value.ToString("dd MMM, yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture) : string.Empty %></div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Actions" ItemStyle-CssClass="sfMoreActions sfLast">
                                <ItemTemplate>
                                    <div class="cmDiv">
                                    <ul class="sfActionsMenu clickMenu">
                                        <li class="main sfFirst sfLast">
                                            <a href="#" data-id='<%# Eval("Id") %>' onclick="showActionsMenu(this, event);" menu="actions0"><%# Eval("ActionsLabel") %></a>
                                        <li>
                                    </ul>
                                    </div>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                    <PagerStyle Mode="NumericPages" />
                    <ClientSettings EnableRowHoverStyle="true" EnableAlternatingItems="false">
                        <Selecting AllowRowSelect="True" />
                        <ClientEvents OnRowSelected="GridRowSelected" OnRowDeselected="GridRowDeselected" />
                    </ClientSettings>
                </telerik:RadGrid>
                <telerik:RadContextMenu ID="actionsMenu" OnClientItemClicking="OnActionsMenuClientItemClicking" ExpandAnimation-Type="None" CollapseAnimation-Type="None" runat="server" CssClass="sfMoreContextMenu">
                    <Items>
                        <telerik:RadMenuItem Text="Delete" Value="del" CssClass="sfDeleteItm" />
                    </Items>
                </telerik:RadContextMenu>
                <asp:HiddenField ID="selectedItemId" runat="server" />
                <asp:HiddenField ID="sortExpression" runat="server" Value="DateCreated DESC" />
                <asp:ObjectDataSource ID="myContentsDataSource" runat="server" DeleteMethod="Delete" EnablePaging="true" SelectCountMethod="GetTotalItemsCount"
                    SelectMethod="GetItems" TypeName="MyCustomModule.Web.Services.MyContents.MyContentsService">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="sortExpression" PropertyName="Value" Direction="Input" Name="sortExpression" Type="String" />
                    </SelectParameters>
                    <DeleteParameters>
                        <asp:Parameter Name="ids" Direction="Input" Type="String" />
                    </DeleteParameters>
                </asp:ObjectDataSource>
                <script type="text/javascript">
                    $(function () {
                        var sortControl = $('#<%= sortDropDown.ClientID %>');
                        sortControl.change(function () {
                            var value = sortControl.val();
                            switch (value) {
                                case "unselectable": {
                                    /* do nothing here */
                                } break;
                                case "custom":
                                case "editcustom": {
                                    var customSortingWindow = $find("<%= customSortingWindow.ClientID %>");
                                    customSortingWindow.show();
                                } break;
                                default: {
                                        $('#<%= sortExpression.ClientID %>').val(value);
                                    __doPostBack('<%= applyCustomSortingButton.UniqueID %>', '');
                                }
                            }
                        });

                        $("#cancelCustomSortingButton").on("click", function () {
                            var customSortingWindow = $find("<%= customSortingWindow.ClientID %>");
                            customSortingWindow.close();
                        });

                        $("#cancelBatchDeleteButton").on("click", function () {
                            var menu = $find("<%= batchDeleteConfirmationWindow.ClientID %>");
                            menu.close();
                        });

                        $("#cancelDeleteButton").on("click", function () {
                            var menu = $find("<%= deleteConfirmationWindow.ClientID %>");
                            menu.close();
                        });
                    });

                    function OnActionsMenuClientItemClicking(sender, args) {
                        args.set_cancel(true);
                        sender.hide();
                        var menu = $find("<%= deleteConfirmationWindow.ClientID %>");
                        menu.show();
                    };

                    function applyCustomSortingClicked() {
                        var sortDirection = $("#<%= ascRadioChoice.ClientID %>").is(':checked') ? "ASC" : "DESC";
                        var sortField = $("#<%= customSortByDropdown.ClientID %>").find(":selected").val();
                        $('#<%= sortExpression.ClientID %>').val(sortField + " " + sortDirection);
                    };

                    function showActionsMenu(element, event) {
                        var menu = $find("<%= actionsMenu.ClientID %>");
                        var obj = $(element);
                        /* remember which item is selected */
                        var itemId = obj.attr("data-id");
                        $('#<%= selectedItemId.ClientID %>').val(itemId);
                        /* calculate where to show the context menu */
                        var height = obj.height();
                        var position = obj.offset();
                        var bottomLeftX = position.left;
                        var bottomLeftY = position.top + height;
                        menu.showAt(bottomLeftX, bottomLeftY);
                        event.cancelBubble = true;
                        event.returnValue = false;
                        if (event.stopPropagation) {
                            event.stopPropagation();
                            event.preventDefault();
                        }
                    };

                    function GridRowSelected(sender, args) {
                        EnableDisableDeleteButton();
                    };

                    function GridRowDeselected(sender, args) {
                        EnableDisableDeleteButton();
                    };

                    function deleteItemsClicked() {
                        var numberSelectedItems = $find("<%= MyContentsMaster.MasterTableView.ClientID %>").get_selectedItems().length;
                        $("#batchDeleteMyContentCountLabel").text(numberSelectedItems + " ");
                        var menu = $find("<%= batchDeleteConfirmationWindow.ClientID %>");
                        menu.show();                        
                    };

                    function EnableDisableDeleteButton() {
                        var numberSelectedItems = $find("<%= MyContentsMaster.MasterTableView.ClientID %>").get_selectedItems().length;
                        var deleteItemsButton = $("#deleteItemsButton");
                        if (numberSelectedItems > 0) {
                            if (deleteItemsButton.is('.sfDisabledLinkBtn')) {
                                deleteItemsButton.removeClass('sfDisabledLinkBtn');
                                $("#deleteItemsButton").on("click", deleteItemsClicked);
                            }
                        } else {
                            if (deleteItemsButton.not('.sfDisabledLinkBtn')) {
                                deleteItemsButton.addClass('sfDisabledLinkBtn');
                                $("#deleteItemsButton").off("click", deleteItemsClicked);
                            }
                        }
                    };
                </script>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
    jQuery("body").addClass("sfNoSidebar");
</script>