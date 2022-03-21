import { Form, Row, Col, Button } from 'react-bootstrap';
import styles from '../../styles/Home.module.scss'

function Opciones() {
  return (
    <>
      <Col md={3}>
        <div className='card h-100'>
            <div className={styles.option_img} style={{background: 'linear-gradient(135deg, #AD862E 16.96%, #54AC47 38.1%, #D1D528 83.03%)'}}>
              <h6>órdenes</h6>
              <div><img src='/img/op-ordenes.png' /></div>
            </div>
            <div className={styles.option_item}>
              <span>+</span>Listado de órdenes<a><img src='/img/arrow-select.png' /></a>
            </div>
            <div className={styles.option_item}>
              <span>+</span>Crear Nueva Orden<a><img src='/img/arrow-select.png' /></a>
            </div>
            <div className={styles.option_item}>
              <span>+</span>Búsqueda de Órdenes<a><img src='/img/arrow-select.png' /></a>
            </div>
            <div className={styles.option_item}>
              <span>+</span>Modificar Órden<a><img src='/img/arrow-select.png' /></a>
            </div>
            <div className={styles.option_item}>
              <span>+</span>Aprobar Órden<a><img src='/img/arrow-select.png' /></a>
            </div>
        </div>
      </Col>
      <Col md={3}>
        <div className='card h-100'>
            <div className={styles.option_img} style={{background: 'linear-gradient(135deg, #F58A6F 17.81%, #F37B71 38.41%, #FBAF5B 82.18%)'}}>
              <h6>profesional<br/>de<br/>la salud</h6>
              <div><img src='/img/op-profesionales.png' /></div>
            </div>
            <div className={styles.option_item}>
              <span>+</span>Crear Profesional de la Salud<a><img src='/img/arrow-select.png' /></a>
            </div>
            <div className={styles.option_item}>
              <span>+</span>Buscar Profesional de la Salud<a><img src='/img/arrow-select.png' /></a>
            </div>
            <div className={styles.option_item}>
              <span>+</span>Eliminar Profesional de la Salud<a><img src='/img/arrow-select.png' /></a>
            </div>
        </div>
      </Col>
      <Col md={3}>
        <div className='card h-100'>
            <div className={styles.option_img} style={{background: 'linear-gradient(135deg, #F37374 17.81%, #CA1682 38.41%, #562C8C 82.18%)'}}>
              <h6>paciente</h6>
              <div><img src='/img/op-paciente.png' /></div>
            </div>
            <div className={styles.option_item}>
              <span>+</span>Crear Paciente<a><img src='/img/arrow-select.png' /></a>
            </div>
            <div className={styles.option_item}>
              <span>+</span>Buscar Paciente<a><img src='/img/arrow-select.png' /></a>
            </div>
            <div className={styles.option_item}>
              <span>+</span>Eliminar Paciente<a><img src='/img/arrow-select.png' /></a>
            </div>
        </div>
      </Col>
    </>
  )
}

export default Opciones