using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Crear un namespace para los modelos, si usas entity framework es diferente porque hay se usan entidades entonces 
// se deben de serparar modelos con entidades, porque los entidades solo se usan en los repositorios y los modelos en vistas.
namespace ModeloVistaControlador.model
{
    //La clase debe de llamarse como se llama la tabla en base de datos
    class Nota
    {
        //Cada propiedad que esta en base de datos debe de estar en el modelo
        //Si usas entity framework la cosa varia
        //El tipo de dato de cada una debe de ser la misma en base de datos
        private int id;
        private String titulo;
        private String mensaje;

        //Debes de generar los getter y setters
        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
    }
}
