using System;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using OSPSuite.Utility.Reflection;

namespace OSPSuite.DataBinding.DevExpress
{
    public static class RepositoryItemExtensions
    {
        /// <summary>
        /// Configures the given repository to behave as a numeric editor if 
        /// 1: The repository derives from RepositoryItemTextEdit
        /// 2: The privided type is numeric (integer or double type)
        /// </summary>
        public static RepositoryItem ConfigureWith(this RepositoryItem repositoryItem, Type propertyType) 
        {
            var repositoryWithMask = repositoryItem as RepositoryItemTextEdit;
            if (repositoryWithMask == null) return repositoryItem;

            if (TypeInspector.IsDoubleType(propertyType))
            {
               repositoryWithMask.Mask.MaskType = MaskType.RegEx;
               repositoryWithMask.Mask.EditMask = RegularExpression.Numeric;
            }
            else if (TypeInspector.IsUnsignedIntegerType(propertyType))
            {
                repositoryWithMask.Mask.MaskType = MaskType.RegEx;
                repositoryWithMask.Mask.EditMask = RegularExpression.UnsignedInteger;
            }
            else if (TypeInspector.IsSignedIntegerType(propertyType))
            {
               repositoryWithMask.Mask.MaskType = MaskType.RegEx;
               repositoryWithMask.Mask.EditMask = RegularExpression.Integer;
            }
            else
            {
              // nothing to do
            }

            return repositoryWithMask;
        }

       public static bool NeedsFormatedValue(this RepositoryItem repositoryItem)
       {
          return repositoryItem.GetType() == typeof (RepositoryItemTextEdit);
       }
    }
}