using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class IteradorCanciones: I_iterator
    {
        private Playlist _playlist;
        private int posicionactual = 0;

        public IteradorCanciones(Playlist playlist)
        {
            _playlist = playlist;
        }
        public bool tienesiguiente()
        {
            return posicionactual < _playlist.Cantidad;
        }

        public Cancion Siguiente()
        {
            if (tienesiguiente())
            {
                return _playlist.Obtener(posicionactual++);
            }
            return null;
        }
    }
}
