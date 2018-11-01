<?php
//Variables for the connection
$servername = "localhost";
$server_username =  "root";
$server_password = "";
$dbName = "proba";

// Create connection
$conn = new mysqli($servername, $server_username, $server_password, $dbName);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT ime, metri FROM proba2";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo "Ime: " . $row["ime"]. " Prijeđeno metara: " . $row["metri"]. "<br>";
    }
} else {
    echo "0 results";
}
$conn->close();
?>
