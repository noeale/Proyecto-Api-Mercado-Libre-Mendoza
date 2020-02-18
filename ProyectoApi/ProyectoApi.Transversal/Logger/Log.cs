using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoApi.Transversal.Logger
{
    public class Log
    {
        /// <summary>
        /// La clase que tiene la información sobre los LOGs  del sistema
        /// </summary>
         //NLog recomienda el uso de una variable estatica
            //private static Log logger =logger;
        //private static Log logger = NLog.Web.NLogBuilder.ConfigureNLog(" nlog.config ").GetCurrentClassLogger();
        /// <summary>
        /// Metodo que permite escribir el Log para las Excepciones
        /// </summary>
        /// <param name="ex">Excepcion que se produjo y se registrará</param>
        /// <param name="Location">Donde se produjo el error</param>
        /// <param name="MethodOrMessage">Mensaje extra para escribir en el log. PARAMETRO OPCIONAL</param>
        //public static void WriteLog(Exception ex, LogLocationEvent Location, string MethodOrMessage = "")
        //    {
        //        string GenericMessageLog = "Ocurrio un error inesperado en {0}, Información extra:: {1}";
        //        logger = LogManager.GetLogger("fileLogger");
        //        logger.Error(ex, string.Format(GenericMessageLog, Location, MethodOrMessage));
        //    }


     }
    
}
