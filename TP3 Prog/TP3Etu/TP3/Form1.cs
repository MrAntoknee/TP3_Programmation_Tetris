using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;


namespace TP3
{
  // Tous les types de blocs existants
  enum TypeBloc { None, Gelé, Carré, Ligne, LigneVerticale, T, L, J, S, Z }
  // Tous les types de déplacements existants
  enum Deplacement { DESCENTE, DROITE, GAUCHE, ROTATION_HORAIRE, ROTATION_ANTIHORAIRE }
  public partial class tetrisGameCore : Form
  {
    // Déclare un lien entre la forme de configuration et la forme principale
    private frmConfigurations configs;
    public tetrisGameCore()
    {
      InitializeComponent();
      // Arrête le timer au départ du jeu
      timerDescente.Stop();
    }

    #region Variables partagées

    // Nombre de colonnes initiales
    int nbColonnesJeu = 10;
    // Nombre de lignes initiales
    int nbLignesJeu = 20;
    // Variables qui permettent d'avoir l'emplacement courant du bloc actif
    int addY = 0;
    int addX = 0;
    // Variable qui va choisir un bloc aléatoirement
    int pieceAleatoire = 0;
    // Booléen qui affirme si la musique est activée ou non (Désactivée par défaut)
    bool musiqueActive = false;
    // Tableau d'états partagé, taille déclarée dans la fonction "InitialierSurfaceDeJeu"
    int[,] etatBlocs = null;
    // Tableaux contenant les blocs partagés, tailles déclarées dans la fonction "FonctionsJeu"
    int[] blocActifY = null;
    int[] blocActifX = null;
    // Tableau qui correspond à toutes les couleurs des états
    Color[] toutesLesCouleurs = new Color[] { Color.Black, Color.Gray, Color.Red, Color.Teal, Color.Teal, Color.Azure, Color.DeepPink, Color.DarkOrange, Color.Turquoise, Color.Yellow };
    // Variable nécessaire pour jouer le son
    WindowsMediaPlayer mediaPlayer = new WindowsMediaPlayer();
    // Variable qui correspond à la dernière ligne qui va être décalée
    int derniereLigneADécaler = 0;
    // Variable qui correspond au pointage total de la partie
    int pointage = 0;
    // Variable qui correspond au nombre de lignes totales à décaler
    int nbLignesADécaler = 0;
    int[] ligneÀRetirer = null;

    #endregion


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
      configs = new frmConfigurations();
      InitialiserSurfaceDeJeu(nbLignesJeu, nbColonnesJeu);
      ExecuterTestsUnitaires();
    }

    private void InitialiserSurfaceDeJeu(int nbLignes, int nbCols)
    {
      // Création d'une surface de jeu 10 colonnes x 20 lignes
      etatBlocs = new int[nbLignesJeu, nbColonnesJeu];
      ligneÀRetirer = new int[nbLignesJeu];
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
    /// Exécute tous les tests unitaires présents
    /// </summary>
    void ExecuterTestsUnitaires()
    {
      ExecuterTest_LigneCompleteEtSeule();
      ExecuterTest_LigneCompleteEtDecalage();
      ExecuterTest_DeuxLignesCompletesConsecutives();
      ExecuterTest_DeuxLignesCompletesNonConsecutives();
      ExecuterTest_TroisLignesCompletesConsecutives();
      ExecuterTest_QuatreLignesCompletesConsecutives();
      // Réinitialise le pointage pour le jeu
      pointage = 0;
    }

    // <ADion>

    /// <summary>
    /// Exécute un test unitaire qui confirme si la ligne complète de blocs gelés a été
    /// retirée ou non (Note: Ma fonction "RetirerLignes" est programmée pour automatiquement 
    /// appeler la fonction "DécalerLigne" si cela est nécessaire)
    /// </summary>
    void ExecuterTest_LigneCompleteEtSeule()
    {
      // Mise en place des données du test
      for (int i = 0; i < nbColonnesJeu; i++)
      {
        etatBlocs[nbLignesJeu - 1, i] = (int)TypeBloc.Gelé;
      }
      // Exécuter de la méthode à tester
      RetirerLignes();
      // Validation des résultats
      for (int i = 0; i < nbColonnesJeu; i++)
      {
        Debug.Assert(etatBlocs[nbLignesJeu - 1, i] == (int)TypeBloc.None, "Erreur lors du retirement de la ligne de blocs gelés");
      }
      // Clean-up
      RefairePartie();
    }

    /// <summary>
    /// Exécute un test unitaire qui confirme que la ligne a été retirée et décalée 
    /// (Note: Ma fonction "RetirerLignes" est programmée pour automatiquement 
    /// appeler la fonction "DécalerLigne" si cela est nécessaire)
    /// </summary>
    void ExecuterTest_LigneCompleteEtDecalage()
    {
      // Mise en place des données du test
      for (int i = 0; i < nbColonnesJeu - 1; i++)
      {
        etatBlocs[nbLignesJeu - 1, i] = (int)TypeBloc.Gelé;
      }

      for (int i = 0; i < nbColonnesJeu; i++)
      {
        etatBlocs[nbLignesJeu - 1, i] = (int)TypeBloc.Gelé;
      }
      // Exécuter de la méthode à tester
      RetirerLignes();
      // Validation des résultats
      for (int i = 0; i < nbColonnesJeu; i++)
      {
        Debug.Assert(etatBlocs[nbLignesJeu - 1, i] == etatBlocs[nbLignesJeu - 2, i], "Erreur lors du décalage des lignes");
      }
      // Clean-up
      RefairePartie();
    }

    /// <summary>
    /// Exécute un test unitaire qui confirme si deux lignes consécutives ont été retirées et décalées
    /// </summary>
    void ExecuterTest_DeuxLignesCompletesConsecutives()
    {
      // Mise en place des données du test
      for (int i = 1; i <= 2; i++)
      {
        for (int j = 0; j < nbColonnesJeu; j++)
        {
          etatBlocs[nbLignesJeu - i, j] = (int)TypeBloc.Gelé;
        }
      }
      // Exécuter de la méthode à tester
      RetirerLignes();
      // Validation des résultats
      for (int i = 1; i <= 2; i++)
      {
        for (int j = 0; j < nbColonnesJeu; j++)
        {
          Debug.Assert(etatBlocs[nbLignesJeu - i, j] == etatBlocs[nbLignesJeu - i - 2 /* 2 correspond à la variable "nbLignesADécaler" */, j], "Erreur lors du retirement et du décalage de deux lignes consécutives");
        }
      }
      // Clean-up
      RefairePartie();
    }

    void ExecuterTest_DeuxLignesCompletesNonConsecutives()
    {
      // Mise en place des données du test
      for (int i = 0; i < nbColonnesJeu; i++)
      {
        etatBlocs[nbLignesJeu - 1, i] = (int)TypeBloc.Gelé;
      }

      for (int i = 0; i < nbColonnesJeu; i++)
      {
        etatBlocs[nbLignesJeu - 3, i] = (int)TypeBloc.Gelé;
      }
      // Exécuter de la méthode à tester
      RetirerLignes();
      // Validation des résultats
      for (int i = 1; i <= 3; i++)
      {
        for (int j = 0; j < nbColonnesJeu; j++)
        {
          Debug.Assert(etatBlocs[nbLignesJeu - i, j] == etatBlocs[nbLignesJeu - i - 2 /* 2 correspond à la variable "nbLignesADécaler" */, j], "Erreur lors du retirement et du décalage de deux lignes non consécutives");
        }
      }
      // Clean-up
      RefairePartie();
    }

    void ExecuterTest_TroisLignesCompletesConsecutives()
    {
      // Mise en place des données du test
      for (int i = 1; i <= 3; i++)
      {
        for (int j = 0; j < nbColonnesJeu; j++)
        {
          etatBlocs[nbLignesJeu - i, j] = (int)TypeBloc.Gelé;
        }
      }
      // Exécuter de la méthode à tester
      RetirerLignes();
      // Validation des résultats
      for (int i = 1; i <= 3; i++)
      {
        for (int j = 0; j < nbColonnesJeu; j++)
        {
          Debug.Assert(etatBlocs[nbLignesJeu - i, j] == etatBlocs[nbLignesJeu - i - 3 /* 3 correspond à la variable "nbLignesADécaler" */, j], "Erreur lors du retirement et du décalage de trois lignes consécutives");
        }
      }
      // Clean-up
      RefairePartie();
    }

    void ExecuterTest_QuatreLignesCompletesConsecutives()
    {
      // Mise en place des données du test
      for (int i = 1; i <= 4; i++)
      {
        for (int j = 0; j < nbColonnesJeu; j++)
        {
          etatBlocs[nbLignesJeu - i, j] = (int)TypeBloc.Gelé;
        }
      }
      // Exécuter de la méthode à tester
      RetirerLignes();
      // Validation des résultats
      for (int i = 1; i <= 4; i++)
      {
        for (int j = 0; j < nbColonnesJeu; j++)
        {
          Debug.Assert(etatBlocs[nbLignesJeu - i, j] == etatBlocs[nbLignesJeu - i - 4 /* 4 correspond à la variable "nbLignesADécaler" */, j], "Erreur lors du retirement et du décalage de quatre lignes consécutives");
        }
      }
      // Clean-up
      RefairePartie();
    }

    // </ADion>

    /// <summary>
    /// Confirme que le bloc peut bouger lorsque le joueur appuie sur une touche en particulier
    /// </summary>
    /// <param name="e"></param>
    /// <returns>Retourne un booléen qui spécifie si le bloc peut bouger ou non</returns>
    bool BlocPeutBouger(KeyPressEventArgs e)
    {
      bool peutBouger = true;

      //<ADion>

      //Vérification, bouger la pièce vers le bas
      // KeyChar == 83 correspond à 'S', KeyChar == 32 correspond à la barre d'espace et KeyChar == 115 correspond à 's'
      if (e.KeyChar == 83 || e.KeyChar == 32 || e.KeyChar == 115)
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
      // KeyChar == 65 correspond à 'A' et KeyChar == 97 correspond à 'a'
      else if (e.KeyChar == 65 || e.KeyChar == 97)
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
      // KeyChar == 68 correspond à 'D' et KeyChar == 100 correspond à 'd'
      else if (e.KeyChar == 68 || e.KeyChar == 100)
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

      //</ADion>

      //<alangevin>

      // Vérification, bouger la pièce du sens anti-horaire
      // KeyChar == 81 correspond à 'Q' et KeyChar == 113 correspond à 'q'
      else if (e.KeyChar == 81 || e.KeyChar == 113)
      {
        int[] temporaireTableauY = new int[4];
        int[] temporaireTableauX = new int[4];
        for (int compteur = 0; compteur < blocActifX.Length; compteur++)
        {
          temporaireTableauY[compteur] = blocActifY[compteur];
          temporaireTableauX[compteur] = -blocActifX[compteur];
        }
        for (int i = 0; i < blocActifX.Length; i++)
        {
          // Vérification des côtés du tableau
          if ((temporaireTableauY[i] + addX) >= nbColonnesJeu || (temporaireTableauY[i] + addX) < 0)
          {
            peutBouger = false;
          }
          // Vérification haut et bas du tableau
          else if ((temporaireTableauX[i] + addY) >= nbLignesJeu || (temporaireTableauX[i] + addY) <= 0)
          {
            peutBouger = false;
          }
          // Vérification des blocs gelés
          else if (etatBlocs[(temporaireTableauX[i] + addY), (temporaireTableauY[i] + addX)] == (int)TypeBloc.Gelé)
          {
            peutBouger = false;                       
          }
        }
      }
      //Vérification, bouger la pièce du sens horaire
      // KeyChar == 69 correspond à 'R' et KeyChar == 101 correspond à 'r'
      else if (e.KeyChar == 69 || e.KeyChar == 101)
      {
        int[] temporaireTableauY = new int[4];
        int[] temporaireTableauX = new int[4];
        for (int compteur = 0; compteur < blocActifX.Length; compteur++)
        {
          temporaireTableauY[compteur] = -blocActifY[compteur];
          temporaireTableauX[compteur] = blocActifX[compteur];
        }
        for (int i = 0; i < blocActifX.Length; i++)
        {
          // Vérification des côtés du tableau
          if ((temporaireTableauY[i] + addX) >= nbColonnesJeu || (temporaireTableauY[i] + addX) < 0)
            {
              peutBouger = false;
            }
          // Vérification haut et bas du tableau
          else if ((temporaireTableauX[i] + addY) >= nbLignesJeu || (temporaireTableauX[i] + addY) <= 0)
            {
              peutBouger = false;
            }
          // Vérification des blocs gelés
          else if (etatBlocs[(temporaireTableauX[i] + addY), (temporaireTableauY[i] + addX)] == (int)TypeBloc.Gelé)
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
    /// Fonction qui met chaque indice du tableau "etatBlocs" à vide
    /// </summary>
    void RemplirTableauEtatVide()
    {
    // Met à jour chaque indice qui correspond au vide ou au bloc choisi aléatoirement à un bloc vide
      for (int compteur = 0; compteur < nbLignesJeu; compteur++)
      {
        for (int compteur2 = 0; compteur2 < nbColonnesJeu; compteur2++)
        {
          if (etatBlocs[compteur, compteur2] == (int)TypeBloc.None || etatBlocs[compteur, compteur2] == pieceAleatoire)
          {
            etatBlocs[compteur, compteur2] = (int)TypeBloc.None;
          }
        }
      }
    }
    /// <summary>
    /// Fonction qui donne les couleurs à tous les types de blocs du tableau "etatBlocs"
    /// </summary>
    void FaireCouleursBlocs()
    {
      RemplirTableauEtatVide();
      // Donne les couleurs de la pièce qui à été choisie aléatoirement
      for (int compteur = 0; compteur < 4; compteur++)
      {
        if (blocActifY[compteur] + addY != nbLignesJeu && etatBlocs[(blocActifY[compteur] + addY), blocActifX[compteur] + addX] != (int)TypeBloc.Gelé)
        {
          etatBlocs[(blocActifY[compteur] + addY), blocActifX[compteur] + addX] = pieceAleatoire;
        }
      }
      // Met à jour le tableau en entier pour avoir les nouvelles couleurs
      for (int compteur = 0; compteur < nbLignesJeu; compteur++)
      {
        for (int compteur2 = 0; compteur2 < nbColonnesJeu; compteur2++)
        {
          toutesImagesVisuelles[compteur,compteur2].BackColor = toutesLesCouleurs[etatBlocs[compteur, compteur2]];
        }
      }
    }

    //<ADion>

    /// <summary>
    /// Rends les blocs actifs gelés
    /// </summary>
    void RendreBlocsGelés()
    {
      for (int compteur = 0; compteur < 4; compteur++)
      {
        if (etatBlocs[(blocActifY[compteur] + addY), (blocActifX[compteur] + addX)] == pieceAleatoire)
        {
          etatBlocs[(blocActifY[compteur] + addY), (blocActifX[compteur] + addX)] = (int)TypeBloc.Gelé;
        }
      }
      // Donne les nouvelles couleurs pour le tableau
      FaireCouleursBlocs();
      // Fait apparaître un nouveau bloc
      FonctionsJeu();
    }

    /// <summary>
    /// Timer qui permet la descente des blocs actifs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void timerDescente_Tick(object sender, EventArgs e)
    {
      bool peutDescendre = true;
      lblPointage.Text = pointage.ToString();
      // Booléen qui va affirmer si les blocs peuvent toujours descendre
      for (int compteur = 0; compteur < 4; compteur++)
      {
        peutDescendre = peutDescendre && (blocActifY[compteur] + addY != nbLignesJeu - 1) && (etatBlocs[blocActifY[compteur] + addY + 1, blocActifX[compteur] + addX] != (int)TypeBloc.Gelé);
      }
      // S'ils peuvent descendre, mets les anciennes positions des blocs au type vide
      if(peutDescendre)
      {
        for (int compteur = 0; compteur < 4; compteur++)
        {
          etatBlocs[(blocActifY[compteur] + addY), blocActifX[compteur] + addX] = (int)TypeBloc.None;
        }
        addY++;
        FaireCouleursBlocs();
      }
      // Sinon, s'ils ne peuvent descendre, ils deviennent gelés
      else
      {
        RendreBlocsGelés();
      }
      RetirerLignes();
    }

    //</ADion>

    //<alangevin>

    /// <summary>
    /// Fonction qui est appelée lorsque l'on cliquera sur l'onglet "Réinitialiser la partie" dans l'onglet "Jeu".
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void restartToolStripMenuItem_Click(object sender, EventArgs e)
    {
      RefairePartie(); 
    }

    /// <summary>
    /// Fonction qui recommence le jeu à zéro.
    /// </summary>
    void RefairePartie()
    {
      // Arrête le timer afin d'arrêter le jeu
      timerDescente.Stop();
      // Arrête la musique en cours si elle est activée
      mediaPlayer.controls.stop();
      // Remets le tableau "etatBlocs" au complet en blocs vides
      for (int compteur = 0; compteur < nbLignesJeu; compteur++)
      {
        for (int compteur2 = 0; compteur2 < nbColonnesJeu; compteur2++)
        {
          etatBlocs[compteur, compteur2] = (int)TypeBloc.None;
          toutesImagesVisuelles[compteur, compteur2].BackColor = toutesLesCouleurs[etatBlocs[compteur, compteur2]];
        }
      }
      // Appele les fonctions initiales du jeu
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
      // Tableau qui va retourner les valeurs du bloc choisi
      int[] tableauValeurBlocs;
      // Si la pièce choisie aléatoirement est un carré
      if (pieceAleatoire == (int)TypeBloc.Carré)
      {
       return tableauValeurBlocs = new int[4] { 0, 1, 0, 1 };
      }
      // Si la pièce choisie aléatoirement est une ligne horizontale
      else if (pieceAleatoire == (int)TypeBloc.Ligne)
      {
        return tableauValeurBlocs = new int[4] { 0, 1, 2, 3 };
      }
      // Si la pièce choisie aléatoirement est un L
      else if (pieceAleatoire == (int)TypeBloc.L)
      {
        return tableauValeurBlocs = new int[4] { 0, 1, 2, 2 };
      }
      // Si la pièce choisie aléatoirement est un J (L de l'autre sens)
      else if (pieceAleatoire == (int)TypeBloc.J)
      {
        return tableauValeurBlocs = new int[4] { 0, 1, 2, 2 };
      }
      // Si la pièce choisie aléatoirement est un S
      else if (pieceAleatoire == (int)TypeBloc.S)
      {
        return tableauValeurBlocs = new int[4] { 0, 1, 1, 2 };
      }
      // Si la pièce choisie aléatoirement est un T
      else if (pieceAleatoire == (int)TypeBloc.T)
      {
        return tableauValeurBlocs = new int[4] { 1, 0, 1, 2 };
      }
      // Si la pièce choisie aléatoirement est un Z (S de l'autre sens)
      else if (pieceAleatoire == (int)TypeBloc.Z)
      {
        return tableauValeurBlocs = new int[4] { 0, 1, 1, 2 };
      }
      // Sinon, initie une pièce vide
      else
      {
        return tableauValeurBlocs = new int[4] { 0, 0, 0, 0 };
      }
    }

    /// <summary>
    /// Fonction qui assigne la position de départ de la pièce choisie
    /// </summary>
    /// <param name="pieceAleatoire">Représente, sous un entier, la pièce choisie aléatoirement</param>
    /// <returns>Retourne les positions initiales de l'axe des y en entier de la pièce choisie </returns>
    int[] AssignerPositionFormeX(int pieceAleatoire)
    {
      // Tableau qui va retourner les valeurs du bloc choisi
      int[] tableauValeurBlocs;
      // Si la pièce choisie aléatoirement est un carré
      if (pieceAleatoire == (int)TypeBloc.Carré)
      {
        return tableauValeurBlocs = new int[4] { 1, 0, 0, 1 };
      }
      // Si la pièce choisie aléatoirement est une ligne horizontale
      else if (pieceAleatoire == (int)TypeBloc.Ligne)
      {
        return tableauValeurBlocs = new int[4] { 0, 0, 0, 0 };
      }
      // Si la pièce choisie aléatoirement est une ligne verticale
      else if (pieceAleatoire == (int)TypeBloc.LigneVerticale)
      {
        return tableauValeurBlocs = new int[4] { 0, 1, 2, 3 };
      }
      // Si la pièce choisie aléatoirement est un L
      else if (pieceAleatoire == (int)TypeBloc.L)
      {
        return tableauValeurBlocs = new int[4] { 0, 0, 0, 1 };
      }
      // Si la pièce choisie aléatoirement est un J (L de l'autre sens)
      else if (pieceAleatoire == (int)TypeBloc.J)
      {
        return tableauValeurBlocs = new int[4] { 1, 1, 0, 1 };
      }
      // Si la pièce choisie aléatoirement est un S
      else if (pieceAleatoire == (int)TypeBloc.S)
      {
        return tableauValeurBlocs = new int[4] { 0, 0, 1, 1 };
      }
      // Si la pièce choisie aléatoirement est un T
      else if (pieceAleatoire == (int)TypeBloc.T)
      {
        return tableauValeurBlocs = new int[4] { 0, 1, 1, 1 };
      }
      // Si la pièce choisie aléatoirement est un Z (S de l'autre sens)
      else if (pieceAleatoire == (int)TypeBloc.Z)
      {
        return tableauValeurBlocs = new int[4] { 1, 0, 1, 0 };
      }
      // Sinon, initie une pièce vide
      else
      {
        return tableauValeurBlocs = new int[4] { 0, 0, 0, 0 };
      }
    }

    /// <summary>
    /// Fonction qui choisie la pièce aléatoirement.
    /// </summary>
    /// <returns>Retourne, sous un entier, la pièce choisie aléatoirement</returns>
    int PieceAleatoire()
    {
      Random rnd = new Random();
      int blocAleatoire = rnd.Next(2,10);
      return blocAleatoire;
    }

    /// <summary>
    /// Fonction qui, à chaque mouvement, appele la fonction qui effectue le mouvement.
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
      // Initie le nombre de blocs gelés dans toutes les lignes à 0
      for (int i = 0; i < ligneÀRetirer.Length; i++)
      {
        ligneÀRetirer[i] = 0;
      }
      // Donne la hauteur initiale
      addY = 0;
      // Donne la position en X initiale (milieu dans ce cas-ci)
      addX = (nbColonnesJeu / 2);
      // Choisi une pièce aléatoire
      pieceAleatoire = PieceAleatoire();
      // Assignent le bloc choisi au bonnes positions des tableaux "blocActif"
      blocActifY = AssignerPositionFormeY(pieceAleatoire);
      blocActifX = AssignerPositionFormeX(pieceAleatoire);
      // Vérifie si la partie est terminée (lorsqu'un bloc ne peut plus apparaître)
      VerifierSiPartieTermine();
    }

    /// <summary>
    /// Fonction qui permet le mouvement de la pièce selon la touche que le joueur appuie
    /// </summary>
    /// <param name="e"></param>
    void MouvementJoueur(KeyPressEventArgs e)
    {
      //<ADion>

      bool reponseBouger = true;
      reponseBouger = BlocPeutBouger(e);
      if (reponseBouger == true)
      {
        //Bouger la pièce à gauche
        if (e.KeyChar == 65 || e.KeyChar == 97)
        {
          addX--;
          FaireCouleursBlocs();
        }
        //Bouger la pièce à droite
        else if (e.KeyChar == 68 || e.KeyChar == 100)
        {
          addX++;
          FaireCouleursBlocs();
        }

        //</ADion>

        //<alangevin>
        //Bouger la pièce du sens horaire
        else if (e.KeyChar == 69 || e.KeyChar == 101)
        {
          int[] temporaireTableauY = new int[4];
          for (int compteur = 0; compteur < blocActifX.Length; compteur++)
          {
            temporaireTableauY[compteur] = blocActifX[compteur];
          }
          for (int compteur = 0; compteur < blocActifX.Length; compteur++)
          {
            blocActifX[compteur] = -blocActifY[compteur];
            blocActifY[compteur] = temporaireTableauY[compteur];
          }
          FaireCouleursBlocs();
        }
        //Bouger la pièce du sens anti-horaire
        else if (e.KeyChar == 81 || e.KeyChar == 113)
        {
          int[] temporaireTableauY = new int[4];
          for (int compteur = 0; compteur < blocActifX.Length; compteur++)
          {
            temporaireTableauY[compteur] = -blocActifX[compteur];
          }
          for (int compteur = 0; compteur < blocActifX.Length; compteur++)
          {
            blocActifX[compteur] = blocActifY[compteur];
            blocActifY[compteur] = temporaireTableauY[compteur];
          }
          FaireCouleursBlocs();
        }

        //</alangevin>

        //<ADion>

        // Bouger la pièce vers le bas
        else if (e.KeyChar == 83 || e.KeyChar == 32 || e.KeyChar == 115)
        {
          addY++;
          FaireCouleursBlocs();
        }
        // Si aucune action
        else
        {
          FaireCouleursBlocs();
        }

        //</ADion>

      }
    }
    /// <summary>
    /// 
    /// </summary>
    void VerifierSiPartieTermine ()
    {
      pieceAleatoire = PieceAleatoire();
      blocActifY = AssignerPositionFormeY(pieceAleatoire);
      blocActifX = AssignerPositionFormeX(pieceAleatoire);
    }

    //<ADion>

    /// <summary>
    /// Va démarrer la partie lorsque le joueur cliquera sur l'onglet "Démarrer la partie" dans l'onglet "Jeu". Si la musique est active, cela va aussi démarrer la musique.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void démarrerLaPartieToolStripMenuItem_Click(object sender, EventArgs e)
    {
      RefairePartie();
      // Si le joueur a activé la musique, ceci va la démarrer
      if (musiqueActive == true)
      {
        mediaPlayer.URL = "Resources/background.mp3";
        mediaPlayer.controls.play();
      }
      // Génère les blocs vide et le bloc choisi aléatoirement
      FaireCouleursBlocs();
      // Démarre le timer pour la descente du bloc à environ chaque seconde
      timerDescente.Start();
    }

    /// <summary>
    /// Va ouvrir le menu de configurations qui va permettre au joueur de modifier 
    /// la taille de la grille de jeu et d'activer la musique.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void configurationsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // Réinitialise la partie si le joueur change les configurations
      RefairePartie();
      // Va chercher le nombre de lignes à mettre selon le choix du joueur
      configs.SpecifierNbLignes(nbLignesJeu);
      // Va chercher le nombre de colonnes à mettre selon le choix du joueur
      configs.SpecifierNbColonnes(nbColonnesJeu);
      // Si le joueur valide ses choix, cela va les appliquer
      if (configs.ShowDialog() == DialogResult.OK)
      {
        nbLignesJeu = configs.ObtenirNbLignes();
        nbColonnesJeu = configs.ObtenirNbColonnes();
        musiqueActive = configs.MusiqueActive();
        InitialiserSurfaceDeJeu(nbLignesJeu, nbColonnesJeu);
      }
      RemplirTableauEtatVide();
    }

    /// <summary>
    /// Fonction qui permet de retirer les lignes pleines de blocs gelés.
    /// </summary>
    void RetirerLignes()
    {
      // Vérifie lignes par lignes s'il y a des blocs gelés dans celle-ci
      for (int i = 0; i < etatBlocs.GetLength(0); i++)
      {
        for (int j = 0; j < etatBlocs.GetLength(1); j++)
        {
          if (etatBlocs[i, j] == (int)TypeBloc.Gelé)
          {
            // Chaques blocs gelés trouvés dans la ligne
            ligneÀRetirer[i] += 1;
          }
        }
        // S'il y a autant de blocs gelés dans la ligne qu'il y a de colonnes, va retirer les lignes (va mettre les blocs gelés de la ligne en bloc vide)
        if (ligneÀRetirer[i] == nbColonnesJeu)
        {
          for (int k = 0; k < etatBlocs.GetLength(1); k++)
          {
            etatBlocs[i, k] = (int)TypeBloc.None;
          }
          // Donne la dernière ligne qui est à décaler
          derniereLigneADécaler = i;
          // Ajoute le nombre de lignes à décaler
          nbLignesADécaler++;
        }
        ligneÀRetirer[i] = 0;
      }
      // Si la dernière ligne à décaler n'est pas la première, va décaler les lignes
      if (derniereLigneADécaler != 0)
      {
        DecalerLignes();
      }
    }

    /// <summary>
    /// Fonction qui permet de décaler toutes les lignes situées au-dessus de la ligne qui a été retirée la plus basse.
    /// </summary>
    void DecalerLignes()
    {
      // Variable qui correspond au nombre de points que le joueur aura lors d'un tour (Un tour est un placement de bloc)
      int pointageTour = 0;
      // Décale lignes par lignes à partir de la dernière ligne à décaler (Du bas jusqu'en-haut)
      for (int i = derniereLigneADécaler; i > 0 + nbLignesADécaler; i--)
      {
        for (int j = 0; j < etatBlocs.GetLength(1); j++)
        {
          etatBlocs[i, j] = etatBlocs[i - nbLignesADécaler, j];
        }
      }
      // La première ligne retirée donne 100 points
      if (nbLignesADécaler == 1)
      {
        pointageTour += 100;
      }
      // Sinon, chaque ligne retirée double le nombre de points acquis pour le tour (Jusqu'à un maximum de 800 points par tour)
      else
      {
        pointageTour += 100;
        // Double les points à chaque ligne retirée
        for (int i = 0; i <= nbLignesADécaler; i++)
        {
          pointageTour *= 2;
        }
      }
      // Ajoute les pointages du tour au pointage global
      pointage += pointageTour;
      pointageTour = 0;
      // Refait les couleurs et réinitialise la dernière ligne à décaler
      //FaireCouleursBlocs();
      derniereLigneADécaler = 0;
      nbLignesADécaler = 0;
    }

    /// <summary>
    /// Permet d'associer la valeur du numericUpDown à la trackBar correspondante afin d'afficher
    /// les mêmes valeurs sur les deux (Ligne dans ce cas-ci)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void numLignesJeu_ValueChanged(object sender, EventArgs e)
    {
      trackBarLignesJeu.Value = (int)numLignesJeu.Value;
    }

    /// <summary>
    /// Permet d'associer la valeur du numericUpDown à la trackBar correspondante afin d'afficher
    /// les mêmes valeurs sur les deux (Colonnne dans ce cas-ci)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void numColonnesJeu_ValueChanged(object sender, EventArgs e)
    {
      trackBarColonnesJeu.Value = (int)numColonnesJeu.Value;
    }

    /// <summary>
    /// Permet d'associer la valeur de la trackBar au numericUpDown correspondant afin d'afficher
    /// les mêmes valeurs sur les deux (Colonne dans ce cas-ci)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void trackBarColonnesJeu_ValueChanged(object sender, EventArgs e)
    {
      numColonnesJeu.Value = trackBarColonnesJeu.Value;
    }

    /// <summary>
    /// Permet d'associer la valeur de la trackBar au numericUpDown correspondant afin d'afficher
    /// les mêmes valeurs sur les deux (Ligne dans ce cas-ci)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void trackBarLignesJeu_ValueChanged(object sender, EventArgs e)
    {
      numLignesJeu.Value = trackBarLignesJeu.Value;
    }

    /// <summary>
    /// Permet de prendre en compte les nouvelles données chosies lorsque l'on clique sur le bouton
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnOk_Click(object sender, EventArgs e)
    {
      // Met fin à la partie et réinitialise tout
      RefairePartie();
      // Donne les nouvelles valeurs à nbLignesJeu et nbColonnesJeu
      nbLignesJeu = trackBarLignesJeu.Value;
      nbColonnesJeu = trackBarColonnesJeu.Value;
      // Refait le tableau de jeu
      InitialiserSurfaceDeJeu(nbLignesJeu, nbColonnesJeu);
    }

    /// <summary>
    /// Permet de confirmer si la musique est active ou non
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void checkBoxActivationMusique_CheckedChanged(object sender, EventArgs e)
    {
      // Si la case est cochée, la musique est active
      if (checkBoxActivationMusique.Checked == true)
      {
        musiqueActive = true;
      }
      // Sinon, inactive
      else 
      {
        musiqueActive = false;
      }
    }

    //</ADion>

  }
}

#endregion