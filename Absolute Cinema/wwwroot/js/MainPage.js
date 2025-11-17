
function Delete(button) {
    const row = button.closest("tr");
    const idCell = row.querySelector(".Id");
    const id = idCell.textContent

    const request = new Request(`/MoviesApi/${id}`, {
        method: "Delete"
    })
    console.log(id)
    fetch(request)
        .then(response => {
            if (!response.ok) throw new Error("Ошибка на сервере")
            row.remove()
        })
        .catch(error => {
            console.error(error)
        })
}

function RedirectToUpdate() {
    
}