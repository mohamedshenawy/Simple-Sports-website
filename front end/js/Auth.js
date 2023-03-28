let userAuth = false;

window.onload = function () {
  var loginDiv = document.getElementById("login");
  var ContentDiv = document.getElementById("content");
  //check cookie
  if (userAuth) {
    loginDiv.style.display = "none";
    ContentDiv.style.display = "block";
  } else {
    loginDiv.style.display = "block";
    ContentDiv.style.display = "none";
  }
};
//
