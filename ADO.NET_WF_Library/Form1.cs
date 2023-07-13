using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using ADO.NET_WF_Library.Model;


namespace ADO.NET_WF_Library 
{
    public partial class Form1 : Form
    {


        Model.Controller controller;



        public Form1()
        {
            InitializeComponent();
            dataSet = new DataSet();
            controller = new Model.Controller();
            //! эти настройки небходимо делат ьв контроллере?  Если да - как , если нет - ок

            //controller.adapter.Fill(dataSet, "Category");
            //controller.adapter.Fill(dataSet, "Author");
            //dataGrid.DataSource = dataSet.Tables["Author"].DefaultView;




            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 0)
            {
                button2.Enabled = false;
            }
            else button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            controller.SearchByName(textBox1.Text);
            controller.adapter.Fill(dataSet, "Books");
            dataGrid.DataSource = null;
            dataGrid.DataSource = dataSet.Tables["Books"].DefaultView;
            textBox1.Text = "";

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                button3.Enabled = false;
            }
            else button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            controller.SearchByAuthorSurname(textBox2.Text);
            controller.adapter.Fill(dataSet, "Books");
            dataGrid.DataSource = null;
            dataGrid.DataSource = dataSet.Tables["Books"].DefaultView;
            textBox2.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {
                button4.Enabled = false;
            }
            else button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            controller.SearchByAuthorCategory(textBox3.Text);
            controller.adapter.Fill(dataSet, "Books");
            dataGrid.DataSource = null;
            dataGrid.DataSource = dataSet.Tables["Books"].DefaultView;
            textBox3.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            dataGrid.DataSource = null;
            controller.SelectAll();
            controller.adapter.Fill(dataSet, "Books");
            dataGrid.DataSource = dataSet.Tables["Books"].DefaultView;
        }
    }
}
