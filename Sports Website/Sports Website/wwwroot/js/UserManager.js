//sing up
//async function UpdateUser() {
//    var obj = collectAndValidateData();
//    if (obj.isvalid == false) {
//        alert("sign up not valid");
//        return;
//    }
//    //ajax to controller
//    var ajaxUrl = window.location.origin.toString() + "/UserManager/UpdateUser";
    
//    var ajaxoptions = {};
//    ajaxoptions.url = ajaxUrl;
//    ajaxoptions.data = obj;
//    ajaxoptions.type = 'POST';
//    ajaxoptions.success = function (result) {
//        window.location.href = window.location.origin + result;
//    }
//    ajaxoptions.error = function (data) {
//        var errors = JSON.parse(data.response);
//        var toster = `<div class="toast align-items-center text-bg-primary border-0 show" role="alert" aria-live="assertive" aria-atomic="true">
//  <div class="d-flex">
//    <div class="toast-body">
//      ${errors.join('\n')}
//    </div>
//    <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
//  </div>
//</div>`
//        document.getElementById("error-sammry").innerHTML = toster;
//    };
//    $.ajax(ajaxoptions);
    
//}
//ajax by fetch 
async function UpdateUser() {
    let obj = collectAndValidateData();
    if (obj.isvalid == false) {
        alert("sign up not valid");
        return;
    }
    //ajax to controller
    try {
    let ajaxUrl = window.location.origin.toString() + "/UserManager/UpdateUser";
        let headers = {
            "Content-Type": "application/json",
            "Access-Control-Origin": "*"
        } 
        let result = await fetch(ajaxUrl, {
            method: "POST",
            headers: headers,
            body: JSON.stringify(obj)
        });
        console.log(result)
    } catch (error) {
        console.log(error);
    }
}
// collect data
function collectAndValidateData() {
    var obj = {
        "Id":"",
        "Name": "",
        "Email": "",
        "isvalid" :true
    };
    var Id = document.querySelector('input[id="Id"]');
    var Name = document.querySelector('input[id="Name"]');
    var Email = document.querySelector("input[id='Email']");
    if (Id.value == "" || Id.value == undefined) {
        Id.style.border = "1px solid red";
        obj["isvalid"] = false;
        return obj;
    }
    if (Name.value == "" || Name.value == undefined) {
        Name.style.border = "1px solid red";
        obj["isvalid"] = false;
        return obj;
    }
    if (Email.value == "" || Email.value == undefined) {
        Email.style.border = "1px solid red";
        obj["isvalid"] = false;
        return obj;
    }
    obj["Name"] = Name.value;
    obj["Email"] = Email.value;
    obj["Id"] = Id.value;
    return obj;
}
