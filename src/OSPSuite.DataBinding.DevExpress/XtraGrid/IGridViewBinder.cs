using DevExpress.XtraGrid.Views.Grid;

namespace OSPSuite.DataBinding.DevExpress.XtraGrid
{
   public interface IGridViewBinder : IBinder
   {
      /// <summary>
      ///    The actual grid view the control is binding to.
      /// </summary>
      GridView GridView { get; }

      /// <summary>
      ///    The ValidationMode value determines how the binder will react to error notification
      ///    Default value is
      ///    <value>ValidationMode.LeavingCell</value>
      /// </summary>
      ValidationMode ValidationMode { get; set; }

      /// <summary>
      ///    Reset grid view with all orignal values of the source list when BindToSource was called
      /// </summary>
      void Reset();

      /// <summary>
      ///    Refresh the binder to reflect the changes made to the date source.
      ///    Each cell will be updated according to the actual content of the data source.
      ///    However, changes in the data source length (add or remove from items) will not be taken into accounts.
      ///    Please use the Rebind method instead.
      /// </summary>
      void Update();

      /// <summary>
      ///    Rebind to the provided data source to reflect the changes made.
      ///    This function should be called for example when the length of the data source changed.
      /// </summary>
      void Rebind();
   }
}