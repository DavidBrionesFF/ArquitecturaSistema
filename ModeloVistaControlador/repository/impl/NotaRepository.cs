using ModeloVistaControlador.component;
using ModeloVistaControlador.model;
using ModeloVistaControlador.uitl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace ModeloVistaControlador.repository
{
    class NotaRepository : BaserRep<Nota>
    {
        
        public long count(string Key, string Value, string Operator)
        {
            String sql = String.Format("select * from nota where {0} {1} '{2}'", Key, Operator, Value);
            return (long)Conexion.getInstance().aggregationSimpleSql(sql);
        }

        public long countAll()
        {
            String sql = "select count(*) from nota";
            return checked((long)Conexion.getInstance().aggregationSimpleSql(sql));
        }

        public bool delete(Nota model)
        {
            String sql = String.Format("delete from nota where id = {0}", model.Id);
            return Conexion.getInstance().execute(sql);
        }

        public List<Nota> find(Pagination pagination, string Key, string Value, string Operator)
        {
            String sql = String.Format("select * from nota where {0} {1} '{2}' OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY ", Key, Operator, Value, pagination.Offset, pagination.Limit);
            List<Nota> notas = new List<Nota>();
            SqlDataReader data = Conexion.getInstance().findBySQL(sql);
            while (data.Read())
            {
                Nota nota = new Nota();
                nota.Id = data.GetInt32(0);
                nota.Titulo = data.GetString(1);
                nota.Mensaje = data.GetString(2);
                notas.Add(nota);
            }
            data.Close();
            return notas;
        }

        public List<Nota> findAll(Pagination pagination)
        {
            String sql = String.Format("select * from nota order by id OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY ", pagination.Offset, pagination.Limit);
            List<Nota> notas = new List<Nota>();
            SqlDataReader data = Conexion.getInstance().findBySQL(sql);
            while (data.Read())
            {
                Nota nota = new Nota();
                nota.Id = data.GetInt32(0);
                nota.Titulo = data.GetString(1);
                nota.Mensaje = data.GetString(2);
                notas.Add(nota);
            }
            data.Close();
            return notas;
        }

        public Nota findOne(string Key, string Value, string Operator)
        {
            Nota nota = new Nota();
            String sql = String.Format("select * from nota where {0} {1} '{2}' order by id OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY ", Key, Operator, Value);
            SqlDataReader data = Conexion.getInstance().findBySQL(sql);
            while (data.Read())
            {
                
                nota.Id = data.GetInt32(0);
                nota.Titulo = data.GetString(1);
                nota.Mensaje = data.GetString(2);
            }
            data.Close();
            return nota;
        }

        public bool save(Nota model)
        {
            String sql = String.Format("insert into nota (titulo, mensaje) values('{0}', '{1}')", model.Titulo, model.Mensaje);
            return Conexion.getInstance().execute(sql);
        }

        public bool update(Nota model)
        {
            String sql = String.Format("update nota set titulo='{0}', mensaje='{1}' where id='{2}'", model.Titulo, model.Mensaje, model.Id);
            return Conexion.getInstance().execute(sql);
        }
    }
}
