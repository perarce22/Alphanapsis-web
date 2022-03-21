import 'bootstrap/dist/css/bootstrap.min.css';
import 'react-calendar/dist/Calendar.css';
import 'react-date-picker/dist/DatePicker.css';
import '../styles/globals.css'
import '../styles/globals.scss'
import Layout from "../components/layout"

function MyApp({ Component, pageProps }) {  
  // const LayoutComponent = Component.Layout || EmptyLayout;
  if(Component.getLayout) {
    return Component.getLayout(<Component {...pageProps} />)
  }
  return (
    <>
      <Layout><Component {...pageProps} /></Layout>
    </>
  )
}

// const EmptyLayout = ({children}) => <>{children}</>

export default MyApp
