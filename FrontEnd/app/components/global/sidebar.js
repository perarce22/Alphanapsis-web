import Link from 'next/link'
import { useRouter } from 'next/router';
import { Form, Row, Col, Button } from 'react-bootstrap';
import { IconLogo, IconHome, IconSeroteca, IconTarifario, IconReportes, IconConfiguracion, IconExit } from '../../public/icons'
import styles from '../../styles/Sidebar.module.scss'

function Sidebar() {
  const router = useRouter();
  return (
    <>
      <div className={styles.sidebar}>
        <div className={styles.logo}>
          <Link href="/home">
            <a><IconLogo /></a>
          </Link>
        </div>
        <ul>
          <li className={`${styles.item} ${ router.pathname == "/home" ? styles.item_active : ''}`}>
            <Link href="/home">
            <a><IconHome /></a>
            </Link>
          </li>
          <li className={`${styles.item} ${ router.pathname == "/" ? styles.item_active : ''}`}>
            <Link href="/">
            <a><IconSeroteca /></a>
            </Link>
          </li>
          <li className={`${styles.item} ${ router.pathname == "/" ? styles.item_active : ''}`}>
            <Link href="/">
            <a><IconTarifario /></a>
            </Link>
          </li>
          <li className={`${styles.item} ${ router.pathname == "/" ? styles.item_active : ''}`}>
            <Link href="/">
              <a><IconReportes /></a>
            </Link>
          </li>
          <li className={`${styles.item} ${ router.pathname == "/" ? styles.item_active : ''}`}>
            <Link href="/">
              <a><IconConfiguracion /></a>
            </Link>
          </li>
          <li className={`${styles.item} ${ router.pathname == "/" ? styles.item_active : ''}`}>
            <Link href="/">
              <a><IconExit /></a>
            </Link>
          </li>
        </ul>
      </div>
    </>
  )
}

export default Sidebar;