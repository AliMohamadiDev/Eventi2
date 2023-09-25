$('.persianDateInput').persianDatepicker({
    format: 'YYYY/MM/DD HH:mm',
    autoClose: true,
    initialValueType: "persian",
    timePicker: {
        enabled: true,
        meridiem: {
            enabled: true
        }
    }
});