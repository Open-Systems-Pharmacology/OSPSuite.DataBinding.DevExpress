using System;
using OSPSuite.Utility;

namespace OSPSuite.DataBinding.DevExpress
{
    public interface ICellBinder<TObjectType, TPropertyType> : ILatchable
    {
        /// <summary>
        /// Sets value into the current bound cell
        /// </summary>
        /// <param name="value">value to be set</param>
        void SetValueToCell(TPropertyType value);

        /// <summary>
        /// Returns the source value for the bound property
        /// </summary>
        /// <returns>the source value for the bound property</returns>
        TPropertyType GetValueFromSource();


        /// <summary>
        /// Sets the value into the source for the bound property
        /// </summary>
        void SetValueToSource(TPropertyType value);

        /// <summary>
        /// Performs the actual data binding to the source
        /// </summary>
        /// <param name="source">source object to bind to</param>
        void Bind(TObjectType source);

        /// <summary>
        /// Source object the cell is bound to
        /// </summary>
        TObjectType Source { get; }

        /// <summary>
        /// Updates the control with the current source value
        /// </summary>
        void Update();

        /// <summary>
        /// Resets the property to its original value
        /// </summary>
        void Reset();


        /// <summary>
        /// Event will be raised before writting a value in the source so that a caller
        /// can take over the action source.Property = value (e.g. for undo/redo actions or protocols).
        /// The value will be set in the source from the control in any case to ensure a bi-directional binding 
        /// </summary>
        event Action<TObjectType, PropertyValueSetEventArgs<TPropertyType>> OnValueSet;

        /// <summary>
        /// Event is raised when the value was changed in the element
        /// </summary>
        event Action<TObjectType> OnChanged;

        void DeleteBinding();
    }



}