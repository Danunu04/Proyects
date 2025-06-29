using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class Playlist
    {
        private List<Cancion> _canciones = new List<Cancion>();

        public int Cantidad => _canciones.Count;

        public void Agregar(Cancion c)
        {
            _canciones.Add(c);
        }

        public Cancion Obtener(int indice)
        {
            return _canciones[indice];
        }

        public I_iterator CrearIterador()
        {
            return new IteradorCanciones(this);
        }
    }
}
