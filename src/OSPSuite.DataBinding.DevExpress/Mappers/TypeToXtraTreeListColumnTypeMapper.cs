using System;
using DevExpress.XtraTreeList.Data;
using OSPSuite.Utility;

namespace OSPSuite.DataBinding.DevExpress.Mappers
{
   public interface ITypeToXtraTreeListColumnTypeMapper : IMapper<Type, UnboundColumnType>
   {
   }

   public class TypeToXtraTreeListColumnTypeMapper : ITypeToXtraTreeListColumnTypeMapper
   {
      public UnboundColumnType MapFrom(Type input)
      {
         if (input == typeof(bool))
            return UnboundColumnType.Boolean;

         if (input == typeof(int))
            return UnboundColumnType.Integer;

         if (input == typeof(string))
            return UnboundColumnType.String;

         if (input == typeof(DateTime))
            return UnboundColumnType.DateTime;

         return UnboundColumnType.Object;
      }
   }
}