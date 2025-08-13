# EF Core Query Practice
This app uses an Accounts Payable database to practice EF Core queries. Code
first migrations are used to create the database and seed it with data.

## Prerequisites
- Visual Studio 2022 with .NET 9

## Getting Started
- Click the "Use this template" button to create a new repository in your own account
- Clone your copy of the repository to your local machine
- Open the solution in Visual Studio
- Run code first migrations with 'Update-Database' in the Package Manager Console
- Open up the `Data.sql` file and connect to `(localdb)\MSSQLLocalDB`, execute
  the script to create the database and seed it with data
- Verify the database is created by checking the `AccountsPayableData` database
  in SQL Server Object Explorer. Right-click the Invoices table and choose `View Data` to
  ensure data is present.

## Query Practice
Using the newly created AccountsPayableData database, practice writing EF Core
queries in the `Program.cs` file. The database is seeded with data, so you can
experiment with different queries to retrieve and manipulate data.

## Queries to Try
- [ ] Retrieve all invoices (All columns)
- [ ] Retrieve all invoices with a balance due greater than 0 (balance is calculated as InvoiceTotal - PaymentTotal - CreditTotal)
- [ ] Retrieve a list of Vendor names sorted in reverse alphabetical order
- [ ] Retrieve a list of Vendor names and their associated InvoiceNumbers and InvoiceTotals (only those 3 columns)
- [ ] Retrieve all invoices for a specific Vendor
- [ ] Retrieve the total amount invoiced for each Vendor
- [ ] Retrieve the number of invoices per Vendor
- [ ] Retrieve all invoices issued in a specific month/year
- [ ] Retrieve all Vendors that do not have invoices
- [ ] Retrieve the average invoice total for each Vendor
- [ ] Retrieve the largest invoice and the Vendor associated with it
- [ ] Retrieve all invoices with more than one line item
- [ ] Retrieve all Vendors in a specific state (California has many)
- [ ] Retrieve all invoices where PaymentDate is null (unpaid invoices)
- [ ] Retrieve all line items for a specific invoice
- [ ] Retrieve the sum of InvoiceTotal for all with a balance due greater than 0