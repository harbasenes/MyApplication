using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Bilance
{
    public class Validator
    {
        public static bool IsPresent(Control control, string name)
        {
            string controlName = control.GetType().Name;

            if (controlName == "TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(name + " je podatak koji se mora upisati.", "Nedostaje podatak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Focus();
                    return false;
                }
                return true;
            }
            
            if (controlName == "ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(name + " je podatak koji se mora upisati.", "Nedostaje podatak", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox.Focus();
                    return false;
                }
                return true;
            }

            return true;
 
        }

        public static bool IsPeriod(DateTime datum1, DateTime datum2)
        {
            if (datum1 > datum2)
            {
                MessageBox.Show("Period nije dobro upisan.\nPrvi datum perioda je veći od drugog datuma.", "Nepravilan period", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;

            }
            return true;
        }

        public static bool IsFolderExist(TextBox textBox, string name)
        {
            if (!Directory.Exists(textBox.Text))
            {
                    MessageBox.Show(name + " ne postoji.", "Mapa ne postoji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Focus();
                    return false;
                
            }
            return true;
        }
        
        public static bool IsFileExist(TextBox textBox, string name)
        {
            if (!File.Exists(textBox.Text))
            {
                MessageBox.Show(name + " ne postoji.", "Datoteka ne postoji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus();
                return false;

            }
            return true;
        }
    }
}
