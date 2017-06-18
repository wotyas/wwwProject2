using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Nauczyciel : System.Web.UI.Page
{
    SqlConnection conn;
    string pesel;
    bool ACCEPTED;
    protected void Page_Load(object sender, EventArgs e)
    {

        pesel = (string)(Session["id"]);
        
        if (pesel.Equals("-1"))
        {
            ACCEPTED = false;
            return;
        }
        ACCEPTED = true;
        Session["teacherID"] = pesel;

        string conStr = "Server=WOTYAS-TSHBA\\WSQLSERVER;Database=Szkola;Trusted_Connection=True;";
        conn = new SqlConnection(conStr);
        conn.Open();

        loadTeacherInformation();
        loadPlan();

    }

    private void loadTeacherInformation()
    {
        SqlCommand cmd = new SqlCommand("SELECT imie, nazwisko FROM Pracownicy WHERE id_pracownik='" + pesel + "';", conn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);

        if( table.Rows.Count == 0)
        {
            ACCEPTED = false;
            return;
        }

        string imie = table.Rows[0]["imie"].ToString();
        string nazwisko = table.Rows[0]["nazwisko"].ToString();
        welcomeLabel.Text = "Nauczyciel: " + imie + " " + nazwisko + " [" + pesel + "]";

        cmd = new SqlCommand("SELECT wynagrodzenie FROM wynagrodzenia WHERE id_pracownik='" + pesel + "';", conn);
        adapter = new SqlDataAdapter(cmd);
        table = new DataTable();
        adapter.Fill(table);
        Pensja.Text = "Twoje miesięczne wynagrodzenie to: [ " + table.Rows[0][0].ToString() + " ] PLN";
     
    }

    private void loadPlan()
    {
        SqlCommand cmd = new SqlCommand("SELECT dzien, godz, przedmiot, sala, klasa FROM mojPlan  WHERE id_pracownik = '" + pesel + "' ORDER BY dbo.dzien_do_int(dzien), godz;", conn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        GridView1.DataSource = table;
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Server.Transfer("dodajOcene.aspx", false);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["teacherID"] = "-1";
        Session["id"] = "-1";
        Server.Transfer("Default.aspx", false);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Server.Transfer("dodajNieob.aspx", false);
    }
}