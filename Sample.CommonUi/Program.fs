open System
open FWinForms
open System.Windows.Forms

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
                    |> Menu.verb (fun _ -> (
                        Sys.openUrlInBrowser
                            GitHubProjectUrl
                       ))
                ; Menu.separator ()
                ; $"&About {AppName}"
                    |> Menu.verb (fun _ -> (
                        MessageBox.Show(
                            $"{AppName} v{``FWinForms Version``}"
                            , $"About {AppName}"
                        ) |> ignore
                    ))
                ]
            ]

    let mainStatusBar =
        StatusBar.create
            [ "Ready" |> StatusBar.label
            ; StatusBar.separator ()
            ; "Want to know more? Select 'Help → ..." |> StatusBar.label
            ]

    "WinForms ♥ F#"
    |> Form.create
    |> Form.beginInit
    |> Form.addControls
        [ Layout.panel
            [ FButton.create (fun btn -> (
                btn.Text <- "Test #1"
                btn.Top <- 0
                btn.Left <- 0
                btn.Click.Add (fun _ -> (
                    MessageBox.Show(
                        $"TEST * TEST * TEST"
                        , $"{AppName}"
                    ) |> ignore
                ))
              ))
            ; FButton.create (fun btn -> (
                btn.Text <- "Test #2"
                btn.Enabled <- false
                btn.Anchor <-
                    AnchorStyles.Left 
                    ||| AnchorStyles.Bottom
                btn.Click.Add Stub.doNothingA__TODO
              ))
            ]
            |> FControl.setup (fun x -> (
                x.BorderStyle <- BorderStyle.Fixed3D
                x.Dock <- DockStyle.Fill
               ))
        ; mainStatusBar
        ; mainMenu
        ]
    |> Form.initEnd
    |> FControl.setup (fun form ->(
        form.ClientSize <- System.Drawing.Size(640, 400)
       ))

let mainNotifyIcon =
    SystemTray.createIcon Stub.systemAppIcon__TODO
    |> SystemTray.contextMenu
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