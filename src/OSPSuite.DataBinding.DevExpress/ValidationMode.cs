namespace OSPSuite.DataBinding.DevExpress
{
    public enum ValidationMode
    {
        /// <summary>
        /// Notification message will be displayed as soon as the bound cell losts the focus. 
        /// If an error exists the cell keep the focus
        /// </summary>
        LeavingCell,

        /// <summary>
        /// Notification message will be displayed when changing the active row
        /// If an error exists in the active cell, the value will be saved into the underlying object which will result
        /// to a temporary invalid state of the object
        /// </summary>
        LeavingRow
    }
}