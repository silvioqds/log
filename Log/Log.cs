using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
    {
        class Log
        {

            public string LOG { get; set; }
            private static dynamic dynamic = new ExpandoObject();
            public object Object { get; private set; }



            /// <summary>
            /// Inicializa uma nova instancia da Classe LOG (object obj) leva 1 argumento
            /// </summary>
            /// <param name="obj"></param>
            public Log(object obj)
            {
                this.Object = obj;
            }

            /// <summary>
            /// Inicializa uma nova instancia da Classe LOG (string log,object obj) leva 2 argumento
            /// </summary>
            /// <param name="log"></param>
            /// <param name="obj"></param>
            public Log(string log, object obj)
            {
                this.LOG = log;
                this.Object = obj;
            }

            protected Log(Log log)
            {
                this.LOG = log.LOG;
                this.Object = log.Object;
            }

        /// <summary>
        /// Adiciona um texto ao seu log antes das propriedades serem exibidas
        /// </summary>
        /// <param name="txt"></param>
        public void SetLog(string txt)
            {
                this.LOG = txt;        
            }

            /// <summary>
            /// Método genérico para criar um log a partir de uma Classe 
            /// </summary>
            public ClientLog NewLog()
            {
                //obtem o tipo do objeto
                var tipo = Object.GetType();
                dynamic.Class = tipo;
                foreach (var prop in tipo.GetProperties())
                {
                    AddProperty(dynamic, prop.Name, prop.GetValue(Object));
                }
              
                ClientLog clientLog = new ClientLog(this);
                return clientLog;
            }
            
            private Log ReturnLog()
            {
                return Object as Log;
            }


            private void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
            {
                IDictionary<string, object> dicExpando = expando as IDictionary<string, object>;

                dicExpando["DATA"] = DateTime.Now;
                if (dicExpando.ContainsKey(propertyName))
                {
                    dicExpando[propertyName] = propertyValue;
                }
                else
                {
                    dicExpando.Add(propertyName, propertyValue);
                }
            }

         
            /// <summary>
            /// Retorna um objeto dinamico com as propriedades do seu objeto
            /// </summary>
            protected ExpandoObject GetObject()
            {
                NewLog();
                return dynamic;
            }

         

        }
}



