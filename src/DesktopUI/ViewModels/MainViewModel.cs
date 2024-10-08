﻿using AstroTrade.Application;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DesktopUI.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _userName = string.Empty;

    [ObservableProperty] private string _password = string.Empty;

    [ObservableProperty] private string _greeting = "Hello there.";

     public string Icon { get; } = "/Assets/icons/Document/folder-open-fill.svg";

    private readonly ISpaceTradersApiService service;

    public MainViewModel(ISpaceTradersApiService service) : base()
    {
        this.service = service;
    }

    [RelayCommand]
    private async Task Login()
    {

        await Task.Delay(4000);

        Greeting = "Login success";
    }
}
