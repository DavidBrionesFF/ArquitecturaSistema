using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//Importar tus librerias
using ModeloVistaControlador.model;
using ModeloVistaControlador.component;
using ModeloVistaControlador.service;
using ModeloVistaControlador.service.impl;
using ModeloVistaControlador.uitl;

namespace ModeloVistaControlador.view
{
    public partial class NotaView : Form
    {

        private NotaService service = new NotaServiceImpl();
        private int page = 1;
        public NotaView()
        {
            //Abrir la conecxion a la db
            Conexion.getInstance().openConection();
            InitializeComponent();
        }

        private void NotaView_Load(object sender, EventArgs e)
        {
            onload(0);
        }

        public void onload(int page)
        {
            
            comboBoxId.Items.Clear();
            lblNotas.Text = String.Format("Notas ({0})", service.countAll() + "");

            Pagination pagination = null;

            if (page == 0)
            {
                txtNumPagina.Text = "1";
                pagination = Pagination.defautlPage;
            }
            else
            {
                txtNumPagina.Text = page + "";
                pagination = new Pagination(page, 5);
            }

            dataGridView1.Rows.Clear();
            service.findAll(pagination)
                .ForEach(nota =>
                {
                    comboBoxId.Items.Add(nota.Id);
                    dataGridView1.Rows.Add(nota.Id, nota.Titulo, nota.Mensaje);
                });
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Nota nota = new Nota();
            nota.Titulo = txtTitulo.Text;
            nota.Mensaje = txtMensaje.Text;
            service.save(nota);
            onload(0);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            service.delete(Int32.Parse(comboBoxId.Text));
            onload(0);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Nota nota = new Nota();
            nota.Id = Int32.Parse(comboBoxId.Text);
            nota.Titulo = txtTitulo.Text;
            nota.Mensaje = txtMensaje.Text;
            service.update(nota);
            onload(0);
        }

        private void ComboBoxId_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (page>0)
            {
                page = page - 1;
                onload(page);
            }
            
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            page = page + 1;
            onload(page);
        }
    }
}
