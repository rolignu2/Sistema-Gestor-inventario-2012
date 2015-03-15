using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delatorre.Modulos
{
    class Sugestion 
    {

        List<string> Suggestions;
        int PreviousLength;

        public DataGridView Grilla;

        public Sugestion(DataGridView GrillaDatos = null) 
        {
            Grilla = GrillaDatos;
        }

        public void StartSuggestion()
        {
            PreviousLength = 0;
            Suggestions = new List<string>();
            for (int i = 0; i < this.Grilla.Rows.Count; i++)
            {
                for (int k = 0; k < Grilla.ColumnCount; k++)
                {
                    Suggestions.Add(Grilla[k, i].Value.ToString());
                }
            }
            Suggestions.Sort();
        }



        private string FindSuggestion(string Input)
        {
            if (Input != "")
                foreach (string Suggestion in Suggestions)
                {
                    if (Suggestion.StartsWith(Input))
                        return Suggestion;
                }
            return null;
        }

        public void Getsuggestion(TextBox Text)
        {

            int CursorPosition = Text.SelectionStart;
            if (Text.Text.Length > PreviousLength && CursorPosition >= 0)
            {
                string Suggestion = FindSuggestion(Text.Text.Substring(0, CursorPosition));
                if (Suggestion != null)
                {

                    Text.Text = Suggestion;
                    Text.Select(CursorPosition, 0);
                }
            }
            PreviousLength = Text.Text.Length;
        }
    }
}
