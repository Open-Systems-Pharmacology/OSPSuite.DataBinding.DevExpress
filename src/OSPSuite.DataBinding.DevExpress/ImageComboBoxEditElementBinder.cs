using System;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using OSPSuite.DataBinding.Core;

namespace OSPSuite.DataBinding.DevExpress
{
    public class ImageComboBoxEditElementBinder<TObjectType, TPropertyType> : ComboBoxEditElementBinder<TObjectType, TPropertyType>
    {
        private readonly ImageComboBoxEdit _imageComboBox;
        public Func<TPropertyType, int> ImageIndexFor { get; set; }

        public ImageComboBoxEditElementBinder(IPropertyBinderNotifier<TObjectType, TPropertyType> propertyBinder, ImageComboBoxEdit imageComboBox): base(propertyBinder,imageComboBox)
        {
            _imageComboBox = imageComboBox;
        }

        public override void SetValueToControl(TPropertyType value)
        {
            _imageComboBox.SelectedItem = itemComboBoxFrom(value);
        }

        private ImageComboBoxItem itemComboBoxFrom(TPropertyType value)
        {
            var allItems = _imageComboBox.Properties.Items;
            return allItems.GetItem(value);
        }

        protected override void AddItem(TPropertyType value, string displayValue)
        {
            var imageComboBoxItem = new ImageComboBoxItem(displayValue, value);
            if (imagesAreDefined())
                imageComboBoxItem.ImageIndex = ImageIndexFor(value);

            _imageComboBox.Properties.Items.Add(imageComboBoxItem);
        }

        private bool imagesAreDefined()
        {
           return ImageIndexFor != null;
        }
    }
}