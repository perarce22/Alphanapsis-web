import Sidebar from "../global/sidebar"
import Navbar from "../global/navbar"

const Layout = ({children}) => {
  return (
    <div id="main-wrapper">
      <Sidebar />
      <div className="content-body">
        <Navbar />
        {children}
      </div>
    </div>
  )
}

export default Layout