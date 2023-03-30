using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MOD17_SkinsSite_.Models
{
    public class utilizador 
    {
        public string perfil;
        public int nutilizador;
        public string nome;
        public string nick;
        public string password;
        public string email;

        BaseDados bd;

        public utilizador()
        {
            bd = new BaseDados();
        }

        //adicionar
        public void Adicionar()
        {
            string sql = @"INSERT INTO utilizador(nome,nick,email,perfil,password)
                            VALUES (@nome,@nick,@email,@perfil,HASHBYTES('SHA2_512',@password))";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@nick",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.nick
                },
                new SqlParameter()
                {
                    ParameterName="@password",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.password
                },
                new SqlParameter()
                {
                    ParameterName="@email",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.email
                },
                new SqlParameter()
                {
                    ParameterName="@perfil",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.perfil
                },
            };
            bd.executaSQL(sql, parametros);
        }
        internal DataTable ListaTodosUtilizadores()
        {
            return bd.devolveSQL("SELECT * FROM Utilizador");
        }
        public DataTable listaTodosUtilizadoresDisponiveis()
        {
            string sql = $@"SELECT nutilizador, email,nome, nick, perfil 
            FROM utilizador ";
            return bd.devolveSQL(sql);
        }

        public void atualizarUtilizador()
        {
            string sql = @"UPDATE utilizador SET nome=@nome,nick=@nick 
                            WHERE nutilizador=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value=nome },
                new SqlParameter() {ParameterName="@nick",SqlDbType=SqlDbType.VarChar,Value=nick },
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=nutilizador },
            };
            bd.executaSQL(sql, parametros);
        }
        public DataTable devolveDadosUtilizador(int id)
        {
            string sql = "SELECT * FROM utilizador WHERE nutilizador=@nutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nutilizador",SqlDbType=SqlDbType.Int,Value=id }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            if (dados.Rows.Count == 0)
            {
                return null;
            }
            return dados;
        }
        //public int estadoUtilizador(int id)
        //{
            //string sql = "SELECT FROM utilizador WHERE id=@id";
            //List<SqlParameter> parametros = new List<SqlParameter>()
            //{
                //new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            //};
            //DataTable dados = bd.devolveSQL(sql, parametros);
            //return int.Parse(dados.Rows[0][0].ToString());
        //}
        public void ativarDesativarUtilizador(int id)
        {
            string sql = "UPDATE utilizador WHERE id=@id";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value=id }
            };
            bd.executaSQL(sql, parametros);
        }
        public void removerUtilizador(int id)
        {
            string sql = "DELETE FROM Utilizador WHERE id=@id";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@id",SqlDbType=SqlDbType.Int,Value= id},
            };
            bd.executaSQL(sql, parametros);
        }
        public void recuperarPassword(string email, string guid)
        {
            string sql = "UPDATE utilizador set lnkRecuperar=@lnk WHERE email=@email";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email },
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }
        public void atualizarPassword(string guid, string password)
        {
            string sql = "UPDATE utilizador set password=HASHBYTES('SHA2_512',concat(@password),lnkRecuperar=null WHERE lnkRecuperar=@lnk";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@password",SqlDbType=SqlDbType.VarChar,Value=password},
                new SqlParameter() {ParameterName="@lnk",SqlDbType=SqlDbType.VarChar,Value=guid },
            };
            bd.executaSQL(sql, parametros);
        }
        public DataTable devolveDadosUtilizador(string email)
        {
            string sql = "SELECT * FROM utilizador WHERE email=@email";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@email",SqlDbType=SqlDbType.VarChar,Value=email }
            };
            DataTable dados = bd.devolveSQL(sql, parametros);
            return dados;
        }
    }
}