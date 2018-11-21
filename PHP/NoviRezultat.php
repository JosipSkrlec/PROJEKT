<?php
	//Variables for the connection
	$servername = "localhost";
	$server_username =  "id6721306_josip";
	$server_password = "skrlec";
	$dbName = "id6721306_igraautojs";
	// kod
	$kodt = "D45800HJOSIP19976HHT0PCF41";

	$conn = new mysqli($servername,$server_username,$server_password,$dbName);

	if(!$conn){
		die("Connection Failed. ". mysqli_connect_error());
	}
	else{
		$varijablaime = $_GET['ime'];
		$varijablametri = $_GET['metri'];
		$varkod = $_GET['KOD'];

	if($varkod == $kodt){

		$sql = "INSERT INTO bazaauto (ime, metri) VALUES ('$varijablaime','$varijablametri')";

		mysqli_query($conn, $sql);
		mysqli_set_charset($conn,"utf8");
			}
			else{
				echo("SERVER ERROR, Molimo pokušajte kasnije! :D tnx");
			}
		}

?>
