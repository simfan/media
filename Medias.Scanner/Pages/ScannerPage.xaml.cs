using ZXing.Net.Maui;
using System.Net.Http.Json;
using Medias.Shared.DTOs;

namespace Medias.Scanner.Pages;

public partial class ScannerPage : ContentPage
{
    private static readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("http://10.0.2.2:5113") // Android emulator address for localhost
                                                      //BaseAddress = new Uri("https://localhost:7259")
                                                      // BaseAddress = new Uri("http://localhost:5113") // Default server address
    };

    public ScannerPage()
    {
        InitializeComponent();

        BarcodeReader.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.All,
            AutoRotate = true,
            TryHarder = true,
            TryInverted = true,
            Multiple = false
        };

        BarcodeReader.IsDetecting = true;
    }

    private void BarcodeReader_BarcodesDetected(
        object? sender,
        BarcodeDetectionEventArgs e)
    {
        var barcode = e.Results.FirstOrDefault();

        if (barcode is null)
            return;

        _ = ProcessBarcodeAsync(barcode.Value);
    }

    private void SubmitManualBarcode_Clicked(object sender, EventArgs e)
    {
        var barcode = ManualBarcodeEntry.Text;

        if (string.IsNullOrWhiteSpace(barcode))
            return;

        _ = ProcessBarcodeAsync(barcode);
        ManualBarcodeEntry.Text = string.Empty;
    }

    private async Task ProcessBarcodeAsync(string value)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            StatusLabel.Text = "Resolving barcode...";
        });

        try
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            Console.WriteLine($"Calling: {_httpClient.BaseAddress}api/barcode-test/{value}");
            System.Diagnostics.Debug.WriteLine($"Calling: {_httpClient.BaseAddress}api/barcode-test/{value}");
            /*var results = await _httpClient.GetAsync($"api/barcode-test/{value}", cts.Token);
            var barcodeProductDTO = await results.Content.ReadFromJsonAsync<BarcodeProductDTO>();
            if (barcodeProductDTO != null)
            {
                await OpenProductReviewAsync(barcodeProductDTO);
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(() => {
                    StatusLabel.Text = $"Server error: {results.StatusCode}";
                });
            }
            */
            var response = await _httpClient.GetAsync($"api/Scans/movies/{value}");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<MovieBarcodeLookupDto>();
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    StatusLabel.Text = data != null
                        ? $"Resolved: {data.SearchTitle}"
                        : $"Barcode: {value}";
                });
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    StatusLabel.Text = "Barcode not recognized.";
                });
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    StatusLabel.Text = $"Server error: {response.StatusCode}";
                });
            }
        }
        catch (OperationCanceledException)
        {
            MainThread.BeginInvokeOnMainThread(() => { StatusLabel.Text = "Request timed out."; });
        }
        catch (Exception ex)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                StatusLabel.Text = "Connection error. Is server running?";
            });
            System.Diagnostics.Debug.WriteLine($"API Error: {ex.Message}");
        }
    }

    private async Task OpenProductReviewAsync(
    BarcodeProductDTO product)
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await Navigation.PushAsync(
                new BarcodeProductReviewPage(product));
        });
    }
}