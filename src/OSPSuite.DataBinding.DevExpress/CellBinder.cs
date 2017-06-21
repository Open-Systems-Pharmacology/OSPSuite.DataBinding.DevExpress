using System;
using System.Reflection;
using OSPSuite.Utility.Extensions;
using OSPSuite.DataBinding.Core;

namespace OSPSuite.DataBinding.DevExpress
{
   public abstract class CellBinder<TObjectType, TPropertyType> : ICellBinder<TObjectType, TPropertyType>
   {
      protected IBinder _parentBinder;
      protected readonly IPropertyBinderNotifier<TObjectType, TPropertyType> _propertyBinder;
      public event Action<TObjectType, PropertyValueSetEventArgs<TPropertyType>> OnValueUpdating = delegate { };
      public event Action<TObjectType, TPropertyType> OnValueUpdated = delegate { };
      public event Action<TObjectType> OnChanged = delegate { };
      public TObjectType Source { get; private set; }
      private TPropertyType _originalValue;
      public bool IsLatched { get; set; }

      protected CellBinder(PropertyInfo propertyInfo, IBinder parentBinder)
      {
         _propertyBinder = new PropertyBinderNotifier<TObjectType, TPropertyType>(propertyInfo);
         _parentBinder = parentBinder;
      }

      public abstract void SetValueToCell(TPropertyType value);

      public TPropertyType GetValueFromSource()
      {
         return _propertyBinder.GetValue(Source);
      }

      public void SetValueToSource(TPropertyType value)
      {
         this.DoWithinLatch
         (() =>
            {
               //before setting the value to the source, raise the on OnValueSet event
               //to allow caller to take over the actual action of setting the value
               var oldValue = GetValueFromSource();
               OnValueUpdating(Source, new PropertyValueSetEventArgs<TPropertyType>(_propertyBinder.PropertyName, oldValue, value));

               if (bindingModeIsTwoWay)
               {
                  //set control value into source
                  _propertyBinder.SetValue(Source, value);
                  OnValueUpdated(Source, value);
               }

               notifyChange();
            }
         );
      }

      private bool bindingModeIsTwoWay => _parentBinder != null && _parentBinder.BindingMode == BindingMode.TwoWay;

      public void Bind(TObjectType source)
      {
         Source = source;

         //save original value
         _originalValue = GetValueFromSource();

         //the function update to any change of the source
         _propertyBinder.AddValueChangedListener(source, Update);
      }

      public void Update()
      {
         ////Update control run within latch so that the function 
         ////is only called when indeed triggered from the element itself
         this.DoWithinLatch(() => updateControl(GetValueFromSource()));
      }

      public void Reset()
      {
         this.DoWithinLatch
         (
            () =>
            {
               //First set value into source before updating value in control so that 
               //a get value from source returns the accurate value
               _propertyBinder.SetValue(Source, _originalValue);

               updateControl(_originalValue);
            }
         );
      }

      private void updateControl(TPropertyType valueToSetInControl)
      {
         //First set value into control
         SetValueToCell(valueToSetInControl);

         notifyChange();
      }

      private void notifyChange()
      {
         OnChanged(Source);
      }

      public void DeleteBinding()
      {
         OnValueUpdating = delegate { };
         OnValueUpdated = delegate { };
         OnChanged = delegate { };
         _propertyBinder.RemoveValueChangedListener(Source);
      }
   }
}