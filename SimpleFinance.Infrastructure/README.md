# EF Creating migrations

Creating EF migration from specific DbContext to specific directory. U

```bash
dotnet ef migrations add Init_Read --context ReadDbContext --startup-project ../SimpleFinance.Api/ -o EF/Migrations
```