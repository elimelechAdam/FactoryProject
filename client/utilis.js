const userID = localStorage.getItem("login");
let userActions = localStorage.getItem("actions");

function checkStatus() {
  if (userID) {
    window.location.href = `index.html`;
    localStorage.clear();
  } else {
    window.location.href = `homepage.html`;
  }
}

function setWelcome() {
  const userFullname = localStorage.getItem("fullname");
  const spanWelcome = document.getElementById("userWelcome");
  if (!userFullname) window.location.href = `index.html`; //if session not found href to index page

  spanWelcome.innerText = `Welcome ${userFullname},Actions: ${userActions}`;
}

async function actionsLeft() {
  try {
    const fFetch = await fetch("https://localhost:44300/api/login/" + userID);
    const data = await fFetch.json();
    //   let nums = --data.NumOfActions;
    let outOfActions = data.NumOfActions;
    userActions = data.NumOfActions;
    console.log(`outOfActions : ${outOfActions}`);
    // console.log(outOfActions);
    // console.log(data.NumOfActions == false);
    if (outOfActions == 0) {
      localStorage.setItem("actions", 0);
      console.log(localStorage.getItem("actions"));
      console.log("You are out of actions. Try again later.");
      window.location.href = `index.html`;
      return outOfActions;
    } else {
      console.log("Works");
      return outOfActions;
    }
  } catch (err) {
    console.log(`actionsLeft fnc: ${err}`);
  }
}
async function addAction() {
  try {
    let status = await actionsLeft(userID);
    console.log(status);
    if (!status == 0) {
      //Something to do and minus to NumOfActions so when it reach 0 its will go to true and will stop work.
      let obj = { NumOfActions: --status };
      var addActParams = {
        method: "PUT",
        body: JSON.stringify(obj),
        headers: { "Content-type": "application/json" },
      };
      await fetch("https://localhost:44300/api/login/" + userID, addActParams);

      localStorage.setItem("actions", obj.NumOfActions);
      console.log(localStorage.getItem("actions"));
      console.log(userActions);
      console.log("added");

      return true;
    } else {
      return false;
    }
  } catch (err) {
    console.log(`addAction fnc : ${err}`);
  }
}

async function resetActionsLeft(userID) {
  console.log("Updated - another day.");
  let obj = { NumOfActions: 2 };
  var addActParams = {
    method: "PUT",
    body: JSON.stringify(obj),
    headers: { "Content-type": "application/json" },
  };
  console.log(userID);
  await fetch("https://localhost:44300/api/login/" + userID, addActParams);
}
