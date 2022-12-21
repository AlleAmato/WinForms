using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersWinForms.Controllers;
using UsersWinForms.Models;

namespace UsersWinForms
{
    public partial class EditUser : Form
    {
        //region viewmodel
        #region ViewModel

        //private User user;
        /*private User UservM
        {
            get {
                return new user
                {
                nbrId.Value = u.Id;
                nbrEtà.Value = u.Age;
                txtFirstName.Text = u.FirstName;
                txtLastName.Text = u.LastName;
                txtEmail.Text = u.Email;
                txtPassword.Text = u.Password;
                txtUsername.Text = u.Username;
                dtBirthDate.Value = u.BirthDate;
                cmbSesso.SelectedItem = u.Gender;
            }; 
            }
            set { 
            Id=Value.    ...
 
                             
}
                 }*/
        
        #endregion
        //end region
        private User u;
        private bool isNew = true;
        public EditUser(User u) : this()
        {
            this.u = u;
            isNew = false;
        }
        public EditUser()
        {
            InitializeComponent();
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            cmbSesso.DataSource = Users.GetGenders();
            cmbSesso.SelectedIndex = -1;
            lblTitolo.Text = "Nuovo Utente";
            if (!isNew)
            {
                nbrId.Value = u.Id;
                nbrEtà.Value = u.Age;
                txtFirstName.Text = u.FirstName;
                txtLastName.Text = u.LastName;
                txtEmail.Text = u.Email;
                txtPassword.Text = u.Password;
                txtUsername.Text = u.Username;
                dtBirthDate.Value = u.BirthDate;
                cmbSesso.SelectedItem = u.Gender;

                lblTitolo.Text = "Modifica Utente";
            }//il caricamento dei dati funziona ora devo cercare di non duplicarlo e di sostituirlo a quello vecchio
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            User nuovo = new User
            {
                Id = (int)nbrId.Value,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Age = (int)nbrEtà.Value,
                Gender = (string)(cmbSesso.SelectedItem),
                BirthDate = dtBirthDate.Value
            };
            if (isNew)
                Users.Add(nuovo);
            else
            {if( Users.Update(u.Id, nuovo) == false)
                {
                    MessageBox.Show("Errore nell'aggiornamento");
                }
            
            }
            Close();
        }


    }
}
