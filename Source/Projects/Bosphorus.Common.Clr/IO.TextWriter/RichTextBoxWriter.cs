using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Bosphorus.Common.Clr.IO.TextWriter
{
    public class RichTextBoxWriter : System.IO.TextWriter
    {
        private readonly RichTextBox output;

        public RichTextBoxWriter(RichTextBox output)
        {
            this.output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            string text = value.ToString(CultureInfo.InvariantCulture);
            output.AppendText(text);
        }

        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
