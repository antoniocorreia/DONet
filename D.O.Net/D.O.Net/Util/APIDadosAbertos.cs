using D.O.Net.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace D.O.Net.Util
{
    public class APIDadosAbertos
    {

        public static Result RequisicaoUltimosRegistros(string[] interesses)
        {
            string url = "http://dados.recife.pe.gov.br/api/action/datastore_search_sql?sql=SELECT * from \"fe91221a-91f5-4d92-94f1-4b8e93cfea4c\"";
            //Montar where de acordo com campo titulo (tipo de documento)
            string whereClause = " WHERE ";

            foreach (var item in interesses)
            {
                whereClause =  whereClause + "titulo LIKE '" + item + "%' OR ";
            }

            whereClause = whereClause.Substring(0, whereClause.Length - 3);

            url = url + whereClause + " AND data BETWEEN '2015-07-17' AND '2015-07-25' LIMIT 10 ";

            //var json = new WebClient().DownloadString("http://dados.recife.pe.gov.br/api/action/datastore_search?resource_id=fe91221a-91f5-4d92-94f1-4b8e93cfea4c&limit=5");
            var json = new WebClient().DownloadString(url);
            Rootobject root = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(json);

            return root.result;
        }

        

        public class Rootobject
        {
            public string help { get; set; }
            public bool success { get; set; }
            public Result result { get; set; }
        }

        public class Result
        {
            public string resource_id { get; set; }
            public Field[] fields { get; set; }
            public Record[] records { get; set; }
            public int limit { get; set; }
            public _Links _links { get; set; }
            public int total { get; set; }
        }

        public class _Links
        {
            public string start { get; set; }
            public string next { get; set; }
        }

        public class Field
        {
            public string type { get; set; }
            public string id { get; set; }
        }

        public class Record
        {
            public string secao { get; set; }
            public string ano { get; set; }
            public string caderno { get; set; }
            public string conteudo { get; set; }
            public string conteudo_ordem { get; set; }
            public string responsavel { get; set; }
            public string edicao { get; set; }
            public int _id { get; set; }
            public DateTime data { get; set; }
            public string titulo { get; set; }
        }
    }
}
