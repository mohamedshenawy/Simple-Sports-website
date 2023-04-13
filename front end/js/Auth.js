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
// ajax to get token
async function login() {
  try {
    var res = await fetch("https://localhost:5001/api/Account", {
      method: "Post",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        userName: document.getElementById("userName").value,
        password: document.getElementById("password").value,
      }),
    });
    var tokenObj = await res.json();
    console.log(tokenObj);
  } catch (e) {
    console.log(e);
  }
}
