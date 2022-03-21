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
        { false ? 
          <Perfil />
          :
          <Opciones />
        }
        <Col md={3}>
          <div className='card h-100'>
            
          </div>
        </Col>
      </Row>
      <div className='card mt-3'>
        <ListadoOrdenes />
      </div>
    </div>
  )
}