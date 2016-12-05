using System;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;


namespace TP3
{
  enum TypeBloc { None, Gelé, Carré, Ligne, LigneVerticale, T, L, J, S, Z }
  enum Deplacement { DESCENTE, DROITE, GAUCHE, ROTATION_HORAIRE, ROTATION_ANTIHORAIRE }
  public partial class tetrisGameCore : Form
  {
    private frmConfigurations configs;
    public tetrisGameCore( )
    {
      InitializeComponent();
      timerDescente.Stop();
      FonctionsJeu();
    }
    //NEED COMMENTS
    int nbColonnesJeu = 10;
    int nbLignesJeu = 20;
    int addX = 0;
    int addY = 0;
    int pieceAleatoire = 0;
    bool musiqueActive = false;
    int[,] etatBlocs = null;
    int[] blocActifX = null;
    int[] blocActifY = null;
    Color[] toutesLesCouleurs = new Color[] { Color.Black, Color.Gray, Color.Red, Color.Teal, Color.Teal };
    // Variable nécessaire pour jouer le son
    WindowsMediaPlayer mediaPlayer = new WindowsMediaPlayer();

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
      ExecuterTestsUnitaires();
      configs = new frmConfigurations();
      InitialiserSurfaceDeJeu(nbLignesJeu, nbColonnesJeu);
    }

    private void InitialiserSurfaceDeJeu(int nbLignes, int nbCols)
    {
      // Création d'une surface de jeu 10 colonnes x 20 lignes
      etatBlocs = new int[nbLignesJeu, nbColonnesJeu];
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
      //Vérification, bouger la pièce vers le bas
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
      //Vérification, bouger la pièce vers la gauche
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
      //Vérification, bouger la pièce vers la droite
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
      //Vérification, bouger la pièce du sens anti-horaire
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
          // Vérification des côtés du tableau
          if ((temporaireTableauY[i] + addY) >= nbColonnesJeu || (temporaireTableauY[i] + addY) < 0)
          {
            peutBouger = false;
          }
          // Vérification haut et bas du tableau
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
      //Vérification, bouger la pièce du sens horaire
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
          // Vérification des côtés du tableau
          if ((temporaireTableauY[i] + addY) >= nbColonnesJeu || (temporaireTableauY[i] + addY) < 0)
            {
              peutBouger = false;
            }
          // Vérification haut et bas du tableau
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

    /// <summary>
    /// Fonction qui met les cubes du tableau à rien
    /// </summary>
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
    /// <summary>
    /// Fonction qui entre la position courante des blocs actifs
    /// </summary>
    void FaireCouleursBlocs()
    {
      RemplirTableauEtatVide();
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
    /// <summary>
    /// Timer qui permet la descente des blocs actifs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void timerDescente_Tick(object sender, EventArgs e)
    {
      for (int compteur = 0; compteur < 4; compteur++)
        {
          etatBlocs[(blocActifX[compteur] + addX), blocActifY[compteur] + addY] = (int)TypeBloc.None;
        }
      addX++;
      FaireCouleursBlocs();
    }
    /// <summary>
    /// Fonction qui est appellé lors d'un click sur le bouton recommencer partie
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //<alangevin>
    private void restartToolStripMenuItem_Click(object sender, EventArgs e)
    {
      refairePartie(); 
    }

    /// <summary>
    /// Fonction qui recommence le jeu à zéro.
    /// </summary>
    void refairePartie()
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
    }
    //</alangevin>
    /// <summary>
    /// Fonction qui assigne la position de départ de la pièce choisie
    /// </summary>
    /// <param name="pieceAleatoire">Représente sous un entier la pièce choisie aléatoirement</param>
    /// <returns>Retourne les positions initiales de l'axe des x en entier de la pièce choisie </returns>
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

    /// <summary>
    /// Fonction qui assigne la position de départ de la pièce choisie
    /// </summary>
    /// <param name="pieceAleatoire">Représente sous un entier la pièce choisie aléatoirement</param>
    /// <returns>Retourne les positions initiales de l'axe des y en entier de la pièce choisie </returns>
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

    /// <summary>
    /// Fonction qui choisie la pièce aléatoire.
    /// </summary>
    /// <returns>Retourne sous un entier la pièce choisie aléatoirement</returns>
    int PieceAleatoire()
    {
      Random rnd = new Random();
      int blocAleatoire = rnd.Next(2,5);
      return blocAleatoire;
    }

    /// <summary>
    /// Fonction qui à chaque mouvement appelle la fonction qui effectue le mouvement.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tetrisGameCore_KeyPress(object sender, KeyPressEventArgs e)
    {
      MouvementJoueur(e);
    }

    /// <summary>
    /// Fonction qui appelle toute les fonctions nécessaire au fonctionnement du jeu
    /// </summary>
    void FonctionsJeu ()
    {
      addY = (nbColonnesJeu / 2);
      pieceAleatoire = PieceAleatoire();
      blocActifX = AssignerPositionFormeX(pieceAleatoire);
      blocActifY = AssignerPositionFormeY(pieceAleatoire);
      VerifierSiPartieTermine();
    }

    /// <summary>
    /// Fonction qui permet le mouvement de la pièce selon la touche que le joueur pèse
    /// </summary>
    /// <param name="e"></param>
    void MouvementJoueur(KeyPressEventArgs e)
    {
      bool reponseBouger = true;
      reponseBouger = BlocPeutBouger(e);
      if (reponseBouger == true)
      {
        //Bouger la pièce à gauche
        if (e.KeyChar == 65 || e.KeyChar == 97)
        {
          addY--;
          FaireCouleursBlocs();
        }
        //Bouger la pièce à droite
        else if (e.KeyChar == 68 || e.KeyChar == 100)
        {
          addY++;
          FaireCouleursBlocs();
        }
        //<alangevin>
        //Bouger la pièce du sens horaire
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
          FaireCouleursBlocs();
        }
        //Bouger la pièce du sens anti-horaire
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
          FaireCouleursBlocs();
        }
        //</alangevin>
        //Bouger la pièce vers le bas
        else if (e.KeyChar == 83 || e.KeyChar == 32 || e.KeyChar == 115)
        {
          addX++;
          FaireCouleursBlocs();
        }
        else
        {
          FaireCouleursBlocs();
        }
      }
    }
    /// <summary>
    /// 
    /// </summary>
    void VerifierSiPartieTermine ()
    {
      pieceAleatoire = PieceAleatoire();
      blocActifX = AssignerPositionFormeX(pieceAleatoire);
      blocActifY = AssignerPositionFormeY(pieceAleatoire);
    }
    //<ADion>
    private void démarrerLaPartieToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (musiqueActive == true)
      {
        mediaPlayer.URL = "Resources/background.mp3";
        mediaPlayer.controls.play();
      }
      FaireCouleursBlocs();
      timerDescente.Start();
    }

    private void configurationsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      refairePartie();
      configs.SpecifierNbLignes(nbLignesJeu);
      configs.SpecifierNbColonnes(nbColonnesJeu);
      if (configs.ShowDialog() == DialogResult.OK)
      {
        nbLignesJeu = configs.ObtenirNbLignes();
        nbColonnesJeu = configs.ObtenirNbColonnes();
        musiqueActive = configs.MusiqueActive();
        InitialiserSurfaceDeJeu(nbLignesJeu, nbColonnesJeu);
      }
      RemplirTableauEtatVide();
    }
    //</ADion>
  }
}
