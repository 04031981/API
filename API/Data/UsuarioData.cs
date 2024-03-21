using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using API.Data;
using API.Models;

public class UsuarioData
{
    public static bool Registrar(Usuario oUsuario)
    {
        using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
        {
            SqlCommand cmd = new SqlCommand("API_registrar", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombres", oUsuario.Nombres);
            cmd.Parameters.AddWithValue("@apellido", oUsuario.Apellido);
            cmd.Parameters.AddWithValue("@dni", oUsuario.DNI);
            cmd.Parameters.AddWithValue("@correo", oUsuario.Correo);

            try
            {
                oConexion.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                return false;
            }
        }
    }
    public static bool Modificar(Usuario oUsuario)
    {
        using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
        {
            SqlCommand cmd = new SqlCommand("API_modificar", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idusuario", oUsuario.IdUsuario);
            cmd.Parameters.AddWithValue("@nombres", oUsuario.Nombres);
            cmd.Parameters.AddWithValue("@apellido", oUsuario.Apellido);
            cmd.Parameters.AddWithValue("@dni", oUsuario.DNI);
            cmd.Parameters.AddWithValue("@correo", oUsuario.Correo);

            try
            {
                oConexion.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                return false;
            }
        }
    }
    public static List<Usuario> Listar()
    {
        List<Usuario> oListaUsuario = new List<Usuario>();
        using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
        {
            SqlCommand cmd = new SqlCommand("API_listar", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        usuario.Nombres = dr["Nombres"].ToString();
                        usuario.Apellido = dr["Apellido"].ToString();
                        usuario.DNI = dr["DNI"].ToString();
                        usuario.Correo = dr["Correo"].ToString();
                        oListaUsuario.Add(usuario);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepción
            }
        }
        return oListaUsuario;
    }
    public static Usuario Obtener(int idusuario)
    {
        Usuario oUsuario = null;
        using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
        {
            SqlCommand cmd = new SqlCommand("API_obtener", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idusuario", idusuario);

            try
            {
                oConexion.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        oUsuario = new Usuario();
                        oUsuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        oUsuario.Nombres = dr["Nombres"].ToString();
                        oUsuario.Apellido = dr["Apellido"].ToString();
                        oUsuario.DNI = dr["DNI"].ToString();
                        oUsuario.Correo = dr["Correo"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepción
            }
        }
        return oUsuario;
    }
    public static bool Eliminar(int id)
    {
        using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
        {
            SqlCommand cmd = new SqlCommand("API_eliminar", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idusuario", id);

            try
            {
                oConexion.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                // Manejo de excepción
                return false;
            }
        }
    }
}
