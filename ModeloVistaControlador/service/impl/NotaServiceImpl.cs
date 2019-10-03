
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Siempre los using de tus capas que vas a usar
using ModeloVistaControlador.repository.logger;
using ModeloVistaControlador.model;
using ModeloVistaControlador.uitl;
using ModeloVistaControlador.repository;

namespace ModeloVistaControlador.service.impl
{

    class NotaServiceImpl : NotaService
    {
        private BaserRep<Nota> repository;

        public NotaServiceImpl()
        {
            repository = new NotaLoggerRepository();
        }

        public long countAll()
        {
            return repository.countAll();
        }

        public void delete(int id)
        {
            Nota nota = new Nota();
            nota.Id = id;
            repository.delete(nota);
        }

        public List<Nota> findAll(Pagination pagination)
        {
            return repository.findAll(pagination);
        }

        public Nota findById(string id)
        {
            return repository.findOne("id", id, "=");
        }

        public void save(Nota nota)
        {
            repository.save(nota);
        }

        public void update(Nota nota)
        {
            repository.update(nota);
        }
    }
}
