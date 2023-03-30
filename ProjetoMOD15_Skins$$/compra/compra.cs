using projetoSkins15;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoSkins15.compra
{
    public class compra
    {
        public string nskin_escolhido;
        public int ncompra;
        public int nskin;
        public int njogador;
        public DateTime data_compra;
        public compra() { }
        public compra(int njogador, int nskin, DateTime data_compra)
        {
            this.njogador = njogador;
            this.nskin = nskin;
            this.data_compra = data_compra;
        }
        public void Adicionar(BaseDados bd)
        {
            //sql com insert
            string sql = $@"insert into compra(nskin,njogador,
                            data_compra) values 
                            (@nskin,@njogador,getdate()
                                )";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nskin",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.nskin
                },
                new SqlParameter()
                {
                    ParameterName="@njogador",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.njogador
                },
                new SqlParameter()
                {
                    ParameterName="@data_compra",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.data_compra
                },
            };
            //executar
            bd.ExecutaSQL(sql, parametros);
        }


        public static bool skinVendida(BaseDados bd, int nskin)
        {

            string sql = $@"select * from compra where nskin = @nskin";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nskin",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=nskin
                },
            };
            //executar
            var dados = bd.DevolveSQL(sql, parametros);
            if (dados != null && dados.Rows.Count==0)
                return false;
            else 
                return true;
        }
        public static DataTable ListarTodos(BaseDados bd)
        {

            string sql = "SELECT * FROM compra ";
            return bd.DevolveSQL(sql);
        }

        public void Atualizar(BaseDados bd)
        {
            string sql = @"UPDATE compra SET data_compra=@data_compra, nskin=@nskin, njogador=@njogador
                            where ncompra=@ncompra";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nskin",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.nskin
                },
                new SqlParameter()
                {
                    ParameterName="@njogador",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.njogador
                },
                new SqlParameter()
                {
                    ParameterName="@data_compra",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.data_compra
                },
                new SqlParameter()
                {
                    ParameterName="@ncompra",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.ncompra
                },

            };

            bd.ExecutaSQL(sql, parametros);
        }
    }
}
