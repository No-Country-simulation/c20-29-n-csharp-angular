<?php
defined('BASEPATH') OR exit('No direct script access allowed');

require APPPATH . '/libraries/REST_Controller.php';
require APPPATH . '/libraries/Format.php';
use Restserver\Libraries\REST_Controller;

class apiAdopciones extends REST_Controller
{
    function __construct()
    {
        parent::__construct();
        $this->load->model('Adopciones_model');
        $this->load->library('form_validation');        
	$this->load->library('datatables');
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
    
    public function json() {
        header('Content-Type: application/json');
        echo $this->Adopciones_model->json();
    }
    

    public function get_all_adoptions_get() 
    {
        // Obtener el ID de la adopción del parámetro de consulta (si está presente)
        $id = $this->input->get('id', TRUE);

        if ($id) {
            // Si se proporciona un ID, obtener el registro específico
            $data = $this->Adopciones_model->get_by_id($id);
            
            if ($data) {
                // Preparar la respuesta en caso de éxito
                $response = array(
                    'Status' => 'Success',
                    'response' => $data,
                    'message' => 'Record retrieved successfully'
                );
            } else {
                // Preparar la respuesta en caso de no encontrar el registro
                $response = array(
                    'Status' => 'Error',
                    'response' => null,
                    'message' => 'Record not found'
                );
            }
        } else {
            // Si no se proporciona un ID, obtener todos los registros
            $data = $this->Adopciones_model->get_all();
            
            if ($data) {
                // Preparar la respuesta en caso de éxito
                $response = array(
                    'Status' => 'Success',
                    'response' => $data,
                    'message' => 'Records retrieved successfully'
                );
            } else {
                // Preparar la respuesta en caso de no encontrar registros
                $response = array(
                    'Status' => 'Error',
                    'response' => null,
                    'message' => 'No records found'
                );
            }
        }

        // Configurar la respuesta JSON
        $this->output
            ->set_content_type('application/json')
            ->set_output(json_encode($response));
    }



   
    
    public function create_Adoption_post() 
    {
        // Validar los datos del formulario
        $this->_rules();

        if ($this->form_validation->run() == FALSE) {
            // Validación fallida, devuelve un JSON con los errores
            $response = array(
                'Status' => 'Error',
                'response' => null,
                'message' => validation_errors() // Mensajes de error de validación
            );
            $this->output
                ->set_content_type('application/json')
                ->set_output(json_encode($response));
        } else {
            // Preparar los datos para insertar
            
            $data = array(
                'IdPost' => $this->security->xss_clean(strip_tags($this->input->post('IdPost', TRUE))),
                'Fecha' => $this->security->xss_clean(strip_tags($this->input->post('Fecha', TRUE))),
                'IdPostNavigationIdPost' => $this->security->xss_clean(strip_tags($this->input->post('IdPostNavigationIdPost', TRUE))),
            );

            // Insertar los datos
            $inserted = $this->Adopciones_model->insert($data);

            if ($inserted) {
                // Inserción exitosa
                $response = array(
                    'Status' => 'Success',
                    'response' => array('Id' => $inserted), // Puede ajustar según lo que devuelva insert()
                    'message' => 'Create Record Success'
                );
            } else {
                // Fallo en la inserción
                $response = array(
                    'Status' => 'Error',
                    'response' => null,
                    'message' => 'Failed to create record'
                );
            }

            // Devolver respuesta JSON
            $this->output
                ->set_content_type('application/json')
                ->set_output(json_encode($response));
        }
    }

    public function update_Adoption_post()
    {
        // Validar los datos del formulario
        $this->_rules();

        if ($this->form_validation->run() == FALSE) {
            // Validación fallida, devuelve un JSON con los errores
            $response = array(
                'Status' => 'Error',
                'response' => null,
                'message' => validation_errors() // Mensajes de error de validación
            );
            $this->output
                ->set_content_type('application/json')
                ->set_output(json_encode($response));
        } else {
            // Preparar los datos para actualizar
            $data = array(
                'IdPost' => $this->security->xss_clean(strip_tags($this->input->post('IdPost', TRUE))),
                'Fecha' => $this->security->xss_clean(strip_tags($this->input->post('Fecha', TRUE))),
                'IdPostNavigationIdPost' => $this->security->xss_clean(strip_tags($this->input->post('IdPostNavigationIdPost', TRUE))),
            );

            // Obtener el ID de la adopción a actualizar
            $idAdopcion = $this->input->post('IdAdopcion', TRUE);

            // Actualizar los datos
            $updated = $this->Adopciones_model->update($idAdopcion, $data);

            if ($updated) {
                // Actualización exitosa
                $response = array(
                    'Status' => 'Success',
                    'response' => array('IdAdopcion' => $idAdopcion), // Puede ajustar según lo que devuelva update()
                    'message' => 'Update Record Success'
                );
            } else {
                // Fallo en la actualización
                $response = array(
                    'Status' => 'Error',
                    'response' => null,
                    'message' => 'Failed to update record'
                );
            }

            // Devolver respuesta JSON
            $this->output
                ->set_content_type('application/json')
                ->set_output(json_encode($response));
        }
    }

    
   
    
    
    public function deleteAdoption_post($id) 
    {
        // Obtener el registro por ID
        $row = $this->Adopciones_model->get_by_id($id);

        if ($row) {
            // El registro existe, proceder con la eliminación
            $deleted = $this->Adopciones_model->delete($id);

            if ($deleted) {
                // Eliminación exitosa
                $response = array(
                    'Status' => 'Success',
                    'response' => null,
                    'message' => 'Delete Record Success'
                );
            } else {
                // Fallo en la eliminación
                $response = array(
                    'Status' => 'Error',
                    'response' => null,
                    'message' => 'Failed to delete record'
                );
            }
        } else {
            // El registro no existe
            $response = array(
                'Status' => 'Error',
                'response' => null,
                'message' => 'Record Not Found'
            );
        }

        // Devolver respuesta JSON
        $this->output
            ->set_content_type('application/json')
            ->set_output(json_encode($response));
    }


    public function _rules() 
    {
	$this->form_validation->set_rules('IdAdopcion', 'idadopcion', 'trim|required');
	$this->form_validation->set_rules('IdPost', 'idpost', 'trim|required');
	$this->form_validation->set_rules('Fecha', 'fecha', 'trim|required');
	$this->form_validation->set_rules('IdPostNavigationIdPost', 'idpostnavigationidpost', 'trim|required');

	$this->form_validation->set_rules('', '', 'trim');
	$this->form_validation->set_error_delimiters('<span class="text-danger">', '</span>');
    }

}
