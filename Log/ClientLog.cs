using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace Log
{

    internal class ClientLog : Log
    {
        /// <summary>
        /// Inicializa uma nova instancia da Classe ClassLog que necessita como argumento uma Classe do tipo LOG
        /// </summary>
        /// <param name="obj"></param>
        public ClientLog(Log log):
            base(log.LOG,log.Object)
        {
            
        }

  
        /// <summary>
        /// Gera um log na tela com as propriedades do seu objeto (Para console application)
        /// </summary>
        public void PrintLog()
        {
            StringBuilder sb = new StringBuilder();
            var tipo = GetObject();
            sb.AppendLine(string.Concat(tipo.Select(x => Environment.NewLine + x.Key + ":" + x.Value)));
            Console.WriteLine(LOG + sb.ToString());
        }
        /// <summary>
        /// // Retorna a string do log personalizado
        /// </summary>
        /// <returns></returns>
        public string StringLog()
        {
            StringBuilder sb = new StringBuilder();
            var tipo = GetObject();
            sb.AppendLine(string.Concat(tipo.Select(x => Environment.NewLine + x.Key + ":" + x.Value)));
            return sb.ToString();
        }

        /// <summary>
        /// Salva seu log em um arquivo com a extensão do tipo .txt é necessario passar o caminho aonde deseja salvar o log
        /// </summary>
        /// <param name="path"></param>
        public void SaveLog(string path)
        {
            string[] lines = { };

            var pairs = GetObject();

            if (System.IO.File.Exists(path))
            {
                lines = System.IO.File.ReadAllLines(path);
            }

            System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true);

            sw.WriteLine(LOG);
            foreach (var p in pairs)
            {

                sw.WriteLine(p.Key + ":" + p.Value);
            }
            sw.WriteLine("===============================================");
            sw.Close();
        }

    }
}
