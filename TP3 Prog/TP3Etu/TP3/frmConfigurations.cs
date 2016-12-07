using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP3
{
  public partial class frmConfigurations : Form
  {
    bool musiqueActive = false;
    public frmConfigurations()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Permet d'associer la valeur du numericUpDown à la trackBar correspondante afin d'afficher
    /// les mêmes valeurs sur les deux (Ligne dans ce cas-ci)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void numLignes_ValueChanged(object sender, EventArgs e)
    {
      trackBarLignes.Value = (int)numLignes.Value;
    }

    /// <summary>
    /// Permet d'associer la valeur du numericUpDown à la trackBar correspondante afin d'afficher
    /// les mêmes valeurs sur les deux (Colonnne dans ce cas-ci)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void numColonnes_ValueChanged(object sender, EventArgs e)
    {
      trackBarColonnes.Value = (int)numColonnes.Value;
    }

    /// <summary>
    /// Permet d'associer la valeur de la trackBar au numericUpDown correspondant afin d'afficher
    /// les mêmes valeurs sur les deux (Colonne dans ce cas-ci)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void trackBarColonnes_ValueChanged(object sender, EventArgs e)
    {
      numColonnes.Value = trackBarColonnes.Value;
    }

    /// <summary>
    /// ermet d'associer la valeur de la trackBar au numericUpDown correspondant afin d'afficher
    /// les mêmes valeurs sur les deux (Ligne dans ce cas-ci)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void trackBarLignes_ValueChanged(object sender, EventArgs e)
    {
      numLignes.Value = trackBarLignes.Value;
    }

    /// <summary>
    /// Spécifie quel est la velur de nbLignes
    /// </summary>
    /// <param name="nbLignes">Entier qui correspond à la valeur de trackBarLignes</param>
    public void SpecifierNbLignes(int nbLignes)
    {
      trackBarLignes.Value = nbLignes;
    }

    /// <summary>
    /// Envoie au formulaire principal la valeur de nbLignes
    /// </summary>
    /// <returns></returns>
    public int ObtenirNbLignes()
    {
      return trackBarLignes.Value;
    }

    /// <summary>
    /// Spécifie quel est la velur de nbColonnes
    /// </summary>
    /// <param name="nbColonnes"></param>
    public void SpecifierNbColonnes(int nbColonnes)
    {
      trackBarColonnes.Value = nbColonnes;
    }

    /// <summary>
    /// Envoie au formulaire principal la valeur de nbColonnes
    /// </summary>
    /// <returns></returns>
    public int ObtenirNbColonnes()
    {
      return trackBarColonnes.Value;
    }

    /// <summary>
    /// Confirme si la musique est active ou non et l'envoie dans le formulaire principal
    /// </summary>
    /// <returns></returns>
    public bool MusiqueActive()
    {
      if (checkBoxMusique.Checked == true)
      {
        musiqueActive = true;
      }
      else
      {
        musiqueActive = false;
      }
      return musiqueActive;
    }
  }
}
