using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Windows;

namespace LibraryManagement.Model
{
   public class EFProvider
   {
      public static EFProvider Instance
      {
         get
         {
            instance = instance ?? new EFProvider();
            return instance;
         }
         set => instance = value;
      }

      public LibraryManagementEntities DbEntities { get; set; }

      public void Reload()
      {
         DbEntities.Dispose();
         DbEntities = new LibraryManagementEntities();
      }

      public void SaveEntity(object entity, EntityState entityState, bool reloadDatabase = false)
      {
         if (entity == null) { return; }

         try
         {
            DbEntities.Entry(entity).State = entityState;
            Instance.DbEntities.SaveChanges();
         }
         catch (DbEntityValidationException e)
         {
            foreach (var entityValidationError in e.EntityValidationErrors)
            {
               MessageBox.Show("Entity of type \"" + entityValidationError.Entry.Entity.GetType().Name + "\" in state \"" + entityValidationError.Entry.State + "\" has the following validation errors:");
               foreach (var validationError in entityValidationError.ValidationErrors)
               {
                  MessageBox.Show("- Property: \"" + validationError.PropertyName + "\", Error: \"" + validationError.ErrorMessage + "\"");
               }
            }
            throw;
         }

         Instance.DbEntities.Entry(entity).State = EntityState.Detached;

         if (reloadDatabase) { Reload(); }
      }

      private EFProvider()
      {
         DbEntities = new LibraryManagementEntities();
      }

      private static EFProvider instance;
   }
}