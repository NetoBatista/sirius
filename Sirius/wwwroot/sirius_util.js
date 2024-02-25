window.sirius = {
    culture: 'en-US',
    currencyMask: (event) => {
        const element = event.target || event;
        element.type = 'text';
        let value = element.value.replace('.', '').replace(',', '').replace(/\D/g, '').slice(0, 8);
        if (!value) {
            if (!element.required) {
                element.value = '';
                return
            }
            value = '0';
        }
        const options = { minimumFractionDigits: 2 };
        const result = new Intl.NumberFormat(window.sirius.culture, options).format(parseFloat(value) / 100);
        element.value = result;
    },
    applyCurrencyMask: () => {
        const elements = document.getElementsByClassName('currency-mask');
        for (var element of elements) {
            element.oninput = window.sirius.currencyMask;
            window.sirius.currencyMask(element);
        }
    }
}