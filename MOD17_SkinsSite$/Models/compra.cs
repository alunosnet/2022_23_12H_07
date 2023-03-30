using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MOD17_SkinsSite_.Models
{
    public class compra
    {
        BaseDados bd;

        public compra()
        {
            this.bd = new BaseDados();
        }
        public void adicionarCompra(int nskin, int nutilizador, DateTime data_aquisicao)
        {
            string sql = "SELECT * FROM skin WHERE nskin=@nskin";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nskin",SqlDbType=SqlDbType.Int,Value=nskin }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                //registar compra
                sql = @"INSERT INTO compra(nskin,nutilizador,data_compra) 
                            VALUES (@nskin,@nutilizador,@data_compra)";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@nskin",SqlDbType=SqlDbType.Int,Value=nskin },
                    new SqlParameter() {ParameterName="@nutilizador",SqlDbType=SqlDbType.Int,Value=nutilizador },
                    new SqlParameter() {ParameterName="@data_compra",SqlDbType=SqlDbType.Date,Value=DateTime.Now.Date},
                };
                bd.executaSQL(sql, parametrosInsert, transacao);
                //concluir transação
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
            }
            dados.Dispose();
        }
        public void adicionarReserva(int nskin, int nutilizador, DateTime data_aquisicao)
        {
            string sql = "SELECT * FROM skin WHERE nskin=@nskin";
            List<SqlParameter> parametrosBloquear = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nskin",SqlDbType=SqlDbType.Int,Value=nskin }
            };
            //iniciar transação
            SqlTransaction transacao = bd.iniciarTransacao(IsolationLevel.Serializable);
            DataTable dados = bd.devolveSQL(sql, parametrosBloquear, transacao);

            try
            {
                List<SqlParameter> parametrosUpdate = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@nskin",SqlDbType=SqlDbType.Int,Value=nskin },
                };
                bd.executaSQL(sql, parametrosUpdate, transacao);
                //registar empréstimo
                sql = @"INSERT INTO compra(nskin,nutilizador,data_compra) 
                            VALUES (@nskin,@nutilizador,@data_compra)";
                List<SqlParameter> parametrosInsert = new List<SqlParameter>()
                {
                    new SqlParameter() {ParameterName="@nskin",SqlDbType=SqlDbType.Int,Value=nskin },
                    new SqlParameter() {ParameterName="@nutilizador",SqlDbType=SqlDbType.Int,Value=nutilizador },
                    new SqlParameter() {ParameterName="@data_compra",SqlDbType=SqlDbType.Date,Value=DateTime.Now.Date},
                };
                bd.executaSQL(sql, parametrosInsert, transacao);
                //concluir transação
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
            }
            dados.Dispose();
        }
        public DataTable listaTodasCompraComNomes(int nskin)
        {
            string sql = @"SELECT *
                        FROM compra Where nutilizador=@nutilizador";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@nutilizador",SqlDbType=SqlDbType.Int,Value=nskin }
            };
            return bd.devolveSQL(sql, parametros);
        }

        public DataTable listaTodasCompraComNomes()
        {
            string sql = @"SELECT ncompra,skin.nome as nomeSkin,utilizador.nome as nomeUtilizador,data_compra,compra
                        FROM compra inner join skin on compra.nskin=skins.nskin
                        inner join utilizador on compra.nutiliador=utilizador.id";
            return bd.devolveSQL(sql);
        }
        public DataTable listaTodasComprasPorConcluirComNomes()
        {
            string sql = @"SELECT ncompra,skin.nome as nomeSkin,utilizador.nome as nomeUtilizador,data_compra
                        FROM compra inner join skin on compra.nskin=skin.nskin
                        inner join utilizador on compra.nutilizador=utilizador.nutilizador";
            return bd.devolveSQL(sql);
        }

        public DataTable devolveDadosCompra(int ncompra)
        {
            string sql = "SELECT * FROM skin WHERE ncompra=@ncompra";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName="@ncompra",SqlDbType=SqlDbType.Int,Value=ncompra }
            };
            return bd.devolveSQL(sql, parametros);
        }
    }
}