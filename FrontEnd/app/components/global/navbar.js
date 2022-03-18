import Link from 'next/link'
import { useRouter } from 'next/router';
import { Form, Row, Col, Button } from 'react-bootstrap';
import { IconLogo, IconHome, IconSeroteca, IconTarifario, IconReportes, IconConfiguracion, IconExit } from '../../public/icons'
import styles from '../../styles/Navbar.module.scss'

function navbar() {
  return (
    <navbar className={styles.navbar}>
      <img src='/img/logo-3.png' className={styles.logo} />
      <p>LABORATORY INFORMATION SYSTEM</p>
      <h6>Bienvenido, Eduardo</h6>
      <img src='/img/avatar.png' />
    </navbar>
  )
}

export default navbar