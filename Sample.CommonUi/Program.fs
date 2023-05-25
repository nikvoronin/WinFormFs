open System
open FWinForms

[<Literal>]
let AppName = "FWinForms"
[<Literal>]
let GitHubProjectUrl = "https://github.com/nikvoronin/FWinForms"

let mainForm =
    let mainMenu =
        Menu.create
            [ "&File" |> Menu.strip
                [ "&Open..." |> Menu.stub__TODO
                ; "&Save As..." |> Menu.stub__TODO
                ; Menu.separator ()
                ; "&Quit" |> Menu.verb App.exitA
                ]
            ; "&Edit" |> Menu.stub__TODO
            ; "&View" |> Menu.stub__TODO
            ; "&Help" |> Menu.strip
                [ "&Technical Details 🚀"
                    |> Menu.verb (fun _ -> (
                        Sys.openUrlInBrowser
                            GitHubProjectUrl ))
                ; Menu.separator ()
                ; $"&About {AppName}"
                    |> Menu.verb (fun _ -> (
                        MessageBox.showText
                            $"{AppName} v{``FWinForms Version``}"
                            $"About {AppName}" ))
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
    |> Form.clientSize 640 400
    |> Form.addControls
        [ Layout.panel
            [ "Test"
                |> Control.button (fun _ -> (
                    MessageBox.showText
                        $"TEST * TEST * TEST"
                        $"{AppName}"))
            ]
        ; mainStatusBar
        ; mainMenu
        ]
    |> Form.initEnd

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