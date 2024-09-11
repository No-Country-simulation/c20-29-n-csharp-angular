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
        <h2 style="margin-top:0px">Adopciones <?php echo $button ?></h2>
        <form action="<?php echo $action; ?>" method="post">
	    <div class="form-group">
            <label for="int">IdPost <?php echo form_error('IdPost') ?></label>
            <input type="text" class="form-control" name="IdPost" id="IdPost" placeholder="IdPost" value="<?php echo $IdPost; ?>" />
        </div>
	    <div class="form-group">
            <label for="int">IdUsuarioAdopcion <?php echo form_error('IdUsuarioAdopcion') ?></label>
            <input type="text" class="form-control" name="IdUsuarioAdopcion" id="IdUsuarioAdopcion" placeholder="IdUsuarioAdopcion" value="<?php echo $IdUsuarioAdopcion; ?>" />
        </div>
	    <div class="form-group">
            <label for="int">IdFormulario <?php echo form_error('IdFormulario') ?></label>
            <input type="text" class="form-control" name="IdFormulario" id="IdFormulario" placeholder="IdFormulario" value="<?php echo $IdFormulario; ?>" />
        </div>
	    <div class="form-group">
            <label for="datetime">Fecha <?php echo form_error('Fecha') ?></label>
            <input type="text" class="form-control" name="Fecha" id="Fecha" placeholder="Fecha" value="<?php echo $Fecha; ?>" />
        </div>
	    <input type="hidden" name="IdAdopcion" value="<?php echo $IdAdopcion; ?>" /> 
	    <button type="submit" class="btn btn-primary"><?php echo $button ?></button> 
	    <a href="<?php echo site_url('adopciones') ?>" class="btn btn-default">Cancel</a>
	</form>
    </body>
</html>