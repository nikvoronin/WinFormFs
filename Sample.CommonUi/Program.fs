open System
open FWinForms

[<Literal>]
let AppName = "FWinForms"
[<Literal>]
let GitHubProjectUrl = "https://github.com/nikvoronin/FWinForms"

let mainForm =
    let mainMenu =
        Menu.create
            [ Menu.strip "&File"
                [ Menu.verb "&Open..." Stub.doNothingA__TODO
                ; Menu.verb "&Save As..." Stub.doNothingA__TODO
                ; Menu.separator ()
                ; Menu.verb "&Quit" App.exitA
                ]
            ; Menu.strip "&Edit" []
            ; Menu.strip "&View" []
            ; Menu.strip "&Help"
                [ Menu.verb
                    "&Technical Details 🚀"
                    (fun x -> (Sys.openUrlInBrowser GitHubProjectUrl))
                ; Menu.separator ()
                ; Menu.verb
                   $"&About {AppName}"
                    (fun x -> (
                        MessageBox.showText
                            $"{AppName} v{``FWinForms Version``}"
                            $"About {AppName}"))
                ]
            ]

    let mainStatusBar =
        StatusBar.create
            [ StatusBar.label "Ready"
            ; StatusBar.separator ()
            ; StatusBar.label "Want to know more? Select 'Help → ..."
            ]

    "WinForms ♥ F#"
    |> Form.create
    |> Form.beginInit
    |> Form.clientSize 640 400
    |> Form.addControls
        [ Layout.panel
            [ Control.button
                "Test"
                (fun x -> (
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
            [ Menu.verb "&Open..." Stub.doNothingA__TODO
            ; Menu.verb "&Save As..." Stub.doNothingA__TODO
            ; Menu.separator ()
            ; Menu.verb "&Quit" App.exitA
            ]
        )
    |> SystemTray.showIcon true

[<EntryPoint; STAThread>]
let main argv =
    use _ = mainNotifyIcon

    App.initSysRender
    App.runWith mainForm