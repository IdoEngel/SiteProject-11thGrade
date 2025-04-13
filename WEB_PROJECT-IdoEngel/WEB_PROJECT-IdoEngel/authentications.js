function checkSignUp() {
    let msg = "";

    let inner = document.getElementById("errorDisplay");

    if (!isEmailValid()) {
        msg += "Email must have a proper puttern.<br/>";

    }
    if (!isPasswordValid()) {
        msg += "Password need to have at least 8 chars - with one number, one upper and one lower case letters.<br/>";
    }
    if (!SamePassword()) {
        msg += "Passwords need to be the same.<br/>";
    }

    inner.innerHTML = msg;

    return (msg.length == 0);
}


function SamePassword() {
    const passwordID = "signUp_password";
    const repPasswordID = "repPassword";

    let pass = document.getElementById(passwordID);
    let rePass = document.getElementById(repPasswordID);

    return (pass.value == rePass.value)
}

function isEmailValid() {
    const emailID = "signUp_email";

    let email = document.getElementById(emailID);

    const emailPattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    return !emailPattern.test(email);
}

function isPasswordValid() {
    const passwordID = "signUp_password";
    const repPasswordID = "repPassword";

    let pass = document.getElementById(passwordID);

    // בדיקה אם הסיסמה מכילה לפחות אות אחת גדולה
    let hasUpperCase = false;
    let hasLowerCase = false;
    let hasNumber = false;

    // לולאת בדיקה לכל התו בסיסמה
    for (let i = 0; i < pass.value.length; i++) {
        if (/[A-Z]/.test(pass.value[i])) {
            hasUpperCase = true;  // אות גדולה נמצאה
        }
        if (/[a-z]/.test(pass.value[i])) {
            hasLowerCase = true;  // אות קטנה נמצאה
        }
        if (/\d/.test(pass.value[i])) {
            hasNumber = true;  // מספר נמצא
        }
    }

    // בדיקה אם הסיסמה מכילה לפחות שמונה תווים
    if (pass.value.length < 8) {
        return false;  // אם יש פחות משמונה תווים
    }

    // אם כל הדרישות התקיימו
    return hasUpperCase && hasLowerCase && hasNumber;  // כל הדרישות צריכות להתקיים
}

