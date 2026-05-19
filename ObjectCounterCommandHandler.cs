using Autodesk.Navisworks.Api.Plugins;

namespace ObjectTraversalPlugin
{
   [Plugin("ObjectCounterRibbon",
            "CCTECH",
            DisplayName = "Object Counter Ribbon")]

    [RibbonLayout("Ribbon.xaml")]

    [RibbonTab("ID_CCTECH_TAB",
        DisplayName = "CCTECH Tools")]

    [Command("ID_CountObjects",
        DisplayName = "Count Objects",
        ToolTip = "Count all objects in model",
        Icon = "Icons/object16.png",
        LargeIcon = "Icons/object32.png")]
    public class ObjectCounterCommandHandler : CommandHandlerPlugin
    {
        public override int ExecuteCommand(string commandId, params string[] parameters)
        {
            switch (commandId)
            {
                case "ID_CountObjects":
                    ObjectCounterPlugin.CountObjects();
                    break;
            }

            return 0;
        }
    }
}
