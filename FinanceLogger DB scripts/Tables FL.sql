drop table if exists "Expense";
CREATE TABLE "Expense"
(
    "ExpenseId"          SERIAL                      NOT NULL PRIMARY KEY,
    "ExpenseDate"        TIMESTAMP WITHOUT TIME ZONE NOT NULL,
    "ExpenseAmount"      DOUBLE PRECISION            NOT NULL,
    "ExpenseCategory" CHARACTER VARYING NOT NULL,
    "ExpenseDescription" CHARACTER VARYING           NOT NULL,
    "RecordDate"         TIMESTAMP WITHOUT TIME ZONE DEFAULT now()
);

drop table if exists "ExpenseCategories";
CREATE TABLE "ExpenseCategories"
(
    "ExpenseCategoryId"   SERIAL            NOT NULL PRIMARY KEY,
    "ExpenseCategory" CHARACTER VARYING NOT NULL
);
