<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Server Page</title>
</head>
<body>

<h2 style="color:#006699;">Дамжсан мэдээлэл</h2>

<?php
$username = $_POST["username"];
$pass = $_POST["pass"];
$fullname = $_POST["fullname"];
$age = $_POST["age"];
$role = $_POST["role"];
$status = $_POST["status"];

echo "Username: " . $username . "<br>";
echo "Password: " . $pass . "<br><br>";

echo "<h3>Ерөнхий мэдээлэл</h3>";
echo "Fullname: " . $fullname . "<br>";
echo "Age: " . $age . "<br><br>";

echo "<h3>Нууцлын хэсэг</h3>";
echo "Role: " . $role . "<br>";
echo "Status: " . $status . "<br>";
?>

</body>
</html>