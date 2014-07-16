using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Select(object sender, EventArgs e)
    {
        var context = new PetaPoco.Database("postgres");

        var res = context.Query<Person>("SELECT id,name,age,sex FROM person");

        foreach (var p in res)
        {
            Response.Write(p.ID + "--" + p.Name + "--" + p.Age + "--" + p.Sex);
            Response.Write("<br />");
        }
    }

    protected void Insert(object sender, EventArgs e)
    {
        var context = new PetaPoco.Database("postgres");

        Person p = new Person
        {
            Name = "小明明",
            Age = 10,
            Sex = "男"
        };

        context.Insert(p);
    }

    protected void Update(object sender, EventArgs e)
    {
        var context = new PetaPoco.Database("postgres");

        var res = context.Query<Person>("SELECT id,name,age,sex FROM person WHERE name='小明明'").FirstOrDefault();

        if (res != null)
        {
            res.Name = "小小明";
            res.Age=5;

            context.Update(res);
        }

    }


    protected void Delete(object sender, EventArgs e)
    {
        var context = new PetaPoco.Database("postgres");

        var res = context.Query<Person>("SELECT id,name,age,sex FROM person WHERE name='小明明'").FirstOrDefault();

        if (res != null)
        {
            context.Delete(res);
        }
    }


}