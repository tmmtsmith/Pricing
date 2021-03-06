﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pricing_Version10
{
    public partial class fAddMerchant : Form
    {
        public fAddMerchant()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var scon = Connections.Connect())
            {
                SqlCommand addApp = new SqlCommand("INSERT INTO SalesList (SalesApproach,SalesNotes) SELECT @1,@2", scon);
                addApp.Parameters.Add(new SqlParameter("@1", txtAddApp.Text));
                addApp.Parameters.Add(new SqlParameter("@2", txtNotes.Text));
                addApp.ExecuteNonQuery();
                scon.Close();
                scon.Dispose();
            }

            txtAddApp.Text = String.Empty;
            txtNotes.Text = String.Empty;
        }
    }
}
