using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

using Terminal.Gui;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace AstroTrade.TUI.Views;

public partial class ShellView : Window
{
    private FrameView mainFrame;
    private FrameView headerFrame;
    private FrameView logFrame;
    private MenuBarv2 menuBar;
    private StatusBar statusBar;
    private Shortcut f1EditMe;
    private Label agentSymbolLabel;

    private void InitializeComponent()
    {
        this.menuBar = new MenuBarv2();
        this.statusBar = new StatusBar();
        this.logFrame = new FrameView();
        this.mainFrame = new FrameView();
        this.headerFrame = new FrameView();
        this.Width = Dim.Fill(0);
        this.Height = Dim.Fill(0);
        this.X = 0;
        this.Y = 0;
        this.Visible = true;
        this.Arrangement = ViewArrangement.Overlapped;
        this.CanFocus = true;
        this.ShadowStyle = ShadowStyle.None;
        this.Modal = false;
        this.TextAlignment = Alignment.Start;
        this.Title = "";
        menuBar.Width = Dim.Fill();
        menuBar.X = 0;
        menuBar.Y = Pos.Top(this);
        menuBar.Title = "Menu";
        menuBar.Menus = [
            new ("_File"),
        ];
        this.Add(menuBar);
        this.headerFrame.Width = Dim.Fill(0);
        this.headerFrame.Height = 5;
        this.headerFrame.X = 0;
        this.headerFrame.Y = Pos.Bottom(menuBar);
        this.headerFrame.Visible = true;
        this.headerFrame.Arrangement = ViewArrangement.Fixed;
        this.headerFrame.CanFocus = true;
        this.headerFrame.ShadowStyle = ShadowStyle.None;
        this.headerFrame.Data = "headerFrame";
        this.headerFrame.TextAlignment = Alignment.Start;
        this.headerFrame.Title = "headerFrame";
        this.Add(this.headerFrame);
        this.mainFrame.Width = Dim.Fill(0);
        this.mainFrame.Height = Dim.Fill(6);
        this.mainFrame.X = 0;
        this.mainFrame.Y = Pos.Bottom(headerFrame);
        this.mainFrame.Visible = true;
        this.mainFrame.Arrangement = ViewArrangement.Fixed;
        this.mainFrame.CanFocus = true;
        this.mainFrame.ShadowStyle = ShadowStyle.None;
        this.mainFrame.Data = "mainFrame";
        this.mainFrame.TextAlignment = Alignment.Start;
        this.mainFrame.Title = "mainFrame";
        this.Add(this.mainFrame);
        this.logFrame.Width = Dim.Fill(0);
        this.logFrame.Height = 5;
        this.logFrame.X = 0;
        this.logFrame.Y = Pos.Top(statusBar) - 5;
        this.logFrame.Visible = true;
        this.logFrame.Arrangement = ViewArrangement.Fixed;
        this.logFrame.CanFocus = true;
        this.logFrame.ShadowStyle = ShadowStyle.None;
        this.logFrame.Data = "logFrame";
        this.logFrame.TextAlignment = Alignment.Start;
        this.logFrame.Title = "logFrame";
        this.Add(this.logFrame);
        this.statusBar.Width = Dim.Fill(0);
        this.statusBar.Height = Dim.Auto();
        this.statusBar.X = 0;
        this.statusBar.Y = Pos.AnchorEnd(0 + 1);
        this.statusBar.Visible = true;
        this.statusBar.Arrangement = ViewArrangement.Fixed;
        this.statusBar.CanFocus = true;
        this.statusBar.ShadowStyle = ShadowStyle.None;
        this.statusBar.Data = "statusBar";
        this.statusBar.Text = "";
        this.statusBar.TextAlignment = Alignment.Start;
        this.f1EditMe = new Shortcut(((Terminal.Gui.Drivers.KeyCode)(1114223u)), "F1 - Edit Me", null);
        this.statusBar.Add(this.f1EditMe);
        this.Add(this.statusBar);
    }
}
