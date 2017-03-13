using System;
using DevExpress.Utils;
using OSPSuite.Utility;
using OSPSuite.Utility.Extensions;

namespace OSPSuite.DataBinding.DevExpress.Mappers
{
   public interface ITypeToHorzAlignmentMapper : IMapper<Type, HorzAlignment>
   {
   }

   public class TypeToHorzAlignmentMapper : ITypeToHorzAlignmentMapper
   {
      public HorzAlignment MapFrom(Type type)
      {
         return type.IsNumeric() ? HorzAlignment.Far : HorzAlignment.Default;
      }
   }
}