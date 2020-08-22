namespace Privatezilla.Setting
{
    public abstract class SettingBase
    {
        /// <summary>
        /// Name of setting
        /// </summary>
        /// <returns>The setting name</returns>
        public abstract string ID();

        /// <summary>
        /// Tooltip text of setting
        /// </summary>
        /// <returns>The setting tooltip</returns>
        public abstract string Info();

        /// <summary>
        /// Checks whether the setting should be applied
        /// </summary>
        /// <returns>Returns true if the setting should be applied, false otherwise.</returns>
        public abstract bool CheckSetting();

        /// <summary>
        /// Applies the setting
        /// </summary>
        /// <returns>Returns true if the setting was successfull, false otherwise.</returns>
        public abstract bool DoSetting();

        /// <summary>
        /// Revert the setting
        /// </summary>
        /// <returns>Returns true if the setting was successfull, false otherwise.</returns>
        public abstract bool UndoSetting();
    }
}