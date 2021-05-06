drop function if exists "CreateExpense"( "reqExpenseDate" TIMESTAMP, "reqExpenseAmount" DOUBLE PRECISION,"reqExpenseCategory" CHARACTER VARYING, "reqExpenseDescription" CHARACTER VARYING);
create function "CreateExpense"("reqExpenseDate" TIMESTAMP,
                                "reqExpenseAmount" DOUBLE PRECISION,
                                "reqExpenseCategory" CHARACTER VARYING,
                                "reqExpenseDescription" CHARACTER VARYING)
    returns CHARACTER VARYING
    language plpgsql
as
$$
DECLARE
    _expenseCategory CHARACTER VARYING;
BEGIN
    -- Verify if the reqExpenseTypeId is valid
    SELECT exp."ExpenseCategory" INTO _expenseCategory FROM "ExpenseCategories" exp WHERE exp."ExpenseCategory" = "reqExpenseCategory" LIMIT 1;

    IF _expenseCategory IS NULL THEN
        RETURN 'Expense category is invalid' ::CHARACTER VARYING;
    END IF;

    INSERT INTO "Expense" ("ExpenseDate", "ExpenseAmount", "ExpenseCategory", "ExpenseDescription")

    VALUES ("reqExpenseDate", "reqExpenseAmount", "reqExpenseCategory", "reqExpenseDescription");

    RETURN '' :: CHARACTER VARYING;

END
$$;


drop function if exists "GetPeriodExpense"(TIMESTAMP, TIMESTAMP);
create function "GetPeriodExpense"("StartDate" DATE,
                                    "EndDate" DATE)
    returns DOUBLE PRECISION
    language plpgsql
as
$$
BEGIN
    SELECT sum("ExpenseAmount")
    FROM "Expense"
    WHERE "StartDate" = "ExpenseDate"
      AND "EndDate" = "ExpenseDate";

END
$$;

drop function if exists "GetExpenseCategories"();
create function "GetExpenseCategories"()
    returns setof "ExpenseCategories"
    language plpgsql
as
$$
BEGIN
     RETURN QUERY SELECT "ExpenseCategoryId", "ExpenseCategory" FROM "ExpenseCategories";

END
$$;