let allTournamentsDiv = document.getElementById("tournamentsCards");
let searchInput = document.getElementById("search-input");
let imgsDirUrl = "https://localhost:44347/Files/images/";

getAllTournaments();

searchInput.addEventListener("change", function () {
  getTournamentByName(this.value);
});

async function getAllTournaments() {
  try {
    var res = await fetch("https://localhost:5001/api/Tournament/Get");
    var tournaments = await res.json();
    allTournamentsDiv.innerHTML = "";
    for (let i of tournaments) {
      allTournamentsDiv.innerHTML += ` 
      <div class="card col m-2" style="width: 18rem;">
      <img src="${
        imgsDirUrl + i.logoUrl
      }" class="card-img-top" alt="tournament logo">
      <div class="card-body">
          <h5 class="card-title">${i.name}</h5>
          <a onclick="getTournamentDetails(${
            i.id
          })" class="btn btn-primary">tournament details</a>
          <a onclick="getTournamentTeams(${
            i.id
          })" class="btn btn-dark m-2">tournament teams</a>
      </div>
  </div>
  `;
    }
  } catch (e) {
    console.log(e);
  }
}

async function getTournamentByName(inputName) {
  try {
    var res = await fetch(
      `https://localhost:5001/api/Tournament/GetByName?tournamentName=${inputName}`
    );
    var tournaments = await res.json();
    allTournamentsDiv.innerHTML = "";
    for (let i of tournaments) {
      allTournamentsDiv.innerHTML += ` 
      <div class="card" style="width: 18rem;">
      <img src="${
        imgsDirUrl + i.logoUrl
      }" class="card-img-top" alt="tournament logo">
      <div class="card-body">
          <h5 class="card-title">${i.name}</h5>
          <a onclick="getTournamentDetails(${
            i.id
          })" class="btn btn-primary">tournament details</a>
          <a onclick="getTournamentTeams(${
            i.id
          })" class="btn btn-dark m-2">tournament teams</a>
      </div>
  </div>
  `;
    }
  } catch (e) {
    console.log(e);
  }
}

async function getTournamentDetails(id) {
  try {
    var res = await fetch(
      `https://localhost:5001/api/Tournament/GetByID?tournamentID=${id}`
    );
    var tournament = await res.json();
    allTournamentsDiv.innerHTML = `<div class="container-fluid">
      <a  onclick ="getAllTournaments()" class = "btn btn-dark">back to all tournaments</a>
    </div>`;
    allTournamentsDiv.innerHTML += ` 
      <div class="card w-100">
  <img src="${
    imgsDirUrl + tournament.logoUrl
  }" class="card-img-top" alt="logo url">
  <div class="card-body">
    <h5 class="card-title">${tournament.name}</h5>
    <p class="card-text">${tournament.description}</p>
    </div>
    <div class="container-fluid">
      ${tournament.vedioUrl}
    </div>
</div>
      
  `;
  } catch (e) {
    console.log(e);
  }
}

async function getTournamentTeams(id) {
  try {
    var res = await fetch(
      `https://localhost:5001/api/Team/GetbytournamentID?tournamentID=${id}`
    );
    var teams = await res.json();
    allTournamentsDiv.innerHTML = `<div class="container-fluid">
    <a  onclick ="getAllTournaments()" class = "btn btn-dark">back to all tournaments</a>
  </div>`;
    for (let i of teams) {
      allTournamentsDiv.innerHTML += ` 
      <div class="card" style="width: 18rem;">
      <img src="${
        imgsDirUrl + i.logoUrl
      }" class="card-img-top" alt="tournament logo">
      <div class="card-body">
          <h5 class="card-title">${i.name}</h5>
          <p class="card-text">${i.description}</p>
          <a href = "${i.websiteUrl}" class="card-text">team website</a>
          <p class="card-text">${i.foundationDate}</p>
          
      </div>
  </div>
  `;
    }
  } catch (e) {
    console.log(e);
  }
}
