//const Toast = Swal.mixin({
//    toast: true,
//    position: 'top-right',
//    iconColor: 'white',
//    customClass: {
//        popup: 'colored-toast'
//    },
//    showConfirmButton: false,
//    timer: 1500,
//    timerProgressBar: true
//})
var roles = searchRoles()
async function searchRoles() {
    //ajax to controller
    var ajaxUrl = window.location.origin.toString() + "/Roles/SearchRoles";
    try {
        var res = await fetch(ajaxUrl);
        var roles = await res.json();
        return roles;

    } catch (e) {
        console.log(e)
    }
}

var table = new Tabulator("#example-table", {
    height: "311px",
    data: tableDataNested,
    dataTree: true,
    dataTreeStartExpanded: true,
    columns: [
        { title: "id", field: "id" , sorter: "number" },
        { title: "Name", field: "name" }
    ]
});


var tableDataNested = [
    { id: 4, name: "India"}
];

