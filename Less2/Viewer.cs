using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2
{
    public class Viewer
    {
        // сделать синглтоне
        private static Viewer _instance;
        // main menu

        // меню общее


        // меню выбора определенного типа


        // меню изменение параметров консоли
        private Viewer()
        {
            
        }

        public static Viewer Singletone()
        {
            if (_instance == null)
                _instance = new Viewer();
            return _instance;
        }


    }
}
