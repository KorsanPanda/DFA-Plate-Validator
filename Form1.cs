using System;
using System.Drawing;
using System.Windows.Forms;

namespace odev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKontrol_Click(object sender, EventArgs e)
        {
            // Eğer "txtPlaka adı mevcut değil" hatası alırsan;
            // Tasarım ekranında TextBox'ın (Name) kısmını kontrol et.
            string girilenPlaka = txtPlaka.Text.ToUpper();

            bool sonuc = PlakaDFA.Dogrula(girilenPlaka);

            if (sonuc)
            {
                lblSonuc.Text = "GEÇERLİ PLAKA";
                lblSonuc.ForeColor = Color.Green;
            }
            else
            {
                lblSonuc.Text = "GEÇERSİZ PLAKA";
                lblSonuc.ForeColor = Color.Red;
            }
        }

        private void lblSonuc_Click(object sender, EventArgs e)
        {

        }
    }

    // --- DFA MOTORU (Form1 sınıfının dışında ama namespace içinde) ---
    public static class PlakaDFA
    {
        enum State
        {
            q0, q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, qHata
        }

        public static bool Dogrula(string input)
        {
            State currentState = State.q0;

            foreach (char c in input)
            {
                bool isDigit = Char.IsDigit(c);
                bool isLetter = Char.IsLetter(c);
                bool isSpace = (c == ' ');

                switch (currentState)
                {
                    case State.q0: // Başlangıç -> Rakam
                        if (isDigit) currentState = State.q1;
                        else currentState = State.qHata;
                        break;

                    case State.q1: // Rakam -> Rakam
                        if (isDigit) currentState = State.q2;
                        else currentState = State.qHata;
                        break;

                    case State.q2: // Rakam -> Boşluk (Şehir bitti)
                        if (isSpace) currentState = State.q3;
                        else currentState = State.qHata;
                        break;

                    case State.q3: // Boşluk -> Harf
                        if (isLetter) currentState = State.q4;
                        else currentState = State.qHata;
                        break;

                    case State.q4: // Harf -> Harf veya Boşluk
                        if (isLetter) currentState = State.q5;
                        else if (isSpace) currentState = State.q7;
                        else currentState = State.qHata;
                        break;

                    case State.q5: // Harf -> Harf veya Boşluk
                        if (isLetter) currentState = State.q6;
                        else if (isSpace) currentState = State.q7;
                        else currentState = State.qHata;
                        break;

                    case State.q6: // Harf -> Boşluk (Max 3 harf bitti)
                        if (isSpace) currentState = State.q7;
                        else currentState = State.qHata;
                        break;

                    case State.q7: // Boşluk -> Rakam (Son kısım başlıyor)
                        if (isDigit) currentState = State.q8;
                        else currentState = State.qHata;
                        break;

                    case State.q8: // Rakam -> Rakam (Kabul)
                        if (isDigit) currentState = State.q9;
                        else currentState = State.qHata;
                        break;

                    case State.q9: // Rakam -> Rakam (Kabul)
                        if (isDigit) currentState = State.q10;
                        else currentState = State.qHata;
                        break;

                    case State.q10: // Rakam -> Rakam (Kabul)
                        if (isDigit) currentState = State.q11;
                        else currentState = State.qHata;
                        break;

                    case State.q11: // Rakam (Son) -> Hata (Fazla karakter)
                        currentState = State.qHata;
                        break;

                    case State.qHata:
                        return false;
                }
            }

            // Döngü bittiğinde kabul durumunda mıyız?
            if (currentState == State.q8 ||
                currentState == State.q9 ||
                currentState == State.q10 ||
                currentState == State.q11)
            {
                return true;
            }

            return false;
        }
    }
}