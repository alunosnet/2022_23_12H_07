using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MOD17_SkinsSite_.Models
{
    public class skin
    {
        public int nskin;
        public string nome;
        public int ano;
        public DateTime data_aquisicao;
        public decimal preco;
        public int quantidade;

        BaseDados bd;

        public skin()
        {
            bd = new BaseDados();
        }

        public int Adicionar()
        {
            string sql = @"INSERT INTO skin(nome,ano,data_aquisicao,preco,quantidade)
                    VALUES (@nome,@ano,@data_aquisicao,@preco,@quantidade);
                    SELECT CAST(SCOPE_IDENTITY() AS INT)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                
                new SqlParameter()
                {
                    ParameterName = "@nome",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Value = this.nome
                },
                new SqlParameter()
                {
                    ParameterName = "@ano",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.ano
                },
                new SqlParameter()
                {
                    ParameterName = "@data_aquisicao",
                    SqlDbType = System.Data.SqlDbType.Date,
                    Value = this.data_aquisicao
                },
                new SqlParameter()
                {
                    ParameterName = "@preco",
                    SqlDbType = System.Data.SqlDbType.Decimal,
                    Value = this.preco
                },
                new SqlParameter()
                {
                    ParameterName = "@quantidade",
                    SqlDbType = System.Data.SqlDbType.Int,
                    Value = this.quantidade
                }
            };
            return bd.executaEDevolveSQL(sql, parametros);
        }
        internal DataTable ListaTodosSkin()
        {
            string sql = @"SELECT nskin,nome,ano,data_aquisicao,
                    preco FROM skin";
            return bd.devolveSQL(sql);
        }
        public DataTable devolveDadosSkin(int nskin)
        {
            string sql = "SELECT * FROM skin WHERE nskin=@nskin";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nskin",SqlDbType=SqlDbType.Int,Value=nskin }
            };
            return bd.devolveSQL(sql, parametros);
        }
        public void removerSkin(int nskin)
        {
            string sql = "DELETE FROM skin WHERE nskin=@nskin";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nskin",SqlDbType=SqlDbType.Int,Value=nskin }
            };
            bd.executaSQL(sql, parametros);
        }
        public void atualizaSkin()
        {
            string sql = "UPDATE skin SET nome=@nome,ano=@ano,data_aquisicao=@data,preco=@preco";
            sql += " WHERE nskin=@nskin;";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nome",SqlDbType=SqlDbType.VarChar,Value= nome},
                new SqlParameter() {ParameterName="@ano",SqlDbType=SqlDbType.Int,Value= ano},
                new SqlParameter() {ParameterName="@data",SqlDbType=SqlDbType.DateTime,Value= data_aquisicao},
                new SqlParameter() {ParameterName="@preco",SqlDbType=SqlDbType.Decimal,Value= preco},
                new SqlParameter() {ParameterName="@nskin",SqlDbType=SqlDbType.Int,Value=nskin}
            };
            bd.executaSQL(sql, parametros);
        }
        public DataTable listarskinDisponiveis(int? ordena = null)
        {
            string sql = "SELECT * FROM skin ";
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco";
            }
            return bd.devolveSQL(sql);
        }

        internal DataTable listaSkinDoAutor(string pesquisa)
        {
            string sql = "SELECT * FROM skin ";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {
                    ParameterName ="@nome",
                    SqlDbType =SqlDbType.VarChar,
                    Value = "%"+pesquisa+"%"},
            };
            return bd.devolveSQL(sql, parametros);
        }
        internal DataTable listaSkinDisponiveis(string pesquisa, int? ordena = null)
        {
            string sql = "SELECT * FROM skin WHERE nome like @nome";
            if (ordena != null && ordena == 1)
            {
                sql += " order by preco";
            }

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {
                    ParameterName ="@nome",
                    SqlDbType =SqlDbType.VarChar,
                    Value = "%"+pesquisa+"%"},
            };
            return bd.devolveSQL(sql, parametros);
        }
    }
}
