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
    public partial class AddVariableUI : Form
    {
        #region variables
        public MainUI parrentUI;
        public int variableType = 0;
        #endregion

        public AddVariableUI()
        {
            InitializeComponent();

            // Add event handler

            listBoxGlobalVariables.SelectedValueChanged += new EventHandler(ListBoxGlobalVariablesAction);
            
        }

        public AddVariableUI(MainUI parrentUI)
        {
            InitializeComponent();

            this.parrentUI = parrentUI;
            this.TopLevel = true;
            string[] globalVariables = parrentUI.SolidWorksSingleton.getSolidWorksGlobalVariables();
            int i = 0;

            // fill in the listboxs

            if (globalVariables != null)
            {
                while (globalVariables[i] != null)
                {
                    listBoxGlobalVariables.Items.Add(globalVariables[i]);
                    if (parrentUI.SolidWorksSingleton.variables.isVariable(globalVariables[i]))
                    {
                        listBoxCurrentVariables.Items.Add(globalVariables[i]);
                    }
                    i++;
                }
            }

            // Add event handler

            listBoxGlobalVariables.SelectedValueChanged += new EventHandler(ListBoxGlobalVariablesAction);

            //Addin.swApp.SendMsgToUser(parrentUI.SolidWorksSingleton.getSolidWorksGlobalVariables()[0]);
        }

        #region event handler

        private void ListBoxGlobalVariablesAction(object sender, EventArgs e)
        {
            textBoxVariableName.Text = listBoxGlobalVariables.SelectedItem.ToString();
        }

        #endregion

        
        public void setParrentUI(MainUI parrentUI)
        {
            this.parrentUI = parrentUI;
        }

        #region button action

        private void Add_Var_Button_Click(object sender, EventArgs e)
        {
            string name = textBoxVariableName.Text;
            string max = textBoxVariableMax.Text;
            string min = textBoxVariableMin.Text;
            int type = variableType;

            if (parrentUI.SolidWorksSingleton.variables.addVariable(name, max, min, type) == 0)
            {
                ListViewItem temp = new ListViewItem(name);
                temp.SubItems.Add(min + " - " + max);
                parrentUI.getVariablesListView().Items.Add(temp);
                this.textBoxVariableName.Text = null;
                this.textBoxVariableMax.Text = null;
                this.textBoxVariableMin.Text = null;
            }
            this.TopLevel = true;
        }

        private void radioButtonVariableTypeFloat_CheckedChanged(object sender, EventArgs e)
        {
            variableType = 0;
        }

        private void radioButtonVariableTypeInt_CheckedChanged(object sender, EventArgs e)
        {
            variableType = 1;
        }


        #endregion

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
