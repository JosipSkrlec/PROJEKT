<?php
//Variables for the connection
$servername = "localhost";
$server_username =  "id6721306_josip";
$server_password = "skrlec";
$dbName = "id6721306_igraautojs";

// Create connection
$conn = new mysqli($servername, $server_username, $server_password, $dbName);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT ime, metri FROM bazaauto ORDER BY metri DESC";
$result = $conn->query($sql);

echo"<table >
<tr>
<th style='color:#ffffff;font-size:40px'>IME     </th>
<th style='color:#ffffff;font-size:40px'>     PRIJEĐENO</th>
</tr>";
$brojac =0;

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        $brojac ++;
        if($brojac < 21){
          if($brojac > 3){
              echo "<tr style='color:#ffffff;font-size:40px'><th>" . $row["ime"]. "</th><th>" . $row["metri"]. "</th></tr>";
          }
          else if($brojac == 1){
              echo "<tr style='color:#ff0000;font-size:70px'><th>" . $row["ime"]. "</th><th>" . $row["metri"]. "</th></tr>";
          }else if($brojac == 2){
              echo "<tr style='color:#ff3f3f;font-size:60px'><th>" . $row["ime"]. "</th><th>" . $row["metri"]. "</th></tr>";
          }
          else if($brojac == 3){
            echo "<tr style='color:#ff8c8c;font-size:50px'><th>" . $row["ime"]. "</th><th>" . $row["metri"]. "</th></tr>";
          }
        }
    }
} else {
    echo "Nema Rezultata";
}
echo"</table>";


$conn->close();
?>
