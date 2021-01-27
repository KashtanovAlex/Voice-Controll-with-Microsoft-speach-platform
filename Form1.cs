using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;

namespace SpeechRecognition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static Label l;

        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence > 0.7) l.Text = e.Result.Text;
        }	
        
        private void Form1_Shown(object sender, EventArgs e)
        {
            l = label1;
            
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-EN");
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci);
            sre.SetInputToDefaultAudioDevice();
          
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
          

            Choices numbers = new Choices();
            numbers.Add(new string[] { "one", "two", "three", "alexandr", "Vlad eats banana", "misha"});

   
            GrammarBuilder gb = new GrammarBuilder();
            gb.Culture = ci;
            gb.Append(numbers);


            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);

            sre.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (label1.Text == "three")
            {
                if(button3.BackColor==Color.Green)
                button3.BackColor = Color.Red;
                else
                button3.BackColor = Color.Green;
            }
            if (label1.Text == "two")
            {
                if (button2.BackColor == Color.Green)
                    button2.BackColor = Color.Red;
                else
                    button2.BackColor = Color.Green;
            }
            if (label1.Text == "one")
            {
                if (button1.BackColor == Color.Green)
                    button1.BackColor = Color.Red;
                else
                    button1.BackColor = Color.Green;
            }

        }
    }
}
