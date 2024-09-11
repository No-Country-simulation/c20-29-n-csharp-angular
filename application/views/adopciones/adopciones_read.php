<!doctype html>
<html>
    <head>
        <title>harviacode.com - codeigniter crud generator</title>
        <link rel="stylesheet" href="<?php echo base_url('assets/bootstrap/css/bootstrap.min.css') ?>"/>
        <style>
            body{
                padding: 15px;
            }
        </style>
    </head>
    <body>
        <h2 style="margin-top:0px">Adopciones Read</h2>
        <table class="table">
	    <tr><td>IdPost</td><td><?php echo $IdPost; ?></td></tr>
	    <tr><td>IdUsuarioAdopcion</td><td><?php echo $IdUsuarioAdopcion; ?></td></tr>
	    <tr><td>IdFormulario</td><td><?php echo $IdFormulario; ?></td></tr>
	    <tr><td>Fecha</td><td><?php echo $Fecha; ?></td></tr>
	    <tr><td></td><td><a href="<?php echo site_url('adopciones') ?>" class="btn btn-default">Cancel</a></td></tr>
	</table>
        </body>
</html>