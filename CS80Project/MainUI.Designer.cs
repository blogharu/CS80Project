namespace CS80Project
{
    partial class MainUI
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupOptimization = new System.Windows.Forms.GroupBox();
            this.textBoxLearningRate = new System.Windows.Forms.TextBox();
            this.labelLearningRate = new System.Windows.Forms.Label();
            this.buttonBackToOriginal = new System.Windows.Forms.Button();
            this.buttonGenerateRandom = new System.Windows.Forms.Button();
            this.buttonOptimization = new System.Windows.Forms.Button();
            this.buttonPrtFile = new System.Windows.Forms.Button();
            this.buttonSTLFile = new System.Windows.Forms.Button();
            this.textBoxNumSamples = new System.Windows.Forms.TextBox();
            this.labelNumSamples = new System.Windows.Forms.Label();
            this.buttonLoadVariableConstraint = new System.Windows.Forms.Button();
            this.buttonSaveVariableConstraint = new System.Windows.Forms.Button();
            this.groupBoxConstraints = new System.Windows.Forms.GroupBox();
            this.buttonDeleteConstraint = new System.Windows.Forms.Button();
            this.listViewConstraints = new System.Windows.Forms.ListView();
            this.columnConstraintName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnConstraintEquation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAddConstraint = new System.Windows.Forms.Button();
            this.projectName = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonPythonEXE = new System.Windows.Forms.Button();
            this.buttonAddVariable = new System.Windows.Forms.Button();
            this.listVariables = new System.Windows.Forms.ListView();
            this.variableName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.variableRange = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDeleteVariable = new System.Windows.Forms.Button();
            this.groupVariables = new System.Windows.Forms.GroupBox();
            this.groupOptimization.SuspendLayout();
            this.groupBoxConstraints.SuspendLayout();
            this.groupVariables.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 509);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Variables and Constraints";
            // 
            // groupOptimization
            // 
            this.groupOptimization.Controls.Add(this.textBoxLearningRate);
            this.groupOptimization.Controls.Add(this.labelLearningRate);
            this.groupOptimization.Controls.Add(this.buttonBackToOriginal);
            this.groupOptimization.Controls.Add(this.buttonGenerateRandom);
            this.groupOptimization.Controls.Add(this.buttonOptimization);
            this.groupOptimization.Controls.Add(this.buttonPrtFile);
            this.groupOptimization.Controls.Add(this.buttonSTLFile);
            this.groupOptimization.Controls.Add(this.textBoxNumSamples);
            this.groupOptimization.Controls.Add(this.labelNumSamples);
            this.groupOptimization.Location = new System.Drawing.Point(9, 577);
            this.groupOptimization.Name = "groupOptimization";
            this.groupOptimization.Size = new System.Drawing.Size(231, 165);
            this.groupOptimization.TabIndex = 17;
            this.groupOptimization.TabStop = false;
            this.groupOptimization.Text = "Optimization";
            // 
            // textBoxLearningRate
            // 
            this.textBoxLearningRate.Location = new System.Drawing.Point(130, 104);
            this.textBoxLearningRate.Name = "textBoxLearningRate";
            this.textBoxLearningRate.Size = new System.Drawing.Size(96, 20);
            this.textBoxLearningRate.TabIndex = 8;
            this.textBoxLearningRate.Text = "0.2";
            // 
            // labelLearningRate
            // 
            this.labelLearningRate.AutoSize = true;
            this.labelLearningRate.Location = new System.Drawing.Point(8, 107);
            this.labelLearningRate.Name = "labelLearningRate";
            this.labelLearningRate.Size = new System.Drawing.Size(116, 13);
            this.labelLearningRate.TabIndex = 7;
            this.labelLearningRate.Text = "Learning Rate (0.1-0.9)";
            // 
            // buttonBackToOriginal
            // 
            this.buttonBackToOriginal.Enabled = false;
            this.buttonBackToOriginal.Location = new System.Drawing.Point(112, 19);
            this.buttonBackToOriginal.Name = "buttonBackToOriginal";
            this.buttonBackToOriginal.Size = new System.Drawing.Size(113, 23);
            this.buttonBackToOriginal.TabIndex = 6;
            this.buttonBackToOriginal.Text = "Original";
            this.buttonBackToOriginal.UseVisualStyleBackColor = true;
            this.buttonBackToOriginal.Click += new System.EventHandler(this.buttonBackToOriginal_Click);
            // 
            // buttonGenerateRandom
            // 
            this.buttonGenerateRandom.Location = new System.Drawing.Point(1, 19);
            this.buttonGenerateRandom.Name = "buttonGenerateRandom";
            this.buttonGenerateRandom.Size = new System.Drawing.Size(104, 23);
            this.buttonGenerateRandom.TabIndex = 5;
            this.buttonGenerateRandom.Text = "Generate Random";
            this.buttonGenerateRandom.UseVisualStyleBackColor = true;
            this.buttonGenerateRandom.Click += new System.EventHandler(this.buttonGenerateRandom_Click);
            // 
            // buttonOptimization
            // 
            this.buttonOptimization.Location = new System.Drawing.Point(1, 130);
            this.buttonOptimization.Name = "buttonOptimization";
            this.buttonOptimization.Size = new System.Drawing.Size(225, 23);
            this.buttonOptimization.TabIndex = 4;
            this.buttonOptimization.Text = "Optimization";
            this.buttonOptimization.UseVisualStyleBackColor = true;
            this.buttonOptimization.Click += new System.EventHandler(this.buttonOptimization_Click);
            // 
            // buttonPrtFile
            // 
            this.buttonPrtFile.Location = new System.Drawing.Point(1, 75);
            this.buttonPrtFile.Name = "buttonPrtFile";
            this.buttonPrtFile.Size = new System.Drawing.Size(105, 23);
            this.buttonPrtFile.TabIndex = 3;
            this.buttonPrtFile.Text = "SAMPLE.sldprt";
            this.buttonPrtFile.UseVisualStyleBackColor = true;
            this.buttonPrtFile.Click += new System.EventHandler(this.buttonPrtFile_Click);
            // 
            // buttonSTLFile
            // 
            this.buttonSTLFile.Location = new System.Drawing.Point(112, 75);
            this.buttonSTLFile.Name = "buttonSTLFile";
            this.buttonSTLFile.Size = new System.Drawing.Size(114, 23);
            this.buttonSTLFile.TabIndex = 2;
            this.buttonSTLFile.Text = "SAMPLE.stl";
            this.buttonSTLFile.UseVisualStyleBackColor = true;
            this.buttonSTLFile.Click += new System.EventHandler(this.buttonSTLFile_Click);
            // 
            // textBoxNumSamples
            // 
            this.textBoxNumSamples.Location = new System.Drawing.Point(112, 48);
            this.textBoxNumSamples.Name = "textBoxNumSamples";
            this.textBoxNumSamples.Size = new System.Drawing.Size(114, 20);
            this.textBoxNumSamples.TabIndex = 1;
            this.textBoxNumSamples.Text = "8";
            // 
            // labelNumSamples
            // 
            this.labelNumSamples.AutoSize = true;
            this.labelNumSamples.Location = new System.Drawing.Point(8, 51);
            this.labelNumSamples.Name = "labelNumSamples";
            this.labelNumSamples.Size = new System.Drawing.Size(72, 13);
            this.labelNumSamples.TabIndex = 0;
            this.labelNumSamples.Text = "Num Samples";
            // 
            // buttonLoadVariableConstraint
            // 
            this.buttonLoadVariableConstraint.Location = new System.Drawing.Point(121, 536);
            this.buttonLoadVariableConstraint.Name = "buttonLoadVariableConstraint";
            this.buttonLoadVariableConstraint.Size = new System.Drawing.Size(113, 23);
            this.buttonLoadVariableConstraint.TabIndex = 16;
            this.buttonLoadVariableConstraint.Text = "Load";
            this.buttonLoadVariableConstraint.UseVisualStyleBackColor = true;
            this.buttonLoadVariableConstraint.Click += new System.EventHandler(this.buttonLoadVariableConstraint_Click);
            // 
            // buttonSaveVariableConstraint
            // 
            this.buttonSaveVariableConstraint.Location = new System.Drawing.Point(10, 536);
            this.buttonSaveVariableConstraint.Name = "buttonSaveVariableConstraint";
            this.buttonSaveVariableConstraint.Size = new System.Drawing.Size(105, 23);
            this.buttonSaveVariableConstraint.TabIndex = 15;
            this.buttonSaveVariableConstraint.Text = "Save";
            this.buttonSaveVariableConstraint.UseVisualStyleBackColor = true;
            this.buttonSaveVariableConstraint.Click += new System.EventHandler(this.buttonSaveVariableConstraint_Click);
            // 
            // groupBoxConstraints
            // 
            this.groupBoxConstraints.Controls.Add(this.buttonDeleteConstraint);
            this.groupBoxConstraints.Controls.Add(this.listViewConstraints);
            this.groupBoxConstraints.Controls.Add(this.buttonAddConstraint);
            this.groupBoxConstraints.Location = new System.Drawing.Point(9, 289);
            this.groupBoxConstraints.Name = "groupBoxConstraints";
            this.groupBoxConstraints.Size = new System.Drawing.Size(233, 204);
            this.groupBoxConstraints.TabIndex = 12;
            this.groupBoxConstraints.TabStop = false;
            this.groupBoxConstraints.Text = "Constraints (Max 6)";
            // 
            // buttonDeleteConstraint
            // 
            this.buttonDeleteConstraint.Location = new System.Drawing.Point(112, 176);
            this.buttonDeleteConstraint.Name = "buttonDeleteConstraint";
            this.buttonDeleteConstraint.Size = new System.Drawing.Size(114, 23);
            this.buttonDeleteConstraint.TabIndex = 3;
            this.buttonDeleteConstraint.Text = "Delete Constraint";
            this.buttonDeleteConstraint.UseVisualStyleBackColor = true;
            this.buttonDeleteConstraint.Click += new System.EventHandler(this.buttonDeleteConstraint_Click);
            // 
            // listViewConstraints
            // 
            this.listViewConstraints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnConstraintName,
            this.columnConstraintEquation});
            this.listViewConstraints.HideSelection = false;
            this.listViewConstraints.Location = new System.Drawing.Point(1, 20);
            this.listViewConstraints.Name = "listViewConstraints";
            this.listViewConstraints.Size = new System.Drawing.Size(225, 149);
            this.listViewConstraints.TabIndex = 0;
            this.listViewConstraints.UseCompatibleStateImageBehavior = false;
            this.listViewConstraints.View = System.Windows.Forms.View.Details;
            // 
            // columnConstraintName
            // 
            this.columnConstraintName.Text = "Name";
            // 
            // columnConstraintEquation
            // 
            this.columnConstraintEquation.Text = "Equation";
            this.columnConstraintEquation.Width = 156;
            // 
            // buttonAddConstraint
            // 
            this.buttonAddConstraint.Location = new System.Drawing.Point(1, 175);
            this.buttonAddConstraint.Name = "buttonAddConstraint";
            this.buttonAddConstraint.Size = new System.Drawing.Size(106, 23);
            this.buttonAddConstraint.TabIndex = 2;
            this.buttonAddConstraint.Text = "Add Constraint";
            this.buttonAddConstraint.UseVisualStyleBackColor = true;
            this.buttonAddConstraint.Click += new System.EventHandler(this.buttonAddConstraint_Click);
            // 
            // projectName
            // 
            this.projectName.AutoSize = true;
            this.projectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectName.Location = new System.Drawing.Point(5, 11);
            this.projectName.Name = "projectName";
            this.projectName.Size = new System.Drawing.Size(136, 17);
            this.projectName.TabIndex = 13;
            this.projectName.Text = "Capstone Project 80";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonPythonEXE
            // 
            this.buttonPythonEXE.Enabled = false;
            this.buttonPythonEXE.Location = new System.Drawing.Point(10, 736);
            this.buttonPythonEXE.Name = "buttonPythonEXE";
            this.buttonPythonEXE.Size = new System.Drawing.Size(224, 23);
            this.buttonPythonEXE.TabIndex = 20;
            this.buttonPythonEXE.Text = "LocationPython EXE";
            this.buttonPythonEXE.UseVisualStyleBackColor = true;
            this.buttonPythonEXE.Click += new System.EventHandler(this.buttonPythonEXE_Click);
            // 
            // buttonAddVariable
            // 
            this.buttonAddVariable.Location = new System.Drawing.Point(5, 192);
            this.buttonAddVariable.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddVariable.Name = "buttonAddVariable";
            this.buttonAddVariable.Size = new System.Drawing.Size(107, 23);
            this.buttonAddVariable.TabIndex = 3;
            this.buttonAddVariable.Text = "Add Variable";
            this.buttonAddVariable.UseVisualStyleBackColor = true;
            this.buttonAddVariable.Click += new System.EventHandler(this.buttonAddVariable_Click);
            // 
            // listVariables
            // 
            this.listVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.variableName,
            this.variableRange});
            this.listVariables.HideSelection = false;
            this.listVariables.Location = new System.Drawing.Point(6, 19);
            this.listVariables.Name = "listVariables";
            this.listVariables.Size = new System.Drawing.Size(225, 167);
            this.listVariables.TabIndex = 0;
            this.listVariables.UseCompatibleStateImageBehavior = false;
            this.listVariables.View = System.Windows.Forms.View.Details;
            // 
            // variableName
            // 
            this.variableName.Text = "Name";
            // 
            // variableRange
            // 
            this.variableRange.Text = "Range";
            this.variableRange.Width = 159;
            // 
            // buttonDeleteVariable
            // 
            this.buttonDeleteVariable.Location = new System.Drawing.Point(117, 192);
            this.buttonDeleteVariable.Name = "buttonDeleteVariable";
            this.buttonDeleteVariable.Size = new System.Drawing.Size(114, 23);
            this.buttonDeleteVariable.TabIndex = 5;
            this.buttonDeleteVariable.Text = "Delete Variable";
            this.buttonDeleteVariable.UseVisualStyleBackColor = true;
            this.buttonDeleteVariable.Click += new System.EventHandler(this.buttonDeleteVariable_Click);
            // 
            // groupVariables
            // 
            this.groupVariables.Controls.Add(this.buttonDeleteVariable);
            this.groupVariables.Controls.Add(this.listVariables);
            this.groupVariables.Controls.Add(this.buttonAddVariable);
            this.groupVariables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupVariables.Location = new System.Drawing.Point(3, 41);
            this.groupVariables.Name = "groupVariables";
            this.groupVariables.Size = new System.Drawing.Size(237, 221);
            this.groupVariables.TabIndex = 14;
            this.groupVariables.TabStop = false;
            this.groupVariables.Text = "Variables (Max 6)";
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonPythonEXE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupOptimization);
            this.Controls.Add(this.buttonLoadVariableConstraint);
            this.Controls.Add(this.buttonSaveVariableConstraint);
            this.Controls.Add(this.groupBoxConstraints);
            this.Controls.Add(this.groupVariables);
            this.Controls.Add(this.projectName);
            this.Name = "MainUI";
            this.Size = new System.Drawing.Size(266, 775);
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.groupOptimization.ResumeLayout(false);
            this.groupOptimization.PerformLayout();
            this.groupBoxConstraints.ResumeLayout(false);
            this.groupVariables.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupOptimization;
        private System.Windows.Forms.Button buttonOptimization;
        private System.Windows.Forms.Button buttonPrtFile;
        private System.Windows.Forms.Button buttonSTLFile;
        private System.Windows.Forms.TextBox textBoxNumSamples;
        private System.Windows.Forms.Label labelNumSamples;
        private System.Windows.Forms.Button buttonLoadVariableConstraint;
        private System.Windows.Forms.Button buttonSaveVariableConstraint;
        private System.Windows.Forms.GroupBox groupBoxConstraints;
        private System.Windows.Forms.Button buttonDeleteConstraint;
        private System.Windows.Forms.ListView listViewConstraints;
        private System.Windows.Forms.ColumnHeader columnConstraintName;
        private System.Windows.Forms.ColumnHeader columnConstraintEquation;
        private System.Windows.Forms.Button buttonAddConstraint;
        private System.Windows.Forms.Label projectName;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textBoxLearningRate;
        private System.Windows.Forms.Label labelLearningRate;
        private System.Windows.Forms.Button buttonBackToOriginal;
        private System.Windows.Forms.Button buttonGenerateRandom;
        private System.Windows.Forms.Button buttonPythonEXE;
        private System.Windows.Forms.Button buttonAddVariable;
        private System.Windows.Forms.ListView listVariables;
        private System.Windows.Forms.ColumnHeader variableName;
        private System.Windows.Forms.ColumnHeader variableRange;
        private System.Windows.Forms.Button buttonDeleteVariable;
        private System.Windows.Forms.GroupBox groupVariables;
    }
}
