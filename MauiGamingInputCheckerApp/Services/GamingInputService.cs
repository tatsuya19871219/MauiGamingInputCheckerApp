using MauiGamingInputCheckerApp.Models;

namespace MauiGamingInputCheckerApp.Services;

public partial class GamingInputService
{

    public List<GamingInput> GamingInputs;

    public GamingInputService()
    {
        InitializeService();
    }

    async void InitializeService()
    {
        GamingInputs = await GetGamingInputsAsync();
    }

    private partial Task<List<GamingInput>> GetGamingInputsAsync();
}
