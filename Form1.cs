using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Typy_trójkątów
{
    public partial class FormTypyTrójkątów : Form
    {
        double a, b, c, alfa, beta, gamma;
        double a1, c1, beta1;
        Boolean blad = false;
        public Form2 form2;
        Pen myPen = new Pen(Color.Black);
        Graphics g = null;
        int start_x, start_y;


        public FormTypyTrójkątów()
        {
            InitializeComponent();
            form2 = new Form2();
            comboBoxFunkcje.SelectedIndex = 6;
            comboBoxRodzajKąta.SelectedIndex = 3;
            textBoxKątAlfa.BackColor = Color.LightGray;
            textBoxKątBeta.BackColor = Color.LightGray;
            textBoxKątGamma.BackColor = Color.LightGray;
        }

        //funkcja Convert 
        ///A
        private void ConvertA(object sender, EventArgs e)
        {
            try { a = Convert.ToDouble(textBoxWartośćA.Text); errorProviderBlad.SetError(textBoxWartośćA, ""); }
            catch { a = 0; textBoxWartośćA.Text = ""; errorProviderBlad.SetError(textBoxWartośćA, "Musisz wpisać liczbę"); }
        }
        ///B
        private void ConvertB(object sender, EventArgs e)
        {
            try { b = Convert.ToDouble(textBoxWartośćB.Text); errorProviderBlad.SetError(textBoxWartośćB, ""); }
            catch { b = 0; textBoxWartośćB.Text = ""; errorProviderBlad.SetError(textBoxWartośćB, "Musisz wpisać liczbę"); }
        }
        ///C
        private void ConvertC(object sender, EventArgs e)
        {
            try { c = Convert.ToDouble(textBoxWartośćC.Text); errorProviderBlad.SetError(textBoxWartośćC, ""); }
            catch { c = 0; textBoxWartośćC.Text = ""; errorProviderBlad.SetError(textBoxWartośćC, "Musisz wpisać liczbę"); }
        }
        ///alfa
        private void ConvertAlfa(object sender, EventArgs e)
        {
            try { alfa = (Math.PI / 180) * Convert.ToDouble(textBoxKątAlfa.Text); errorProviderBlad.SetError(textBoxKątAlfa, ""); }//radiany
            catch { alfa = 0; textBoxKątAlfa.Text = ""; errorProviderBlad.SetError(textBoxKątAlfa, "Musisz wpisać liczbę"); }
        }
        ///beta
        private void ConvertBeta(object sender, EventArgs e)
        {
            try { beta = (Math.PI / 180) * Convert.ToDouble(textBoxKątBeta.Text); errorProviderBlad.SetError(textBoxKątBeta, ""); }
            catch { beta = 0; textBoxKątBeta.Text = ""; errorProviderBlad.SetError(textBoxKątBeta, "Musisz wpisać liczbę"); }
        }
        ///gamma
        private void ConvertGamma(object sender, EventArgs e)
        {
            try { gamma = (Math.PI / 180) * Convert.ToDouble(textBoxKątGamma.Text); errorProviderBlad.SetError(textBoxKątGamma, ""); }
            catch{gamma = 0; textBoxKątGamma.Text = ""; errorProviderBlad.SetError(textBoxKątGamma, "Musisz wpisać liczbę");}
        }

        //funkcja sprawdzenie
        ///A
        private void sprawdzenieA(object sender, EventArgs e)
        {
            if (a <= 0)
            {
                if (textBoxWartośćA.Text == "") errorProviderBlad.SetError(textBoxWartośćA, "Musisz wpisać liczbę");
                else errorProviderBlad.SetError(textBoxWartośćA, "Liczba musi być większa od 0");
            }
        }
        ///B
        private void sprawdzenieB(object sender, EventArgs e)
        {
            if (b <= 0)
            {
                if (textBoxWartośćB.Text == "") errorProviderBlad.SetError(textBoxWartośćB, "Musisz wpisać liczbę");
                else errorProviderBlad.SetError(textBoxWartośćB, "Liczba musi być większa od 0");
            }
        }
        ///C
        private void sprawdzenieC(object sender, EventArgs e)
        {
            if (c <= 0)
            {
                if (textBoxWartośćC.Text == "") errorProviderBlad.SetError(textBoxWartośćC, "Musisz wpisać liczbę");
                else errorProviderBlad.SetError(textBoxWartośćC, "Liczba musi być większa od 0");
            }
        }
        ///alfa
        private void sprawdzenieAlfa(object sender, EventArgs e)
        {
            if (alfa <= 0 || alfa >= Math.PI)
            {
                if (textBoxKątAlfa.Text == "") errorProviderBlad.SetError(textBoxKątAlfa, "Musisz wpisać kąt");
                else errorProviderBlad.SetError(textBoxKątAlfa, "Kąt musi być liczbą między 0 a 180");
            }
        }
        ///beta
        private void sprawdzenieBeta(object sender, EventArgs e)
        {
            if (beta <= 0 || beta >= Math.PI)
            {
                if (textBoxKątBeta.Text == "") errorProviderBlad.SetError(textBoxKątBeta, "Musisz wpisać kąt");
                else errorProviderBlad.SetError(textBoxKątBeta, "Kąt musi być liczbą między 0 a 180");
            }
        }
        ///gamma
        private void sprawdzenieGamma(object sender, EventArgs e)
        {
            if (gamma <= 0 || gamma >= Math.PI)
            {
                if (textBoxKątGamma.Text == "") errorProviderBlad.SetError(textBoxKątGamma, "Musisz wpisać kąt");
                else errorProviderBlad.SetError(textBoxKątGamma, "Kąt musi być liczbą między 0 a 180");
            }
        }

        //funkcja Boki
        private void zmianaBoki(object sender, EventArgs e)
        {
            aibToolStripMenuItem.CheckState = CheckState.Unchecked;
            aicToolStripMenuItem.CheckState = CheckState.Unchecked;
            bicToolStripMenuItem.CheckState = CheckState.Unchecked;
            textBoxWartośćA.BackColor = Color.LightGray;//rodzaj tła
            textBoxWartośćB.BackColor = Color.LightGray;
            textBoxWartośćC.BackColor = Color.LightGray;
            textBoxWartośćA.Cursor = Cursors.No;//kursory
            textBoxWartośćB.Cursor = Cursors.No;
            textBoxWartośćC.Cursor = Cursors.No;
            textBoxWartośćA.ReadOnly = true;//czy można wpisać
            textBoxWartośćB.ReadOnly = true;
            textBoxWartośćC.ReadOnly = true;
            textBoxWartośćA.Text = "";//wartości
            textBoxWartośćB.Text = "";
            textBoxWartośćC.Text = "";
        }
        //funkcja Kąty
        private void zmianaKąt(object sender, EventArgs e)
        {
            alfaToolStripMenuItem.CheckState = CheckState.Unchecked;
            betaToolStripMenuItem.CheckState = CheckState.Unchecked;
            gammaToolStripMenuItem.CheckState = CheckState.Unchecked;
            textBoxKątAlfa.BackColor = Color.LightGray;//rodzaj tła
            textBoxKątBeta.BackColor = Color.LightGray;
            textBoxKątGamma.BackColor = Color.LightGray;
            textBoxKątAlfa.Cursor = Cursors.No;//kursory
            textBoxKątBeta.Cursor = Cursors.No;
            textBoxKątGamma.Cursor = Cursors.No;
            textBoxKątAlfa.ReadOnly = true;//czy można wpisać
            textBoxKątBeta.ReadOnly = true;
            textBoxKątGamma.ReadOnly = true;
            textBoxKątAlfa.Text = "";//wartości
            textBoxKątBeta.Text = "";
            textBoxKątGamma.Text = "";
        }
        //funkcja Bok
        private void zmianaBok(object sender, EventArgs e)
        {
            aToolStripMenuItem.CheckState = CheckState.Unchecked;
            bToolStripMenuItem.CheckState = CheckState.Unchecked;
            cToolStripMenuItem.CheckState = CheckState.Unchecked;
            textBoxWartośćA.BackColor = Color.LightGray;//rodzaj tła
            textBoxWartośćB.BackColor = Color.LightGray;
            textBoxWartośćC.BackColor = Color.LightGray;
            textBoxWartośćA.Cursor = Cursors.No;//kursory
            textBoxWartośćB.Cursor = Cursors.No;
            textBoxWartośćC.Cursor = Cursors.No;
            textBoxWartośćA.ReadOnly = true;//czy można wpisać
            textBoxWartośćB.ReadOnly = true;
            textBoxWartośćC.ReadOnly = true;
            textBoxWartośćA.Text = "";//wartości
            textBoxWartośćB.Text = "";
            textBoxWartośćC.Text = "";
        }
        //funkcja Kąty
        private void zmianaKąty(object sender, EventArgs e)
        {
            alfaibetaToolStripMenuItem.CheckState = CheckState.Unchecked;
            alfaigammaToolStripMenuItem.CheckState = CheckState.Unchecked;
            betaigammaToolStripMenuItem.CheckState = CheckState.Unchecked;
            textBoxKątAlfa.BackColor = Color.LightGray;//rodzaj tła
            textBoxKątBeta.BackColor = Color.LightGray;
            textBoxKątGamma.BackColor = Color.LightGray;
            textBoxKątAlfa.Cursor = Cursors.No;//kursory
            textBoxKątBeta.Cursor = Cursors.No;
            textBoxKątGamma.Cursor = Cursors.No;
            textBoxKątAlfa.ReadOnly = true;//czy można wpisać
            textBoxKątBeta.ReadOnly = true;
            textBoxKątGamma.ReadOnly = true;
            textBoxKątAlfa.Text = "";//wartości
            textBoxKątBeta.Text = "";
            textBoxKątGamma.Text = "";
        }
        
        //zmiana textBoxów(readOnly,Text,Color,Cursor)
        ///A
        private void zmianaTextBoxuA(object sender, EventArgs e)
        {
            textBoxWartośćA.ReadOnly = false;
            textBoxWartośćA.Text = "3";
            textBoxWartośćA.BackColor = Color.FromArgb(255, 230, 210);
            textBoxWartośćA.Cursor = Cursors.IBeam;
        }
        ///B
        private void zmianaTextBoxuB(object sender, EventArgs e)
        {
            textBoxWartośćB.ReadOnly = false;
            textBoxWartośćB.Text = "3";
            textBoxWartośćB.BackColor = Color.FromArgb(220, 255, 200);
            textBoxWartośćB.Cursor = Cursors.IBeam;
        }
        ///C
        private void zmianaTextBoxuC(object sender, EventArgs e)
        {
            textBoxWartośćC.ReadOnly = false;
            textBoxWartośćC.Text = "3";
            textBoxWartośćC.BackColor = Color.FromArgb(200, 220, 255);
            textBoxWartośćC.Cursor = Cursors.IBeam;
        }
        ///alfa
        private void zmianaTextBoxuAlfa(object sender, EventArgs e)
        {
            textBoxKątAlfa.ReadOnly = false;
            textBoxKątAlfa.Text = "60";
            textBoxKątAlfa.BackColor = Color.FromArgb(255, 230, 210);
            textBoxKątAlfa.Cursor = Cursors.IBeam;
        }
        ///beta
        private void zmianaTextBoxuBeta(object sender, EventArgs e)
        {
            textBoxKątBeta.ReadOnly = false;
            textBoxKątBeta.Text = "60";
            textBoxKątBeta.BackColor = Color.FromArgb(220, 255, 200);
            textBoxKątBeta.Cursor = Cursors.IBeam;
        }
        ///gamma
        private void zmianaTextBoxuGamma(object sender, EventArgs e)
        {
            textBoxKątGamma.ReadOnly = false;
            textBoxKątGamma.Text = "60";
            textBoxKątGamma.BackColor = Color.FromArgb(200, 220, 255);
            textBoxKątGamma.Cursor = Cursors.IBeam;
        }

        //funkcja ComboBox
        private void trygonometria(object sender,EventArgs e)
        {
            double x = 0;
            try { alfa = (Math.PI / 180) * Convert.ToDouble(textBoxKątAlfa.Text); errorProviderBlad.SetError(comboBoxFunkcje, ""); }
            catch { alfa = 0; textBoxWynikFunkcji.Text = "NaN"; errorProviderBlad.SetError(comboBoxFunkcje, "Kątowi alfa musi być przypisana wartość liczbowa"); }
            try { beta = (Math.PI / 180) * Convert.ToDouble(textBoxKątBeta.Text); errorProviderBlad.SetError(comboBoxFunkcje, ""); }
            catch { beta = 0; textBoxWynikFunkcji.Text = "NaN"; errorProviderBlad.SetError(comboBoxFunkcje, "Kątowi beta musi być przypisana wartość liczbowa"); }
            try { gamma = (Math.PI / 180) * Convert.ToDouble(textBoxKątGamma.Text); errorProviderBlad.SetError(comboBoxFunkcje, ""); }
            catch { gamma = 0; textBoxWynikFunkcji.Text = "NaN"; errorProviderBlad.SetError(comboBoxFunkcje, "Kątowi gamma musi być przypisana wartość liczbowa"); }

            if (alfa <= 0 || alfa >= Math.PI || textBoxKątAlfa.Text == "" || textBoxKątAlfa.Text == "NaN" || beta <= 0 || beta >= Math.PI || textBoxKątBeta.Text == "" || textBoxKątBeta.Text == "" || gamma <= 0 || gamma >= Math.PI || textBoxKątGamma.Text == "" || textBoxKątGamma.Text == "NaN")//obsługa błędów
            {
                if (alfa <= 0 || alfa >= Math.PI || textBoxKątAlfa.Text == "" || textBoxKątAlfa.Text == "NaN")
                {
                    errorProviderBlad.SetError(comboBoxFunkcje, "Kątowi alfa musi być przypisana poprawna wartość liczbowa");
                }
                else if (beta <= 0 || beta >= Math.PI || textBoxKątBeta.Text == "" || textBoxKątBeta.Text == "")
                {
                    errorProviderBlad.SetError(comboBoxFunkcje, "Kątowi beta musi być przypisana poprawna wartość liczbowa");
                }

                else if (gamma <= 0 || gamma >= Math.PI || textBoxKątGamma.Text == "" || textBoxKątGamma.Text == "NaN")
                {
                    errorProviderBlad.SetError(comboBoxFunkcje, "Kątowi gamma musi być przypisana poprawna wartość liczbowa");
                }
            }
            else
            {
                switch (comboBoxFunkcje.SelectedIndex)
                {
                    case 0:
                        if (comboBoxRodzajKąta.SelectedIndex == 0) x = Math.Sin(alfa);
                        else if (comboBoxRodzajKąta.SelectedIndex == 1) x = Math.Sin(beta);
                        else if (comboBoxRodzajKąta.SelectedIndex == 2) x = Math.Sin(gamma); break;
                    case 1:
                        if (comboBoxRodzajKąta.SelectedIndex == 0) x = Math.Cos(alfa);
                        else if (comboBoxRodzajKąta.SelectedIndex == 1) x = Math.Cos(beta);
                        else if (comboBoxRodzajKąta.SelectedIndex == 2) x = Math.Cos(gamma); break;
                    case 2:
                        if (comboBoxRodzajKąta.SelectedIndex == 0) x = Math.Tan(alfa);
                        else if (comboBoxRodzajKąta.SelectedIndex == 1) x = Math.Tan(beta);
                        else if (comboBoxRodzajKąta.SelectedIndex == 2) x = Math.Tan(gamma); break;
                    case 3:
                        if (comboBoxRodzajKąta.SelectedIndex == 0) x = 1 / (Math.Tan(alfa));
                        else if (comboBoxRodzajKąta.SelectedIndex == 1) x = 1 / Math.Tan(beta);
                        else if (comboBoxRodzajKąta.SelectedIndex == 2) x = 1 / Math.Tan(gamma); break;
                    case 4:
                        if (comboBoxRodzajKąta.SelectedIndex == 0) x = 1 / (Math.Cos(alfa));
                        else if (comboBoxRodzajKąta.SelectedIndex == 1) x = 1 / Math.Cos(beta);
                        else if (comboBoxRodzajKąta.SelectedIndex == 2) x = 1 / Math.Cos(gamma); break;
                    case 5:
                        if (comboBoxRodzajKąta.SelectedIndex == 0) x = 1 / (Math.Sin(alfa));
                        else if (comboBoxRodzajKąta.SelectedIndex == 1) x = 1 / Math.Sin(beta);
                        else if (comboBoxRodzajKąta.SelectedIndex == 2) x = 1 / Math.Sin(gamma); break;
                }
            }
            x = Math.Round(x, 2);
            textBoxWynikFunkcji.Text = Convert.ToString(x);
        }
        //funkcja errory ogólna
        private void errory(object sender, EventArgs e)
        {
            errorProviderBlad.SetError(labelWynik, "");
            errorProviderBlad.SetError(comboBoxFunkcje, "");
            errorProviderBlad.SetError(comboBoxRodzajKąta, "");
            errorProviderBlad.SetError(textBoxWynikFunkcji, "");
            errorProviderBlad.SetError(textBoxKątAlfa, "");
            errorProviderBlad.SetError(textBoxKątBeta, "");
            errorProviderBlad.SetError(textBoxKątGamma, "");
            errorProviderBlad.SetError(textBoxWartośćA, "");
            errorProviderBlad.SetError(textBoxWartośćB, "");
            errorProviderBlad.SetError(textBoxWartośćC, "");
            errorProviderBlad.SetError(panelRysowanie, "");

        }
        //funkcja errory bok, bok, bok
        private void erroryBBB(object sender, EventArgs e)
        {
            blad = true;
            textBoxKątAlfa.Text = "NaN";
            textBoxKątBeta.Text = "NaN";
            textBoxKątGamma.Text = "NaN";
            labelWynik.Text = "Taki trójkąt nie istnieje";
        }
        //funkcja errory bok, bok, kąt
        private void erroryBBK(object sender, EventArgs e)
        {
            blad = true;
            if (aibToolStripMenuItem.Checked )
            {
                if (alfaToolStripMenuItem.Checked)
                {
                    textBoxKątBeta.Text = "NaN";
                    textBoxKątGamma.Text = "NaN";
                    textBoxWartośćC.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
                else if (betaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "NaN";
                    textBoxKątGamma.Text = "NaN";
                    textBoxWartośćC.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
                else if (gammaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "NaN";
                    textBoxKątBeta.Text = "NaN";
                    textBoxWartośćC.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
            }
            else if (aicToolStripMenuItem.Checked)
            {
                if (alfaToolStripMenuItem.Checked)
                {
                    textBoxKątBeta.Text = "NaN";
                    textBoxKątGamma.Text = "NaN";
                    textBoxWartośćB.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
                else if (betaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "NaN";
                    textBoxKątGamma.Text = "NaN";
                    textBoxWartośćB.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
                else if (gammaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "NaN";
                    textBoxKątBeta.Text = "NaN";
                    textBoxWartośćB.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
            }
            else if (bicToolStripMenuItem.Checked)
            {
                if (alfaToolStripMenuItem.Checked)
                {
                    textBoxKątBeta.Text = "NaN";
                    textBoxKątGamma.Text = "NaN";
                    textBoxWartośćA.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
                else if (betaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "NaN";
                    textBoxKątGamma.Text = "NaN";
                    textBoxWartośćA.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
                else if (gammaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "NaN";
                    textBoxKątBeta.Text = "NaN";
                    textBoxWartośćA.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
            }
        }
        //funkcja errory bok, kąt, kąt
        private void erroryBKK(object sender, EventArgs e)
        {
            blad = true;
            if (alfaibetaToolStripMenuItem.Checked)
            {
                if (aToolStripMenuItem.Checked)
                {
                    textBoxKątGamma.Text = "NaN";
                    textBoxWartośćB.Text = "NaN";
                    textBoxWartośćC.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
                else if (bToolStripMenuItem.Checked)
                {
                    textBoxKątGamma.Text = "NaN";
                    textBoxWartośćA.Text = "NaN";
                    textBoxWartośćC.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
                else if (cToolStripMenuItem.Checked)
                {
                    textBoxKątGamma.Text = "NaN";
                    textBoxWartośćA.Text = "NaN";
                    textBoxWartośćB.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
            }
            else if (alfaigammaToolStripMenuItem.Checked)
            {
                if (aToolStripMenuItem.Checked)
                {
                    textBoxKątBeta.Text = "NaN";
                    textBoxWartośćB.Text = "NaN";
                    textBoxWartośćC.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
                else if (bToolStripMenuItem.Checked)
                {
                    textBoxKątBeta.Text = "NaN";
                    textBoxWartośćA.Text = "NaN";
                    textBoxWartośćC.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
                else if (cToolStripMenuItem.Checked)
                {
                    textBoxKątBeta.Text = "NaN";
                    textBoxWartośćA.Text = "NaN";
                    textBoxWartośćB.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
            }
            else if (betaigammaToolStripMenuItem.Checked)
            {
                if (aToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "NaN";
                    textBoxWartośćB.Text = "NaN";
                    textBoxWartośćC.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
                else if (bToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "NaN";
                    textBoxWartośćA.Text = "NaN";
                    textBoxWartośćC.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
                else if (cToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "NaN";
                    textBoxWartośćA.Text = "NaN";
                    textBoxWartośćB.Text = "NaN";
                    labelWynik.Text = "Taki trójkąt nie istnieje";
                }
            }
        }

        //funkcja czyść rysunek
        private void pustyRysunek(object sender, EventArgs e)
        {
            textBoxRysunekAlfa.Text = "";
            textBoxRysunekBeta.Text = "";
            textBoxRysunekGamma.Text = "";
            textBoxRysunekBokA.Text = "";
            textBoxRysunekBokB.Text = "";
            textBoxRysunekBokC.Text = "";
        }
        //funkcja przypisz rysunek
        private void przypiszRysunek(object sender, EventArgs e)
        {
            textBoxRysunekBokA.Text = textBoxWartośćA.Text;
            textBoxRysunekBokB.Text = textBoxWartośćB.Text;
            textBoxRysunekBokC.Text = textBoxWartośćC.Text;
            textBoxRysunekAlfa.Text = textBoxKątAlfa.Text + "˚";
            textBoxRysunekBeta.Text = textBoxKątBeta.Text + "˚";
            textBoxRysunekGamma.Text = textBoxKątGamma.Text + "˚";
        }

        //funkcja zmiana tekstu bok, bok, bok
        private void opcjeWyszukiwaniaBBB(object sender, EventArgs e)
        {
            if (bokbokbokToolStripMenuItem.Checked)
            {
                textBoxKątAlfa.Text = "";
                textBoxKątBeta.Text = "";
                textBoxKątGamma.Text = "";
            }
        }
        //funkcje zmiana tekstu bok, bok, kąt
        ///funkcje ab
        private void opcjeWyszukiwaniaBBKabalfa(object sender, EventArgs e)
        {
            if (bokBokKątToolStripMenuItem.Checked && aibToolStripMenuItem.Checked && alfaToolStripMenuItem.Checked)
            {
                textBoxKątBeta.Text = "";
                textBoxKątGamma.Text = "";
                textBoxWartośćC.Text = "";
            }               
        }
        private void opcjeWyszukiwaniaBBKabbeta(object sender, EventArgs e)
        {
            if (bokBokKątToolStripMenuItem.Checked && aibToolStripMenuItem.Checked && betaToolStripMenuItem.Checked)
            {
                textBoxKątAlfa.Text = "";
                textBoxKątGamma.Text = "";
                textBoxWartośćC.Text = "";
            }
        }
        private void opcjeWyszukiwaniaBBKabgamma(object sender, EventArgs e)
        {
            if (bokBokKątToolStripMenuItem.Checked && aibToolStripMenuItem.Checked && gammaToolStripMenuItem.Checked)
            {
                textBoxKątAlfa.Text = "";
                textBoxKątBeta.Text = "";
                textBoxWartośćC.Text = "";
            }
        }
        ///funkcje ac
        private void opcjeWyszukiwaniaBBKacalfa(object sender, EventArgs e)
        {
            if (bokBokKątToolStripMenuItem.Checked && aicToolStripMenuItem.Checked && alfaToolStripMenuItem.Checked)
            {
                textBoxKątBeta.Text = "";
                textBoxKątGamma.Text = "";
                textBoxWartośćB.Text = "";
            }
        }
        private void opcjeWyszukiwaniaBBKacbeta(object sender, EventArgs e)
        {
            if (bokBokKątToolStripMenuItem.Checked && aicToolStripMenuItem.Checked && betaToolStripMenuItem.Checked)
            {
                textBoxKątAlfa.Text = "";
                textBoxKątGamma.Text = "";
                textBoxWartośćB.Text = "";
            }
        }
        private void opcjeWyszukiwaniaBBKacgamma(object sender, EventArgs e)
        {
            if (bokBokKątToolStripMenuItem.Checked && aicToolStripMenuItem.Checked && gammaToolStripMenuItem.Checked)
            {
                textBoxKątAlfa.Text = "";
                textBoxKątBeta.Text = "";
                textBoxWartośćB.Text = "";
            }
        }
        ///funkcje bc
        private void opcjeWyszukiwaniaBBKbcalfa(object sender, EventArgs e)
        {
            if (bokBokKątToolStripMenuItem.Checked && bicToolStripMenuItem.Checked && alfaToolStripMenuItem.Checked)
            {
                textBoxKątBeta.Text = "";
                textBoxKątGamma.Text = "";
                textBoxWartośćA.Text = "";
            }
        }
        private void opcjeWyszukiwaniaBBKbcbeta(object sender, EventArgs e)
        {
            if (bokBokKątToolStripMenuItem.Checked && bicToolStripMenuItem.Checked && betaToolStripMenuItem.Checked)
            {
                textBoxKątAlfa.Text = "";
                textBoxKątGamma.Text = "";
                textBoxWartośćA.Text = "";
            }
        }
        private void opcjeWyszukiwaniaBBKbcgamma(object sender, EventArgs e)
        {
            if (bokBokKątToolStripMenuItem.Checked && bicToolStripMenuItem.Checked && gammaToolStripMenuItem.Checked)
            {
                textBoxKątAlfa.Text = "";
                textBoxKątBeta.Text = "";
                textBoxWartośćA.Text = "";
            }
        }

        //funkcja zmiana tekstu bok, kąt, kąt
        ///funkcje alfabeta
        private void opcjeWyszukiwaniaBKKalfabetaa(object sender, EventArgs e)
        {
            if (bokKątKątToolStripMenuItem.Checked && aToolStripMenuItem.Checked && alfaibetaToolStripMenuItem.Checked)
            {
                textBoxKątGamma.Text = "";
                textBoxWartośćB.Text = "";
                textBoxWartośćC.Text = "";
            }
        }
        private void opcjeWyszukiwaniaBKKalfabetab(object sender, EventArgs e)
        {
            if (bokKątKątToolStripMenuItem.Checked && bToolStripMenuItem.Checked && alfaibetaToolStripMenuItem.Checked)
            {
                textBoxKątGamma.Text = "";
                textBoxWartośćA.Text = "";
                textBoxWartośćC.Text = "";
            }
        }
        private void opcjeWyszukiwaniaBKKalfabetac(object sender, EventArgs e)
        {
            if (bokKątKątToolStripMenuItem.Checked && cToolStripMenuItem.Checked && alfaibetaToolStripMenuItem.Checked)
            {
                textBoxKątGamma.Text = "";
                textBoxWartośćA.Text = "";
                textBoxWartośćB.Text = "";
            }
        }
        ///funkcje alfagamma
        private void opcjeWyszukiwaniaBKKalfagammaa(object sender, EventArgs e)
        {
            if (bokKątKątToolStripMenuItem.Checked && aToolStripMenuItem.Checked && alfaigammaToolStripMenuItem.Checked)
            {
                textBoxKątBeta.Text = "";
                textBoxWartośćB.Text = "";
                textBoxWartośćC.Text = "";
            }
        }
        private void opcjeWyszukiwaniaBKKalfagammab(object sender, EventArgs e)
        {
            if (bokKątKątToolStripMenuItem.Checked && bToolStripMenuItem.Checked && alfaigammaToolStripMenuItem.Checked)
            {
                textBoxKątBeta.Text = "";
                textBoxWartośćA.Text = "";
                textBoxWartośćC.Text = "";
            }
        }
        private void opcjeWyszukiwaniaBKKalfagammac(object sender, EventArgs e)
        {
            if (bokKątKątToolStripMenuItem.Checked && cToolStripMenuItem.Checked && alfaigammaToolStripMenuItem.Checked)
            {
                textBoxKątBeta.Text = "";
                textBoxWartośćA.Text = "";
                textBoxWartośćB.Text = "";
            }
        }
        ///funkcje alfabeta
        private void opcjeWyszukiwaniaBKKbetagammaa(object sender, EventArgs e)
        {
            if (bokKątKątToolStripMenuItem.Checked && aToolStripMenuItem.Checked && betaigammaToolStripMenuItem.Checked)
            {
                textBoxKątAlfa.Text = "";
                textBoxWartośćB.Text = "";
                textBoxWartośćC.Text = "";
            }
        }
        private void opcjeWyszukiwaniaBKKbetagammab(object sender, EventArgs e)
        {
            if (bokKątKątToolStripMenuItem.Checked && bToolStripMenuItem.Checked && betaigammaToolStripMenuItem.Checked)
            {
                textBoxKątAlfa.Text = "";
                textBoxWartośćA.Text = "";
                textBoxWartośćC.Text = "";
            }
        }
        private void opcjeWyszukiwaniaBKKbetagammac(object sender, EventArgs e)
        {
            if (bokKątKątToolStripMenuItem.Checked && cToolStripMenuItem.Checked && betaigammaToolStripMenuItem.Checked)
            {
                textBoxKątAlfa.Text = "";
                textBoxWartośćA.Text = "";
                textBoxWartośćB.Text = "";
            }
        }

        //funkcja drawLine()
        private void drawLine()
        {
            if ((panelRysowanie.Visible == true) && (blad == false))
            {
                int wynik = 0;
                if (c1 >= a1)
                {
                    if (c1 >= 2)
                    {
                        while (c1 > 2)
                        {
                            c1 = c1 / 2;
                            wynik += 1;
                        }
                        for (int i = 0; i < wynik; i++)
                            a1 = a1 / 2;
                        start_x = panelRysowanie.Width / 8;
                        start_y = panelRysowanie.Height - 10;
                    }
                    else if (c1 < 1)
                    {
                        while (c1 < 1)
                        {
                            c1 = c1 * 2;
                            wynik += 1;
                        }
                        for (int i = 0; i < wynik; i++)
                            a1 = a1 * 2;
                        start_x = panelRysowanie.Width / 8;
                        start_y = panelRysowanie.Height - 10;
                    }
                }
                else
                {
                    if (a1 >= 2)
                    {
                        while (a1 > 2)
                        {
                            a1 = a1 / 2;
                            wynik += 1;
                        }
                        for (int i = 0; i < wynik; i++)
                            c1 = c1 / 2;
                        start_x = panelRysowanie.Width / 2;
                        start_y = panelRysowanie.Height - 10;
                    }
                    else if (a1 < 2)
                    {
                        while (a1 < 2)
                        {
                            a1 = a1 * 2;
                            wynik += 1;
                        }
                        for (int i = 0; i < wynik; i++)
                            c1 = c1 * 2;
                        start_x = panelRysowanie.Width / 2;
                        start_y = panelRysowanie.Height - 10;
                    }
                }
                a1 = a1 * 60;
                c1 = c1 * 60;

                myPen.Width = 3;
                int x1 = (int)(start_x + c1);
                int x2 = (int)(x1 - Math.Cos(beta1 * (Math.PI / 180)) * a1);
                int y2 = (int)(start_y - Math.Sin(beta1 * (Math.PI / 180)) * a1);
                Point[] points =
                {
                new Point(start_x,start_y),
                new Point(x1,start_y),
                new Point(x2,y2)
                };
                g.DrawPolygon(myPen, points);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxWynik_TextChanged(object sender, EventArgs e)
        {

        }

        //główny program
        private void buttonLicz_Click(object sender, EventArgs e)
        {
            errory(sender, e);
            blad = false;
            //bok bok bok
            if (bokbokbokToolStripMenuItem.Checked) 
            {
                ConvertA(sender, e);
                ConvertB(sender, e);
                ConvertC(sender, e);
                if (a <= 0 || b <= 0 || c <= 0)//obsługa błędów
                {
                    erroryBBB(sender, e);
                    sprawdzenieA(sender, e);
                    sprawdzenieB(sender, e);
                    sprawdzenieC(sender, e);
                }

                else //poprawne rozwiązanie
                {
                    double wynikab = ((a * a + b * b - c * c) / (2 * a * b));//cos gamma
                    double wynikac = (a * a + c * c - b * b) / (2 * a * c);//cos beta
                    double wynikbc = (b * b + c * c - a * a) / (2 * b * c);//cos alfa
                    alfa = (Math.Acos(wynikbc) * (180 / Math.PI));
                    beta = (Math.Acos(wynikac) * (180 / Math.PI));
                    gamma = (Math.Acos(wynikab) * (180 / Math.PI));
                    textBoxKątAlfa.Text = Convert.ToString(Math.Round(alfa, 2));//alfa
                    textBoxKątBeta.Text = Convert.ToString(Math.Round(beta, 2));//beta
                    textBoxKątGamma.Text = Convert.ToString(Math.Round(gamma, 2));//gamma
                    przypiszRysunek(sender, e);


                    if (a + b > c && b + c > a && a + c > b)//warunek trójkąta
                    {
                        if (wynikab > 0 && wynikac > 0 && wynikbc > 0)//warunek trójkąta ostrokątnego
                        {
                            if (wynikab == wynikac || wynikac == wynikbc || wynikab == wynikbc)
                            {
                                if (wynikab == wynikac && wynikac == wynikbc && wynikab == wynikbc)
                                    labelWynik.Text = "Trójkąt równoboczny";
                                else
                                    labelWynik.Text = "Trójkąt ostrokątny, równoramienny";
                            }
                            else
                                labelWynik.Text = "Trójkąt ostrokątny";
                        }
                        else if (wynikab == 0 || wynikac == 0 || wynikbc == 0)//warunek trójkąta prostokątnego
                        {
                            if (wynikab == wynikac || wynikac == wynikbc || wynikab == wynikbc)
                                labelWynik.Text = "Trójkąt prostokątny, równoramienny";
                            else
                                labelWynik.Text = "Trójkąt prostokątny";
                        }
                        else if (wynikab < 0 || wynikac < 0 || wynikbc < 0)//warunek trójkąta rozwartokątnego
                        {
                            if (wynikab == wynikac || wynikac == wynikbc || wynikab == wynikbc)
                                labelWynik.Text = "Trójkąt rozwartokątny, równoramienny";
                            else
                                labelWynik.Text = "Trójkąt rozwartokątny";
                        }

                    }
                    else
                    {
                        erroryBBB(sender, e);
                        errorProviderBlad.SetError(labelWynik, "Musi być spełniony warunek trójkąta");
                    }
                }
            }
            //bok bok kąt
            else if (bokBokKątToolStripMenuItem.Checked)
            {
                if (aibToolStripMenuItem.Checked)
                {
                    ConvertA(sender, e);
                    ConvertB(sender, e);
                    //a,b,alfa
                    if (alfaToolStripMenuItem.Checked)
                    {
                        ConvertAlfa(sender, e);
                        if (a <= 0 || b <= 0 || alfa <= 0 || alfa >= Math.PI)//obsługa błędów
                        {
                            erroryBBK(sender, e);
                            sprawdzenieA(sender, e);
                            sprawdzenieB(sender, e);
                            sprawdzenieAlfa(sender, e);
                        }
                        else
                        {
                            beta = (Math.Asin((b * Math.Sin(alfa)) / a));
                            gamma = Math.PI - beta - alfa;
                            c = Math.Sqrt((a * a + b * b) - (2 * a * b * Math.Cos(gamma)));
                            textBoxKątBeta.Text = Convert.ToString(Math.Round(beta * (180 / Math.PI), 2));//beta
                            textBoxKątGamma.Text = Convert.ToString(Math.Round(gamma * (180 / Math.PI), 2));//gamma
                            textBoxWartośćC.Text = Convert.ToString(Math.Round(c, 2));//c
                        }
                    }
                    //a,b,beta
                    else if (betaToolStripMenuItem.Checked)
                    {
                        ConvertBeta(sender, e);
                        if (a <= 0 || b <= 0 || beta <= 0 || beta >= Math.PI)//obsługa błędów
                        {
                            erroryBBK(sender, e);
                            sprawdzenieA(sender, e);
                            sprawdzenieB(sender, e);
                            sprawdzenieBeta(sender, e);
                        }
                        else
                        {
                            alfa = (Math.Asin((a * Math.Sin(beta)) / b));
                            gamma = Math.PI - beta - alfa;
                            c = Math.Sqrt((a * a + b * b) - (2 * a * b * Math.Cos(gamma)));
                            //c = ((a * Math.Sin(gamma)) / (Math.Sin(alfa)));
                            textBoxKątAlfa.Text = Convert.ToString(Math.Round(alfa * (180 / Math.PI), 2));//alfa
                            textBoxKątGamma.Text = Convert.ToString(Math.Round(gamma * (180 / Math.PI), 2));//gamma
                            textBoxWartośćC.Text = Convert.ToString(Math.Round(c, 2));//c
                        }
                    }
                    //a,b,gamma
                    else if (gammaToolStripMenuItem.Checked)
                    {
                        ConvertGamma(sender, e);
                        if (a <= 0 || b <= 0 || gamma <= 0 || gamma >= Math.PI)//obsługa błędów
                        {
                            erroryBBK(sender, e);
                            sprawdzenieA(sender, e);
                            sprawdzenieB(sender, e);
                            sprawdzenieGamma(sender, e);
                        }
                        else
                        {
                            c = Math.Sqrt((a * a + b * b) - (2 * a * b * Math.Cos(gamma)));
                            double wynikab = ((a * a + b * b - c * c) / (2 * a * b));
                            double wynikac = (a * a + c * c - b * b) / (2 * a * c);
                            double wynikbc = (b * b + c * c - a * a) / (2 * b * c);
                            alfa = (Math.Acos(wynikbc) * (180 / Math.PI));
                            beta = (Math.Acos(wynikac) * (180 / Math.PI));
                            textBoxKątAlfa.Text = Convert.ToString(Math.Round(Math.Acos(wynikbc) * (180 / Math.PI), 2));//alfa
                            textBoxKątBeta.Text = Convert.ToString(Math.Round(Math.Acos(wynikac) * (180 / Math.PI), 2));//beta
                            textBoxWartośćC.Text = Convert.ToString(Math.Round(c, 2));//c
                        }
                    }
                }
                else if (aicToolStripMenuItem.Checked)
                {
                    ConvertA(sender, e);
                    ConvertC(sender, e);
                    //a,c,alfa
                    if (alfaToolStripMenuItem.Checked)
                    {
                        ConvertAlfa(sender, e);
                        if (a <= 0 || c <= 0 || alfa <= 0 || alfa >= Math.PI)//obsługa błędów
                        {
                            erroryBBK(sender, e);
                            sprawdzenieA(sender, e);
                            sprawdzenieC(sender, e);
                            sprawdzenieAlfa(sender, e);
                        }
                        else
                        {
                            gamma = Math.Asin((c * Math.Sin(alfa)) / a);
                            beta = Math.PI - gamma - alfa;
                            b = Math.Sqrt((a * a + c * c) - (2 * a * c * Math.Cos(beta)));
                            textBoxKątBeta.Text = Convert.ToString(Math.Round(beta * (180 / Math.PI), 2));//beta
                            textBoxKątGamma.Text = Convert.ToString(Math.Round(gamma * (180 / Math.PI), 2));//gamma
                            textBoxWartośćB.Text = Convert.ToString(Math.Round(b, 2));//b
                        }
                    }
                    //a,c,beta
                    else if (betaToolStripMenuItem.Checked)
                    {
                        ConvertBeta(sender, e);
                        if (a <= 0 || c <= 0 || beta <= 0 || beta >= Math.PI)//obsługa błędów
                        {
                            erroryBBK(sender, e);
                            sprawdzenieA(sender, e);
                            sprawdzenieC(sender, e);
                            sprawdzenieBeta(sender, e);
                        }
                        else
                        {
                            b = Math.Sqrt((a * a + c * c) - (2 * a * c * Math.Cos(beta)));
                            double wynikab = ((a * a + b * b - c * c) / (2 * a * b));
                            double wynikac = (a * a + c * c - b * b) / (2 * a * c);
                            double wynikbc = (b * b + c * c - a * a) / (2 * b * c);
                            alfa = (Math.Acos(wynikbc) * (180 / Math.PI));
                            gamma = (Math.Acos(wynikab) * (180 / Math.PI));
                            textBoxKątAlfa.Text = Convert.ToString(Math.Round(alfa, 2));//alfa
                            textBoxKątGamma.Text = Convert.ToString(Math.Round(gamma, 2));//gamma
                            textBoxWartośćB.Text = Convert.ToString(Math.Round(b, 2));//b
                        }
                    }
                    //a,c,gamma
                    else if (gammaToolStripMenuItem.Checked)
                    {
                        ConvertGamma(sender, e);
                        if (a <= 0 || c <= 0 || gamma <= 0 || gamma >= Math.PI)//obsługa błędów
                        {
                            erroryBBK(sender, e);
                            sprawdzenieA(sender, e);
                            sprawdzenieC(sender, e);
                            sprawdzenieGamma(sender, e);
                        }
                        else
                        {
                            alfa = Math.Asin((a * Math.Sin(gamma)) / c);
                            beta = Math.PI - gamma - alfa;
                            b = Math.Sqrt((a * a + c * c) - (2 * a * c * Math.Cos(beta)));
                            textBoxKątAlfa.Text = Convert.ToString(Math.Round(alfa * (180 / Math.PI), 2));//alfa
                            textBoxKątBeta.Text = Convert.ToString(Math.Round(beta * (180 / Math.PI), 2));//beta
                            textBoxWartośćB.Text = Convert.ToString(Math.Round(b, 2));//b
                        }
                    }
                }
                else if (bicToolStripMenuItem.Checked)
                {
                    ConvertB(sender, e);
                    ConvertC(sender, e);
                    //b,c,alfa
                    if (alfaToolStripMenuItem.Checked)
                    {
                        ConvertAlfa(sender, e);
                        if (b <= 0 || c <= 0 || alfa <= 0 || alfa >= Math.PI)//obsługa błędów
                        {
                            erroryBBK(sender, e);
                            sprawdzenieB(sender, e);
                            sprawdzenieC(sender, e);
                            sprawdzenieAlfa(sender, e);
                        }
                        else
                        {
                            a = Math.Sqrt((b * b + c * c) - (2 * b * c * Math.Cos(alfa)));
                            double wynikab = ((a * a + b * b - c * c) / (2 * a * b));
                            double wynikac = (a * a + c * c - b * b) / (2 * a * c);
                            double wynikbc = (b * b + c * c - a * a) / (2 * b * c);
                            beta = (Math.Acos(wynikac) * (180 / Math.PI));
                            gamma = (Math.Acos(wynikab) * (180 / Math.PI));
                            textBoxKątBeta.Text = Convert.ToString(Math.Round(beta, 2));//beta
                            textBoxKątGamma.Text = Convert.ToString(Math.Round(gamma, 2));//gamma
                            textBoxWartośćA.Text = Convert.ToString(Math.Round(a, 2));//a
                        }
                    }
                    //b,c,beta
                    else if (betaToolStripMenuItem.Checked)
                    {
                        ConvertBeta(sender, e);
                        if (b <= 0 || c <= 0 || beta <= 0 || beta >= Math.PI)//obsługa błędów
                        {
                            erroryBBK(sender, e);
                            sprawdzenieB(sender, e);
                            sprawdzenieC(sender, e);
                            sprawdzenieBeta(sender, e);
                        }
                        else
                        {
                            gamma = Math.Asin((c * Math.Sin(beta)) / b);
                            alfa = Math.PI - beta - gamma;
                            a = Math.Sqrt((b * b + c * c) - (2 * b * c * Math.Cos(alfa)));
                            textBoxKątAlfa.Text = Convert.ToString(Math.Round(alfa * (180 / Math.PI), 2));//alfa
                            textBoxKątGamma.Text = Convert.ToString(Math.Round(gamma * (180 / Math.PI), 2));//gamma
                            textBoxWartośćA.Text = Convert.ToString(Math.Round(a, 2));//a
                        }
                    }
                    //b,c,gamma
                    else if (gammaToolStripMenuItem.Checked)
                    {
                        ConvertGamma(sender, e);
                        if (b <= 0 || c <= 0 || gamma <= 0 || gamma >= Math.PI)//obsługa błędów
                        {
                            erroryBBK(sender, e);
                            sprawdzenieB(sender, e);
                            sprawdzenieC(sender, e);
                            sprawdzenieGamma(sender, e);
                        }
                        else
                        {
                            beta = Math.Asin((b * Math.Sin(gamma)) / c);
                            alfa = Math.PI - beta - gamma;
                            a = Math.Sqrt((b * b + c * c) - (2 * b * c * Math.Cos(alfa)));
                            textBoxKątAlfa.Text = Convert.ToString(Math.Round(alfa * (180 / Math.PI), 2));//alfa
                            textBoxKątBeta.Text = Convert.ToString(Math.Round(beta * (180 / Math.PI), 2));//beta
                            textBoxWartośćA.Text = Convert.ToString(Math.Round(a, 2));//a
                        }
                    }
                }
                //poprawne rozwiązanie
                if (blad == false)
                {
                    double wynikab = ((a * a + b * b - c * c) / (2 * a * b));
                    double wynikac = (a * a + c * c - b * b) / (2 * a * c);
                    double wynikbc = (b * b + c * c - a * a) / (2 * b * c);
                    przypiszRysunek(sender, e);

                    if (a + b > c && b + c > a && a + c > b)//warunek trójkąta 
                    {
                        if (textBoxKątAlfa.Text == "90" || textBoxKątBeta.Text == "90" || textBoxKątGamma.Text == "90" ||
                            gamma == Math.PI / 2 || beta == Math.PI / 2 || alfa == Math.PI / 2 ||
                            wynikab == 0 || wynikac == 0 || wynikbc == 0)//warunek trójkąta prostokątnego
                        {
                            if (a == b || b == c || c == a||alfa == beta || alfa == gamma || beta == gamma)
                                labelWynik.Text = "Trójkąt prostokątny, równoramienny";
                            else
                                labelWynik.Text = "Trójkąt prostokątny";
                        }
                        else if (wynikab > 0 && wynikac > 0 && wynikbc > 0)//warunek trójkąta ostrokątnego
                        {
                            if (a == b || b == c || c == a||alfa == beta || alfa == gamma || beta == gamma)
                            {
                                if ((a == b || b == c || c == a) && (alfa == (Math.PI / 3) || beta == (Math.PI / 3) || gamma == (Math.PI / 3)))
                                    labelWynik.Text = "Trójkąt równoboczny";
                                else
                                    labelWynik.Text = "Trójkąt ostrokątny, równoramienny";
                            }
                            else
                                labelWynik.Text = "Trójkąt ostrokątny";
                        }
                        else if (alfa > (Math.PI / 2) || beta > (Math.PI / 2) || gamma > (Math.PI / 2))//warunek trójkąta rozwartokątnego
                        {
                            if (a == b || b == c || c == a || alfa ==beta ||alfa==gamma ||beta==gamma)
                                labelWynik.Text = "Trójkąt rozwartokątny, równoramienny";
                            else
                                labelWynik.Text = "Trójkąt rozwartokątny";
                        }
                        else
                            labelWynik.Text = "Coś jest nie tak";
                    }
                    else
                    {
                        erroryBBK(sender, e);
                        errorProviderBlad.SetError(labelWynik, "Musi być spełniony warunek trójkąta");
                    }
                }
            }
            //bok kąt kąt
            else if (bokKątKątToolStripMenuItem.Checked)
            {
                if (alfaibetaToolStripMenuItem.Checked)
                {
                    ConvertAlfa(sender, e);
                    ConvertBeta(sender, e);
                    //alfa,beta,a
                    if (aToolStripMenuItem.Checked)
                    {
                        ConvertA(sender, e);
                        if (a <= 0 || alfa <= 0 || alfa >= Math.PI || beta <= 0 || beta >= Math.PI || alfa + beta >= Math.PI)//obsługa błędów
                        {
                            erroryBKK(sender, e);
                            sprawdzenieAlfa(sender, e);
                            sprawdzenieBeta(sender, e);
                            sprawdzenieA(sender, e);

                            if (alfa + beta >= Math.PI)
                            {
                                errorProviderBlad.SetError(textBoxKątAlfa, "Suma kątów alfa i beta musi być między 0 a 180");
                                errorProviderBlad.SetError(textBoxKątBeta, "Suma kątów alfa i beta musi być między 0 a 180");
                            }
                        }
                        else
                        {
                            gamma = Math.PI - beta - alfa;
                            b = (a * Math.Sin(beta) / (Math.Sin(alfa)));
                            c = (a * Math.Sin(gamma) / (Math.Sin(alfa)));
                            textBoxKątGamma.Text = Convert.ToString(Math.Round(gamma * (180 / Math.PI), 2));//gamma
                            textBoxWartośćB.Text = Convert.ToString(Math.Round(b, 2));//b
                            textBoxWartośćC.Text = Convert.ToString(Math.Round(c, 2));//c
                        }
                    }
                    //alfa,beta,b
                    else if (bToolStripMenuItem.Checked)
                    {
                        ConvertB(sender, e);
                        if (b <= 0 || alfa <= 0 || alfa >= Math.PI || beta <= 0 || beta >= Math.PI || alfa + beta >= Math.PI)//obsługa błędów
                        {
                            erroryBKK(sender, e);
                            sprawdzenieAlfa(sender, e);
                            sprawdzenieBeta(sender, e);
                            sprawdzenieB(sender, e);

                            if (alfa + beta >= Math.PI)
                            {
                                errorProviderBlad.SetError(textBoxKątAlfa, "Suma kątów alfa i beta musi być między 0 a 180");
                                errorProviderBlad.SetError(textBoxKątBeta, "Suma kątów alfa i beta musi być między 0 a 180");
                            }
                        }
                        else
                        {
                            gamma = Math.PI - beta - alfa;
                            a = (b * Math.Sin(alfa) / (Math.Sin(beta)));
                            c = (b * Math.Sin(gamma) / (Math.Sin(beta)));
                            textBoxKątGamma.Text = Convert.ToString(Math.Round(gamma * (180 / Math.PI), 2));//gamma
                            textBoxWartośćA.Text = Convert.ToString(Math.Round(a, 2));//a
                            textBoxWartośćC.Text = Convert.ToString(Math.Round(c, 2));//c
                        }
                    }
                    //alfa,beta,c
                    else if (cToolStripMenuItem.Checked)
                    {
                        ConvertC(sender, e);
                        if (c <= 0 || alfa <= 0 || alfa >= Math.PI || beta <= 0 || beta >= Math.PI || alfa + beta >= Math.PI)//obsługa błędów
                        {
                            erroryBKK(sender, e);
                            sprawdzenieAlfa(sender, e);
                            sprawdzenieBeta(sender, e);
                            sprawdzenieC(sender, e);

                            if (alfa + beta >= Math.PI)
                            {
                                errorProviderBlad.SetError(textBoxKątAlfa, "Suma kątów alfa i beta musi być między 0 a 180");
                                errorProviderBlad.SetError(textBoxKątBeta, "Suma kątów alfa i beta musi być między 0 a 180");
                            }
                        }
                        else
                        {
                            gamma = Math.PI - beta - alfa;
                            a = (c * Math.Sin(alfa) / (Math.Sin(gamma)));
                            b = (c * Math.Sin(beta) / (Math.Sin(gamma)));
                            textBoxKątGamma.Text = Convert.ToString(Math.Round(gamma * (180 / Math.PI), 2));//gamma
                            textBoxWartośćA.Text = Convert.ToString(Math.Round(a, 2));//a
                            textBoxWartośćB.Text = Convert.ToString(Math.Round(b, 2));//c
                        }
                    }
                }
                else if(alfaigammaToolStripMenuItem.Checked)
                {
                    ConvertAlfa(sender, e);
                    ConvertGamma(sender, e);
                    //alfa,gamma,a
                    if (aToolStripMenuItem.Checked)
                    {
                        ConvertA(sender, e);
                        if (a <= 0 || alfa <= 0 || alfa >= Math.PI || gamma <= 0 || gamma >= Math.PI || alfa + gamma >= Math.PI)//obsługa błędów
                        {
                            erroryBKK(sender, e);
                            sprawdzenieAlfa(sender, e);
                            sprawdzenieGamma(sender, e);
                            sprawdzenieA(sender, e);

                            if (alfa + gamma >= Math.PI)
                            {
                                errorProviderBlad.SetError(textBoxKątAlfa, "Suma kątów alfa i gamma musi być między 0 a 180");
                                errorProviderBlad.SetError(textBoxKątGamma, "Suma kątów alfa i gamma musi być między 0 a 180");
                            }
                        }
                        else
                        {
                            beta = Math.PI - gamma - alfa;
                            b = (a * Math.Sin(beta) / (Math.Sin(alfa)));
                            c = (a * Math.Sin(gamma) / (Math.Sin(alfa)));
                            textBoxKątBeta.Text = Convert.ToString(Math.Round(beta * (180 / Math.PI), 2));//beta
                            textBoxWartośćB.Text = Convert.ToString(Math.Round(b, 2));//b
                            textBoxWartośćC.Text = Convert.ToString(Math.Round(c, 2));//c
                        }
                    }
                    //alfa,gamma,b
                    else if (bToolStripMenuItem.Checked)
                    {
                        ConvertB(sender, e);
                        if (b <= 0 || alfa <= 0 || alfa >= Math.PI || gamma <= 0 || gamma >= Math.PI || alfa + gamma >= Math.PI)//obsługa błędów
                        {
                            erroryBKK(sender, e);
                            sprawdzenieAlfa(sender, e);
                            sprawdzenieGamma(sender, e);
                            sprawdzenieB(sender, e);

                            if (alfa + gamma >= Math.PI)
                            {
                                errorProviderBlad.SetError(textBoxKątAlfa, "Suma kątów alfa i gamma musi być między 0 a 180");
                                errorProviderBlad.SetError(textBoxKątGamma, "Suma kątów alfa i gamma musi być między 0 a 180");
                            }
                        }
                        else
                        {
                            beta = Math.PI - gamma - alfa;
                            a = (b * Math.Sin(alfa) / (Math.Sin(beta)));
                            c = (b * Math.Sin(gamma) / (Math.Sin(beta)));
                            textBoxKątBeta.Text = Convert.ToString(Math.Round(beta * (180 / Math.PI), 2));//beta
                            textBoxWartośćA.Text = Convert.ToString(Math.Round(a, 2));//a
                            textBoxWartośćC.Text = Convert.ToString(Math.Round(c, 2));//c
                        }
                    }
                    //alfa,gamma,c
                    else if (cToolStripMenuItem.Checked)
                    {
                        ConvertC(sender, e);
                        if (c <= 0 || alfa <= 0 || alfa >= Math.PI || gamma <= 0 || gamma >= Math.PI || alfa + gamma >= Math.PI)//obsługa błędów
                        {
                            erroryBKK(sender, e);
                            sprawdzenieAlfa(sender, e);
                            sprawdzenieGamma(sender, e);
                            sprawdzenieC(sender, e);

                            if (alfa + gamma >= Math.PI)
                            {
                                errorProviderBlad.SetError(textBoxKątAlfa, "Suma kątów alfa i gamma musi być między 0 a 180");
                                errorProviderBlad.SetError(textBoxKątGamma, "Suma kątów alfa i gamma musi być między 0 a 180");
                            }
                        }
                        else
                        {
                            beta = Math.PI - gamma - alfa;
                            a = (c * Math.Sin(alfa) / (Math.Sin(gamma)));
                            b = (c * Math.Sin(beta) / (Math.Sin(gamma)));
                            textBoxKątBeta.Text = Convert.ToString(Math.Round(beta * (180 / Math.PI), 2));//beta
                            textBoxWartośćA.Text = Convert.ToString(Math.Round(a, 2));//a
                            textBoxWartośćB.Text = Convert.ToString(Math.Round(b, 2));//b
                        }
                    }
                }
                else if (betaigammaToolStripMenuItem.Checked)
                {
                    ConvertBeta(sender, e);
                    ConvertGamma(sender, e);
                    //beta,gamma,a
                    if (aToolStripMenuItem.Checked)
                    {
                        ConvertA(sender, e);
                        if (a <= 0 || beta <= 0 || beta >= Math.PI || gamma <= 0 || gamma >= Math.PI || beta + gamma >= Math.PI)//obsługa błędów
                        {
                            erroryBKK(sender, e);
                            sprawdzenieBeta(sender, e);
                            sprawdzenieGamma(sender, e);
                            sprawdzenieA(sender, e);

                            if (beta + gamma >= Math.PI)
                            {
                                errorProviderBlad.SetError(textBoxKątBeta, "Suma kątów beta i gamma musi być między 0 a 180");
                                errorProviderBlad.SetError(textBoxKątGamma, "Suma kątów beta i gamma musi być między 0 a 180");
                            }
                        }
                        else
                        {
                            alfa = Math.PI - gamma - beta;
                            b = (a * Math.Sin(beta) / (Math.Sin(alfa)));
                            c = (a * Math.Sin(gamma) / (Math.Sin(alfa)));
                            textBoxKątAlfa.Text = Convert.ToString(Math.Round(alfa * (180 / Math.PI), 2));//alfa
                            textBoxWartośćB.Text = Convert.ToString(Math.Round(b, 2));//b
                            textBoxWartośćC.Text = Convert.ToString(Math.Round(c, 2));//c
                        }
                    }
                    //beta,gamma,b
                    else if (bToolStripMenuItem.Checked)
                    {
                        ConvertB(sender, e);
                        if (b <= 0 || beta <= 0 || beta >= Math.PI || gamma <= 0 || gamma >= Math.PI || beta + gamma >= Math.PI)//obsługa błędów
                        {
                            erroryBKK(sender, e);
                            sprawdzenieBeta(sender, e);
                            sprawdzenieGamma(sender, e);
                            sprawdzenieB(sender, e);

                            if (beta + gamma >= Math.PI)
                            {
                                errorProviderBlad.SetError(textBoxKątBeta, "Suma kątów beta i gamma musi być między 0 a 180");
                                errorProviderBlad.SetError(textBoxKątGamma, "Suma kątów beta i gamma musi być między 0 a 180");
                            }
                        }
                        else
                        {
                            alfa = Math.PI - gamma - beta;
                            a = (b * Math.Sin(alfa) / (Math.Sin(beta)));
                            c = (b * Math.Sin(gamma) / (Math.Sin(beta)));
                            textBoxKątAlfa.Text = Convert.ToString(Math.Round(alfa * (180 / Math.PI), 2));//alfa
                            textBoxWartośćA.Text = Convert.ToString(Math.Round(a, 2));//a
                            textBoxWartośćC.Text = Convert.ToString(Math.Round(c, 2));//c
                        }
                    }
                    //beta,gamma,c
                    else if (cToolStripMenuItem.Checked)
                    {
                        ConvertC(sender, e);
                        if (c <= 0 || beta <= 0 || beta >= Math.PI || gamma <= 0 || gamma >= Math.PI || beta + gamma >= Math.PI)//obsługa błędów
                        {
                            erroryBKK(sender, e);
                            sprawdzenieBeta(sender, e);
                            sprawdzenieGamma(sender, e);
                            sprawdzenieC(sender, e);

                            if (beta + gamma >= Math.PI)
                            {
                                errorProviderBlad.SetError(textBoxKątBeta, "Suma kątów beta i gamma musi być między 0 a 180");
                                errorProviderBlad.SetError(textBoxKątGamma, "Suma kątów beta i gamma musi być między 0 a 180");
                            }
                        }
                        else
                        {
                            alfa = Math.PI - gamma - beta;
                            a = (c * Math.Sin(alfa) / (Math.Sin(gamma)));
                            b = (c * Math.Sin(beta) / (Math.Sin(gamma)));
                            textBoxKątAlfa.Text = Convert.ToString(Math.Round(alfa * (180 / Math.PI), 2));//alfa
                            textBoxWartośćA.Text = Convert.ToString(Math.Round(a, 2));//a
                            textBoxWartośćB.Text = Convert.ToString(Math.Round(b, 2));//c
                        }
                    }
                }
                //poprawne rozwiązanie
                if(blad == false)
                {
                        double wynikab = ((a * a + b * b - c * c) / (2 * a * b));
                        double wynikac = (a * a + c * c - b * b) / (2 * a * c);
                        double wynikbc = (b * b + c * c - a * a) / (2 * b * c);
                        przypiszRysunek(sender, e);

                        if (a + b > c && b + c > a && a + c > b)//warunek trójkąta 
                        {
                            if (textBoxKątAlfa.Text == "90" || textBoxKątBeta.Text == "90" || textBoxKątGamma.Text == "90" || 
                            wynikab == 0 || wynikac == 0 || wynikbc == 0 ||
                            gamma == Math.PI / 2 || beta == Math.PI / 2 || alfa == Math.PI / 2)//warunek trójkąta prostokątnego
                            {
                                if (alfa==beta||beta==gamma||alfa==gamma|| 
                                    a == b || b == c || a == c || 
                                    textBoxKątAlfa.Text == textBoxKątBeta.Text ||
                                    textBoxKątAlfa.Text == textBoxKątGamma.Text ||
                                    textBoxKątGamma.Text == textBoxKątBeta.Text)
                                        labelWynik.Text = "Trójkąt prostokątny, równoramienny";
                                else
                                    labelWynik.Text = "Trójkąt prostokątny";
                            }
                            else if (wynikab > 0 && wynikac > 0 && wynikbc > 0)//warunek trójkąta ostrokątnego
                            {
                                if (wynikab == wynikac || wynikac == wynikbc || wynikab == wynikbc ||
                                    alfa==beta || beta==gamma || alfa==gamma ||
                                    textBoxKątAlfa.Text == textBoxKątBeta.Text ||
                                    textBoxKątAlfa.Text == textBoxKątGamma.Text ||
                                    textBoxKątGamma.Text == textBoxKątBeta.Text)
                                {
                                    if ((alfa == (Math.PI / 3) && beta == (Math.PI / 3)) || 
                                        (alfa == (Math.PI / 3) && gamma == (Math.PI / 3)) ||
                                        (beta == (Math.PI / 3) && gamma == (Math.PI / 3)))
                                            labelWynik.Text = "Trójkąt równoboczny";
                                    else
                                        labelWynik.Text = "Trójkąt ostrokątny, równoramienny";
                                }
                                else
                                    labelWynik.Text = "Trójkąt ostrokątny";
                            }
                            else if (wynikab < 0 || wynikac < 0 || wynikbc < 0)//warunek trójkąta rozwartokątnego
                            {
                                if (wynikab == wynikac || wynikac == wynikbc || wynikab == wynikbc ||
                                    alfa == beta || beta == gamma || alfa == gamma||
                                    a==b||b==c||a==c||textBoxKątAlfa.Text==textBoxKątBeta.Text||
                                    textBoxKątAlfa.Text == textBoxKątGamma.Text||
                                    textBoxKątGamma.Text == textBoxKątBeta.Text)
                                        labelWynik.Text = "Trójkąt rozwartokątny, równoramienny";
                                else
                                    labelWynik.Text = "Trójkąt rozwartokątny";
                            }
                        }
                        else
                        {
                            erroryBKK(sender, e);
                            errorProviderBlad.SetError(labelWynik, "Musi być spełniony warunek trójkąta");
                        }
                    }
            }
            if (takToolStripMenuItem.Checked && blad == true)
                errorProviderBlad.SetError(panelRysowanie, "Aby pojawił się rysunek, musisz wprowadzić odpowiednie dane");
            else if (takToolStripMenuItem.Checked && blad == false)
            {
                c1 = Double.Parse(textBoxWartośćC.Text);
                a1 = Double.Parse(textBoxWartośćA.Text);
                beta1 = Convert.ToDouble(textBoxKątBeta.Text);
                panelRysowanie.Refresh();
            }
            if (comboBoxFunkcje.Visible == true)
                trygonometria(sender, e);
        }

        private void FormTypyTrójkątów_Load(object sender, EventArgs e)
        {

        }

        private void przykładoweBokiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ątnyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //kliknięcie Trójkąta prostokątnego - 1
        private void przykład1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bokbokbokToolStripMenuItem.Checked)
            {
                textBoxWartośćA.Text = "6";
                textBoxWartośćB.Text = "8";
                textBoxWartośćC.Text = "10";
            }
            else if(bokBokKątToolStripMenuItem.Checked)
            {
                if (aibToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "6";
                    textBoxWartośćB.Text = "12";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "30";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "90";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "60";
                }
                else if (aicToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "5";
                    textBoxWartośćC.Text = "10";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "30";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "60";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "90";
                }
                else if (bicToolStripMenuItem.Checked)
                {
                    textBoxWartośćB.Text = "4";
                    textBoxWartośćC.Text = "8";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "60";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "30";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "90";
                }

            }
            else
            {
                if (alfaibetaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "90";
                    textBoxKątBeta.Text = "60";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "5";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "3";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "7,5";
                }
                else if (alfaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "40";
                    textBoxKątGamma.Text = "50";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "9";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "4";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "6";
                }
                else if (betaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątBeta.Text = "20";
                    textBoxKątGamma.Text = "90";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "9";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "2";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "10";
                }
            }

        }
        //kliknięcie Trójkąta prostokątnego - 2
        private void przykład2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bokbokbokToolStripMenuItem.Checked)
            {
                textBoxWartośćA.Text = "5";
                textBoxWartośćB.Text = "12";
                textBoxWartośćC.Text = "13";
            }
            else if (bokBokKątToolStripMenuItem.Checked)
            {
                if (aibToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "5";
                    textBoxWartośćB.Text = "5";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "45";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "45";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "90";
                }
                else if (aicToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "4";
                    textBoxWartośćC.Text = "4";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "45";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "90";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "45";
                }
                else if (bicToolStripMenuItem.Checked)
                {
                    textBoxWartośćB.Text = "6";
                    textBoxWartośćC.Text = "6";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "90";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "45";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "45";
                }
            }
            else
            {
                if (alfaibetaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "90";
                    textBoxKątBeta.Text = "45";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "3";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "7";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "5";
                }
                else if (alfaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "45";
                    textBoxKątGamma.Text = "45";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "3";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "6";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "5";
                }
                else if (betaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątBeta.Text = "45";
                    textBoxKątGamma.Text = "45";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "2";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "6";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "10";
                }
            }
        }
        //kliknięcie Trójkąta rozwartokątnego
        private void rozwartokątnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bokbokbokToolStripMenuItem.Checked)
            {
                textBoxWartośćA.Text = "2";
                textBoxWartośćB.Text = "3";
                textBoxWartośćC.Text = "4";
            }
            else if (bokBokKątToolStripMenuItem.Checked)
            {
                if (aibToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "10";
                    textBoxWartośćB.Text = "8";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "100";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "30";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "130";
                }
                else if (aicToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "5";
                    textBoxWartośćC.Text = "7";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "25";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "40";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "120";
                }
                else if (bicToolStripMenuItem.Checked)
                {
                    textBoxWartośćB.Text = "4";
                    textBoxWartośćC.Text = "9";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "40";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "20";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "60";
                }
            }
            else
            {
                if (alfaibetaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "40";
                    textBoxKątBeta.Text = "110";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "4";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "6";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "10";
                }
                else if (alfaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "20";
                    textBoxKątGamma.Text = "60";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "4";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "7";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "5";
                }
                else if (betaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątBeta.Text = "120";
                    textBoxKątGamma.Text = "50";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "1";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "7";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "5";
                }
            }
        }
        //kliknięcie Trójkąta ostrokątnego
        private void ostrokątnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bokbokbokToolStripMenuItem.Checked)
            {
                textBoxWartośćA.Text = "4";
                textBoxWartośćB.Text = "6";
                textBoxWartośćC.Text = "7";
            }
            else if (bokBokKątToolStripMenuItem.Checked)
            {
                if (aibToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "5";
                    textBoxWartośćB.Text = "6";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "50";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "60";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "60";
                }
                else if (aicToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "3,7";
                    textBoxWartośćC.Text = "3,2";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "55";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "60";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "45";
                }
                else if (bicToolStripMenuItem.Checked)
                {
                    textBoxWartośćB.Text = "6";
                    textBoxWartośćC.Text = "4";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "80";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "65";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "40";
                }
            }
            else
            {
                if (alfaibetaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "60";
                    textBoxKątBeta.Text = "40";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "5";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "3";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "10";
                }
                else if (alfaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "30";
                    textBoxKątGamma.Text = "80";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "6";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "3";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "8";
                }
                else if (betaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątBeta.Text = "55";
                    textBoxKątGamma.Text = "80";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "7";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "4";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "6";
                }
            }
        }

        private void równoramiennyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //kliknięcie Trójkąta równoramiennego rozwartokątnego
        private void rozwartokątnyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (bokbokbokToolStripMenuItem.Checked)
            {
                textBoxWartośćA.Text = "4";
                textBoxWartośćB.Text = "7";
                textBoxWartośćC.Text = "4";
            }
            else if (bokBokKątToolStripMenuItem.Checked)
            {
                if (aibToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "5";
                    textBoxWartośćB.Text = "5";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "30";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "30";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "120";
                }
                else if (aicToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "6";
                    textBoxWartośćC.Text = "6";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "40";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "100";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "40";
                }
                else if (bicToolStripMenuItem.Checked)
                {
                    textBoxWartośćB.Text = "3";
                    textBoxWartośćC.Text = "3";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "150";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "15";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "15";
                }
            }
            else
            {
                if (alfaibetaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "30";
                    textBoxKątBeta.Text = "30";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "3";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "5";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "7";
                }
                else if (alfaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "40";
                    textBoxKątGamma.Text = "40";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "4";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "8";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "5";
                }
                else if (betaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątBeta.Text = "150";
                    textBoxKątGamma.Text = "15";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "5";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "7";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "3";
                }
            }
        }
        //kliknięcie Trójkąta równoramiennego ostrokątnego
        private void ostrokątnyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (bokbokbokToolStripMenuItem.Checked)
            {
                textBoxWartośćA.Text = "7";
                textBoxWartośćB.Text = "5";
                textBoxWartośćC.Text = "5";
            }
            else if (bokBokKątToolStripMenuItem.Checked)
            {
                if (aibToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "3";
                    textBoxWartośćB.Text = "3";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "50";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "50";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "80";
                }
                else if (aicToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "5";
                    textBoxWartośćC.Text = "5";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "80";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "20";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "80";
                }
                else if (bicToolStripMenuItem.Checked)
                {
                    textBoxWartośćB.Text = "4";
                    textBoxWartośćC.Text = "4";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "40";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "40";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "70";
                }
            }
            else
            {
                if(alfaibetaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "70";
                    textBoxKątBeta.Text = "40";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "6";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "5";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "7";
                }
                else if (alfaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "65";
                    textBoxKątGamma.Text = "50";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "4";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "8";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "5";
                }
                else if (betaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątBeta.Text = "80";
                    textBoxKątGamma.Text = "20";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "5";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "7";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "3";
                }
            }
        }
        //kliknięcie Trójkąta równobocznego
        private void równobocznyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bokbokbokToolStripMenuItem.Checked)
            {
                textBoxWartośćA.Text = "6";
                textBoxWartośćB.Text = "6";
                textBoxWartośćC.Text = "6";
            }
            else if (bokBokKątToolStripMenuItem.Checked)
            {
                if (aibToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "6";
                    textBoxWartośćB.Text = "6";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "60";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "60";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "60";
                }
                else if (aicToolStripMenuItem.Checked)
                {
                    textBoxWartośćA.Text = "4";
                    textBoxWartośćC.Text = "4";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "60";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "60";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "60";
                }
                else if (bicToolStripMenuItem.Checked)
                {
                    textBoxWartośćB.Text = "8";
                    textBoxWartośćC.Text = "8";
                    if (alfaToolStripMenuItem.Checked)
                        textBoxKątAlfa.Text = "60";
                    else if (betaToolStripMenuItem.Checked)
                        textBoxKątBeta.Text = "60";
                    else if (gammaToolStripMenuItem.Checked)
                        textBoxKątGamma.Text = "60";
                }
            }
            else
            {
                if(alfaibetaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "60";
                    textBoxKątBeta.Text = "60";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "3";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "3";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "3";
                }
                else if (alfaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątAlfa.Text = "60";
                    textBoxKątGamma.Text = "60";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "3";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "3";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "3";
                }
                else if (betaigammaToolStripMenuItem.Checked)
                {
                    textBoxKątBeta.Text = "60";
                    textBoxKątGamma.Text = "60";
                    if (aToolStripMenuItem.Checked)
                        textBoxWartośćA.Text = "3";
                    else if (bToolStripMenuItem.Checked)
                        textBoxWartośćB.Text = "3";
                    else if (cToolStripMenuItem.Checked)
                        textBoxWartośćC.Text = "3";
                }
            }
        }
        
        //kliknięcie BBB
        private void bokbokbokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errory(sender, e);
            zmianaBoki(sender, e);
            zmianaKąt(sender, e);
            bokbokbokToolStripMenuItem.CheckState = CheckState.Checked;
            bokBokKątToolStripMenuItem.CheckState = CheckState.Unchecked;
            bokKątKątToolStripMenuItem.CheckState = CheckState.Unchecked;
            //czy można wpisać,wartości,rodzaj tła,kursory
            zmianaTextBoxuA(sender, e);
            zmianaTextBoxuB(sender, e);
            zmianaTextBoxuC(sender, e);
            textBoxWartośćB.Text = "4";
            textBoxWartośćC.Text = "5";
            bokiIKątToolStripMenuItem.Visible = false;
            kątyIBokToolStripMenuItem.Visible = false;
        }
        //kliknięcie BBK
        private void bokBokKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errory(sender, e);
            zmianaBoki(sender, e);
            zmianaKąt(sender, e);
            bokBokKątToolStripMenuItem.CheckState = CheckState.Checked;
            bokbokbokToolStripMenuItem.CheckState = CheckState.Unchecked;
            bokKątKątToolStripMenuItem.CheckState = CheckState.Unchecked;
            //czy można wpisać,wartości,rodzaj tła,kursory
            zmianaTextBoxuA(sender, e);
            zmianaTextBoxuB(sender, e);
            zmianaTextBoxuGamma(sender, e);
            bokiIKątToolStripMenuItem.Visible = true;
            kątyIBokToolStripMenuItem.Visible = false;
            aibToolStripMenuItem.CheckState = CheckState.Checked;
            gammaToolStripMenuItem.CheckState = CheckState.Checked;

        }
        //kliknięcie BKK
        private void bokKątKątToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errory(sender, e);
            zmianaBok(sender, e);
            zmianaKąty(sender, e);
            bokKątKątToolStripMenuItem.CheckState = CheckState.Checked;
            bokbokbokToolStripMenuItem.CheckState = CheckState.Unchecked;
            bokBokKątToolStripMenuItem.CheckState = CheckState.Unchecked;
            //czy można wpisać,wartości,rodzaj tła,kursory
            zmianaTextBoxuA(sender, e);
            zmianaTextBoxuBeta(sender, e);
            zmianaTextBoxuGamma(sender, e);
            bokiIKątToolStripMenuItem.Visible = false;
            kątyIBokToolStripMenuItem.Visible = true;
            betaigammaToolStripMenuItem.CheckState = CheckState.Checked;
            aToolStripMenuItem.CheckState = CheckState.Checked;
        }
        
        ///kliknięcie ukryj rysunek
        private void ukryjNaRysunkuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ukryjNaRysunkuToolStripMenuItem.CheckState = CheckState.Checked;
            pokażNaRysunkuToolStripMenuItem.CheckState = CheckState.Unchecked;
            textBoxRysunekBokA.Visible = false;
            textBoxRysunekBokB.Visible = false;
            textBoxRysunekBokC.Visible = false;
            textBoxRysunekAlfa.Visible = false;
            textBoxRysunekBeta.Visible = false;
            textBoxRysunekGamma.Visible = false;
        }
        ///kliknięcie pokaż rysunek
        private void pokażNaRysunkuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pokażNaRysunkuToolStripMenuItem.CheckState = CheckState.Checked;
            ukryjNaRysunkuToolStripMenuItem.CheckState = CheckState.Unchecked;
            textBoxRysunekBokA.Visible = true;
            textBoxRysunekBokB.Visible = true;
            textBoxRysunekBokC.Visible = true;
            textBoxRysunekAlfa.Visible = true;
            textBoxRysunekBeta.Visible = true;
            textBoxRysunekGamma.Visible = true;
        }
        ///kliknięcie pokaż trygonometrię
        private void pokażToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pokażToolStripMenuItem.CheckState = CheckState.Checked;
            ukryjToolStripMenuItem.CheckState = CheckState.Unchecked;
            comboBoxFunkcje.Visible = true;
            comboBoxRodzajKąta.Visible = true;
            labelZnakRówności.Visible = true;
            textBoxWynikFunkcji.Visible = true;
            buttonLicz.Location = new Point(255, 268);
            buttonLicz_Click(sender, e);
        }
        ///kliknięcie ukryj trygonometrię
        private void ukryjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ukryjToolStripMenuItem.CheckState = CheckState.Checked;
            pokażToolStripMenuItem.CheckState = CheckState.Unchecked;
            comboBoxFunkcje.Visible = false;
            comboBoxRodzajKąta.Visible = false;
            labelZnakRówności.Visible = false;
            textBoxWynikFunkcji.Visible = false;
            buttonLicz.Location=new Point(313, 267);
        }
        ///kliknięcie ukryj panel
        private void nieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nieToolStripMenuItem.CheckState = CheckState.Checked;
            takToolStripMenuItem.CheckState = CheckState.Unchecked;
            panelRysowanie.Visible = false;
        }
        ///kliknięcie pokaż panel
        private void takToolStripMenuItem_Click(object sender, EventArgs e)
        {
            takToolStripMenuItem.CheckState = CheckState.Checked;
            nieToolStripMenuItem.CheckState = CheckState.Unchecked;
            panelRysowanie.Visible = true;
            if (blad == true)
                errorProviderBlad.SetError(panelRysowanie, "Aby pojawił się rysunek, musisz wprowadzić odpowiednie dane");
            else if (blad == false)
            {
                buttonLicz_Click(sender, e);
                c1 = Double.Parse(textBoxWartośćC.Text);
                a1 = Double.Parse(textBoxWartośćA.Text);
                beta1 = Convert.ToDouble(textBoxKątBeta.Text);
            }
        }

        //kliknięcie a i b
        private void bokAIBokBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmianaBoki(sender, e);
            aibToolStripMenuItem.CheckState = CheckState.Checked;
            zmianaTextBoxuA(sender, e);
            zmianaTextBoxuB(sender, e);
        }
        //kliknięcie a i c
        private void aicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmianaBoki(sender, e);
            aicToolStripMenuItem.CheckState = CheckState.Checked;
            zmianaTextBoxuA(sender, e);
            zmianaTextBoxuC(sender, e);
        }
        //kliknięcie b i c
        private void bicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmianaBoki(sender, e);
            bicToolStripMenuItem.CheckState = CheckState.Checked;
            zmianaTextBoxuB(sender, e);
            zmianaTextBoxuC(sender, e);
        }
        //kliknięcie alfa
        private void alfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmianaKąt(sender, e);
            alfaToolStripMenuItem.CheckState = CheckState.Checked;
            zmianaTextBoxuAlfa(sender, e);
        }
        //kliknięcie beta
        private void betaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmianaKąt(sender, e);
            betaToolStripMenuItem.CheckState = CheckState.Checked;
            zmianaTextBoxuBeta(sender, e);
        }
        //kliknięcie gamma
        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmianaKąt(sender, e);
            gammaToolStripMenuItem.CheckState = CheckState.Checked;
            zmianaTextBoxuGamma(sender, e);
        }

        //kliknięcie a
        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmianaBok(sender, e);
            aToolStripMenuItem.CheckState = CheckState.Checked;
            zmianaTextBoxuA(sender, e);
        }
        //kliknięcie b
        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmianaBok(sender, e);
            bToolStripMenuItem.CheckState = CheckState.Checked;
            zmianaTextBoxuB(sender, e);
        }
        //kliknięcie c
        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmianaBok(sender, e);
            cToolStripMenuItem.CheckState = CheckState.Checked;
            zmianaTextBoxuC(sender, e);
        }
        //kliknięcie alfa i beta
        private void alfaibetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmianaKąty(sender, e);
            alfaibetaToolStripMenuItem.CheckState = CheckState.Checked;
            zmianaTextBoxuAlfa(sender, e);
            zmianaTextBoxuBeta(sender, e);
        }
        //kliknięcie alfa i gamma
        private void alfaigammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmianaKąty(sender, e);
            alfaigammaToolStripMenuItem.CheckState = CheckState.Checked;
            zmianaTextBoxuAlfa(sender, e);
            zmianaTextBoxuGamma(sender, e);
        }
        //kliknięcie beta i gamma
        private void betaigammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zmianaKąty(sender, e);
            betaigammaToolStripMenuItem.CheckState = CheckState.Checked;
            zmianaTextBoxuBeta(sender, e);
            zmianaTextBoxuGamma(sender, e);
        }

        ///zmiana A
        private void textBoxWartośćA_TextChanged(object sender, EventArgs e)//zmiana wartości A
        {
            errory(sender, e);
            pustyRysunek(sender, e);
            opcjeWyszukiwaniaBBB(sender, e);
            //BBK
            opcjeWyszukiwaniaBBKabalfa(sender, e);
            opcjeWyszukiwaniaBBKabbeta(sender, e);
            opcjeWyszukiwaniaBBKabgamma(sender, e);
            opcjeWyszukiwaniaBBKacalfa(sender, e);
            opcjeWyszukiwaniaBBKacbeta(sender, e);
            opcjeWyszukiwaniaBBKacgamma(sender, e);
            //BKK
            opcjeWyszukiwaniaBKKalfabetaa(sender, e);
            opcjeWyszukiwaniaBKKalfagammaa(sender, e);
            opcjeWyszukiwaniaBKKbetagammaa(sender, e);
            labelWynik.Text = "";
        }
        ///zmiana B
        private void textBoxWartośćB_TextChanged(object sender, EventArgs e) //zmiana wartości B
        {
            errory(sender, e);
            pustyRysunek(sender, e);
            opcjeWyszukiwaniaBBB(sender, e);
            //BBK
            opcjeWyszukiwaniaBBKabalfa(sender, e);
            opcjeWyszukiwaniaBBKabbeta(sender, e);
            opcjeWyszukiwaniaBBKabgamma(sender, e);
            opcjeWyszukiwaniaBBKbcalfa(sender, e);
            opcjeWyszukiwaniaBBKbcbeta(sender, e);
            opcjeWyszukiwaniaBBKbcgamma(sender, e);
            //BKK
            opcjeWyszukiwaniaBKKalfabetab(sender, e);
            opcjeWyszukiwaniaBKKalfagammab(sender, e);
            opcjeWyszukiwaniaBKKbetagammab(sender, e);
            labelWynik.Text = "";
        }
        ///zmiana C
        private void textBoxWartośćC_TextChanged(object sender, EventArgs e)//zmiana wartości C
        {
            errory(sender, e);
            pustyRysunek(sender, e);
            opcjeWyszukiwaniaBBB(sender, e);
            //BBK
            opcjeWyszukiwaniaBBKacalfa(sender, e);
            opcjeWyszukiwaniaBBKacbeta(sender, e);
            opcjeWyszukiwaniaBBKacgamma(sender, e);
            opcjeWyszukiwaniaBBKbcalfa(sender, e);
            opcjeWyszukiwaniaBBKbcbeta(sender, e);
            opcjeWyszukiwaniaBBKbcgamma(sender, e);
            //BKK
            opcjeWyszukiwaniaBKKalfabetac(sender, e);
            opcjeWyszukiwaniaBKKalfagammac(sender, e);
            opcjeWyszukiwaniaBKKbetagammac(sender, e);
            labelWynik.Text = "";
        }
        
        ///zmiana alfa
        private void textBoxKątAlfa_TextChanged(object sender, EventArgs e)
        {
            //BBK
            opcjeWyszukiwaniaBBKabalfa(sender, e);
            opcjeWyszukiwaniaBBKacalfa(sender, e);
            opcjeWyszukiwaniaBBKbcalfa(sender, e);
            //BKK
            opcjeWyszukiwaniaBKKalfabetaa(sender, e);
            opcjeWyszukiwaniaBKKalfagammaa(sender, e);
            opcjeWyszukiwaniaBKKalfabetab(sender, e);
            opcjeWyszukiwaniaBKKalfagammab(sender, e);
            opcjeWyszukiwaniaBKKalfabetac(sender, e);
            opcjeWyszukiwaniaBKKalfagammac(sender, e);
        }
        ///zmiana beta
        private void textBoxKątBeta_TextChanged(object sender, EventArgs e)//zmiana kąta beta
        {
            errory(sender, e);
            pustyRysunek(sender, e);
            //BBK
            opcjeWyszukiwaniaBBKabbeta(sender, e);
            opcjeWyszukiwaniaBBKacbeta(sender, e);
            opcjeWyszukiwaniaBBKbcbeta(sender, e);
            //BKK
            opcjeWyszukiwaniaBKKalfabetaa(sender, e);
            opcjeWyszukiwaniaBKKalfabetab(sender, e);
            opcjeWyszukiwaniaBKKalfabetac(sender, e);
            opcjeWyszukiwaniaBKKbetagammaa(sender, e);
            opcjeWyszukiwaniaBKKbetagammab(sender, e);
            opcjeWyszukiwaniaBKKbetagammac(sender, e);
            labelWynik.Text = "";
        }
        ///zmiana gamma
        private void textBoxKątGamma_TextChanged(object sender, EventArgs e)//zmiana kąta gamma
        {
            errory(sender, e);
            pustyRysunek(sender, e);
            //BBK
            opcjeWyszukiwaniaBBKabgamma(sender, e);
            opcjeWyszukiwaniaBBKacgamma(sender, e);
            opcjeWyszukiwaniaBBKbcgamma(sender, e);
            //BKK
            opcjeWyszukiwaniaBKKalfagammaa(sender, e);
            opcjeWyszukiwaniaBKKalfagammab(sender, e);
            opcjeWyszukiwaniaBKKalfagammac(sender, e);
            opcjeWyszukiwaniaBKKbetagammaa(sender, e);
            opcjeWyszukiwaniaBKKbetagammab(sender, e);
            opcjeWyszukiwaniaBKKbetagammac(sender, e);
            labelWynik.Text = "";
        }
        
        //Klawisz Enter
        private void textBoxWartośćA_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxWartośćA.ReadOnly == false)
            {
                if (e.KeyCode == Keys.Enter)
                    buttonLicz.PerformClick();
            }
        }

        private void textBoxWartośćB_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxWartośćB.ReadOnly == false)
            {
                if (e.KeyCode == Keys.Enter)
                    buttonLicz.PerformClick();
            }
        }

        private void textBoxWartośćC_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxWartośćC.ReadOnly == false)
            {
                if (e.KeyCode == Keys.Enter)
                    buttonLicz.PerformClick();
            }
        }

        private void textBoxKątAlfa_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxKątAlfa.ReadOnly == false)
            {
                if (e.KeyCode == Keys.Enter)
                    buttonLicz.PerformClick();
            }
        }

        private void textBoxKątBeta_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxKątBeta.ReadOnly == false)
            {
                if (e.KeyCode == Keys.Enter)
                    buttonLicz.PerformClick();
            }
        }

        private void textBoxKątGamma_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxKątGamma.ReadOnly == false)
            {
                if (e.KeyCode == Keys.Enter)
                    buttonLicz.PerformClick();
            }
        }


        //message boxy
        //1
        private void jakUruchomićProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program możesz uruchomić klikając przycisk Licz lub wciskając klawisz Enter na swojej klawiaturze." +
                " Dzięki temu aplikacja błyskawicznie policzy wszystko czego pragniesz.");
        }

        //2
        private void coToSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sekans - odwrotność cosinusa. Cosekans - odwrotność sinusa.");
        }
        //3
        private void inneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("W przypadku innych pytań, zgłaszania błędów lub nowych pomysłów," +
                "proszę kontaktować się przez adres e-mail: kubeusz007@gmail.com, w tematcie: Typy Trójkątów");
        }
        //4
        private void oProjekcieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2.Show();
        }
        //5
        private void twórcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Kuba Banach - Maj 2020");
        }

        private void opcjeWpisywaniaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //comboBoxy
        private void comboBoxFunkcje_SelectedIndexChanged(object sender, EventArgs e)
        {
            trygonometria(sender, e);
        }

        private void comboBoxRodzajKąta_SelectedIndexChanged(object sender, EventArgs e)
        {
            trygonometria(sender, e);
        }

        //rysowanie
        private void panelRysowanie_Paint(object sender, PaintEventArgs e)
        {
            if ((panelRysowanie.Visible == true) && (blad == false))
            {
                g = panelRysowanie.CreateGraphics();
                drawLine();
            }
        }
        private void zamknijProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
