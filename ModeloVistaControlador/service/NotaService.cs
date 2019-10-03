using ModeloVistaControlador.model;
using ModeloVistaControlador.uitl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloVistaControlador.service
{
    interface NotaService
    {
        void save(Nota nota);
        void update(Nota nota);
        void delete(int id);
        long countAll();
        List<Nota> findAll(Pagination pagination);
        Nota findById(string id);
    }
}
