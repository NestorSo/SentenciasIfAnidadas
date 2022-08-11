namespace ControlMultasTransito
{
    public partial class ControlMultas : Form
    {
        public ControlMultas()
        {
            InitializeComponent();
        }



        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Capturando los datos 
            String placa = txtPlaca.Text;
            double velocidad = double.Parse(txtVelocidad.Text);
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            DateTime hora = DateTime.Parse(lblHora.Text);

            //Procesando los datos 
            double multa = 0;
            if (velocidad <= 70)
                multa = 0;
            else if (velocidad > 70 && velocidad <= 90)
                multa = 120;
            else if (velocidad > 90 && velocidad < 100)
                multa = 240;
            else if (velocidad > 100)
                multa = 350;

            // imprimiendo resultados 
            ListViewItem fila = new ListViewItem(placa);
            fila.SubItems.Add(lblFecha.Text);
            fila.SubItems.Add(lblHora.Text);
            fila.SubItems.Add(velocidad.ToString("0.00"));
            fila.SubItems.Add(multa.ToString("C"));
            lvMultas.Items.Add(fila);   



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Today.Date.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();

        }
        ListViewItem item;
        private void lvMultas_MouseClick(object sender, MouseEventArgs e)
        {
          item = lvMultas.GetItemAt(e.X, e.Y);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(item != null)
            {
                lvMultas.Items.Remove(item);
                MessageBox.Show("Multa ha sido eliminada");

            }
            else
            {
                MessageBox.Show("Debe seleccionar una multa del listado");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Esta seguro que desea salir ??",
                                              "Control de muiltas de tránsito",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

            if(r == DialogResult.Yes)
                this.Close();
        }
    }
}