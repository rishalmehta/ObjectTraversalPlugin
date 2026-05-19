/*using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectTraversalPlugin
{

    [Plugin("ObjectCounterPlugin",
            "CCTECH",
            DisplayName = "Object Counter")]
    public class ObjectCounterPlugin : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            CountObjects();
            return 0;
        }

        public static void CountObjects()
        {
            Document doc = Autodesk.Navisworks.Api.Application.ActiveDocument;

            if (doc == null || doc.Models.Count == 0)
            {
                MessageBox.Show("No model loaded.");
                return;
            }

            int count = doc.Models
                           .SelectMany(m => m.RootItem.DescendantsAndSelf)
                           .Count();

            MessageBox.Show($"Total Objects : {count}");
        }
    }
}
*/

using Autodesk.Navisworks.Api;
using Autodesk.Navisworks.Api.Plugins;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ObjectTraversalPlugin
{
    [Plugin("ObjectCounterPlugin",
            "CCTECH",
            DisplayName = "Object Counter")]
    public class ObjectCounterPlugin : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            CountObjects();
            return 0;
        }

        public static void CountObjects()
        {
            try
            {
                Document doc = Autodesk.Navisworks.Api.Application.ActiveDocument;

                if (doc == null || doc.Models.Count == 0)
                {
                    MessageBox.Show("No model loaded.");
                    return;
                }

                // Get all items from all models
                var allItems = doc.Models
                                  .SelectMany(m => m.RootItem.DescendantsAndSelf)
                                  .ToList();

                // Total object count
                int totalObjects = allItems.Count;

                // Geometry objects
                int geometryCount = allItems.Count(i => i.HasGeometry);

                // Group items (items having children)
                int groupCount = allItems.Count(i => i.Children.Count() > 0);

                // Leaf items (final geometry nodes)
                int leafCount = allItems.Count(i => i.Children.Count() == 0);

                // Hidden items
                int hiddenCount = allItems.Count(i => i.IsHidden);

                // Build output
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("===== NAVISWORKS OBJECT REPORT =====");
                sb.AppendLine();

                sb.AppendLine($"Total Objects       : {totalObjects}");
                sb.AppendLine($"Geometry Objects    : {geometryCount}");
                sb.AppendLine($"Group Objects       : {groupCount}");
                sb.AppendLine($"Leaf Objects        : {leafCount}");
                sb.AppendLine($"Hidden Objects      : {hiddenCount}");

                sb.AppendLine();
                sb.AppendLine("Traversal Completed Successfully.");

                MessageBox.Show(sb.ToString(),
                                "Object Traversal Report",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error : {ex.Message}",
                    "Plugin Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}