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
      this.lblPointageTexte = new System.Windows.Forms.Label();
      this.lblPointage = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.lblDroiteInfo = new System.Windows.Forms.Label();
      this.lblGaucheInfo = new System.Windows.Forms.Label();
      this.lblRotHoraireInfo = new System.Windows.Forms.Label();
      this.lblRotAntiHoraireInfo = new System.Windows.Forms.Label();
      this.lblTouchesDescente = new System.Windows.Forms.Label();
      this.lblToucheDroite = new System.Windows.Forms.Label();
      this.lblToucheGauche = new System.Windows.Forms.Label();
      this.lblToucheRotHoraire = new System.Windows.Forms.Label();
      this.lblToucheRotAntiHoraire = new System.Windows.Forms.Label();
      this.lblColonnesTexte = new System.Windows.Forms.Label();
      this.lblLignesTexte = new System.Windows.Forms.Label();
      this.checkBoxActivationMusique = new System.Windows.Forms.CheckBox();
      this.numLignesJeu = new System.Windows.Forms.NumericUpDown();
      this.numColonnesJeu = new System.Windows.Forms.NumericUpDown();
      this.trackBarLignesJeu = new System.Windows.Forms.TrackBar();
      this.trackBarColonnesJeu = new System.Windows.Forms.TrackBar();
      this.btnOk = new System.Windows.Forms.Button();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numLignesJeu)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numColonnesJeu)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarLignesJeu)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarColonnesJeu)).BeginInit();
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
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 22F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
      this.tableauJeu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
      this.tableauJeu.Location = new System.Drawing.Point(262, 24);
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
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
      this.tableauJeu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
      this.tableauJeu.Size = new System.Drawing.Size(316, 566);
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
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
      this.menuStrip1.Size = new System.Drawing.Size(578, 24);
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
      this.optionsToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
      this.optionsToolStripMenuItem.Text = "Jeu";
      // 
      // démarrerLaPartieToolStripMenuItem
      // 
      this.démarrerLaPartieToolStripMenuItem.Name = "démarrerLaPartieToolStripMenuItem";
      this.démarrerLaPartieToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.démarrerLaPartieToolStripMenuItem.Text = "Démarrer la partie";
      this.démarrerLaPartieToolStripMenuItem.Click += new System.EventHandler(this.démarrerLaPartieToolStripMenuItem_Click);
      // 
      // restartToolStripMenuItem
      // 
      this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
      this.restartToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.restartToolStripMenuItem.Text = "Recommencer la partie";
      this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
      this.exitToolStripMenuItem.Text = "Quitter";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // configurationsToolStripMenuItem
      // 
      this.configurationsToolStripMenuItem.Name = "configurationsToolStripMenuItem";
      this.configurationsToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
      this.configurationsToolStripMenuItem.Text = "Configurations";
      this.configurationsToolStripMenuItem.Click += new System.EventHandler(this.configurationsToolStripMenuItem_Click);
      // 
      // timerDescente
      // 
      this.timerDescente.Enabled = true;
      this.timerDescente.Interval = 1000;
      this.timerDescente.Tick += new System.EventHandler(this.timerDescente_Tick);
      // 
      // lblPointageTexte
      // 
      this.lblPointageTexte.AutoSize = true;
      this.lblPointageTexte.Location = new System.Drawing.Point(12, 151);
      this.lblPointageTexte.Name = "lblPointageTexte";
      this.lblPointageTexte.Size = new System.Drawing.Size(81, 13);
      this.lblPointageTexte.TabIndex = 3;
      this.lblPointageTexte.Text = "Pointage total : ";
      // 
      // lblPointage
      // 
      this.lblPointage.AutoSize = true;
      this.lblPointage.Location = new System.Drawing.Point(88, 151);
      this.lblPointage.Name = "lblPointage";
      this.lblPointage.Size = new System.Drawing.Size(13, 13);
      this.lblPointage.TabIndex = 6;
      this.lblPointage.Text = "0";
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 209);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(130, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Déplacement vers le bas :";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblDroiteInfo
      // 
      this.lblDroiteInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
      this.lblDroiteInfo.AutoSize = true;
      this.lblDroiteInfo.Location = new System.Drawing.Point(12, 240);
      this.lblDroiteInfo.Name = "lblDroiteInfo";
      this.lblDroiteInfo.Size = new System.Drawing.Size(139, 13);
      this.lblDroiteInfo.TabIndex = 1;
      this.lblDroiteInfo.Text = "Déplacement vers la droite :";
      this.lblDroiteInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblGaucheInfo
      // 
      this.lblGaucheInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
      this.lblGaucheInfo.AutoSize = true;
      this.lblGaucheInfo.Location = new System.Drawing.Point(12, 271);
      this.lblGaucheInfo.Name = "lblGaucheInfo";
      this.lblGaucheInfo.Size = new System.Drawing.Size(152, 13);
      this.lblGaucheInfo.TabIndex = 0;
      this.lblGaucheInfo.Text = "Déplacement vers la gauche : ";
      this.lblGaucheInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // lblRotHoraireInfo
      // 
      this.lblRotHoraireInfo.AutoSize = true;
      this.lblRotHoraireInfo.Location = new System.Drawing.Point(12, 302);
      this.lblRotHoraireInfo.Name = "lblRotHoraireInfo";
      this.lblRotHoraireInfo.Size = new System.Drawing.Size(91, 13);
      this.lblRotHoraireInfo.TabIndex = 7;
      this.lblRotHoraireInfo.Text = "Rotation horaire : ";
      // 
      // lblRotAntiHoraireInfo
      // 
      this.lblRotAntiHoraireInfo.AutoSize = true;
      this.lblRotAntiHoraireInfo.Location = new System.Drawing.Point(12, 333);
      this.lblRotAntiHoraireInfo.Name = "lblRotAntiHoraireInfo";
      this.lblRotAntiHoraireInfo.Size = new System.Drawing.Size(111, 13);
      this.lblRotAntiHoraireInfo.TabIndex = 8;
      this.lblRotAntiHoraireInfo.Text = "Rotation anti-horaire : ";
      // 
      // lblTouchesDescente
      // 
      this.lblTouchesDescente.AutoSize = true;
      this.lblTouchesDescente.Location = new System.Drawing.Point(148, 209);
      this.lblTouchesDescente.Name = "lblTouchesDescente";
      this.lblTouchesDescente.Size = new System.Drawing.Size(61, 13);
      this.lblTouchesDescente.TabIndex = 9;
      this.lblTouchesDescente.Text = "Espace / S";
      // 
      // lblToucheDroite
      // 
      this.lblToucheDroite.AutoSize = true;
      this.lblToucheDroite.Location = new System.Drawing.Point(157, 240);
      this.lblToucheDroite.Name = "lblToucheDroite";
      this.lblToucheDroite.Size = new System.Drawing.Size(15, 13);
      this.lblToucheDroite.TabIndex = 10;
      this.lblToucheDroite.Text = "D";
      // 
      // lblToucheGauche
      // 
      this.lblToucheGauche.AutoSize = true;
      this.lblToucheGauche.Location = new System.Drawing.Point(170, 271);
      this.lblToucheGauche.Name = "lblToucheGauche";
      this.lblToucheGauche.Size = new System.Drawing.Size(14, 13);
      this.lblToucheGauche.TabIndex = 11;
      this.lblToucheGauche.Text = "A";
      // 
      // lblToucheRotHoraire
      // 
      this.lblToucheRotHoraire.AutoSize = true;
      this.lblToucheRotHoraire.Location = new System.Drawing.Point(109, 302);
      this.lblToucheRotHoraire.Name = "lblToucheRotHoraire";
      this.lblToucheRotHoraire.Size = new System.Drawing.Size(14, 13);
      this.lblToucheRotHoraire.TabIndex = 12;
      this.lblToucheRotHoraire.Text = "E";
      // 
      // lblToucheRotAntiHoraire
      // 
      this.lblToucheRotAntiHoraire.AutoSize = true;
      this.lblToucheRotAntiHoraire.Location = new System.Drawing.Point(129, 333);
      this.lblToucheRotAntiHoraire.Name = "lblToucheRotAntiHoraire";
      this.lblToucheRotAntiHoraire.Size = new System.Drawing.Size(15, 13);
      this.lblToucheRotAntiHoraire.TabIndex = 13;
      this.lblToucheRotAntiHoraire.Text = "Q";
      // 
      // lblColonnesTexte
      // 
      this.lblColonnesTexte.AutoSize = true;
      this.lblColonnesTexte.Location = new System.Drawing.Point(82, 437);
      this.lblColonnesTexte.Name = "lblColonnesTexte";
      this.lblColonnesTexte.Size = new System.Drawing.Size(105, 13);
      this.lblColonnesTexte.TabIndex = 15;
      this.lblColonnesTexte.Text = "Nombre de colonnes";
      // 
      // lblLignesTexte
      // 
      this.lblLignesTexte.AutoSize = true;
      this.lblLignesTexte.Location = new System.Drawing.Point(90, 362);
      this.lblLignesTexte.Name = "lblLignesTexte";
      this.lblLignesTexte.Size = new System.Drawing.Size(89, 13);
      this.lblLignesTexte.TabIndex = 16;
      this.lblLignesTexte.Text = "Nombre de lignes";
      // 
      // checkBoxActivationMusique
      // 
      this.checkBoxActivationMusique.AutoSize = true;
      this.checkBoxActivationMusique.Location = new System.Drawing.Point(75, 503);
      this.checkBoxActivationMusique.Name = "checkBoxActivationMusique";
      this.checkBoxActivationMusique.Size = new System.Drawing.Size(112, 17);
      this.checkBoxActivationMusique.TabIndex = 17;
      this.checkBoxActivationMusique.Text = "Activer la musique";
      this.checkBoxActivationMusique.UseVisualStyleBackColor = true;
      this.checkBoxActivationMusique.CheckedChanged += new System.EventHandler(this.checkBoxActivationMusique_CheckedChanged);
      // 
      // numLignesJeu
      // 
      this.numLignesJeu.Location = new System.Drawing.Point(15, 383);
      this.numLignesJeu.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
      this.numLignesJeu.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numLignesJeu.Name = "numLignesJeu";
      this.numLignesJeu.Size = new System.Drawing.Size(40, 20);
      this.numLignesJeu.TabIndex = 18;
      this.numLignesJeu.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.numLignesJeu.ValueChanged += new System.EventHandler(this.numLignesJeu_ValueChanged);
      // 
      // numColonnesJeu
      // 
      this.numColonnesJeu.Location = new System.Drawing.Point(15, 453);
      this.numColonnesJeu.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.numColonnesJeu.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
      this.numColonnesJeu.Name = "numColonnesJeu";
      this.numColonnesJeu.Size = new System.Drawing.Size(40, 20);
      this.numColonnesJeu.TabIndex = 19;
      this.numColonnesJeu.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numColonnesJeu.ValueChanged += new System.EventHandler(this.numColonnesJeu_ValueChanged);
      // 
      // trackBarLignesJeu
      // 
      this.trackBarLignesJeu.Location = new System.Drawing.Point(61, 378);
      this.trackBarLignesJeu.Maximum = 30;
      this.trackBarLignesJeu.Minimum = 10;
      this.trackBarLignesJeu.Name = "trackBarLignesJeu";
      this.trackBarLignesJeu.Size = new System.Drawing.Size(183, 45);
      this.trackBarLignesJeu.TabIndex = 20;
      this.trackBarLignesJeu.Value = 20;
      this.trackBarLignesJeu.ValueChanged += new System.EventHandler(this.trackBarLignesJeu_ValueChanged);
      // 
      // trackBarColonnesJeu
      // 
      this.trackBarColonnesJeu.Location = new System.Drawing.Point(61, 453);
      this.trackBarColonnesJeu.Maximum = 20;
      this.trackBarColonnesJeu.Minimum = 8;
      this.trackBarColonnesJeu.Name = "trackBarColonnesJeu";
      this.trackBarColonnesJeu.Size = new System.Drawing.Size(183, 45);
      this.trackBarColonnesJeu.TabIndex = 21;
      this.trackBarColonnesJeu.Value = 10;
      this.trackBarColonnesJeu.ValueChanged += new System.EventHandler(this.trackBarColonnesJeu_ValueChanged);
      // 
      // btnOk
      // 
      this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.btnOk.Location = new System.Drawing.Point(15, 532);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(229, 45);
      this.btnOk.TabIndex = 22;
      this.btnOk.Text = "Valider";
      this.btnOk.UseVisualStyleBackColor = true;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // tetrisGameCore
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(578, 589);
      this.Controls.Add(this.btnOk);
      this.Controls.Add(this.trackBarColonnesJeu);
      this.Controls.Add(this.trackBarLignesJeu);
      this.Controls.Add(this.numColonnesJeu);
      this.Controls.Add(this.numLignesJeu);
      this.Controls.Add(this.checkBoxActivationMusique);
      this.Controls.Add(this.lblLignesTexte);
      this.Controls.Add(this.lblColonnesTexte);
      this.Controls.Add(this.lblToucheRotAntiHoraire);
      this.Controls.Add(this.lblToucheRotHoraire);
      this.Controls.Add(this.lblToucheGauche);
      this.Controls.Add(this.lblToucheDroite);
      this.Controls.Add(this.lblTouchesDescente);
      this.Controls.Add(this.lblRotAntiHoraireInfo);
      this.Controls.Add(this.lblRotHoraireInfo);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.lblDroiteInfo);
      this.Controls.Add(this.lblGaucheInfo);
      this.Controls.Add(this.lblPointage);
      this.Controls.Add(this.lblPointageTexte);
      this.Controls.Add(this.tableauJeu);
      this.Controls.Add(this.menuStrip1);
      this.KeyPreview = true;
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "tetrisGameCore";
      this.Text = "Titris";
      this.Load += new System.EventHandler(this.frmLoad);
      this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tetrisGameCore_KeyPress);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numLignesJeu)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numColonnesJeu)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarLignesJeu)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarColonnesJeu)).EndInit();
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
    private System.Windows.Forms.Label lblPointageTexte;
    private System.Windows.Forms.Label lblPointage;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblDroiteInfo;
    private System.Windows.Forms.Label lblGaucheInfo;
    private System.Windows.Forms.Label lblRotHoraireInfo;
    private System.Windows.Forms.Label lblRotAntiHoraireInfo;
    private System.Windows.Forms.Label lblTouchesDescente;
    private System.Windows.Forms.Label lblToucheDroite;
    private System.Windows.Forms.Label lblToucheGauche;
    private System.Windows.Forms.Label lblToucheRotHoraire;
    private System.Windows.Forms.Label lblToucheRotAntiHoraire;
    private System.Windows.Forms.Label lblColonnesTexte;
    private System.Windows.Forms.Label lblLignesTexte;
    private System.Windows.Forms.CheckBox checkBoxActivationMusique;
    private System.Windows.Forms.NumericUpDown numLignesJeu;
    private System.Windows.Forms.NumericUpDown numColonnesJeu;
    public System.Windows.Forms.TrackBar trackBarLignesJeu;
    public System.Windows.Forms.TrackBar trackBarColonnesJeu;
    private System.Windows.Forms.Button btnOk;
  }
}

