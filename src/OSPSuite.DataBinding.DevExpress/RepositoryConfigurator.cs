using System;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;

namespace OSPSuite.DataBinding.DevExpress
{
   public interface IRepositoryConfigurator<TObjectType>
   {
      Func<TObjectType, RepositoryItem> RepositoryProvider { get; set; }
      Func<TObjectType, RepositoryItem> EditRepositoryProvider { get; set; }
      Action<BaseEdit, TObjectType> ActiveEditorConfiguration { get; set; }

      RepositoryItem RepositoryFor(TObjectType source);
      RepositoryItem EditRepositoryFor(TObjectType source);
      void ConfigureEditor(BaseEdit activeEditor, TObjectType source);
   }

   public class RepositoryConfigurator<TypeToBind> : IRepositoryConfigurator<TypeToBind>
   {
      public Func<TypeToBind, RepositoryItem> RepositoryProvider { get; set; }
      public Func<TypeToBind, RepositoryItem> EditRepositoryProvider { get; set; }
      public Action<BaseEdit, TypeToBind> ActiveEditorConfiguration { get; set; }

      public RepositoryConfigurator()
         : this(source => new RepositoryItemTextEdit(),  null,(editor, source) => {})
      {
      }

      public RepositoryConfigurator(Func<TypeToBind, RepositoryItem> repositoryProvider,
                                    Func<TypeToBind, RepositoryItem> editRepositoryProvider,
                                    Action<BaseEdit, TypeToBind> activeEditorConfiguration)
      {
         RepositoryProvider = repositoryProvider;
         EditRepositoryProvider = editRepositoryProvider;
         ActiveEditorConfiguration = activeEditorConfiguration;
      }

      public RepositoryItem RepositoryFor(TypeToBind source)
      {
         return RepositoryProvider(source);
      }

      public RepositoryItem EditRepositoryFor(TypeToBind source)
      {
         if (EditRepositoryProvider == null)
            return RepositoryFor(source);

         return EditRepositoryProvider(source);
      }

      public void ConfigureEditor(BaseEdit activeEditor, TypeToBind source)
      {
         ActiveEditorConfiguration(activeEditor, source);
      }
   }
}