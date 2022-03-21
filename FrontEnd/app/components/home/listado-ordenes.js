import Table from 'rc-table';
import DatePicker from "react-date-picker/dist/entry.nostyle";
import { Form, Row, Col, Button } from 'react-bootstrap';
import { IconCalendar } from '../../public/icons'
import styles from '../../styles/Home.module.scss'

function ListadoOrdenes() {
  const columns = [
    {
      title: '',
      dataIndex: 'edit',
      key: 'edit',
      width: 50,
      render: () => <button className='btn-icon'><img src='/img/icon-edit.png' /></button>,
    },
    {
      title: '#',
      dataIndex: 'orden',
      key: 'orden',
      width: 50,
    },
    {
      title: 'Código ',
      dataIndex: 'codigo',
      key: 'codigo',
    },
    {
      title: 'Fecha ',
      dataIndex: 'fecha',
      key: 'fecha',
    },
    {
      title: 'Paciente ',
      dataIndex: 'paciente',
      key: 'paciente',
      width: 200,
    },
    {
      title: 'Edad',
      dataIndex: 'edad',
      key: 'edad',
    },
    {
      title: 'Tipo Documento',
      dataIndex: 'tipo_doc',
      key: 'tipo_doc',
      width: 140,
    },
    {
      title: 'Número Documento',
      dataIndex: 'num_doc',
      key: 'num_doc',
      width: 140,
    },
    {
      title: 'Estado',
      dataIndex: 'estado',
      key: 'estado',
    },
    {
      title: 'Opción',
      dataIndex: 'opcion',
      key: 'opcion',
      render: () => 
        <>
          <button className='btn-icon'><img src='/img/icon-code.png' /></button>
          <button className='btn-icon'><img src='/img/icon-delete.png' /></button>
        </>
      ,
    },
  ];
  
  const data = [
    { orden: 1, codigo: 121120090, fecha: '22/12/2021', paciente: 'Flores Torres Diego', fecha: '22/12/2021', edad: '33', tipo_doc: 'DNI', num_doc:'42421110', estado:'Pendiente' },
    { orden: 2, codigo: 121120090, fecha: '22/12/2021', paciente: 'Flores Torres Diego', fecha: '22/12/2021', edad: '33', tipo_doc: 'Carnet de Extranjeria', num_doc:'42421110', estado:'Pendiente' },
    { orden: 1, codigo: 121120090, fecha: '22/12/2021', paciente: 'Flores Torres Diego', fecha: '22/12/2021', edad: '33', tipo_doc: 'DNI', num_doc:'42421110', estado:'Pendiente' },
    { orden: 2, codigo: 121120090, fecha: '22/12/2021', paciente: 'Flores Torres Diego', fecha: '22/12/2021', edad: '33', tipo_doc: 'DNI', num_doc:'42421110', estado:'Pendiente' },
    { orden: 1, codigo: 121120090, fecha: '22/12/2021', paciente: 'Flores Torres Diego', fecha: '22/12/2021', edad: '33', tipo_doc: 'DNI', num_doc:'42421110', estado:'Pendiente' },
    { orden: 2, codigo: 121120090, fecha: '22/12/2021', paciente: 'Flores Torres Diego', fecha: '22/12/2021', edad: '33', tipo_doc: 'DNI', num_doc:'42421110', estado:'Pendiente' },
    { orden: 1, codigo: 121120090, fecha: '22/12/2021', paciente: 'Flores Torres Diego', fecha: '22/12/2021', edad: '33', tipo_doc: 'DNI', num_doc:'42421110', estado:'Pendiente' },
    { orden: 2, codigo: 121120090, fecha: '22/12/2021', paciente: 'Flores Torres Diego', fecha: '22/12/2021', edad: '33', tipo_doc: 'DNI', num_doc:'42421110', estado:'Pendiente' },
  ];

  return (
    <>
      <Row className='mb-2'>
        <Col className='align-self-center' xl={2} sm={12}>
          <h5 className='title_section mb-0'>Listado de Órdenes</h5>
        </Col>
        <Col xl={2} xs={4}>
          <Form.Group className={styles.table_filtro}>
            <Form.Label>Filtro</Form.Label>
            <Form.Control />
          </Form.Group>
        </Col>
        <Col xl={2} xs={4}>
          <Form.Group className={styles.table_filtro}>
            <Form.Label>Estado </Form.Label>
            <Form.Select>
              <option></option>
            </Form.Select>
          </Form.Group>
        </Col>
        <Col xl={2} xs={4}>
          <Form.Group className={styles.table_filtro_date}>
            <Form.Label>Fecha Inicio</Form.Label>
            <DatePicker calendarIcon={<IconCalendar />} />
          </Form.Group>
        </Col>
        <Col xl={2} xs={4}>
          <Form.Group className={styles.table_filtro_date}>
            <Form.Label>Fecha Fin</Form.Label>
            <DatePicker calendarIcon={<IconCalendar />} />
          </Form.Group>
        </Col>
        <Col className='align-self-end' style={{marginLeft:'auto'}} xs={4} xl={2}>
          <Button variant="success" className='w-100'>Consultar</Button>
        </Col>
      </Row>
      
      <Table columns={columns} data={data} scroll={{ y: 300 }}/>
    </>
  )
}

export default ListadoOrdenes