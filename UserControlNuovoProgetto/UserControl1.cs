﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserControlNuovoProgetto
{
    public partial class UserControl1 : UserControl
    {
        public event EventHandler miHannoCliccato;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void bSwitch_Click(object sender, EventArgs e)
        {
            miHannoCliccato?.Invoke(this, EventArgs.Empty);
        }
    }
}
