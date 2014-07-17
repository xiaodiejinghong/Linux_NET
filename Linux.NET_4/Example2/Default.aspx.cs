using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["postgres"].ToString();
    }

    protected void Select(object sender, EventArgs e)
    {
        DataTable dt = NpgsqlTool.Query("SELECT * FROM person");
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Response.Write(dt.Rows[i][0].ToString() + "--" + dt.Rows[i][1].ToString() + "--" + dt.Rows[i][2].ToString() + "--" + dt.Rows[i][3].ToString() + "<br/>");
        }
    }

    protected void Insert(object sender, EventArgs e)
    {
        NpgsqlTool.Execute("INSERT INTO person(name,age,sex) VALUES ('小明明',8,'男')");
    }

    protected void Update(object sender, EventArgs e)
    {
        NpgsqlTool.Execute("UPDATE person SET name='小小明',age=10 WHERE name='小明明'");
    }

    protected void Delete(object sender, EventArgs e)
    {
        NpgsqlTool.Execute("DELETE FROM person WHERE name='小小明'");
    }


}