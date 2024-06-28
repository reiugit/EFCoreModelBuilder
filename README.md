# EFCoreModelBuilder Example

## Configuring EntityFrameworkCore within 'AppDbContext.OnModelCreating'

* Class AProduct is configured mostly with 'data annotations'
* Class BProduct is configured only within the 'modelBuilder' in AppDbContext.OnModelCreating

### Prerequisite:
* This application needs a local SqlServer-Database.

1. Use  'DOCKER compose up --detach'  to create a local SqlServer instance.

2. Use 'EFCore Migrations' to create a valid database:  
-- with  'ef migrations database update'  in EFCore Tools  
-- or  'update-database'  in the Package Manager Console
