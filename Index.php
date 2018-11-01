<?php
//Variables for the connection
	$servername = "localhost";
	$server_username =  "root";
	$server_password = "";
	$dbName = "proba";

	$conn = new mysqli($servername,$server_username,$server_password,$dbName);


	if(!$conn){
		die("Connection Failed. ". mysqli_connect_error());
	}
	else{
		$varijablaime = $_GET['ime'];
		$varijablametri = $_GET['metri'];

		$sql = "INSERT INTO proba2 (ime, metri) VALUES ('$varijablaime','$varijablametri')";
	  mysqli_query($conn, $sql);
		mysqli_set_charset($conn,"utf8");
	}

?>
