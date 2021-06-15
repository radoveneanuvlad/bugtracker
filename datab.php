<html>
    <head>
    <title>Bug Tracker DB</title>
    <style type="text/css">
    table {
        border-collapse: collapse;
        width: 100%;
        color: #eb4034;
        font-family: monospace;
        font-size: 25px;
        text-align: left;
    }

    th {
        background-color: #eb4034;
        color: white;
    }

    tr:nth-child(even) {background-color: #ededed}
    </style>
    </head>
    <body>
        <table>
            <tr>
                <th>ID</th>
                <th>Bug</th>
            </tr>
            <?php
            $conn = mysqli_connect("localhost","root","","bugs");
            $sql = "SELECT `ID`, `Bug` FROM `tracker` ORDER BY ID";
            $result = $conn->query($sql);

            if($result->num_rows > 0){
                while ($row = $result->fetch_assoc()){
                    echo "<tr><td>" . $row["ID"] . "</td><td>" . $row["Bug"] . "</td></tr>";

                }
            }
            $conn->close();
            ?>
        </table>
    </body>
</html>