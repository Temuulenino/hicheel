<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>RGB Result</title>
</head>
<body>

<?php
$r = $_POST["r"];
$g = $_POST["g"];
$b = $_POST["b"];

$color = "rgb($r,$g,$b)";

echo "<h2 style='color:#006699;'>Оруулсан RGB код</h2>";
echo "R: $r <br>";
echo "G: $g <br>";
echo "B: $b <br><br>";

echo "<div style='width:200px; height:200px; background-color:$color; border:1px solid black;'></div>";
?>

</body>
</html>