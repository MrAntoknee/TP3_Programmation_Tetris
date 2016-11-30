using System;
using System.Drawing;
using System.Windows.Forms;

namespace TP3
{
  enum TypeBloc { None, Gelé, Carré, Ligne, T, L, J, S, Z }
  enum Deplacement { DESCENTE, DROITE, GAUCHE, ROTATION_HORAIRE, ROTATION_ANTIHORAIRE }
  public partial class tetrisGameCore : Form
  {
    public tetrisGameCore( )
    {
      pieceAleatoire = PieceAleatoire();
      blocActifX = AssignerPositionFormeX(pieceAleatoire);
      blocActifY = AssignerPositionFormeY(pieceAleatoire);
      RemplirTableauEtat();
      InitializeComponent();
    }
    //NEED COMMENTS
    int pieceAleatoire = 0;
    int timerAction = 0;
    const int nbColonnesJeu = 10;
    const int nbLignesJeu = 20;
    int[,] etatBlocs = new int[nbLignesJeu, nbColonnesJeu];
    int[] blocActifX = null;
    int[] blocActifY = null;
    Color[] toutesLesCouleurs = new Color[] { Color.Black, Color.Gray, Color.Red, Color.Teal };

    #region Code fourni

    // Représentation visuelles du jeu en mémoire.
    PictureBox[,] toutesImagesVisuelles = null;
    
    /// <summary>
    /// Gestionnaire de l'événement se produisant lors du premier affichage 
    /// du formulaire principal.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmLoad( object sender, EventArgs e )
    {
      // Ne pas oublier de mettre en place les valeurs nécessaires à une partie.
      ExecuterTestsUnitaires();
      InitialiserSurfaceDeJeu(nbLignesJeu, nbColonnesJeu);

    }

    private void InitialiserSurfaceDeJeu(int nbLignes, int nbCols)
    {
      // Création d'une surface de jeu 10 colonnes x 20 lignes
      toutesImagesVisuelles = new PictureBox[nbLignes, nbCols];
      tableauJeu.Controls.Clear();
      tableauJeu.ColumnCount = toutesImagesVisuelles.GetLength(1);
      tableauJeu.RowCount = toutesImagesVisuelles.GetLength(0);
      for (int i = 0; i < tableauJeu.RowCount; i++)
      {
        tableauJeu.RowStyles[i].Height = tableauJeu.Height / tableauJeu.RowCount;
        for (int j = 0; j < tableauJeu.ColumnCount; j++)
        {
          tableauJeu.ColumnStyles[j].Width = tableauJeu.Width / tableauJeu.ColumnCount;
          // Création dynamique des PictureBox qui contiendront les pièces de jeu
          PictureBox newPictureBox = new PictureBox();
          newPictureBox.Width = tableauJeu.Width / tableauJeu.ColumnCount;
          newPictureBox.Height = tableauJeu.Height / tableauJeu.RowCount;
          newPictureBox.BackColor = Color.Black;
          newPictureBox.Margin = new Padding(0, 0, 0, 0);
          newPictureBox.BorderStyle = BorderStyle.FixedSingle;
          newPictureBox.Dock = DockStyle.Fill;

          // Assignation de la représentation visuelle.
          toutesImagesVisuelles[i, j] = newPictureBox;
          // Ajout dynamique du PictureBox créé dans la grille de mise en forme.
          // A noter que l' "origine" du repère dans le tableau est en haut à gauche.
          tableauJeu.Controls.Add(newPictureBox, j, i);
        }
      }
    }
    #endregion



    #region Code à développer
    /// <summary>
    /// Faites ici les appels requis pour vos tests unitaires.
    /// </summary>
    void ExecuterTestsUnitaires()
    {      
      ExecuterTestABC();
      // A compléter...
    }

    // A renommer et commenter!
    void ExecuterTestABC()
    {
      // Mise en place des données du test
      
      // Exécuter de la méthode à tester
      
      // Validation des résultats
      
      // Clean-up
    }


    #endregion


  /*bool BlocPeutBouger(KeyPressEventArgs e)
    {
      bool peutBouger = true;
      if (e == 65)
      {
        for (int i = 0; i < blocActifX.Length; i++)
        {
          for (int j = 0; j < blocActifY.Length; j++)
          {
            if (blocActifX[i] == (int)TypeBloc.Gelé && (blocActifY[j] + 1) == (int)TypeBloc.Gelé || (blocActifY[j] + 1) >= nbLignesJeu)
            {
              peutBouger = false;
            }
          }
        }
      }
      else if (sens == Deplacement.GAUCHE)
      {
        for (int i = 0; i < blocActifX.Length; i++)
        {
          if (blocActifX[i] - 1 < 0 || blocActifX[i] - 1 == (int)TypeBloc.Gelé)
          {
            peutBouger = false;
          }
        }
      }
      else if (sens == Deplacement.DROITE)
      {
        for(int i = 0; i < blocActifX.Length; i++)
        {
          if (blocActifX[i] + 1 >= nbColonnesJeu || blocActifX[i] + 1 == (int)TypeBloc.Gelé)
          {
            peutBouger = false;
          }
        }
      }
      else if(sens == Deplacement.ROTATION_ANTIHORAIRE)
      {
        for (int i = 0; i < blocActifY.Length; i++)
        {
          blocActifNouveauY[i] = -blocActifX[i];
          blocActifNouveauX[i] = blocActifY[i];
          if (blocActifNouveauY[i] == (int)TypeBloc.Gelé || blocActifNouveauX[i] == (int)TypeBloc.Gelé || blocActifNouveauY[i] + 1 >= nbColonnesJeu)
          {
            peutBouger = false;
          }
        }
      }
      else
      {
        for (int i = 0; i < blocActifY.Length; i++)
        {
          blocActifNouveauY[i] = blocActifX[i];
          blocActifNouveauX[i] = -blocActifY[i];
          if (blocActifNouveauY[i] == (int)TypeBloc.Gelé || blocActifNouveauX[i] == (int)TypeBloc.Gelé || (blocActifNouveauY[i] + 1) < 0)
          {
            peutBouger = false;
          }
        }
      }
      return peutBouger;
    }*/
    /// <summary>
    /// Permet la sortie de l'application à tout moment.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
    void RemplirTableauEtat()
    {
      for (int compteur = 0; compteur < nbLignesJeu; compteur++)
      {
        for (int compteur2 = 0; compteur2 < nbColonnesJeu; compteur2++)
        {
          etatBlocs[compteur, compteur2] = (int)TypeBloc.None;
        }
      }
    }
    void refaireCouleurs()
    {
      RemplirTableauEtat();
      etatBlocs[8, 5] = (int)TypeBloc.Gelé;//**************************************************************************************************************
      for (int compteur = 0; compteur < 4; compteur++)
      {
        etatBlocs[blocActifX[compteur], blocActifY[compteur]] = pieceAleatoire;
      }
      for (int compteur = 0; compteur < nbLignesJeu; compteur++)
      {
        for (int compteur2 = 0; compteur2 < nbColonnesJeu; compteur2++)
        {
          toutesImagesVisuelles[compteur,compteur2].BackColor = toutesLesCouleurs[etatBlocs[compteur, compteur2]];
        }
      }
    }
    private void timerDescente_Tick(object sender, EventArgs e)
    {
      for (int compteur = 0; compteur < 4; compteur++)
      {
        etatBlocs[blocActifX[compteur], blocActifY[compteur]] = (int)TypeBloc.None;
      }
      for (int compteur = 0; compteur < 4; compteur++)
      {
        blocActifX[compteur]++;
      }
      timerAction++;
      refaireCouleurs();
    }

    private void restartToolStripMenuItem_Click(object sender, EventArgs e)
    {
      refaireJeu();
    }
    /// <summary>
    /// Fonction qui recommence le jeu à zéro.
    /// </summary>
    //<alangevin>
    void refaireJeu()
    {
      timerDescente.Stop();
           timerAction = 0;
      for (int compteur = 0; compteur < nbLignesJeu; compteur++)
      {
        for (int compteur2 = 0; compteur2 < nbColonnesJeu; compteur2++)
        {
          etatBlocs[compteur, compteur2] = (int)TypeBloc.None;
          toutesImagesVisuelles[compteur, compteur2].BackColor = toutesLesCouleurs[etatBlocs[compteur, compteur2]];
        }
      }
      timerDescente.Start();
    }
    //</alangevin>
    int[] AssignerPositionFormeX(int pieceAleatoire)
    {
      int[] tableauValeurBlocs;
      if (pieceAleatoire == (int)TypeBloc.Carré)
      {
       return tableauValeurBlocs = new int[4] { 0, 1, 0, 1 };
      }
      else if (pieceAleatoire == (int)TypeBloc.Ligne)
      {
        return tableauValeurBlocs = new int[4] { 0, 1, 2, 3 };
      }
      else 
      {
        return tableauValeurBlocs = new int[4] { 0, 0, 0, 0 };
      }
    }
    int[] AssignerPositionFormeY(int pieceAleatoire)
    {
      int[] tableauValeurBlocs;
      if (pieceAleatoire == (int)TypeBloc.Carré)
      {
        return tableauValeurBlocs = new int[4] { 5, 4, 4, 5 };
      }
      else if (pieceAleatoire == (int)TypeBloc.Ligne)
      {
        return tableauValeurBlocs = new int[4] { 5, 5, 5, 5 };
      }
      else
      {
        return tableauValeurBlocs = new int[4] { 0, 0, 0, 0 };
      }
    }
    int PieceAleatoire()
    {
      Random rnd = new Random();
      int blocAleatoire = rnd.Next(2,4);
      return blocAleatoire;
    }

    private void tetrisGameCore_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 65 || e.KeyChar == 97)
      {
        for (int compteur = 0; compteur < blocActifY.Length;compteur++)
        {
          blocActifY[compteur]--;
          refaireCouleurs();
        }
      }
      else if (e.KeyChar == 68 || e.KeyChar == 100)
      {
        for (int compteur = 0; compteur < blocActifY.Length; compteur++)
        {
          blocActifY[compteur]++;
          refaireCouleurs();
        }
      }
      //<alangevin>
      else if (e.KeyChar == 69 || e.KeyChar == 101)
      {
        int[] blocActifNouveauY = blocActifY;
        int[] blocActifNouveauX = blocActifX;
        int abc = 1;
        int compteurExterne = 0;
        for (int compteur = 1; compteur < blocActifY.Length; compteur++)
        {
          if(compteurExterne%2 == 0)
          {
            blocActifY[compteur] = blocActifNouveauY[0] - abc;
            blocActifX[compteur] = blocActifNouveauX[0];
            abc++;
          }
          else 
          {
            
          }
        }
        refaireCouleurs();
      }
      /*else if (info.Key == ConsoleKey.DownArrow)
      {
        sens = Deplacement.ROTATION_ANTIHORAIRE;
        return sens;
      }*/
      //</alangevin>
      else if (e.KeyChar == 83 || e.KeyChar == 32 || e.KeyChar == 115)
      {
        for (int compteur = 0; compteur < blocActifX.Length; compteur++)
        {
          blocActifX[compteur]++;
          refaireCouleurs();
        }
      }
      else
      {

      }
    }
  }
  







}
