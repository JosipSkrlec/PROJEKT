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
<th>IME     </th>
<th>     PRIJEĐENO</th>
</tr>";
$brojac =0;

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        $brojac ++;
        if($brojac < 11){
          if($brojac > 3){
              echo "<tr><th>" . $row["ime"]. "</th><th>" . $row["metri"]. "</th></tr>";
          }
          else if($brojac == 1){
              echo "<tr style='color:#ff0000;font-size:30px'><th>" . $row["ime"]. "</th><th>" . $row["metri"]. "</th></tr>";
          }else if($brojac == 2){
              echo "<tr style='color:#990000;font-size:25px'><th>" . $row["ime"]. "</th><th>" . $row["metri"]. "</th></tr>";
          }
          else if($brojac == 3){
            echo "<tr style='color:#4d0000;font-size:20px'><th>" . $row["ime"]. "</th><th>" . $row["metri"]. "</th></tr>";
          }
        }
    }
} else {
    echo "Nema Rezultata";
}
echo"</table>";


$conn->close();
?>
