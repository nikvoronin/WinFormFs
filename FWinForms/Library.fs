module FWinForms

open System.Windows.Forms
open System.Drawing
open System.Diagnostics
open System

[<Literal>]
let ``FWinForms Version`` = "3.5.27-alpha"


module App =
    /// Configure HighDpi scalling for looking good
    let initSysRender =
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(false)
        Application.SetHighDpiMode(HighDpiMode.SystemAware) |> ignore

    // Start application with given form
    let runWith (form: Form) =
        Application.Run(form)
        0

    let run () =
        Application.Run()

    let exit () = Application.Exit()
    let exitA _ = Application.Exit()


module Form =
    let title caption (form: Form) =
        form.Text <- caption
        form

    let clientSize width height (form: Form) =
        form.ClientSize <- new Size(width, height)
        form

    let addControls (controls: Control seq) (form: Form) : Form =
        form.Controls.AddRange( Array.ofSeq controls)
        form

    let beginInit (form: Form) =
        form.SuspendLayout()
        form.AutoScaleDimensions <- new System.Drawing.SizeF(6F, 13F)
        form.AutoScaleMode <- AutoScaleMode.Font
        form

    let initEnd (form: Form) =
        form.ResumeLayout(false)
        form.PerformLayout()
        form

    let create (caption: string) =
        new Form()
        |> title caption


module ToolStrip =
    let separator () =
        new ToolStripSeparator()


module Menu =
    let separator = ToolStrip.separator

    let verb click (text: string) : ToolStripItem =
        let item = new ToolStripMenuItem(text)
        item.Click.Add( click )
        item

    let stub__TODO (text: string) =
        let root = new ToolStripMenuItem(text)
        root

    let strip (items: ToolStripItem seq) (text: string) : ToolStripItem =
        let root = new ToolStripMenuItem(text)
        root.DropDownItems.AddRange(Array.ofSeq items)
        root

    let create (items: ToolStripItem seq) =
        let menu = new MenuStrip()
        menu.Items.AddRange (Array.ofSeq items) |> ignore
        menu

    let createContext (items: ToolStripItem seq) =
        let menu = new ContextMenuStrip()
        menu.Items.AddRange (Array.ofSeq items) |> ignore
        menu


module MessageBox =
    /// Show message box with text, caption and default OK button
    let showText text caption =
        MessageBox.Show
            ( text= text
            , caption= caption
            )
        |> ignore


module Sys =
    /// Open URL in a system web browser. Call cmd start
    let openUrlInBrowser url =
        let procInfo =
            new ProcessStartInfo
                ( "cmd"
                , $"/c start {url}"
                )

        procInfo.CreateNoWindow <- true
        Process.Start(procInfo) |> ignore


module Stub =
    /// Just a stub for event handlers. Lets do nothing
    let doNothingA__TODO = fun x -> ()
    let systemAppIcon__TODO = SystemIcons.Application


module StatusBar =
    let separator = ToolStrip.separator

    let create (items: ToolStripItem seq) =
        let bar = new StatusStrip()
        bar.Items.AddRange(Array.ofSeq items) |> ignore
        bar

    let label (text: string) : ToolStripItem =
        let label = new ToolStripLabel(text)
        label

// TODO: Add StatusBar controls: ToolStripProgressBar, ToolStripButton


module Control =
    let setup init x =
        init x
        x

    let create<'a when 'a : (new : unit -> 'a)> init =
        new 'a ()
        |> setup init


module Layout =
    let panel (controls: Control seq) =
        let panel = new Panel()
        panel.Controls.AddRange(Array.ofSeq controls)
        panel


module SystemTray =
    let createIcon (icon: Icon) =
        let notifyIcon = new NotifyIcon ()
        notifyIcon.Icon <- icon
        notifyIcon

    let contextMenu (menu: ContextMenuStrip) (notifyIcon: NotifyIcon) : NotifyIcon =
        notifyIcon.ContextMenuStrip <- menu
        notifyIcon

    let updateText (hintText: string) (notifyIcon: NotifyIcon) : NotifyIcon =
        notifyIcon.Text <- hintText
        notifyIcon

    let changeIcon (icon: Icon) (notifyIcon: NotifyIcon) : NotifyIcon =
        notifyIcon.Icon <- icon
        notifyIcon

    let showIcon (notifyIcon: NotifyIcon) =
        notifyIcon.Visible <- true
        notifyIcon

    let hideIcon (notifyIcon: NotifyIcon) =
        notifyIcon.Visible <- false
        notifyIcon