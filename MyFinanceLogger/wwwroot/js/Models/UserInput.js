export class UserInput {
    constructor(category, details, amount, date) {
        this.category = category;
        this.details = details;
        this.amount = amount;
        this.date = date;
    }
    format() {
        return "On " + this.date + " GH₵ " + this.amount + " was spent on " + this.category + " Details: " + this.details;
    }
}
//# sourceMappingURL=UserInput.js.map