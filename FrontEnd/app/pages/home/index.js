import Link from 'next/link'
import { Form, Row, Col, Button } from 'react-bootstrap';
import Table from 'rc-table';
import styles from '../../styles/Home.module.scss'

export default function Home() {
  const columns = [
    {
      title: '',
      dataIndex: 'edit',
      key: 'edit',
      width: 100,
      render: () => <a href="#">Editar</a>,
    },
    {
      title: '#',
      dataIndex: 'orden',
      key: 'orden',
      width: 100,
    },
    {
      title: 'Código ',
      dataIndex: 'codigo',
      key: 'codigo',
    },
    {
      title: 'Paciente ',
      dataIndex: 'paciente',
      key: 'paciente',
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
    },
    {
      title: 'Número Documento',
      dataIndex: 'num_doc',
      key: 'num_doc',
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
      render: () => <a href="#">Delete</a>,
    },
  ];
  
  const data = [
    { orden: 1, codigo: 121120090, fecha: '22/12/2021', edad: '33', tipo_doc: 'DNI', num_doc:'42421110', estado:'Pendiente' },
    { orden: 2, codigo: 121120090, fecha: '22/12/2021', edad: '33', tipo_doc: 'DNI', num_doc:'42421110', estado:'Pendiente' },
  ];
  return (
    <div>
      <Row>
        <Col md={3}>
          <div className='card h-100'>
            <div className={styles.perfil_photo}>
              <img src='/img/user.jpg' />
            </div>
            <div className={styles.perfil_dato}><span>Eduardo Inca Ocas</span></div>
            <div className={styles.perfil_dato}><span>eduardo.inca@gmail.com</span></div>
            <div className={styles.perfil_dato}><span>Administrador</span></div>
          </div>
        </Col>
        <Col md={3}>
          <div className='card h-100'>
            <h6 className='title_blue'>Perfil</h6>
            <Form.Group className={styles.perfil_campo}>
              <Form.Label>Télefono/Celular</Form.Label>
              <Form.Control />
            </Form.Group>
            <Form.Group className={styles.perfil_campo}>
              <Form.Label>Tipo Documento</Form.Label>
              <Form.Select>
                <option></option>
              </Form.Select>
            </Form.Group>
            <Form.Group className={styles.perfil_campo}>
              <Form.Label>N° Documento</Form.Label>
              <Form.Control />
            </Form.Group>
            <Form.Group className={styles.perfil_campo}>
              <Form.Label>Correo Electrónico</Form.Label>
              <Form.Control />
            </Form.Group>
            <Form.Group className={styles.perfil_campo}>
              <Form.Label>Cargo</Form.Label>
              <Form.Select>
                <option></option>
              </Form.Select>
            </Form.Group>
            <Form.Group className={styles.perfil_campo}>
              <Form.Label>Sede</Form.Label>
              <Form.Select>
                <option></option>
              </Form.Select>
            </Form.Group>
          </div>
        </Col>
        <Col md={3}>
          <div className='card h-100'>
            <div className={styles.resumen_header}>
              <img src='/img/clinica-logo.png' />
            </div>
            <div className={styles.resumen_body}>
              <h6 className='title_blue'>Resumen</h6>
              <img src='/img/logo-4.png' />
              <div>
                <label>Interfases: ALPHATEC SCIENTIFIC   200</label>
                <span>ALPHATEC SCIENTIFIC   51</span>
              </div>
              <div>
                <label>Número de Serie: </label>
                <span>ALPSCA200AB-0000000001</span>
                <span>ALPSCA200AB-0000000001</span>
              </div>
              <div>
                <label>Licencia Activa hasta:</label>
                <span>30/12/20222</span>
              </div>
              <div className='d-flex align-items-center'>
                <img src='/img/logo-footer.png' />
                <p>.2018-2022.Todos los derechos reservados</p>
              </div>
            </div>
          </div>
        </Col>
        <Col md={3}>
          <div className='card h-100'>
            
          </div>
        </Col>
      </Row>
      <div className='card mt-3'>
        <Table columns={columns} data={data} />
      </div>
    </div>
  )
}