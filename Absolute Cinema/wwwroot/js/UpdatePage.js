const id = document.getElementById("Id");
const movieName = document.getElementById("Name");
const description = document.getElementById("Description");

function Update() {

    const request = new Request("/MoviesApi", {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify({
            Id: id.value,
            Name: movieName.value,
            Description: description.value
        })
    })
    fetch(request)
        .then(response => {
            if (!response.ok) throw new Error("Произошла ошибка на сервере");
            window.location.href = "/Movies/Main"
        })
        .catch(error => {
            console.error(error)
        })
}

function Delete() {

    const request = new Request("/MoviesApi", {
        method: "DELETE"
    })
    fetch(request)
        .then(response => {
            if (!response.ok) throw new Error("Произошла ошибка на сервере");
            window.location.href = "/Movies/Main"
        })
        .catch(error => {
            console.error(error)
        })
}