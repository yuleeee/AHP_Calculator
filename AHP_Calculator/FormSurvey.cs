﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AHP_Calculator
{
    public partial class FormSurvey : Form
    {
        private Label[] labelQuestions;
        public string[,] pairWiseMatrix;
        private string[] factors;
        private string parentFactor;
        private int[] compairIndex;
        private Font defaultFont = new Font(new FontFamily("微软雅黑"), 12, new FontStyle());
        public FormSurvey(string[] factors, string parentFactor)
        {
            InitializeComponent();
            this.factors = factors;
            this.parentFactor = parentFactor;
            labelQuestions = new Label[factors.Length * (factors.Length - 1) / 2];
            pairWiseMatrix = new string[factors.Length, factors.Length];
            //generate what to compare
            compairIndex = new int[labelQuestions.Length * 2];
            int counter = 0;
            for (int i = 1; i <= factors.Length - 1; i++)
            {
                for (int j = i + 1; j <= factors.Length; j++)
                {
                    compairIndex[counter] = j;
                    compairIndex[counter + 1] = i;
                    counter += 2;
                }
            }
        }

        private void FormSurvey_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < labelQuestions.Length; i++)
            {
                labelQuestions[i] = new Label
                {
                    Text = "Consider two factors: " + factors[compairIndex[2 * i] - 1] + " and " + factors[compairIndex[2 * i + 1] - 1] +
                    ", which one is more important in " + parentFactor + "? How many times more important?",
                    AutoSize = true,
                    Font = defaultFont
                };
                flowLayoutPanel1.Controls.Add(labelQuestions[i]);
            }
        }
    }
}