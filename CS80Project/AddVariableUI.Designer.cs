namespace CS80Project
{
    partial class AddVariableUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonVariableTypeInt = new System.Windows.Forms.RadioButton();
            this.radioButtonVariableTypeFloat = new System.Windows.Forms.RadioButton();
            this.textBoxVariableMin = new System.Windows.Forms.TextBox();
            this.textBoxVariableMax = new System.Windows.Forms.TextBox();
            this.textBoxVariableName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelVariableName = new System.Windows.Forms.Label();
            this.listBoxGlobalVariables = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxCurrentVariables = new System.Windows.Forms.ListBox();
            this.Add_Var_Button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(184, 236);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(120, 23);
            this.buttonClose.TabIndex = 33;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonVariableTypeInt);
            this.groupBox1.Controls.Add(this.radioButtonVariableTypeFloat);
            this.groupBox1.Location = new System.Drawing.Point(184, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 75);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // radioButtonVariableTypeInt
            // 
            this.radioButtonVariableTypeInt.AutoSize = true;
            this.radioButtonVariableTypeInt.Location = new System.Drawing.Point(16, 43);
            this.radioButtonVariableTypeInt.Name = "radioButtonVariableTypeInt";
            this.radioButtonVariableTypeInt.Size = new System.Drawing.Size(37, 17);
            this.radioButtonVariableTypeInt.TabIndex = 1;
            this.radioButtonVariableTypeInt.Text = "Int";
            this.radioButtonVariableTypeInt.UseVisualStyleBackColor = true;
            this.radioButtonVariableTypeInt.CheckedChanged += new System.EventHandler(this.radioButtonVariableTypeInt_CheckedChanged);
            // 
            // radioButtonVariableTypeFloat
            // 
            this.radioButtonVariableTypeFloat.AutoSize = true;
            this.radioButtonVariableTypeFloat.Checked = true;
            this.radioButtonVariableTypeFloat.Location = new System.Drawing.Point(16, 19);
            this.radioButtonVariableTypeFloat.Name = "radioButtonVariableTypeFloat";
            this.radioButtonVariableTypeFloat.Size = new System.Drawing.Size(48, 17);
            this.radioButtonVariableTypeFloat.TabIndex = 0;
            this.radioButtonVariableTypeFloat.TabStop = true;
            this.radioButtonVariableTypeFloat.Text = "Float";
            this.radioButtonVariableTypeFloat.UseVisualStyleBackColor = true;
            this.radioButtonVariableTypeFloat.CheckedChanged += new System.EventHandler(this.radioButtonVariableTypeFloat_CheckedChanged);
            // 
            // textBoxVariableMin
            // 
            this.textBoxVariableMin.Location = new System.Drawing.Point(53, 183);
            this.textBoxVariableMin.Name = "textBoxVariableMin";
            this.textBoxVariableMin.Size = new System.Drawing.Size(124, 20);
            this.textBoxVariableMin.TabIndex = 31;
            // 
            // textBoxVariableMax
            // 
            this.textBoxVariableMax.Location = new System.Drawing.Point(53, 209);
            this.textBoxVariableMax.Name = "textBoxVariableMax";
            this.textBoxVariableMax.Size = new System.Drawing.Size(124, 20);
            this.textBoxVariableMax.TabIndex = 30;
            // 
            // textBoxVariableName
            // 
            this.textBoxVariableName.Location = new System.Drawing.Point(53, 157);
            this.textBoxVariableName.Name = "textBoxVariableName";
            this.textBoxVariableName.Size = new System.Drawing.Size(124, 20);
            this.textBoxVariableName.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Min";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Max";
            // 
            // labelVariableName
            // 
            this.labelVariableName.AutoSize = true;
            this.labelVariableName.Location = new System.Drawing.Point(11, 165);
            this.labelVariableName.Name = "labelVariableName";
            this.labelVariableName.Size = new System.Drawing.Size(35, 13);
            this.labelVariableName.TabIndex = 26;
            this.labelVariableName.Text = "Name";
            // 
            // listBoxGlobalVariables
            // 
            this.listBoxGlobalVariables.FormattingEnabled = true;
            this.listBoxGlobalVariables.Location = new System.Drawing.Point(14, 30);
            this.listBoxGlobalVariables.Name = "listBoxGlobalVariables";
            this.listBoxGlobalVariables.Size = new System.Drawing.Size(163, 121);
            this.listBoxGlobalVariables.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Current Variables";
            // 
            // listBoxCurrentVariables
            // 
            this.listBoxCurrentVariables.FormattingEnabled = true;
            this.listBoxCurrentVariables.Location = new System.Drawing.Point(184, 30);
            this.listBoxCurrentVariables.Name = "listBoxCurrentVariables";
            this.listBoxCurrentVariables.Size = new System.Drawing.Size(120, 121);
            this.listBoxCurrentVariables.TabIndex = 23;
            // 
            // Add_Var_Button
            // 
            this.Add_Var_Button.Location = new System.Drawing.Point(68, 236);
            this.Add_Var_Button.Margin = new System.Windows.Forms.Padding(2);
            this.Add_Var_Button.Name = "Add_Var_Button";
            this.Add_Var_Button.Size = new System.Drawing.Size(109, 24);
            this.Add_Var_Button.TabIndex = 22;
            this.Add_Var_Button.Text = "Add Variable";
            this.Add_Var_Button.UseVisualStyleBackColor = true;
            this.Add_Var_Button.Click += new System.EventHandler(this.Add_Var_Button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Variables in SolidWorks";
            // 
            // AddVariableUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 273);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxVariableMin);
            this.Controls.Add(this.textBoxVariableMax);
            this.Controls.Add(this.textBoxVariableName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelVariableName);
            this.Controls.Add(this.listBoxGlobalVariables);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxCurrentVariables);
            this.Controls.Add(this.Add_Var_Button);
            this.Controls.Add(this.label3);
            this.Name = "AddVariableUI";
            this.Text = "Add Variable";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonVariableTypeInt;
        private System.Windows.Forms.RadioButton radioButtonVariableTypeFloat;
        private System.Windows.Forms.TextBox textBoxVariableMin;
        private System.Windows.Forms.TextBox textBoxVariableMax;
        private System.Windows.Forms.TextBox textBoxVariableName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelVariableName;
        private System.Windows.Forms.ListBox listBoxGlobalVariables;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxCurrentVariables;
        private System.Windows.Forms.Button Add_Var_Button;
        private System.Windows.Forms.Label label3;
    }
}