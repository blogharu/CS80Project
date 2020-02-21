namespace CS80Project
{
    partial class AddConstraintUI
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
            this.listViewConstraints = new System.Windows.Forms.ListView();
            this.columnHeaderConstraintName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderConstraintEquation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddConstraint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDeleteConstraint = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonFinish = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listViewConstraints
            // 
            this.listViewConstraints.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderConstraintName,
            this.columnHeaderConstraintEquation});
            this.listViewConstraints.HideSelection = false;
            this.listViewConstraints.Location = new System.Drawing.Point(46, 49);
            this.listViewConstraints.Name = "listViewConstraints";
            this.listViewConstraints.Size = new System.Drawing.Size(351, 222);
            this.listViewConstraints.TabIndex = 24;
            this.listViewConstraints.UseCompatibleStateImageBehavior = false;
            this.listViewConstraints.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderConstraintName
            // 
            this.columnHeaderConstraintName.Text = "Name";
            this.columnHeaderConstraintName.Width = 71;
            // 
            // columnHeaderConstraintEquation
            // 
            this.columnHeaderConstraintEquation.Text = "Equation";
            this.columnHeaderConstraintEquation.Width = 275;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(129, 328);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(268, 20);
            this.textBox2.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 373);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Equation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 335);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Name";
            // 
            // buttonAddConstraint
            // 
            this.buttonAddConstraint.Location = new System.Drawing.Point(426, 363);
            this.buttonAddConstraint.Name = "buttonAddConstraint";
            this.buttonAddConstraint.Size = new System.Drawing.Size(120, 23);
            this.buttonAddConstraint.TabIndex = 20;
            this.buttonAddConstraint.Text = "Add Constraint";
            this.buttonAddConstraint.UseVisualStyleBackColor = true;
            this.buttonAddConstraint.Click += new System.EventHandler(this.buttonAddConstraint_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "New Constraint";
            // 
            // buttonDeleteConstraint
            // 
            this.buttonDeleteConstraint.Location = new System.Drawing.Point(426, 249);
            this.buttonDeleteConstraint.Name = "buttonDeleteConstraint";
            this.buttonDeleteConstraint.Size = new System.Drawing.Size(120, 23);
            this.buttonDeleteConstraint.TabIndex = 18;
            this.buttonDeleteConstraint.Text = "Delete Constraint";
            this.buttonDeleteConstraint.UseVisualStyleBackColor = true;
            this.buttonDeleteConstraint.Click += new System.EventHandler(this.buttonDeleteConstraint_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "My Constraints";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(426, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "My Variables";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(129, 366);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 20);
            this.textBox1.TabIndex = 15;
            // 
            // buttonFinish
            // 
            this.buttonFinish.Location = new System.Drawing.Point(426, 409);
            this.buttonFinish.Name = "buttonFinish";
            this.buttonFinish.Size = new System.Drawing.Size(120, 23);
            this.buttonFinish.TabIndex = 14;
            this.buttonFinish.Text = "Finish";
            this.buttonFinish.UseVisualStyleBackColor = true;
            this.buttonFinish.Click += new System.EventHandler(this.buttonFinish_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(426, 49);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 13;
            // 
            // AddConstraintUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 462);
            this.Controls.Add(this.listViewConstraints);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonAddConstraint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonDeleteConstraint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonFinish);
            this.Controls.Add(this.listBox1);
            this.Name = "AddConstraintUI";
            this.Text = "AddConstraintUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewConstraints;
        private System.Windows.Forms.ColumnHeader columnHeaderConstraintName;
        private System.Windows.Forms.ColumnHeader columnHeaderConstraintEquation;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddConstraint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDeleteConstraint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonFinish;
        private System.Windows.Forms.ListBox listBox1;
    }
}