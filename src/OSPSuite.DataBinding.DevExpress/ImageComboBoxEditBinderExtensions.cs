using System;

namespace OSPSuite.DataBinding.DevExpress
{
    public static class ImageComboBoxEditBinderExtensions
    {
        /// <summary>
        /// Defines the list of images to be displayed dynamically as a function of the object defined in the value list.
        /// </summary>
        /// <param name="imageComboBoxEditElementBinder">element binder</param>
        /// <param name="imageIndexFor">Delegate that takes one object from the value list and returns the index in the image list of the image for that object</param>
        /// <returns>the element binder</returns>
        public static ImageComboBoxEditElementBinder<TObjectType, TPropertyType>
           WithImages<TObjectType, TPropertyType>(this ImageComboBoxEditElementBinder<TObjectType, TPropertyType> imageComboBoxEditElementBinder, Func<TPropertyType, int> imageIndexFor)
        {
            imageComboBoxEditElementBinder.ImageIndexFor = imageIndexFor;
            return imageComboBoxEditElementBinder;
        }
    }
}