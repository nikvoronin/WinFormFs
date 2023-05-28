open System
open FWinForms
open System.Windows.Forms
open System.Drawing

[<Literal>]
let AppName = "FWinForms"
[<Literal>]
let GitHubProjectUrl = "https://github.com/nikvoronin/FWinForms"

let mainForm =
    let mainMenu =
        Menu.create
            [ "&File"
                |> Menu.strip
                [ "&Open..." |> Menu.stub__TODO
                ; "&Save As..." |> Menu.stub__TODO
                ; Menu.separator ()
                ; "&Quit" |> Menu.verb App.exitA
                ]
            ; "&Edit" |> Menu.stub__TODO
            ; "&View" |> Menu.stub__TODO
            ; "&Help"
                |> Menu.strip
                [ "&Technical Details 🚀"
                    |> Menu.verb
                        (fun _ ->
                            Sys.openUrlInBrowser
                                GitHubProjectUrl
                        )
                ; Menu.separator ()
                ; $"&About {AppName}"
                    |> Menu.verb
                        (fun _ ->
                            MessageBox.Show(
                                $"{AppName} v{``FWinForms Version``}"
                                , $"About {AppName}"
                            ) |> ignore
                        )
                ]
            ]

    let mainStatusLabel = StatusBar.label "Ready" 

    let mainStatusBar =
        StatusBar.create
            [ mainStatusLabel
                |> setup
                    (fun x ->
                        x.BackColor <-
                            colorFrom KnownColor.LightGreen
                    )
            ; StatusBar.separator ()
            ; StatusBar.progress ()
                |> setup
                    (fun x ->
                        x.Style <- ProgressBarStyle.Marquee
                    )
            ; StatusBar.separator ()
            ; "Want to know more? Select 'Help → ..." |> StatusBar.label
            ]

    "WinForms ♥ F#"
    |> Frm.create
    |> Frm.beginInit
    |> Frm.addControls
        [ Layout.flowV
            [ create<Button>
                (fun btn ->
                    btn.Text <- "Test #1"
                    //btn.Top <- 0
                    //btn.Left <- 0
                    btn.Click.Add
                        (fun _ ->
                            MessageBox.Show(
                                $"TEST * TEST * TEST"
                                , $"{AppName}"
                            ) |> ignore
                        )
                )
            ; Btn.create
                (fun btn ->
                    btn.Text <- "Test #2"
                    btn.Enabled <- false
                    //btn.Anchor <-
                    //    AnchorStyles.Left 
                    //    ||| AnchorStyles.Bottom
                    btn.Click.Add Stub.doNothingA__TODO
                )
            ; create<ListBox>
                (fun x ->
                    x.Items.AddRange (
                        Array.ofSeq<obj>
                            [ "First"
                            ; "Second"
                            ; "Third"
                            ]
                    )
                    x.SelectedIndexChanged.Add(
                        (fun _ ->
                            mainStatusLabel.Text <-
                                string x.SelectedItem
                        )
                    )
                )
            ]
            |> setup
                (fun x ->
                    x.Dock <- DockStyle.Fill
                )
        ; mainStatusBar
        ; mainMenu
        ]
    |> Frm.initEnd
    |> setup
        (fun form ->
            form.ClientSize <- System.Drawing.Size(640, 400)
        )

let mainNotifyIcon =
    SystemTray.createIcon SystemIcons.Application // TODO: STUB: replace with app-icon
    |> SystemTray.setContextMenu
        ( Menu.createContext
            [ "&Open..." |> Menu.stub__TODO
            ; "&Save As..." |> Menu.stub__TODO
            ; Menu.separator ()
            ; "&Quit" |> Menu.verb App.exitA
            ]
        )
    |> SystemTray.showIcon

[<EntryPoint; STAThread>]
let main argv =
    use _ = mainNotifyIcon

    App.initSysRender
    App.runWith mainForm