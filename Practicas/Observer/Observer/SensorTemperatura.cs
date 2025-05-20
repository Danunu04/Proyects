using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class SensorTemperatura:ISensorTemperatura
    {
        private List<Iestacion> estaciones = new List<Iestacion>();
        private float Temperatura;
        public SensorTemperatura() { } // Constructor vacío


        public void setTemp(float temp)
        {
            Temperatura = temp;
            Console.WriteLine($"\n[Sensor] Nueva temperatura: {Temperatura}°C");
            notificar();
        }

        public void agregarEstacion(Iestacion estacion)
        {
            estaciones.Add( estacion );
        }

        public void eliminarEstacion(Iestacion estacion)
        {
            estaciones.Remove(estacion);
        }

        public void notificar()
        {
            foreach (var item in estaciones)
            {
                item.actualizar(Temperatura);
            }
        }
    }
}
