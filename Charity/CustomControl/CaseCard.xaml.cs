namespace Charity.CustomControl;

public partial class CaseCard : ContentView
{
	
	public CaseCard()
	{
		InitializeComponent();
	}

    #region Tittle

    public static readonly BindableProperty TitleProperty =
        BindableProperty.Create(nameof(Title),
        typeof(string), typeof(CaseCard), default,
        BindingMode.TwoWay);
    // Gets or sets TextLable value  
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion
    #region ImageSource
    public static readonly BindableProperty ImageSourceProperty =
        BindableProperty.Create(nameof(ImageSource),
        typeof(string), typeof(CaseCard), default,
        BindingMode.TwoWay);
    // Gets or sets ImageSource value  
    public string ImageSource
    {
        get => (string)GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }
    #endregion

    #region TextLable

    public static readonly BindableProperty TextLableProperty =
        BindableProperty.Create(nameof(TextLable),
        typeof(string), typeof(CaseCard), default,
        BindingMode.TwoWay);
    // Gets or sets TextLable value  
    public string TextLable
    {
        get => (string)GetValue(TextLableProperty);
        set => SetValue(TextLableProperty, value);
    }

    #endregion
}