import Link from 'next/link'
import { Form, Row, Col, Button } from 'react-bootstrap';
import styles from '../../styles/Home.NuevaOrden.module.scss'

function NuevaOrden() {
  return (
    <div className='card'>
      <div className={styles.header_section}>
        <h6 className='title_blue'>Crear Nueva Orden</h6>
        <label>Código</label>
        <Form.Control />
        <label>Fecha de Emisión</label>
        <Form.Control />
      </div>
      <Row>
        <Col md={7}>
          <fieldset className={styles.fieldset}>
            <legend>Paciente</legend>
            <Row className='mb-2'>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>Tipo Documento</Form.Label>
                  <Form.Select>
                    <option></option>
                  </Form.Select>
                </Form.Group>
              </Col>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>N° Documento</Form.Label>
                  <Form.Control />
                </Form.Group>
              </Col>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>Historia Clínica</Form.Label>
                  <Form.Control />
                </Form.Group>
              </Col>
            </Row>
            <Form.Group className='mb-2'>
              <Form.Label>Nombre Completo</Form.Label>
              <Form.Control />
            </Form.Group>
            <Row className='mb-2'>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>Teléfono/Celular</Form.Label>
                  <Form.Control />
                </Form.Group>
              </Col>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>Sexo</Form.Label>
                  <Form.Select>
                    <option></option>
                  </Form.Select>
                </Form.Group>
              </Col>
              <Col md={4}>
                <Row>
                  <Col>
                    <Form.Group>
                      <Form.Label>Edad</Form.Label>
                      <Form.Control />
                    </Form.Group>
                  </Col>
                  <Col>
                    <Form.Group>
                      <Form.Label>N° Cama</Form.Label>
                      <Form.Control />
                    </Form.Group>
                  </Col>
                </Row>
              </Col>
            </Row>
            <Row className='mb-2'>
              <Col md={8}>
                <Form.Group>
                  <Form.Label>Correo Electrónico</Form.Label>
                  <Form.Control />
                </Form.Group>
              </Col>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>Diagnóstico</Form.Label>
                  <Form.Control />
                </Form.Group>
              </Col>
            </Row>
            <Row>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>Servicio de Salud</Form.Label>
                  <Form.Select>
                    <option></option>
                  </Form.Select>
                </Form.Group>
              </Col>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>Procedencia</Form.Label>
                  <Form.Select>
                    <option></option>
                  </Form.Select>
                </Form.Group>
              </Col>
            </Row>
          </fieldset>
          <fieldset className={styles.fieldset}>
            <legend>Médico</legend>
            <Row className='mb-2'>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>Tipo Documento</Form.Label>
                  <Form.Select>
                    <option></option>
                  </Form.Select>
                </Form.Group>
              </Col>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>N° Documento</Form.Label>
                  <Form.Control />
                </Form.Group>
              </Col>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>N° Colegiatura</Form.Label>
                  <Form.Control />
                </Form.Group>
              </Col>
            </Row>
            <Form.Group className='mb-2'>
              <Form.Label>Nombre Completo</Form.Label>
              <Form.Control />
            </Form.Group>
            <Row className='mb-2'>
              <Col md={8}>
                <Form.Group>
                  <Form.Label>Correo Electrónico</Form.Label>
                  <Form.Control />
                </Form.Group>
              </Col>
              <Col md={4}>
                <Form.Group>
                  <Form.Label>Teléfono/Celular</Form.Label>
                  <Form.Control />
                </Form.Group>
              </Col>
            </Row>
          </fieldset>
        </Col>
        <Col md={5}>
          <fieldset className={styles.fieldset}>
            <legend>Perfiles</legend>
            <Form.Group>
              <Form.Label>Área de Estudio</Form.Label>
              <Form.Select>
                <option></option>
              </Form.Select>
            </Form.Group>
            <Form.Group>
              <Form.Control />
            </Form.Group>
          </fieldset>
        </Col>
      </Row>
    </div>
  )
}

export default NuevaOrden