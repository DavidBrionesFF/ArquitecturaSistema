using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloVistaControlador.uitl
{
    class Pagination
    {
        private int limit;
        private int offset;
        private int size;
        private int page;


        public static Pagination defautlPage = new Pagination(1, 5);

        public int Limit { get => limit; set => limit = value; }
        public int Offset { get => offset; set => offset = value; }
        public int Size { get => size; set => size = value; }
        public int Page { get => page; set => page = value; }

        public Pagination()
        {

        }

        public Pagination(int page , int size)
        {
            this.Page = page;
            this.Size = size;
            this.Limit = page * size;
            this.Offset = limit - size;
        }
    }
}
