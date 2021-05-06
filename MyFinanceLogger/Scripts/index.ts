import { MyFormat } from './Interfaces/MyFormat.js';
import { ListTemplate } from './Models/ListTemplate.js';
import { UserInput } from './Models/UserInput.js'


document.addEventListener('DOMContentLoaded', function () {

    alert(123245676)
    const form = document.getElementById('inputform') as HTMLFormElement;
    const date = document.getElementById('date') as HTMLInputElement;
    const category = document.getElementById('category') as HTMLInputElement;
    const details = document.getElementById('details') as HTMLInputElement;
    const amount = document.getElementById('amount') as HTMLInputElement;

    const ul = document.getElementById('item-list') as HTMLUListElement;
    const list = new ListTemplate(ul);
    console.log(form);

    if (form) {
        form.addEventListener('submit', (e: Event) => {
            let doc: MyFormat;
            doc = new UserInput(category.value, details.value, amount.valueAsNumber, date.value);
            list.render(doc, category.value, 'end');

            e.preventDefault();
            return false;
        });
    }

})

