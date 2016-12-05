using System;
using System.Drawing;
using System.Windows.Forms;

namespace TP3
{
  enum TypeBloc { None, Gelé, Carré, Ligne, LigneVerticale, T, L, J, S, Z }
  enum Deplacement { DESCENTE, DROITE, GAUCHE, ROTATION_HORAIRE, ROTATION_ANTIHORAIRE }
  public partial class tetrisGameCore : Form
  {
    public tetrisGameCore( )
    {
      FonctionsJeu();
      InitializeComponent();
    }
    //NEED COMMENTS
    int addX = 0;
    int addY = (nbColonnesJeu/2);
    int pieceAleatoire = 0;
    const int nbColonnesJeu = 10;
    const int nbLignesJeu = 20;
    int[,] etatBlocs = new int[nbLignesJeu, nbColonnesJeu];
    int[] blocActifX = null;
    int[] blocActifY = null;
    Color[] toutesLesCouleurs = new Color[] { Color.Black, Color.Gray, Color.Red, Color.Teal, Color.Teal };

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


    bool BlocPeutBouger(KeyPressEventArgs e)
    {
      bool peutBouger = true;
      // Descendre
      if (e.KeyChar == 83 || e.KeyChar == 32 || e.KeyChar == 115)
      {
        for (int i = 0; i < blocActifX.Length; i++)
        {
          if ((blocActifX[i] + addX + 1) == nbLignesJeu)
          {
            peutBouger = false;
          }
          else if (etatBlocs[blocActifX[i] + addX + 1, blocActifY[i] + addY] == (int)TypeBloc.Gelé)
          {
            peutBouger = false;
          }
        }
      }
      // Gauche
      else if (e.KeyChar == 65 || e.KeyChar == 97)
      {
        for (int i = 0; i < blocActifY.Length; i++)
        {
          if (blocActifY[i] + addY - 1 < 0)
          {
            peutBouger = false;
          }
          else if (etatBlocs[blocActifX[i] + addX, blocActifY[i] + addY - 1] == (int)TypeBloc.Gelé)
          {
            peutBouger = false;
          }
        }
      }
      // Droite
      else if (e.KeyChar == 68 || e.KeyChar == 100)
      {
        for (int i = 0; i < blocActifY.Length; i++)
        {
          if (blocActifY[i] + addY + 1 > nbColonnesJeu - 1)
          {
            peutBouger = false;
          }
          else if (etatBlocs[blocActifX[i] + addX, blocActifY[i] + addY + 1] == (int)TypeBloc.Gelé)
          {
            peutBouger = false;
          }
        }
      }
      //<alangevin>
      // Rotation q
      else if (e.KeyChar == 81 || e.KeyChar == 113)
      {
        int[] temporaireTableauY = new int[4];
        int[] temporaireTableauX = new int[4];
        for (int compteur = 0; compteur < blocActifY.Length; compteur++)
        {
          temporaireTableauY[compteur] = blocActifX[compteur];
          temporaireTableauX[compteur] = -blocActifY[compteur];
        }
        for (int i = 0; i < blocActifY.Length; i++)
        {
          // Vérification des côtés
          if ((temporaireTableauY[i] + addY) >= nbColonnesJeu || (temporaireTableauY[i] + addY) < 0)
          {
            peutBouger = false;
          }
          // Vérification haut et bas
          else if ((temporaireTableauX[i] + addX) >= nbLignesJeu || (temporaireTableauX[i] + addX) <= 0)
          {
            peutBouger = false;
          }
          // Vérification des blocs gelés
          else if (etatBlocs[(temporaireTableauX[i] + addX), (temporaireTableauY[i] + addY)] == (int)TypeBloc.Gelé)
          {
                peutBouger = false;                       
          }
        }
      }
      // Rotation e
      else if (e.KeyChar == 69 || e.KeyChar == 101)
      {
        int[] temporaireTableauY = new int[4];
        int[] temporaireTableauX = new int[4];
        for (int compteur = 0; compteur < blocActifY.Length; compteur++)
        {
          temporaireTableauY[compteur] = -blocActifX[compteur];
          temporaireTableauX[compteur] = blocActifY[compteur];
        }
        for (int i = 0; i < blocActifY.Length; i++)
        {
          // Vérification des côtés
          if ((temporaireTableauY[i] + addY) >= nbColonnesJeu || (temporaireTableauY[i] + addY) < 0)
            {
              peutBouger = false;
            }
          // Vérification haut et bas
          else if ((temporaireTableauX[i] + addX) >= nbLignesJeu || (temporaireTableauX[i] + addX) <= 0)
            {
              peutBouger = false;
            }
          // Vérification des blocs gelés
          else if (etatBlocs[(temporaireTableauX[i] + addX), (temporaireTableauY[i] + addY)] == (int)TypeBloc.Gelé)
            {
              peutBouger = false;
            }
        }
      }
      //</alangevin>
      return peutBouger;
      
    }
    /// <summary>
    /// Permet la sortie de l'application à tout moment.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }
    void RemplirTableauEtatVide()
    {
      for (int compteur = 0; compteur < nbLignesJeu; compteur++)
      {
        for (int compteur2 = 0; compteur2 < nbColonnesJeu; compteur2++)
        {
          etatBlocs[compteur, compteur2] = (int)TypeBloc.None;
        }
      }
    }
    void faireCouleursBlocs()
    {
      RemplirTableauEtatVide();
      etatBlocs[0, 5] = (int)TypeBloc.Gelé;//**************************************************************************************************************
      etatBlocs[8, 5] = (int)TypeBloc.Gelé;
      etatBlocs[8, 4] = (int)TypeBloc.Gelé;
      etatBlocs[9, 5] = (int)TypeBloc.Gelé;
      etatBlocs[9, 4] = (int)TypeBloc.Gelé;
      for (int compteur = 0; compteur < 4; compteur++)
      {
        etatBlocs[(blocActifX[compteur] + addX), blocActifY[compteur] + addY] = pieceAleatoire;
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
          etatBlocs[(blocActifX[compteur] + addX), blocActifY[compteur] + addY] = (int)TypeBloc.None;
        }
      addX++;
      faireCouleursBlocs();
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
      addX = 0;
      addY = 5;
      pieceAleatoire = 0;
      for (int compteur = 0; compteur < nbLignesJeu; compteur++)
      {
        for (int compteur2 = 0; compteur2 < nbColonnesJeu; compteur2++)
        {
          etatBlocs[compteur, compteur2] = (int)TypeBloc.None;
          toutesImagesVisuelles[compteur, compteur2].BackColor = toutesLesCouleurs[etatBlocs[compteur, compteur2]];
        }
      }
      FonctionsJeu();
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
        return tableauValeurBlocs = new int[4] { 1, 0, 0, 1 };
      }
      else if (pieceAleatoire == (int)TypeBloc.Ligne)
      {
        return tableauValeurBlocs = new int[4] { 0, 0, 0, 0 };
      }
      else if(pieceAleatoire == (int)TypeBloc.LigneVerticale)
      {
        return tableauValeurBlocs = new int[4] { 0, 1, 2, 3 };
      }
      else
      {
        return tableauValeurBlocs = new int[4] { 0, 0, 0, 0 };
      }
    }

    int PieceAleatoire()
    {
      Random rnd = new Random();
      int blocAleatoire = rnd.Next(2,5);
      return blocAleatoire;
    }

    private void tetrisGameCore_KeyPress(object sender, KeyPressEventArgs e)
    {
      MouvementJoueur(e);
    }

    void FonctionsJeu ()
    {
      pieceAleatoire = PieceAleatoire();
      blocActifX = AssignerPositionFormeX(pieceAleatoire);
      blocActifY = AssignerPositionFormeY(pieceAleatoire);
      VerifierSiPartieTermine();
      RemplirTableauEtatVide();
    }

    void MouvementJoueur(KeyPressEventArgs e)
    {
      bool reponseBouger = true;
      reponseBouger = BlocPeutBouger(e);
      if (reponseBouger == true)
      {
        //Gauche
        if (e.KeyChar == 65 || e.KeyChar == 97)
        {
          addY--;
          faireCouleursBlocs();
        }
        //Droite
        else if (e.KeyChar == 68 || e.KeyChar == 100)
        {
          addY++;
          faireCouleursBlocs();
        }
        //<alangevin>
        //Tourne e
        else if (e.KeyChar == 69 || e.KeyChar == 101)
        {
          int[] temporaireTableauY = new int[4];
          for (int compteur = 0; compteur < blocActifY.Length; compteur++)
          {
            temporaireTableauY[compteur] = blocActifY[compteur];
          }
          for (int compteur = 0; compteur < blocActifY.Length; compteur++)
          {
            blocActifY[compteur] = -blocActifX[compteur];
            blocActifX[compteur] = temporaireTableauY[compteur];
          }
          faireCouleursBlocs();
        }
        //Tourne q
        else if (e.KeyChar == 81 || e.KeyChar == 113)
        {
          int[] temporaireTableauY = new int[4];
          for (int compteur = 0; compteur < blocActifY.Length; compteur++)
          {
            temporaireTableauY[compteur] = -blocActifY[compteur];
          }
          for (int compteur = 0; compteur < blocActifY.Length; compteur++)
          {
            blocActifY[compteur] = blocActifX[compteur];
            blocActifX[compteur] = temporaireTableauY[compteur];
          }
          faireCouleursBlocs();
        }
        //</alangevin>
        //Descendre
        else if (e.KeyChar == 83 || e.KeyChar == 32 || e.KeyChar == 115)
        {
          addX++;
          faireCouleursBlocs();
        }
        else
        {
          faireCouleursBlocs();
        }
      }
    }
    void VerifierSiPartieTermine ()
    {
      for (int i = 0; i < blocActifX.Length; i++)
        if (etatBlocs[(blocActifX[i] + addX), (blocActifY[i] + addY)] != (int)TypeBloc.None) 
        {
          timerDescente.Stop();
        }
    }
  }
  







}
