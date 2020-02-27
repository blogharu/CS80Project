using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS80Project
{
    public partial class AddConstraintUI : Form
    {
        #region Variable

        MainUI parrentUI;

        #endregion

        public AddConstraintUI()
        {
            InitializeComponent();
        }

        public AddConstraintUI(MainUI parrentUI)
        {
            InitializeComponent();
            this.parrentUI = parrentUI;
            this.TopLevel = true;

            if (parrentUI.SolidWorksSingleton.constraints.constraintsName != null)
            {
                for (int i = 0; i < parrentUI.SolidWorksSingleton.constraints.numConstraints; i++)
                {
                    if (parrentUI.SolidWorksSingleton.constraints.constraintsName[i] != null)
                    {
                        ListViewItem temp = new ListViewItem(parrentUI.SolidWorksSingleton.constraints.constraintsName[i]);
                        temp.SubItems.Add(parrentUI.SolidWorksSingleton.constraints.constraintsEquation[i]);
                        listViewConstraints.Items.Add(temp);
                    }
                }
            }

            if (parrentUI.SolidWorksSingleton.variables.variablesName != null)
            {
                for (int i = 0; i < parrentUI.SolidWorksSingleton.variables.numVariables; i++)
                {
                    if (parrentUI.SolidWorksSingleton.variables.variablesName[i] != null)
                    {
                        listBox1.Items.Add(parrentUI.SolidWorksSingleton.variables.variablesName[i]);
                    }
                }
            }
        }

        private void buttonDeleteConstraint_Click(object sender, EventArgs e)
        {
            if (listViewConstraints.FocusedItem == null)
            {
                return;
            }
            if (listViewConstraints.SelectedItems.Count > 0)
            {
                int count = listViewConstraints.SelectedItems.Count;
                for (int i = 0; i < count; i++)
                {
                    parrentUI.SolidWorksSingleton.constraints.removeConstraint(listViewConstraints.SelectedItems[0].Text);
                    parrentUI.getConstraintsListView().FindItemWithText(listViewConstraints.SelectedItems[0].Text).Remove();
                    listViewConstraints.SelectedItems[0].Remove();
                }
            }
        }

        private void buttonAddConstraint_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text.ToString();
            string constraint = textBox1.Text.ToString();
            if (parrentUI.SolidWorksSingleton.constraints.addConstraint(name, constraint) == 1)
            {
                ListViewItem temp = new ListViewItem(name);
                temp.SubItems.Add(constraint);
                listViewConstraints.Items.Add(temp);
                temp = new ListViewItem(name);
                temp.SubItems.Add(constraint);
                parrentUI.getConstraintsListView().Items.Add(temp);
                this.textBox2.Text = null;
                this.textBox1.Text = null;
            }
            this.TopLevel = true;
        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
