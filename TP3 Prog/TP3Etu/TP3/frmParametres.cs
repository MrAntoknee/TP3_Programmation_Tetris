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
  public partial class frmParametres : Form
  {
    public frmParametres()
    {
      InitializeComponent();
    }

    private void btnAnnuler_Click(object sender, EventArgs e)
    {

    }

    private void btnOk_Click(object sender, EventArgs e)
    {

    }

    private void numColonnes_ValueChanged(object sender, EventArgs e)
    {
      trackBarColonnes.Value = (int)numColonnes.Value;
    }

    private void numLignes_ValueChanged(object sender, EventArgs e)
    {
      trackBarLignes.Value = (int)numLignes.Value;
    }

    private void trackBarColonnes_ValueChanged(object sender, EventArgs e)
    {
      numColonnes.Value = trackBarColonnes.Value;
    }

    private void trackBarLignes_ValueChanged(object sender, EventArgs e)
    {
      numLignes.Value = trackBarLignes.Value;
    }

    private void checkBoxMusique_CheckedChanged(object sender, EventArgs e)
    {

    }

    public int LignesJeu()
    {
      int nbLignesJeu = trackBarLignes.Value;
      return nbLignesJeu;
    }

    public int ColonnesJeu()
    {
      int nbColonnesJeu = trackBarColonnes.Value;
      return nbColonnesJeu;
    }
  }
}
