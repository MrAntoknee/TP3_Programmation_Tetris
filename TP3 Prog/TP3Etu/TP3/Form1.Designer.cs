namespace TP3
{
  partial class tetrisGameCore
  {
    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Nettoyage des ressources utilisées.
    /// </summary>
    /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose( );
      }
      base.Dispose( disposing );
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent( )
    {
      this.components = new System.ComponentModel.Container();
      this.tableauJeu = new System.Windows.Forms.TableLayoutPanel();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.démarrerLaPartieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.configurationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.timerDescente = new System.Windows.Forms.Timer(this.components);
      this.tempsDeJeu = new System.Windows.Forms.Timer(this.components);
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableauJeu
      // 
      this.tableauJeu.ColumnCount = 20;
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.63538F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.220217F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01805F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01805F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01805F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01805F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01805F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01805F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01805F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.01805F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
      this.tableauJeu.Location = new System.Drawing.Point(349, 30);
      this.tableauJeu.Margin = new System.Windows.Forms.Padding(0);
      this.tableauJeu.Name = "tableauJeu";
      this.tableauJeu.RowCount = 30;
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.444445F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.166667F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.350646F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.001134F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
      this.tableauJeu.Size = new System.Drawing.Size(421, 697);
      this.tableauJeu.TabIndex = 1;
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.configurationsToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
      this.menuStrip1.Size = new System.Drawing.Size(771, 28);
      this.menuStrip1.TabIndex = 2;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // optionsToolStripMenuItem
      // 
      this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.démarrerLaPartieToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.exitToolStripMenuItem});
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(42, 24);
      this.optionsToolStripMenuItem.Text = "Jeu";
      // 
      // démarrerLaPartieToolStripMenuItem
      // 
      this.démarrerLaPartieToolStripMenuItem.Name = "démarrerLaPartieToolStripMenuItem";
      this.démarrerLaPartieToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
      this.démarrerLaPartieToolStripMenuItem.Text = "Démarrer la partie";
      this.démarrerLaPartieToolStripMenuItem.Click += new System.EventHandler(this.démarrerLaPartieToolStripMenuItem_Click);
      // 
      // restartToolStripMenuItem
      // 
      this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
      this.restartToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
      this.restartToolStripMenuItem.Text = "Recommencer la partie";
      this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(238, 26);
      this.exitToolStripMenuItem.Text = "Quitter";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // configurationsToolStripMenuItem
      // 
      this.configurationsToolStripMenuItem.Name = "configurationsToolStripMenuItem";
      this.configurationsToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
      this.configurationsToolStripMenuItem.Text = "Configurations";
      this.configurationsToolStripMenuItem.Click += new System.EventHandler(this.configurationsToolStripMenuItem_Click);
      // 
      // timerDescente
      // 
      this.timerDescente.Enabled = true;
      this.timerDescente.Interval = 1000;
      this.timerDescente.Tick += new System.EventHandler(this.timerDescente_Tick);
      // 
      // tempsDeJeu
      // 
      this.tempsDeJeu.Enabled = true;
      this.tempsDeJeu.Interval = 1000;
      this.tempsDeJeu.Tick += new System.EventHandler(this.tempsDeJeu_Tick);
      // 
      // tetrisGameCore
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(771, 725);
      this.Controls.Add(this.tableauJeu);
      this.Controls.Add(this.menuStrip1);
      this.KeyPreview = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "tetrisGameCore";
      this.Text = "Titris";
      this.Load += new System.EventHandler(this.frmLoad);
      this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tetrisGameCore_KeyPress);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableauJeu;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.Timer timerDescente;
    private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem démarrerLaPartieToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem configurationsToolStripMenuItem;
    private System.Windows.Forms.Timer tempsDeJeu;
  }
}

