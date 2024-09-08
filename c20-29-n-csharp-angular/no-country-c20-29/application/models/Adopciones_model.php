<?php

if (!defined('BASEPATH'))
    exit('No direct script access allowed');

class Adopciones_model extends CI_Model
{

    public $table = 'adopciones';
    public $id = '';
    public $order = 'DESC';

    function __construct()
    {
        parent::__construct();
    }

    // datatables
    function json() {
        $this->datatables->select('IdAdopcion,IdPost,Fecha,IdPostNavigationIdPost');
        $this->datatables->from('adopciones');
        //add this line for join
        //$this->datatables->join('table2', 'adopciones.field = table2.field');
        $this->datatables->add_column('action', anchor(site_url('adopciones/read/$1'),'Read')." | ".anchor(site_url('adopciones/update/$1'),'Update')." | ".anchor(site_url('adopciones/delete/$1'),'Delete','onclick="javasciprt: return confirm(\'Are You Sure ?\')"'), '');
        return $this->datatables->generate();
    }

     // Método para obtener todos los registros
     public function get_all() {
        $query = $this->db->get('adopciones');
        return $query->result_array(); // Devuelve los registros como un array asociativo
    }

    // Método para obtener un registro por ID
    public function get_by_id($id) {
        $this->db->where('IdAdopcion', $id); // Ajusta el campo según el nombre real en tu base de datos
        $query = $this->db->get('adopciones');
        return $query->row_array(); // Devuelve el registro como un array asociativo, o null si no se encuentra
    }

    // get total rows
    function total_rows($q = NULL) {
        $this->db->like('', $q);
	$this->db->or_like('IdAdopcion', $q);
	$this->db->or_like('IdPost', $q);
	$this->db->or_like('Fecha', $q);
	$this->db->or_like('IdPostNavigationIdPost', $q);
	$this->db->from($this->table);
        return $this->db->count_all_results();
    }

    // get data with limit and search
    function get_limit_data($limit, $start = 0, $q = NULL) {
        $this->db->order_by($this->id, $this->order);
        $this->db->like('', $q);
	$this->db->or_like('IdAdopcion', $q);
	$this->db->or_like('IdPost', $q);
	$this->db->or_like('Fecha', $q);
	$this->db->or_like('IdPostNavigationIdPost', $q);
	$this->db->limit($limit, $start);
        return $this->db->get($this->table)->result();
    }

    // insert data
    function insert($data)
    {
        $this->db->insert($this->table, $data);
    }

    // update data
    function update($id, $data)
    {
        $this->db->where($this->id, $id);
        $this->db->update($this->table, $data);
    }

    // delete data
    function delete($id)
    {
        $this->db->where($this->id, $id);
        $this->db->delete($this->table);
    }

}
