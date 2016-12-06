using System;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;
using System.Diagnostics;


namespace TP3
{
  enum TypeBloc { None, Gelé, Carré, Ligne, LigneVerticale, T, L, J, S, Z }
  enum Deplacement { DESCENTE, DROITE, GAUCHE, ROTATION_HORAIRE, ROTATION_ANTIHORAIRE, RIEN}
  public partial class tetrisGameCore : Form
  {
    private frmConfigurations configs;
    private FinDePartie fin;
    //Temps total de la partie
    int tempsPartie = 0;

    public tetrisGameCore()
    {
      InitializeComponent();
      timerDescente.Stop();
      FonctionsJeu();
    }
    int nbColonnesJeu = 10;
    int nbLignesJeu = 20;
    //Représente la position ajouté sur pour le Y ou le X
    int addY = 0;
    int addX = 0;
    //Représente lenuméro de la pièce qui est joué
    int pieceAleatoire = 0;
    bool musiqueActive = false;
    //Représente le tableau du jeu avec tout les états des blocs à l'intérieur
    int[,] etatBlocs = null;
    //Représente les blocs de la pièce en jeu
    int[] blocActifY = null;
    int[] blocActifX = null;
    //Tableau qui compte combien de pièce différente il y a eu au cours de la partie
    public float[] nbrBlocsDifferent = new float[9];
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
    private void frmLoad(object sender, EventArgs e)
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
      TestRotationHoraireCentre();
      TestRotationHoraireGauche();
      TestRotationHoraireDroite();
      TestRotationHoraireCentreAvecBlocs();
      TestFinDePartie();
      TestContinuerPartie();
    }
    //<alangevin>
    /// <summary>
    /// Fonction qui test la rotation horaire d'une pièce au centre du tableau
    /// </summary>
    void TestRotationHoraireCentre()
    {
      // Mise en place des données du test
      Deplacement sens = Deplacement.ROTATION_HORAIRE;
      blocActifY = AssignerPositionFormeY(2);
      blocActifX = AssignerPositionFormeX(2);
      addX = 5;
      addY = 10;
      bool testReponse;

      InitialiserSurfaceDeJeu(nbLignesJeu, nbColonnesJeu);
      for (int i = 0; i < blocActifY.Length; i++)
      {
        etatBlocs[(blocActifY[i] + addY), blocActifX[i] + addX] = (int)TypeBloc.Carré;
      }
      // Exécuter de la méthode à tester
      testReponse = BlocPeutBouger(sens);
      // Validation des résultats

        Debug.Assert(testReponse == true);
      
      // Clean-up
      RefairePartie();
    }

    /// <summary>
    /// Fonction qui test la rotation horaire d'une pièce à gauche du tableau
    /// </summary>
    void TestRotationHoraireGauche()
    {
      // Mise en place des données du test
      Deplacement sens = Deplacement.ROTATION_HORAIRE;
      blocActifY = AssignerPositionFormeY(2);
      blocActifX = AssignerPositionFormeX(2);
      addX = 0;
      addY = 10;
      bool testReponse;

      InitialiserSurfaceDeJeu(nbLignesJeu, nbColonnesJeu);
      for (int i = 0; i < blocActifY.Length; i++)
      {
        etatBlocs[(blocActifY[i] + addY), blocActifX[i] + addX] = (int)TypeBloc.Carré;
      }
      // Exécuter de la méthode à tester

      testReponse = BlocPeutBouger(sens);
      // Validation des résultats

        Debug.Assert(testReponse == false);

      // Clean-up
      RefairePartie();
    }

    /// <summary>
    /// Fonction qui test la rotation horaire d'une pièce à droite du tableau
    /// </summary>
    void TestRotationHoraireDroite()
    {
      // Mise en place des données du test
      Deplacement sens = Deplacement.ROTATION_HORAIRE;
      int[] blocY = AssignerPositionFormeY(2);
      int[] blocX = AssignerPositionFormeX(2);
      addX = 8;
      addY = 10;
      bool testReponse;

      InitialiserSurfaceDeJeu(nbLignesJeu, nbColonnesJeu);
      for (int i = 0; i < blocY.Length - 1; i++)
      {
        etatBlocs[(blocY[i] + addY), blocX[i] + addX] = (int)TypeBloc.Carré;
      }
      // Exécuter de la méthode à tester

      testReponse = BlocPeutBouger(sens);
      // Validation des résultats

      Debug.Assert(testReponse == true);

      // Clean-up
      RefairePartie();
    }
    /// <summary>
    /// Fonction qui test la rotation horaire d'une pièce au centre du tableau, mais avec des blocs gelés autour
    /// </summary>
    void TestRotationHoraireCentreAvecBlocs()
    {
      // Mise en place des données du test
      Deplacement sens = Deplacement.ROTATION_HORAIRE;
      blocActifY = AssignerPositionFormeY(2);
      blocActifX = AssignerPositionFormeX(2);
      addX = 5;
      addY = 10;
      bool testReponse;

      InitialiserSurfaceDeJeu(nbLignesJeu, nbColonnesJeu);
      for (int i = 0; i < blocActifY.Length; i++)
      {
        etatBlocs[(blocActifY[i] + addY), blocActifX[i] + addX] = (int)TypeBloc.Carré;
      }
      etatBlocs[9, 5] = (int)TypeBloc.Gelé;
      etatBlocs[9, 6] = (int)TypeBloc.Gelé;
      etatBlocs[10, 4] = (int)TypeBloc.Gelé;
      etatBlocs[10, 7] = (int)TypeBloc.Gelé;
      etatBlocs[11, 4] = (int)TypeBloc.Gelé;
      etatBlocs[11, 7] = (int)TypeBloc.Gelé;
      etatBlocs[12, 5] = (int)TypeBloc.Gelé;
      etatBlocs[12, 6] = (int)TypeBloc.Gelé;
      // Exécuter de la méthode à tester
      testReponse = BlocPeutBouger(sens);
      // Validation des résultats

      Debug.Assert(testReponse == false);

      // Clean-up
      RefairePartie();
    }
    /// <summary>
    /// Fonction qui test si la fin de partie fonctionne correctement lorsqu'il y en a une
    /// </summary>
    void TestFinDePartie()
    {

      // Mise en place des données du test
      blocActifY = AssignerPositionFormeY(2);
      blocActifX = AssignerPositionFormeX(2);
      addX = 5;
      addY = 0;
      bool testPartieTermine;

      InitialiserSurfaceDeJeu(nbLignesJeu, nbColonnesJeu);
      for (int i = 0; i < blocActifY.Length; i++)
      {
        etatBlocs[(blocActifY[i] + addY), blocActifX[i] + addX] = (int)TypeBloc.Carré;
      }
      etatBlocs[0, 5] = (int)TypeBloc.Gelé;

      // Exécuter de la méthode à tester
      testPartieTermine = VerifierSiPartieTermine();
      // Validation des résultats

      Debug.Assert(testPartieTermine == true);

      // Clean-up
      RefairePartie();
    }

    /// <summary>
    /// Fonction qui test si la fin de partie fonctionne correctement lorsque le jeu doit continuer
    /// </summary>
    void TestContinuerPartie()
    {

      // Mise en place des données du test
      blocActifY = AssignerPositionFormeY(2);
      blocActifX = AssignerPositionFormeX(2);
      addX = 0;
      addY = 0;
      bool testPartieTermine;

      InitialiserSurfaceDeJeu(nbLignesJeu, nbColonnesJeu);
      for (int i = 0; i < blocActifY.Length; i++)
      {
        etatBlocs[(blocActifY[i] + addY), blocActifX[i] + addX] = (int)TypeBloc.Carré;
      }
      etatBlocs[0, 5] = (int)TypeBloc.Gelé;

      // Exécuter de la méthode à tester
      testPartieTermine = VerifierSiPartieTermine();
      // Validation des résultats

      Debug.Assert(testPartieTermine == false);

      // Clean-up
      RefairePartie();
    }
    //</alangevin>
    #endregion

    /// <summary>
    /// Fonction qui vérifie si la pièce peut effectuer le mouvement attendu
    /// </summary>
    /// <param name="sens"></param>
    /// <returns>Retourne un booléen qui affirme ou non si la pièce peut bouger</returns>
    bool BlocPeutBouger(Deplacement sens)
    {
      bool peutBouger = true;
      //Vérification, bouger la pièce vers le bas
      if (sens == Deplacement.DESCENTE)
      {
        for (int i = 0; i < blocActifY.Length; i++)
        {
          if ((blocActifY[i] + addY + 1) == nbLignesJeu)
          {
            peutBouger = false;
          }
          else if (etatBlocs[blocActifY[i] + addY + 1, blocActifX[i] + addX] == (int)TypeBloc.Gelé)
          {
            peutBouger = false;
          }
        }
      }
      //Vérification, bouger la pièce vers la gauche
      else if (sens == Deplacement.GAUCHE)
      {
        for (int i = 0; i < blocActifX.Length; i++)
        {
          if (blocActifX[i] + addX - 1 < 0)
          {
            peutBouger = false;
          }
          else if (etatBlocs[blocActifY[i] + addY, blocActifX[i] + addX - 1] == (int)TypeBloc.Gelé)
          {
            peutBouger = false;
          }
        }
      }
      //Vérification, bouger la pièce vers la droite
      else if (sens == Deplacement.DROITE)
      {
        for (int i = 0; i < blocActifX.Length; i++)
        {
          if (blocActifX[i] + addX + 1 > nbColonnesJeu - 1)
          {
            peutBouger = false;
          }
          else if (etatBlocs[blocActifY[i] + addY, blocActifX[i] + addX + 1] == (int)TypeBloc.Gelé)
          {
            peutBouger = false;
          }
        }
      }
      //<alangevin>
      //Vérification, bouger la pièce du sens anti-horaire
      else if (sens == Deplacement.ROTATION_ANTIHORAIRE)
      {
        int[] temporaireTableauX = new int[4];
        int[] temporaireTableauY = new int[4];
        for (int compteur = 0; compteur < blocActifX.Length; compteur++)
        {
          temporaireTableauX[compteur] = blocActifY[compteur];
          temporaireTableauY[compteur] = -blocActifX[compteur];
        }
        for (int i = 0; i < blocActifX.Length; i++)
        {
          // Vérification des côtés du tableau
          if ((temporaireTableauX[i] + addX) >= nbColonnesJeu || (temporaireTableauX[i] + addX) < 0)
          {
            peutBouger = false;
          }
          // Vérification haut et bas du tableau
          else if ((temporaireTableauY[i] + addY) >= nbLignesJeu || (temporaireTableauY[i] + addY) < 0)
          {
            peutBouger = false;
          }
          // Vérification des blocs gelés
          else if (etatBlocs[(temporaireTableauY[i] + addY), (temporaireTableauX[i] + addX)] == (int)TypeBloc.Gelé)
          {
            peutBouger = false;
          }
        }
      }
      //Vérification, bouger la pièce du sens horaire
      else if (sens == Deplacement.ROTATION_HORAIRE)
      {
        int[] temporaireTableauX = new int[4];
        int[] temporaireTableauY = new int[4];
        for (int compteur = 0; compteur < blocActifX.Length; compteur++)
        {
          temporaireTableauX[compteur] = -blocActifY[compteur];
          temporaireTableauY[compteur] = blocActifX[compteur];
        }
        for (int i = 0; i < blocActifX.Length; i++)
        {
          // Vérification des côtés du tableau
          if ((temporaireTableauX[i] + addX) >= nbColonnesJeu || (temporaireTableauX[i] + addX) < 0)
          {
            peutBouger = false;
          }
          // Vérification haut et bas du tableau
          else if ((temporaireTableauY[i] + addY) >= nbLignesJeu || (temporaireTableauY[i] + addY) < 0)
          {
            peutBouger = false;
          }
          // Vérification des blocs gelés
          else if (etatBlocs[(temporaireTableauY[i] + addY), (temporaireTableauX[i] + addX)] == (int)TypeBloc.Gelé)
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
        etatBlocs[(blocActifY[compteur] + addY), blocActifX[compteur] + addX] = pieceAleatoire;
      }
      for (int compteur = 0; compteur < nbLignesJeu; compteur++)
      {
        for (int compteur2 = 0; compteur2 < nbColonnesJeu; compteur2++)
        {
          toutesImagesVisuelles[compteur, compteur2].BackColor = toutesLesCouleurs[etatBlocs[compteur, compteur2]];
        }
      }
    }

    /// <summary>
    /// Chronomètre qui permet la descente des blocs actifs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void timerDescente_Tick(object sender, EventArgs e)
    {
      for (int compteur = 0; compteur < 4; compteur++)
      {
        etatBlocs[(blocActifY[compteur] + addY), blocActifX[compteur] + addX] = (int)TypeBloc.None;
      }
      addY++;
      FaireCouleursBlocs();
    }

    /// <summary>
    /// Fonction qui est appellé lorsque l'utilisateur pèse sur le bouton recommencer partie
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //<alangevin>
    private void restartToolStripMenuItem_Click(object sender, EventArgs e)
    {
      RefairePartie();
    }

    /// <summary>
    /// Fonction qui recommence le jeu à zéro.
    /// </summary>
    void RefairePartie()
    {
      timerDescente.Stop();
      tempsPartie = 0;
      addY = 0;
      addX = 5;
      pieceAleatoire = 0;
      mediaPlayer.controls.stop();
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
    int[] AssignerPositionFormeY(int pieceAleatoire)
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
    int[] AssignerPositionFormeX(int pieceAleatoire)
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
      else if (pieceAleatoire == (int)TypeBloc.LigneVerticale)
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
      int blocAleatoire = rnd.Next(2, 5);
      return blocAleatoire;
    }

    /// <summary>
    /// Fonction qui à chaque mouvement appelle la fonction qui effectue le mouvement.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tetrisGameCore_KeyPress(object sender, KeyPressEventArgs e)
    {
      Deplacement sens = Deplacement.RIEN;
      if (e.KeyChar == 65 || e.KeyChar == 97)
      {
        sens = Deplacement.GAUCHE;
      }
      else if (e.KeyChar == 68 || e.KeyChar == 100)
      {
        sens = Deplacement.DROITE;
      }
      else if (e.KeyChar == 69 || e.KeyChar == 101)
      {
        sens = Deplacement.ROTATION_HORAIRE;
      }
      else if (e.KeyChar == 81 || e.KeyChar == 113)
      {
        sens = Deplacement.ROTATION_ANTIHORAIRE;
      }
      else if (e.KeyChar == 83 || e.KeyChar == 32 || e.KeyChar == 115)
      {
        sens = Deplacement.DESCENTE;
      }
      MouvementJoueur(sens);
    }

    /// <summary>
    /// Fonction qui appelle toute les fonctions nécessaire à la formation des pièces du jeu
    /// </summary>
    void FonctionsJeu()
    {
      addX = (nbColonnesJeu / 2);
      pieceAleatoire = PieceAleatoire();
      nbrBlocsDifferent[pieceAleatoire-2]++;
      nbrBlocsDifferent[8]++;
      blocActifY = AssignerPositionFormeY(pieceAleatoire);
      blocActifX = AssignerPositionFormeX(pieceAleatoire);
    }

    /// <summary>
    /// Fonction qui permet le mouvement de la pièce selon la touche que le joueur pèse
    /// </summary>
    /// <param name="sens">Enum qui représente le sens de déplacement du joueur</param>
    void MouvementJoueur(Deplacement sens)
    {
      bool reponseBouger = true;
      reponseBouger = BlocPeutBouger(sens);
      if (reponseBouger == true)
      {
        //Bouger la pièce à gauche
        if (sens == Deplacement.GAUCHE)
        {
          addX--;
          FaireCouleursBlocs();
        }
        //Bouger la pièce à droite
        else if (sens == Deplacement.DROITE)
        {
          addX++;
          FaireCouleursBlocs();
        }
        //<alangevin>
        //Bouger la pièce du sens horaire
        else if (sens == Deplacement.ROTATION_HORAIRE)
        {
          int[] temporaireTableau = new int[4];
          for (int compteur = 0; compteur < blocActifX.Length; compteur++)
          {
            temporaireTableau[compteur] = blocActifX[compteur];
          }
          for (int compteur = 0; compteur < blocActifX.Length; compteur++)
          {
            blocActifX[compteur] = -blocActifY[compteur];
            blocActifY[compteur] = temporaireTableau[compteur];
          }
          FaireCouleursBlocs();
        }
        //Bouger la pièce du sens anti-horaire
        else if (sens == Deplacement.ROTATION_ANTIHORAIRE)
        {
          int[] temporaireTableau = new int[4];
          for (int compteur = 0; compteur < blocActifX.Length; compteur++)
          {
            temporaireTableau[compteur] = -blocActifX[compteur];
          }
          for (int compteur = 0; compteur < blocActifX.Length; compteur++)
          {
            blocActifX[compteur] = blocActifY[compteur];
            blocActifY[compteur] = temporaireTableau[compteur];
          }
          FaireCouleursBlocs();
        }
        //</alangevin>
        //Bouger la pièce vers le bas
        else if (sens == Deplacement.DESCENTE)
        {
          addY++;
          FaireCouleursBlocs();
        }
        else
        {
          FaireCouleursBlocs();
        }
      }
    }

    //<alangevin>
    /// <summary>
    /// Fonction qui permet de vérifier si la partie est terminée
    /// </summary>
    bool VerifierSiPartieTermine()
    {
      bool partieTermine = false;
      for (int i = 0; i < blocActifY.Length-1; i++)
      {
        if (etatBlocs[(blocActifY[i] + addY), (blocActifX[i] + addX)] == (int)TypeBloc.Gelé)
        {
          partieTermine = true;
        }
      }
      return partieTermine;
    }

    /// <summary>
    /// Fonction qui termine la partie
    /// </summary>
    void PartieTermine()
    {
      if (VerifierSiPartieTermine() == true)
      {
        timerDescente.Stop();
        fin = new FinDePartie();
        fin.TempsDeJeu(tempsPartie);
        fin.SpecifierNbPiece(nbrBlocsDifferent);
        fin.ShowDialog();
      }
    }
    //</alangevin>

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
      RefairePartie();
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

    /// <summary>
    /// Fonction qui compte le temps jouer 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tempsDeJeu_Tick(object sender, EventArgs e)
    {
      tempsPartie++;
    }
  }
}
