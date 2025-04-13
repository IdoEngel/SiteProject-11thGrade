// ID getters
const LogOut = document.getElementById('LogOut'); // log out conversation
const AboutUs = document.getElementsByClassName("accordion"); // unfold about us sections


//Action listeners
LogOut.addEventListener('click', function (event) { // log out conversation
    askToLogOut(event);
});

for (let i = 0; i < AboutUs.length; i++) { // LOOP REQURED
    AboutUs[i].addEventListener("click", function () { // for each tag..
        unfoldAboutUs(this);
    });
}


//Functions

/**
 * ask the user if he wants to log out (confirm the loging out from the account)
 * @param {any} event - click accured
 */
function askToLogOut(event) {
    const msg = "Are you sure you want to log out?";
    const URL = "LogOut.aspx";

    event.preventDefault();

    if (confirm(msg)) {
        window.location.href = URL;
    }
}

/**
 * unfold the about us section
 * @param {any} th - this (curr item from the loop)
 */
function unfoldAboutUs(th) {

    th.classList.toggle("active");
    var panel = th.nextElementSibling;
    if (panel.style.maxHeight) {
        panel.style.maxHeight = null;
    } else {
        panel.style.maxHeight = panel.scrollHeight + "px";
    }
}

const modalBtn = document.getElementById("btn_myAccount");
modalBtn.onclick = function () {
    let = v = document.getElementById('Modal');
    v.style.display = 'block';
}
