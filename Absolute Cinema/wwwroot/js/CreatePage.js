const { error } = require("jquery");


function SendData(event) {
    event.preventDefault();

    const form = event.target;
    const dataForm = new FormData(form);

    fetch("/MoviesApi", {
        method: "POST",
        body:  dataForm
    })
        .then(response => {
            if (!response.ok) throw new Error("Что-то не так произошло при создании")
            return response.json();
        })
        .then(data => {
            console.log(data);
            window.location.href = "/Movies/Main"

        })
        .catch(error => {
            console.error(error);
        })
}