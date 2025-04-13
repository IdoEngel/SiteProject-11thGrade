<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserNav.aspx.cs" Inherits="WEB_PROJECT_IdoEngel.UserNav1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8" />
    <title>Log In Page</title>
    <link rel="icon" type="image/x-icon" href="imgs/pageIcon.png">
    <script src="authentications.js" defer></script>

    <style>
.forms-container {
  display: flex;
  justify-content: center; /* מרכז את הטפסים בתוך המכולה */
  gap: 20px; /* מרווח בין הטפסים */
}

/* טקסט ותצוגת שגיאות */
.invalid {
    color: #D32F2F; /* אדום כהה אך לא צעקני */
    border-color: #D32F2F;
    font-weight: bold;
}

/* מבנה הטופס */
form {

    text-align: center;
    background: rgba(255, 255, 255, 0.6); /* רקע חצי שקוף */
    padding: 20px;
    border-radius: 12px;
    display: flex; /* שימוש ב-flexbox */
    flex-direction: column; /* האלמנטים בטופס מסודרים בטור */
    justify-content: center; /* ממרכז אנכית את התוכן */
    align-items: center; /* ממרכז אופקית את התוכן */
    height: 400px; /* גובה קבוע לטופס */
    width: 300px; /* רוחב קבוע */
}

/* תוויות */
label {
    display: block; /* מציב את התווית מעל השדה */
    width: 100%;
    margin-bottom: 5px;
    font-weight: 600;
    text-align: left; /* ניתן להוסיף אם רוצים שהתווית תהיה מיושרת לשמאל */
}


/* שדות קלט */
input {
    padding: 10px;
    margin: 10px 0;
    border: 2px solid #ccc;
    border-radius: 10px;
    font-size: 14px;
    width: 80%;
    max-width: 300px;
    transition: 0.3s;
    font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
}

/* קלט לא תקין */
input:invalid {
    border: 2px solid #D32F2F;
}

/* עיצוב גוף הדף */
body {
  display: flex;
  flex-direction: column; /* כל האלמנטים מוצבים בטור */
  align-items: center;
  justify-content: center;
  background-image: url('imgs/backgroundImage.png');
  background-size: cover;
  background-position: center;
  font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
  text-align: center;
}

/* כפתורים */
.button {
    background-color: #333; /* כהה כדי להתאים לניווט */
    border: none;
    color: #f2f2f2;
    padding: 10px 20px;
    text-align: center;
    text-decoration: none;
    display: inline-block;
    font-size: 17px;
    border-radius: 12px;
    cursor: pointer;
    transition: background-color 0.3s;
}

.button:hover {
    background-color: #ddd;
    color: black;
}

h1, h2, h3 {
  margin-bottom: 20px; /* מרווח בין הכותרת לתוכן שמתחתיה */
  text-align: left;    /* מיושר לשמאל, ניתן לשנות ל-center או right לפי הצורך */
  font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;
  color: #333;         /* צבע כהה */
}
    </style>

</head>
<body style="font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sans-serif;">
    <h1 style="font-weight: bolder; text-align:center;"> To Start - Log In or Sign Up</h1>
    <p>To use our website - you need to create an acount or log in to an existing one</p>

    <h3 style="text-align: center;" class="">Use the left form to sign-up, and the right form if you have an account</h3>

    <div class="invalid" id="errorDisplay">
        <%=msg %>
    </div>
    <div class="forms-container">
            <form onsubmit="return checkSignUp();" method="post" id="SignUpForn">
        <label for="name" id="nameLabel_signUP"> Full Name </label>
        <input type="text" required id="signUp_name" name="signUp_name"
               title="Two names, 3 lettters for each at least" placeholder="What should we call you?" /> <br />

        <label for="email">  Email  </label>
        <input type="email" required id="signUp_email" name="signUp_email"
               title="user@example.com" placeholder="How should we contact you?" /> <br />

        <label for="password" id="pass"> Enter Password </label>
        <input type="password" required name="signUp_password"
               title="At least 8 characters" id="signUp_password" placeholder="A password you'll remember" /> <br />

        <label for="password" id="repPass"> Repeat password </label>
        <input type="password" required name="repPassword"
               title="At least 8 characters" id="repPassword" /> <br />

        <button class="button" type="submit" id="button_signUp">Create an acount</button>
    </form>

    <form method="post" id="LogInForn">

        <label for="email">  Email  </label>
        <input name="logIn_email" type="email" required id="logIn_email"
               title="user@example.com" placeholder="What is your email?" /> <br />

        <label for="password"> Enter Password </label>
        <input name="logIn_password" type="password" required
               title="At least 8 characters" id="logIn_password" placeholder="Enter your password" /> <br />

        <button class="button" type="submit">What are my tasks?</button>
    </form>

    </div>

</body>
</html>
