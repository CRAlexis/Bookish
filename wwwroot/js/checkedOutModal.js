function ShowCheckedOutModal(inventory) {
    document.getElementById("CheckedOutModal").style.display = "block";
    document.getElementById("CheckOutModalImage").innerHTML = inventory.image;

    document.getElementById("CheckedOutModalTitle").innerHTML = "Title: " + inventory.title;
    document.getElementById("CheckedOutModalAuthor").innerHTML = "Author: " + inventory.author;
    document.getElementById("CheckedOutModalGenre").innerHTML = "Genre: " + inventory.genre;
    document.getElementById("CheckedOutModalYear").innerHTML = "Published: " + inventory.year_published;
    CreateTable(inventory.copy_id
    );
    CheckOutSection(inventory);
}

function CreateTable(id) {
    var xhttp = new XMLHttpRequest();
    var response = "";
    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            response = JSON.parse(this.responseText);
            var table = document.getElementById('ModalBookHistoryTable');
            response.forEach((res) => {
                var jsonRes = JSON.parse(res)
                const returned = (jsonRes.returned === null) ? '' : jsonRes.returned.slice(0, -9);
                table.insertAdjacentHTML('beforeend', '' +
                    '<td><a href="#">' + jsonRes.name + '</a></td>\n' +
                    '<td>' + jsonRes.email + '</td>\n' +
                    '<td>' + jsonRes.checked_out.slice(0, -9) + '</td>\n' +
                    '<td>' + returned + '</td>\n' +
                    '<td>' + jsonRes.due_date.slice(0, -9) + '</td>\n' +
                    '</tr>');
            })

        }
    };
    xhttp.open("GET", "https://localhost:5001/borrowed-json/" + id.toString(), true);
    xhttp.send();
}

function CheckOutSection(inventory) {
    FetchUsers(inventory)
    const xhttp = new XMLHttpRequest();
    document.getElementById("ModalCheckOutCopyId").value = inventory.copy_id;
    document.getElementById("ModalCheckOutCheckingOut").value = !inventory.currently_out;
    document.getElementById("ModalCheckOutButton").value = inventory.currently_out ? "Check in" : "Check out";
    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            response = JSON.parse(this.responseText);
            document.getElementById("ModalCheckOutText").innerHTML = inventory.currently_out ? "This book is currently checked out with " + response.name : "Check out this book for a member";
        }else{
            document.getElementById("ModalCheckOutText").innerHTML = "Check out this book for a member";
        }
    };
    xhttp.open("GET", "https://localhost:5001/member-json?memId=" + inventory.members_id, true);
    xhttp.send();

}

function FetchUsers(inventory) {
    var xhttp = new XMLHttpRequest();
    var response = "";
    xhttp.onreadystatechange = function () {
        if (this.readyState === 4 && this.status === 200) {
            response = JSON.parse(this.responseText);
            var element = document.getElementById('ModalCheckOutUsers');
            response.forEach((res) => {
                var jsonRes = JSON.parse(res)
                element.insertAdjacentHTML('beforeend', '' +
                    '<option value=' + jsonRes.id + '>' + jsonRes.name + '</option>');
            })
            if (inventory.members_id){
                document.getElementById("ModalCheckOutUsers").hidden = inventory.currently_out;
                document.getElementById("ModalCheckOutUsersText").style.visibility = inventory.currently_out ? 'collapse' : 'visible';
                document.getElementById("ModalCheckOutUsers").value = inventory.members_id;
            }

        }
    };
    xhttp.open("GET", "https://localhost:5001/members-json", true);
    xhttp.send();
}

function HideCheckedOutModal() {
    var table = document.getElementById('ModalBookHistoryTable');
    
    while (table.firstChild) {
        table.removeChild(table.lastChild);
    }
    document.getElementById("CheckedOutModal").style.display = "none";
    document.getElementById("CheckOutModalImage").src = "";
    document.getElementById("ModalCheckOutUsers").hidden = false
    document.getElementById("ModalCheckOutUsersText").style.visibility = 'visible';
    document.getElementById("ModalCheckOutUsers").value = 0;
}

function OpenModalTab(tabName) {
    var i;
    var x = document.getElementsByClassName("ModalTabs");
    for (i = 0; i < 3; i++) {
        x[i].classList.remove("showTab")
        x[i].classList.add("hideTab")
    }
    document.getElementById(tabName).classList.add("showTab")
    document.getElementById(tabName).classList.remove("hideTab")
}