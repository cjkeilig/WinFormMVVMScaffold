using Core.Interfaces;
using Core.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace WindowsFormsApplication1
{
    static class Program
    {
        ///
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var container = BuildContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run(new Form1(container.Resolve<PersonManager>()));
        }

        public static IUnityContainer BuildContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IPersonManager, PersonManager>();
            currentContainer.RegisterType<IMainFormView, Form1>();
            // note: registering types could be moved off to app config if you want as well
            return currentContainer;
        }
    }
}
