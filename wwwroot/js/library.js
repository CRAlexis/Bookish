function SearchByFunction(){
    const search = document.getElementById("searchByTitle").value.toLowerCase();
    console.log(search);
    
    const children = document.getElementById("all-books").children
    
    let test = children[0].children[1];
    console.log(test.innerHTML)
    
    for (i=0; i<children.length; i++){
        let title = children[i].children[1].innerHTML.toLowerCase();
        if (title.includes(search)){
            children[i].style.display='flex'
        } else {
            children[i].style.display='none'
        }
    }
}