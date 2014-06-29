using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Bosphorus.Common.Clr.IO.TextWriter
{
    public class TextBoxWriter : System.IO.TextWriter
    {
        private readonly TextBox output;

        public TextBoxWriter(TextBox output)
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
