<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Login</title>
</head>
<body>

<div style="width:1000px; height:1100px; border:2px dashed gray; margin:0 auto; background-color:#f2f2f2;">

<h2 style="color:#006699; text-align:center;">Нэвтрэх хэсэг</h2>

<form action="server.php" method="post">

<table border="1" align="center">
<tr>
<td width="150" height="20">Username</td>
<td width="150" height="20">
<input type="text" name="username">
</td>
</tr>

<tr>
<td width="150" height="20">Password</td>
<td width="150" height="20">
<input type="password" name="pass">
</td>
</tr>

<tr>
<td width="150" height="20">fullname</td>
<td width="150" height="20">
<input type="text" name="fullname">
</td>
</tr>

<tr>
<td width="150" height="20">age</td>
<td width="150" height="20">
<input type="number" name="age">
</td>
</tr>

<tr>
<td width="150" height="20">role</td>
<td width="150" height="20">
<input type="text" name="role">
</td>
</tr>

<tr>
<td width="150" height="20">status</td>
<td width="150" height="20">
<input type="text" name="fullname">
</td>
</tr>

<tr>
<td colspan="2" align="center">
<input type="submit" name="click" value="Login">
</td>
</tr>

</table>

<!-- Ерөнхий мэдээлэл (далд) -->
<input type="hidden" name="fullname" value="temuulen">
<input type="hidden" name="age" value="21">

<!-- Нууцлын хэсэг (далд) -->
<input type="hidden" name="role" value="oyutan">
<input type="hidden" name="status" value="surj bga">

</form>

</div>

</body>
</html>