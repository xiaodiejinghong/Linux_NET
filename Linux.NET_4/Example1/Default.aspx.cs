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

    protected void Add(object sender, EventArgs e)
    {
        int a = Convert.ToInt32(Addend1.Text);
        int b = Convert.ToInt32(Addend2.Text);
        Result.Text = (a + b).ToString();
    }
}