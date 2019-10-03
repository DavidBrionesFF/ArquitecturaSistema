using ModeloVistaControlador.uitl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloVistaControlador.repository
{
    //Interfaz generica que cada repositorio debe de implementar
    interface BaserRep<T>
    {
        //Este es el metodo para guardar
        Boolean save(T model);
        //Este metodo actualizara el modelo
        Boolean update(T model);

        //Este borrar el obj
        Boolean delete(T model);

        //Obtener todos
        List<T> findAll(Pagination pagination);

        //Este una busqueda con filtro
        List<T> find(Pagination pagination, string Key, string Value, string Operator);

        T findOne(string Key, string Value, string Operator);

        long countAll();

        long count(string Key, string Value, string Operator);
    }
}
