namespace UIVeterin_air
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtAnimal = new System.Windows.Forms.TextBox();
            this.ageetpoids = new System.Windows.Forms.NumericUpDown();
            this.txtPuce = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ageetpoids)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAnimal
            // 
            this.txtAnimal.Location = new System.Drawing.Point(96, 47);
            this.txtAnimal.Name = "txtAnimal";
            this.txtAnimal.Size = new System.Drawing.Size(100, 20);
            this.txtAnimal.TabIndex = 0;
            this.txtAnimal.TextChanged += new System.EventHandler(this.txtAnimal_TextChanged);
            // 
            // ageetpoids
            // 
            this.ageetpoids.Location = new System.Drawing.Point(363, 69);
            this.ageetpoids.Name = "ageetpoids";
            this.ageetpoids.Size = new System.Drawing.Size(120, 20);
            this.ageetpoids.TabIndex = 1;
            this.ageetpoids.ValueChanged += new System.EventHandler(this.ageetpoids_ValueChanged);
            // 
            // txtPuce
            // 
            this.txtPuce.Location = new System.Drawing.Point(145, 144);
            this.txtPuce.Name = "txtPuce";
            this.txtPuce.Size = new System.Drawing.Size(100, 20);
            this.txtPuce.TabIndex = 2;
            this.txtPuce.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(370, 138);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtPuce);
            this.Controls.Add(this.ageetpoids);
            this.Controls.Add(this.txtAnimal);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ageetpoids)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAnimal;
        private System.Windows.Forms.NumericUpDown ageetpoids;
        private System.Windows.Forms.TextBox txtPuce;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

