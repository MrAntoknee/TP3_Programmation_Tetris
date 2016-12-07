namespace TP3
{
  partial class frmConfigurations
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
      this.trackBarLignes = new System.Windows.Forms.TrackBar();
      this.trackBarColonnes = new System.Windows.Forms.TrackBar();
      this.numLignes = new System.Windows.Forms.NumericUpDown();
      this.numColonnes = new System.Windows.Forms.NumericUpDown();
      this.lblNbrLignes = new System.Windows.Forms.Label();
      this.lblNbrColonnes = new System.Windows.Forms.Label();
      this.checkBoxMusique = new System.Windows.Forms.CheckBox();
      this.btnValider = new System.Windows.Forms.Button();
      this.btnAnnuler = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarLignes)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarColonnes)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numLignes)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numColonnes)).BeginInit();
      this.SuspendLayout();
      // 
      // trackBarLignes
      // 
      this.trackBarLignes.Location = new System.Drawing.Point(168, 19);
      this.trackBarLignes.Maximum = 30;
      this.trackBarLignes.Minimum = 10;
      this.trackBarLignes.Name = "trackBarLignes";
      this.trackBarLignes.Size = new System.Drawing.Size(236, 45);
      this.trackBarLignes.TabIndex = 0;
      this.trackBarLignes.Value = 20;
      this.trackBarLignes.ValueChanged += new System.EventHandler(this.trackBarLignes_ValueChanged);
      // 
      // trackBarColonnes
      // 
      this.trackBarColonnes.Location = new System.Drawing.Point(168, 70);
      this.trackBarColonnes.Maximum = 20;
      this.trackBarColonnes.Minimum = 8;
      this.trackBarColonnes.Name = "trackBarColonnes";
      this.trackBarColonnes.Size = new System.Drawing.Size(236, 45);
      this.trackBarColonnes.TabIndex = 1;
      this.trackBarColonnes.Value = 10;
      this.trackBarColonnes.ValueChanged += new System.EventHandler(this.trackBarColonnes_ValueChanged);
      // 
      // numLignes
      // 
      this.numLignes.Location = new System.Drawing.Point(122, 21);
      this.numLignes.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
      this.numLignes.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numLignes.Name = "numLignes";
      this.numLignes.Size = new System.Drawing.Size(40, 20);
      this.numLignes.TabIndex = 2;
      this.numLignes.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.numLignes.ValueChanged += new System.EventHandler(this.numLignes_ValueChanged);
      // 
      // numColonnes
      // 
      this.numColonnes.Location = new System.Drawing.Point(122, 73);
      this.numColonnes.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.numColonnes.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
      this.numColonnes.Name = "numColonnes";
      this.numColonnes.Size = new System.Drawing.Size(40, 20);
      this.numColonnes.TabIndex = 3;
      this.numColonnes.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numColonnes.ValueChanged += new System.EventHandler(this.numColonnes_ValueChanged);
      // 
      // lblNbrLignes
      // 
      this.lblNbrLignes.AutoSize = true;
      this.lblNbrLignes.Location = new System.Drawing.Point(21, 23);
      this.lblNbrLignes.Name = "lblNbrLignes";
      this.lblNbrLignes.Size = new System.Drawing.Size(95, 13);
      this.lblNbrLignes.TabIndex = 4;
      this.lblNbrLignes.Text = "Nombre de lignes :";
      // 
      // lblNbrColonnes
      // 
      this.lblNbrColonnes.AutoSize = true;
      this.lblNbrColonnes.Location = new System.Drawing.Point(5, 75);
      this.lblNbrColonnes.Name = "lblNbrColonnes";
      this.lblNbrColonnes.Size = new System.Drawing.Size(111, 13);
      this.lblNbrColonnes.TabIndex = 5;
      this.lblNbrColonnes.Text = "Nombre de colonnes :";
      // 
      // checkBoxMusique
      // 
      this.checkBoxMusique.AutoSize = true;
      this.checkBoxMusique.Location = new System.Drawing.Point(145, 111);
      this.checkBoxMusique.Name = "checkBoxMusique";
      this.checkBoxMusique.Size = new System.Drawing.Size(112, 17);
      this.checkBoxMusique.TabIndex = 6;
      this.checkBoxMusique.Text = "Activer la musique";
      this.checkBoxMusique.UseVisualStyleBackColor = true;
      // 
      // btnValider
      // 
      this.btnValider.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnValider.Location = new System.Drawing.Point(12, 143);
      this.btnValider.Name = "btnValider";
      this.btnValider.Size = new System.Drawing.Size(190, 48);
      this.btnValider.TabIndex = 7;
      this.btnValider.Text = "Valider";
      this.btnValider.UseVisualStyleBackColor = true;
      // 
      // btnAnnuler
      // 
      this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnAnnuler.Location = new System.Drawing.Point(208, 143);
      this.btnAnnuler.Name = "btnAnnuler";
      this.btnAnnuler.Size = new System.Drawing.Size(196, 48);
      this.btnAnnuler.TabIndex = 8;
      this.btnAnnuler.Text = "Annuler";
      this.btnAnnuler.UseVisualStyleBackColor = true;
      // 
      // frmConfigurations
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(416, 199);
      this.ControlBox = false;
      this.Controls.Add(this.btnAnnuler);
      this.Controls.Add(this.btnValider);
      this.Controls.Add(this.checkBoxMusique);
      this.Controls.Add(this.lblNbrColonnes);
      this.Controls.Add(this.lblNbrLignes);
      this.Controls.Add(this.numColonnes);
      this.Controls.Add(this.numLignes);
      this.Controls.Add(this.trackBarColonnes);
      this.Controls.Add(this.trackBarLignes);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmConfigurations";
      this.Text = "Configurations";
      ((System.ComponentModel.ISupportInitialize)(this.trackBarLignes)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarColonnes)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numLignes)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numColonnes)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.NumericUpDown numLignes;
    private System.Windows.Forms.NumericUpDown numColonnes;
    private System.Windows.Forms.Label lblNbrLignes;
    private System.Windows.Forms.Label lblNbrColonnes;
    private System.Windows.Forms.Button btnValider;
    private System.Windows.Forms.Button btnAnnuler;
    public System.Windows.Forms.TrackBar trackBarLignes;
    public System.Windows.Forms.TrackBar trackBarColonnes;
    public System.Windows.Forms.CheckBox checkBoxMusique;
  }
}