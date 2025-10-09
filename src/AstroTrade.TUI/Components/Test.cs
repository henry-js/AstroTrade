using Terminal.Gui;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

public partial class Test : View
{
    private FrameView frameView;
    private Label nameLabel;
    private Label separatorLabel;
    private Label valueLabel;

    public Test()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.valueLabel = new Label();
        this.separatorLabel = new Label();
        this.nameLabel = new Label();
        this.frameView = new FrameView();
        this.Width = Dim.Fill(0);
        this.Height = Dim.Fill(0);
        this.X = 0;
        this.Y = 0;
        this.Visible = true;
        this.Arrangement = ViewArrangement.Fixed;
        this.CanFocus = false;
        this.ShadowStyle = ShadowStyle.None;
        this.TextAlignment = Alignment.Start;
        this.frameView.Width = Dim.Auto();
        this.frameView.Height = Dim.Auto();
        this.frameView.X = 31;
        this.frameView.Y = 11;
        this.frameView.Visible = true;
        this.frameView.Arrangement = ViewArrangement.Fixed;
        this.frameView.CanFocus = true;
        this.frameView.ShadowStyle = ShadowStyle.None;
        this.frameView.Data = "frameView";
        this.frameView.TextAlignment = Alignment.Start;
        this.frameView.Title = "";
        this.Add(this.frameView);
        this.nameLabel.Width = Dim.Auto();
        this.nameLabel.Height = Dim.Auto();
        this.nameLabel.X = 0;
        this.nameLabel.Y = 0;
        this.nameLabel.Visible = true;
        this.nameLabel.Arrangement = ViewArrangement.Fixed;
        this.nameLabel.CanFocus = false;
        this.nameLabel.ShadowStyle = ShadowStyle.None;
        this.nameLabel.Data = "nameLabel";
        this.nameLabel.Text = "NameLabel";
        this.nameLabel.TextAlignment = Alignment.Start;
        this.frameView.Add(this.nameLabel);
        this.separatorLabel.Width = Dim.Auto();
        this.separatorLabel.Height = Dim.Auto();
        this.separatorLabel.X = Pos.Right(nameLabel);
        this.separatorLabel.Y = 0;
        this.separatorLabel.Visible = true;
        this.separatorLabel.Arrangement = ViewArrangement.Fixed;
        this.separatorLabel.CanFocus = false;
        this.separatorLabel.ShadowStyle = ShadowStyle.None;
        this.separatorLabel.Data = "separatorLabel";
        this.separatorLabel.Text = " | ";
        this.separatorLabel.TextAlignment = Alignment.Start;
        this.frameView.Add(this.separatorLabel);
        this.valueLabel.Width = Dim.Auto();
        this.valueLabel.Height = Dim.Auto();
        this.valueLabel.X = Pos.Right(separatorLabel);
        this.valueLabel.Y = 0;
        this.valueLabel.Visible = true;
        this.valueLabel.Arrangement = ViewArrangement.Fixed;
        this.valueLabel.CanFocus = false;
        this.valueLabel.ShadowStyle = ShadowStyle.None;
        this.valueLabel.Data = "valueLabel";
        this.valueLabel.Text = "i am val";
        this.valueLabel.TextAlignment = Alignment.Start;
        this.frameView.Add(this.valueLabel);
    }
}
