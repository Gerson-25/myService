using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{

    string strConex = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
    string Patron = ConfigurationManager.AppSettings["Patron"].ToString();
    DataSet ds = new DataSet();
    SqlDataAdapter da;

	public DataSet ValidarUsuario(string Login, string Password)
	{

        try
        {
            //Se configura el DataAdapter con el objeto a ejecutar y la conexiòn
            da = new SqlDataAdapter("SP_ValidarUsuario", strConex);
            //El objeto a ejecutar se indica que es un Stored Procedure
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //Se envìan los paràmetros que el SP está esperando
            da.SelectCommand.Parameters.Add("@Login", SqlDbType.VarChar).Value = Login;
            da.SelectCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
            da.SelectCommand.Parameters.Add("@Patron", SqlDbType.VarChar).Value = Patron;
            //Se ejecuta el SP y se llena el DataSet con la informaciòn devuelta
            da.Fill(ds, "ValidarUsuario");
            //Se devuelve el DataSet al proceso que lo invocò
            return ds;
        }
        catch(Exception ex)
        {
            return null;
        }
	}

    public DataSet AgregarUsuario(string Nombre, string Login, string Password, bool Estado, string Email, int Privilegio)
    {
        try
        {
            da = new SqlDataAdapter("SP_AgregarUsuario", strConex);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
            da.SelectCommand.Parameters.Add("@Login", SqlDbType.VarChar).Value = Login;
            da.SelectCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
            da.SelectCommand.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
            da.SelectCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
            da.SelectCommand.Parameters.Add("@Privilegio", SqlDbType.Int).Value = Privilegio;
            da.SelectCommand.Parameters.Add("@Patron", SqlDbType.VarChar).Value = Patron;
            da.Fill(ds, "UsuarioNuevo");
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public DataSet BuscarUsuario(int IdUsuario, string Nombre, string Login)
    {
        try
        {
            da = new SqlDataAdapter("SP_BuscarUsuario", strConex);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
            da.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
            da.SelectCommand.Parameters.Add("@Login", SqlDbType.VarChar).Value = Login;
            da.Fill(ds, "BusquedaUsuario");
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataSet ModificarUsuario(int IdUsuario, string Nombre, string Login, string Password, bool Estado, string Email, int Privilegio)
    {
        try
        {
            da = new SqlDataAdapter("SP_ModificarUsuario", strConex);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
            da.SelectCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Nombre;
            da.SelectCommand.Parameters.Add("@Login", SqlDbType.VarChar).Value = Login;
            da.SelectCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = Password;
            da.SelectCommand.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
            da.SelectCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
            da.SelectCommand.Parameters.Add("@Privilegio", SqlDbType.Int).Value = Privilegio;
            da.SelectCommand.Parameters.Add("@Patron", SqlDbType.VarChar).Value = Patron;
            da.Fill(ds, "ModificaUsuario");
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataSet EliminarUsuario(int IdUsuario)
    {
        try
        {
            da = new SqlDataAdapter("SP_EliminarUsuario", strConex);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = IdUsuario;
            da.Fill(ds, "EliminarUsuario");
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataSet AgregarProveedor(string Empresa, string Contacto, string Telefono, string Direccion, string PaginaWeb, string Email, string Registro, string Nit, string RazonSocial, bool Estado)
    {
        try
        {
            da = new SqlDataAdapter("SP_AgregarProveedor", strConex);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Empresa", SqlDbType.VarChar).Value = Empresa;
            da.SelectCommand.Parameters.Add("@Contacto", SqlDbType.VarChar).Value = Contacto;
            da.SelectCommand.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
            da.SelectCommand.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Direccion;
            da.SelectCommand.Parameters.Add("@PaginaWeb", SqlDbType.VarChar).Value = PaginaWeb;
            da.SelectCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
            da.SelectCommand.Parameters.Add("@Registro", SqlDbType.VarChar).Value = Registro;
            da.SelectCommand.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
            da.SelectCommand.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial;
            da.SelectCommand.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
            //da.SelectCommand.Parameters.Add("@Mensaje", SqlDbType.Int).Value = 0;
            da.Fill(ds, "ProveedorNuevo");
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataSet BuscarProveedor(int IdProveedor, string Empresa)
    {
        try
        {
            da = new SqlDataAdapter("SP_BuscarProveedor", strConex);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor;
            da.SelectCommand.Parameters.Add("@Empresa", SqlDbType.VarChar).Value = Empresa;
            da.Fill(ds, "BusquedaProveedor");
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataSet ModificarProveedor(int IdProveedor, string Empresa, string Contacto, string Telefono, string Direccion, string PaginaWeb, string Email, string Registro, string Nit, string RazonSocial, bool Estado)
    {
        try
        {
            da = new SqlDataAdapter("SP_ModificarProveedor", strConex);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = IdProveedor;
            da.SelectCommand.Parameters.Add("@Empresa", SqlDbType.VarChar).Value = Empresa;
            da.SelectCommand.Parameters.Add("@Contacto", SqlDbType.VarChar).Value = Contacto;
            da.SelectCommand.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = Telefono;
            da.SelectCommand.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = Direccion;
            da.SelectCommand.Parameters.Add("@PaginaWeb", SqlDbType.VarChar).Value = PaginaWeb;
            da.SelectCommand.Parameters.Add("@Email", SqlDbType.VarChar).Value = Email;
            da.SelectCommand.Parameters.Add("@Registro", SqlDbType.VarChar).Value = Registro;
            da.SelectCommand.Parameters.Add("@Nit", SqlDbType.VarChar).Value = Nit;
            da.SelectCommand.Parameters.Add("@RazonSocial", SqlDbType.VarChar).Value = RazonSocial;
            da.SelectCommand.Parameters.Add("@Estado", SqlDbType.Bit).Value = Estado;
            //da.SelectCommand.Parameters.Add("@Mensaje", SqlDbType.Int).Value = 0;
            da.Fill(ds, "ProveedorModificado");
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public DataSet ListarPrivilegios()
    {
        try
        {
            da = new SqlDataAdapter("SP_ListarPrivilegios", strConex);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.Fill(ds, "Privilegios");
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}//Fin de la clase
