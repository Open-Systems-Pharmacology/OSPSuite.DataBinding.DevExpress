using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using OSPSuite.Utility.Extensions;

namespace OSPSuite.DataBinding.DevExpress.Extensions
{
   public static class GridViewExtensions
   {
      public static void FillComboBoxRepositoryWith<T>(this GridView gridView, IEnumerable<T> listToAddToComboBoxRepository)
      {
         var comboBoxEdit = gridView.ActiveEditor as ComboBoxEdit;
         if (comboBoxEdit == null) return;

         comboBoxEdit.Properties.Items.Clear();
         listToAddToComboBoxRepository.Each(item => comboBoxEdit.Properties.Items.Add(item));
      }
   }
}