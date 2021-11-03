function ShowCheckedOutModal(inventory){
    document.getElementById("CheckedOutModal").style.display = "block";
    document.getElementById("CheckOutModalImage").src = inventory.image;
}

function HideCheckedOutModal(){
    document.getElementById("CheckedOutModal").style.display = "none";
    document.getElementById("CheckOutModalImage").src = "";
}