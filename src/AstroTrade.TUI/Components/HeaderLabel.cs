#nullable enable

using Terminal.Gui;
using Terminal.Gui.Drawing;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace YourApp.Views // Or Terminal.Gui.Views if you prefer
{
    /// <summary>
    /// A composite <see cref="View"/> that displays a Name and a Value on a single line,
    /// separated by a customizable string. This view is useful for creating headers or
    /// status fields.
    /// </summary>
    public class HeaderLabel : View
    {
        private readonly Label _nameLabel;
        private readonly Label _separatorLabel;
        private readonly Label _valueLabel;
        private string _separatorText;

        /// <summary>
        /// _nameLabel Initializes a new instance of the<see cref = "HeaderLabel" /> class.
        /// </summary>
        public HeaderLabel()
        {
            // Initialize child controls
            _nameLabel = new Label();
            _valueLabel = new Label();
            _separatorText = ": "; // Default separator
            _separatorLabel = new Label() { Text = _separatorText };

            // Configure layout to "lock" the views together horizontally
            // The Name label starts at the left edge and sizes to its text
            _nameLabel.X = 0;
            _nameLabel.Y = 0;
            _nameLabel.Width = Dim.Auto(DimAutoStyle.Text);
            _nameLabel.Height = 1;

            // The Separator label is positioned immediately to the right of the Name label
            _separatorLabel.X = Pos.Right(_nameLabel);
            _separatorLabel.Y = 0;
            _separatorLabel.Width = Dim.Auto(DimAutoStyle.Text);
            _separatorLabel.Height = 1;

            // The Value label is positioned immediately to the right of the Separator
            _valueLabel.X = Pos.Right(_separatorLabel);
            _valueLabel.Y = 0;
            // The Value label fills the remaining available width
            _valueLabel.Width = Dim.Fill();
            _valueLabel.Height = 1;

            // The composite view itself should be one line high
            Height = 1;

            // Add the child controls to this View's Subviews collection
            Add(_nameLabel, _separatorLabel, _valueLabel);
        }

        /// <summary>
        /// Gets or sets the text for the Name part of the header.
        /// </summary>
        public string NameText
        {
            get => _nameLabel.Text;
            set
            {
                _nameLabel.Text = value;
                // The layout system will automatically reposition other views
            }
        }

        /// <summary>
        /// Gets or sets the text for the Value part of the header.
        /// </summary>
        public string ValueText
        {
            get => _valueLabel.Text;
            set { _valueLabel.Text = value; }
        }

        /// <summary>
        /// Gets or sets the string that separates the Name and Value. Defaults to ": ".
        /// </summary>
        public string Separator
        {
            get => _separatorText;
            set
            {
                _separatorText = value;
                _separatorLabel.Text = value;
                // The layout system will automatically reposition the Value label
            }
        }
    }
}
