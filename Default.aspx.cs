using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection conn = null;
    HtmlElement textArea;
    protected void Page_Load(object sender, EventArgs e)
    {
        if( conn != null)
        {
            conn.Close();
        }
        //peselTextBox.Text = "";
        //pwdTextBox.Text = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string conStr = "Server=WOTYAS-TSHBA\\WSQLSERVER;Database=Szkola;Trusted_Connection=True;";
        conn = new SqlConnection(conStr);
        conn.Open();

        string pesel = peselTextBox.Text;
        string haslo = pwdTextBox.Text;
        pesel = pesel.Replace(" ", string.Empty);
        haslo = haslo.Replace(" ", string.Empty);

        SqlCommand komenda = new SqlCommand("SELECT haslo, typ FROM Hasla WHERE login='" + pesel + "';", conn);

        SqlDataAdapter adapt = new SqlDataAdapter(komenda);
        DataTable tabela = new DataTable();
        adapt.Fill(tabela);

        if (tabela.Rows.Count > 0)
        {
            string wynik = tabela.Rows[0]["haslo"].ToString();
            string typ = tabela.Rows[0]["typ"].ToString();
            typ = typ.Replace(" ", string.Empty);
            wynik = wynik.Replace(" ", string.Empty);

            if (wynik.Equals(haslo))
            {
                Label3.Text = typ;
                Session["id"] = pesel;
                if ( typ.Equals("U"))
                {
                    Server.Transfer("Student.aspx", false);
                }
                else if( typ.Equals("N"))
                {
                    Server.Transfer("Nauczyciel.aspx", false);
                }
                
            }
            else
            {
                Label3.Text = "Błędne hasło!";
            }
        }
        else
        {
            Label3.Text = "Błędny pesel!";
            
        }

    } 
}