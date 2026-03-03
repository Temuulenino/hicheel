<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Нэвтрэх хуудас</title>
<style>
body{
    background:#f2f2f2;
    font-family: Arial;
}
.container{
    width:900px;
    margin:20px auto;
}
fieldset{
    border:1px solid #999;
    padding:20px;
    margin-bottom:30px;
    background:white;
}
legend{
    font-size:22px;
    color:#006699;
    font-weight:bold;
}
label{
    display:inline-block;
    width:180px;
    margin-bottom:8px;
}
input, select{
    padding:5px;
    width:200px;
}
.small-text{
    font-size:12px;
    color:gray;
}
</style>
</head>
<body>

<div class="container">

<h2 style="color:black; font:Times new roman;">Нэвтрэх хуудас</h2>

<form action="server.php" method="post">

<fieldset>
<legend>Ерөнхий мэдээлэл</legend>

<label>Овог: *</label>
<input type="text" name="ovog" required><br>

<label>Нэр: *</label>
<input type="text" name="ner" required><br>

<label>Хүйс: *</label>
<select name="huis" required>
<option value="">Сонгох</option>
<option value="Эр">Эр</option>
<option value="Эм">Эм</option>
</select><br>

<label>Улс: *</label>
<select name="uls" required>
<option value="">Сонгох</option>
<option value="Монгол">Монгол</option>
<option value="БНСУ">БНСУ</option>
<option value="Япон">Япон</option>
</select>
<div class="small-text">Та оршин суугаа хаягаа сонгоно уу.</div>
<br>

<label>Гар утас:</label>
<input type="text" name="phone"><br>

<label>Username: *</label>
<input type="text" name="username" required> @mandakh.org
<div class="small-text">
Латин үсэг a-z,0-9,ID дунд хэсэгт доогуур зураас болон цэг байж болно.
</div>
<br>

<label>Нууц үг: *</label>
<input type="password" name="password" required>
<div class="small-text">Латин үсэг 6с багагүй байх шаардлагатай</div>
<br>

<label>Нууц үг давтах: *</label>
<input type="password" name="password2" required><br>

</fieldset>

<fieldset>
<legend>Нууцлалын хэсэг</legend>

<label>Нууц асуулт: *</label>
<select name="question" required>
<option value="">Сонгох</option>
<option value="pet">Таны анхны тэжээвэр амьтан?</option>
<option value="school">Таны төгссөн сургууль?</option>
<option value="color">Таны дуртай өнгө?</option>
</select><br>

<label>Нууц асуултын хариулт: *</label>
<input type="text" name="answer" required><br>

<label>Төрсөн огноо: *</label>
<input type="date" name="birth" required><br>

<label>Өөрийн email хаяг: *</label>
<input type="email" name="email" required><br>

<div class="small-text">
Нууц үг мартсан тохиолдолд тухай нууц мэдээллийг ашиглана.
</div>

</fieldset>

<input type="submit" value="Бүртгүүлэх">


</form>
</div>

</body>
</html>