import '../styles/globals.css'
import '../styles/globals.scss'
import 'bootstrap/dist/css/bootstrap.min.css';
import Layout from "../components/layout"

function MyApp({ Component, pageProps }) {  
  const LayoutComponent = Component.Layout || EmptyLayout;
  return (
    <>
      <LayoutComponent>
        <Component {...pageProps} />
      </LayoutComponent>
    </>
  )
}

const EmptyLayout = ({children}) => <>{children}</>

export default MyApp
