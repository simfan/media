using Medias.Shared.DTOs;
namespace Medias.Scanner.Pages;

public partial class BarcodeProductReviewPage : ContentPage
{
    public BarcodeProductReviewPage(BarcodeProductDTO product)
    {
        ArgumentNullException.ThrowIfNull(product);

        InitializeComponent();

        if (string.IsNullOrWhiteSpace(product.NormalizedTitle))
        {
            product.TitleNormalization(product.Title);
        }

        BindingContext = product;
    }
}