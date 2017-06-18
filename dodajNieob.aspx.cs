using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class dodajNieob : System.Web.UI.Page
{
    SqlConnection conn;
    string pesel;
    bool ACCEPTED;

    protected void Page_Load(object sender, EventArgs e)
    {
        pesel = (string)(Session["teacherID"]);
        if (pesel.Equals("-1"))
        {
            ACCEPTED = false;
            return;
        }
        ACCEPTED = true;

        string conStr = "Server=WOTYAS-TSHBA\\WSQLSERVER;Database=Szkola;Trusted_Connection=True;";
        conn = new SqlConnection(conStr);
        conn.Open();

        loadKlasy();

    }

    private void loadKlasy()
    {
        SqlCommand komenda = new SqlCommand("SELECT Klasa FROM mojPlan WHERE id_pracownik = '" + pesel + "' GROUP BY Klasa", conn);
        SqlDataAdapter dataAdapter = new SqlDataAdapter(komenda);
        DataTable tabela = new DataTable();
        dataAdapter.Fill(tabela);

        if (klasy.Items.Count == 0)
        {
            klasy.Items.Clear();
            klasy.Items.Add("");

            foreach (DataRow row in tabela.Rows)
            {
                klasy.Items.Add(row["Klasa"].ToString());

            }
        }

    }

    protected void klasy_SelectedIndexChanged(object sender, EventArgs e)
    {

        string klasa = klasy.SelectedItem.ToString();
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

    protected void Wroc_Click(object sender, EventArgs e)
    {
        Server.Transfer("Nauczyciel.aspx", false);
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

    protected void Generuj_Click(object sender, EventArgs e)
    {
        lekcje.Items.Clear();
        string klasa = klasy.SelectedItem.ToString();
        string dzien = dzienTB.Text;
        string miesiac = miesiacTB.Text;
        string rok = rokTB.Text;
        try
        {
            DateTime datetime = new DateTime(Int32.Parse(rok), Int32.Parse(miesiac), Int32.Parse(dzien));
            string day = datetime.DayOfWeek.ToString();
            string wynik = pobierz_dzien(day);

            DataSet dataset = new DataSet();
            SqlCommand komenda = new SqlCommand("SELECT * FROM mojPlan WHERE dzien='" + wynik + "' AND Klasa = '" + klasa + "' AND id_pracownik = '" + pesel + "';", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(komenda);
            DataTable tabela = new DataTable();
            dataAdapter.Fill(tabela);

            foreach (DataRow row in tabela.Rows)
            {
                lekcje.Items.Add(row["godz"].ToString());
            }
        }
        catch
        {
            infoLabel.Text = "Podana data jest nieprawidlowa!";
        }
    }

    protected void Zatwierdz_Click(object sender, EventArgs e)
    {
        if (klasy.Text.Equals(string.Empty) || uczniowie.Text.Equals(string.Empty) || lekcje.Text.Equals(string.Empty))
        {
            infoLabel.Text = "Wprowadz pelne dane!";
        }
        else
        {
            string dzien = dzienTB.Text;
            string miesiac = miesiacTB.Text;
            string rok = rokTB.Text;
            string data = rok + "-" + miesiac + "-" + dzien;
            DateTime datetime = new DateTime();
            try
            {
                datetime = new DateTime(Int32.Parse(rok), Int32.Parse(miesiac), Int32.Parse(dzien));
                string dz = datetime.DayOfWeek.ToString();
                string id = uczniowie.Text.Split(' ')[2];
                SqlCommand cmd = new SqlCommand("INSERT INTO Nieobecnosci VALUES('" + id + "', '" + data + "', (SELECT id_lekcja FROM Lekcje WHERE godz='" + lekcje.Text + "'), 'nieusp');", conn);
                cmd.ExecuteNonQuery();
                infoLabel.Text = "Dodano nieobecnosc dla: [ " + id + " ]";
        
            }
            catch
            {
                infoLabel.Text = "Niepoprawna data!";
            }
        }
    }

}