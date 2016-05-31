using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form

    {
        string turno;
        string puntaje;
        int turno_real;
        Tablero t;
        public Form1()
        {
            InitializeComponent();
            t = new Tablero(5, 5);
            txtturno.Text = "0";
            txtpuntaje.Text = "0";
            turno_real = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            t.Dibuja(this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            turno = Convert.ToString(turno_real);
            turno_real = turno_real + 1;
            txtturno.Text = turno;
            puntaje = Convert.ToString(turno_real);
            puntaje = puntaje + 0;
            txtpuntaje.Text = puntaje;

            t.next();
            t.update();
            this.Invalidate();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                this.Invalidate();
                t = new Tablero(5, 10);
                turno_real = 1;
                txtturno.Text = "0";
                txtpuntaje.Text = "0";
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                this.Invalidate();
                t = new Tablero(10, 10);
                turno_real = 1;
                txtturno.Text = "0";
                txtpuntaje.Text = "0";

            }
            else if (comboBox1.SelectedIndex == 2)
            {
                this.Invalidate();
                t = new Tablero(10, 15);
                turno_real = 1;
                txtturno.Text = "0";
                txtpuntaje.Text = "0";

            }
            else if (comboBox1.SelectedIndex == 3)
            {
                this.Invalidate();
                t = new Tablero(15, 15);
                turno_real = 1;
                txtturno.Text = "0";
                txtpuntaje.Text = "0";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                this.Invalidate();
                t = new Tablero(15, 20);
                turno_real = 1;
                txtturno.Text = "0";
                txtpuntaje.Text = "0";
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                this.Invalidate();
                t = new Tablero(20, 20);
                turno_real = 1;
                txtturno.Text = "0";
                txtpuntaje.Text = "0";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            t = new Tablero(5, 5);
            turno_real = 1;
            txtturno.Text = "0";
            txtpuntaje.Text = "0";

            t.Dibuja(this);
            this.Invalidate();

        }

        private void btnPickFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlgOpenFile = new OpenFileDialog())
            {
                dlgOpenFile.Filter = "All Filles|*.*";

                if (dlgOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        mediaPlayer.URL = dlgOpenFile.FileName;
                        lblPath.Text = dlgOpenFile.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to load file!\n\n" + ex.Message);
                    }
                }
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mediaPlayer.Ctlcontrols.stop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            mediaPlayer.Ctlcontrols.play();
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            if (mediaPlayer.URL.Length > 0)
            {
                mediaPlayer.fullScreen = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter escribir = new StreamWriter("puntaje.txt", true);
            StreamWriter escribir1 = new StreamWriter("turno.txt", true);
            escribir.WriteLine(txtturno.Text);
            escribir1.WriteLine(txtpuntaje.Text);
            escribir.Close();
            escribir1.Close();
            MessageBox.Show("Partida Actual Guardada");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            StreamReader mostrar = new StreamReader("puntaje.txt");
            txtturno1.Text = mostrar.ReadToEnd();
            mostrar.Close();
            StreamReader mostrar1 = new StreamReader("turno.txt");
            txtpuntaje1.Text = mostrar1.ReadToEnd();
            mostrar1.Close();

        }
    }
}
            
        
    

