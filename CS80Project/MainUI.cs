using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

namespace CS80Project
{
    [ProgId(Addin.SWTASKPANE_PROGID)]
    public partial class MainUI : UserControl
    {
        public Addin SolidWorksSingleton;
        public int original = 0;
        public string[] originalVariables;


        public MainUI()
        {
            InitializeComponent();

            if (Addin.pythonLocation == null)
            {
                buttonPythonEXE.Enabled = true;
            }
        }

        #region Get and Set Functions

        public ListView getVariablesListView()
        {
            return listVariables;
        }
        public ListView getConstraintsListView()
        {
            return listViewConstraints;
        }

        public void setSolidWorksSingleton(Addin SolidWorksSingleton)
        {
            this.SolidWorksSingleton = SolidWorksSingleton;
        }

        public void setOriginal()
        {
            if (original == 0)
            {
                original = 1;
                originalVariables = SolidWorksSingleton.variables.getValues();
                buttonBackToOriginal.Enabled = true;
            }
        }

        #endregion

        #region VariablesUI

        private void buttonAddVariable_Click(object sender, EventArgs e)
        {
            AddVariableUI addVariableUI = new AddVariableUI(this);
            //addVariableUI.setParrentUI(this);
            addVariableUI.Show();
        }

        private void buttonDeleteVariable_Click(object sender, EventArgs e)
        {
            if (listVariables.FocusedItem == null)
            {
                return;
            }
            if (listVariables.SelectedItems.Count > 0)
            {
                int count = listVariables.SelectedItems.Count;
                for (int i = 0; i < count; i++)
                {
                    SolidWorksSingleton.variables.removeVariable(listVariables.SelectedItems[0].Text);
                    listVariables.SelectedItems[0].Remove();
                }
            }
        }

        private void refreshVariablesList()
        {
            if (listVariables.Items.Count > 0)
            {
                int count = listVariables.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    listVariables.Items[0].Remove();
                }
            }

            for (int i = 0; i < SolidWorksSingleton.variables.numVariables; i++)
            {
                ListViewItem temp = new ListViewItem(SolidWorksSingleton.variables.variablesName[i]);
                if (SolidWorksSingleton.variables.variablesType[i] == 0)
                {
                    temp.SubItems.Add(SolidWorksSingleton.variables.variablesMin[i] + " - " + SolidWorksSingleton.variables.variablesMax[i]);
                }
                else
                {
                    temp.SubItems.Add(SolidWorksSingleton.variables.roundUpValue(SolidWorksSingleton.variables.variablesMin[i]) + " - " + SolidWorksSingleton.variables.roundUpValue(SolidWorksSingleton.variables.variablesMax[i]));
                }
                listVariables.Items.Add(temp);
            }
        }

        #endregion

        #region ConstraintUI

        private void buttonAddConstraint_Click(object sender, EventArgs e)
        {
            AddConstraintUI getConstarint = new AddConstraintUI(this);
            getConstarint.Show();
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
                    SolidWorksSingleton.constraints.removeConstraint(listViewConstraints.SelectedItems[0].Text);
                    listViewConstraints.SelectedItems[0].Remove();
                }
            }
        }

        private void refreshConstraintsList()
        {
            if (listViewConstraints.Items.Count > 0)
            {
                int count = listViewConstraints.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    listViewConstraints.Items[0].Remove();
                }
            }

            for (int i = 0; i < SolidWorksSingleton.constraints.numConstraints; i++)
            {
                ListViewItem temp = new ListViewItem(SolidWorksSingleton.constraints.constraintsName[i]);
                temp.SubItems.Add(SolidWorksSingleton.constraints.constraintsEquation[i]);
                listViewConstraints.Items.Add(temp);
            }
        }

        #endregion

        #region Read and Write

        private void buttonSaveVariableConstraint_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            SolidWorksSingleton.writeVariablesAndConstraints(saveFileDialog1.FileName);
        }

        private void buttonLoadVariableConstraint_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            SolidWorksSingleton.readVariablesAndConstraints(openFileDialog1.FileName);
            refreshVariablesList();
            refreshConstraintsList();
        }

        #endregion

        #region Rendom Generator and Optimization
        private void buttonPrtFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            string path = saveFileDialog1.FileName;

            try
            {
                using (StreamWriter outFile = new StreamWriter(path + "_Result.csv"))
                {
                    outFile.WriteLine("CS80PROJECT_RANDOM_SAMPLES");

                    /* Write Number of Variables, Number of Constraints, Number of Samples*/
                    outFile.WriteLine("{0},{1},{2}", SolidWorksSingleton.variables.numVariables, SolidWorksSingleton.constraints.numConstraints, textBoxNumSamples.Text);

                    // Write out all of the variables

                    int num = SolidWorksSingleton.variables.numVariables;

                    if (num > 0)
                    {
                        outFile.WriteLine("Variables,{0}", num);
                        for (int i = 0; i < num; i++)
                        {
                            outFile.WriteLine("{0},{1},{2},{3}", SolidWorksSingleton.variables.variablesName[i], SolidWorksSingleton.variables.variablesMin[i], SolidWorksSingleton.variables.variablesMax[i],SolidWorksSingleton.variables.variablesType[i]);
                        }
                    }

                    /* Write out all of the constraint equations */

                    num = SolidWorksSingleton.constraints.numConstraints;

                    outFile.WriteLine("Constraints,{0}",num);

                    if (SolidWorksSingleton.constraints.numConstraints > 0)
                    {
                        for (int i = 0; i < SolidWorksSingleton.constraints.numConstraints; i++)
                        {
                            outFile.WriteLine("{0}", SolidWorksSingleton.constraints.constraintsEquation[i]);
                        }
                    }

                    /* Write out samples header */
                    string header = "Sample#";

                    /* Write out all of the variable names for the sample header */
                    for (int i = 0; i < SolidWorksSingleton.variables.numVariables; i++)
                    {
                        header = header + "," + SolidWorksSingleton.variables.variablesName[i];
                    }

                    header = header + ",Result";

                    outFile.WriteLine(header);

                    // Generate Random Object and write the data to the result.csv

                    setOriginal();
                    for (int i = 0; i < int.Parse(textBoxNumSamples.Text); i++)
                    {
                        SolidWorksSingleton.generateRandomObject();
                        if (i < 9)
                        {
                            SolidWorksSingleton.writeSolidWorksDocumentAsSLDPRT(saveFileDialog1.FileName + "0" + (i + 1).ToString());
                        }
                        else
                        {
                            SolidWorksSingleton.writeSolidWorksDocumentAsSLDPRT(saveFileDialog1.FileName + (i + 1).ToString());
                        }

                        string sample = "Sample" + (i + 1).ToString();
                        string[] sampleValue = SolidWorksSingleton.variables.getValues();
                        for (int j = 0; j < SolidWorksSingleton.variables.numVariables; j++)
                        {
                            sample = sample + "," + sampleValue[j];
                        }

                        outFile.WriteLine(sample);
                    }
                    SolidWorksSingleton.sendMessageToUser2("Random objects are created", 2);

                }
            }
            catch(Exception err)
            {
                SolidWorksSingleton.sendMessageToUser("ERROR!!!");
            }

        }

        private void buttonSTLFile_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

            string path = saveFileDialog1.FileName;

            try
            {
                using (StreamWriter outFile = new StreamWriter(path + "_Result.csv"))
                {
                    outFile.WriteLine("CS80PROJECT_RANDOM_SAMPLES");

                    /* Write Number of Variables, Number of Constraints, Number of Samples*/
                    outFile.WriteLine("{0},{1},{2}", SolidWorksSingleton.variables.numVariables, SolidWorksSingleton.constraints.numConstraints, textBoxNumSamples.Text);

                    // Write out all of the variables

                    int num = SolidWorksSingleton.variables.numVariables;

                    if (num > 0)
                    {
                        outFile.WriteLine("Variables,{0}", num);
                        for (int i = 0; i < num; i++)
                        {
                            outFile.WriteLine("{0},{1},{2},{3}", SolidWorksSingleton.variables.variablesName[i], SolidWorksSingleton.variables.variablesMin[i], SolidWorksSingleton.variables.variablesMax[i], SolidWorksSingleton.variables.variablesType[i]);
                        }
                    }

                    /* Write out all of the constraint equations */

                    num = SolidWorksSingleton.constraints.numConstraints;

                    outFile.WriteLine("Constraints,{0}", num);

                    if (SolidWorksSingleton.constraints.numConstraints > 0)
                    {
                        for (int i = 0; i < SolidWorksSingleton.constraints.numConstraints; i++)
                        {
                            outFile.WriteLine("{0}", SolidWorksSingleton.constraints.constraintsEquation[i]);
                        }
                    }

                    /* Write out samples header */
                    string header = "Sample#";

                    /* Write out all of the variable names for the sample header */
                    for (int i = 0; i < SolidWorksSingleton.variables.numVariables; i++)
                    {
                        header = header + "," + SolidWorksSingleton.variables.variablesName[i];
                    }

                    header = header + ",Result";

                    outFile.WriteLine(header);

                    // Generate Random Object and write the data to the result.csv

                    setOriginal();
                    for (int i = 0; i < int.Parse(textBoxNumSamples.Text); i++)
                    {
                        SolidWorksSingleton.generateRandomObject();
                        if (i < 9)
                        {
                            SolidWorksSingleton.writeSolidWorksDocumentAsSTL(saveFileDialog1.FileName + "0" + (i + 1).ToString());
                        }
                        else
                        {
                            SolidWorksSingleton.writeSolidWorksDocumentAsSTL(saveFileDialog1.FileName + (i + 1).ToString());
                        }

                        string sample = "Sample" + (i + 1).ToString();
                        string[] sampleValue = SolidWorksSingleton.variables.getValues();
                        for (int j = 0; j < SolidWorksSingleton.variables.numVariables; j++)
                        {
                            sample = sample + "," + sampleValue[j];
                        }

                        outFile.WriteLine(sample);
                    }
                }
                SolidWorksSingleton.sendMessageToUser2("Random objects are created",2);
            }
            catch (Exception err)
            {
                SolidWorksSingleton.sendMessageToUser("ERROR!!!");
            }
        }

        private void buttonOptimization_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            string path = openFileDialog1.FileName;

            string[] arguemtns = new string[1];
            arguemtns[0] = openFileDialog1.FileName;

            SolidWorksSingleton.writeArgument(arguemtns);

            if (SolidWorksSingleton.optimization(textBoxLearningRate.Text) == true)
            {
                refreshVariablesList();
            }
        }
        #endregion

        private void buttonGenerateRandom_Click(object sender, EventArgs e)
        {
            setOriginal();
            SolidWorksSingleton.generateRandomObject();
        }

        private void buttonBackToOriginal_Click(object sender, EventArgs e)
        {
            original = 0;
            SolidWorksSingleton.setObject(originalVariables);
            buttonBackToOriginal.Enabled = false;
        }
        //sendMessageToUser2("Variables and Constraints are saved", 2);

        private void buttonPythonEXE_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (SolidWorksSingleton.setPythonLocation(openFileDialog1.FileName)) {
                SolidWorksSingleton.sendMessageToUser2("Python location is saved",2); //line393
                buttonPythonEXE.Enabled = false;
            }
            else
            {
                SolidWorksSingleton.sendMessageToUser("Wrong Location");
            }
        }

        private void MainUI_Load(object sender, EventArgs e)
        {

        }
    }
}
