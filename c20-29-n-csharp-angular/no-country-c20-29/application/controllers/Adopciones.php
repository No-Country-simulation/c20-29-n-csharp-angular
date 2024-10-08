<?php

if (!defined('BASEPATH'))
    exit('No direct script access allowed');

class Adopciones extends CI_Controller
{
    function __construct()
    {
        parent::__construct();
        $this->load->model('Adopciones_model');
        $this->load->library('form_validation');        
	$this->load->library('datatables');
    }

    public function index()
    {
        $this->load->view('adopciones/adopciones_list');
    } 
    
    public function json() {
        header('Content-Type: application/json');
        echo $this->Adopciones_model->json();
    }

    public function read($id) 
    {
        $row = $this->Adopciones_model->get_by_id($id);
        if ($row) {
            $data = array(
		'IdAdopcion' => $row->IdAdopcion,
		'IdPost' => $row->IdPost,
		'Fecha' => $row->Fecha,
		'IdPostNavigationIdPost' => $row->IdPostNavigationIdPost,
	    );
            $this->load->view('adopciones/adopciones_read', $data);
        } else {
            $this->session->set_flashdata('message', 'Record Not Found');
            redirect(site_url('adopciones'));
        }
    }

    public function create() 
    {
        $data = array(
            'button' => 'Create',
            'action' => site_url('adopciones/create_action'),
	    'IdAdopcion' => set_value('IdAdopcion'),
	    'IdPost' => set_value('IdPost'),
	    'Fecha' => set_value('Fecha'),
	    'IdPostNavigationIdPost' => set_value('IdPostNavigationIdPost'),
	);
        $this->load->view('adopciones/adopciones_form', $data);
    }
    
    public function create_action() 
    {
        $this->_rules();

        if ($this->form_validation->run() == FALSE) {
            $this->create();
        } else {
            $data = array(
		'IdAdopcion' => $this->input->post('IdAdopcion',TRUE),
		'IdPost' => $this->input->post('IdPost',TRUE),
		'Fecha' => $this->input->post('Fecha',TRUE),
		'IdPostNavigationIdPost' => $this->input->post('IdPostNavigationIdPost',TRUE),
	    );

            $this->Adopciones_model->insert($data);
            $this->session->set_flashdata('message', 'Create Record Success');
            redirect(site_url('adopciones'));
        }
    }
    
    public function update($id) 
    {
        $row = $this->Adopciones_model->get_by_id($id);

        if ($row) {
            $data = array(
                'button' => 'Update',
                'action' => site_url('adopciones/update_action'),
		'IdAdopcion' => set_value('IdAdopcion', $row->IdAdopcion),
		'IdPost' => set_value('IdPost', $row->IdPost),
		'Fecha' => set_value('Fecha', $row->Fecha),
		'IdPostNavigationIdPost' => set_value('IdPostNavigationIdPost', $row->IdPostNavigationIdPost),
	    );
            $this->load->view('adopciones/adopciones_form', $data);
        } else {
            $this->session->set_flashdata('message', 'Record Not Found');
            redirect(site_url('adopciones'));
        }
    }
    
    public function update_action() 
    {
        $this->_rules();

        if ($this->form_validation->run() == FALSE) {
            $this->update($this->input->post('', TRUE));
        } else {
            $data = array(
		'IdAdopcion' => $this->input->post('IdAdopcion',TRUE),
		'IdPost' => $this->input->post('IdPost',TRUE),
		'Fecha' => $this->input->post('Fecha',TRUE),
		'IdPostNavigationIdPost' => $this->input->post('IdPostNavigationIdPost',TRUE),
	    );

            $this->Adopciones_model->update($this->input->post('', TRUE), $data);
            $this->session->set_flashdata('message', 'Update Record Success');
            redirect(site_url('adopciones'));
        }
    }
    
    public function delete($id) 
    {
        $row = $this->Adopciones_model->get_by_id($id);

        if ($row) {
            $this->Adopciones_model->delete($id);
            $this->session->set_flashdata('message', 'Delete Record Success');
            redirect(site_url('adopciones'));
        } else {
            $this->session->set_flashdata('message', 'Record Not Found');
            redirect(site_url('adopciones'));
        }
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

/* End of file Adopciones.php */
/* Location: ./application/controllers/Adopciones.php */
/* Please DO NOT modify this information : */
/* Generated by Harviacode Codeigniter CRUD Generator 2024-09-07 15:57:46 */
/* http://harviacode.com */