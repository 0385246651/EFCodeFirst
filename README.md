ASP .NET MVC 5 . 4.7 . EF CodeFirst

- update Product Model (Quantity)

enable-migrations

// Add Quantity col
add-migration <migration_name>

//Update db
update-database

update with default value
//update-database -verbose

//packages jquery and validate

 <script src="~/Scripts/jquery-3.6.0.js"></script>
 <script src="~/Scripts/jquery.validate.js"></script>
 <script src="~/Scripts/jquery.validate.unobtrusive.js"></script>
 <style>

//packages Identity
install-package Microsoft.AspNet.Identity.EntityFramework
install-package Microsoft.AspNet.Identity.Owin
install-package Microsoft.Owin.Host.SystemWeb

// migration Identity context
enable-migrations -ContextTypeName EFCodeFirst.Identity.AppDBContext -MigrationsDirectory IdentityMigration

// add migration for configuration
add-migration -Configuration EFCodeFirst.IdentityMigration.Configuration <Configuration_migration_name>

//update DB for configuration
update-database -Configuration EFCodeFirst.IdentityMigration.Configuration
