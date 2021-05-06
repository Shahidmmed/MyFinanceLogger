INSERT INTO "ExpenseCategories" ("ExpenseCategory") VALUES
('Bills'),
('Clothes'),
('Entertainment'),
('Food'),
('Fuel'),
('General'),
('Gifts'),
('Health'),
('Holidays'),
('Home'),
('Kids'),
('Other');

SELECT * FROM "Expense", "ExpenseCategories" WHERE "Expense"."ExpenseCategory" = "ExpenseCategories"."ExpenseCategory";

SELECT * from "GetExpenseCategories" ();