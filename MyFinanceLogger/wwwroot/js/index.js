import { ListTemplate } from './Models/ListTemplate.js';
import { UserInput } from './Models/UserInput.js';
document.addEventListener('DOMContentLoaded', function () {
    alert(123245676);
    const form = document.getElementById('inputform');
    const date = document.getElementById('date');
    const category = document.getElementById('category');
    const details = document.getElementById('details');
    const amount = document.getElementById('amount');
    const ul = document.getElementById('item-list');
    const list = new ListTemplate(ul);
    console.log(form);
    if (form) {
        form.addEventListener('submit', (e) => {
            let doc;
            doc = new UserInput(category.value, details.value, amount.valueAsNumber, date.value);
            list.render(doc, category.value, 'end');
            e.preventDefault();
            return false;
        });
    }
});
//# sourceMappingURL=index.js.map