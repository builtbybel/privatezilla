using Privatezilla.Setting;
using System.Windows.Forms;

namespace Privatezilla
{
    internal class SettingNode : TreeNode
    {
        public SettingBase Setting { get; }

        public SettingNode(SettingBase setting)
        {
            Setting = setting;
            Text = Setting.ID();
            ToolTipText = Setting.Info();
            //Checked = true;
        }

    }
}