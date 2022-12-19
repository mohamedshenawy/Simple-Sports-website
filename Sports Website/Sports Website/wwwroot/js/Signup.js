//sing up
async function signUp() {
    var obj = collectAndValidateData();
    if (obj.isvalid == false) {
        alert("sign up not valid");
        return;
    }
    //ajax to controller
    var ajaxUrl = window.location.origin.toString() + "/Account/SinUpPost";
    
    var ajaxoptions = {};
    ajaxoptions.url = ajaxUrl;
    ajaxoptions.data = obj;
    ajaxoptions.type = 'POST';
    ajaxoptions.success = function (result) {
        window.location.href = window.location.origin + result;
    }
    ajaxoptions.error = function (data) {
        var errors = JSON.parse(data.response);
        var toster = `<div class="toast align-items-center text-bg-primary border-0 show" role="alert" aria-live="assertive" aria-atomic="true">
  <div class="d-flex">
    <div class="toast-body">
      ${errors.join('\n')}
    </div>
    <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
  </div>
</div>`
        document.getElementById("error-sammry").innerHTML = toster;
    };
    $.ajax(ajaxoptions);
    
}
// collect data
function collectAndValidateData() {
    var obj = {
        "Name": "",
        "Email": "",
        "Password": "",
        "isvalid" :true
    };

    var Name = document.querySelector('input[id="Name"]');
    var Email = document.querySelector("input[id='Email']");
    var Pass = document.querySelector("input[id='Password']");
    var ConfirmPass = document.querySelector("input[id='Confirm-Password']");
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

    if (Pass.value == "" || Pass.value == undefined) {
        Pass.style.border = "1px solid red";
        obj["isvalid"] = false;
        return obj;
    } else if (Pass.value.length < 8) {
        Pass.style.border = "1px solid red";
        document.getElementById("PasswordValidation").innerHTML = "Min value is 8";
        obj["isvalid"] = false;
        return obj;
    }

    if (ConfirmPass.value == "" || ConfirmPass.value == undefined) {
        ConfirmPass.style.border = "1px solid red";
        obj['isvalid'] = false;
        return obj;
    }
    if (ConfirmPass.value != Pass.value) {
        ConfirmPass.style.border = "1px solid red";
        document.getElementById("Confirm-PasswordValidation").innerText = "confirm password must be same as password";
        obj['isvalid'] = false;
        return obj;
    }

    obj["Name"] = Name.value;
    obj["Email"] = Email.value;
    obj["Password"] = Pass.value;
    return obj;
}
