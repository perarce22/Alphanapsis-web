import Link from 'next/link'
import { Form, Row, Col, Button } from 'react-bootstrap';
import styles from '../../styles/Home.module.scss'
import ListadoOrdenes from '../../components/home/listado-ordenes';
import Opciones from '../../components/home/opciones';
import Perfil from '../../components/home/perfil';

export default function Home() {
  
  return (
    <div>
      <Row>
        { true ? 
          <Perfil />
          :
          <Opciones />
        }
        <Col md={3}>
          <div className='card h-100'>
            <div className={styles.data_control_logo}>
              <img src='/img/logo-2.png' />
            </div>
            <Row>
              <Col>
                <div className={styles.data_control}>
                  <span>Ordenes Diarias:</span>
                </div>
              </Col>
              <Col>
                <div className={styles.data_control}>
                  <span>Ordenes por Aprobar:</span>
                </div>
              </Col>
            </Row>
            <div className={styles.data_control}>
              <span>Versión:</span>
              <img src='/img/logo-4.png' />
            </div>
            <div className={styles.data_control}>
              <span>Suscriptor:</span>
              <img src='/img/clinica-logo.png' />
            </div>
            <div className={styles.data_control}>
              <span>Sede:</span>
              <img style={{marginRight:12}} src='/img/arrow-select.png' />
            </div>
            <div className={styles.data_control}>
              <span>Observaciones:</span>
            </div>
          </div>
        </Col>
      </Row>
      <div className='card mt-3'>
        <ListadoOrdenes />
      </div>
    </div>
  )
}