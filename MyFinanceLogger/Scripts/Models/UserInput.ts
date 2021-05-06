import { MyFormat } from "../interfaces/MyFormat.js";

export class UserInput implements MyFormat {
    constructor(
        readonly category: string,
        private details: string,
        public amount: number,
        public date: string
    ) { }

    format() {
        return "On " + this.date + " GH₵ " + this.amount + " was spent on " + this.category + " Details: " + this.details;
    }
}