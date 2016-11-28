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
      RemplirTableauEtat();
      InitializeComponent( );
    }
    //NEED COMMENTS
    int timerI = 0;
    const int nbColonnesJeu = 10;
    const int nbLignesJeu = 20;
    int[,] etatBlocs = new int[nbLignesJeu, nbColonnesJeu];
    int[] blocActifX = new int[4] { 0, 1, 0, 1 };
    int[] blocActifY = new int[4] { 5, 4, 4, 5 };
    Color[] toutesLesCouleurs = new Color[] { Color.Black, Color.Gray, Color.Red };

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


    
    Deplacement SaisirCoupJoueur()
    {
      Deplacement sens;
      ConsoleKeyInfo info = Console.ReadKey();
      if (info.Key == ConsoleKey.LeftArrow)
      {
        sens = Deplacement.GAUCHE;
        return sens;
      }
      else if (info.Key == ConsoleKey.RightArrow)
      {
        sens = Deplacement.DROITE;
        return sens;
      }
      else if (info.Key == ConsoleKey.UpArrow)
      {
        sens = Deplacement.ROTATION_HORAIRE;
        return sens;
      }
      else if (info.Key == ConsoleKey.DownArrow)
      {
        sens = Deplacement.ROTATION_ANTIHORAIRE;
        return sens;
      }
      else if (info.Key == ConsoleKey.Spacebar)
      {
        sens = Deplacement.DESCENTE;
        return sens;
      }
      else
      {
        sens = Deplacement.DESCENTE;
        return sens;
      }
    }

  /* bool BlocPeutBouger(Deplacement sens)
    {
      bool peutBouger = true;
      if (sens == DESCENTE)
      {
        for (int i = 0; i < blocActifX.Length; i++)
        {
          for (int j = 0; j < blocActifY.Length; j++)
          {
            if ((blocActifX[i] && (blocActifY[j] + 1)) == TypeBloc.Gele || (blocActifY[j] + 1) >= nbLignesJeu)
            {
              peutBouger = false;
            }
          }
        }
      }
      else if (sens == GAUCHE)
      {
        for (int i = 0; i < blocActifX.Length; i++)
        {
          if (blocActifX[i] - 1 < 0 || blocActifX[i] - 1 == TypeBloc.Gele)
          {
            peutBouger = false;
          }
        }
      }
      else if (sens == DROITE)
      {
        for(int i = 0; i < blocActifX.Length; i++)
        {
          if (blocActifX[i] + 1 >= nbColonnesJeu || blocActifX[i] + 1 == TypeBloc.Gele)
          {
            peutBouger = false;
          }
        }
      }
      else if(sens == ROTATION_ANTIHORAIRE)
      {
        for (int i = 0; i < blocAcifY.Length; i++)
        {
          blocActifNouveauY[i] = -blocActifX[i];
          blocActifNouveauX[i] = blocActifY[i];
          if (blocActifNouveauY[i] == TypeBloc.Gele || blocActifNouveauX[i] == TypeBloc.Gele || blocActifNouveauY[i] + 1 >= nbColonnesJeu)
          {
            peutBouger = false;
          }
        }
      }
      else
      {
        for (int i = 0; i < blocAcifY.Length; i++)
        {
          blocActifNouveauY[i] = blocActifX[i];
          blocActifNouveauX[i] = -blocActifY[i];
          if (blocActifNouveauY[i] == TypeBloc.Gele || blocActifNouveauX[i] == TypeBloc.Gele || (blocActifNouveauY[i] + 1 < 0)
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
      etatBlocs[8, 8] = (int)TypeBloc.Gelé;//**********************************************
      for (int compteur = 0; compteur < 4; compteur++)
      {
        etatBlocs[blocActifX[compteur], blocActifY[compteur]] = (int)TypeBloc.Carré;
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
      refaireCouleurs();
      for (int compteur = 0; compteur < 4; compteur++)
      {
        etatBlocs[blocActifX[compteur], blocActifY[compteur]] = (int)TypeBloc.None;
      }
      for (int compteur = 0; compteur < 4; compteur++)
      {
        blocActifX[compteur]++;
      }
      timerI++;
    }
  }








}
