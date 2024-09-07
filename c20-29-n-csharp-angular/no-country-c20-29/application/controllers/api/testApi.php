<?php
defined('BASEPATH') OR exit('No direct script access allowed');

require APPPATH . '/libraries/REST_Controller.php';
require APPPATH . '/libraries/Format.php';
use Restserver\Libraries\REST_Controller;

class testApi extends REST_Controller {

    public function __construct() {
        parent::__construct();
    }

    public function user_get($id = 0) {
        // Ejemplo de un arreglo de datos simulados
        $users = [
            ['id' => 1, 'name' => 'John Doe', 'email' => 'john@example.com'],
            ['id' => 2, 'name' => 'Jane Doe', 'email' => 'jane@example.com'],
            ['id' => 3, 'name' => 'Jim Doe', 'email' => 'jim@example.com'],
        ];

        if ($id === 0) {
            // Si no se proporciona ID, devolver todos los usuarios
            $this->response($users, REST_Controller::HTTP_OK);
        } else {
            // Buscar el usuario por ID
            $user = null;
            foreach ($users as $u) {
                if ($u['id'] == $id) {
                    $user = $u;
                    break;
                }
            }

            if ($user) {
                $this->response($user, REST_Controller::HTTP_OK);
            } else {
                $this->response(['status' => false, 'message' => 'User not found'], REST_Controller::HTTP_NOT_FOUND);
            }
        }
    }
}
