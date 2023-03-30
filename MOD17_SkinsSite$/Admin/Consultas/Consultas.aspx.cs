using MOD17_SkinsSite_.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_.Admin.Consultas
{
    public partial class Consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
                Response.Redirect("~/index.aspx");

            AtualizaGrelhaConsulta();
        }
        private void AtualizaGrelhaConsulta()
        {
            gvConsultas.Columns.Clear();
            int idconsulta = int.Parse(ddConsultas.SelectedValue);
            DataTable dados;
            string sql = "";
            switch (idconsulta)
            {
                //Top de skisn mais adquiridas
                case 0:
                    sql = @"SELECT Nome,count(compra.nskin) as [Nº de compras] FROM skin 
                            INNER JOIN compra ON skin.nskin=compra.nskin 
                            GROUP BY skin.nskin,skin.Nome
                            ORDER BY count(compra.nskin) DESC";
                    break;
                //Top de jogadores
                case 1:
                    sql = @"SELECT Nome,count(compra.nutilizador) as [Nº de compra] FROM utilizador 
                            INNER JOIN compra ON utilizador.nutilizador=compra.nutilizador 
                            GROUP BY utilizador.nutilizador,utilizador.Nome
                            ORDER BY count(compra.nutilizador) DESC";
                    break;
                //Top de skins mais adquiridas do último mês
                case 2:
                    sql = @"SELECT TOP 3 nome AS [skin], COUNT(compra.nskin) AS [Nº de Aquisiçãoes] 
                            FROM skin, compra
                            WHERE skin.nskin = compra.nskin 
                                AND DATEDIFF(DAY, compra.data_compra, GETDATE()) < 30
                            GROUP BY skin.nskin,skin.nome
                            ORDER BY COUNT(compra.nskin) DESC";
                    break;
                //Skins da última semana - novidades 
                case 4:
                    sql = @"SELECT nome
                            FROM skin
                            WHERE DATEDIFF(DAY,data_aquisicao,GETDATE()) <= 7";
                    break;
                //Nº de utilizador bloqueados
                case 7:
                    sql = @"SELECT count(*) as [Nº de utilizador bloqueados] 
                            FROM utilizador
                            WHERE estado = 0";
                    break;
                //Nº de tipos de skin por utilizador
                case 8:
                    sql = @"SELECT utilizador.nome, skin.tipo, count(*) as [Nº de compra] 
                            FROM utilizador
                            INNER JOIN compra on utilizador.nutilizador=compra.nutilizador
                            INNER JOIN compra on compra.nskin=skin.nskin
                            GROUP BY utilizador.nutilizador,utilizador.nome,skin.tipo
                            ORDER BY utilizador.nutilizador";
                    break;
                //Nº de compras por mês
                case 9:
                    sql = @"SELECT MONTH(data_compra) as [Mês],Count(ncompra) as [Nº de compra] 
                            FROM compra
                            GROUP BY MONTH(data_compra)";
                    break;
                //Lista dos utilizador que adquiriram a skin mais caro
                case 10:
                    sql = @"SELECT DISTINCT utilizador.nome 
                            FROM utilizador
                            INNER JOIN compra on compra.nutilizador = utilizador.nutilizador
                            WHERE compra.nskin = (SELECT TOP 1 skin.nskin FROM skin ORDER BY preco DESC)";
                    break;
                //Lista das skisn cujo preço é superior à média
                case 11:
                    sql = @"SELECT * FROM skin WHERE preco>(SELECT AVG(preco) FROM skin)";
                    break;
                //11- Lista dos utilizador com a mesma password
                case 12:
                    sql = @"SELECT Nome, 
                                (SELECT count(*) FROM Utilizador as UT WHERE U.password=UT.password)
                            as [Nº de utilizador com a mesma password]
                            FROM utilizador as U";
                    break;
            }
            BaseDados bd = new BaseDados();
            dados = bd.devolveSQL(sql);
            gvConsultas.DataSource = dados;
            gvConsultas.DataBind();
        }

        protected void ddConsultas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}