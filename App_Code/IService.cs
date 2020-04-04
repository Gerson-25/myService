using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{

	[OperationContract]
	DataSet ValidarUsuario(string Login, string Password);

    [OperationContract]
    DataSet AgregarUsuario(string Nombre, string Login, string Password, bool Estado, string Email, int Privilegio);

    [OperationContract]
    DataSet BuscarUsuario(int IdUsuario, string Nombre, string Login);

    [OperationContract]
    DataSet ModificarUsuario(int IdUsuario, string Nombre, string Login, string Password, bool Estado, string Email, int Privilegio);

    [OperationContract]
    DataSet EliminarUsuario(int IdUsuario);

    [OperationContract]
    DataSet AgregarProveedor(string Empresa, string Contacto, string Telefono, string Direccion, string PaginaWeb, string Email, string Registro, string Nit, string RazonSocial, bool Estado);

    [OperationContract]
    DataSet BuscarProveedor(int IdProveedor, string Empresa);

    [OperationContract]
    DataSet ModificarProveedor(int IdProveedor, string Empresa, string Contacto, string Telefono, string Direccion, string PaginaWeb, string Email, string Registro, string Nit, string RazonSocial, bool Estado);

    [OperationContract]
    DataSet ListarPrivilegios();
}
