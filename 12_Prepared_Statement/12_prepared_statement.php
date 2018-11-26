<?php
# DB Zugriff
$database = "localhost";
$admin_un = "username";
$admin_pw = "password";
$dbname = "myDB";

$connection = new mysqli($database, $admin_un, $admin_pw, $dbname);
if ($connection->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

# Prepared Statement
$prepared = $connection->prepare("SELECT id, username, password FROM User WHERE username = ? AND password = ?");
$prepared->bind_param("ss", $username, $password);

# Abfangen von userdaten, sofern POST
$username = $_POST['user'];
$password = $_POST['pass'];

# Ausführen des Prepared Statements
$prepared->execute();
$prepared->close();
$connection->close();
?> 
<html>
<body>
  <form action="#" method="post">
    Username:
    <input name="user"></input>
    <br/>
    Password:
    <input name="pass"></input>
  </form>
</body>
</html>