using System;
using System.Collections.Generic;
using System.Text;
using USD.Alphanapsis.Entidades;

namespace USD.Alphanapsis.Servicios.Repository
{
    public interface INotificacionRepository
    {
        ICollection<Notificacion> ListarNotificacionPendiente();
        ICollection<Notificacion> ListarNotificacion(string filtro, bool? estado, int page, int rows, out int nroTotalRegistros);
        Notificacion ObtenerNotificacion(int id);
        void NotificacionEnviada(int id);
        void EliminaNotificacion(int id, bool estado, string usuario);
        int RegistrarNotificacion(Notificacion notificacion);
    }
}
