# Carly_AspProject ( A Complete Real world ASP MVC WebApp)

### Work with EntityFramework code first:
```
> enable-migrations
```

add DbSet in IdentityModels.cs:
public DbSet<BankAccount> BankAccounts { get; set; }

```
> add-migration  [migration-name] #eg: addBankAccounts
```

```
> update-database
```

in Controller file:
private ApplicationDbContext _context = new ApplicationDbContext();

eg: adding record to table
BankAccount bankAccount = new BankAccount();
...
_context.BankAccounts.Add(bankAccount);
_context.SaveChanges();
