using DevExpress.XtraEditors.DXErrorProvider;
using OSPSuite.Utility.Reflection;
using OSPSuite.Utility.Validation;

namespace OSPSuite.DataBinding.DevExpress
{
   public class DxNotifier : Notifier, IValidatable, IDXDataErrorInfo
   {
      protected readonly IBusinessRuleSet _rules = new BusinessRuleSet();

      public virtual IBusinessRuleSet Rules => _rules;

      public virtual void GetPropertyError(string propertyName, ErrorInfo info)
      {
         var brokenRules = this.Validate(propertyName);
         if (brokenRules.IsEmpty) return;
         info.ErrorText = brokenRules.Message;
         info.ErrorType = ErrorType.Critical;
      }

      public virtual void GetError(ErrorInfo info)
      {
         var brokenRules = this.Validate();
         if (brokenRules.IsEmpty) return;
         info.ErrorText = brokenRules.Message;
         info.ErrorType = ErrorType.Critical;
      }
   }
}