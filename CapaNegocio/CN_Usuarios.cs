using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Usuarios
    {

        //Instanciamos el dbml
        private static DataClassesECU911DataContext dc = new DataClassesECU911DataContext();
        //metodo para verificar credenciales
        public static bool autentificarUsuarioPassword(string usuario, string pass)
        {
            var auto = dc.Tbl_Person.Any(per => per.Per_nomlogin.Equals(usuario) && per.Per_pass.Equals(pass) && (per.Per_estado == "AA" || per.Per_estado == "AM" || per.Per_estado == "AS" || per.Per_estado == "AP"));
            return auto;
        }        
        //metodo para verificar si existe el usuario
        public static Tbl_Person obtenerUsuariosxCedula(string cedula)
        {
            var usuced = dc.Tbl_Person.FirstOrDefault(per => per.Per_cedula.Equals(cedula) && per.Per_estado == "AP");
            return usuced;
        }
        //metodo para verificar si existe el nombre
        public static bool autentificarxCedula(int cedula)
        {
            var auto = dc.Tbl_Person.Any(per => per.Per_estado == "AP" && per.Per_cedula.Equals(cedula));
            return auto;
        }
        //metodo para verificar si existe el nombre de usuario
        public static Tbl_Person obtenerUsuariosxNomUsuario(string usuario)
        {
            var usunom = dc.Tbl_Person.FirstOrDefault(per => per.Per_nomlogin.Equals(usuario) && per.Per_estado == "AP");
            return usunom;
        }
        //metodo para verificar si existe el nombre
        public static bool autentificarxNomUsuario(string usuario)
        {
            var auto = dc.Tbl_Person.Any(per => per.Per_estado == "AP" && per.Per_nomlogin.Equals(usuario));
            return auto;
        }
        //metodo para verificar si existe el nombre medico
        public static bool autentificarxUsuario(string usuario)
        {
            var auto = dc.Tbl_Person.Any(per => per.Per_nomlogin.Equals(usuario) && (per.Per_estado == "AA" || per.Per_estado == "AM" || per.Per_estado == "AS" || per.Per_estado == "AP"));
            return auto;
        }        
        //metodo para traer los objetos de Usuario
        public static Tbl_Person autentificarxUnicoUsuPass(string person, string pass)
        {
            var nlogin = dc.Tbl_Person.Single(per => per.Per_nomlogin.Equals(person) && per.Per_pass.Equals(pass) && (per.Per_estado == "AA" || per.Per_estado == "AM" || per.Per_estado == "AS" || per.Per_estado == "AP"));
            return nlogin;
        }
        //metodo para obtener los usuarios por su id
        public static Tbl_Person obtenerUsuariosxId(int id)
        {
            var perid = dc.Tbl_Person.FirstOrDefault(per => per.Per_id.Equals(id) && (per.Per_estado == "AA" || per.Per_estado == "AM" || per.Per_estado == "AS" || per.Per_estado == "AP"));
            return perid;
        }
        //Metodo para obtener contraseña anterior para medicos 
        public static bool autentificarxUsuario(int per, string pass)
        {
            var perso = dc.Tbl_Person.Any(usup => (usup.Per_estado == "AA" || usup.Per_estado == "AM" || usup.Per_estado == "AS" || usup.Per_estado == "AP") && usup.Per_id.Equals(per) && usup.Per_pass.Equals(pass));
            return perso;
        }
        //metodo para obtener los usuarios por su id para social
        public static Tbl_Person obtenerUsuariosxIdSocial(int id)
        {
            var perid = dc.Tbl_Person.FirstOrDefault(per => per.Per_id.Equals(id) && per.Per_estado == "AS");
            return perid;
        }
        //Metodo para obtener contraseña anterior para social
        public static bool autentificarxUsuarioSocial(int per, string pass)
        {
            var perso = dc.Tbl_Person.Any(usup => usup.Per_estado == "AS" && usup.Per_id.Equals(per) && usup.Per_pass.Equals(pass));
            return perso;
        }
        //metodo para obtener los usuarios por su id para paciente
        public static Tbl_Person obtenerUsuariosxIdPaciente(int id)
        {
            var perid = dc.Tbl_Person.FirstOrDefault(per => per.Per_id.Equals(id) && per.Per_estado == "AP");
            return perid;
        }
        //Metodo para obtener contraseña anterior para paciente
        public static bool autentificarxUsuarioPaciente(int per, string pass)
        {
            var perso = dc.Tbl_Person.Any(usup => usup.Per_estado == "AP" && usup.Per_id.Equals(per) && usup.Per_pass.Equals(pass));
            return perso;
        }
        //metodo para verificar si existe el correo
        public static bool autentificarxCorreo(string correo)
        {
            var auto = dc.Tbl_Person.Any(per => (per.Per_estado == "AA" || per.Per_estado == "AM" || per.Per_estado == "AS" || per.Per_estado == "AP") && per.Per_correo == (correo));
            return auto;
        }

        //metodo para obtener el correo
        //public static Tbl_Person obtenerCorreo(string correo)
        //{
        //    var contra = dc.Tbl_Person.Single(per => (per.Per_estado == "AA" || per.Per_estado == "AM" || per.Per_estado == "AS" || per.Per_estado == "AP") && per.Per_correo.Equals(correo));
        //    return contra;
        //}

        public static Tbl_Person obtenerCorreo(string correo)
        {
            var perid = dc.Tbl_Person.FirstOrDefault(per => (per.Per_estado == "AA" || per.Per_estado == "AM" || per.Per_estado == "AS" || per.Per_estado == "AP") && per.Per_correo == (correo));
            return perid;
        }


        public static void GuardarUsuario(Tbl_Person usu)
        {
            try
            {
                dc.Tbl_Person.InsertOnSubmit(usu);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido guardados <br/>" + ex.Message);
            }
        }
        public static void ModificarUsuarios(Tbl_Person usu)
        {
            try
            {
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los datos no han sido modificados <br/>" + ex.Message);
            }
        }
        //public static void delete(Tbl_Usuarios usu)
        //{
        //    try
        //    {
        //        usu.usu_estado = "I";
        //        dc.SubmitChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException("Los datos no han sido eliminados <br/>" + ex.Message);
        //    }
        //}
        //public static void change(Tbl_Usuarios usu)
        //{
        //    try
        //    {
        //        dc.SubmitChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException("Los datos no han sido modificados <br/>" + ex.Message);
        //    }
        //}

    }
}
