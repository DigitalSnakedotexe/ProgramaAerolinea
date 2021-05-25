using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AerolineaI_MarkI
{
    public partial class Main : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=Gestorvuelos; Integrated Security=SSPI");

        public Main()
        {
            InitializeComponent();
        }

        //Pantalla Principal
        private void Main_Load(object sender, EventArgs e)
        {
            //Inicia con la pantalla en LOGO
            Paeropuerto.Visible = false;
            Pavion.Visible = false;
            Ppasajeros.Visible = false;
            Ppersonal.Visible = false;
            Pvuelo.Visible = false;          


        }

        private void Aeropuerto_Click(object sender, EventArgs e)
        {
            Paeropuerto.Visible = true;
            Pavion.Visible = false;
            Ppasajeros.Visible = false;
            Ppersonal.Visible = false;
            Pvuelo.Visible = false;
        }

        private void Avion_Click(object sender, EventArgs e)
        {
            Paeropuerto.Visible = false;
            Pavion.Visible = true;
            Ppasajeros.Visible = false;
            Ppersonal.Visible = false;
            Pvuelo.Visible = false;
        }

        private void Pasajero_Click(object sender, EventArgs e)
        {
            Paeropuerto.Visible = false;
            Pavion.Visible = false;
            Ppasajeros.Visible = true;
            Ppersonal.Visible = false;
            Pvuelo.Visible = false;
        }

        private void Personal_Click(object sender, EventArgs e)
        {
            Paeropuerto.Visible = false;
            Pavion.Visible = false;
            Ppasajeros.Visible = false;
            Ppersonal.Visible = true;
            Pvuelo.Visible = false;
        }

        private void Vuelo_Click(object sender, EventArgs e)
        {
            Paeropuerto.Visible = false;
            Pavion.Visible = false;
            Ppasajeros.Visible = false;
            Ppersonal.Visible = false;
            Pvuelo.Visible = true;
        }

        private void Borrar_Click(object sender, EventArgs e)
        {
            ClaveCatastro.Clear();
            Calle.Clear();
            Colonia.Clear();
            Ciudad.Clear();
            Estado.Clear();
            CodigoPostal.Clear();
            ClaveCatastro.Focus();

            Matricula.Clear();
            Fabricante.Clear();
            Modelo.Clear();
            Capacidad.Clear();
            AutoVuelo.Focus();

            IdPasajero.Clear();
            NombrePasajero.Clear();
            ApellidoPasajero.Clear();
            NumeroAsiento.Clear();
            Clase.Clear();

            IdEmpleado.Clear();
            NombreEmpelado.Clear();
            ApeidoEmpleado.Clear();
            Profesion.Clear();
            Puesto.Clear();
            conexion.Close();         

            IdVuelo.Clear();
            Fecha.Clear();
            AeroOrigen.Clear();
            AeroDestino.Clear();
            


        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //FIN DE PANTALLA PRINSIPAL

        //AEROPUERTO
        private void GAE_Click(object sender, EventArgs e)
        {
            // se crea el comando para dar de altas al sistema
            SqlCommand altas = new SqlCommand("insert into Aeropuerto(ClaveCatastro,Calle,Colonia,Ciudad,Estado,CodigoPostal) values(@ClaveCatastro,@Calle,@Colonia,@Ciudad,@Estado,@CodigoPostal)", conexion);
            // se pasan los valores de los text box a las variables temporales

            altas.Parameters.AddWithValue("@ClaveCatastro", ClaveCatastro.Text);
            altas.Parameters.AddWithValue("@Calle", Calle.Text);
            altas.Parameters.AddWithValue("@Colonia", Colonia.Text);
            altas.Parameters.AddWithValue("@Ciudad", Ciudad.Text);
            altas.Parameters.AddWithValue("@Estado", Estado.Text);
            altas.Parameters.AddWithValue("@CodigoPostal", CodigoPostal.Text);

            conexion.Open();// se abre la conexion
            altas.ExecuteNonQuery();

            conexion.Close();// se cierra la conexion
            MessageBox.Show("Datos Guardados");
            // limpiar los textbox
            ClaveCatastro.Clear();
            Calle.Clear();
            Colonia.Clear();
            Ciudad.Clear();
            Estado.Clear();
            CodigoPostal.Clear();
            ClaveCatastro.Focus();
        }

        private void CAE_Click(object sender, EventArgs e)
        {
            SqlCommand consulta = new SqlCommand("SELECT * FROM Aeropuerto WHERE ClaveCatastro = @ClaveCatastro", conexion);
            conexion.Open();

            consulta.Parameters.AddWithValue("@ClaveCatastro", ClaveCatastro.Text);

            SqlDataReader reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                ClaveCatastro.Text = reader[0].ToString();
                Calle.Text = reader[1].ToString();
                Colonia.Text = reader[2].ToString();
                Ciudad.Text = reader[3].ToString();
                Estado.Text = reader[4].ToString();
                CodigoPostal.Text = reader[5].ToString();
            }
            MessageBox.Show("Consulta completada");
            conexion.Close();
        }

        private void MAE_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Aeropuerto SET ClaveCatastro = @ClaveCatastro, Calle = @Calle, Colonia = @Colonia, Ciudad = @Ciudad, Estado = @Estado, CodigoPostal = @CodigoPostal";
            conexion.Open();
            SqlCommand update = new SqlCommand(query, conexion);
            update.Parameters.AddWithValue("@ClaveCatastro", ClaveCatastro.Text);
            update.Parameters.AddWithValue("@Calle", Calle.Text);
            update.Parameters.AddWithValue("@Colonia", Colonia.Text);
            update.Parameters.AddWithValue("@Ciudad", Ciudad.Text);
            update.Parameters.AddWithValue("@Estado", Estado.Text);
            update.Parameters.AddWithValue("@CodigoPostal", CodigoPostal.Text);
            update.ExecuteNonQuery();
            conexion.Close();
            ClaveCatastro.Clear();        

            MessageBox.Show("Datos actualizados");
         
        }

        private void DAE_Click(object sender, EventArgs e)
        {
            string baja = "DELETE FROM Aeropuerto WHERE ClaveCatastro = @ClaveCatastro";
            conexion.Open();


            SqlCommand cmdIns = new SqlCommand(baja, conexion);
            cmdIns.Parameters.AddWithValue("ClaveCatastro", ClaveCatastro.Text);
            cmdIns.ExecuteNonQuery();

            cmdIns.Dispose();
            cmdIns = null;

            ClaveCatastro.Clear();
            Calle.Clear();
            Colonia.Clear();
            Ciudad.Clear();
            Estado.Clear();
            CodigoPostal.Clear();
            ClaveCatastro.Focus();
            conexion.Close();
            MessageBox.Show("Aeropuerto Eliminado");
        }
        //FIN DE AEROPUERTO
        
            
        // AVIONES                                 

        private void GA_Click(object sender, EventArgs e)
        {
             // se crea el comando para dar de altas al sistema
            SqlCommand altas = new SqlCommand("insert into Avion(Matricula,Fabricante,Modelo,Capacidad,AutoVuelo) values(@Matricula,@Fabricante,@Modelo,@Capacidad,@AutoVuelo)", conexion);
            // se pasan los valores de los text box a las variables temporales

            altas.Parameters.AddWithValue("@Matricula", Matricula.Text);
            altas.Parameters.AddWithValue("@Fabricante", Fabricante.Text);
            altas.Parameters.AddWithValue("@Modelo", Modelo.Text);
            altas.Parameters.AddWithValue("@Capacidad", Capacidad.Text);
            altas.Parameters.AddWithValue("@AutoVuelo", AutoVuelo.Text);

            conexion.Open();// se abre la conexion
            altas.ExecuteNonQuery();

            conexion.Close();// se cierra la conexion
            MessageBox.Show("Actualizado");
            // limpiar los textbox
            Matricula.Clear();
            Fabricante.Clear();
            Modelo.Clear();
            Capacidad.Clear();
            AutoVuelo.Focus();
        }

        private void CA_Click(object sender, EventArgs e)
        {
            SqlCommand consulta = new SqlCommand("SELECT * FROM Avion WHERE Matricula = @Matricula", conexion);
            conexion.Open();

            consulta.Parameters.AddWithValue("@Matricula", Matricula.Text);

            SqlDataReader reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                Matricula.Text = reader[0].ToString();
                Fabricante.Text = reader[1].ToString();
                Modelo.Text = reader[2].ToString();
                Capacidad.Text = reader[3].ToString();
                AutoVuelo.Text = reader[4].ToString();
            }
            MessageBox.Show("CONSULTA COMPLETA");
            conexion.Close();
        }

        private void MA_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Avion SET Matricula = @Matricula, Fabricante = @Fabricante, Modelo = @Modelo, Capacidad = @Capacidad, AutoVuelo = @AutoVuelo";
            conexion.Open();
            SqlCommand update = new SqlCommand(query, conexion);
            update.Parameters.AddWithValue("@Matricula", Matricula.Text);
            update.Parameters.AddWithValue("@Fabricante", Fabricante.Text);
            update.Parameters.AddWithValue("@Modelo", Modelo.Text);
            update.Parameters.AddWithValue("@Capacidad", Capacidad.Text);
            update.Parameters.AddWithValue("@AutoVuelo", AutoVuelo.Text);
            update.ExecuteNonQuery();            
            conexion.Close();

            IdPasajero.Clear();
            NombrePasajero.Clear();
            ApellidoPasajero.Clear();
            NumeroAsiento.Clear();
            Clase.Clear();

            MessageBox.Show("Datos actualizados");
        }

        private void BA_Click(object sender, EventArgs e)
        {
            string baja = "DELETE FROM Avion WHERE Matricula = @Matricula";
            conexion.Open();


            SqlCommand cmdIns = new SqlCommand(baja, conexion);
            cmdIns.Parameters.AddWithValue("Matricula", Matricula.Text);
            cmdIns.ExecuteNonQuery();

            cmdIns.Dispose();
            cmdIns = null;

            Matricula.Clear();
            Fabricante.Clear();
            Modelo.Clear();
            Capacidad.Clear();
            AutoVuelo.Focus();

            conexion.Close();
            MessageBox.Show("Avion a sido dado de baja");


        }
        // FIN AVION

        
        // PASAJEROS

        private void GP_Click(object sender, EventArgs e)
        {
            // se crea el comando para dar de altas al sistema
            SqlCommand altas = new SqlCommand("insert into Pasajeros(IdPasajero,NombrePasajero,ApellidoPasajero,NumeroAsiento,Clase) values(@IdPasajero,@NombrePasajero,@ApellidoPasajero,@NumeroAsiento,@Clase)", conexion);
            // se pasan los valores de los text box a las variables temporales

            altas.Parameters.AddWithValue("@IdPasajero", IdPasajero.Text);
            altas.Parameters.AddWithValue("@NombrePasajero", NombrePasajero.Text);
            altas.Parameters.AddWithValue("@ApellidoPasajero", ApellidoPasajero.Text);
            altas.Parameters.AddWithValue("@NumeroAsiento", NumeroAsiento.Text);
            altas.Parameters.AddWithValue("@Clase", Clase.Text);

            conexion.Open();// se abre la conexion
            altas.ExecuteNonQuery();

            conexion.Close();// se cierra la conexion
            MessageBox.Show("Pasajero Guardado");
            // limpiar los textbox
            IdPasajero.Clear();
            NombrePasajero.Clear();
            ApellidoPasajero.Clear();
            NumeroAsiento.Clear();
            Clase.Clear();
        }

        private void CP_Click(object sender, EventArgs e)
        {
            SqlCommand consulta = new SqlCommand("SELECT * FROM Pasajeros WHERE IdPasajero = @IdPasajero", conexion);
            conexion.Open();

            consulta.Parameters.AddWithValue("@IdPasajero", IdPasajero.Text);

            SqlDataReader reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                IdPasajero.Text = reader[0].ToString();
                NombrePasajero.Text = reader[1].ToString();
                ApellidoPasajero.Text = reader[2].ToString();
                NumeroAsiento.Text = reader[3].ToString();
                Clase.Text = reader[4].ToString();

            }
            MessageBox.Show("CONSULTA COMPLETA");
            conexion.Close();
        }

        private void MP_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Pasajeros SET IdPasajero = @IdPasajero, NombrePasajero = @NombrePasajero, ApeidoPasajero = @ApeidoPasajero, Asiento = @Asiento, Clase = @Clase";
            conexion.Open();
            SqlCommand update = new SqlCommand(query, conexion);
            update.Parameters.AddWithValue("@IdPasajero", IdPasajero.Text);
            update.Parameters.AddWithValue("@NombrePasajero", NombrePasajero.Text);
            update.Parameters.AddWithValue("@ApeidoPasajero", ApellidoPasajero.Text);
            update.Parameters.AddWithValue("@Asiento", NumeroAsiento.Text);
            update.Parameters.AddWithValue("@Clase", Clase.Text);
            update.ExecuteNonQuery();
            conexion.Close();

            IdPasajero.Clear();
            NombrePasajero.Clear();
            ApellidoPasajero.Clear();
            NumeroAsiento.Clear();
            Clase.Clear();

            MessageBox.Show("Datos actualizados");
        }

        private void BP_Click(object sender, EventArgs e)
        {
            string baja = "DELETE FROM Pasajeros WHERE IdPasajero = @IdPasajero";
            conexion.Open();


            SqlCommand cmdIns = new SqlCommand(baja, conexion);
            cmdIns.Parameters.AddWithValue("@IdPasajero", IdPasajero.Text);
            cmdIns.ExecuteNonQuery();

            cmdIns.Dispose();
            cmdIns = null;

            IdPasajero.Clear();
            NombrePasajero.Clear();
            ApellidoPasajero.Clear();
            NumeroAsiento.Clear();
            Clase.Clear();

            conexion.Close();
            MessageBox.Show("Pasajero Eliminado");
        }
        //FIN PASAJERO




        //PERSONAL

        private void GPE_Click(object sender, EventArgs e)
        {
            // se crea el comando para dar de altas al sistema
            SqlCommand altas = new SqlCommand("insert into Personal(IdEmpleado,NombreEmpelado,ApeidoEmpleado,Profesion,Puesto) values(@IdEmpleado,@NombreEmpelado,@ApeidoEmpleado,@Profesion,@Puesto)", conexion);
            // se pasan los valores de los text box a las variables temporales

            altas.Parameters.AddWithValue("@Idempleado", IdEmpleado.Text);
            altas.Parameters.AddWithValue("@NombreEmpelado", NombreEmpelado.Text);
            altas.Parameters.AddWithValue("@ApeidoEmpleado", ApeidoEmpleado.Text);
            altas.Parameters.AddWithValue("@Profesion", Profesion.Text);
            altas.Parameters.AddWithValue("@Puesto", Puesto.Text);

            conexion.Open();// se abre la conexion
            altas.ExecuteNonQuery();

            conexion.Close();// se cierra la conexion
            MessageBox.Show("Actualizado");
            // limpiar los textbox
            IdEmpleado.Clear();
            NombreEmpelado.Clear();
            ApeidoEmpleado.Clear();
            Profesion.Clear();
            Puesto.Clear();
        }

        private void CPE_Click(object sender, EventArgs e)
        {
            SqlCommand consulta = new SqlCommand("SELECT * FROM Personal WHERE IdEmpleado = @IdEmpleado", conexion);
            conexion.Open();

            consulta.Parameters.AddWithValue("@Idempleado", IdEmpleado.Text);

            SqlDataReader reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                IdEmpleado.Text = reader[0].ToString();
                NombreEmpelado.Text = reader[1].ToString();
                ApeidoEmpleado.Text = reader[2].ToString();
                Profesion.Text = reader[3].ToString();
                Puesto.Text = reader[4].ToString();

            }
            MessageBox.Show("CONSULTA COMPLETA");
            conexion.Close();
        }

        private void MPE_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Personal SET IdEmpleado = @IdEmpleado, NombreEmpelado = @NombreEmpelado, ApeidoEmpleado = @ApeidoEmpleado, Profesion = @Profesion, Puesto = @Puesto";
            conexion.Open();
            SqlCommand update = new SqlCommand(query, conexion);
            update.Parameters.AddWithValue("@IdEmpleado", IdEmpleado.Text);
            update.Parameters.AddWithValue("@NombreEmpelado", NombreEmpelado.Text);
            update.Parameters.AddWithValue("@ApeidoEmpleado", ApeidoEmpleado.Text);
            update.Parameters.AddWithValue("@Profesion", Profesion.Text);
            update.Parameters.AddWithValue("@Puesto", Puesto.Text);
            update.ExecuteNonQuery();

            conexion.Close();
            IdEmpleado.Clear();
            NombreEmpelado.Clear();
            ApeidoEmpleado.Clear();
            Profesion.Clear();
            Puesto.Clear();
            conexion.Close();
           
            MessageBox.Show("Datos actualizados");
        }

        private void BPE_Click(object sender, EventArgs e)
        {
            string baja = "DELETE FROM Personal WHERE IdEmpleado = @IdEmpleado";
            conexion.Open();


            SqlCommand cmdIns = new SqlCommand(baja, conexion);
            cmdIns.Parameters.AddWithValue("@IdEmpleado", IdEmpleado.Text);
            cmdIns.ExecuteNonQuery();

            cmdIns.Dispose();
            cmdIns = null;
            
            IdEmpleado.Clear();
            NombreEmpelado.Clear();
            ApeidoEmpleado.Clear();
            Profesion.Clear();
            Puesto.Clear();
            conexion.Close();

            MessageBox.Show("Empleado Eliminado");
        }

        //FIN PERSONAL

        // VUELO
        private void GV_Click(object sender, EventArgs e)
        {
            // se crea el comando para dar de altas al sistema
            SqlCommand altas = new SqlCommand("insert into Vuelos(idvuelo,fecha,aeroOrigen,Aerodestino) values(@idvuelo,@fecha,@aeroOrigen,@Aerodestino)", conexion);
            // se pasan los valores de los text box a las variables temporales

            altas.Parameters.AddWithValue("@idvuelo", IdVuelo.Text);
            altas.Parameters.AddWithValue("@fecha", Fecha.Text);
            altas.Parameters.AddWithValue("@aeroOrigen", AeroOrigen.Text);
            altas.Parameters.AddWithValue("@Aerodestino", AeroDestino.Text);

            conexion.Open();// se abre la conexion
            altas.ExecuteNonQuery();

            conexion.Close();// se cierra la conexion
            MessageBox.Show("Actualizado");
            // limpiar los textbox
            IdVuelo.Clear();
            Fecha.Clear();
            AeroOrigen.Clear();
            AeroDestino.Clear();
            IdVuelo.Focus();
        }

        private void CV_Click(object sender, EventArgs e)
        {
            SqlCommand consulta = new SqlCommand("SELECT * FROM Vuelos WHERE idvuelo = @idvuelo", conexion);
            conexion.Open();

            consulta.Parameters.AddWithValue("@idvuelo", IdVuelo.Text);

            SqlDataReader reader = consulta.ExecuteReader();
            while (reader.Read())
            {
                IdVuelo.Text = reader[0].ToString();
                Fecha.Text = reader[1].ToString();
                AeroOrigen.Text = reader[2].ToString();
                AeroDestino.Text = reader[3].ToString();

            }
            MessageBox.Show("CONSULTA COMPLETA");
            conexion.Close();
        }

        private void MV_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Vuelos SET idvuelo = @idvuelo, fecha = @fecha, aeroOrigen = @aeroOrigen, Aerodestino = @Aerodestino";
            conexion.Open();
            SqlCommand update = new SqlCommand(query, conexion);
            update.Parameters.AddWithValue("@idvuelo", IdVuelo.Text);
            update.Parameters.AddWithValue("@fecha", Fecha.Text);
            update.Parameters.AddWithValue("@aeroOrigen", AeroOrigen.Text);
            update.Parameters.AddWithValue("@Aerodestino", AeroDestino.Text);
            update.ExecuteNonQuery();

            conexion.Close();
            IdVuelo.Clear();
            Fecha.Clear();
            AeroOrigen.Clear();
            AeroDestino.Clear();
            IdVuelo.Focus();
            
            MessageBox.Show("Datos actualizados");
        }

        private void BV_Click(object sender, EventArgs e)
        {
            string baja = "DELETE FROM Vuelos WHERE idvuelo = @idvuelo";
            conexion.Open();


            SqlCommand cmdIns = new SqlCommand(baja, conexion);
            cmdIns.Parameters.AddWithValue("idvuelo", IdVuelo.Text);
            cmdIns.ExecuteNonQuery();

            cmdIns.Dispose();
            cmdIns = null;

            IdVuelo.Clear();
            Fecha.Clear();
            AeroOrigen.Clear();
            AeroDestino.Clear();
            IdVuelo.Focus();

            conexion.Close();
            MessageBox.Show("socio eliminado");
        }

       
        //FIN VUELO
    }
}
