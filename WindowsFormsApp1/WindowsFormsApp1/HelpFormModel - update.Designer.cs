
namespace WindowsFormsApp1
{
    partial class HelpFormModelupdate
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
            this.components = new System.ComponentModel.Container();
            this.производителиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.autosalonDataSet = new WindowsFormsApp1.autosalonDataSet();
            this.модельBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.модельTableAdapter = new WindowsFormsApp1.autosalonDataSetTableAdapters.МодельTableAdapter();
            this.autosalonDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.производителиTableAdapter = new WindowsFormsApp1.autosalonDataSetTableAdapters.ПроизводителиTableAdapter();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.производителиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autosalonDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.модельBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autosalonDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // производителиBindingSource
            // 
            this.производителиBindingSource.DataMember = "Производители";
            this.производителиBindingSource.DataSource = this.autosalonDataSet;
            // 
            // autosalonDataSet
            // 
            this.autosalonDataSet.DataSetName = "autosalonDataSet";
            this.autosalonDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // модельBindingSource
            // 
            this.модельBindingSource.DataMember = "Модель";
            this.модельBindingSource.DataSource = this.autosalonDataSet;
            // 
            // модельTableAdapter
            // 
            this.модельTableAdapter.ClearBeforeFill = true;
            // 
            // autosalonDataSetBindingSource
            // 
            this.autosalonDataSetBindingSource.DataSource = this.autosalonDataSet;
            this.autosalonDataSetBindingSource.Position = 0;
            // 
            // производителиTableAdapter
            // 
            this.производителиTableAdapter.ClearBeforeFill = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(222, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 17);
            this.label8.TabIndex = 41;
            this.label8.Text = "Производитель";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 40;
            this.label7.Text = "Цвет";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(627, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 39;
            this.label6.Text = "год выпуска";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(462, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 17);
            this.label5.TabIndex = 38;
            this.label5.Text = "Наименование модели";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 17);
            this.label4.TabIndex = 37;
            this.label4.Text = "КП";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 36;
            this.label2.Text = "Тип кузова";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 35;
            this.label1.Text = "Марка";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(425, 356);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 58);
            this.button2.TabIndex = 34;
            this.button2.Text = "Обновить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 356);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 58);
            this.button1.TabIndex = 33;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(211, 261);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 32;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(86, 261);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 31;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(595, 206);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 30;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(479, 206);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 29;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Автомат",
            "Полуавтомат",
            "Механика"});
            this.comboBox1.Location = new System.Drawing.Point(341, 205);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 28;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(211, 205);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 27;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 206);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 17);
            this.label3.TabIndex = 25;
            this.label3.Text = "Добавьте новые данные о модели";
            // 
            // HelpFormModelupdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Name = "HelpFormModelupdate";
            this.Text = "HelpFormAutomobily";
            this.Load += new System.EventHandler(this.HelpFormModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.производителиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autosalonDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.модельBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autosalonDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private autosalonDataSet autosalonDataSet;
        private System.Windows.Forms.BindingSource модельBindingSource;
        private autosalonDataSetTableAdapters.МодельTableAdapter модельTableAdapter;
        private System.Windows.Forms.BindingSource autosalonDataSetBindingSource;
        private System.Windows.Forms.BindingSource производителиBindingSource;
        private autosalonDataSetTableAdapters.ПроизводителиTableAdapter производителиTableAdapter;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}