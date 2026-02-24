<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>GET Example</title>
</head>
<body>

<h2 style="color:#006699;">GET ашиглах жишээ</h2>

<form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="GET">
Username: <input type="text" name="username"><br><br>
E-mail: <input type="text" name="email"><br><br>

<input type="submit" value="Илгээх">
</form>

<?php
if(isset($_GET["username"]) && isset($_GET["email"])) {

$username = $_GET["username"];
$email = $_GET["email"];

echo "<h3 style='color:blue;'>Таны хэрэглэгчийн нэр нь $username байна</h3>";
echo "<h3 style='color:red;'>Таны Email хаяг $email байна</h3>";
}
?>

</body>
</html>