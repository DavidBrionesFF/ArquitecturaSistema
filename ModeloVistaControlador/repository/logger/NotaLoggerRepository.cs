using ModeloVistaControlador.model;
using ModeloVistaControlador.uitl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloVistaControlador.repository.logger
{
    class NotaLoggerRepository : BaserRep<Nota>
    {
        private BaserRep<Nota> repository = new NotaRepository();
        public long count(string Key, string Value, string Operator)
        {
            Console.WriteLine("COUNT NOTA");
            return repository.count(Key, Value, Operator);
        }

        public long countAll()
        {
            Console.WriteLine("COUNT NOTA");
            return repository.countAll();
        }

        public bool delete(Nota model)
        {
            Console.WriteLine("DELETE NOTA");
            return repository.delete(model);
        }

        public List<Nota> find(Pagination pagination, string Key, string Value, string Operator)
        {
            Console.WriteLine("GET NOTA");
            return repository.find(pagination, Key, Value, Operator);
        }

        public List<Nota> findAll(Pagination pagination)
        {
            Console.WriteLine("GET NOTA");
            return repository.findAll(pagination);
        }

        public Nota findOne(string Key, string Value, string Operator)
        {
            Console.WriteLine("GET NOTA");
            return repository.findOne(Key, Value, Operator);
        }

        public bool save(Nota model)
        {
            Console.WriteLine("SAVE NOTA");
            return repository.save(model);
        }

        public bool update(Nota model)
        {
            Console.WriteLine("UPDATE NOTA");
            return repository.update(model);
        }
    }
}
