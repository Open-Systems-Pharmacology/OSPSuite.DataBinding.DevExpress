using System;
using DevExpress.Data;
using OSPSuite.BDDHelper;
using OSPSuite.BDDHelper.Extensions;
using OSPSuite.DataBinding.DevExpress.Mappers;

namespace OSPSuite.DataBinding.DevExpress.Tests
{
    public abstract class concern_for_TypeToColumnTypeMapper : ContextSpecification<ITypeToColumnTypeMapper>
    {
        protected override void Context()
        {
            sut = new TypeToColumnTypeMapper();
        }
    }

    public class When_mapping_a : concern_for_TypeToColumnTypeMapper
    {
        [Observation]
        public void boolean_should_return_a_boolean_type()
        {
            sut.MapFrom(typeof (bool)).ShouldBeEqualTo(UnboundColumnType.Boolean);
        }

        [Observation]
        public void double_should_return_an_object_type()
        {
            sut.MapFrom(typeof (double)).ShouldBeEqualTo(UnboundColumnType.Object);
        }

        [Observation]
        public void integer_should_return_an_integer_type()
        {
            sut.MapFrom(typeof (int)).ShouldBeEqualTo(UnboundColumnType.Integer);
        }

        [Observation]
        public void string_should_return_a_string_type()
        {
            sut.MapFrom(typeof (string)).ShouldBeEqualTo(UnboundColumnType.String);
        }

        [Observation]
        public void datetime_should_return_a_datetime_type()
        {
            sut.MapFrom(typeof (DateTime)).ShouldBeEqualTo(UnboundColumnType.DateTime);
        }

        [Observation]
        public void an_object_type_should_return_an_object_type()
        {
            sut.MapFrom(typeof (AnImplementation)).ShouldBeEqualTo(UnboundColumnType.Object);
        }
    }
}