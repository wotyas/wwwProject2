using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student : System.Web.UI.Page
{
    SqlConnection conn;
    string pesel;
    bool ACCEPTED;
    protected void Page_Load(object sender, EventArgs e)
    {
        pesel = (string)(Session["id"]);
        Session["teacherID"] = "-1";
        if( pesel.Equals("-1"))
        {
            ACCEPTED = false;
            return;
        }
        ACCEPTED = true;


        string conStr = "Server=WOTYAS-TSHBA\\WSQLSERVER;Database=Szkola;Trusted_Connection=True;";
        conn = new SqlConnection(conStr);
        conn.Open();

        loadStudentInformation();
        loadPlanZajec();
        loadOceny();
        loadNieobecnosci();
    }

    private void loadStudentInformation()
    {
        SqlCommand komenda = new SqlCommand("SELECT imie, nazwisko FROM Uczniowie WHERE id_uczen='" + pesel + "';", conn);

        SqlDataAdapter adapt = new SqlDataAdapter(komenda);
        DataTable tabela = new DataTable();
        adapt.Fill(tabela);

        string imie = tabela.Rows[0]["imie"].ToString();
        string nazwisko = tabela.Rows[0]["nazwisko"].ToString();

        Label1.Text = "Witaj " + imie + " " + nazwisko + " [" + pesel + "]";
    }

    private void loadPlanZajec()
    {
        SqlCommand cmd = new SqlCommand("SELECT dzien, godz, Przedmiot, sala, imie, nazwisko FROM PlanUcznia WHERE id_uczen = '" + pesel + "' ORDER BY dbo.dzien_do_int(dzien), godz", conn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable tabela = new DataTable();
        adapter.Fill(tabela);
        GridView1.DataSource = tabela;
        GridView1.DataBind();
    }

    private void loadOceny()
    {
        SqlCommand cmd = new SqlCommand("SELECT przedmiot, ocena, rodzaj, data, komentarz FROM ocenyUczen WHERE id_uczen = '" + pesel + "' ORDER BY data;", conn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        GridView2.DataSource = table;
        GridView2.DataBind();
    }

    private void loadNieobecnosci()
    {
        SqlCommand cmd = new SqlCommand("SELECT data, dzien, godzina, nazwa, status FROM nieobUcznia WHERE id_uczen ='" + pesel + "';", conn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        GridView3.DataSource = table;
        GridView3.DataBind();

        if( table.Rows.Count == 0)
        {
            Label2.Text += "brak";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["id"] = "-1";
        Server.Transfer("Default.aspx", false);
    }
}