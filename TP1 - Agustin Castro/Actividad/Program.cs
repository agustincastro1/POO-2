using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad
{
    /*
     Realizar un programa que represente una simulación de copos de nieve cayendo en la consola, utilizando el símbolo "*" para cada copo.

El programa debe cumplir con las siguientes condiciones:
Definir una clase Configuracion que almacene parámetros de la simulación, como la cantidad de filas, columnas y la velocidad de caída de los copos.
Definir una clase Copo que modele el comportamiento de un copo de nieve. Cada copo debe tener una posición en la consola y un método para mostrarse y desplazarse hacia abajo.
Usar una lista para administrar todos los copos activos durante la simulación.
Implementar una lógica que controle la caída de los copos de nieve, evitando que se superpongan en la misma posición.
Al completarse una fila con copos en todas las columnas, esta debe eliminarse para permitir que continúe la simulación.
El programa debe ejecutarse en un ciclo continuo, simulando de manera animada la caída de los copos.
    */
    class Configuracion
    {
        private static int cantFilas;
        private static int cantColumnas;
        private static int velocidad;

        public static int CantFilas
        {
            set
            {
                cantFilas = value;
            }
            get
            {
                return cantFilas;
            }
        }
        public static int CantColumnas
        {
            set
            {
                cantColumnas = value;
            }
            get
            {
                return cantColumnas;
            }
        }
        public static int Velocidad
        {
            set
            {
                velocidad = value;
            }
            get
            {
                return velocidad;
            }
        }

        static void Main(string[] args)
        {
            Configuracion configuracion = new Configuracion();
            List<Copo> copos = new List<Copo>();
            Random random = new Random();
            Configuracion.CantFilas = 10;
            Configuracion.CantColumnas = 10;
            Configuracion.Velocidad = 200;
            while (true)
            {
                if (copos.Count <= Configuracion.CantColumnas * Configuracion.CantFilas)
                {
                    Copo copo = new Copo();
                    copo.PosX = random.Next(0, Configuracion.CantColumnas);
                    copo.PosY = 0;
                    if (!copo.HayCopos(copo.PosY, copo.PosX, copos))
                    {
                        copos.Add(copo);
                        copo.Mostrar();
                    }
                }
                foreach (var copo in copos)
                {
                    copo.Mover(copos);
                }
                copos[0].BorrarLineaCompleta(copos);
                System.Threading.Thread.Sleep(Configuracion.Velocidad);
            }
        }
    }
}
