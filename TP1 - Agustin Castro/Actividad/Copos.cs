using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Actividad
{
    class Copo
    {
        private int posX;
        private int posY;

        public int PosX
        {
            set
            {
                posX = value;
            }
            get
            {
                return posX;
            }
        }
        public int PosY
        {
            set
            {
                posY = value;
            }
            get
            {
                return posY;
            }
        }

        public void Mostrar()
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write("*");
        }
        public void Borrar()
        {
            Console.SetCursorPosition(posX, posY);
            Console.Write(" ");
        }
        public bool HayCopos(int fila, int columna, List<Copo> copos)
        {
            foreach(var copo in copos)
            {
                if (copo.PosY == fila && copo.posX == columna)
                {
                    return true;
                }
            }
            return false;
        }
        public void Mover(List<Copo> copos)
        {
            int sigFIla = posY + 1;
            if (sigFIla != Configuracion.CantFilas && !HayCopos(sigFIla, posX, copos))
            {
                Borrar();
                posY++;
                Mostrar();
            }
        }
        public void BorrarLineaCompleta(List<Copo> copos)
        {
            for (int i = 0; i < Configuracion.CantFilas ; i++)
            {
                int contador = 0;
                foreach (var copo in copos)
                {
                    if (copo.posY == i)
                    {
                        contador++;
                    }
                }
                if (contador == Configuracion.CantColumnas)
                {
                    foreach (var copo in copos)
                    {
                        if (copo.posY == i)
                        {
                            copo.Borrar();
                        }
                    }
                    copos.RemoveAll(c => c.posY == i);
                    foreach (var copo in copos)
                    {
                        if (copo.posY < i)
                        {
                            copo.Borrar();
                            copo.posY++;
                            copo.Mostrar();
                        }
                    }
                }
            }
        }
    }
}
