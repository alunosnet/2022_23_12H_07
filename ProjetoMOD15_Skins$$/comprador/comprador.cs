using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoSkins15
{
    public class jogador
    {
        public int njogador { get; set; }
        public string nome { get; set; }
        public string nick { get; set; }
        public jogador()
        { }
        public jogador(int njogador, string nome, string nick)
        {
            this.njogador = njogador;
            this.nome = nome;
            this.nick = nick;
        }

        public void Guardar(BaseDados bd)
        {
            string sql = @"INSERT INTO jogadores(nome,nick) VALUES 
                        (@nome,@nick)";
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

            };
            bd.ExecutaSQL(sql, parametros);
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * From jogadores";
            return bd.DevolveSQL(sql);
        }

        public void ProcurarPorNrJogador(BaseDados bd, int nleitor)
        {
            string sql = "SELECT * FROM jogadores WHERE njogador=" + nleitor;
            DataTable dados = bd.DevolveSQL(sql);
            if (dados != null && dados.Rows.Count > 0)
            {
                this.njogador = int.Parse(dados.Rows[0]["njogador"].ToString());
                this.nome = dados.Rows[0]["nome"].ToString();
                this.nick = dados.Rows[0]["nick"].ToString();
            }
        }

        internal static void Apagar(BaseDados bd, int nleitor_escolhido)
        {
            string sql = "DELETE FROM jogadores WHERE njogador=" + nleitor_escolhido;
            bd.ExecutaSQL(sql);
        }

        internal void Atualizar(BaseDados bd)
        {
            string sql = @"UPDATE jogadores SET nome=@nome,nick=@nick ";
            
            sql += " WHERE njogador=@njogador";

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
                    Value=this.nome
                },
                new SqlParameter()
                {
                    ParameterName="@njogador",
                    SqlDbType=SqlDbType.Int,
                    Value=this.njogador
                }
            };
            
            bd.ExecutaSQL(sql, parametros);
        }

        public override string ToString()
        {
            return this.nome;
        }

        public static bool Jcomprador(BaseDados bd, int njogador)
        {

            string sql = $@"select * from compra where njogador = @njogador";
            //parametros
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@njogador",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=njogador
                },
            };
            //executar
            var dados = bd.DevolveSQL(sql, parametros);
            if (dados != null && dados.Rows.Count == 0)
                return false;
            else
                return true;
        }


    }
}
