
namespace archivosPlanos
{
    partial class btncrearTxt
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTxt = new System.Windows.Forms.Button();
            this.btnCsv = new System.Windows.Forms.Button();
            this.btnXml = new System.Windows.Forms.Button();
            this.btnRtf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTxt
            // 
            this.btnTxt.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTxt.Location = new System.Drawing.Point(25, 103);
            this.btnTxt.Name = "btnTxt";
            this.btnTxt.Size = new System.Drawing.Size(121, 43);
            this.btnTxt.TabIndex = 0;
            this.btnTxt.Text = ".TXT";
            this.btnTxt.UseVisualStyleBackColor = true;
            this.btnTxt.Click += new System.EventHandler(this.btnTxt_Click);
            // 
            // btnCsv
            // 
            this.btnCsv.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCsv.Location = new System.Drawing.Point(176, 103);
            this.btnCsv.Name = "btnCsv";
            this.btnCsv.Size = new System.Drawing.Size(121, 43);
            this.btnCsv.TabIndex = 1;
            this.btnCsv.Text = ".CSV";
            this.btnCsv.UseVisualStyleBackColor = true;
            this.btnCsv.Click += new System.EventHandler(this.btnCsv_Click);
            // 
            // btnXml
            // 
            this.btnXml.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXml.Location = new System.Drawing.Point(323, 103);
            this.btnXml.Name = "btnXml";
            this.btnXml.Size = new System.Drawing.Size(121, 43);
            this.btnXml.TabIndex = 2;
            this.btnXml.Text = ".XML";
            this.btnXml.UseVisualStyleBackColor = true;
            this.btnXml.Click += new System.EventHandler(this.btnXml_Click);
            // 
            // btnRtf
            // 
            this.btnRtf.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRtf.Location = new System.Drawing.Point(469, 103);
            this.btnRtf.Name = "btnRtf";
            this.btnRtf.Size = new System.Drawing.Size(121, 43);
            this.btnRtf.TabIndex = 3;
            this.btnRtf.Text = ".RTF";
            this.btnRtf.UseVisualStyleBackColor = true;
            this.btnRtf.Click += new System.EventHandler(this.btnRtf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(151, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(363, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Seleccione un tipo de archivo:";
            // 
            // btncrearTxt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 215);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRtf);
            this.Controls.Add(this.btnXml);
            this.Controls.Add(this.btnCsv);
            this.Controls.Add(this.btnTxt);
            this.Name = "btncrearTxt";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTxt;
        private System.Windows.Forms.Button btnCsv;
        private System.Windows.Forms.Button btnXml;
        private System.Windows.Forms.Button btnRtf;
        private System.Windows.Forms.Label label1;
    }
}

