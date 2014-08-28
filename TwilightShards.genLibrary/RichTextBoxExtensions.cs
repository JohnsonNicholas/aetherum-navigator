using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TwilightShards.genLibrary
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public static void AppendBoldText(this RichTextBox box, string text)
        {
            box.SelectionFont = new Font(box.Font, FontStyle.Bold);
            box.AppendText(text);
            box.SelectionFont = new Font(box.Font, FontStyle.Regular);
        }
    }
}
