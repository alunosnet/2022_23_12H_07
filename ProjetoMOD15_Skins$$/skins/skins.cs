using projetoSkins15;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoSkins15
{
    public class skin
    {
        public int NSkin { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }
        public DateTime Data_compra { get; set; }
        public Decimal Preco { get; set; }
        public string Capa { get; set; }

        public void Guardar(BaseDados bd)
        {
            string sql = @"INSERT INTO skin(nome,ano,data_aquisicao,preco) VALUES 
                            (@nome,@ano,@data_aquisicao,@preco)";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Nome
                },
                new SqlParameter()
                {
                    ParameterName="@ano",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.Ano
                },
                new SqlParameter()
                {
                    ParameterName="@data_aquisicao",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.Data_compra.Date
                },
                new SqlParameter()
                {
                    ParameterName="@preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.Preco
                },
            };
            bd.ExecutaSQL(sql, parametros);
        }

        public static DataTable ListarTodos(BaseDados bd)
        {
            string sql = "SELECT * FROM skin";
            return bd.DevolveSQL(sql);
        }

        public DataTable Procurar(int nskin, BaseDados bd)
        {
            string sql = "SELECT * FROM skin WHERE nskin=" + nskin;
            DataTable temp = bd.DevolveSQL(sql);

            if (temp != null && temp.Rows.Count > 0)
            {
                this.NSkin= int.Parse(temp.Rows[0]["nskin"].ToString());
                this.Nome = temp.Rows[0]["nome"].ToString();
                this.Ano = int.Parse(temp.Rows[0]["ano"].ToString());
                this.Data_compra = DateTime.Parse(temp.Rows[0]["data_aquisicao"].ToString());
                this.Preco = Decimal.Parse(temp.Rows[0]["preco"].ToString());
                this.Capa = temp.Rows[0]["capa"].ToString();
            }

            return temp;
        }

        public static void ApagarSkin(int NSkin, BaseDados bd)
        {
            string sql = "DELETE FROM skin WHERE nskin=" + NSkin;
            bd.ExecutaSQL(sql);
        }

        public void Atualizar(BaseDados bd)
        {
            string sql = @"UPDATE skin SET nome=@nome,ano=@ano,data_aquisicao=@data_aquisicao,
                                preco=@preco
                                WHERE nskin=@nskin";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value=this.Nome
                },
                new SqlParameter()
                {
                    ParameterName="@ano",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.Ano
                },
                new SqlParameter()
                {
                    ParameterName="@data_aquisicao",
                    SqlDbType=System.Data.SqlDbType.Date,
                    Value=this.Data_compra.Date
                },
                new SqlParameter()
                {
                    ParameterName="@preco",
                    SqlDbType=System.Data.SqlDbType.Decimal,
                    Value=this.Preco
                },
                new SqlParameter()
                {
                    ParameterName="@nskin",
                    SqlDbType=System.Data.SqlDbType.Int,
                    Value=this.NSkin
                }
            };
            bd.ExecutaSQL(sql, parametros);
        }

        public static DataTable PesquisaPorNome(BaseDados bd, string nome)
        {
            string sql = @"SELECT * FROM skin WHERE nome LIKE @nome";
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName="@nome",
                    SqlDbType=System.Data.SqlDbType.VarChar,
                    Value="%"+nome+"%"
                },
            };
            return bd.DevolveSQL(sql, parametros);
        }
        public static int NrRegistos(BaseDados bd)
        {
            string sql = "SELECT count(*) as NrRegistos from skin";
            DataTable dados = bd.DevolveSQL(sql);
            int nr = int.Parse(dados.Rows[0][0].ToString());
            dados.Dispose();
            return nr;
        }

        public static DataTable ListarTodos(BaseDados bd, int primeiroregisto, int ultimoregisto)
        {
            string sql = $@"SELECT nskin,nome,ano,data_compra,Preco,FROM
                        (SELECT row_number() over (order by nskin) as Num,* FROM skin) as T
                        WHERE Num>={primeiroregisto} AND Num<={ultimoregisto}";
            return bd.DevolveSQL(sql);
        }

        public override string ToString()
        {
            return this.Nome;
        }

        public static DataTable ListarDisponiveis(BaseDados bd)
        {

            string sql = "SELECT * FROM skin ";
            return bd.DevolveSQL(sql);
        }
        public static DataTable ListarCompras(BaseDados bd)
        {

            string sql = "SELECT * FROM skin ";
            return bd.DevolveSQL(sql);
        }
    }
}
