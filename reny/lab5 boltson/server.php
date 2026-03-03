<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Server Page</title>
</head>
<body>

<h2 style="color:#006699;">Дамжсан мэдээлэл</h2>

<?php

echo "<h3>Ерөнхий мэдээлэл</h3>";
echo "Овог: " . $_POST["ovog"] . "<br>";
echo "Нэр: " . $_POST["ner"] . "<br>";
echo "Хүйс: " . $_POST["huis"] . "<br>";
echo "Улс: " . $_POST["uls"] . "<br>";
echo "Гар утас: " . $_POST["phone"] . "<br>";
echo "Username: " . $_POST["username"] . "@mandakh.org<br><br>";

echo "<h3>Нууцлалын хэсэг</h3>";
echo "Нууц асуулт: " . $_POST["question"] . "<br>";
echo "Хариулт: " . $_POST["answer"] . "<br>";
echo "Төрсөн огноо: " . $_POST["birth"] . "<br>";
echo "Email: " . $_POST["email"] . "<br>";

?>

</body>
</html>