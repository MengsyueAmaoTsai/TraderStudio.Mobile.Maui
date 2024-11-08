﻿using Android.App;
using Android.Runtime;

namespace RichillCapital.TraderStudio.Mobile;

[Application]
public sealed class MainApplication : MauiApplication
{
    public MainApplication(
        IntPtr handle, 
        JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    protected override MauiApp CreateMauiApp() => 
        MauiProgram.CreateMauiApp();
}
