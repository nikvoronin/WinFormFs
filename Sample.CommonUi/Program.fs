open System
open FWinForms

[<Literal>]
let AppName = "FWinForms"
[<Literal>]
let GitHubProjectUrl = "https://github.com/nikvoronin/FWinForms"

let mainForm =
    let mainMenu =
        Menu.create
            [ Menu.top "&File"
                [ Menu.sub "&Open..." Stub.doNothingA__TODO
                ; Menu.sub "&Save As..." Stub.doNothingA__TODO
                ; Menu.separator ()
                ; Menu.sub "&Quit" App.exitA
                ]
            ; Menu.top "&Edit" []
            ; Menu.top "&View" []
            ; Menu.top "&Help"
                [ Menu.sub
                    "&Technical Details 🚀"
                    (fun x -> (Sys.openUrlInBrowser GitHubProjectUrl))
                ; Menu.separator ()
                ; Menu.sub
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
            [ Menu.sub "&Open..." Stub.doNothingA__TODO
            ; Menu.sub "&Save As..." Stub.doNothingA__TODO
            ; Menu.separator ()
            ; Menu.sub "&Quit" App.exitA
            ]
        )
    |> SystemTray.showIcon true

[<EntryPoint; STAThread>]
let main argv =
    use _ = mainNotifyIcon

    App.initSysRender
    App.runWith mainForm