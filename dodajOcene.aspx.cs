using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dodajOcene : System.Web.UI.Page
{
    SqlConnection conn;
    string pesel;
    bool ACCEPTED;

    protected void Page_Load(object sender, EventArgs e)
    {
        pesel = (string)(Session["teacherID"]);
        if( pesel.Equals("-1"))
        {
            ACCEPTED = false;
            return;
        }
        ACCEPTED = true;

        string conStr = "Server=WOTYAS-TSHBA\\WSQLSERVER;Database=Szkola;Trusted_Connection=True;";
        conn = new SqlConnection(conStr);
        conn.Open();

        loadKlasy();
        loadTypy();

    }

    private void loadKlasy()
    {
        SqlCommand komenda = new SqlCommand("SELECT Klasa FROM mojPlan WHERE id_pracownik = '" + pesel + "' GROUP BY Klasa", conn);
        SqlDataAdapter dataAdapter = new SqlDataAdapter(komenda);
        DataTable tabela = new DataTable();
        dataAdapter.Fill(tabela);

        if( klasy.Items.Count == 0)
        {
            klasy.Items.Clear();
            klasy.Items.Add("");

            foreach (DataRow row in tabela.Rows)
            {
                klasy.Items.Add(row["Klasa"].ToString());

            }
        }
        
    }

    private void inicjalizuj_przedmioty(string klasa)
    {
        
        przedmioty.Items.Clear();
        przedmioty.Items.Add("");
        DataSet dataset = new DataSet();
        SqlCommand komenda = new SqlCommand("SELECT przedmiot FROM mojPlan WHERE id_pracownik = '" + pesel + "' AND Klasa='" + klasa + "' GROUP BY przedmiot;", conn);
        SqlDataAdapter dataAdapter = new SqlDataAdapter(komenda);
        DataTable tabela = new DataTable();
        dataAdapter.Fill(tabela);

        foreach (DataRow row in tabela.Rows)
        {
            przedmioty.Items.Add(row["przedmiot"].ToString().Replace(" ", ""));
        }
    }


    protected void klasy_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        string klasa = klasy.SelectedItem.ToString();
        inicjalizuj_przedmioty(klasa);
        uczniowie.Items.Clear();
        uczniowie.Items.Add("");
        
        DataSet dataset = new DataSet();
        SqlCommand komenda = new SqlCommand("SELECT * FROM Uczniowie WHERE klasa=(SELECT id_klasa FROM Klasy WHERE nazwa='" + klasa + "');", conn);
        SqlDataAdapter dataAdapter = new SqlDataAdapter(komenda);
        DataTable tabela = new DataTable();
        dataAdapter.Fill(tabela);

        foreach (DataRow row in tabela.Rows)
        {
            string imie = row["imie"].ToString();
            string nazwisko = row["nazwisko"].ToString();
            string pesel = row["id_uczen"].ToString();
            imie = imie.Replace(" ", "");
            nazwisko = nazwisko.Replace(" ", "");
            pesel = pesel.Replace(" ", "");

            uczniowie.Items.Add(imie + " " + nazwisko + ", " + pesel);
        }
    }

    private void loadTypy()
    {
        if (typy.Items.Count == 0)
        {
            typy.Items.Add("");
            typy.Items.Add("sprawdzian");
            typy.Items.Add("odpowiedz");
            typy.Items.Add("zad_domowe");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if( !ACCEPTED )
        {
            infoLabel.Text = "Musisz byc zalogowany!";
            return;
        }

        DateTime datetime;
        string dzien = dzienTB.Text;
        string miesiac = miesiacTB.Text;
        string rok = rokTB.Text;
        string data = rok + "-" + miesiac + "-" + dzien;
        string klasa = klasy.Text;
        if (klasy.Text.Equals(string.Empty) || uczniowie.Text.Equals(string.Empty) 
            || przedmioty.Text.Equals(string.Empty) || ocena.Text.Equals(string.Empty) 
            || typy.Text.Equals(string.Empty) || dzienTB.Text.Equals(string.Empty) 
            || miesiacTB.Text.Equals(string.Empty) || rokTB.Text.Equals(string.Empty))
        {
            infoLabel.Text = "Wprowadź pełne dane!";
        }
        else
        {
            try
            {
                datetime = new DateTime(Int32.Parse(rokTB.Text), Int32.Parse(miesiacTB.Text), Int32.Parse(dzienTB.Text));
                string day = pobierz_dzien(datetime.DayOfWeek.ToString());
                string id = uczniowie.Text.Split(' ')[2];
                int o_ocena = Int32.Parse(ocena.Text);
                string przedmiot = przedmioty.Text;
                string typ = typy.Text;
                string komentarz = komentarzTB.Text;

                SqlCommand sqlcmd = new SqlCommand("SELECT * FROM mojPlan WHERE dzien = '" + day + "' AND Klasa = '" + klasa + "' AND id_pracownik = '" + pesel + "' AND Przedmiot = '" + przedmioty.SelectedItem.ToString() + "';", conn);
                DataSet dataset = new DataSet();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlcmd);
                DataTable tabela = new DataTable();
                dataAdapter.Fill(tabela);

                if (tabela.Rows.Count > 0)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Oceny VALUES('" + id + "', " + o_ocena + ", (SELECT id_przedmiot FROM Przedmioty WHERE nazwa='" + przedmiot + "'), '" + typ + "', '" + data + "', '" + komentarz + "');", conn);
                    cmd.ExecuteNonQuery();
                    infoLabel.Text = "Wprowadzono nowa ocene!";
                    
                }
                else
                {
                    infoLabel.Text = "Niepoprawne dane!";
                }

            }
            catch
            {
                infoLabel.Text = "Niepoprawna data!";
            }
        }
    }

    private string pobierz_dzien(string dzien)
    {
        switch (dzien)
        {
            case "Monday":
                return "poniedziałek";
            case "Tuesday":
                return "wtorek";
            case "Wednesday":
                return "środa";
            case "Thursday":
                return "czwartek";
            case "Friday":
                return "piątek";
            default:
                return "weekend";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("Nauczyciel.aspx", false);
    }
}